using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using System.Net;
using System.IO;

namespace PEG.User_Controls
{
    public partial class UCCadastroArquivoIA : UCBase
    {

        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
        }

        private void Show()
        {
            this.divUserControl.Visible = true;

            if (!ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar))
            {
                EnableControl(this.PnlFundo.Controls, false);
                this.ImgBttnGravar.Visible = false;
            }
            else
            {
                EnableControl(this.PnlFundo.Controls, true);
                this.ImgBttnGravar.Visible = true;
                this.ChckBxAtivo.Enabled = ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Excluir);
            }
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        protected void ImgBttnGravar_Click(object sender, ImageClickEventArgs e)
        {
            if (this.VerificaCamposObrigatoriosCadastro())
            {
                if (this.Gravar())
                {
                    this.Clear();
                    this.Close();

                    if (atualizaGrid != null)
                    {
                        this.atualizaGrid();
                    }
                }
            }
            else
            {
                MessageBox(this.Page, "Favor preencher os campos obrigatórios (em destaque).");
            }
        }

        private Boolean VerificaCamposObrigatoriosCadastro()
        {
            Boolean res = true;
            res &= Valida_TextBox(TxtBxNome);

            return res;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        public void Editar(Int32 IdArquivo)
        {
            EntArquivo objArquivo = new BllArquivo().ObterPorId(IdArquivo);
            this.ObjectToPage(objArquivo);
            this.Show();
        }

        public void Inserir()
        {
            this.PopulaEstado();
            this.PopulaTurma();
            this.PopulaPrioridade();
            this.PopulaGridQuestionarioIncluir();
            this.lblGrupoDiv.Style.Add("display", "none");
            this.grdGrupoDiv.Style.Add("display", "none");
            this.ChckBxAtivo.Checked = true;
            this.rdTipoUsuarioAdministrativo.Checked = false;
            this.rdTipoUsuarioEmpresa.Checked = false;
            this.Show();
        }

        private Boolean PageToObject(EntArquivo objArquivo)
        {
            objArquivo.IdArquivo = StringUtils.ToInt(this.HddnFldIdArquivo.Value);
            objArquivo.Titulo = this.TxtBxNome.Text;
            objArquivo.DataAlteracao = DateTime.Now;
            objArquivo.Prioridade = int.Parse(this.DrpDwnLstPrioridade.SelectedValue);
            objArquivo.Estado.IdEstado = int.Parse(this.DrpDwnLstEstado.SelectedValue);
            objArquivo.Programa.IdPrograma = this.objPrograma.IdPrograma;
            objArquivo.Turma.IdTurma = int.Parse(this.DrpDwnLstTurma.SelectedValue);
            if (this.rdTipoUsuarioAdministrativo.Checked)
            {
                objArquivo.UsuarioAdministrativo = true;
            }
            else if (this.rdTipoUsuarioEmpresa.Checked)
            {
                objArquivo.UsuarioAdministrativo = false;
            }
            objArquivo.Ativo = this.ChckBxAtivo.Checked;
            objArquivo.ListArquivoGrupo = this.obterGruposSelecionados();

            if (Session["flNameArquivo"] != null)
            {
                objArquivo.Arquivo = Session["flNameArquivo"].ToString();
                Session.Remove("flNameArquivo");
                return true;
            }
            return false;
        }

        protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AsyncFileUpload1.HasFile)
            {
                String flNameArquivo = AsyncFileUpload1.FileName.Substring(0, AsyncFileUpload1.FileName.LastIndexOf(".")) + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + AsyncFileUpload1.FileName.Substring(AsyncFileUpload1.FileName.LastIndexOf("."));
                AsyncFileUpload1.SaveAs(Server.MapPath(this.PathDownloadArquivos + flNameArquivo));
                Session.Add("flNameArquivo", flNameArquivo);
            }
        }

        private void ObjectToPage(EntArquivo objArquivo)
        {
            this.HddnFldIdArquivo.Value = IntUtils.ToString(objArquivo.IdArquivo);
            this.HddnFldArquivo.Value = objArquivo.Arquivo;
            this.TxtBxNome.Text = objArquivo.Titulo;
            if (objArquivo.UsuarioAdministrativo)
            {
                this.rdTipoUsuarioAdministrativo.Checked = true;
                this.lblGrupoDiv.Style.Add("display", "block");
                this.grdGrupoDiv.Style.Add("display", "block");
            }
            else
            {
                this.rdTipoUsuarioEmpresa.Checked = true;
                this.lblGrupoDiv.Style.Add("display", "none");
                this.grdGrupoDiv.Style.Add("display", "none");
            }
            this.ChckBxAtivo.Checked = objArquivo.Ativo;

            this.PopulaEstado();
            this.PopulaTurma();
            this.PopulaPrioridade();
            this.DrpDwnLstEstado.SelectedValue = objArquivo.Estado.IdEstado.ToString();
            this.DrpDwnLstTurma.SelectedValue = objArquivo.Turma.IdTurma.ToString();
            this.DrpDwnLstPrioridade.SelectedValue = objArquivo.Prioridade.ToString();

            this.PopulaGridQuestionarioIncluir(objArquivo.IdArquivo);
        }

        private Boolean Gravar()
        {
            EntArquivo objArquivo = new EntArquivo();

            if (!this.PageToObject(objArquivo))
            {
                objArquivo.Arquivo = HddnFldArquivo.Value;
            }

            try
            {
                //Verifica se é Insert ou Update
                if (objArquivo.IdArquivo == 0)
                {
                    objArquivo = new BllArquivo().Inserir(objArquivo);
                    MessageBox(this.Page, "Arquivo inserido com sucesso!");
                }
                else
                {
                    new BllArquivo().Alterar(objArquivo);
                    MessageBox(this.Page, "Arquivo alterado com sucesso!");
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar o Arquivo!");
                return false;
            }
        }

        private List<EntArquivoGrupo> obterGruposSelecionados()
        {
            List<EntArquivoGrupo> res = new List<EntArquivoGrupo>();
            foreach (GridViewRow item in this.grdGrupoIncluir.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {
                    if (((CheckBox)item.Cells[4].Controls[1]).Checked)
                    {
                        EntArquivoGrupo objArquivoGrupo = new EntArquivoGrupo();
                        if (this.HddnFldIdArquivo.Value != "")
                        {
                            objArquivoGrupo.Arquivo.IdArquivo = int.Parse(this.HddnFldIdArquivo.Value);
                        }
                        objArquivoGrupo.AdmGrupo.IdGrupo = StringUtils.ToInt(((Label)this.grdGrupoIncluir.Rows[item.DataItemIndex].Cells[0].FindControl("lblIdGrupo")).Text);

                        res.Add(objArquivoGrupo);
                    }
                }
            }

            return res;
        }

        private void PopulaGridQuestionarioIncluir()
        {
            this.grdGrupoIncluir.DataSource = new BllAdmGrupo().ObterTodos(this.objPrograma.IdPrograma);
            this.grdGrupoIncluir.DataBind();
        }

        private void PopulaGridQuestionarioIncluir(Int32 IdArquivo)
        {
            this.grdGrupoIncluir.DataSource = new BllAdmGrupo().ObterTodosPorArquivo(IdArquivo, this.objPrograma.IdPrograma);
            this.grdGrupoIncluir.DataBind();
        }

        private void PopulaEstado()
        {
            this.DrpDwnLstEstado.Items.Clear();

            this.DrpDwnLstEstado.DataSource = new BllEstado().ObterTodos();
            this.DrpDwnLstEstado.DataBind();
            this.DrpDwnLstEstado.Items.Insert(0, new ListItem("<< Todos >>", "0"));
            this.DrpDwnLstEstado.SelectedValue = "0";
        }

        private void PopulaTurma()
        {
            this.DrpDwnLstTurma.Items.Clear();

            this.DrpDwnLstTurma.DataSource = new BllTurma().ObterPorIdPrograma(this.objPrograma.IdPrograma);
            this.DrpDwnLstTurma.DataBind();
            this.DrpDwnLstTurma.Items.Insert(0, new ListItem("<< Todas >>", "0"));
            this.DrpDwnLstTurma.SelectedValue = "0";
        }

        private void PopulaPrioridade()
        {
            this.DrpDwnLstPrioridade.Items.Clear();

            this.DrpDwnLstPrioridade.Items.Add(new ListItem("Alta", EntArquivo.ARQUIVO_PRIORIDADE_ALTA.ToString()));
            this.DrpDwnLstPrioridade.Items.Add(new ListItem("Média", EntArquivo.ARQUIVO_PRIORIDADE_MEDIA.ToString()));
            this.DrpDwnLstPrioridade.Items.Add(new ListItem("Baixa", EntArquivo.ARQUIVO_PRIORIDADE_BAIXA.ToString()));
            this.DrpDwnLstPrioridade.SelectedValue = EntArquivo.ARQUIVO_PRIORIDADE_ALTA.ToString();
        }

        protected void grdGrupo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSelecionado = (Label)e.Row.FindControl("lblFlSelecionado");
                CheckBox chkIncluir = (CheckBox)e.Row.FindControl("ChkIncluir");
                if (lblSelecionado.Text == "True")
                {
                    chkIncluir.Checked = true;
                }
                else
                {
                    chkIncluir.Checked = false;
                }
            }

        }

    }
}