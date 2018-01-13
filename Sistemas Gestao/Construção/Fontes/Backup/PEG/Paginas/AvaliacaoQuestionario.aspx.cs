using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using PEG.Pagina_Base;

namespace PEG.Paginas
{
    public partial class AvaliacaoQuestionario : PaginaBase
    {
        public Object ListaUsuarios
        {
            get
            {
                if (Session["ListaUsuarios"] == null)
                {
                    Session["ListaUsuarios"] = new List<Object>();
                }
                return Session["ListaUsuarios"];
            }

            set { Session["ListaUsuarios"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ListaUsuarios = new BllAdmUsuario().ObterPorIdGrupo(16);
            divDevolucao.Style.Add("display", "none");
            this.UCListaQuestionariosAvaliacao1.atualizaGrid += this.PopulaGridEmpresa;

        }

        protected void grdSimplificado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label labelAvaliado = ((Label)e.Row.FindControl("lblAvaliado"));
                Label labelDevolvido = ((Label)e.Row.FindControl("lblDevolvido"));
                ImageButton ImgBttnAvaliar = ((ImageButton)e.Row.FindControl("ImgBttnAvaliar"));
                ImageButton ImgBttnFormulario = ((ImageButton)e.Row.FindControl("ImgBttnFormulario"));
                ImageButton ImgBttnDevolucao = ((ImageButton)e.Row.FindControl("ImgBttnDevolucao"));

                if (StringUtils.ToBoolean(labelAvaliado.Text) && !StringUtils.ToBoolean(labelDevolvido.Text))
                {
                    HabilitaDesabilitaBotao(ImgBttnAvaliar, false);
                    ImgBttnAvaliar.ImageUrl = "~/Image/ico_pesquisar_desabilitado.png";
                }
                if (!StringUtils.ToBoolean(labelDevolvido.Text))
                {
                    HabilitaDesabilitaBotao(ImgBttnDevolucao, false);
                    ImgBttnDevolucao.ImageUrl = "~/Image/voltar16a_desabilitado.png";
                }

            }
        }

        private void PopulaGridEmpresa()
        {
            RelFiltroRanking objRelFiltroRanking = this.UCFiltroAvaliacao1.GetFiltro();
            ListaGrid = new BllRelatorioRanking().ObterAvaliacaoPorFiltro(objRelFiltroRanking);

            if (((List<RelAvaliacao>)ListaGrid).Count > 0)
            {
                ImgBttnExportar.Visible = true;
            }
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
            AtualizaGrid(this.UCFiltroAvaliacao1.GetFiltro());
        }

        protected void grdSimplificado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Index = ObjectUtils.ToInt(e.CommandArgument) - (grdSimplificado.PageIndex * grdSimplificado.PageSize);

            if (e.CommandName == "Avaliar")
            {
                //Avaliar
                Label lblIdEmpresaCadastro = ((Label)grdSimplificado.Rows[Index].FindControl("lblIdEmpresaCadastro"));
                int IdEmpresaCadastro = StringUtils.ToInt(lblIdEmpresaCadastro.Text);
                Label lblIdEtapa = ((Label)grdSimplificado.Rows[Index].FindControl("lblIdEtapa"));
                int IdEtapa = StringUtils.ToInt(lblIdEtapa.Text);
                int IdTurma = UCFiltroAvaliacao1.IdTurma();
                this.UCListaQuestionariosAvaliacao1.Editar(IdEmpresaCadastro, IdEtapa, IdTurma);
            }
            else if (e.CommandName == "Formulario")
            {
                //Formulario
                Boolean comentarios = false;
                Int32 intro = 0;
                String estado = null;
                String categoria = null;
                String protocolo = ((Label)grdSimplificado.Rows[Index].FindControl("lblProtocolo")).Text;
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
            else if (e.CommandName == "Devolucao")
            {
                //Devolucao
                Label labelIdQuestionarioEmpresa = ((Label)grdSimplificado.Rows[Index].FindControl("lblIdQuestionarioEmpresa"));
                String motivoDevolucao = "";
                EntQuestionarioEmpresa objQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorId(int.Parse(labelIdQuestionarioEmpresa.Text));
                if (objQuestionarioEmpresa.MotivoExcluiu != null)
                {
                    motivoDevolucao = objQuestionarioEmpresa.MotivoExcluiu;
                }
                this.TxtDevolucao.Text = motivoDevolucao;

                this.divDevolucao.Style.Add("display", "block");
            }
        }

        protected void grdSimplificado_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Int32 IdQuestionarioEmpresa = StringUtils.ToInt(grdSimplificado.DataKeys[0].Value.ToString());
            Boolean Classificar = StringUtils.ToBoolean(grdSimplificado.DataKeys[1].Value.ToString());

            ImageButton ImgBttnDesclassificar = ((ImageButton)grdSimplificado.Rows[e.RowIndex].FindControl("ImgBttnDesclassificar"));
            ImageButton ImgBttnClassificar = ((ImageButton)grdSimplificado.Rows[e.RowIndex].FindControl("ImgBttnClassificar"));
        }
    }
}