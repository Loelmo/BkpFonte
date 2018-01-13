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
using System.Drawing;
using Sistema_de_Gestao.Utilitarios;

namespace Sistema_de_Gestao
{
    public partial class RelatorioEstatisticoInscritas : PaginaBase
    {
        public Int32 TotalGeral { get; set; }
        public Int32 IdEstado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UCFiltroRanking1.Relatorio = MPE.User_Controls.UCFiltroRanking.enumRelatorio.RelatorioEstatisticoInscritas;
        }

        private void PopulaRelatorioEstatisticoInscritas()
        {
            //Implementar permissão do admin
            MontarRepeater(repTotal);
            MontarRepeater(repEstado);
            //------------------------------
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaRelatorioEstatisticoInscritas();
        }

        #region Montar Repeater
        private void MontarRepeater(Repeater rep)
        {
            RelFiltroRanking objFiltroRanking = UCFiltroRanking1.GetFiltro();
            objFiltroRanking.TipoEtapaMpe = Vinit.SG.Common.EnumType.TipoEtapaMpe.InscriçãoCandidaturaEmpresa;

            switch (rep.ID)
            {
                case "repTotal":

                    List<EntCategoriaCustom> listCategoria = new BllCategoria().ObterCategoriaEmpresasInscritasPorFiltro(objFiltroRanking);

                    if (listCategoria.Count > 0)
                    {
                        rep.Visible = true;
                        rep.DataSource = listCategoria;
                        rep.DataBind();
                    }
                    else
                    {
                        rep.Visible = false;
                    }

                    break;
                case "repEstado":

                    List<EntEstado> listEstado = new BllEstado().ObterEstadoEmpresasInscritasPorFiltro(objFiltroRanking);

                    if (listEstado.Count > 0)
                    {
                        this.lblMensagemEstado.Visible = false;
                        rep.Visible = true;
                        rep.DataSource = listEstado;
                        rep.DataBind();
                    }
                    else
                    {
                        this.lblMensagemEstado.Visible = true;
                        rep.Visible = false;
                    }

                    break;
            }
        }
        #endregion

        protected void repTotal_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.AlternatingItem:
                case ListItemType.Item:

                    MontaItem(e);

                    break;

                case ListItemType.Footer:

                    MontaFooter(e);

