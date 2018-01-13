using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.BLL;
using Vinit.SG.Common;

namespace FGA.FGA.Paginas
{
    public partial class ComparacaoResultadosFase1Fase4PreVista : PaginaBase
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
            ListaGrid = new BllRelatorioRanking().ComparacaoResultadosFase1Fase4PreVista(objRelFiltroRanking);

            this.AtualizaGrid(objRelFiltroRanking);
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridEmpresa();
        }

        private void AtualizaGrid(RelFiltroRanking objRelFiltroRanking)
        {
            this.grdPreVisita.DataSource = ListaGrid;
            this.grdPreVisita.DataBind();
            this.grdPreVisita.SelectedIndex = -1;

        }

        protected void grdPreVisita_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ObjectUtils.ToInt(e.CommandArgument) - (grdPreVisita.PageIndex * grdPreVisita.PageSize);

            int IdQuestionarioEmpresa = StringUtils.ToInt(((Label)this.grdPreVisita.Rows[index].Cells[0].FindControl("lblIdQuestionarioEmpresa")).Text);
            int IdEmpresaCadastro = StringUtils.ToInt(((Label)this.grdPreVisita.Rows[index].Cells[1].FindControl("lblIdEmpresaCadastro")).Text);
            int IdEtapa = StringUtils.ToInt(((Label)this.grdPreVisita.Rows[index].Cells[2].FindControl("lblIdEtapa")).Text);
            bool FlPassaProximaEtapa = StringUtils.ToBoolean(((Label)this.grdPreVisita.Rows[index].Cells[2].FindControl("lblFlPassaProximaEtapa")).Text);

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
                Label lblIdQuestionarioEmpresa = ((Label)grdPreVisita.Rows[index].FindControl("lblIdQuestionarioEmpresa"));
                Label lblFlDesclassificado = ((Label)grdPreVisita.Rows[index].FindControl("lblFlDesclassificado"));

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

                CheckBox ChckBxDesclassificar = ((CheckBox)grdPreVisita.Rows[index].FindControl("ChckBxDesclassificar"));
                CheckBox ChckBxClassificar = ((CheckBox)grdPreVisita.Rows[index].FindControl("ChckBxClassificar"));

                ImageButton imgBttnDesclassificar = ((ImageButton)grdPreVisita.Rows[index].FindControl("imgBttnDesclassificar"));
                ImageButton ImgBttnClassificar = ((ImageButton)grdPreVisita.Rows[index].FindControl("ImgBttnClassificar"));

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
                String protocolo = ((Label)grdPreVisita.Rows[index].Cells[7].Controls[1]).Text;
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
                String protocolo = ((Label)grdPreVisita.Rows[index].Cells[7].Controls[1]).Text;
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

        protected void grdPreVisita_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                EntComparacaoResultados objRelRankingClassificada = ((EntComparacaoResultados)e.Row.DataItem);
                Label lblIdQuestionarioEmpresa = ((Label)e.Row.FindControl("lblIdQuestionarioEmpresa"));
                Label lblPassaProximaEtapa = ((Label)e.Row.FindControl("lblFlPassaProximaEtapa"));

                ImageButton imgBttnFinalista = ((ImageButton)e.Row.FindControl("imgBttnFinalista"));
                ImageButton imgBttnDesclassificar = ((ImageButton)e.Row.FindControl("imgBttnDesclassificar"));
                CheckBox ChckBxDesclassificar = ((CheckBox)e.Row.FindControl("ChckBxDesclassificar"));

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
                
            }
        }




    }
}