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
    public partial class RankingCandidataEstadual : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfiguraPagina(objPrograma.IdPrograma);
            }
        }

        protected void grdSimplificado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ImgBttnClassificar = ((ImageButton)e.Row.FindControl("ImgBttnClassificar"));
                CheckBox ChckBxClassificar = ((CheckBox)e.Row.FindControl("ChckBxClassificar"));

                ImageButton imgBttnDesclassificar = ((ImageButton)e.Row.FindControl("imgBttnDesclassificar"));
                CheckBox ChckBxDesclassificar = ((CheckBox)e.Row.FindControl("ChckBxDesclassificar"));

                DropDownList DrpDwnLstSenior = ((DropDownList)e.Row.FindControl("DrpDwnLstSenior"));
                DropDownList DrpDwnLstAcompanhante = ((DropDownList)e.Row.FindControl("DrpDwnLstAcompanhante"));
                ImageButton ImgBttnGravar = ((ImageButton)e.Row.FindControl("ImgBttnGravar"));
                Label lblPassaProximaEtapa = ((Label)e.Row.FindControl("lblFlPassaProximaEtapa"));

                Label lblJaAvaliada = ((Label)e.Row.FindControl("lblJaAvaliada"));
                Label lblEtapaAtiva = ((Label)e.Row.FindControl("lblFlEtapaAtiva"));
                Label lblFlDesclassificado = ((Label)e.Row.FindControl("lblFlDesclassificado"));
                Boolean isEtapaAtiva = false;
                if (lblEtapaAtiva.Text == "True")
                {
                    isEtapaAtiva = true;
                }

                if (ChckBxClassificar.Checked)
                {
                    Label lblIdAvaliadorSenior = ((Label)e.Row.FindControl("lblIdAvaliadorSenior"));
                    Label lblIdAvaliadorAcompanhante = ((Label)e.Row.FindControl("lblIdAvaliadorAcompanhante"));
                    Label lblNomeAvaliadorSenior = ((Label)e.Row.FindControl("lblNomeAvaliadorSenior"));
                    Label lblNomeAvaliadorAcompanhante = ((Label)e.Row.FindControl("lblNomeAvaliadorAcompanhante"));

                    ImgBttnClassificar.ImageUrl = "~/Image/checked.gif";
                    DrpDwnLstSenior.Visible = true;
                    DrpDwnLstAcompanhante.Visible = true;
                    DrpDwnLstSenior.Enabled = false;
                    DrpDwnLstAcompanhante.Enabled = false;
                    ImgBttnGravar.Visible = false;
                    ChckBxClassificar.Checked = true;
                    HabilitaDesabilitaBotao(imgBttnDesclassificar, false);
                    DrpDwnLstSenior.Items.Add(new ListItem(lblNomeAvaliadorSenior.Text, lblIdAvaliadorSenior.Text));
                    DrpDwnLstAcompanhante.Items.Add(new ListItem(lblNomeAvaliadorAcompanhante.Text, lblIdAvaliadorAcompanhante.Text));
                }
                else
                {
                    ImgBttnClassificar.ImageUrl = "~/Image/unchecked.gif";
                    DrpDwnLstSenior.Visible = false;
                    DrpDwnLstAcompanhante.Visible = false;
                    ImgBttnGravar.Visible = false;
                    ChckBxClassificar.Checked = false;
                    HabilitaDesabilitaBotao(imgBttnDesclassificar, true);
                }

                if (ChckBxDesclassificar.Checked)
                {
                    imgBttnDesclassificar.ImageUrl = "~/Image/checked.gif";
                    ChckBxDesclassificar.Checked = true;
                    HabilitaDesabilitaBotao(ImgBttnClassificar, false);
                }
                else
                {
                    imgBttnDesclassificar.ImageUrl = "~/Image/unchecked.gif";
                    ChckBxDesclassificar.Checked = false;
                    HabilitaDesabilitaBotao(ImgBttnClassificar, true);
                }
                if (!isEtapaAtiva)
                {
                    HabilitaDesabilitaBotao(ImgBttnClassificar, false);
                    DrpDwnLstSenior.Visible = false;
                    DrpDwnLstAcompanhante.Visible = false;
                    ImgBttnGravar.Visible = false;
                    ChckBxClassificar.Enabled = false;
                    HabilitaDesabilitaBotao(imgBttnDesclassificar, true);
                    HabilitaDesabilitaBotao(imgBttnDesclassificar, false);
                    ChckBxDesclassificar.Enabled = false;
                    HabilitaDesabilitaBotao(ImgBttnClassificar, false);
                }
                if (StringUtils.ToBoolean(lblJaAvaliada.Text))
                {
                    ChckBxDesclassificar.Enabled = false;
                    ChckBxClassificar.Enabled = false;
                    HabilitaDesabilitaBotao(ImgBttnClassificar, false);
                    HabilitaDesabilitaBotao(imgBttnDesclassificar, false);
                }
                else
                {
                    ChckBxDesclassificar.Enabled = true;
                    ChckBxClassificar.Enabled = true;
                    HabilitaDesabilitaBotao(ImgBttnClassificar, true);
                    HabilitaDesabilitaBotao(imgBttnDesclassificar, true);
                }

                Label lblRanking = ((Label)e.Row.FindControl("lblRanking"));
                lblRanking.Text = IntUtils.ToString(e.Row.RowIndex + 1);

                CheckBox chkTotalResponsabilidadeSocial = ((CheckBox)e.Row.FindControl("chkTotalResponsabilidadeSocial"));
                Label LblTotalResponsabilidadeSocial = ((Label)e.Row.FindControl("LblTotalResponsabilidadeSocial"));

                LblTotalResponsabilidadeSocial.Visible = chkTotalResponsabilidadeSocial.Checked;

                CheckBox chkPontuacaoInovacao = ((CheckBox)e.Row.FindControl("chkTotalResponsabilidadeSocial"));
                Label LblPontuacaoInovacao = ((Label)e.Row.FindControl("LblTotalResponsabilidadeSocial"));

                LblPontuacaoInovacao.Visible = chkPontuacaoInovacao.Checked;
