using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Sistema_de_Gestao.Pagina_Base;

namespace Sistema_de_Gestao.Paginas
{
    public partial class RelatorioQuestoesEspeciais : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfiguraPagina();
            }
        }

        protected void grdSimplificado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblRanking = ((Label)e.Row.FindControl("lblRanking"));
                lblRanking.Text = IntUtils.ToString(e.Row.RowIndex + 1);
            }
        }

        private void PopulaGridEmpresa()
        {
            RelFiltroRanking objRelFiltroRanking = this.UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"]));
            ListaGrid = new BllRelatorio().ObterRelatorioQuestoesEspeciais(objRelFiltroRanking);

            this.AtualizaGrid(objRelFiltroRanking);
        }

        private void AtualizaGrid(RelFiltroRanking objRelFiltroRanking)
        {
            this.grdSimplificado.DataSource = ListaGrid;
            this.grdSimplificado.DataBind();
            this.grdSimplificado.SelectedIndex = -1;
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridEmpresa();
        }

        protected void grdSimplificado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSimplificado.PageIndex = e.NewPageIndex;
            AtualizaGrid(this.UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"])));
        }

        protected void grdSimplificado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Index = ObjectUtils.ToInt(e.CommandArgument) - (grdSimplificado.PageIndex * grdSimplificado.PageSize);

                if (e.CommandName == "Download")
                {
                    Boolean comentarios = false;
                    Int32 intro = 0;
                    String estado = null;
                    String categoria = null;
                    String protocolo = ((Label)grdSimplificado.Rows[Index].Cells[2].Controls[1]).Text;
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
        }

        private void ConfiguraPagina()
        {
            switch (int.Parse(Request["TipoEtapaId"]))
            {
                case EntTipoEtapa.TIPO_ETAPA_FGA_VALIDACAO_RESPOSTAS:
                    lblTitulo.Text = "Comparativo de Questões Especiais Autoavaliação Inicial";
                    this.Title = "Comparativo de Questões Especiais Autoavaliação Inicial";
                    break;
                case EntTipoEtapa.TIPO_ETAPA_FGA_FASE_4:
                    lblTitulo.Text = "Comparativo de Questões Especiais Autoavaliação Final";
                    this.Title = "Comparativo de Questões Especiais Autoavaliação Final";
                    break;
            }
        }
    }
}