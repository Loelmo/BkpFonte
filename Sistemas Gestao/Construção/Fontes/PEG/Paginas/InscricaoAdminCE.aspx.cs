using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PEG.Pagina_Base;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using Vinit.SG.Ent;
using PEG.Utilitarios;

namespace PEG.Paginas
{
    public partial class InscricaoAdminCE : PaginaBase
    {


        protected void Page_Init(object sender, EventArgs e)
        {
            if (ValidaPermissaoBotao(this, EnumType.TipoAcao.Atualizar))
            {
                this.grdEmpresas.Columns[6].HeaderText = "Alterar";
            }
            else
            {
                this.grdEmpresas.Columns[6].HeaderText = "Visualizar";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.RegisterStartupScript("LimpaCampos", "<script>function LimpaCampos(){" +
                "   LimpaCombo('" + this.ddlFaturamento.ClientID + "');" +
                "   LimpaCombo('" + this.ddlTipoEmpresa.ClientID + "');" +
                "   document.getElementById('" + this.txtNumeroFuncionarios.ClientID + "').value = '';" +
                "   LimpaCombo('" + this.ddlSexo.ClientID + "');" +
                "   LimpaCombo('" + this.ddlNivelEscolaridade.ClientID + "');" +
                "   LimpaCombo('" + this.ddlFaixaEtaria.ClientID + "');" +
                "   document.getElementById('" + this.txtDe.ClientID + "').value = '';" +
                "   document.getElementById('" + this.txtAte.ClientID + "').value = '';" +
                "}</script>");

                WebUtils.PopulaDropDownList(this.ddlFaturamento, EnumType.TipoDropDownList.Faturamento, "Todos");

                this.PopulaCategoria();
                this.PopulaNivelEscolaridade();
                this.PopulaFaixaEtaria();
                this.PopulaStatus();
                this.PopulaTipoEmpresa();
                //  this.Pesquisar();
                //string DivFiltroCompleto = this.filtroCompleto.ClientID;
                //string ClientIdimgMais = this.imgMais.ClientID;
                //string ClientIdimgMenos = this.imgMenos.ClientID;
                //this.Page.RegisterStartupScript("MaisFiltros",
                //"<script>" +
                //    "function AbrirFiltros(valor) {" +
                //       " if (valor == 'block') {" +
                //       "     document.getElementById('" + ClientIdimgMais + "').style.display = 'none';" +
                //       "     document.getElementById('" + ClientIdimgMenos + "').style.display = 'block';" +
                //       "     document.getElementById('" + DivFiltroCompleto + "').style.display = 'block';" +
                //       " }" +
                //       " if (valor == 'none'){" +
                //       "     document.getElementById('" + ClientIdimgMais + "').style.display = 'block';" +
                //       "     document.getElementById('" + ClientIdimgMenos + "').style.display = 'none';" +
                //       "     document.getElementById('" + DivFiltroCompleto + "').style.display = 'none';" +
                //       "     LimpaCampos();" +
                //      "  }" +
                //    "}" +
                //"</script>");
                //this.filtroCompleto.Style.Add("display", "none");

                if (this.objPrograma.IdPrograma == EntPrograma.PROGRAMA_FGA || this.objPrograma.IdPrograma == EntPrograma.PROGRAMA_PEG)
                {
                    this.Label25.Text = "Turma:";
                    this.grdEmpresas.Columns[6].Visible = false;
                    this.grdEmpresas.Columns[7].Visible = false;
                    this.grdEmpresas.Columns[8].Visible = false;
                    this.grdEmpresas.Columns[9].Visible = false;
                    this.grdEmpresas.Columns[10].Visible = false;
                    this.grdEmpresas.Columns[11].Visible = false;
                }
                else
                {
                    this.Label25.Text = "Ano:";
                }

                this.ImgBttnIncluir.Visible = ValidaPermissaoBotao(this, EnumType.TipoAcao.Inserir);
            }

            this.UCInscricaoEmpresaIA1.atualizaGrid += this.Pesquisar;
            this.UCEstado1.WidthCampo = 100;

            String Url = "WindowOpen('Etiqueta.aspx');";
            ImgBttnEmitirEtiqueta.OnClientClick = Url;
        }



        //public override void VerifyRenderingInServerForm(Control control)
        //{

        //}

        protected void ImgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            this.UCExportarInscritas1.Exportar();
        }

