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
using System.IO;

namespace PEG.User_Controls
{
    public partial class UCCadastroNoticiaIA : UCBase
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

        public void Editar(Int32 IdNoticia)
        {
            EntNoticia objNoticia = new BllNoticia().ObterPorId(IdNoticia);
            this.ObjectToPage(objNoticia);
            this.Show();
        }

        public void Inserir()
        {
            this.PopulaEstado();
            this.PopulaTurma();
            this.PopulaGridQuestionarioIncluir();
            this.ChckBxAtivo.Checked = true;
            this.rdTipoUsuarioAdministrativo.Checked = false;
            this.rdTipoUsuarioEmpresa.Checked = false;
            this.lblGrupoDiv.Style.Add("display", "none");
            this.grdGrupoDiv.Style.Add("display", "none");
            this.ImgAtual.Visible = false;
            this.FCKeditor1.Value = "";
            this.Show();
        }

        private Boolean PageToObject(EntNoticia objNoticia)
        {
            objNoticia.IdNoticia = StringUtils.ToInt(this.HddnFldIdNoticia.Value);
            objNoticia.Titulo = this.TxtBxNome.Text;
            objNoticia.Noticia = this.FCKeditor1.Value;
            objNoticia.DataAlteracao = DateTime.Now;
            objNoticia.Estado.IdEstado = int.Parse(this.DrpDwnLstEstado.SelectedValue);
            objNoticia.Programa.IdPrograma = this.objPrograma.IdPrograma;
            objNoticia.Turma.IdTurma = int.Parse(this.DrpDwnLstTurma.SelectedValue);
            if (this.rdTipoUsuarioAdministrativo.Checked)
            {
                objNoticia.UsuarioAdministrativo = true;
            }
            else if (this.rdTipoUsuarioEmpresa.Checked)
            {
                objNoticia.UsuarioAdministrativo = false;
            }
            objNoticia.DataVigenciaFim = StringUtils.ToDate(this.TxtBxDataValidade.Text);
            objNoticia.Ativo = this.ChckBxAtivo.Checked;
            objNoticia.ListNoticiaGrupo = this.obterGruposSelecionados();

            if (Session["flNameNoticia"] != null)
            {
                objNoticia.UrlImagem = Session["flNameNoticia"].ToString();
                Session.Remove("flNameNoticia");
                return true;
            }
            return false;

        }

        protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AsyncFileUpload1.HasFile)
            {
                if (!AsyncFileUpload1.ContentType.Contains("image"))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Tipo de iamgem inválido');", true);
                }
                else
                {
                    String flName = AsyncFileUpload1.FileName.Substring(0, AsyncFileUpload1.FileName.LastIndexOf(".")) + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + AsyncFileUpload1.FileName.Substring(AsyncFileUpload1.FileName.LastIndexOf("."));
                    AsyncFileUpload1.SaveAs(Server.MapPath(this.PathDownloadArquivos + flName));
                    Session.Add("flNameNoticia", flName);
                }
            }
        }

        private void ObjectToPage(EntNoticia objNoticia)
        {
            this.HddnFldIdNoticia.Value = IntUtils.ToString(objNoticia.IdNoticia);
            this.HddnFldArquivo.Value = objNoticia.UrlImagem;
            this.TxtBxNome.Text = objNoticia.Titulo;
            this.FCKeditor1.Value = objNoticia.Noticia;
            this.TxtBxDataValidade.Text = DateUtils.ToString(objNoticia.DataVigenciaFim);
            if (objNoticia.UsuarioAdministrativo)
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
            this.ChckBxAtivo.Checked = objNoticia.Ativo;

            this.PopulaEstado();
            this.PopulaTurma();
            this.DrpDwnLstEstado.SelectedValue = objNoticia.Estado.IdEstado.ToString();
            this.DrpDwnLstTurma.SelectedValue = objNoticia.Turma.IdTurma.ToString();

            this.LblImgAtual.Visible = true;
            this.ImgAtual.Visible = true;
            this.ImgAtual.ImageUrl = PathDownloadArquivos + objNoticia.UrlImagem;

            this.PopulaGridQuestionarioIncluir(objNoticia.IdNoticia);
        }

        private Boolean Gravar()
        {
            EntNoticia objNoticia = new EntNoticia();

            if (!this.PageToObject(objNoticia))
            {
                objNoticia.UrlImagem = HddnFldArquivo.Value;
            }

            try
            {
                //Verifica se é Insert ou Update
                if (objNoticia.IdNoticia == 0)
                {
                    objNoticia = new BllNoticia().Inserir(objNoticia);
                    MessageBox(this.Page, "Notícia inserida com sucesso!");
                }
                else
                {
                    new BllNoticia().Alterar(objNoticia);
                    MessageBox(this.Page, "Notícia alterada com sucesso!");
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar a Notícia!");
                return false;
            }
        }

        private List<EntNoticiaGrupo> obterGruposSelecionados()
        {
            List<EntNoticiaGrupo> res = new List<EntNoticiaGrupo>();
            foreach (GridViewRow item in this.grdGrupoIncluir.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {
                    if (((CheckBox)item.Cells[4].Controls[1]).Checked)
                    {
                        EntNoticiaGrupo objNoticiaGrupo = new EntNoticiaGrupo();
                        if (this.HddnFldIdNoticia.Value != "")
                        {
                            objNoticiaGrupo.Noticia.IdNoticia = int.Parse(this.HddnFldIdNoticia.Value);
                        }
                        objNoticiaGrupo.AdmGrupo.IdGrupo = StringUtils.ToInt(((Label)this.grdGrupoIncluir.Rows[item.DataItemIndex].Cells[0].FindControl("lblIdGrupo")).Text);

                        res.Add(objNoticiaGrupo);
                    }
                }
            }

            return res;
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

        private void PopulaGridQuestionarioIncluir()
        {
            this.grdGrupoIncluir.DataSource = new BllAdmGrupo().ObterTodos(this.objPrograma.IdPrograma);
            this.grdGrupoIncluir.DataBind();
        }

        private void PopulaGridQuestionarioIncluir(Int32 IdNoticia)
        {
            this.grdGrupoIncluir.DataSource = new BllAdmGrupo().ObterTodosPorNoticia(IdNoticia, this.objPrograma.IdPrograma);
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
    }
}