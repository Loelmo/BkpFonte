using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;

namespace Sistema_de_Gestao.Paginas
{
    public partial class CadastroGrupoAcessoCE : PaginaBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (ValidaPermissaoBotao(this, EnumType.TipoAcao.Inserir))
            {
                this.grdGrupoAcesso.Columns[2].HeaderText = "Inserir Funcionalidade";
            }
            else
            {
                this.grdGrupoAcesso.Columns[2].HeaderText = "Visualizar";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulaGridAdmGrupo();
                this.ImgBttnIncluir.Visible = ValidaPermissaoBotao(this, EnumType.TipoAcao.Inserir);
            }
            this.UCCadastroGrupoAcessoIA1.atualizaGrid += this.PopulaGridAdmGrupo;
        }

        private void AtualizaGrid()
        {
            this.grdGrupoAcesso.DataSource = ListaGrid;
            this.grdGrupoAcesso.DataBind();
            this.grdGrupoAcesso.SelectedIndex = -1;
        }

        private void PopulaGridAdmGrupo()
        {
            ListaGrid = new BllAdmGrupo().ObterTodos(this.objPrograma.IdPrograma);
            this.AtualizaGrid();
        }

        private void PopulaGridAdmGrupo(String sNome)
        {
            ListaGrid = new BllAdmGrupo().ObterPorNome(sNome);
            this.AtualizaGrid();
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridAdmGrupo(this.TxtBxNomePesquisa.Text);
        }

        protected void grdGrupoAcesso_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGrupoAcesso.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        protected void grdGrupoAcesso_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataKey dk = this.grdGrupoAcesso.DataKeys[e.RowIndex];
            this.grdGrupoAcesso.SelectedIndex = -1;
            this.UCCadastroGrupoAcessoIA1.Editar(ObjectUtils.ToInt(dk.Value));
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCCadastroGrupoAcessoIA1.Inserir();
        }

        protected void grdGrupoAcesso_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataKey dk = this.grdGrupoAcesso.DataKeys[e.NewEditIndex];
            this.UCCadastroGrupoUsuarioCE1.Editar(ObjectUtils.ToInt(dk.Value));
        }
    }
}