using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using Vinit.SG.Ent;

namespace Sistema_de_Gestao.MPE.Paginas
{
    public partial class InscricaoAdminCE : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.RegisterStartupScript("LimpaCampos", "<script>function LimpaCampos(){" +
                "   LimpaCombo('" + this.ddlMunicipio.ClientID + "');" +
                "   LimpaCombo('" + this.ddlRegiao.ClientID + "');" +
                "   LimpaCombo('" + this.ddlFaturamento.ClientID + "');" +
                "   LimpaCombo('" + this.ddlTipoEmpresa.ClientID + "');" +
                "   LimpaCombo('" + this.ddlTipoRelatorio.ClientID + "');" +
                "   LimpaCombo('" + this.ddlPremiosEspeciaos.ClientID + "');" +
                "   document.getElementById('" + this.txtNumeroFuncionarios.ClientID + "').value = '';" +
                "   LimpaCombo('" + this.ddlSexo.ClientID + "');" +
                "   LimpaCombo('" + this.ddlNivelEscolaridade.ClientID + "');" +
                "   LimpaCombo('" + this.ddlFaixaEtaria.ClientID + "');" +
                "   document.getElementById('" + this.txtDe.ClientID + "').value = '';" +
                "   document.getElementById('" + this.txtAte.ClientID + "').value = '';" +
                "   document.getElementById('" + this.rd1Sim.ClientID + "').checked = '';" +
                "   document.getElementById('" + this.rd1Nao.ClientID + "').checked = '';" +
                "   document.getElementById('" + this.rd2Sim.ClientID + "').checked = '';" +
                "   document.getElementById('" + this.rd2Nao.ClientID + "').checked = '';" +
                "   document.getElementById('" + this.rd3Sim.ClientID + "').checked = '';" +
                "   document.getElementById('" + this.rd3Nao.ClientID + "').checked = '';" +
                "   document.getElementById('" + this.rd4Sim.ClientID + "').checked = '';" +
                "   document.getElementById('" + this.rd4Nao.ClientID + "').checked = '';" +
                "}</script>");

                this.AtualizaGrid();
                this.PopulaEstado();
                this.PopulaCategoria();
                this.PopulaNivelEscolaridade();
                this.PopulaFaixaEtaria();
                this.PopulaCidade(0);
                this.PopulaEscritorioRegional();
                this.PopulaStatus();
                this.PopulaAno();
                this.PopulaGrupo();
                this.PopulaFaturamento();
                this.PopulaRegiao();
                this.PopulaTipoEmpresa();

