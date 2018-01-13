using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Vinit.SG.BLL;
using PEG.Pagina_Base;
using PEG.Utilitarios;

namespace PEG.MPE.Paginas
{
    public partial class RankingClassificadaEstadual : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UCFiltroRanking1.IsEstadual = true;
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
            int IdEtapa = StringUtils.ToInt(((Label)this.grdRanking.Rows[index].Cells[1].FindControl("lblIdEtapa")).Text);

            if (e.CommandName == "Devolver")
            {
                this.UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (int)EnumType.TipoEtapaMpe.AvaliacaoEstadual, EnumType.Questionario.Gestao);
            }
            else if (e.CommandName == "FinalistaGestao")
            {
                new BllRelatorioRanking().EncaminharProximaEtapa(IdEmpresaCadastro, (int)EnumType.Questionario.Gestao, IdEtapa, true);
            }
            else if (e.CommandName == "FinalistaResponsabilidadeSocial")
            {
                new BllRelatorioRanking().EncaminharProximaEtapa(IdEmpresaCadastro, (int)EnumType.Questionario.ResponsabilidadeSocial, IdEtapa, true);
            }
            else if (e.CommandName == "FinalistaInovacao")
            {
                new BllRelatorioRanking().EncaminharProximaEtapa(IdEmpresaCadastro, (int)EnumType.Questionario.Inovacao, IdEtapa, true);
            }
        }

        /*private void DevolverParaAvaliador(Int32 IdQuestionarioEmpresa, String Justificativa)
        {
            EntQuestionarioEmpresaAvaliador objQuestionarioEmpresaAvaliador = new EntQuestionarioEmpresaAvaliador();
            objQuestionarioEmpresaAvaliador.QuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
            objQuestionarioEmpresaAvaliador.MotivoDevolucao = Justificativa;
            objQuestionarioEmpresaAvaliador.QuestionarioEmpresa.ParaAvaliador = true;

            new BllRelatorioRanking().DevolverParaAvaliador(objQuestionarioEmpresaAvaliador);
            this.PopulaGridEmpresa();
        }*/

        protected void grdRanking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RelRankingClassificada objRelRankingClassificada = ((RelRankingClassificada)e.Row.DataItem);
                Label lblIdQuestionarioEmpresa = ((Label)e.Row.FindControl("lblIdQuestionarioEmpresa"));

                Label lblRanking = ((Label)e.Row.FindControl("lblRanking"));
                lblRanking.Text = IntUtils.ToString(e.Row.RowIndex + 1);

                ImageButton imgBttn = ((ImageButton)e.Row.FindControl("imgBttnDevolver"));
                Label lblParaAvaliacao = ((Label)e.Row.FindControl("lblParaAvaliacao"));
                this.AlterarCheck(imgBttn, StringUtils.ToBoolean(lblParaAvaliacao.Text));

                imgBttn = ((ImageButton)e.Row.FindControl("imgBttnFinalista"));
                this.AlterarCheck(imgBttn, objRelRankingClassificada.Finalista);

                imgBttn = ((ImageButton)e.Row.FindControl("imgBttnFinalistaResponsabilidadeSocial"));
                imgBttn.Visible = objRelRankingClassificada.PossuiResponsabilidadeSocial;
                this.AlterarCheck(imgBttn, objRelRankingClassificada.FinalistaResponsabilidadeSocial);

                imgBttn = ((ImageButton)e.Row.FindControl("imgBttnFinalistaInovacao"));
                imgBttn.Visible = objRelRankingClassificada.PossuiInovacao;
                this.AlterarCheck(imgBttn, objRelRankingClassificada.FinalistaInovacao);
            }
        }

        private void AlterarCheck(ImageButton imgBttn, Boolean valor)
        {
            imgBttn.ImageUrl = valor ? "~/Image/checked.gif" : "~/Image/unchecked.gif";
        }
    }
}