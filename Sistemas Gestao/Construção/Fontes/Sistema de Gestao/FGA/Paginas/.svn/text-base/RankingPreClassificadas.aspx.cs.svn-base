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

namespace Sistema_de_Gestao.FGA.Paginas
{
    public partial class RankingPreClassificadas : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UCFiltroRanking1.IsEstadual = true;
                ConfiguraPagina();
            }
        }

        private void PopulaGridEmpresa()
        {
            RelFiltroRanking objRelFiltroRanking = this.UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"]));
            ListaGrid = new BllRelatorioRanking().ObterRankingClassificadaPorFiltro(objRelFiltroRanking);

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

                    grdRanking.Columns[8].Visible =
                    grdRanking.Columns[9].Visible =
                    grdRanking.Columns[10].Visible =
                    grdRanking.Columns[11].Visible =
                    grdRanking.Columns[12].Visible =
                    grdRanking.Columns[13].Visible =
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

                    grdRanking.Columns[8].Visible =
                    grdRanking.Columns[9].Visible =
                    grdRanking.Columns[10].Visible =
                    grdRanking.Columns[11].Visible =
                    grdRanking.Columns[12].Visible =
                    grdRanking.Columns[13].Visible =
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
            int index = ObjectUtils.ToInt(e.CommandArgument) - (grdRanking.PageIndex * grdRanking.PageSize);
            int IdQuestionarioEmpresa = StringUtils.ToInt(((Label)this.grdRanking.Rows[index].Cells[0].FindControl("lblIdQuestionarioEmpresa")).Text);
            int IdEmpresaCadastro = StringUtils.ToInt(((Label)this.grdRanking.Rows[index].Cells[1].FindControl("lblIdEmpresaCadastro")).Text);
            int IdEtapa = StringUtils.ToInt(((Label)this.grdRanking.Rows[index].Cells[2].FindControl("lblIdEtapa")).Text);
            bool FlPassaProximaEtapa = StringUtils.ToBoolean(((Label)this.grdRanking.Rows[index].Cells[2].FindControl("lblFlPassaProximaEtapa")).Text);

            if (e.CommandName == "Devolver")
            {
                
                switch (objPrograma.IdPrograma)
                {
                    case (int)EnumType.Programa.FGA:
                        this.UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (int)EnumType.TipoEtapaFga.ValidacaoAnaliseRespostas, EnumType.Questionario.Gestao);
                        break;

                    case (int)EnumType.Programa.PEG:
                        this.UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (int)EnumType.TipoEtapaPeg.ValidacaoAnaliseRespostas, EnumType.Questionario.Gestao);
                        break;
                }
            }
            else if (e.CommandName == "FinalistaGestao")
            {
                if (FlPassaProximaEtapa)
                {
                    new BllRelatorioRanking().EncaminharEtapaAnterior(IdEmpresaCadastro, (int)EnumType.Questionario.Gestao, IdEtapa, false);
                }
                else
                {
                    new BllRelatorioRanking().EncaminharProximaEtapa(IdEmpresaCadastro, (int)EnumType.Questionario.Gestao, IdEtapa, false);
                }
            }
            PopulaGridEmpresa();
        }

        protected void grdRanking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RelRankingClassificada objRelRankingClassificada = ((RelRankingClassificada)e.Row.DataItem);
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

                ImageButton imgBttn = ((ImageButton)e.Row.FindControl("imgBttnDevolver"));
                Label lblParaAvaliacao = ((Label)e.Row.FindControl("lblParaAvaliacao"));
                this.AlterarCheck(imgBttn, StringUtils.ToBoolean(lblParaAvaliacao.Text), isEtapaAtiva && !StringUtils.ToBoolean(lblPassaProximaEtapa.Text));

                imgBttn = ((ImageButton)e.Row.FindControl("imgBttnFinalista"));
                this.AlterarCheck(imgBttn, StringUtils.ToBoolean(lblPassaProximaEtapa.Text), isEtapaAtiva && !StringUtils.ToBoolean(lblParaAvaliacao.Text));

                HyperLink hyperLink1 = ((HyperLink)e.Row.FindControl("HyperLink1"));
                Label lblProtocolo = ((Label)e.Row.FindControl("lblProtocolo"));
                String Url = "/MPE/Paginas/DownloadPDF.aspx?protocolo=" + lblProtocolo.Text + "&comentarios=false&programaId=" + objPrograma.IdPrograma;
                hyperLink1.NavigateUrl = Url;
            }
        }

        private void ConfiguraPagina()
        {
            switch (int.Parse(Request["TipoEtapaId"]))
            {
                case EntTipoEtapa.TIPO_ETAPA_FGA_PRE_CLASSIFICADAS:
                    lblTitulo.Text = "Ranking Pré-Classificadas FGA";
                    break;
                case EntTipoEtapa.TIPO_ETAPA_FGA_FASE_4:
                    lblTitulo.Text = "Ranking Fase 4 FGA";
                    break;
                case EntTipoEtapa.TIPO_ETAPA_PEG_PRE_CLASSIFICADAS:
                    lblTitulo.Text = "Ranking Pré-Classificadas PEG";
                    break;
                case EntTipoEtapa.TIPO_ETAPA_PEG_FASE_4:
                    lblTitulo.Text = "Ranking Fase 4 PEG";
                    break;
            }
        }
    }
}