                    break;
            }
        }

        protected void repEstadoItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.AlternatingItem:
                case ListItemType.Item:

                    MontaItem(e);

                    break;

                case ListItemType.Footer:

                    MontaFooter(e);

                    break;
            }
        }

        protected void repEstado_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RelFiltroRanking objFiltroRanking = UCFiltroRanking1.GetFiltro();
            objFiltroRanking.TipoEtapaMpe = Vinit.SG.Common.EnumType.TipoEtapaMpe.InscriçãoCandidaturaEmpresa;

            switch (e.Item.ItemType)
            {
                case ListItemType.AlternatingItem:
                case ListItemType.Item:

                    Label lblEstado = (Label)e.Item.FindControl("lblEstado");
                    lblEstado.Text = DataBinder.Eval(e.Item.DataItem, "Estado").ToString();

                    objFiltroRanking.Estado = ObjectUtils.ToInt(DataBinder.Eval(e.Item.DataItem, "IdEstado").ToString());
                    this.IdEstado = objFiltroRanking.Estado;

                    Repeater rep = (Repeater)e.Item.FindControl("repEstadoItem");

                    List<EntCategoriaCustom> listCategoria = new BllCategoria().ObterCategoriaEmpresasInscritasPorFiltro(objFiltroRanking);
                    this.TotalGeral = 0;

                    rep.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.repTotal_ItemDataBound);
                    rep.DataSource = listCategoria;
                    rep.DataBind();
                    break;
            }
        }

        void MontaItem(RepeaterItemEventArgs e)
        {
            List<EntCategoriaCustom> listCategoriaAdmin;
            List<EntCategoriaCustom> listCategoriaDigitador;
            RelFiltroRanking objFiltroRanking = UCFiltroRanking1.GetFiltro();
            objFiltroRanking.TipoEtapaMpe = Vinit.SG.Common.EnumType.TipoEtapaMpe.InscriçãoCandidaturaEmpresa;

            objFiltroRanking.Estado = this.IdEstado;

            // Categoria
            Label lblCategoria = (Label)e.Item.FindControl("lblCategoria");
            lblCategoria.Text = "";
            lblCategoria.Text = DataBinder.Eval(e.Item.DataItem, "Categoria").ToString();

            Int32 IdCategoria = ObjectUtils.ToInt(DataBinder.Eval(e.Item.DataItem, "IdCategoria"));

            // Quantidade Digitador
            Label lblQtdDigitador = (Label)e.Item.FindControl("lblQtdDigitador");

            listCategoriaDigitador = new BllCategoria().ObterDigitadorEmpresasInscritasPorFiltro(objFiltroRanking).FindAll(delegate(EntCategoriaCustom Categoria) { return Categoria.IdCategoria == IdCategoria; });
            Int32 CountEmpresaGeralDigitador = listCategoriaDigitador.Sum<EntCategoriaCustom>(TotalQtde => TotalQtde.CountEmpresas);

            this.TotalGeral += CountEmpresaGeralDigitador;
            lblQtdDigitador.Text = CountEmpresaGeralDigitador.ToString();

            // Quantidade Empresa
            Label lblQtdEmpresa = (Label)e.Item.FindControl("lblQtdEmpresa");

            listCategoriaAdmin = new BllCategoria().ObterAdminEmpresasInscritasPorFiltro(objFiltroRanking).FindAll(delegate(EntCategoriaCustom Categoria) { return Categoria.IdCategoria == IdCategoria; });
            Int32 CountEmpresaGeralAdmin = listCategoriaAdmin.Sum<EntCategoriaCustom>(TotalQtde => TotalQtde.CountEmpresas);

            this.TotalGeral += CountEmpresaGeralAdmin;
            lblQtdEmpresa.Text = CountEmpresaGeralAdmin.ToString();
        }

        void MontaFooter(RepeaterItemEventArgs e)
        {
            List<EntCategoriaCustom> listCategoriaAdmin;
            List<EntCategoriaCustom> listCategoriaDigitador;
            RelFiltroRanking objFiltroRanking = UCFiltroRanking1.GetFiltro();
            objFiltroRanking.TipoEtapaMpe = Vinit.SG.Common.EnumType.TipoEtapaMpe.InscriçãoCandidaturaEmpresa;

            objFiltroRanking.Estado = this.IdEstado;

            int qtd;
            int total = 0;
            int totalEmpresa = 0;
            int totalDigitador = 0;

            #region Gráfico
            PlaceHolder ph = (PlaceHolder)e.Item.FindControl("phGrafico");
            ph.Controls.Clear();

            List<EntCategoriaCustom> listCategoria = new BllCategoria().ObterCategoriaEmpresasInscritasPorFiltro(objFiltroRanking);

            Int32 RowIndex = 0;
            string[,] valorXY = new string[listCategoria.Count, 3];

            foreach (EntCategoriaCustom objCategoria in listCategoria)
            {
                decimal valor = 0;
                total = 0;

                listCategoriaAdmin = new BllCategoria().ObterAdminEmpresasInscritasPorFiltro(objFiltroRanking).FindAll(delegate(EntCategoriaCustom Categoria) { return Categoria.IdCategoria == objCategoria.IdCategoria; });
                listCategoriaDigitador = new BllCategoria().ObterDigitadorEmpresasInscritasPorFiltro(objFiltroRanking).FindAll(delegate(EntCategoriaCustom Categoria) { return Categoria.IdCategoria == objCategoria.IdCategoria; });

                totalEmpresa = listCategoriaAdmin.Sum<EntCategoriaCustom>(TotalQtde => TotalQtde.CountEmpresas);
                total = totalEmpresa;

                totalDigitador = listCategoriaDigitador.Sum<EntCategoriaCustom>(TotalQtde => TotalQtde.CountEmpresas);
                total += totalDigitador;

                if (this.TotalGeral > 0)
                {
                    valor = (total * 100 / (this.TotalGeral));
                }

                valorXY[RowIndex, 0] = valor.ToString("0");
                valorXY[RowIndex, 1] = valor.ToString("0.00") + "%";
                valorXY[RowIndex, 2] = objCategoria.Categoria;

                RowIndex += 1;
            }

            Grafico grafico = new Grafico();
            ph.Controls.Add(grafico.GerarGraficoPizza(valorXY));

            //Criando Gráfico Pizza para Inscrições Realizadas
            string[,] valorXYRealizado = new string[2, 3];

            PlaceHolder phRealizado = (PlaceHolder)e.Item.FindControl("phGraficoRealizada");
            phRealizado.Controls.Clear();

            decimal valorRealizado = 0;
            try
            {
                valorRealizado = (totalEmpresa * 100 / (totalEmpresa + totalDigitador));
            }
            catch { }

            valorXYRealizado[0, 0] = valorRealizado.ToString("0");
            valorXYRealizado[0, 1] = valorRealizado.ToString("0.00") + "%";
            valorXYRealizado[0, 2] = "Empresa";

            valorRealizado = 0;
            try
            {
                valorRealizado = (totalDigitador * 100 / (totalEmpresa + totalDigitador));
            }
            catch { }

            valorXYRealizado[1, 0] = valorRealizado.ToString("0");
            valorXYRealizado[1, 1] = valorRealizado.ToString("0.00") + "%";
            valorXYRealizado[1, 2] = "Digitador";

            phRealizado.Controls.Add(grafico.GerarGraficoPizza(valorXYRealizado));

            #endregion

            #region Total Digitador

            // Total Digitador
            Label lblTotDigitador = (Label)e.Item.FindControl("lblTotDigitador");
            qtd = 0;

            listCategoriaDigitador = new BllCategoria().ObterDigitadorEmpresasInscritasPorFiltro(objFiltroRanking);

            qtd = listCategoriaDigitador.Sum<EntCategoriaCustom>(TotalQtde => TotalQtde.CountEmpresas);

            lblTotDigitador.Text = qtd.ToString();
            int TotDigitador = qtd;
            #endregion

            #region Total Empresa

            // Total Empresa
            Label lblTotEmpresa = (Label)e.Item.FindControl("lblTotEmpresa");
            qtd = 0;

            listCategoriaAdmin = new BllCategoria().ObterAdminEmpresasInscritasPorFiltro(objFiltroRanking);

            qtd = listCategoriaAdmin.Sum<EntCategoriaCustom>(TotalQtde => TotalQtde.CountEmpresas);

            lblTotEmpresa.Text = qtd.ToString();
            int TotEmpresa = qtd;

            #endregion

            #region Total Geral

            // Total Geral
            Label lblTotalGeral = (Label)e.Item.FindControl("lblTotalGeral");
            lblTotalGeral.Text = (TotDigitador + TotEmpresa).ToString();

            #endregion
        }
    }
}