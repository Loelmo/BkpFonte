using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using System.Globalization;
using Dundas.Charting.WebControl;
using System.Drawing;
using Sistema_de_Gestao.Utilitarios;

namespace Sistema_de_Gestao.MPE.Paginas
{
    public partial class RelatorioNumeroParticipantesPorEtada : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UCFiltroRanking1.Relatorio = MPE.User_Controls.UCFiltroRanking.enumRelatorio.RelatorioParticipantesPorEtapa;
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridPorEstado();
            PopulaGridPorCategoria();
        }

        private void PopulaGridPorEstado()
        {
            RelFiltroRanking objRelFiltroRanking = this.UCFiltroRanking1.GetFiltro();
            List<RelParticipantesPorEtapa> Lista = new BllRelatorio().ObterParticipantesPorEtapaPorEstado(UCFiltroRanking1.GetFiltro());

            this.grdEtapaEstado.DataSource = Lista;
            this.grdEtapaEstado.DataBind();

            if (Lista.Count > 0)
            {
                phGraficoPercentualEstado.Controls.Clear();
                phGraficoPercentualEstado.Controls.Add(GetGroupedBarEstadualEstadoChart(Lista));
            }
        }

        private void PopulaGridPorCategoria()
        {
            RelFiltroRanking objRelFiltroRanking = this.UCFiltroRanking1.GetFiltro();
            List<RelParticipantesPorEtapa> Lista = new BllRelatorio().ObterParticipantesPorEtapaPorCategoria(UCFiltroRanking1.GetFiltro());

            this.grdCategoria.DataSource = Lista;
            this.grdCategoria.DataBind();

            if (Lista.Count > 0)
            {
                phGraficoPercentualCategoria.Controls.Clear();
                phGraficoPercentualCategoria.Controls.Add(GetGroupedBarEstadualCategoriaChart(Lista));
            }
        }


        #region Gerar Gráfico Coluna
        private CultureInfo enUS = new CultureInfo("en-US");
        private Dundas.Charting.WebControl.Chart GetGroupedBarEstadualEstadoChart(List<RelParticipantesPorEtapa> lista)
        {

            double maior_valor = double.MinValue;
            string[, ,] valorXY = new string[9, lista.Count, 4];
            int i = 0;
            foreach (RelParticipantesPorEtapa item in lista)
            {
                int inscritas = item.TotalInscritas;
                int candidatas = item.TotalCandidatas;
                int classificada = item.TotalClassificadas;
                int finalista = item.TotalFinalistasGestao;
                int vencedora = item.TotalVencedoraGestao;

                int total_total = item.TotalInscritasPorTurma;

                decimal valor_perc = 0;
                String estado = item.Estado.Estado;
                //Inscritas
                Int32 k = 0;
                valor_perc = (inscritas * decimal.Parse("100.00", enUS) / total_total);
                valorXY[k, i, 0] = valor_perc.ToString(); //inscritas.ToString();
                valorXY[k, i, 1] = "";//valor_perc.ToString("N2", enUS) + "%";
                valorXY[k, i, 2] = estado;
                valorXY[k, i, 3] = inscritas.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + estado;

                if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                //Candidatas
                k++;
                valor_perc = (candidatas * decimal.Parse("100.00", enUS) / total_total);
                valorXY[k, i, 0] = valor_perc.ToString(); //candidatas.ToString();
                valorXY[k, i, 1] = "";// valor_perc.ToString("N2", enUS) + "%";
                valorXY[k, i, 2] = estado;
                valorXY[k, i, 3] = candidatas.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + estado;

                if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                //Classificada
                k++;
                valor_perc = (classificada * decimal.Parse("100.00", enUS) / total_total);
                valorXY[k, i, 0] = valor_perc.ToString();
                valorXY[k, i, 1] = "";
                valorXY[k, i, 2] = estado;
                valorXY[k, i, 3] = classificada.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + estado;

                if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                //FinalistasGestao 
                k++;
                valor_perc = (item.TotalFinalistasGestao * decimal.Parse("100.00", enUS) / total_total);
                valorXY[k, i, 0] = valor_perc.ToString();
                valorXY[k, i, 1] = "";
                valorXY[k, i, 2] = estado;
                valorXY[k, i, 3] = item.TotalFinalistasGestao.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + estado;

                if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                //FinalistasRespSocial 
                k++;
                valor_perc = (item.TotalFinalistasRespSocial * decimal.Parse("100.00", enUS) / total_total);
                valorXY[k, i, 0] = valor_perc.ToString();
                valorXY[k, i, 1] = "";
                valorXY[k, i, 2] = estado;
                valorXY[k, i, 3] = item.TotalFinalistasRespSocial.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + estado;

                if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                //FinalistasInovacao 
                k++;
                valor_perc = (item.TotalFinalistasInovacao * decimal.Parse("100.00", enUS) / total_total);
                valorXY[k, i, 0] = valor_perc.ToString();
                valorXY[k, i, 1] = "";
                valorXY[k, i, 2] = estado;
                valorXY[k, i, 3] = item.TotalFinalistasInovacao.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + estado;

                if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                //VencedoraGestao 
                k++;
                valor_perc = (item.TotalVencedoraGestao * decimal.Parse("100.00", enUS) / total_total);
                valorXY[k, i, 0] = valor_perc.ToString();
                valorXY[k, i, 1] = "";
                valorXY[k, i, 2] = estado;
                valorXY[k, i, 3] = item.TotalVencedoraGestao.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + estado;

                if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                //VencedoraRespSocial 
                k++;
                valor_perc = (item.TotalVencedoraRespSocial * decimal.Parse("100.00", enUS) / total_total);
                valorXY[k, i, 0] = valor_perc.ToString();
                valorXY[k, i, 1] = "";
                valorXY[k, i, 2] = estado;
                valorXY[k, i, 3] = item.TotalVencedoraRespSocial.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + estado;

                if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                //VencedoraInovacao 
                k++;
                valor_perc = (item.TotalVencedoraInovacao * decimal.Parse("100.00", enUS) / total_total);
                valorXY[k, i, 0] = valor_perc.ToString();
                valorXY[k, i, 1] = "";
                valorXY[k, i, 2] = estado;
                valorXY[k, i, 3] = item.TotalVencedoraInovacao.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + estado;

                if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                i++;

            }

            Grafico grafico = new Grafico();
            Dundas.Charting.WebControl.Chart chart = grafico.GerarGraficoColuna(valorXY, true, maior_valor);

            return chart;
        }

        private Dundas.Charting.WebControl.Chart GetGroupedBarEstadualCategoriaChart(List<RelParticipantesPorEtapa> lista)
        {
            double maior_valor = double.MinValue;
            string[, ,] valorXY = new string[9, lista.Count, 4];
            int i = 0;
            foreach (RelParticipantesPorEtapa item in lista)
            {
                int inscritas = item.TotalInscritas;
                int candidatas = item.TotalCandidatas;
                int classificada = item.TotalClassificadas;
                int finalista = item.TotalFinalistasGestao;
                int vencedora = item.TotalVencedoraGestao;

                int total_total = item.TotalInscritasPorTurma;

                decimal valor_perc = 0;

                if (total_total > 0)
                {
                    //Inscritas
                    Int32 k = 0;
                    valor_perc = (inscritas * decimal.Parse("100.00", enUS) / total_total);
                    valorXY[k, i, 0] = valor_perc.ToString(); //inscritas.ToString();
                    valorXY[k, i, 1] = "";// valor_perc.ToString("N2", enUS) + "%";
                    valorXY[k, i, 2] = item.Categoria.Categoria;
                    valorXY[k, i, 3] = inscritas.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + item.Categoria.Categoria;

                    if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                    //Candidatas
                    k++;
                    valor_perc = (candidatas * decimal.Parse("100.00", enUS) / total_total);
                    valorXY[k, i, 0] = valor_perc.ToString(); //candidatas.ToString();
                    valorXY[k, i, 1] = "";// valor_perc.ToString("N2", enUS) + "%";
                    valorXY[k, i, 2] = item.Categoria.Categoria;
                    valorXY[k, i, 3] = candidatas.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + item.Categoria.Categoria;

                    if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());


                    //Classificada
                    k++;
                    valor_perc = (classificada * decimal.Parse("100.00", enUS) / total_total);
                    valorXY[k, i, 0] = valor_perc.ToString();
                    valorXY[k, i, 1] = "";
                    valorXY[k, i, 2] = item.Categoria.Categoria;
                    valorXY[k, i, 3] = classificada.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + item.Categoria.Categoria;

                    if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());


                    //FinalistasGestao 
                    k++;
                    valor_perc = (item.TotalFinalistasGestao * decimal.Parse("100.00", enUS) / total_total);
                    valorXY[k, i, 0] = valor_perc.ToString();
                    valorXY[k, i, 1] = "";
                    valorXY[k, i, 2] = item.Categoria.Categoria;
                    valorXY[k, i, 3] = item.TotalFinalistasGestao.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + item.Categoria.Categoria;

                    if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                    //FinalistasRespSocial 
                    k++;
                    valor_perc = (item.TotalFinalistasRespSocial * decimal.Parse("100.00", enUS) / total_total);
                    valorXY[k, i, 0] = valor_perc.ToString();
                    valorXY[k, i, 1] = "";
                    valorXY[k, i, 2] = item.Categoria.Categoria;
                    valorXY[k, i, 3] = item.TotalFinalistasRespSocial.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + item.Categoria.Categoria;

                    if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                    //FinalistasInovacao 
                    k++;
                    valor_perc = (item.TotalFinalistasInovacao * decimal.Parse("100.00", enUS) / total_total);
                    valorXY[k, i, 0] = valor_perc.ToString();
                    valorXY[k, i, 1] = "";
                    valorXY[k, i, 2] = item.Categoria.Categoria;
                    valorXY[k, i, 3] = item.TotalFinalistasInovacao.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + item.Categoria.Categoria;

                    if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                    //VencedoraGestao 
                    k++;
                    valor_perc = (item.TotalVencedoraGestao * decimal.Parse("100.00", enUS) / total_total);
                    valorXY[k, i, 0] = valor_perc.ToString();
                    valorXY[k, i, 1] = "";
                    valorXY[k, i, 2] = item.Categoria.Categoria;
                    valorXY[k, i, 3] = item.TotalVencedoraGestao.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + item.Categoria.Categoria;

                    if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                    //VencedoraRespSocial 
                    k++;
                    valor_perc = (item.TotalVencedoraRespSocial * decimal.Parse("100.00", enUS) / total_total);
                    valorXY[k, i, 0] = valor_perc.ToString();
                    valorXY[k, i, 1] = "";
                    valorXY[k, i, 2] = item.Categoria.Categoria;
                    valorXY[k, i, 3] = item.TotalVencedoraRespSocial.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + item.Categoria.Categoria;

                    if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());

                    //VencedoraInovacao 
                    k++;
                    valor_perc = (item.TotalVencedoraInovacao * decimal.Parse("100.00", enUS) / total_total);
                    valorXY[k, i, 0] = valor_perc.ToString();
                    valorXY[k, i, 1] = "";
                    valorXY[k, i, 2] = item.Categoria.Categoria;
                    valorXY[k, i, 3] = item.TotalVencedoraInovacao.ToString() + " - " + valor_perc.ToString("N2", enUS) + "% - " + item.Categoria.Categoria;

                    if (maior_valor < double.Parse(valor_perc.ToString())) maior_valor = double.Parse(valor_perc.ToString());
                }

                i++;

            }

            Grafico grafico = new Grafico();
            Dundas.Charting.WebControl.Chart chart = grafico.GerarGraficoColuna(valorXY, true, maior_valor);

            return chart;
        }

        #endregion
    }
}