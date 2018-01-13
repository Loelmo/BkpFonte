using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using System.IO;

namespace PEG.User_Controls
{
    public partial class UCCadastroGrupoEmpresaIA : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            this.UCCadastroGrupoEmpresaIncluir1.AtualizaEmpresasInseridasDelegate += this.AtualizaEmpresasInseridasDelegate;
        }

        private void Show(EnumType.StateIA stateIA)
        {
            this.divUserControl.Visible = true;

            Boolean bPermissao;

            if (stateIA == EnumType.StateIA.Inserir)
            {
                bPermissao = ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Inserir);
            }
            else
            {
                bPermissao = ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar);
            }

            if (bPermissao)
            {
                EnableControl(this.PnlFundo.Controls, true);
                this.TxtNome.Enabled = true;
                this.ImgBttnGravar.Visible = true;
                this.ImgBttnIncluir.Visible = true;
            }
            else
            {
                EnableControl(this.PnlFundo.Controls, false);
                this.TxtNome.Enabled = false;
                this.ImgBttnGravar.Visible = false;
                this.ImgBttnIncluir.Visible = false;
            }
        }

        private void Close()
        {
            this.divUserControl.Visible = false;
            this.Clear();
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        public void Inserir(EnumType.StateIA stateIA)
        {
            this.HddnFldGrupo.Value = "0";

            PopulaGridEmpresa(0);
            this.PopulaSetor();
            this.PopulaTurma(this.Page.Title);

            this.Show(stateIA);
        }

        private void PopulaSetor()
        {
            this.ddlSetor.Items.Clear();
            //this.ddlSetor.Items.Add(new ListItem("Selecione", "0"));
            this.ddlSetor.DataSource = new BllSetor().ObterTodos();
            this.ddlSetor.DataBind();
        }

        private void PopulaGridEmpresa(Int32 IdGrupo)
        {
            populaGridSession(new BllEmpresaCadastro().ObterTodosPorGrupo(IdGrupo));
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCCadastroGrupoEmpresaIncluir1.Inserir(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue));
        }

        private void AtualizaEmpresasInseridasDelegate()
        {
            //this.Show();
            populaGridSession((List<EntEmpresaCadastro>)Session["EmpresasAssociadas"]);
        }

        protected void grdEmpresa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<EntEmpresaCadastro> lstEmpresaCadastro = (List<EntEmpresaCadastro>)Session["EmpresasAssociadas"];

            for (int i = 0; i < lstEmpresaCadastro.Count; i++)
            {
                if (lstEmpresaCadastro[i].IdEmpresaCadastro == StringUtils.ToInt(this.grdEmpresa.DataKeys[e.RowIndex].Value.ToString()))
                {
                    lstEmpresaCadastro.RemoveAt(i);
                    i--;
                }
            }
            populaGridSession(lstEmpresaCadastro);
        }

        private void populaGridSession(List<EntEmpresaCadastro> list)
        {
            Session["EmpresasAssociadas"] = list;
            this.grdEmpresa.DataSource = Session["EmpresasAssociadas"];
            this.grdEmpresa.DataBind();
        }

        protected void ImgBttnGravar_Click1(object sender, ImageClickEventArgs e)
        {
            if (this.VerificaCamposObrigatoriosCadastro())
		    {
                this.Gravar();
                this.Clear();
                this.atualizaGrid();
                this.Close();
            }
            else
            {
                MessageBox(this.Page, "Favor preencher os campos obrigatórios (em destaque).");
            }
        }

        private Boolean VerificaCamposObrigatoriosCadastro()
        {
         
            Boolean res = true;
            res &= Valida_TextBox(TxtNome);
            res &= Valida_DropDownList(DrpDwnLstTurma);
            res &= Valida_DropDownList(DrpDwnLstEstado);
            
            return res;
        
        }

        protected void ImgBttnCancelar_Click1(object sender, ImageClickEventArgs e)
        {
            this.Close();
        }

        private void Gravar()
        {
            EntGrupo objGrupo = new EntGrupo();
            List<EntEmpresaCadastro> lstEmpresaCadastro = (List<EntEmpresaCadastro>)Session["EmpresasAssociadas"];
            PageToObject(objGrupo);

            try
            {
                string msg = "";
                //Verifica se é Insert ou Update
                if (objGrupo.IdGrupo == 0)
                {

                    if (new BllGrupo().ExisteGrupoPorTurma(this.TxtNome.Text, StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue)))
                    {
                        msg = "Já existe um Grupo cadastrado com esse nome para essa turma!";
                    }
                    else
                    {
                        objGrupo = new BllGrupo().InserirComEmpresas(objGrupo, lstEmpresaCadastro);
                        if (objGrupo.IdGrupo > 0)
                        {
                            msg = "Grupo e Empresas inseridos com sucesso!";
                        }
                    }

                    MessageBox(this.Page, msg);
                }
                else
                {
                    new BllGrupo().AlterarComEmpresas(objGrupo, lstEmpresaCadastro);
                    msg = "Grupo e Empresas alterados com sucesso!";
                    MessageBox(this.Page, msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar!");
                //logger.Error("Erro ao inserir o Escritório Regional!", ex);
            }
        }

        private void PageToObject(EntGrupo objGrupo)
        {
            objGrupo.IdGrupo = StringUtils.ToInt(this.HddnFldGrupo.Value.ToString());
            objGrupo.Ativo = true;
            objGrupo.Estado.IdEstado = StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue);
            objGrupo.Grupo = this.TxtNome.Text;
            objGrupo.Setor.IdSetor = StringUtils.ToInt(this.ddlSetor.SelectedItem.Value);
            objGrupo.Setor.Setor = this.ddlSetor.SelectedItem.Text;
            objGrupo.Turma.IdTurma = StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue);
            objGrupo.Descricao = this.txtDescricao.Text;
        }

        private void ObjectToPage(EntGrupo objGrupo)
        {
            this.HddnFldGrupo.Value = IntUtils.ToString(objGrupo.IdGrupo);
            this.PopulaTurma(this.Page.Title);
            this.DrpDwnLstTurma.SelectedValue = IntUtils.ToString(objGrupo.Turma.IdTurma);
            this.PopulaEstado(objGrupo.Turma.IdTurma, this.Page.Title);
            this.DrpDwnLstEstado.SelectedValue = IntUtils.ToString(objGrupo.Estado.IdEstado);
            this.TxtNome.Text = objGrupo.Grupo;
            this.ddlSetor.SelectedValue = IntUtils.ToString(objGrupo.Setor.IdSetor);
            this.txtDescricao.Text = objGrupo.Descricao;
        }

        public void Editar(int IdGrupo, EnumType.StateIA stateIA)
        {
            this.HddnFldGrupo.Value = "0";
            this.PopulaSetor();

            EntGrupo objGrupo = new BllGrupo().ObterPorId(IdGrupo);
            PopulaGridEmpresa(objGrupo.IdGrupo);
            ObjectToPage(objGrupo);
            this.Show(stateIA);
        }

        public void Copiar(int IdGrupo)
        {
            this.PopulaSetor();

            EntGrupo objGrupo = new BllGrupo().ObterPorId(IdGrupo);
            PopulaGridEmpresa(objGrupo.IdGrupo);
            ObjectToPage(objGrupo);
            this.TxtNome.Text = String.Empty;
            this.HddnFldGrupo.Value = "0";
            this.Show(EnumType.StateIA.Inserir);
        }

        protected void grdEmpresa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Boolean PermissaoExcluir = ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                ImageButton btnExcluir = ((ImageButton)e.Row.FindControl("imgExcluir"));
                btnExcluir.ToolTip = "Excluir";

                RegistraScriptExcluirGrid(this.Page, btnExcluir, "Confirma Exclusão?");

                btnExcluir.Enabled = PermissaoExcluir;

            }
        }

        protected void DrpDwnLstTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaEstado(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), this.Page.Title.ToString());
        }

        public void PopulaTurma(String sFuncionalidade)
        {
            this.DrpDwnLstTurma.Items.Clear();

            this.DrpDwnLstTurma.DataSource = UsuarioLogado.lstTurmasPermitidas.FindAll(delegate(EntTurmasPermitidas objTurmasPermitidas) { return objTurmasPermitidas.Funcionalidade == sFuncionalidade; });
            this.DrpDwnLstTurma.DataBind();

            //if (this.DrpDwnLstTurma.Items.Count == 1)
            //{
            //    this.PopulaEstado(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), sFuncionalidade);
            //}
            this.DrpDwnLstTurma.Items.Insert(0, new ListItem("<< Selecione uma Turma >>", "0"));
            this.DrpDwnLstTurma.SelectedValue = "0";
        }

        private void PopulaEstado(Int32 IdTurma, String sFuncionalidade)
        {

            if (IdTurma != 0)
            {
                this.DrpDwnLstEstado.Items.Clear();

                List<EntEstadosPermitidos> lstEstadosPermitidos1 = UsuarioLogado.lstEstadoPermitidos.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.IdTurma == IdTurma; });

                this.DrpDwnLstEstado.DataSource = lstEstadosPermitidos1.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.Funcionalidade == sFuncionalidade; });
                this.DrpDwnLstEstado.DataBind();

                if (this.DrpDwnLstEstado.Items.Count == 0)
                {
                    //this.DrpDwnLstEstado.DataSource = UsuarioLogado.lstEstadoPermitidos.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.Funcionalidade == sFuncionalidade; });
                    this.DrpDwnLstEstado.DataSource = new BllEstado().ObterTodos();
                    this.DrpDwnLstEstado.DataBind();
                }

                this.DrpDwnLstEstado.Items.Insert(0, new ListItem("<< Selecione um Estado >>", "0"));
                this.DrpDwnLstEstado.SelectedValue = "0";
            }
            else
            {
                this.DrpDwnLstEstado.Items.Clear();
                this.DrpDwnLstEstado.Items.Insert(0, new ListItem("<< Selecione uma Turma>>", "0"));
                this.DrpDwnLstEstado.SelectedValue = "0";
            }
        }

    }
}