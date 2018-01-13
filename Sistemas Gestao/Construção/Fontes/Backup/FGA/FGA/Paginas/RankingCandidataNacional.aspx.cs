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
    public partial class RankingCandidataNacional : PaginaBase
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
            if (!IsPostBack)
            {
                UCFiltroRanking1.IsEstadual = false;
            }
        }

        protected void grdSimplificado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ImgBttnClassificar = ((ImageButton)e.Row.FindControl("ImgBttnClassificar"));
                CheckBox ChckBxClassificar = ((CheckBox)e.Row.FindControl("ChckBxClassificar"));

                DropDownList DrpDwnLstSenior = ((DropDownList)e.Row.FindControl("DrpDwnLstSenior"));
                DropDownList DrpDwnLstAcompanhante = ((DropDownList)e.Row.FindControl("DrpDwnLstAcompanhante"));
                ImageButton ImgBttnGravar = ((ImageButton)e.Row.FindControl("ImgBttnGravar"));
                Label lblPassaProximaEtapa = ((Label)e.Row.FindControl("lblFlPassaProximaEtapa"));

                Label lblEtapaAtiva = ((Label)e.Row.FindControl("lblFlEtapaAtiva"));
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
                }

                if (!isEtapaAtiva)
                {
                    ImgBttnClassificar.Enabled = false;
                    DrpDwnLstSenior.Visible = false;
                    DrpDwnLstAcompanhante.Visible = false;
                    ImgBttnGravar.Visible = false;
                    ChckBxClassificar.Enabled = false;
                    ImgBttnClassificar.Enabled = false;
                }

                Label lblRanking = ((Label)e.Row.FindControl("lblRanking"));
                lblRanking.Text = IntUtils.ToString(e.Row.RowIndex + 1);
            }
        }

        private void PopulaGridEmpresa()
        {
            RelFiltroRanking objRelFiltroRanking = this.UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"]));
            ListaGrid = new BllRelatorioRanking().ObterRankingCandidataNacionalPorFiltro(objRelFiltroRanking);
            this.AtualizaGrid(objRelFiltroRanking);

        }

        private void AtualizaGrid(RelFiltroRanking objRelFiltroRanking)
        {
            OrdemPontuacaoTotalQuestionario(objRelFiltroRanking.Questionario);
            ExibeColunaDetalhe(objRelFiltroRanking.TipoRelatorio);

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

                if (DrpDwnLstSenior.SelectedIndex == 0)
                {
                    MessageBox(this, "Selecione o Avaliador Senior!");
                }
                else
                {
                    Label lblIdQuestionarioEmpresa = ((Label)grdSimplificado.Rows[Index].FindControl("lblIdQuestionarioEmpresa"));
                    int IdEmpresaCadastro = StringUtils.ToInt(((Label)this.grdSimplificado.Rows[Index].Cells[1].FindControl("lblIdEmpresaCadastro")).Text);
                    int IdEtapa = StringUtils.ToInt(((Label)this.grdSimplificado.Rows[Index].Cells[2].FindControl("lblIdEtapa")).Text);
                    int IdQuestionario = StringUtils.ToInt(((Label)this.grdSimplificado.Rows[Index].Cells[1].FindControl("lblIdQuestionario")).Text);

                    EntQuestionarioEmpresaAvaliador objQuestionarioEmpresaAvaliador = new EntQuestionarioEmpresaAvaliador();

                    objQuestionarioEmpresaAvaliador.QuestionarioEmpresa.IdQuestionarioEmpresa = StringUtils.ToInt(lblIdQuestionarioEmpresa.Text);
                    objQuestionarioEmpresaAvaliador.Usuario.IdUsuario = StringUtils.ToInt(DrpDwnLstSenior.SelectedValue);
                    objQuestionarioEmpresaAvaliador.Avaliado = true;
                    objQuestionarioEmpresaAvaliador.Primario = true;

                    new BllQuestionarioEmpresaAvaliador().Inserir(objQuestionarioEmpresaAvaliador);

                    DropDownList DrpDwnLstAcompanhante = ((DropDownList)grdSimplificado.Rows[Index].FindControl("DrpDwnLstAcompanhante"));

                    if (DrpDwnLstAcompanhante.SelectedIndex != 0)
                    {
                        objQuestionarioEmpresaAvaliador.QuestionarioEmpresa.IdQuestionarioEmpresa = StringUtils.ToInt(lblIdQuestionarioEmpresa.Text);
                        objQuestionarioEmpresaAvaliador.Usuario.IdUsuario = StringUtils.ToInt(DrpDwnLstAcompanhante.SelectedValue);
                        objQuestionarioEmpresaAvaliador.Avaliado = true;
                        objQuestionarioEmpresaAvaliador.Primario = false;

                        new BllQuestionarioEmpresaAvaliador().Inserir(objQuestionarioEmpresaAvaliador);
                    }

                    new BllRelatorioRanking().EncaminharProximaEtapa(IdEmpresaCadastro, IdQuestionario, IdEtapa, true);
                }
            }
            else
            {
                if (e.CommandName == "Desclassificar")
                {
                    Label lblIdQuestionarioEmpresa = ((Label)grdSimplificado.Rows[Index].FindControl("lblIdQuestionarioEmpresa"));

                    int IdQuestionarioEmpresa = StringUtils.ToInt(lblIdQuestionarioEmpresa.Text);
                    this.UCJustificativaRanking1.Show(IdQuestionarioEmpresa, (int)EnumType.TipoEtapaMpe.ClassificaçãoEstadual, EnumType.Questionario.Gestao);

                    CheckBox ChckBxDesclassificar = ((CheckBox)grdSimplificado.Rows[Index].FindControl("ChckBxDesclassificar"));
                    CheckBox ChckBxClassificar = ((CheckBox)grdSimplificado.Rows[Index].FindControl("ChckBxClassificar"));

                    ImageButton imgBttnDesclassificar = ((ImageButton)grdSimplificado.Rows[Index].FindControl("imgBttnDesclassificar"));
                    ImageButton ImgBttnClassificar = ((ImageButton)grdSimplificado.Rows[Index].FindControl("ImgBttnClassificar"));

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
            }
        }

        protected void grdSimplificado_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Int32 IdQuestionarioEmpresa = StringUtils.ToInt(grdSimplificado.DataKeys[0].Value.ToString());

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

                //Passa para etapa anterior pois não é mais vencedor
                EntQuestionarioEmpresa objQuestionarioEmpresa = new EntQuestionarioEmpresa();
                Label lblIdEmpresaCadastro = ((Label)grdSimplificado.Rows[e.RowIndex].FindControl("lblIdEmpresaCadastro"));

                objQuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro = StringUtils.ToInt(lblIdEmpresaCadastro.Text);
                objQuestionarioEmpresa.Usuario.IdUsuario = IdUsuarioLogado;
                objQuestionarioEmpresa.Questionario.IdQuestionario = (Int32)UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"])).Questionario;
                objQuestionarioEmpresa.Etapa.TipoEtapa.IdTipoEtapa = (Int32)EnumType.TipoEtapaMpe.ClassificacaoNacional;

                new BllRelatorioRanking().EncaminharEtapaAnterior(objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, objQuestionarioEmpresa.Questionario.IdQuestionario, objQuestionarioEmpresa.Etapa.IdEtapa, true);
            }
            else
            {
                ImgBttnClassificar.ImageUrl = "~/Image/checked.gif";
                Label lblIdEstado = ((Label)grdSimplificado.Rows[e.RowIndex].FindControl("lblIdEstado"));
                RelFiltroRanking objRelFiltroRanking = this.UCFiltroRanking1.GetFiltro(int.Parse(Request["TipoEtapaId"]));
                DropDownList DrpDwnLstSenior = ((DropDownList)grdSimplificado.Rows[e.RowIndex].FindControl("DrpDwnLstSenior"));
                DropDownList DrpDwnLstAcompanhante = ((DropDownList)grdSimplificado.Rows[e.RowIndex].FindControl("DrpDwnLstAcompanhante"));
                ImageButton ImgBttnGravar = ((ImageButton)grdSimplificado.Rows[e.RowIndex].FindControl("ImgBttnGravar"));

                DrpDwnLstSenior.Visible = true;
                DrpDwnLstAcompanhante.Visible = true;
                ImgBttnGravar.Visible = true;
                ChckBxClassificar.Checked = true;

                List<EntAdmUsuario> ListaUser = new BllAdmUsuario().ObterPorFuncionalidade("Avaliar", int.Parse(lblIdEstado.Text), objPrograma.IdPrograma, objRelFiltroRanking.Turma);
                DrpDwnLstSenior.Items.Clear();
                DrpDwnLstSenior.DataSource = ListaUser;
                DrpDwnLstSenior.DataBind();
                DrpDwnLstSenior.Items.Insert(0, new ListItem("<< Selecionar >>", "0"));
                DrpDwnLstSenior.SelectedValue = "0";

                DrpDwnLstAcompanhante.Items.Clear();
                DrpDwnLstAcompanhante.DataSource = ListaUser;
                DrpDwnLstAcompanhante.DataBind();
                DrpDwnLstAcompanhante.Items.Insert(0, new ListItem("<< Selecionar >>", "0"));
                DrpDwnLstAcompanhante.SelectedValue = "0";

            }
        }

        private void OrdemPontuacaoTotalQuestionario(EnumType.Questionario Questionario)
        {
            switch (Questionario)
            {
                case EnumType.Questionario.ResponsabilidadeSocial:

                    this.grdSimplificado.Columns[8].Visible = true;      //Coluna Total Pontuação Responsabilidade Social "Coluna inicio relatório"
                    this.grdSimplificado.Columns[9].Visible = false;     //Coluna Total Pontuação Inovação "Coluna inicio relatório"
                    this.grdSimplificado.Columns[15].Visible = false;    //Coluna Total Pontuação Responsabilidade Social "Coluna fim relatório"
                    this.grdSimplificado.Columns[16].Visible = true;     //Coluna Total Pontuação Inovação "Coluna fim relatório"

                    this.grdSimplificado.Sort("PontuacaoTotalResponsabilidadeSocial", SortDirection.Ascending);

                    break;
                case EnumType.Questionario.Inovacao:

                    this.grdSimplificado.Columns[8].Visible = false;     //Coluna Total Pontuação Responsabilidade Social "Coluna inicio relatório"
                    this.grdSimplificado.Columns[9].Visible = true;      //Coluna Total Pontuação Inovação "Coluna inicio relatório"
                    this.grdSimplificado.Columns[15].Visible = true;     //Coluna Total Pontuação Responsabilidade Social "Coluna fim relatório"
                    this.grdSimplificado.Columns[16].Visible = false;    //Coluna Total Pontuação Inovação "Coluna fim relatório"

                    this.grdSimplificado.Sort("PontuacaoTotalInovacao", SortDirection.Ascending);

                    break;
            }
        }

        private void ExibeColunaDetalhe(EnumType.TipoRelatorio TipoRelatorio)
        {
            switch (TipoRelatorio)
            {
                case EnumType.TipoRelatorio.Simplificado:

                    grdSimplificado.Columns[16].Visible =
                    grdSimplificado.Columns[17].Visible =
                    grdSimplificado.Columns[18].Visible =
                    grdSimplificado.Columns[19].Visible =
                    grdSimplificado.Columns[20].Visible =
                    grdSimplificado.Columns[21].Visible =
                    grdSimplificado.Columns[22].Visible = false;


                    TituloBoxSimplificado.Visible = true;
                    TituloBoxDetalhado.Visible = false;

                    break;
                case EnumType.TipoRelatorio.Detalhado:

                    grdSimplificado.Columns[16].Visible =
                    grdSimplificado.Columns[17].Visible =
                    grdSimplificado.Columns[18].Visible =
                    grdSimplificado.Columns[19].Visible =
                    grdSimplificado.Columns[20].Visible =
                    grdSimplificado.Columns[21].Visible =
                    grdSimplificado.Columns[22].Visible = true;

                    TituloBoxSimplificado.Visible = false;
                    TituloBoxDetalhado.Visible = true;

                    break;
            }
        }


    }
}