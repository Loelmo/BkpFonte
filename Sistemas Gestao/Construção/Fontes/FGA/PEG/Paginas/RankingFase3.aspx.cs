using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Vinit.SG.BLL;
using Sistema_de_Gestao.Pagina_Base;
using Sistema_de_Gestao.Utilitarios;

namespace Sistema_de_Gestao.PEG.Paginas
{
    public partial class RankingFase3 : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        private void PopulaGridEmpresa()
        {
            RelFiltroRanking objRelFiltroRanking = this.UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"]));
            ListaGrid = new BllRelatorioRanking().ObterRankingPegFase2PorFiltro(objRelFiltroRanking);
            this.AtualizaGrid(objRelFiltroRanking);
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridEmpresa();
        }

        private void AtualizaGrid(RelFiltroRanking objRelFiltroRanking)
        {
            this.grdRanking.DataSource = ListaGrid;
            this.grdRanking.DataBind();
            this.grdRanking.SelectedIndex = -1;

            ExibeColunaDetalhe(objRelFiltroRanking.TipoRelatorio);
        }

        private void ExibeColunaDetalhe(EnumType.TipoRelatorio TipoRelatorio)
        {
            switch (TipoRelatorio)
            {
                case EnumType.TipoRelatorio.Simplificado:

                    grdRanking.Columns[14].Visible =
                    grdRanking.Columns[21].Visible =
                    grdRanking.Columns[22].Visible =
                    grdRanking.Columns[23].Visible =
                    grdRanking.Columns[24].Visible =
                    grdRanking.Columns[25].Visible =
                    grdRanking.Columns[26].Visible =
                    grdRanking.Columns[27].Visible = false;


                    TituloBoxSimplificado.Visible = true;
                    TituloBoxDetalhado.Visible = false;

                    break;
                case EnumType.TipoRelatorio.Detalhado:

                    grdRanking.Columns[14].Visible =
                    grdRanking.Columns[21].Visible =
                    grdRanking.Columns[22].Visible =
                    grdRanking.Columns[23].Visible =
                    grdRanking.Columns[24].Visible =
                    grdRanking.Columns[25].Visible =
                    grdRanking.Columns[26].Visible =
                    grdRanking.Columns[27].Visible = true;

                    TituloBoxSimplificado.Visible = false;
                    TituloBoxDetalhado.Visible = true;

                    break;
            }
        }

        protected void grdRanking_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ObjectUtils.ToInt(e.CommandArgument);
            int IdQuestionarioEmpresa = StringUtils.ToInt(((Label)this.grdRanking.Rows[index].Cells[0].FindControl("lblIdQuestionarioEmpresa")).Text);
            int IdEmpresaCadastro = StringUtils.ToInt(((Label)this.grdRanking.Rows[index].Cells[1].FindControl("lblIdEmpresaCadastro")).Text);
            int IdTurma = StringUtils.ToInt(((Label)this.grdRanking.Rows[index].Cells[2].FindControl("lblIdTurma")).Text);
            int IdEtapa = StringUtils.ToInt(((Label)this.grdRanking.Rows[index].Cells[3].FindControl("lblIdEtapa")).Text);

            if (e.CommandName == "Fase4")
            {
                this.UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (Int32) EnumType.TipoEtapaPeg.GestãoDoResultadoFase3, EnumType.Questionario.Gestao);
            }
            else if (e.CommandName == "ResumoFase3")
            {
                this.UCResumoRanking1.Show(IdQuestionarioEmpresa);
            }
            else if (e.CommandName == "Anexos")
            {
                this.UCTurmaEmpresaArquivoCE1.Show(IdEmpresaCadastro, IdTurma, IdEtapa, 3);
            }
            else if (e.CommandName == "PlanosAcao")
            {
                this.UCPlanoAcaoCE1.Show(IdEmpresaCadastro, IdTurma, IdEtapa, 3);
            }
        }

        protected void grdRanking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RelRankingPegFase2 objRelRankingClassificada = ((RelRankingPegFase2)e.Row.DataItem);
                Label lblIdQuestionarioEmpresa = ((Label)e.Row.FindControl("lblIdQuestionarioEmpresa"));
                Label lblPassaProximaEtapa = ((Label)e.Row.FindControl("lblFlPassaProximaEtapa"));

                Label lblEtapaAtiva = ((Label)e.Row.FindControl("lblFlEtapaAtiva"));
                Boolean isEtapaAtiva = false;
                if (lblEtapaAtiva.Text == "True")
                {
                    isEtapaAtiva = true;
                }

                Label lblRanking = ((Label)e.Row.FindControl("lblRanking"));
                lblRanking.Text = IntUtils.ToString(e.Row.RowIndex + 1);

                ImageButton imgBttn = ((ImageButton)e.Row.FindControl("imgBttnFinalista"));
                this.AlterarCheck(imgBttn, StringUtils.ToBoolean(lblPassaProximaEtapa.Text), isEtapaAtiva);

                HyperLink hyperLink1 = ((HyperLink)e.Row.FindControl("HyperLink1"));
                Label lblProtocolo = ((Label)e.Row.FindControl("lblProtocolo"));
                String Url = "/MPE/Paginas/DownloadPDF.aspx?protocolo=" + lblProtocolo.Text + "&comentarios=false&programaId=" + objPrograma.IdPrograma;
                hyperLink1.NavigateUrl = Url;
            }
        }

        private void AlterarCheck(ImageButton imgBttn, Boolean valor)
        {
            imgBttn.ImageUrl = valor ? "~/Image/checked.gif" : "~/Image/unchecked.gif";
        }
    }
}