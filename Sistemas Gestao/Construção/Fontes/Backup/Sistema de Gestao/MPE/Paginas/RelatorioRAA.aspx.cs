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
using Sistema_de_Gestao.Utilitarios;

namespace Sistema_de_Gestao
{
    public partial class RelatorioRAA : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulaGridRelatorioRAA();
            }
            this.UCConfirmaEmail1.enviarEmail += EnviarEmail;
        }

        private void AtualizaGrid()
        {
            if (((List<EntRelatorioRAA>)ListaGrid).Count == 0)
            {
                grdRelatorioRAA.Width = 300;
            }
            this.grdRelatorioRAA.DataSource = ListaGrid;
            this.grdRelatorioRAA.DataBind();
            this.grdRelatorioRAA.SelectedIndex = -1;
        }

        private void PopulaGridRelatorioRAA()
        {
            Int32 IdEmpresaCadastro = EmpresaLogada.IdEmpresaCadastro;
            Int32 IdTurma = objTurma.IdTurma;

            ListaGrid = new BllRelatorio().RelRAAPorFiltro(IdEmpresaCadastro, IdTurma, objPrograma.IdPrograma, null);

            this.AtualizaGrid();
        }

        protected void grdRelatorioRAA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRelatorioRAA.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        protected void grdRelatorioRAA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                EntRelatorioRAA objRelatorioRAA = ((EntRelatorioRAA)e.Row.DataItem);

                Label lblTipoRelatorio = ((Label)e.Row.FindControl("lblTipoRelatorio"));

                String lblEtapa = "";
                switch(objRelatorioRAA.TipoEtapa){
                    case EntTipoEtapa.TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_ADMINISTRATIVO:
                    case EntTipoEtapa.TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_EMPRESA:
                        lblEtapa = "Inicial";
                        break;
                    case EntTipoEtapa.TIPO_ETAPA_MPE_CLASSIFICACAO_ESTADUAL:
                    case EntTipoEtapa.TIPO_ETAPA_MPE_AVALIACAO_ESTADUAL:
                    case EntTipoEtapa.TIPO_ETAPA_MPE_JULGAMENTO_FINALISTAS_ESTADUAL:
                        lblEtapa = "Inicial";
                        break;
                    case EntTipoEtapa.TIPO_ETAPA_MPE_CLASSIFICACAO_NACIONAL:
                    case EntTipoEtapa.TIPO_ETAPA_MPE_AVALIACAO_NACIONAL:
                    case EntTipoEtapa.TIPO_ETAPA_MPE_JULGAMENTO_FINALISTAS_NACIONAL:
                        lblEtapa = "Final";
                        break;
                }

                if (objRelatorioRAA.Avaliador)
                {
                    lblEtapa = "Avaliação " + lblEtapa;
                }
                else
                {
                    lblEtapa = "Autoavaliação " + lblEtapa;
                }

                lblTipoRelatorio.Text = lblEtapa;
            }
        }

        private void EnviarEmail(String Email)
        {
            Int32 RowIndex = ObjectUtils.ToInt(hddRowIndex.Value);
            String protocolo = ((Label)grdRelatorioRAA.Rows[RowIndex].Cells[15].Controls[1]).Text;
            Int32 programa = StringUtils.ToInt(((Label)grdRelatorioRAA.Rows[RowIndex].Cells[16].Controls[1]).Text);
            Boolean avaliador = StringUtils.ToBoolean(((Label)grdRelatorioRAA.Rows[RowIndex].Cells[17].Controls[1]).Text);
            String caminho = "";
            if (protocolo != "")
            {
                String estado = null;
                String categoria = null;

                List<EntQuestionarioEmpresa> listQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorProtocolo(protocolo);

                if (listQuestionarioEmpresa != null)
                {
                    List<EntEmpresaCadastro> listEmpresaCadastro = new BllEmpresaCadastro().ObterPorIdPrograma(listQuestionarioEmpresa[0].EmpresaCadastro.IdEmpresaCadastro, programa);

                    if (listEmpresaCadastro != null)
                    {
                        caminho = gerarRelatorioPDF(listEmpresaCadastro[0].IdEmpresaCadastro.ToString(), listEmpresaCadastro[0].CPF_CNPJ, listQuestionarioEmpresa[0].IdQuestionarioEmpresa.ToString(), protocolo, estado, categoria, false, programa, objTurma.IdTurma, BooleanUtils.ToInt(avaliador), 0, true, this.Page);
                    }
                }
                if (caminho != "")
                    WebUtils.EnviaEmailRaa(Email, "", caminho);
            }
            UCStatus1.UpdateControls();
        }

        protected void grdRelatorioRAA_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Email")
            {
                hddRowIndex.Value = ObjectUtils.ToString(e.CommandArgument);
                this.UCConfirmaEmail1.Show();
            }
            else if (e.CommandName == "Download")
            {
                hddRowIndex.Value = ObjectUtils.ToString(e.CommandArgument);
                Boolean comentarios = false;
                Int32 intro = 0;
                Int32 RowIndex = ObjectUtils.ToInt(hddRowIndex.Value);
                String estado = null;
                String categoria = null;
                String protocolo = ((Label)grdRelatorioRAA.Rows[RowIndex].Cells[15].Controls[1]).Text;
                Int32 programaId = StringUtils.ToInt(((Label)grdRelatorioRAA.Rows[RowIndex].Cells[16].Controls[1]).Text);
                Boolean avaliador = StringUtils.ToBoolean(((Label)grdRelatorioRAA.Rows[RowIndex].Cells[17].Controls[1]).Text);
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

                UCStatus1.UpdateControls();
//                Response.Redirect("~/FGA/Paginas/RelatorioRAA.aspx");
            }
        }
    }
}