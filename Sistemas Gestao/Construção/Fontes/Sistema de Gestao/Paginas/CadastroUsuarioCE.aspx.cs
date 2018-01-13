using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.Ent;

namespace Sistema_de_Gestao
{
    public partial class CadastroUsuarioCE : PaginaBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (ValidaPermissaoBotao(this, EnumType.TipoAcao.Atualizar))
            {
                this.grdUsuario.Columns[6].HeaderText = "Alterar";
            }
            else
            {
                this.grdUsuario.Columns[6].HeaderText = "Visualizar";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EntAdmUsuario objAdmUsuario = new EntAdmUsuario();

                this.PageToObject(objAdmUsuario);

                this.PopulaGridUsuario();
                this.PopulaEstado();

                this.ImgBttnIncluir.Visible = ValidaPermissaoBotao(this, EnumType.TipoAcao.Inserir);
            }
            this.UCCadastroUsuarioIA1.atualizaGrid += this.PopulaGridUsuario;
            
        }

        private void AtualizaGrid()
        {
            this.grdUsuario.DataSource = ListaGrid;
            this.grdUsuario.DataBind();
            this.grdUsuario.SelectedIndex = -1;
        }
                
        private void PopulaGridUsuario()
        {
            EntAdmUsuario objAdmUsuario = new EntAdmUsuario();

            this.PageToObject(objAdmUsuario);

            ListaGrid = new BllAdmUsuario().ObterPorFiltro(objAdmUsuario, objPrograma.IdPrograma);
            this.AtualizaGrid();
        }

        private void PopulaEstado()
        {
            this.DrpDwnLstEstado.Items.Clear();

            this.DrpDwnLstEstado.DataSource = UsuarioLogado.lstEstadoPermitidos.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.Funcionalidade == this.Title; });
            this.DrpDwnLstEstado.DataBind();

            if (this.DrpDwnLstEstado.Items.Count == 0)
            {
                this.DrpDwnLstEstado.DataSource = new BllEstado().ObterTodos();
                this.DrpDwnLstEstado.DataBind();
            }

            this.DrpDwnLstEstado.Items.Insert(0, new ListItem("Todos", "0"));
            this.DrpDwnLstEstado.SelectedValue = "0";
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCCadastroUsuarioIA1.Inserir();
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridUsuario();
        }

        private void PageToObject(EntAdmUsuario objAdmUsuario)
        {
            objAdmUsuario.IdUsuario = UsuarioLogado.IdUsuario;
            objAdmUsuario.Usuario = this.TxtBxUsuario.Text;
            objAdmUsuario.Login = this.TxtBxLogin.Text;
            objAdmUsuario.CPF = StringUtils.OnlyNumbers(this.TxtBxCPF.Text);
            objAdmUsuario.Telefone = StringUtils.OnlyNumbers(this.TxtBxTelefone.Text);
            objAdmUsuario.Email = this.TxtBxEmail.Text;
            objAdmUsuario.Estado.IdEstado = StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue);
            objAdmUsuario.Ativo = this.ChckBxAtivo.Checked;
        }

        protected void grdUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUsuario.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        protected void grdUsuario_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataKey dk = this.grdUsuario.DataKeys[e.RowIndex];
            this.grdUsuario.SelectedIndex = -1;
            this.UCCadastroUsuarioIA1.Editar(ObjectUtils.ToInt(dk.Value));
        }
         
        protected void grdUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataKey dk = grdUsuario.DataKeys[e.RowIndex];

                EntAdmUsuario objUsuario = new BllAdmUsuario().ObterPorId(ObjectUtils.ToInt(dk.Value));
                objUsuario.Ativo = !objUsuario.Ativo;

                new BllAdmUsuario().Alterar(objUsuario);
                this.PopulaGridUsuario();

                MessageBox(this, "Ação alterado com sucesso!");
            }
            catch (Exception)
            {
            }

        }

        protected void grdUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Boolean PermissaoExcluir = ValidaPermissaoBotao(this, EnumType.TipoAcao.Excluir);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnAlterar = ((ImageButton)e.Row.FindControl("ImagBttnAlterar"));
                btnAlterar.ToolTip = "Alterar Usuário";

                ImageButton btnAtivo = ((ImageButton)e.Row.FindControl("ImagBttnAtivo"));
                btnAtivo.ToolTip = "Ativar e Inativar";

                RegistraScriptExcluirGrid(this, btnAtivo, "Confirma Ativação/Inativação?");

                String imageUrl;
                Label lblAtivoAux = (Label)e.Row.FindControl("LblAtivo");

                if (lblAtivoAux.Text == "True")
                {
                    imageUrl = "~/Image/_file_Ok2.png";
                }
                else
                {
                    imageUrl = "~/Image/file_delete2.png";
                }

                btnAtivo.ImageUrl = imageUrl;
                HabilitaDesabilitaBotao(btnAtivo, PermissaoExcluir);
                
            }

        }
    }
}