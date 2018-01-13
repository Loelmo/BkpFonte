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

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCSelecionaCNAE : UCBase
    {
        public delegate void AtualizaCampo(EntAtividadeEconomica objAtividadeEconomica);
        public AtualizaCampo atualizaCampo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        private void Show()
        {
            this.divUserControl.Visible = true;
            this.txtCodigoPesquisa.Focus();
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

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridAtividadeEconomica();
        }

        private void Clear()
        {
            ClearControl(this.PnlPesquisa.Controls);
            grdAtividadeEconomica.DataBind();
        }

        public void Buscar()
        {
            this.Clear();
            this.Show();
        }

        public void Selecionar(EntAtividadeEconomica objAtividadeEconomica)
        {
            this.atualizaCampo(objAtividadeEconomica);
            this.Clear();
            this.Close();
        }

        private void PopulaGridAtividadeEconomica()
        {
            EntAtividadeEconomica objAtividadeEconomica = new EntAtividadeEconomica();

            objAtividadeEconomica.Codigo = StringUtils.ToInt(txtCodigoPesquisa.Text);
            objAtividadeEconomica.AtividadeEconomica = txtAtividadeEconomicaPesquisa.Text;

            ListaGrid = new BllAtividadeEconomica().ObterPorFiltro(objAtividadeEconomica);
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            grdAtividadeEconomica.DataSource = ListaGrid;
            grdAtividadeEconomica.DataBind();
            this.grdAtividadeEconomica.SelectedIndex = -1;
        }

        protected void grdAtividadeEconomica_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            EntAtividadeEconomica objAtividadeEconomica = new EntAtividadeEconomica();

            objAtividadeEconomica.IdAtividadeEconomica = ObjectUtils.ToInt(grdAtividadeEconomica.DataKeys[e.RowIndex][0]);
            objAtividadeEconomica.AtividadeEconomica = ObjectUtils.ToString(grdAtividadeEconomica.DataKeys[e.RowIndex][1]);

            objAtividadeEconomica = new BllAtividadeEconomica().ObterPorId(objAtividadeEconomica.IdAtividadeEconomica);
            Selecionar(objAtividadeEconomica);
        }

        protected void grdAtividadeEconomica_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAtividadeEconomica.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        protected void grdAtividadeEconomica_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btn = (ImageButton)e.Row.Cells[0].FindControl("ImagBttnSelecionar");
                e.Row.Attributes.Add("onClick", this.Page.GetPostBackEventReference(btn, ""));
                e.Row.Style.Add("cursor","pointer");
            }

        }
    }
}