        private void AtualizaGrid()
        {
            this.grdEmpresas.DataSource = ListaGrid;
            this.grdEmpresas.DataBind();
            this.grdEmpresas.SelectedIndex = -1;

            this.UCExportarInscritas1.UCUCConfirmaExportarInscritas1.grdEmpresasExport.DataSource = ListaGrid;
            this.UCExportarInscritas1.UCUCConfirmaExportarInscritas1.grdEmpresasExport.DataBind();
            this.UCExportarInscritas1.UCUCConfirmaExportarInscritas1.grdEmpresasExport.SelectedIndex = -1;

            ImgBttnEmitirEtiqueta.Visible = (grdEmpresas.Rows.Count > 0 ? true : false);
            ImgBttnExportar.Visible = (grdEmpresas.Rows.Count > 0 ? true : false);
        }

        private void PopulaGridEmpresa(EntTurmaEmpresa objTurmaEmpresa, EntGrupo objGrupo, String sProtocolo, DateTime dDataInicio, DateTime dDataFim)
        {
            ListaGrid = new BllTurmaEmpresa().ObterTodasInscritasPorFiltros(objTurmaEmpresa, objGrupo, sProtocolo, dDataInicio, dDataFim, EntTipoEtapa.TIPO_ETAPA_PEG_INSCRICAO_AUTODIAGNOSTICO_ADMINISTRATIVO);
            ListaGridEtiqueta = ListaGrid;
            ListaGrid = ListaGrid;
            this.AtualizaGrid();
        }

        private void Pesquisar()
        {
            EntTurmaEmpresa objTurmaEmpresa = new EntTurmaEmpresa();
            EntGrupo objGrupo = new EntGrupo();

            objGrupo.IdGrupo = UCEstado1.IdGrupo;
            String sProtocolo = this.txtProtocolo.Text;

            objTurmaEmpresa.Turma.IdTurma = UCEstado1.IdTurma;
            objTurmaEmpresa.Estado.IdEstado = UCEstado1.IdEstado;
            objTurmaEmpresa.Cidade.EscritorioRegional.IdEscritorioRegional = UCEstado1.IdEscritorioRegional;
            objTurmaEmpresa.Cidade.EstadoRegiao.IdEstadoRegiao = UCEstado1.IdRegiao;
            objTurmaEmpresa.Cidade.IdCidade = UCEstado1.IdCidade;
            objTurmaEmpresa.Faturamento.IdFaturamento = StringUtils.ToInt(this.ddlFaturamento.SelectedValue);
            objTurmaEmpresa.NumeroFuncionario = StringUtils.ToInt(this.txtNumeroFuncionarios.Text);
            objTurmaEmpresa.ContatoNivelEscolaridade.IdContatoNivelEscolaridade = StringUtils.ToInt(this.ddlNivelEscolaridade.SelectedValue);
            objTurmaEmpresa.FaixaEtaria.IdContatoFaixaEtaria = StringUtils.ToInt(this.ddlFaixaEtaria.SelectedValue);
            objTurmaEmpresa.EmpresaCadastro.NomeFantasia = this.TxtBxNomePesquisa.Text;
            objTurmaEmpresa.EmpresaCadastro.RazaoSocial = this.TxtBxRazaoSocial.Text;
            objTurmaEmpresa.EmpresaCadastro.CPF_CNPJ = StringUtils.OnlyNumbers(this.txtCpfCnpj.Text);
            objTurmaEmpresa.Status = StringUtils.ToInt(this.ddlStatus.SelectedValue);
            objTurmaEmpresa.Categoria.IdCategoria = StringUtils.ToInt(this.ddlCategoria.SelectedValue);
            objTurmaEmpresa.TipoEmpresa.IdTipoEmpresa = StringUtils.ToInt(this.ddlTipoEmpresa.SelectedValue);
            objTurmaEmpresa.ParticipaPrograma = true;

            //Premios
            objTurmaEmpresa.SexoContato = this.ddlSexo.SelectedValue == "0" ? "" : this.ddlSexo.SelectedValue;
            DateTime dDataInicio = StringUtils.ToDate(this.txtDe.Text);
            DateTime dDataFim = StringUtils.ToDate(this.txtAte.Text);



            this.PopulaGridEmpresa(objTurmaEmpresa, objGrupo, sProtocolo, dDataInicio, dDataFim);
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.Pesquisar();
        }

