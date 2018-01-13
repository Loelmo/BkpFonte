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

namespace FGA.FGA.Paginas
{
    public partial class ComparacaoResultadosPreVisitaPosVisitaPreClassificadas : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UCFiltroRanking1.IsEstadual = true;
            }
            this.UCJustificativaRanking1.atualizaGrid += this.PopulaGridEmpresa;
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
            //if (((List<RelRankingClassificada>)ListaGrid).Count > 0)
            //{
            //    ImgBttnExportar.Visible = true;
            //}
            this.grdRanking.DataSource = ListaGrid;
            this.grdRanking.DataBind();
            this.grdRanking.SelectedIndex = -1;

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

                //if (ChckBxDesclassificar.Checked)
                //{
                //    imgBttnDesclassificar.ImageUrl = "~/Image/checked.gif";
                //    ChckBxDesclassificar.Checked = true;
                //    imgBttnFinalista.Enabled = false;
                //}
                //else
                //{
                //    imgBttnDesclassificar.ImageUrl = "~/Image/unchecked.gif";
                //    ChckBxDesclassificar.Checked = false;
                //    imgBttnFinalista.Enabled = true;
                //}

                Label lblEtapaAtiva = ((Label)e.Row.FindControl("lblFlEtapaAtiva"));
                Boolean isEtapaAtiva = false;
                if (lblEtapaAtiva.Text == "True")
                {
                    isEtapaAtiva = true;
                }

                ImageButton imgBttn = ((ImageButton)e.Row.FindControl("imgBttnDevolver"));
                Label lblParaAvaliacao = ((Label)e.Row.FindControl("lblParaAvaliacao"));

                imgBttn = ((ImageButton)e.Row.FindControl("imgBttnFinalista"));

                Label lblMarcaQuestoesEspeciais = ((Label)e.Row.FindControl("lblMarcaQuestoesEspeciais"));
                //if (lblMarcaQuestoesEspeciais.Text == "Sim")
                //{
                //    e.Row.Style.Add("background-color", "#FFFFB5");
                //}

            }
        }

        //protected void ImgBttnExportar_Click(object sender, ImageClickEventArgs e)
        //{
        //    this.UCExportarPreClassificadas1.Exportar();
        //}

        //protected void grdRanking_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {

                ////Build custom header.
                //GridView oGridView = (GridView)sender;
                //GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                //TableHeaderCell oTableCell = new TableHeaderCell();





                //oGridViewRow = new GridViewRow(2, 0, DataControlRowType.Header, DataControlRowState.Insert);
                //oTableCell = new TableHeaderCell();
                //oTableCell.Text = "teste 1";
                //oTableCell.ColumnSpan = 2;
                //oGridViewRow.Cells.Add(oTableCell);
                //oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);

                //oGridViewRow = new GridViewRow(3, 0, DataControlRowType.Header, DataControlRowState.Insert);
                //oTableCell = new TableHeaderCell();
                //oTableCell.Text = "teste 2";
                //oTableCell.ColumnSpan = 4;
                //oGridViewRow.Cells.Add(oTableCell);
                //oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);


                //oTableCell = new TableHeaderCell();
                //oTableCell.Text = "teste !!!";
                //oTableCell.ColumnSpan = 2;
                //oGridViewRow.Cells.Add(oTableCell);

                //oGridViewRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
                //oTableCell = new TableHeaderCell();
                //oTableCell.Text = "Empresa";
                //oTableCell.RowSpan = 4;
                //oGridViewRow.Cells.Add(oTableCell);
                //oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);

                //oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                //oTableCell = new TableHeaderCell();
                //oTableCell.Text = "Fase 1";
                //oTableCell.ColumnSpan = 20;
                //oGridViewRow.Cells.Add(oTableCell);
                //oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);

                //TableHeaderRow oTableRow = new TableHeaderRow();
                //oTableRow.Cells.Add(oTableCell);
                

                //for (int j = 0; j < 4; j++)
                //{
                //    oTableCell = new TableHeaderCell();

                //    oTableCell.Text = "teste !!!";
                //    oTableCell.ColumnSpan = 2;
                //    oGridViewRow.Cells.Add(oTableCell);
                //}
                //oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);

                //e.Row.Cells[2].Text = "Testando";

                //for (int i = 0; i < e.Row.Cells.Count; i++)
                //{
                //    if (i == 0)
                //        e.Row.Cells[i].Text = "";
                //    else if (i % 2 == 0)
                //        e.Row.Cells[i].Text = "%";
                //    else
                //        e.Row.Cells[i].Text = "Calls";
                //}

                //var gridView = (GridView)sender;
                //var header = (GridViewRow)gridView.Controls[0].Controls[0];

                //header.Cells[0].Visible = true;
                //header.Cells[0].ColumnSpan = 20;
                //header.Cells[0].Text = "Fase 1";

                //header = (GridViewRow)gridView.Controls[1].Controls[0];
                //header.Cells[1].Visible = true;
                //header.Cells[1].ColumnSpan = 2;
                //header.Cells[1].Text = "Teste !! !!";
        //    }

        //}




    }
}