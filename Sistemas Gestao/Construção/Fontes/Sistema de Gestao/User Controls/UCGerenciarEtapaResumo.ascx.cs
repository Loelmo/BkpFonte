using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using Sistema_de_Gestão_de_Treinamento.User_Control;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCGerenciarEtapaResumo : UCBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Show()
        {
            divUserControl.Visible = true;
        }

        private void Close()
        {
            divUserControl.Visible = false;
        }

        protected void ImgBttnGravar_Click(object sender, ImageClickEventArgs e)
        {
            this.Close();
        }

        public void VisualizarPorEtapa(int IdEtapa)
        {
            List<EntEtapaResumo> lstEtapaResumo = new List<EntEtapaResumo>();
            lstEtapaResumo = new BllEtapaResumo().ObterPorIdEtapa(IdEtapa);

            ObjectToPage(lstEtapaResumo);
            this.Show();
        }
        /// <summary>
        /// Utilizar este metodo no PEG/FGA
        /// </summary>
        /// <param name="IdEstado"></param>
        /// <param name="nTipoEtapa"></param>
        public void Visualizar(int IdTurma)
        {
            List<EntEtapaResumo> lstEtapaResumo = new List<EntEtapaResumo>();

            lstEtapaResumo = new BllEtapaResumo().ObterPorTurma(IdTurma);

            ObjectToPage(lstEtapaResumo);
            this.Show();
        }

        private void ObjectToPage(List<EntEtapaResumo> lstEtapaResumo)
        {
            ListaGrid = lstEtapaResumo;
            this.AtualizaGrid();
        }

        protected void grdEtapa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState == DataControlRowState.Normal) ||
                (e.Row.RowState == DataControlRowState.Alternate))
                {
                    if (((Label)e.Row.Cells[3].Controls[1]).Text.ToString().Contains("Inativar"))
                    {
                        ((Label)e.Row.Cells[3].Controls[1]).Text = "Inativar";
                    }
                    else
                    {
                        ((Label)e.Row.Cells[3].Controls[1]).Text = "Ativar";
                    }
                }
            }

        }

        private void AtualizaGrid()
        {
            grdEtapa.DataSource = ListaGrid;
            grdEtapa.DataBind();
            this.grdEtapa.SelectedIndex = -1;
        }

        protected void grdEtapa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEtapa.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }
    }
}