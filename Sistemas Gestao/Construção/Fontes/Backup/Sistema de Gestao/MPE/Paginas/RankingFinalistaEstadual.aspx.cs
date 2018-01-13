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
using Sistema_de_Gestao.MPE.User_Control;

namespace Sistema_de_Gestao.MPE.Paginas
{
    public partial class RankingFinalistaEstadual : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UCFiltroRanking1.IsEstadual = true;
            }

            this.UCJustificativaRanking1.atualizaGrid += this.PopulaGridRankingFinalitaEstadual;
        }

        private void PopulaGridRankingFinalitaEstadual()
        {
            RelFiltroRanking objRelFiltroRanking = UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"]));
            ListaGrid = new BllRelatorioRanking().ObterRankingFinalistaPorFiltro(objRelFiltroRanking);
            this.AtualizaGrid(objRelFiltroRanking);
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridRankingFinalitaEstadual();
        }
       
        private void AtualizaGrid(RelFiltroRanking objRelFiltroRanking)
        {
            OrdemPontuacaoTotalQuestionario(objRelFiltroRanking.Questionario);
            ExibeColunaDetalhe(objRelFiltroRanking.TipoRelatorio);

            this.grdRanking.DataSource = ListaGrid;
            this.grdRanking.DataBind();
            this.grdRanking.SelectedIndex = -1;
        }

        private void OrdemPontuacaoTotalQuestionario(EnumType.Questionario Questionario)
        {
            switch (Questionario)
            {
                case EnumType.Questionario.ResponsabilidadeSocial:

                    this.grdRanking.Columns[6].Visible = true;      //Coluna Total Pontuação Responsabilidade Social "Coluna inicio relatório"
                    this.grdRanking.Columns[7].Visible = false;     //Coluna Total Pontuação Inovação "Coluna inicio relatório"
                    this.grdRanking.Columns[34].Visible = false;    //Coluna Total Pontuação Responsabilidade Social "Coluna fim relatório"
                    this.grdRanking.Columns[35].Visible = true;     //Coluna Total Pontuação Inovação "Coluna fim relatório"

                    this.grdRanking.Sort("PontuacaoTotalResponsabilidadeSocial", SortDirection.Ascending);

                    break;
                case EnumType.Questionario.Inovacao:

                    this.grdRanking.Columns[6].Visible = false;     //Coluna Total Pontuação Responsabilidade Social "Coluna inicio relatório"
                    this.grdRanking.Columns[7].Visible = true;      //Coluna Total Pontuação Inovação "Coluna inicio relatório"
                    this.grdRanking.Columns[34].Visible = true;     //Coluna Total Pontuação Responsabilidade Social "Coluna fim relatório"
                    this.grdRanking.Columns[35].Visible = false;    //Coluna Total Pontuação Inovação "Coluna fim relatório"

                    this.grdRanking.Sort("PontuacaoTotalInovacao", SortDirection.Ascending);

                    break;
            }
        }

        private void ExibeColunaDetalhe(EnumType.TipoRelatorio TipoRelatorio)
        {
            switch (TipoRelatorio)
            {
                case EnumType.TipoRelatorio.Simplificado:

                    this.grdRanking.Columns[9].Visible =
                    this.grdRanking.Columns[10].Visible =
                    this.grdRanking.Columns[11].Visible =
                    this.grdRanking.Columns[12].Visible =
                    this.grdRanking.Columns[13].Visible =
                    this.grdRanking.Columns[14].Visible =
                    this.grdRanking.Columns[15].Visible =
                    this.grdRanking.Columns[22].Visible =
                    this.grdRanking.Columns[23].Visible =
                    this.grdRanking.Columns[24].Visible =
                    this.grdRanking.Columns[25].Visible =
                    this.grdRanking.Columns[26].Visible =
                    this.grdRanking.Columns[27].Visible =
                    this.grdRanking.Columns[28].Visible = false;

                    this.TituloBoxSimplificado.Visible = true;
                    this.TituloBoxDetalhado.Visible = false;

                    break;
                case EnumType.TipoRelatorio.Detalhado:

                    this.grdRanking.Columns[9].Visible =
                    this.grdRanking.Columns[10].Visible =
                    this.grdRanking.Columns[11].Visible =
                    this.grdRanking.Columns[12].Visible =
                    this.grdRanking.Columns[13].Visible =
                    this.grdRanking.Columns[14].Visible =
                    this.grdRanking.Columns[15].Visible =
                    this.grdRanking.Columns[22].Visible =
                    this.grdRanking.Columns[23].Visible =
                    this.grdRanking.Columns[24].Visible =
                    this.grdRanking.Columns[25].Visible =
                    this.grdRanking.Columns[26].Visible =
                    this.grdRanking.Columns[27].Visible =
                    this.grdRanking.Columns[28].Visible = true;

                    this.TituloBoxSimplificado.Visible = false;
                    this.TituloBoxDetalhado.Visible = true;

                    break;
            }
        }

        protected void grdRanking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RelRankingFinalista objRelRankingFinalista = ((RelRankingFinalista)e.Row.DataItem);

                Label lblIdQuestionarioEmpresa = ((Label)e.Row.FindControl("lblIdQuestionarioEmpresa"));

                Label lblRanking = ((Label)e.Row.FindControl("lblRanking"));
                lblRanking.Text = IntUtils.ToString(e.Row.RowIndex + 1);

                ImageButton imgBttn = ((ImageButton)e.Row.FindControl("imgBttnVencedora"));
                if (objRelRankingFinalista.Vencedor)
                {
                    imgBttn.ImageUrl = "~/Image/checked.gif";
                }
                else
                {
                    imgBttn.ImageUrl = "~/Image/unchecked.gif";
                }
            }
        }

        protected void grdRanking_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Int32 IdQuestionarioEmpresa = StringUtils.ToInt(grdRanking.DataKeys[0].Values[0].ToString());
            Boolean Vencedor = StringUtils.ToBoolean(grdRanking.DataKeys[0].Values[1].ToString());

            if (Vencedor)
            {
                //Passa para etapa anterior
                EntQuestionarioEmpresa objQuestionarioEmpresa = new EntQuestionarioEmpresa();
                Label lblIdEmpresaCadastro = ((Label)grdRanking.Rows[e.RowIndex].FindControl("lblIdEmpresaCadastro"));
                
                objQuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro = StringUtils.ToInt(lblIdEmpresaCadastro.Text);
                objQuestionarioEmpresa.Usuario.IdUsuario = IdUsuarioLogado;
                objQuestionarioEmpresa.Questionario.IdQuestionario = (Int32)UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"])).Questionario;
                objQuestionarioEmpresa.Etapa.TipoEtapa.IdTipoEtapa = (Int32)EnumType.TipoEtapaMpe.ClassificaçãoEstadual;

                new BllRelatorioRanking().EncaminharEtapaAnterior(objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, objQuestionarioEmpresa.Questionario.IdQuestionario, objQuestionarioEmpresa.Etapa.IdEtapa, true);
            }
            else
            {
                //Passa para próxima etapa
                UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (int)EnumType.TipoEtapaMpe.ClassificacaoNacional, UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"])).Questionario);
            }
        }

        protected void grdRanking_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void grdRanking_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRanking.PageIndex = e.NewPageIndex;
            AtualizaGrid(UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"])));
        }
    }
}