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


namespace Sistema_de_Gestao.FGA.User_Controls
{
    public partial class UCVisualizarAutodiagnosticoInicial : UCBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.PopulaGridRelatorioRAA();
            }
        }

        private void AtualizaGrid()
        {
            this.grdRelatorioRAA.DataSource = ListaGrid;
            this.grdRelatorioRAA.DataBind();
            this.grdRelatorioRAA.SelectedIndex = -1;
        }

        private void PopulaGridRelatorioRAA(Int32 IdEmpresaCadastro, Int32 IdTurma)
        {
            ListaGrid = new BllRelatorio().RelRAAPorFiltro(IdEmpresaCadastro, IdTurma, objPrograma.IdPrograma, null);

            this.AtualizaGrid();
        }

        protected void grdRelatorioRAA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRelatorioRAA.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        protected void grdRelatorioRAA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                EntRelatorioRAA objRelatorioRAA = ((EntRelatorioRAA)e.Row.DataItem);

                ImageButton btnDownload = ((ImageButton)e.Row.FindControl("ImagBttnDownload"));
                ImageButton btnEnviaEmail = ((ImageButton)e.Row.FindControl("ImagBttnEnviarEmail"));

                String Url = "";

                if (objRelatorioRAA.Avaliador)
                {
                    Url += "DownloadPDF.aspx?protocolo=" + objRelatorioRAA.Protocolo + "&comentarios=true&avaliacao=true&turmaId=" + objTurma.IdTurma.ToString() + "&programaId=" + objRelatorioRAA.Programa.ToString();

                    btnDownload.OnClientClick = "WindowOpen('" + Url + "');";
                }
                else
                {
                    Url += "DownloadPDF.aspx?protocolo=" + objRelatorioRAA.Protocolo + "&comentarios=false&programaId=" + objRelatorioRAA.Programa.ToString();

                    btnDownload.OnClientClick = "WindowOpen('" + Url + "');";
                }
            }
        }

        private void Show()
        {

            this.divUserControl.Visible = true;
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }


        protected void ImgBttnGravar_Click1(object sender, ImageClickEventArgs e)
        {

            this.Close();
            this.Clear();
        }

        public void Visualiar(Int32 IdEmpresaCadastro, Int32 IdTurma)
        {
            PopulaGridRelatorioRAA(IdEmpresaCadastro, IdTurma);
            this.Show();
        }

    }
}