/*                if (lblMarcaQuestoesEspeciais.Text == "Sim")
                {
                    e.Row.Style.Add("background-color", "#FFFFB5");
                }
                if (int.Parse(lblNumeroFuncionarios.Text) < 9 || StringUtils.ToDate(lblDataAbertura.Text) > StringUtils.ToDate("31/03/2009"))
                {
                    e.Row.Style.Add("background-color", "#FC8879");
                }*/
            }
        }

        private void PopulaGridEmpresa()
        {
            RelFiltroRanking objRelFiltroRanking = this.UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"]));
            ListaGrid = new BllRelatorioRanking().ObterRankingCandidataPorFiltro(objRelFiltroRanking);

            this.AtualizaGrid(objRelFiltroRanking);
        }

        private void AtualizaGrid(RelFiltroRanking objRelFiltroRanking)
        {
            if (((List<RelRankingCandidataEstadual>)ListaGrid).Count > 0)
            {
                ImgBttnExportar.Visible = true;
                divLegenda.Visible = true;
            }
            this.grdSimplificado.DataSource = ListaGrid;
            this.grdSimplificado.DataBind();
            this.grdSimplificado.SelectedIndex = -1;

            ExibeColunaDetalhe(objRelFiltroRanking.TipoRelatorio);
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

            if (e.CommandName == "Gravar")
            {
                //Gravar
                DropDownList DrpDwnLstSenior = ((DropDownList)grdSimplificado.Rows[Index].FindControl("DrpDwnLstSenior"));
                DropDownList DrpDwnLstAcompanhante = ((DropDownList)grdSimplificado.Rows[Index].FindControl("DrpDwnLstAcompanhante"));

                if (DrpDwnLstSenior.SelectedIndex == 0)
                {
                    MessageBox(this, "Selecione o Avaliador Senior!");
                }
                else
                {
                    Label lblIdEmpresaCadastro = ((Label)grdSimplificado.Rows[Index].FindControl("lblIdEmpresaCadastro"));
                    Label lblIdQuestionarioEmpresa = ((Label)grdSimplificado.Rows[Index].FindControl("lblIdQuestionarioEmpresa"));
                    ImageButton imgBtnSalvar = ((ImageButton)grdSimplificado.Rows[Index].FindControl("ImgBttnGravar"));
                    int IdEmpresaCadastro = StringUtils.ToInt(((Label)this.grdSimplificado.Rows[Index].Cells[1].FindControl("lblIdEmpresaCadastro")).Text);
                    int IdEtapa = StringUtils.ToInt(((Label)this.grdSimplificado.Rows[Index].Cells[1].FindControl("lblIdEtapa")).Text);

                    RelFiltroRanking objRelFiltroRanking = this.UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"]));
                    foreach (EntQuestionarioEmpresa qe in new BllQuestionarioEmpresa().ObterQuestionarioEmpresaAtivoPorTurmaEmpresa(int.Parse(lblIdEmpresaCadastro.Text), objRelFiltroRanking.Turma))
                    {
                        EntQuestionarioEmpresaAvaliador objQuestionarioEmpresaAvaliador = new EntQuestionarioEmpresaAvaliador();

                        objQuestionarioEmpresaAvaliador.QuestionarioEmpresa.IdQuestionarioEmpresa = qe.IdQuestionarioEmpresa;
                        objQuestionarioEmpresaAvaliador.Usuario.IdUsuario = StringUtils.ToInt(DrpDwnLstSenior.SelectedValue);
                        objQuestionarioEmpresaAvaliador.Avaliado = false;
                        objQuestionarioEmpresaAvaliador.Primario = true;

                        new BllQuestionarioEmpresaAvaliador().Inserir(objQuestionarioEmpresaAvaliador);

                        if (DrpDwnLstAcompanhante.SelectedIndex != 0)
                        {
                            objQuestionarioEmpresaAvaliador.QuestionarioEmpresa.IdQuestionarioEmpresa = qe.IdQuestionarioEmpresa;
                            objQuestionarioEmpresaAvaliador.Usuario.IdUsuario = StringUtils.ToInt(DrpDwnLstAcompanhante.SelectedValue);
                            objQuestionarioEmpresaAvaliador.Avaliado = false;
                            objQuestionarioEmpresaAvaliador.Primario = false;

                            new BllQuestionarioEmpresaAvaliador().Inserir(objQuestionarioEmpresaAvaliador);
                        }
                    }

                    new BllRelatorioRanking().EncaminharProximaEtapa(IdEmpresaCadastro, (int)EnumType.Questionario.Gestao, IdEtapa, false);

                    DrpDwnLstSenior.Enabled = false;
                    DrpDwnLstAcompanhante.Enabled = false;
                    imgBtnSalvar.Visible = false;
                }
            }
            else
            if (e.CommandName == "Desclassificar")
            {
                Label lblIdQuestionarioEmpresa = ((Label)grdSimplificado.Rows[Index].FindControl("lblIdQuestionarioEmpresa"));
                Label lblFlDesclassificado = ((Label)grdSimplificado.Rows[Index].FindControl("lblFlDesclassificado"));
                    int IdQuestionarioEmpresa = StringUtils.ToInt(lblIdQuestionarioEmpresa.Text);

                    if (lblFlDesclassificado.Text == "True")
                    {
                        EntQuestionarioEmpresa objQuestionarioEmpresa = new EntQuestionarioEmpresa();
                        objQuestionarioEmpresa.IdQuestionarioEmpresa = int.Parse(lblIdQuestionarioEmpresa.Text);
                        objQuestionarioEmpresa.Excluido = false;
                        new BllQuestionarioEmpresa().AlterarSomenteDesclassificar(objQuestionarioEmpresa);
                    }
                    else if (lblFlDesclassificado.Text == "False")
                    {
                        switch (objPrograma.IdPrograma)
                        {
                            case (int)EnumType.Programa.MPE:
                                this.UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (int)EnumType.TipoEtapaMpe.ClassificaçãoEstadual, EnumType.Questionario.Gestao);
                                break;

                            case (int)EnumType.Programa.FGA:
                                this.UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (int)EnumType.TipoEtapaFga.ValidacaoAnaliseRespostas, EnumType.Questionario.Gestao);
                                break;

                            case (int)EnumType.Programa.PEG:
                                this.UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (int)EnumType.TipoEtapaPeg.ValidacaoAnaliseRespostas, EnumType.Questionario.Gestao);
                                break;

                            default:
                                this.UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (int)EnumType.TipoEtapaMpe.ClassificaçãoEstadual, EnumType.Questionario.Gestao);
                                break;
                        }
                    }

                    CheckBox ChckBxDesclassificar = ((CheckBox)grdSimplificado.Rows[Index].FindControl("ChckBxDesclassificar"));
                    CheckBox ChckBxClassificar = ((CheckBox)grdSimplificado.Rows[Index].FindControl("ChckBxClassificar"));

                    ImageButton imgBttnDesclassificar = ((ImageButton)grdSimplificado.Rows[Index].FindControl("imgBttnDesclassificar"));
                    ImageButton ImgBttnClassificar = ((ImageButton)grdSimplificado.Rows[Index].FindControl("ImgBttnClassificar"));

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
                else if (e.CommandName == "Visualizar")
                {
                    RelFiltroRanking objRelFiltroRanking = this.UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"]));
                    int IdTurma = objRelFiltroRanking.Turma;
                    int IdEmpresaCadastro = StringUtils.ToInt(((Label)grdSimplificado.Rows[Index].FindControl("lblIdQuestionarioEmpresa")).Text);
                    this.UCVisualizarAutodiagnosticoInicial1.Visualiar(IdEmpresaCadastro, IdTurma);
                }
                else if (e.CommandName == "Update")
                {
                    CheckBox ChckBxClassificar = ((CheckBox)grdSimplificado.Rows[Index].FindControl("ChckBxClassificar"));
                    Label lblIdEmpresaCadastro = ((Label)grdSimplificado.Rows[Index].FindControl("lblIdEmpresaCadastro"));
                    Label lblIdQuestionarioEmpresa = ((Label)grdSimplificado.Rows[Index].FindControl("lblIdQuestionarioEmpresa"));
                    Label lblIdEstado = ((Label)grdSimplificado.Rows[Index].FindControl("lblIdEstado"));
                    Label lblIdEtapa = ((Label)grdSimplificado.Rows[Index].FindControl("lblIdEtapa"));
                    RelFiltroRanking objRelFiltroRanking = this.UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"]));
                    DropDownList DrpDwnLstSenior = ((DropDownList)grdSimplificado.Rows[Index].FindControl("DrpDwnLstSenior"));
                    EntEmpresaCadastro objEmpresaCadastro = new BllEmpresaCadastro().ObterPorId(int.Parse(lblIdEmpresaCadastro.Text));

                    if (!ChckBxClassificar.Checked)
                    {
                        List<EntAdmUsuario> ListaUser = new BllAdmUsuario().ObterPorFuncionalidade("Avaliações", objEmpresaCadastro.Estado.IdEstado, objPrograma.IdPrograma, objRelFiltroRanking.Turma);
                        DrpDwnLstSenior.Items.Clear();
                        DrpDwnLstSenior.DataSource = ListaUser;
                        DrpDwnLstSenior.DataBind();
                        DrpDwnLstSenior.Items.Insert(0, new ListItem("<< Selecionar >>", "0"));
                        DrpDwnLstSenior.SelectedValue = "0";
                    }
                    else
                    {
                        EntEtapa objEtapa = new BllEtapa().ObterProximaEtapaPorEtapaEstadoOrdem(int.Parse(lblIdEtapa.Text));

                        new BllQuestionarioEmpresaAvaliador().RemoverPorQuestionarioEmpresa(int.Parse(lblIdQuestionarioEmpresa.Text));
                        new BllQuestionarioEmpresa().AlterarSomentePassaProximaEtapa(int.Parse(lblIdQuestionarioEmpresa.Text));
                        new BllQuestionarioEmpresa().DesabilitaAnteriores(int.Parse(lblIdEmpresaCadastro.Text), objEtapa.IdEtapa, EntQuestionario.QUESTIONARIO_GESTAO_2011);
                    }
                }
                else if (e.CommandName == "Download")
                {
                    Boolean comentarios = false;
                    Int32 intro = 0;
                    String estado = null;
                    String categoria = null;
                    String protocolo = ((Label)grdSimplificado.Rows[Index].Cells[8].Controls[1]).Text;
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

        protected void grdSimplificado_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Int32 IdQuestionarioEmpresa = StringUtils.ToInt(grdSimplificado.DataKeys[0].Value.ToString());

            ImageButton ImgBttnDesclassificar = ((ImageButton)grdSimplificado.Rows[e.RowIndex].FindControl("ImgBttnDesclassificar"));
            ImageButton ImgBttnClassificar = ((ImageButton)grdSimplificado.Rows[e.RowIndex].FindControl("ImgBttnClassificar"));
            CheckBox ChckBxClassificar = ((CheckBox)grdSimplificado.Rows[e.RowIndex].FindControl("ChckBxClassificar"));

            if (ChckBxClassificar.Checked)
            {
                ImgBttnClassificar.ImageUrl = "~/Image/unchecked.gif";
                DropDownList DrpDwnLstSenior = ((DropDownList)grdSimplificado.Rows[e.RowIndex].FindControl("DrpDwnLstSenior"));
                DropDownList DrpDwnLstAcompanhante = ((DropDownList)grdSimplificado.Rows[e.RowIndex].FindControl("DrpDwnLstAcompanhante"));
                ImageButton ImgBttnGravar = ((ImageButton)grdSimplificado.Rows[e.RowIndex].FindControl("ImgBttnGravar"));

                DrpDwnLstSenior.Visible = false;
                DrpDwnLstAcompanhante.Visible = false;
                ImgBttnGravar.Visible = false;
                ChckBxClassificar.Checked = false;
                ImgBttnDesclassificar.Enabled = true;
            }
            else
            {
                ImgBttnClassificar.ImageUrl = "~/Image/checked.gif";
                DropDownList DrpDwnLstSenior = ((DropDownList)grdSimplificado.Rows[e.RowIndex].FindControl("DrpDwnLstSenior"));
                DropDownList DrpDwnLstAcompanhante = ((DropDownList)grdSimplificado.Rows[e.RowIndex].FindControl("DrpDwnLstAcompanhante"));
                ImageButton ImgBttnGravar = ((ImageButton)grdSimplificado.Rows[e.RowIndex].FindControl("ImgBttnGravar"));

                DrpDwnLstSenior.Visible = true;
                DrpDwnLstAcompanhante.Visible = true;
                ImgBttnGravar.Visible = true;
                ChckBxClassificar.Checked = true;
                ImgBttnDesclassificar.Enabled = false;
            }
        }

        private void ExibeColunaDetalhe(EnumType.TipoRelatorio TipoRelatorio)
        {
            switch (TipoRelatorio)
            {
                case EnumType.TipoRelatorio.Simplificado:

                    grdSimplificado.Columns[21].Visible =
                    grdSimplificado.Columns[22].Visible =
                    grdSimplificado.Columns[23].Visible =
                    grdSimplificado.Columns[24].Visible =
                    grdSimplificado.Columns[25].Visible =
                    grdSimplificado.Columns[26].Visible =
                    grdSimplificado.Columns[27].Visible = false;

                    TituloBoxSimplificado.Visible = true;
                    TituloBoxDetalhado.Visible = false;

                    break;
                case EnumType.TipoRelatorio.Detalhado:

                    grdSimplificado.Columns[21].Visible =
                    grdSimplificado.Columns[22].Visible =
                    grdSimplificado.Columns[23].Visible =
                    grdSimplificado.Columns[24].Visible =
                    grdSimplificado.Columns[25].Visible =
                    grdSimplificado.Columns[26].Visible =
                    grdSimplificado.Columns[27].Visible = true;

                    TituloBoxSimplificado.Visible = false;
                    TituloBoxDetalhado.Visible = true;

                    break;
            }
        }

        private void ConfiguraPagina(int IdPrograma)
        {
            lblTitulo.Text = "Ranking de Candidatas Estaduais";
        }

        protected void ImgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            this.UCExportarCandidataEstadual1.Exportar();
        }

    }
}