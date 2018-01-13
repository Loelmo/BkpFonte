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

namespace PEG.PEG.Paginas
{
    public partial class RankingFase2 : PaginaBase
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

                    grdRanking.Columns[19].Visible =
                    grdRanking.Columns[20].Visible =
                    grdRanking.Columns[21].Visible =
                    grdRanking.Columns[22].Visible =
                    grdRanking.Columns[23].Visible =
                    grdRanking.Columns[24].Visible =
                    grdRanking.Columns[25].Visible =
                    grdRanking.Columns[30].Visible =
                    grdRanking.Columns[31].Visible =
                    grdRanking.Columns[32].Visible =
                    grdRanking.Columns[33].Visible =
                    grdRanking.Columns[34].Visible =
                    grdRanking.Columns[35].Visible =
                    grdRanking.Columns[36].Visible = false;

                    TituloBoxSimplificado.Visible = true;
                    TituloBoxDetalhado.Visible = false;

                    break;
                case EnumType.TipoRelatorio.Detalhado:

                    grdRanking.Columns[19].Visible =
                    grdRanking.Columns[20].Visible =
                    grdRanking.Columns[21].Visible =
                    grdRanking.Columns[22].Visible =
                    grdRanking.Columns[23].Visible =
                    grdRanking.Columns[24].Visible =
                    grdRanking.Columns[25].Visible =
                    grdRanking.Columns[30].Visible =
                    grdRanking.Columns[31].Visible =
                    grdRanking.Columns[32].Visible =
                    grdRanking.Columns[33].Visible =
                    grdRanking.Columns[34].Visible =
                    grdRanking.Columns[35].Visible =
                    grdRanking.Columns[36].Visible = true;

                    TituloBoxSimplificado.Visible = false;
                    TituloBoxDetalhado.Visible = true;

                    break;
            }
        }

        protected void grdRanking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RelRankingPegFase2 objRelRankingClassificada = ((RelRankingPegFase2)e.Row.DataItem);
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

                ImageButton imgBttn = ((ImageButton)e.Row.FindControl("imgBttnDesclassificar"));
                Label lblExcluido = ((Label)e.Row.FindControl("lblExcluido"));
                this.AlterarCheck(imgBttn, StringUtils.ToBoolean(lblExcluido.Text), isEtapaAtiva && !StringUtils.ToBoolean(lblPassaProximaEtapa.Text));

                imgBttn = ((ImageButton)e.Row.FindControl("imgBttnFinalista"));
                this.AlterarCheck(imgBttn, StringUtils.ToBoolean(lblPassaProximaEtapa.Text), isEtapaAtiva);
            }
        }

        protected void grdRanking_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ObjectUtils.ToInt(e.CommandArgument) - (grdRanking.PageIndex * grdRanking.PageSize);
            int IdQuestionarioEmpresa = StringUtils.ToInt(((Label)this.grdRanking.Rows[index].Cells[0].FindControl("lblIdQuestionarioEmpresa")).Text);
            int IdEmpresaCadastro = StringUtils.ToInt(((Label)this.grdRanking.Rows[index].Cells[1].FindControl("lblIdEmpresaCadastro")).Text);
            int IdTurma = StringUtils.ToInt(((Label)this.grdRanking.Rows[index].Cells[2].FindControl("lblIdTurma")).Text);
            int IdEtapa = StringUtils.ToInt(((Label)this.grdRanking.Rows[index].Cells[3].FindControl("lblIdEtapa")).Text);

            if (e.CommandName == "Fase3")
            {
                this.UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (Int32) EnumType.TipoEtapaPeg.GestãoDoResultadoFase3, EnumType.Questionario.Gestao);
            }
            else if (e.CommandName == "ResumoFase2")
            {
                this.UCResumoRanking1.Show(IdQuestionarioEmpresa);
            }
            else if (e.CommandName == "Anexos")
            {
                this.UCTurmaEmpresaArquivoCE1.Show(IdQuestionarioEmpresa, IdTurma, IdEtapa, 2);
            }
            else if (e.CommandName == "PlanosAcao")
            {
                this.UCPlanoAcaoCE1.Show(IdQuestionarioEmpresa, IdTurma, IdEtapa, 2);
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
                    this.UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (int)EnumType.TipoEtapaPeg.ValidacaoAnaliseRespostas, EnumType.Questionario.Gestao);
                }

                CheckBox ChckBxDesclassificar = ((CheckBox)grdRanking.Rows[index].FindControl("ChckBxDesclassificar"));
                CheckBox ChckBxClassificar = ((CheckBox)grdRanking.Rows[index].FindControl("ChckBxClassificar"));

                ImageButton imgBttnDesclassificar = ((ImageButton)grdRanking.Rows[index].FindControl("imgBttnDesclassificar"));
                ImageButton ImgBttnClassificar = ((ImageButton)grdRanking.Rows[index].FindControl("ImgBttnClassificar"));

                if (ChckBxDesclassificar.Checked)
                {
                    imgBttnDesclassificar.ImageUrl = "~/Image/unchecked.gif";
                    ChckBxDesclassificar.Checked = false;
                    HabilitaDesabilitaBotao(ImgBttnClassificar, true);
                }
                else
                {
                    imgBttnDesclassificar.ImageUrl = "~/Image/checked.gif";
                    ChckBxDesclassificar.Checked = true;
                    HabilitaDesabilitaBotao(ImgBttnClassificar, false);
                }
            }
            else if (e.CommandName == "Download")
            {
                Boolean comentarios = false;
                Int32 intro = 0;
                String estado = null;
                String categoria = null;
                String protocolo = ((Label)grdRanking.Rows[index].Cells[8].Controls[1]).Text;
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
                String protocolo = ((Label)grdRanking.Rows[index].Cells[8].Controls[1]).Text;
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

        private void AlterarCheck(ImageButton imgBttn, Boolean valor)
        {
            imgBttn.ImageUrl = valor ? "~/Image/checked.gif" : "~/Image/unchecked.gif";
        }
    }
}