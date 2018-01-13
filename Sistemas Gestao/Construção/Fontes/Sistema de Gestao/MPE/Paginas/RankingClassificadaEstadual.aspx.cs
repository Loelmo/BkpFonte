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

namespace Sistema_de_Gestao.MPE.Paginas
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
            if (((List<RelRankingClassificada>)ListaGrid).Count > 0)
            {
                ImgBttnExportar.Visible = true;
                divLegenda.Visible = true;
            }
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

                    grdRanking.Columns[16].Visible =
                    grdRanking.Columns[17].Visible =
                    grdRanking.Columns[18].Visible =
                    grdRanking.Columns[19].Visible =
                    grdRanking.Columns[20].Visible =
                    grdRanking.Columns[21].Visible =
                    grdRanking.Columns[22].Visible =
                    grdRanking.Columns[27].Visible =
                    grdRanking.Columns[28].Visible =
                    grdRanking.Columns[29].Visible =
                    grdRanking.Columns[30].Visible =
                    grdRanking.Columns[31].Visible =
                    grdRanking.Columns[32].Visible =
                    grdRanking.Columns[33].Visible = false;

                    TituloBoxSimplificado.Visible = true;
                    TituloBoxDetalhado.Visible = false;

                    break;
                case EnumType.TipoRelatorio.Detalhado:

                    grdRanking.Columns[16].Visible =
                    grdRanking.Columns[17].Visible =
                    grdRanking.Columns[18].Visible =
                    grdRanking.Columns[19].Visible =
                    grdRanking.Columns[20].Visible =
                    grdRanking.Columns[21].Visible =
                    grdRanking.Columns[22].Visible =
                    grdRanking.Columns[27].Visible =
                    grdRanking.Columns[28].Visible =
                    grdRanking.Columns[29].Visible =
                    grdRanking.Columns[30].Visible =
                    grdRanking.Columns[31].Visible =
                    grdRanking.Columns[32].Visible =
                    grdRanking.Columns[33].Visible = true;

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
                this.UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (int)EnumType.TipoEtapaMpe.AvaliacaoEstadual, EnumType.Questionario.Gestao);
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
            else if (e.CommandName == "Desclassificar")
            {
                Label lblIdQuestionarioEmpresa = ((Label)grdRanking.Rows[index].FindControl("lblIdQuestionarioEmpresa"));
                Label lblFlDesclassificado = ((Label)grdRanking.Rows[index].FindControl("lblFlDesclassificado"));

                if (lblFlDesclassificado.Text == "True")
                {
                    EntQuestionarioEmpresa objQuestionarioEmpresa = new EntQuestionarioEmpresa();
                    objQuestionarioEmpresa.IdQuestionarioEmpresa = int.Parse(lblIdQuestionarioEmpresa.Text);
                    objQuestionarioEmpresa.Excluido = false;
                    new BllQuestionarioEmpresa().AlterarSomenteDesclassificar(objQuestionarioEmpresa);
                }
                else if (lblFlDesclassificado.Text == "False")
                {
                    this.UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (int)EnumType.TipoEtapaFga.ValidacaoAnaliseRespostas, EnumType.Questionario.Gestao);
                }

                CheckBox ChckBxDesclassificar = ((CheckBox)grdRanking.Rows[index].FindControl("ChckBxDesclassificar"));
                CheckBox ChckBxClassificar = ((CheckBox)grdRanking.Rows[index].FindControl("ChckBxClassificar"));

                ImageButton imgBttnDesclassificar = ((ImageButton)grdRanking.Rows[index].FindControl("imgBttnDesclassificar"));
                ImageButton ImgBttnClassificar = ((ImageButton)grdRanking.Rows[index].FindControl("ImgBttnClassificar"));

                if (ChckBxDesclassificar.Checked)
                {
                    imgBttnDesclassificar.ImageUrl = "~/Image/unchecked.gif";
                    ChckBxDesclassificar.Checked = false;
                    ImgBttnClassificar.Enabled = true;
                }
                else
                {
                    imgBttnDesclassificar.ImageUrl = "~/Image/checked.gif";
                    ChckBxDesclassificar.Checked = true;
                    ImgBttnClassificar.Enabled = false;
                }
            }
            else if (e.CommandName == "FinalistaResponsabilidadeSocial")
            {
                if (FlPassaProximaEtapa)
                {
                    new BllRelatorioRanking().EncaminharEtapaAnterior(IdEmpresaCadastro, (int)EnumType.Questionario.ResponsabilidadeSocial, IdEtapa, false);
                }
                else
                {
	                new BllRelatorioRanking().EncaminharProximaEtapa(IdEmpresaCadastro, (int)EnumType.Questionario.ResponsabilidadeSocial, IdEtapa, true);
                }
            }
            else if (e.CommandName == "FinalistaInovacao")
            {
                if (FlPassaProximaEtapa)
                {
                    new BllRelatorioRanking().EncaminharEtapaAnterior(IdEmpresaCadastro, (int)EnumType.Questionario.Inovacao, IdEtapa, false);
                }
                else
                {
	                new BllRelatorioRanking().EncaminharProximaEtapa(IdEmpresaCadastro, (int)EnumType.Questionario.Inovacao, IdEtapa, true);
                }
            }
            else if (e.CommandName == "Download")
            {
                Boolean comentarios = false;
                Int32 intro = 0;
                String estado = null;
                String categoria = null;
                String protocolo = ((Label)grdRanking.Rows[index].Cells[7].Controls[1]).Text;
                Int32 programaId = objPrograma.IdPrograma;
                Boolean avaliador = false;
                String caminho = "";

                List<EntQuestionarioEmpresa> listQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorProtocolo(protocolo);

                if (listQuestionarioEmpresa != null)
                {
                    List<EntEmpresaCadastro> listEmpresaCadastro = new BllEmpresaCadastro().ObterPorIdPrograma(listQuestionarioEmpresa[0].EmpresaCadastro.IdEmpresaCadastro, programaId);

                    if (listEmpresaCadastro != null)
                    {
                        caminho = new PaginaBase().gerarRelatorioPDF(listEmpresaCadastro[0].IdEmpresaCadastro.ToString(), listEmpresaCadastro[0].CPF_CNPJ, listQuestionarioEmpresa[0].IdQuestionarioEmpresa.ToString(), protocolo, estado, categoria, comentarios, programaId, objTurma.IdTurma, BooleanUtils.ToInt(avaliador), intro, false, this.Page);
                        if (caminho != "")
                        {
                            NovaJanela(this.Page, caminho);
                        }
                    }
                }
            }
            else if (e.CommandName == "DownloadRa")
            {
                Boolean comentarios = false;
                Int32 intro = 0;
                String estado = null;
                String categoria = null;
                String protocolo = ((Label)grdRanking.Rows[index].Cells[7].Controls[1]).Text;
                Int32 programaId = objPrograma.IdPrograma;
                String caminho = "";

                List<EntQuestionarioEmpresa> listQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorProtocolo(protocolo);

                if (listQuestionarioEmpresa != null)
                {
                    List<EntEmpresaCadastro> listEmpresaCadastro = new BllEmpresaCadastro().ObterPorIdPrograma(listQuestionarioEmpresa[0].EmpresaCadastro.IdEmpresaCadastro, programaId);

                    if (listEmpresaCadastro != null)
                    {
                        caminho = new PaginaBase().gerarRelatorioPDF(listEmpresaCadastro[0].IdEmpresaCadastro.ToString(), listEmpresaCadastro[0].CPF_CNPJ, listQuestionarioEmpresa[0].IdQuestionarioEmpresa.ToString(), protocolo, estado, categoria, comentarios, programaId, objTurma.IdTurma, 1, intro, false, this.Page);
                        if (caminho != "")
                        {
                            NovaJanela(this.Page, caminho);
                        }
                    }
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

                ImageButton imgBttnFinalista = ((ImageButton)e.Row.FindControl("imgBttnFinalista"));
                ImageButton imgBttnDesclassificar = ((ImageButton)e.Row.FindControl("imgBttnDesclassificar"));
                CheckBox ChckBxDesclassificar = ((CheckBox)e.Row.FindControl("ChckBxDesclassificar"));

                if (ChckBxDesclassificar.Checked)
                {
                    imgBttnDesclassificar.ImageUrl = "~/Image/checked.gif";
                    ChckBxDesclassificar.Checked = true;
                    imgBttnFinalista.Enabled = false;
                }
                else
                {
                    imgBttnDesclassificar.ImageUrl = "~/Image/unchecked.gif";
                    ChckBxDesclassificar.Checked = false;
                    imgBttnFinalista.Enabled = true;
                }

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

                Label lblMarcaQuestoesEspeciais = ((Label)e.Row.FindControl("lblMarcaQuestoesEspeciais"));
                if (lblMarcaQuestoesEspeciais.Text == "Sim")
                {
                    e.Row.Style.Add("background-color", "#FFFFB5");
                }

            }
        }

        protected void ImgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            this.UCExportarClassificadas1.Exportar();
        }

    }
}