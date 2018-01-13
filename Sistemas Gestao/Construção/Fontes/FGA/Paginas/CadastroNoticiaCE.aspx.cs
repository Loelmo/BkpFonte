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
    public partial class CadastroNoticiaCE : PaginaBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (ValidaPermissaoBotao(this, EnumType.TipoAcao.Atualizar))
            {
                this.grdNoticia.Columns[5].HeaderText = "Alterar";
            }
            else
            {
                this.grdNoticia.Columns[5].HeaderText = "Visualizar";
            }

            this.UCCadastroNoticiaIA1.atualizaGrid += this.PopulaGridNoticia;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.rdTipoUsuarioEmpresa.Checked)
            {
                lblGrupoAcesso.Style.Add("display", "none");
                drpDwnGrupoAcesso.Style.Add("display", "none");
            }
            else if (this.rdTipoUsuarioAdministrativo.Checked)
            {
                lblGrupoAcesso.Style.Add("display", "block");
                drpDwnGrupoAcesso.Style.Add("display", "block");
            }
            if (!IsPostBack)
            {
                EntNoticia objNoticia = new EntNoticia();
                this.PopulaGrupo();

                this.PageToObject(objNoticia);

                this.PopulaGridNoticia();
                this.ImgBttnIncluir.Visible = ValidaPermissaoBotao(this, EnumType.TipoAcao.Inserir);
            }
            this.UCCadastroNoticiaIA1.atualizaGrid += this.PopulaGridNoticia;
        }

        private void AtualizaGrid()
        {
            this.grdNoticia.DataSource = ListaGrid;
            this.grdNoticia.DataBind();
            this.grdNoticia.SelectedIndex = -1;
        }

        
        private void PopulaGridNoticia()
        {
            EntNoticia objNoticia = new EntNoticia();

            this.PageToObject(objNoticia);

            ListaGrid = new BllNoticia().ObterPorFiltro(objNoticia);
            this.AtualizaGrid();
        }

        private void PopulaGrupo()
        {
            this.DrpDwnLstGrupo.Items.Clear();

            this.DrpDwnLstGrupo.DataSource = new BllAdmGrupo().ObterTodos(this.objPrograma.IdPrograma);
            this.DrpDwnLstGrupo.DataBind();
            this.DrpDwnLstGrupo.Items.Insert(0, new ListItem("<< Todos >>", "0"));
            this.DrpDwnLstGrupo.SelectedValue = "0";
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCCadastroNoticiaIA1.Inserir();
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridNoticia();
        }

        private void PageToObject(EntNoticia objNoticia)
        {
            objNoticia.Titulo = this.TxtBxTitulo.Text;
            objNoticia.DataCadastroFiltroInicial = StringUtils.ToDate(this.TxtBxDataInicio.Text);
            objNoticia.DataCadastroFiltroFinal = StringUtils.ToDateFim(this.TxtBxDataFim.Text);
            if(rdTipoUsuarioEmpresa.Checked){
                objNoticia.UsuarioAdministrativo = false;
            }
            else if (rdTipoUsuarioAdministrativo.Checked)
            {
                objNoticia.UsuarioAdministrativo = true;
            }
            objNoticia.IdGrupoFiltro = int.Parse(DrpDwnLstGrupo.SelectedValue);
            if (chkBoxAtivo.Checked)
            {
                objNoticia.Ativo = true;
            }
            else
            {
                objNoticia.Ativo = false;
            }
            objNoticia.Estado.IdEstado = UsuarioLogado.Estado.IdEstado;
            objNoticia.Programa.IdPrograma = objPrograma.IdPrograma;
            objTurma.IdTurma = objTurma.IdTurma;
        }

        protected void grdNoticia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdNoticia.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        protected void grdNoticia_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataKey dk = this.grdNoticia.DataKeys[e.RowIndex];
            this.grdNoticia.SelectedIndex = -1;
            this.UCCadastroNoticiaIA1.Editar(ObjectUtils.ToInt(dk.Value));
        }
         
        protected void grdNoticia_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataKey dk = grdNoticia.DataKeys[e.RowIndex];

                EntNoticia objNoticia = new BllNoticia().ObterPorId(ObjectUtils.ToInt(dk.Value));
                objNoticia.Ativo = !objNoticia.Ativo;

                new BllNoticia().Alterar(objNoticia);
                this.PopulaGridNoticia();

                MessageBox(this, "Notícia alterada com sucesso!");
            }
            catch (Exception)
            {
            }

        }

        protected void grdNoticia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Boolean PermissaoExcluir = ValidaPermissaoBotao(this, EnumType.TipoAcao.Excluir);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnAlterar = ((ImageButton)e.Row.FindControl("ImagBttnAlterar"));
                btnAlterar.ToolTip = "Alterar Notícia";

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
                    imageUrl = "~/Image/file_delete.png";
                }

                btnAtivo.ImageUrl = imageUrl;
                HabilitaDesabilitaBotao(btnAtivo, PermissaoExcluir);
            }

        }
    }
}