        protected void grdEmpresas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEmpresas.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        protected void grdEmpresas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int IdEmpresaCadastro = StringUtils.ToInt(((Label)this.grdEmpresas.Rows[e.RowIndex].FindControl("lblIdEmpresaCadastro")).Text);
            this.grdEmpresas.SelectedIndex = -1;
            this.UCInscricaoEmpresaIA1.Editar(IdEmpresaCadastro, UCEstado1.IdTurma);
        }

        protected void grdEmpresas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Boolean PermissaoExcluir = ValidaPermissaoBotao(this, EnumType.TipoAcao.Excluir);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnParticipaPrograma = ((ImageButton)e.Row.FindControl("ImagBttnParticipaPrograma"));
                ImageButton ImagBttnEditar = ((ImageButton)e.Row.FindControl("ImagBttnEditar"));
                ImageButton ImagBttnQuestionario = ((ImageButton)e.Row.FindControl("ImagBttnQuestionario"));

                String imageUrl;
                Label lblParticipaProgramaAux = (Label)e.Row.FindControl("LblParticipaPrograma");
                Label lblEtapaAtiva = (Label)e.Row.FindControl("lblFlEtapaAtiva");

                if (lblParticipaProgramaAux.Text == "True")
                {
                    imageUrl = "~/Image/_file_Ok2.png";
                }
                else
                {
                    imageUrl = "~/Image/file_delete2.png";
                }

                if (lblEtapaAtiva.Text == "True")
                {
                    HabilitaDesabilitaBotao(ImagBttnEditar, true);
                    HabilitaDesabilitaBotao(ImagBttnQuestionario, true);
                    ImagBttnEditar.ImageUrl = "~/Image/file_edit2.png";
                    ImagBttnEditar.Style.Add("cursor", "pointer");
                    ImagBttnQuestionario.ImageUrl = "~/Image/_file_resume2.png";
                    ImagBttnQuestionario.Style.Add("cursor", "pointer");
                }
                else
                {
                    HabilitaDesabilitaBotao(ImagBttnEditar, false);
                    HabilitaDesabilitaBotao(ImagBttnQuestionario, false);
                    ImagBttnEditar.ImageUrl = "~/Image/file_edit2_disabled.png";
                    ImagBttnEditar.Style.Add("cursor", "default");
                    ImagBttnQuestionario.ImageUrl = "~/Image/_file_resume2_disabled.png";
                    ImagBttnQuestionario.Style.Add("cursor", "default");
                }

                btnParticipaPrograma.ImageUrl = imageUrl;
                HabilitaDesabilitaBotao(btnParticipaPrograma, PermissaoExcluir);
            }
        }

        protected void grdEmpresas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ImageButton btnParticipaPrograma = ((ImageButton)grdEmpresas.Rows[e.RowIndex].FindControl("ImagBttnParticipaPrograma"));
            String imageUrl;
            Label lblParticipaProgramaAux = (Label)grdEmpresas.Rows[e.RowIndex].FindControl("LblParticipaPrograma");

            try
            {
                EntTurmaEmpresa objTurmaEmpresa = new EntTurmaEmpresa();
                objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro = StringUtils.ToInt(((Label)this.grdEmpresas.Rows[e.RowIndex].FindControl("lblIdEmpresaCadastro")).Text);
                objTurmaEmpresa.Turma.IdTurma = StringUtils.ToInt(((Label)this.grdEmpresas.Rows[e.RowIndex].FindControl("lblIdTurma")).Text);

                if (lblParticipaProgramaAux.Text == "True")
                {
                    imageUrl = "~/Image/file_delete2.png";
                    lblParticipaProgramaAux.Text = "False";
                    btnParticipaPrograma.ImageUrl = imageUrl;
                    objTurmaEmpresa.ParticipaPrograma = false;
                }
                else
                {
                    imageUrl = "~/Image/_file_Ok2.png";
                    lblParticipaProgramaAux.Text = "True";
                    btnParticipaPrograma.ImageUrl = imageUrl;
                    objTurmaEmpresa.ParticipaPrograma = true;
                }
                new BllInscricoesEmpresa().ParticiparPrograma(objTurmaEmpresa);
                MessageBox(this.Page, "Empresa Alterada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar alterar Etapa!");
                //logger.Error("Erro ao inserir o EntUsuario!", ex);
            }

        }

        private void PopulaCategoria()
        {
            this.ddlCategoria.Items.Clear();
            this.ddlCategoria.DataSource = new BllCategoria().ObterTodos(false);
            this.ddlCategoria.DataBind();
            this.ddlCategoria.Items.Insert(0, new ListItem("Todos", "0"));
            this.ddlCategoria.SelectedValue = "0";
        }

        private void PopulaNivelEscolaridade()
        {
            this.ddlNivelEscolaridade.Items.Clear();
            this.ddlNivelEscolaridade.DataSource = new BllContatoNivelEscolaridade().ObterTodos();
            this.ddlNivelEscolaridade.DataBind();
            this.ddlNivelEscolaridade.Items.Insert(0, new ListItem("Todos", "0"));
            this.ddlNivelEscolaridade.SelectedValue = "0";
        }

        private void PopulaFaixaEtaria()
        {
            this.ddlFaixaEtaria.Items.Clear();
            this.ddlFaixaEtaria.DataSource = new BllContatoFaixaEtaria().ObterTodos();
            this.ddlFaixaEtaria.DataBind();
            this.ddlFaixaEtaria.Items.Insert(0, new ListItem("Todos", "0"));
            this.ddlFaixaEtaria.SelectedValue = "0";
        }

        private void PopulaStatus()
        {
            ddlStatus.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "Todos";
            item.Value = "0";
            item.Selected = true;
            ddlStatus.Items.Insert(0, item);

            //Insere Item Inscritas
            item = new ListItem();
            item.Text = EnumType.Status.Inscrita.ToString();
            item.Value = "0";
            ddlStatus.Items.Add(item);

            //Insere Item Candidata
            item = new ListItem();
            item.Text = EnumType.Status.Candidata.ToString();
            item.Value = EntTipoEtapa.TIPO_ETAPA_PEG_VALIDACAO_RESPOSTAS.ToString();
            ddlStatus.Items.Add(item);

            //Insere Item Classificada
            item = new ListItem();
            item.Text = "Pré-Classificada";
            item.Value = EntTipoEtapa.TIPO_ETAPA_PEG_PRE_CLASSIFICADAS.ToString();
            ddlStatus.Items.Add(item);

            //Insere Item Finalista
            item = new ListItem();
            item.Text = "Fase 2";
            item.Value = EntTipoEtapa.TIPO_ETAPA_PEG_FASE_2.ToString();
            ddlStatus.Items.Add(item);

            //Insere Item Finalista
            item = new ListItem();
            item.Text = "Fase 3";
            item.Value = EntTipoEtapa.TIPO_ETAPA_PEG_FASE_3.ToString();
            ddlStatus.Items.Add(item);

            //Insere Item Finalista
            item = new ListItem();
            item.Text = "Fase 4";
            item.Value = EntTipoEtapa.TIPO_ETAPA_PEG_FASE_4.ToString();
            ddlStatus.Items.Add(item);
        }

        private void PopulaTipoEmpresa()
        {
            this.ddlTipoEmpresa.Items.Clear();
            this.ddlTipoEmpresa.DataSource = new BllTipoEmpresa().ObterTodos();
            this.ddlTipoEmpresa.DataBind();
            this.ddlTipoEmpresa.Items.Insert(0, new ListItem("Todos", "0"));
            this.ddlTipoEmpresa.SelectedValue = "0";
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCInscricaoEmpresaIA1.Incluir();
        }

        protected void ImgBttnMais_Click(object sender, ImageClickEventArgs e)
        {
            this.ImgBttnMais.Visible = false;
            this.ImgBttnMenos.Visible = true;
            this.filtroCompleto.Visible = true;
        }

        protected void ImgBttnMenos_Click(object sender, ImageClickEventArgs e)
        {
            this.ImgBttnMais.Visible = true;
            this.ImgBttnMenos.Visible = false;
            this.filtroCompleto.Visible = false;
        }

        protected void grdEmpresas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Questionario")
            {
                int IdEmpresaCadastro = int.Parse(e.CommandArgument.ToString());
                int IdTurma = UCEstado1.IdTurma;
                this.UCListaQuestionariosDigitador1.Editar(IdEmpresaCadastro, IdTurma);
            }
            else if (e.CommandName == "ResumoRAA")
            {
                int RowIndex = ObjectUtils.ToInt(e.CommandArgument) - (grdEmpresas.PageIndex * grdEmpresas.PageSize);

                Label lblIdEmpresaCadastro = (Label)grdEmpresas.Rows[RowIndex].FindControl("lblIdEmpresaCadastro");
                Label lblIdTurma = (Label)grdEmpresas.Rows[RowIndex].FindControl("lblIdTurma");
                String sCnpj = ((DataBoundLiteralControl)grdEmpresas.Rows[RowIndex].Cells[5].Controls[0]).Text;
                String sRazaoSocial = ((DataBoundLiteralControl)grdEmpresas.Rows[RowIndex].Cells[2].Controls[0]).Text;
                this.UCHistoricoRAA1.Show(StringUtils.ToInt(lblIdEmpresaCadastro.Text), StringUtils.ToInt(lblIdTurma.Text), sCnpj, sRazaoSocial);
            }
        }

        public GridView GetGrid()
        {
            return grdEmpresas;
        }
    }
}