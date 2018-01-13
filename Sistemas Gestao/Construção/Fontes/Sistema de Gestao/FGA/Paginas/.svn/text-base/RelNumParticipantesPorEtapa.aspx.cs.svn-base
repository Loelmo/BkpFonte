using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using Vinit.SG.Ent;


namespace Sistema_de_Gestao.FGA.Paginas
{
    public partial class RelNumParticipantesInscritosEtapa : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.UCFiltro1.Relatorio = EnumType.RelatorioFiltro.NumeroParticipantesPorEtapaFga;
                grdEtapaEstado.DataBind();
                grdCategoriaEtapa.DataBind();
                
            }
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            
            RelFiltroGeral Filtro = new RelFiltroGeral();
            Filtro = this.UCFiltro1.GetFiltro();
           // Filtro.Estado = 11;
           // Filtro.Turma = 7;
            List<RelRelatorioNumeroParticipantes> lista = new BllRelatorio().RelNumeroParticipantesEtapaFga(Filtro, 1);
            List<RelRelatorioNumeroParticipantes> listaGrafico = new List<RelRelatorioNumeroParticipantes>();

            Div1.Style.Add("display", "block");
            Div2.Style.Add("display", "block");
            Div3.Style.Add("display", "block");
            Div4.Style.Add("display", "block");
           
            //Estado
            grdEtapaEstado.DataSource = lista;
            grdEtapaEstado.DataBind();
            if (Filtro.Estado > 0)
            {
                foreach (RelRelatorioNumeroParticipantes item in lista)
                {
                    if (item.IdEstado == Filtro.Estado)
                        listaGrafico.Add(item);
                }
            }
            else
            {
                listaGrafico = lista;
            }

            if (listaGrafico.Count > 0)
            {
                lblMsgGrafico1.Visible = false;
                grafEstado.DataSource = listaGrafico;

            }
            //Categoria
            lista = new BllRelatorio().RelNumeroParticipantesEtapaFga(Filtro, 2);
            listaGrafico = new List<RelRelatorioNumeroParticipantes>();
            grdCategoriaEtapa.DataSource = lista;
            grdCategoriaEtapa.DataBind();
            if (Filtro.Categoria > 0)
            {
                foreach (RelRelatorioNumeroParticipantes item in lista)
                {
                    if (item.IdCategoria == Filtro.Categoria)
                        listaGrafico.Add(item);
                }
            }
            else
            {
                listaGrafico = lista;
            }

            if (listaGrafico.Count > 0)
            {
                lblMsgGrafico.Visible = false;
                grafCategoria.DataSource = listaGrafico;
            }

        }
    }
}