                string DivFiltroCompleto = this.filtroCompleto.ClientID;
                string ClientIdimgMais = this.imgMais.ClientID;
                string ClientIdimgMenos = this.imgMenos.ClientID;
                this.Page.RegisterStartupScript("MaisFiltros",
                "<script>" +
                    "function AbrirFiltros(valor) {" +
                       " if (valor == 'block') {" +
                       "     document.getElementById('" + ClientIdimgMais + "').style.display = 'none';" +
                       "     document.getElementById('" + ClientIdimgMenos + "').style.display = 'block';" +
                       "     document.getElementById('" + DivFiltroCompleto + "').style.display = 'block';" +
                       " }" +
                       " if (valor == 'none'){" +
                       "     document.getElementById('" + ClientIdimgMais + "').style.display = 'block';" +
                       "     document.getElementById('" + ClientIdimgMenos + "').style.display = 'none';" +
                       "     document.getElementById('" + DivFiltroCompleto + "').style.display = 'none';" +
                       "     LimpaCampos();" +
                      "  }" +
                    "}" +
                "</script>");
                this.filtroCompleto.Style.Add("display", "none");

            }
        }

        

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void ImgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            this.UCExportarInscritas1.Exportar();
        }

        private void AtualizaGrid()
        {
            this.grdEmpresas.DataSource = ListaGrid;
            this.grdEmpresas.DataBind();
            this.grdEmpresas.SelectedIndex = -1;

            this.UCExportarInscritas1.UCUCConfirmaExportarInscritas1.grdEmpresas.DataSource = ListaGrid;
            this.UCExportarInscritas1.UCUCConfirmaExportarInscritas1.grdEmpresas.DataBind();
            this.UCExportarInscritas1.UCUCConfirmaExportarInscritas1.grdEmpresas.SelectedIndex = -1;
        }

        private void PopulaGridEmpresa(EntTurmaEmpresa objTurmaEmpresa, Int32 nIdEscritorioRegional, Int32 nIdGrupo, String sProtocolo, Int32 nIdEstadoRegiao, Boolean? bPergunta1, Boolean?bPergunta2, Boolean?bPergunta3, Boolean?bPergunta4, DateTime dDataInicio, DateTime dDataFim)
        {
            ListaGrid = new BllTurmaEmpresa().ObterTodasInscritasPorFiltros(objTurmaEmpresa, nIdEscritorioRegional, nIdGrupo, sProtocolo, nIdEstadoRegiao, bPergunta1, bPergunta2, bPergunta3, bPergunta4, dDataInicio, dDataFim);
            this.AtualizaGrid();
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            EntEmpresaCadastro objEmpresaCadastro = new EntEmpresaCadastro();
            EntTurmaEmpresa objTurmaEmpresa = new EntTurmaEmpresa();
            objTurmaEmpresa.EmpresaCadastro = objEmpresaCadastro;
            objEmpresaCadastro.NomeFantasia = this.TxtBxNomePesquisa.Text;
            objEmpresaCadastro.CPF_CNPJ = this.txtCpfCnpj.Text;
            objEmpresaCadastro.Estado.IdEstado = StringUtils.ToInt(this.ddlEstado.SelectedValue);
            objTurmaEmpresa.Categoria.IdCategoria = StringUtils.ToInt(this.ddlCategoria.SelectedValue);
            objTurmaEmpresa.ContatoNivelEscolaridade.IdContatoNivelEscolaridade = StringUtils.ToInt(this.ddlNivelEscolaridade.SelectedValue);
            objTurmaEmpresa.FaixaEtaria.IdContatoFaixaEtaria = StringUtils.ToInt(this.ddlFaixaEtaria.SelectedValue);
            objTurmaEmpresa.Cidade.IdCidade = StringUtils.ToInt(this.ddlMunicipio.SelectedValue);
            Int32 nIdEscritorioRegional = StringUtils.ToInt(this.ddlEscritorioRegional.SelectedValue);
            objTurmaEmpresa.Status = StringUtils.ToInt(this.ddlStatus.SelectedValue);
            objTurmaEmpresa.Turma.IdTurma = StringUtils.ToInt(this.ddlAno.SelectedValue);
            Int32 nIdGrupo = StringUtils.ToInt(this.ddlGrupo.SelectedValue);
            objTurmaEmpresa.Faturamento.IdFaturamento = StringUtils.ToInt(this.ddlFaturamento.SelectedValue);
            Int32 nIdEstadoRegiao = StringUtils.ToInt(this.ddlRegiao.SelectedValue);
            objTurmaEmpresa.SexoContato = this.ddlSexo.SelectedValue == "0" ? "" : this.ddlSexo.SelectedValue;
            
            Boolean? bPergunta1 = null;
            if (this.rd1Sim.Checked || this.rd1Nao.Checked)
                bPergunta1 = this.rd1Sim.Checked;
            Boolean? bPergunta2 = null;
            if (this.rd2Sim.Checked || this.rd2Nao.Checked)
                bPergunta2 = this.rd2Sim.Checked;
            Boolean? bPergunta3 = null;
            if (this.rd3Sim.Checked || this.rd3Nao.Checked)
                bPergunta3 = this.rd3Sim.Checked;
            Boolean? bPergunta4 = null;
            if (this.rd4Sim.Checked || this.rd4Nao.Checked)
                bPergunta4 = this.rd4Sim.Checked;

            DateTime dDataInicio = new DateTime(1753, 1, 1);
            if (this.txtDe.Text.Length > 0)
                dDataInicio = StringUtils.ToDate(this.txtDe.Text);
            DateTime dDataFim = DateTime.Now;
            if (this.txtAte.Text.Length > 0)
                dDataFim = StringUtils.ToDate(this.txtAte.Text);
            
            objTurmaEmpresa.NumeroFuncionario = StringUtils.ToInt(this.txtNumeroFuncionarios.Text);
            objTurmaEmpresa.TipoEmpresa.IdTipoEmpresa = StringUtils.ToInt(this.ddlTipoEmpresa.SelectedValue);
            String sProtocolo = this.txtProtocolo.Text;
            
            this.PopulaGridEmpresa(objTurmaEmpresa, nIdEscritorioRegional, nIdGrupo, sProtocolo, nIdEstadoRegiao, bPergunta1, bPergunta2, bPergunta3, bPergunta4, dDataInicio, dDataFim);
        }

        protected void grdEmpresas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEmpresas.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        protected void grdEmpresas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataKey dk = this.grdEmpresas.DataKeys[e.RowIndex];
            this.grdEmpresas.SelectedIndex = -1;
            //this.UCCadastroGrupoAcessoIA1.Editar(ObjectUtils.ToInt(dk.Value));
        }

        private void PopulaEstado()
        {
            this.ddlEstado.Items.Clear();
            this.ddlEstado.DataSource = new BllEstado().ObterTodos();
            this.ddlEstado.DataBind();
            this.ddlEstado.Items.Add(new ListItem("Todos", "0"));
            this.ddlEstado.SelectedValue = "0";
        }

        private void PopulaCategoria()
        {
            this.ddlCategoria.Items.Clear();
            this.ddlCategoria.DataSource = new BllCategoria().ObterTodos();
            this.ddlCategoria.DataBind();
            this.ddlCategoria.Items.Add(new ListItem("Todos", "0"));
            this.ddlCategoria.SelectedValue = "0";
        }

        private void PopulaNivelEscolaridade()
        {
            this.ddlNivelEscolaridade.Items.Clear();
            this.ddlNivelEscolaridade.DataSource = new BllContatoNivelEscolaridade().ObterTodos();
            this.ddlNivelEscolaridade.DataBind();
            this.ddlNivelEscolaridade.Items.Add(new ListItem("Todos", "0"));
            this.ddlNivelEscolaridade.SelectedValue = "0";
        }

        private void PopulaFaixaEtaria()
        {
            this.ddlFaixaEtaria.Items.Clear();
            this.ddlFaixaEtaria.DataSource = new BllContatoFaixaEtaria().ObterTodos();
            this.ddlFaixaEtaria.DataBind();
            this.ddlFaixaEtaria.Items.Add(new ListItem("Todos", "0"));
            this.ddlFaixaEtaria.SelectedValue = "0";
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaCidade(StringUtils.ToInt(this.ddlEstado.SelectedValue));
        }

        private void PopulaCidade(Int32 IdEstado)
        {
            this.ddlMunicipio.Items.Clear();
            this.ddlMunicipio.DataSource = new BllCidade().ObterCidadePorEstado(IdEstado);
            this.ddlMunicipio.DataBind();
            this.ddlMunicipio.Items.Add(new ListItem("Todos", "0"));
            this.ddlMunicipio.SelectedValue = "0";
        }

        private void PopulaEscritorioRegional()
        {
            this.ddlEscritorioRegional.Items.Clear();
            this.ddlEscritorioRegional.DataSource = new BllEscritorioRegional().ObterTodosAtivos();
            this.ddlEscritorioRegional.DataBind();
            this.ddlEscritorioRegional.Items.Add(new ListItem("Todos", "0"));
            this.ddlEscritorioRegional.SelectedValue = "0";
        }

        private void PopulaStatus()
        {
            ddlStatus.Items.Clear();
            ListItem item;

            //Insere Item Inscritas
            item = new ListItem();
            item.Text = EnumType.Status.Inscrita.ToString();
            item.Value = IntUtils.ToString((int)EnumType.Status.Inscrita);
            ddlStatus.Items.Add(item);

            //Insere Item Candidata
            item = new ListItem();
            item.Text = EnumType.Status.Candidata.ToString();
            item.Value = IntUtils.ToString((int)EnumType.Status.Candidata);
            ddlStatus.Items.Add(item);

            //Insere Item Classificada
            item = new ListItem();
            item.Text = EnumType.Status.Classificada.ToString();
            item.Value = IntUtils.ToString((int)EnumType.Status.Classificada);
            ddlStatus.Items.Add(item);

            //Insere Item Finalista
            item = new ListItem();
            item.Text = EnumType.Status.Finalista.ToString();
            item.Value = IntUtils.ToString((int)EnumType.Status.Finalista);
            ddlStatus.Items.Add(item);

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "Todos";
            item.Value = "0";
            item.Selected = true;
            ddlStatus.Items.Add(item);
        }

        private void PopulaAno()
        {
            this.ddlAno.Items.Clear();
            this.ddlAno.DataSource = new BllTurma().ObterPorIdPrograma((int)EnumType.Programa.MPE);
            this.ddlAno.DataBind();
            this.ddlAno.Items.Add(new ListItem("Todos", "0"));
            this.ddlAno.SelectedValue = "0";
        }

        private void PopulaGrupo()
        {
            this.ddlGrupo.Items.Clear();
            this.ddlGrupo.DataSource = new BllGrupo().ObterTodosAtivos();
            this.ddlGrupo.DataBind();
            this.ddlGrupo.Items.Add(new ListItem("Todos", "0"));
            this.ddlGrupo.SelectedValue = "0";
        }

        private void PopulaRegiao()
        {
            this.ddlRegiao.Items.Clear();
            this.ddlRegiao.DataSource = new BllEstadoRegiao().ObterTodos();
            this.ddlRegiao.DataBind();
            this.ddlRegiao.Items.Add(new ListItem("Todos", "0"));
            this.ddlRegiao.SelectedValue = "0";
        }

        private void PopulaFaturamento()
        {
            this.ddlFaturamento.Items.Clear();
            this.ddlFaturamento.DataSource = new BllFaturamento().ObterTodos();
            this.ddlFaturamento.DataBind();
            this.ddlFaturamento.Items.Add(new ListItem("Todos", "0"));
            this.ddlFaturamento.SelectedValue = "0";
        }

        private void PopulaTipoEmpresa()
        {
            this.ddlTipoEmpresa.Items.Clear();
            this.ddlTipoEmpresa.DataSource = new BllTipoEmpresa().ObterTodos();
            this.ddlTipoEmpresa.DataBind();
            this.ddlTipoEmpresa.Items.Add(new ListItem("Todos", "0"));
            this.ddlTipoEmpresa.SelectedValue = "0";
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCInscricaoEmpresaIA1.Incluir();
        }


    }
}