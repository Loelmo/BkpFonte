using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.Common;

namespace Sistema_de_Gestao.Paginas
{
    public partial class GerenciarEtapaEstadualCE : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulaEstado();
            }
        }

        private void PopulaEstado()
        {
            this.ddlEstado.Items.Clear();
            this.ddlEstado.DataSource = new BllEstado().ObterTodos();
            this.ddlEstado.DataBind();
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridEtapas(StringUtils.ToInt(this.ddlEstado.SelectedValue));
        }

        private void PopulaGridEtapas(Int32 nIdEstado)
        {
            ListaGrid = new BllEtapa().ObterPorIdEstado(nIdEstado);
            this.AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            this.grdEtapa.DataSource = ListaGrid;
            this.grdEtapa.DataBind();
            this.grdEtapa.SelectedIndex = -1;
        }

        protected void grdEtapa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdEtapa.PageIndex = e.NewPageIndex;
            this.AtualizaGrid();
        }

        protected void grdEtapa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataKey dk = this.grdEtapa.DataKeys[e.RowIndex];
            //new BllAdmUsuario().Excluir(ObjectUtils.ToInt(dk.Value));
            AtualizaGrid();
        }

        protected void grdEtapa_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataKey dk = this.grdEtapa.DataKeys[e.RowIndex];
            this.grdEtapa.SelectedIndex = -1;
            //this.UCCadastroEscritorioRegionalIA1.Editar(ObjectUtils.ToInt(dk.Value));
        }
    }
}