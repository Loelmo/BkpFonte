using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using PEG.Pagina_Base;
using Vinit.SG.Ent;
using PEG.Utilitarios;
using Sistema_de_Gestão_de_Treinamento.User_Control;

namespace PEG.User_Control
{
    public partial class UCHistoricoRAA : UCBase
    {
        public Object ListaGridAux
        {
            get
            {
                if (Session["ListaGridAux"] == null)
                {
                    Session["ListaGridAux"] = new List<Object>();
                }
                return Session["ListaGridAux"];
            }

            set { Session["ListaGridAux"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCConfirmaEmail1.enviarEmail += EnviarEmail;
        }

        public void Show(Int32 idEmpresaCadastro, Int32 idTurma)
        {
            Show(idEmpresaCadastro, idTurma, "", "");
        }

        public void Show(Int32 idEmpresaCadastro, Int32 idTurma, String Cnpj, String RazaoSocial)
        {
            this.lblCnpj.Text = Cnpj;
            this.lblRazaoSocial.Text = RazaoSocial;
            this.PopulaGridRelatorioRAA(idEmpresaCadastro, idTurma);
            this.divUserControl.Visible = true;
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Close();
        }

        private void AtualizaGrid()
        {

            if (((List<EntRelatorioRAA>)ListaGridAux).Count == 0)
            {
                grdRelatorioRAA.Width = 300;
            }

            HabilitaColunasPorPrograma(objPrograma);

            this.grdRelatorioRAA.DataSource = ListaGridAux;
            this.grdRelatorioRAA.DataBind();
            this.grdRelatorioRAA.SelectedIndex = -1;
        }

        private void PopulaGridRelatorioRAA(Int32 IdEmpresaCadastro, Int32 IdTurma)
        {
            ListaGridAux = new BllRelatorio().RelRAAPorFiltro(IdEmpresaCadastro, IdTurma, objPrograma.IdPrograma, null);
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
                switch (objRelatorioRAA.TipoEtapa)
                {
                    case EntTipoEtapa.TIPO_ETAPA_PEG_INSCRICAO_AUTODIAGNOSTICO_ADMINISTRATIVO:
                    case EntTipoEtapa.TIPO_ETAPA_PEG_INSCRICAO_AUTODIAGNOSTICO_EMPRESA:
                        lblEtapa = "Inicial";
                        break;
                    case EntTipoEtapa.TIPO_ETAPA_PEG_VALIDACAO_RESPOSTAS:
                        lblEtapa = "Inicial";
                        break;
                    case EntTipoEtapa.TIPO_ETAPA_PEG_PRE_CLASSIFICADAS:
                        lblEtapa = "Inicial";
                        break;
                    case EntTipoEtapa.TIPO_ETAPA_PEG_FASE_4:
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
                        caminho = new PaginaBase().gerarRelatorioPDF(listEmpresaCadastro[0].IdEmpresaCadastro.ToString(), listEmpresaCadastro[0].CPF_CNPJ, listQuestionarioEmpresa[0].IdQuestionarioEmpresa.ToString(), protocolo, estado, categoria, false, programa, objTurma.IdTurma, BooleanUtils.ToInt(avaliador), 0, true, this.Page);
                    }
                }

                if (caminho != "")
                {
                    Boolean Enviado = WebUtils.EnviaEmailRaa(Email, "", caminho);
                    if (Enviado)
                    {
                        MessageBox(this.Page, "Email enviado com sucesso!");
                    }
                    else
                    {
                        MessageBox(this.Page, "Erro ao enviar email.");
                    }
                }
                else
                {
                    MessageBox(this.Page, "Erro ao gerar PDF.");
                }
            }
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
            }
        }

        private void HabilitaColunasPorPrograma(EntPrograma objPrograma)
        {
            Boolean ExisteEmpreendedorismo = false;
            switch (objPrograma.IdPrograma)
            {
                case (int)EnumType.Programa.MPE:
                    ExisteEmpreendedorismo = true;
                    break;
                case (int)EnumType.Programa.FGA:
                    ExisteEmpreendedorismo = false;
                    break;
                default:
                    ExisteEmpreendedorismo = false;
                    break;
            }
            this.grdRelatorioRAA.Columns[14].Visible = ExisteEmpreendedorismo;
        }
    }
}