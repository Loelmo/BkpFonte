using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestao.User_Controls;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using System.Web.UI.HtmlControls;
using Sistema_de_Gestao.Pagina_Base;
using System.Text;
using Sistema_de_Gestao.Utilitarios;
using Sistema_de_Gestao.SiacWebCadastroAtendimentoWS.ws;
using AjaxControlToolkit;
using Sistema_de_Gestão_de_Treinamento.User_Control;

namespace Sistema_de_Gestao.User_Control
{
    public partial class UCInscricaoEmpresaIA : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        private Boolean ImportacaoOutrosProgramas;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.PopulaEstadoContato();
                this.PopulaTipoEmpresa();
                this.PopulaCategoria(false);
                this.PopulaNivelEscolaridade();
                this.PopulaCargo();
                this.PopulaTurma();
                this.PopulaCidade(0);
                this.PopulaBairro(0);
                this.PopulaCidadeContato(0);
                this.PopulaBairroContato(0);
                this.PopulaFaturamento(4);
                HabilitaCampos(false);
            }
          //  this.UCEstado1.populaEstadoContato += this.PopulaEstadoContato;
            this.UCSelecionaCNAE1.atualizaCampo += this.PopulaAtividadeEconomica;
        }

        private void PopulaTurma()
        {
            CmbBxTurma.Items.Clear();
            this.CmbBxTurma.DataSource = UsuarioLogado.lstTurmasPermitidas.FindAll(delegate(EntTurmasPermitidas objTurmasPermitidas) { return objTurmasPermitidas.Funcionalidade == this.Page.Title.ToString(); });
            this.CmbBxTurma.DataBind();
            this.PopulaEstado(StringUtils.ToInt(this.CmbBxTurma.SelectedValue), this.Page.Title.ToString());
        }

        private void PopulaEstado(Int32 IdTurma, String sFuncionalidade)
        {
            this.CmbBxEstado.Items.Clear();

            List<EntEstadosPermitidos> lstEstadosPermitidos1 = UsuarioLogado.lstEstadoPermitidos.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.IdTurma == IdTurma; });
            List<EntEstado> lstEstados = new List<EntEstado>();

            lstEstadosPermitidos1 = lstEstadosPermitidos1.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.Funcionalidade == sFuncionalidade; });
            lstEstadosPermitidos1.Insert(0, new EntEstadosPermitidos(0, "<< Selecione o Estado >>"));
            this.CmbBxEstado.DataSource = lstEstadosPermitidos1;

            if (lstEstadosPermitidos1.Count == 0)
            {
                lstEstados = new BllEstado().ObterEstadosPorTurma(IdTurma, EntTipoEtapa.TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_ADMINISTRATIVO);
                lstEstados.Insert(0, new EntEstado(0, "<< Selecione o Estado >>"));
                this.CmbBxEstado.DataSource = lstEstados;
            }

            this.CmbBxEstado.DataBind();
        }

        private void PopulaEstado()
        {
            CmbBxEstado.Items.Clear();
            Int32 IdTipoEtapa = EntTipoEtapa.TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_ADMINISTRATIVO;
            this.CmbBxEstado.DataSource = new BllEstado().ObterEstadosPorTurma(int.Parse(CmbBxTurma.SelectedValue), IdTipoEtapa);
            this.CmbBxEstado.DataBind();
            this.CmbBxEstado.Items.Insert(0, new ListItem("Todos", "0"));
            this.CmbBxEstado.SelectedValue = "0";
        }

        private void PopulaEstadoContato()
        {
            CmbBxEstadoContato.Items.Clear();
            this.CmbBxEstadoContato.DataSource = new BllEstado().ObterTodos();
            this.CmbBxEstadoContato.DataBind();
            this.CmbBxEstadoContato.Items.Insert(0, new ListItem("Todos", "0"));
            this.CmbBxEstadoContato.SelectedValue = "0";
        }

        private void Show()
        {
            this.divUserControl.Visible = true;

            if (!ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar))
            {
                EnableControl(this.PnlFundo.Controls, false);
                this.ImgBttnConfirma.Visible = false;
            }
            else
            {
                EnableControl(this.PnlFundo.Controls, true);
                this.ImgBttnConfirma.Visible = true;
            }
        }

        private void Close()
        {
            this.Clear();
            this.divUserControl.Visible = false;
        }

        private void Clear()
        {
            this.TxtBxCNPJCPF.Text = String.Empty;
            this.TxtBxRazaoSocial.Text = String.Empty;
            this.TxtBxNomeFantasia.Text = String.Empty;
            this.TxtBxDataAbertura.Text = String.Empty;
            this.TxtBxNumeroEmpregados.Text = String.Empty;
            this.TxtBxEndereco.Text = String.Empty;
            this.TxtBxCEP.Text = String.Empty;
            this.CmbBxTipoEmpresa.SelectedIndex = 0;
            this.CmbBxCategoria.SelectedIndex = 0;
            this.CmbBxFaturamento.SelectedIndex = 0;
            this.CmbBxTurma.SelectedIndex = 0;
            this.TxtBoxAtividadeEconomica.Text = String.Empty;
            this.HddnIdAtividadeEconomica.Value = String.Empty;
            this.TxtBxPrincipalAtividade.Text = String.Empty;
            this.TxtBxNomeCompleto.Text = String.Empty;
            this.TxtBxCelular.Text = String.Empty;
            this.TxtBxCPF.Text = String.Empty;
            this.TxtBxEmail.Text = String.Empty;
            this.CmbBxCargo.SelectedIndex = 0;
            this.TxtBxDtNascimento.Text = String.Empty;
            this.CmbBxEstadoContato.SelectedIndex = 0;
            this.CmbBxEstado.SelectedIndex = 0;
            this.RdBttnLstSexo.SelectedIndex = -1;
            this.CmbBxCidade.SelectedIndex = 0;
            this.CmbBxCidadeContato.SelectedIndex = 0;
            this.CmbBxNivelEscolaridade.SelectedIndex = 0;
            this.CmbBxBairro.SelectedIndex = 0;
            this.CmbBxBairroContato.SelectedIndex = 0;
            this.TxtBxEnderecoCompleto.Text = String.Empty;
            this.TxtBxCEPContato.Text = String.Empty;
            this.TxtBxTelefoneFixo.Text = String.Empty;
            this.RdBttnLstPergunta1.SelectedIndex = -1;
            this.RdBttnLstPergunta2.SelectedIndex = -1;
            this.RdBttnLstPergunta3.SelectedIndex = -1;
            this.RdBttnLstPergunta4.SelectedIndex = -1;

        }

        public void Editar(Int32 IdEmpresaCadastro, Int32 IdTurma)
        {
            this.HddnFldEmpresaCadastro.Value = IntUtils.ToString(IdEmpresaCadastro);
            this.ImportacaoOutrosProgramas = false;
            EntTurmaEmpresa turmaEmpresa = new EntTurmaEmpresa();
            turmaEmpresa.EmpresaCadastro.IdEmpresaCadastro = IdEmpresaCadastro;
            turmaEmpresa.Turma.IdTurma = IdTurma;
            EntInscricoesEmpresa objInscricoesEmpresa = new BllInscricoesEmpresa().ObterPorIdEmpresaTurma(turmaEmpresa, objPrograma.IdPrograma);
            if (objInscricoesEmpresa == null)
            {
                objInscricoesEmpresa = new BllInscricoesEmpresa().ObterPorIdEmpresaPrograma(IdEmpresaCadastro, objPrograma.IdPrograma);
            }
            this.ObjectToPage(objInscricoesEmpresa, ImportacaoOutrosProgramas);
            this.HddnFldTurma.Value = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma);
            this.TxtBxCNPJCPF.Enabled = false;
            HabilitaCampos(true);
            this.CmbBxTurma.Enabled = false;
            divSenha.Visible = false;
            this.CmbBxEstado.Focus();
            this.Show();
        }

        public void Incluir()
        {
            this.HddnFldEmpresaCadastro.Value = "0";
            this.TxtBxCNPJCPF.Text = String.Empty;
            this.TxtBxCNPJCPF.Enabled = true;
            this.HabilitaCampos(false);
            this.Show();
            this.TxtBxCNPJCPF.Focus();
            this.ImgBttnConfirma.Visible = false;
            this.CmbBxTurma.Enabled = true;
            this.PopulaEstadoContato();
            this.CmbBxTurma.Focus();
            divSenha.Visible = true;
        }

        private void PopulaTipoEmpresa()
        {
            CmbBxTipoEmpresa.Items.Clear();

            this.CmbBxTipoEmpresa.DataSource = new BllTipoEmpresa().ObterTodos();
            this.CmbBxTipoEmpresa.DataBind();
            this.CmbBxTipoEmpresa.Items.Insert(0, new ListItem("Todos", "0"));
            this.CmbBxTipoEmpresa.SelectedValue = "0";
        }

        private void PopulaCidade(Int32 IdEstado)
        {
            CmbBxCidade.Items.Clear();

            this.CmbBxCidade.DataSource = new BllCidade().ObterCidadePorEstado2(IdEstado);
            this.CmbBxCidade.DataBind();
            this.CmbBxCidade.Items.Insert(0, new ListItem("Todos", "0"));
            this.CmbBxCidade.SelectedValue = "0";
        }

        private void PopulaCidadeContato(Int32 IdEstado)
        {
            CmbBxCidadeContato.Items.Clear();

            this.CmbBxCidadeContato.DataSource = new BllCidade().ObterCidadePorEstado2(IdEstado);
            this.CmbBxCidadeContato.DataBind();
            this.CmbBxCidadeContato.Items.Insert(0, new ListItem("Todos", "0"));
            this.CmbBxCidadeContato.SelectedValue = "0";
        }

        private void PopulaBairro(Int32 IdCidade)
        {
            CmbBxBairro.Items.Clear();

            this.CmbBxBairro.DataSource = new BllBairro().ObterPorCidade(IdCidade);
            this.CmbBxBairro.DataBind();
            this.CmbBxBairro.Items.Insert(0, new ListItem("Todos", "0"));
            this.CmbBxBairro.SelectedValue = "0";
        }

        private void PopulaBairroContato(Int32 IdCidade)
        {
            CmbBxBairroContato.Items.Clear();

            this.CmbBxBairroContato.DataSource = new BllBairro().ObterPorCidade(IdCidade);
            this.CmbBxBairroContato.DataBind();
            this.CmbBxBairroContato.Items.Insert(0, new ListItem("Todos", "0"));
            this.CmbBxBairroContato.SelectedValue = "0";
        }

        private void PopulaCategoria(Boolean isCpf)
        {
            CmbBxCategoria.Items.Clear();

            this.CmbBxCategoria.DataSource = new BllCategoria().ObterTodos(isCpf);
            this.CmbBxCategoria.DataBind();
            this.CmbBxCategoria.Items.Insert(0, new ListItem("Todos", "0"));
            this.CmbBxCategoria.SelectedValue = "0";
        }

        private void PopulaNivelEscolaridade()
        {
            CmbBxNivelEscolaridade.Items.Clear();

            this.CmbBxNivelEscolaridade.DataSource = new BllContatoNivelEscolaridade().ObterTodos();
            this.CmbBxNivelEscolaridade.DataBind();
            this.CmbBxNivelEscolaridade.Items.Insert(0, new ListItem("Todos", "0"));
            this.CmbBxNivelEscolaridade.SelectedValue = "0";
        }

        private void PopulaCargo()
        {
            CmbBxCargo.Items.Clear();

            this.CmbBxCargo.DataSource = new BllCargo().ObterTodos();
            this.CmbBxCargo.DataBind();
            this.CmbBxCargo.Items.Insert(0, new ListItem("Todos", "0"));
            this.CmbBxCargo.SelectedValue = "0";
        }

        private void PopulaAtividadeEconomica(EntAtividadeEconomica objAtividadeEconomica)
        {
            String campo = "";
            if (objAtividadeEconomica.Codigo > 0)
            {
                campo = campo + objAtividadeEconomica.Codigo + " - ";
            }
            this.TxtBoxAtividadeEconomica.Text = campo + objAtividadeEconomica.AtividadeEconomica;
            this.TxtBoxAtividadeEconomica.ToolTip = campo + objAtividadeEconomica.AtividadeEconomica;
            this.HddnIdAtividadeEconomica.Value = IntUtils.ToString(objAtividadeEconomica.IdAtividadeEconomica);
        }

        private void PopulaFaturamento(Int32 IdTipoFaturamento)
        {
            CmbBxFaturamento.Items.Clear();

            this.CmbBxFaturamento.DataSource = new BllFaturamento().ObterPorIdTipoFaturamento(IdTipoFaturamento);
            this.CmbBxFaturamento.DataBind();
            this.CmbBxFaturamento.Items.Insert(0, new ListItem("Todos", "0"));
            this.CmbBxFaturamento.SelectedValue = "0";
        }

        protected void DrpDwnLstTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaEstado(StringUtils.ToInt(this.CmbBxTurma.SelectedValue), this.Page.Title);

            this.CmbBxEstado.Focus();
        }

        protected void DrpDwnLstEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaCidade(StringUtils.ToInt(this.CmbBxEstado.SelectedValue));
            this.PopulaBairro(StringUtils.ToInt(this.CmbBxCidade.SelectedValue));

            this.CmbBxCidade.Focus();
        }

        protected void DrpDwnLstEstadoContato_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaCidadeContato(StringUtils.ToInt(this.CmbBxEstadoContato.SelectedValue));
            this.PopulaBairroContato(StringUtils.ToInt(this.CmbBxCidadeContato.SelectedValue));

            this.CmbBxCidadeContato.Focus();
        }

        protected void DrpDwnLstCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaBairro(StringUtils.ToInt(this.CmbBxCidade.SelectedValue));
            this.CmbBxBairro.Focus();
        }

        protected void DrpDwnLstCidadeContato_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaBairroContato(StringUtils.ToInt(this.CmbBxCidadeContato.SelectedValue));
            this.CmbBxBairroContato.Focus();
        }

        protected void LnkBttnSelecionaAtividadeEconomica_Click(object sender, EventArgs e)
        {
            this.UCSelecionaCNAE1.Buscar();
        }

        private Boolean VerificaCamposCnpj()
        {
            Boolean res = true;
            res &= Valida_TextBox(TxtBxCNPJCPF);

            return res;
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            if (VerificaCamposCnpj())
            {
                EntEmpresaCadastro objEmpresa = new BllEmpresaCadastro().ValidarEmpresa(StringUtils.OnlyNumbers(this.TxtBxCNPJCPF.Text), objPrograma.IdPrograma);
                if (objEmpresa.IdEmpresaCadastro == 0)
                {
                    this.HddnFldEmpresaCadastro.Value = IntUtils.ToString(objEmpresa.IdEmpresaCadastro);
                    this.ImportacaoOutrosProgramas = true;
                    this.ObjectToPage(new BllInscricoesEmpresa().ObterPorIdEmpresaPrograma(objEmpresa.IdEmpresaCadastro, objPrograma.IdPrograma), this.ImportacaoOutrosProgramas);
                    HabilitaCampos(true);
                    this.TxtBxCNPJCPFValido.Text = this.TxtBxCNPJCPF.Text;
                }
                else
                {
                    EntInscricoesEmpresa objInscricoesEmpresa = new BllInscricoesEmpresa().ObterPorIdEmpresaPrograma(objEmpresa.IdEmpresaCadastro, objPrograma.IdPrograma);
                    EntTurma objTurma = new BllTurma().ObterTurmaAtiva(objPrograma.IdPrograma);

                    if (objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma != objTurma.IdTurma)
                    {
                        this.HddnFldEmpresaCadastro.Value = IntUtils.ToString(objEmpresa.IdEmpresaCadastro);
                        this.ImportacaoOutrosProgramas = true;
                        this.ObjectToPage(new BllInscricoesEmpresa().ObterPorIdEmpresaPrograma(objEmpresa.IdEmpresaCadastro, objPrograma.IdPrograma), this.ImportacaoOutrosProgramas);
                        HabilitaCampos(true);
                    }
                    else
                    {
                        MessageBox(this.Page, "Empresa já cadastrada.");
                        this.TxtBxCNPJCPF.Focus();
                    }
                }
            }
            else
            {
                MessageBox(this.Page, "Favor preencher o campo obrigatório (em destaque).");
            }
        }

        private void HabilitaCampos(Boolean valor)
        {
            this.fsValidar.Visible = !valor;
            this.divDados.Visible = valor;
            this.CmbBxEstado.Focus();
            this.ImgBttnConfirma.Visible = valor;
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        private Boolean VerificaCamposObrigatoriosCadastro()
        {
            Boolean res = true;
            res &= Valida_TextBox(TxtBxRazaoSocial);
            res &= Valida_DropDownList(CmbBxTipoEmpresa);
            res &= Valida_TextBox(TxtBxNomeFantasia);
            res &= Valida_DropDownList(CmbBxFaturamento);
            res &= Valida_TextBox(TxtBxCNPJCPF);
            res &= Valida_DropDownList(CmbBxCategoria);
            res &= Valida_TextBoxData(TxtBxDataAbertura);
            res &= Valida_TextBox(TxtBoxAtividadeEconomica);
            res &= Valida_TextBox(TxtBxNumeroEmpregados);
            res &= Valida_TextBox(TxtBxPrincipalAtividade);
            res &= Valida_DropDownList(CmbBxEstado);
            res &= Valida_DropDownList(CmbBxCidade);
            res &= Valida_DropDownList(CmbBxBairro);
            res &= Valida_TextBox(TxtBxEndereco);
            res &= Valida_TextBox(TxtBxNumero);
            res &= Valida_TextBox(TxtBxCEP);
            res &= Valida_TextBox(TxtBxNomeCompleto);
            res &= Valida_TextBox(TxtBxTelefoneFixo);
            res &= Valida_TextBox(TxtBxCPF);
            res &= Valida_DropDownList(CmbBxCargo);
            res &= Valida_TextBox(TxtBxEmail);
            res &= Valida_DropDownList(CmbBxEstadoContato);
            res &= Valida_TextBoxData(TxtBxDtNascimento);
            res &= Valida_DropDownList(CmbBxCidadeContato);
            res &= Valida_RadioButtonList(RdBttnLstSexo);
            res &= Valida_DropDownList(CmbBxBairroContato);
            res &= Valida_DropDownList(CmbBxNivelEscolaridade);
            res &= Valida_TextBox(TxtBxEnderecoCompleto);
            res &= Valida_TextBox(TxtBxNumeroContato);
            if (divSenha.Visible == true)
            {
                res &= Valida_TextBoxSenha(TxtBxSenha, TxtBxConfSenha);
            }
            res &= Valida_TextBox(TxtBxCEPContato);

            return res;
        }

        protected void ImgBttnConfirma_Click(object sender, ImageClickEventArgs e)
        {
            if (this.VerificaCamposObrigatoriosCadastro())
            {
                this.Gravar();
                this.Clear();
                this.Close();


                if (atualizaGrid != null)
                {
                    this.atualizaGrid();
                }
            }
            else
            {
                MessageBox(this.Page, "Favor preencher os campos obrigatórios (em destaque).");
            }
        }

        private void EnviaEmail()
        {
            String sPara = this.TxtBxEmail.Text;
            String sAssunto = "Inscrição";
            StringBuilder sMensagem = new StringBuilder();

            //EntInscricoesEmpresa objInscricoesEmpresa = new EntInscricoesEmpresa();
            //EntGrupoEmpresa objGrupoEmpresa = new EntGrupoEmpresa();
            //PageToObject(objInscricoesEmpresa, objGrupoEmpresa);

            sMensagem.AppendLine("Esta é uma Mensagem automática, não responda este e-mail.");
            sMensagem.AppendLine("Empresa Cadastrada:" + this.TxtBxRazaoSocial.Text);
            sMensagem.AppendLine("Administração MPE.");

            WebUtils.EnviaEmail(sPara, sAssunto, sMensagem);
        }

        private void Gravar()
        {
            EntInscricoesEmpresa objInscricoesEmpresa = new EntInscricoesEmpresa();
            EntGrupoEmpresa objGrupoEmpresa = new EntGrupoEmpresa();

            this.PageToObject(objInscricoesEmpresa, objGrupoEmpresa);

            try
            {
                Boolean flNovoCadastro = false;
                objInscricoesEmpresa.TurmaEmpresa.ParticipaPrograma = true;
                objInscricoesEmpresa.TurmaEmpresa.Ativo = true;
                objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.ParticipouMPE2011 = true;
                EntEmpresaCadastro empCadastro = new BllEmpresaCadastro().ObterPorCpfCnpj(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.CPF_CNPJ);

                if (empCadastro == null)
                {
                    flNovoCadastro = true;
                }
                objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro;

                objInscricoesEmpresa = new BllInscricoesEmpresa().InserirAlterar(objInscricoesEmpresa);

                //Verifica se é Novo Cadastro ou não
                if (flNovoCadastro)
                {
                    this.EnviaEmail();
                    MessageBox(this.Page, "Inscrição de Empresa inserida com sucesso!");
                }
                else
                {
                    MessageBox(this.Page, "Inscrição de Empresa alterada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar a Inscrição de Empresa!");
            }
        }

        private void PageToObject(EntInscricoesEmpresa objInscricoesEmpresa, EntGrupoEmpresa objGrupoEmpresa)
        {
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro = StringUtils.ToInt(this.HddnFldEmpresaCadastro.Value);
            objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma = StringUtils.ToInt(this.HddnFldTurma.Value);

            // Dados da Empresa
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.RazaoSocial = this.TxtBxRazaoSocial.Text;
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.NomeFantasia = this.TxtBxNomeFantasia.Text;
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.CPF_CNPJ = StringUtils.OnlyNumbers(this.TxtBxCNPJCPF.Text);
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.AberturaEmpresa = StringUtils.ToDate(this.TxtBxDataAbertura.Text);
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.PessoaJuridica = (StringUtils.OnlyNumbers(this.TxtBxCNPJCPF.Text).Length == 11); // provisorio
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.Ativo = true;
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.Estado.IdEstado = int.Parse(CmbBxEstado.SelectedValue);

            objInscricoesEmpresa.TurmaEmpresa.NumeroFuncionario = StringUtils.ToInt(this.TxtBxNumeroEmpregados.Text);
            objInscricoesEmpresa.TurmaEmpresa.Endereco = this.TxtBxEndereco.Text;
            objInscricoesEmpresa.TurmaEmpresa.NumeroEndereco = this.TxtBxNumero.Text;
            objInscricoesEmpresa.TurmaEmpresa.Complemento = this.TxtBxComplemento.Text;
            objInscricoesEmpresa.TurmaEmpresa.CEP = StringUtils.OnlyNumbers(this.TxtBxCEP.Text);
            objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomicaComplemento = this.TxtBxPrincipalAtividade.Text;
            objInscricoesEmpresa.TurmaEmpresa.TipoEmpresa.IdTipoEmpresa = StringUtils.ToInt(this.CmbBxTipoEmpresa.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Faturamento.IdFaturamento = StringUtils.ToInt(this.CmbBxFaturamento.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Categoria.IdCategoria = StringUtils.ToInt(this.CmbBxCategoria.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomica.IdAtividadeEconomica = StringUtils.ToInt(this.HddnIdAtividadeEconomica.Value);
            objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma = new BllTurma().ObterTurmaAtiva(objPrograma.IdPrograma).IdTurma;
            objInscricoesEmpresa.TurmaEmpresa.Usuario.IdUsuario = IdUsuarioLogado;

            objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma = int.Parse(CmbBxTurma.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Estado.IdEstado = int.Parse(CmbBxEstado.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Cidade.IdCidade = int.Parse(CmbBxCidade.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Bairro.IdBairro = int.Parse(CmbBxBairro.SelectedValue);
            //objInscricoesEmpresa.TurmaEmpresa.

            
            //Dados de Grupo x Empresa
            objGrupoEmpresa = new EntGrupoEmpresa();
            objGrupoEmpresa.Ativo = true;
            objGrupoEmpresa.DtCadastro = DateTime.Now;
            objGrupoEmpresa.EmpresaCadastro = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro;

            // Dados do Contato
            objInscricoesEmpresa.TurmaEmpresa.NomeContato = this.TxtBxNomeCompleto.Text;
            objInscricoesEmpresa.TurmaEmpresa.CPFContato = StringUtils.OnlyNumbers(this.TxtBxCPF.Text);
            objInscricoesEmpresa.TurmaEmpresa.CelularContato = StringUtils.OnlyNumbers(this.TxtBxCelular.Text);
            objInscricoesEmpresa.TurmaEmpresa.EmailContato = this.TxtBxEmail.Text;

            objInscricoesEmpresa.TurmaEmpresa.NascimentoContato = StringUtils.ToDate(this.TxtBxDtNascimento.Text);
            objInscricoesEmpresa.TurmaEmpresa.EnderecoContato = this.TxtBxEnderecoCompleto.Text;
            objInscricoesEmpresa.TurmaEmpresa.NumeroEnderecoContato = this.TxtBxNumeroContato.Text;
            objInscricoesEmpresa.TurmaEmpresa.ComplementoContato = this.TxtBxComplementoContato.Text;
            objInscricoesEmpresa.TurmaEmpresa.CEPContato = StringUtils.OnlyNumbers(this.TxtBxCEPContato.Text);
            objInscricoesEmpresa.TurmaEmpresa.TelefoneContato = StringUtils.OnlyNumbers(this.TxtBxTelefoneFixo.Text);
            objInscricoesEmpresa.TurmaEmpresa.Cargo.IdCargo = StringUtils.ToInt(this.CmbBxCargo.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.EstadoContato.IdEstado = StringUtils.ToInt(this.CmbBxEstadoContato.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.CidadeContato.IdCidade = StringUtils.ToInt(this.CmbBxCidadeContato.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.BairroContato.IdBairro = StringUtils.ToInt(this.CmbBxBairroContato.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.ContatoNivelEscolaridade.IdContatoNivelEscolaridade = StringUtils.ToInt(this.CmbBxNivelEscolaridade.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.FaixaEtaria.IdContatoFaixaEtaria = this.ProcessaFaixaEtaria(StringUtils.ToDate(this.TxtBxDtNascimento.Text));
            objInscricoesEmpresa.TurmaEmpresa.SexoContato = RdBttnLstSexo.SelectedValue;

            objInscricoesEmpresa.ProgramaEmpresa.NomeResponsavel = this.TxtBxNomeCompleto.Text;
            objInscricoesEmpresa.ProgramaEmpresa.EmailResponsavel = this.TxtBxEmail.Text;
            objInscricoesEmpresa.ProgramaEmpresa.Programa.IdPrograma = objPrograma.IdPrograma;
            if (divSenha.Visible)
            {
                objInscricoesEmpresa.ProgramaEmpresa.Senha = StringUtils.EncryptPassword(this.TxtBxSenha.Text);
            }
        }

        private void ObjectToPage(EntInscricoesEmpresa objInscricoesEmpresa, Boolean ImportacaoOutrosProgramas)
        {
            this.HddnFldEmpresaCadastro.Value = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            this.HddnFldTurma.Value = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma);

            this.PopulaTurma();
            SetSelectedItemInDropDownList(CmbBxTurma, IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma));

            this.PopulaEstado();
            SetSelectedItemInDropDownList(CmbBxEstado, IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Estado.IdEstado));

            this.PopulaCidade(objInscricoesEmpresa.TurmaEmpresa.Estado.IdEstado);
            SetSelectedItemInDropDownList(CmbBxCidade, IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Cidade.IdCidade));

            this.PopulaBairro(objInscricoesEmpresa.TurmaEmpresa.Cidade.IdCidade);
            SetSelectedItemInDropDownList(CmbBxBairro, IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Bairro.IdBairro));

            // Dados da Empresa
            this.TxtBxRazaoSocial.Text = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.RazaoSocial;
            this.TxtBxNomeFantasia.Text = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.NomeFantasia;
            this.TxtBxCNPJCPF.Text = FormatUtils.FormataCNPJ_CPF(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.CPF_CNPJ);

            this.TxtBxCNPJCPFValido.Text = this.TxtBxCNPJCPF.Text;

            this.TxtBxDataAbertura.Text = DateUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.AberturaEmpresa);
            this.TxtBxEndereco.Text = objInscricoesEmpresa.TurmaEmpresa.Endereco;
            this.TxtBxNumero.Text = objInscricoesEmpresa.TurmaEmpresa.NumeroEndereco;
            this.TxtBxComplemento.Text = objInscricoesEmpresa.TurmaEmpresa.Complemento;
            this.TxtBxCEP.Text = FormatUtils.FormatCEP(objInscricoesEmpresa.TurmaEmpresa.CEP);
            this.TxtBxPrincipalAtividade.Text = objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomicaComplemento;
            this.PopulaTipoEmpresa();
            SetSelectedItemInDropDownList(CmbBxTipoEmpresa, IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.TipoEmpresa.IdTipoEmpresa));
            
            if (!ImportacaoOutrosProgramas)
            {
                this.PopulaFaturamento(4);
                SetSelectedItemInDropDownList(CmbBxFaturamento, IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Faturamento.IdFaturamento));
                this.TxtBxNumeroEmpregados.Text = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.NumeroFuncionario);
            }

            this.PopulaCategoria(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.PessoaJuridica);
            SetSelectedItemInDropDownList(CmbBxCategoria, IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Categoria.IdCategoria));

            this.PopulaAtividadeEconomica(objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomica);

            // Dados do Contato
            this.TxtBxNomeCompleto.Text = objInscricoesEmpresa.TurmaEmpresa.NomeContato;
            this.TxtBxCPF.Text = FormatUtils.FormatCPF(objInscricoesEmpresa.TurmaEmpresa.CPFContato);
            this.TxtBxCelular.Text = FormatUtils.FormatTelefone(objInscricoesEmpresa.TurmaEmpresa.CelularContato);
            this.TxtBxEmail.Text = objInscricoesEmpresa.TurmaEmpresa.EmailContato;

            this.TxtBxDtNascimento.Text = DateUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.NascimentoContato);
            this.TxtBxEnderecoCompleto.Text = objInscricoesEmpresa.TurmaEmpresa.EnderecoContato;
            this.TxtBxNumeroContato.Text = objInscricoesEmpresa.TurmaEmpresa.NumeroEnderecoContato;
            this.TxtBxComplementoContato.Text = objInscricoesEmpresa.TurmaEmpresa.ComplementoContato;
            this.TxtBxCEPContato.Text = FormatUtils.FormatCEP(objInscricoesEmpresa.TurmaEmpresa.CEPContato);
            this.TxtBxTelefoneFixo.Text = FormatUtils.FormatTelefone( objInscricoesEmpresa.TurmaEmpresa.TelefoneContato);

            this.PopulaCargo();
            SetSelectedItemInDropDownList(CmbBxCargo, IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Cargo.IdCargo));

            this.PopulaEstadoContato();
            SetSelectedItemInDropDownList(CmbBxEstadoContato, IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.EstadoContato.IdEstado));

            this.PopulaCidadeContato(objInscricoesEmpresa.TurmaEmpresa.EstadoContato.IdEstado);
            SetSelectedItemInDropDownList(CmbBxCidadeContato, IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.CidadeContato.IdCidade));

            this.PopulaBairroContato(objInscricoesEmpresa.TurmaEmpresa.CidadeContato.IdCidade);
            SetSelectedItemInDropDownList(CmbBxBairroContato, IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.BairroContato.IdBairro));

            this.PopulaNivelEscolaridade();
            SetSelectedItemInDropDownList(CmbBxNivelEscolaridade, IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.ContatoNivelEscolaridade.IdContatoNivelEscolaridade));
            
            SetSelectedItemInDropDownList(RdBttnLstSexo, objInscricoesEmpresa.TurmaEmpresa.SexoContato);

            List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterAbertosPorIdTurmaIdEmpresa(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro);
            foreach (EntQuestionario eq in listaQuestionarios)
            {
                if (eq.IdQuestionario == EntQuestionario.QUESTIONARIO_INOVACAO_2011)
                {
                    if (eq.EmpresaParticipa)
                    {
                        Destaque2.SelectedValue = "1";
                    }
                    else
                    {
                        Destaque2.SelectedValue = "0";
                    }
                }
                else if (eq.IdQuestionario == EntQuestionario.QUESTIONARIO_RESPONSABILIDADE_2011)
                {
                    if (eq.EmpresaParticipa)
                    {
                        Destaque1.SelectedValue = "1";
                    }
                    else
                    {
                        Destaque1.SelectedValue = "0";
                    }
                }
                else if (eq.IdQuestionario == EntQuestionario.QUESTIONARIO_EMPREENDEDORISMO_2011)
                {
                    if (eq.EmpresaParticipa)
                    {
                        Destaque3.SelectedValue = "1";
                    }
                    else
                    {
                        Destaque3.SelectedValue = "0";
                    }
                }
            }

            // Teste de AutoAvaliação
            this.RdBttnLstPergunta1.SelectedValue = BooleanUtils.ToInt(objInscricoesEmpresa.TurmaEmpresa.Pergunta1).ToString();
            this.RdBttnLstPergunta2.SelectedValue = BooleanUtils.ToInt(objInscricoesEmpresa.TurmaEmpresa.Pergunta2).ToString();
            this.RdBttnLstPergunta3.SelectedValue = BooleanUtils.ToInt(objInscricoesEmpresa.TurmaEmpresa.Pergunta3).ToString();
            this.RdBttnLstPergunta4.SelectedValue = BooleanUtils.ToInt(objInscricoesEmpresa.TurmaEmpresa.Pergunta4).ToString();
        }

        private void SelecionaListItem(ComboBox cbb, Int32 value)
        {
            ListItem objListItem = cbb.Items.FindByValue(IntUtils.ToString(value));
            if (objListItem != null)
            {
                cbb.SelectedValue = objListItem.Value;
            }
        }

        protected void ImgBttnBuscarCep_Click(object sender, EventArgs e)
        {
            String cepTemp = StringUtils.OnlyNumbers(TxtBxCEP.Text);
            if (cepTemp.Length == 8)
            {
                try
                {
                    String teste = new SiacWEB_CadastroAtenderWS().Util_Rec_EnderecoPorCEP(cepTemp);
                    EntEstado objEstadoTemp = new BllIntegracaoSiac().ObterEstadoPorCep(teste);
                    EntCidade objCidadeTemp = new BllIntegracaoSiac().ObterCidadePorCep(teste);
                    EntBairro objBairroTemp = new BllIntegracaoSiac().ObterBairroPorCep(teste);
                    String enderecoTemp = new BllIntegracaoSiac().ObterEnderecoPorCep(teste);

                    this.SelecionaListItem(this.CmbBxEstado, objEstadoTemp.IdEstado);

                    if (CmbBxEstado.SelectedValue == objEstadoTemp.IdEstado.ToString())
                    {
                        if (this.CmbBxEstado.SelectedIndex > 0)
                            this.CmbBxCidade.Enabled = true;

                        this.PopulaCidade(objEstadoTemp.IdEstado);
                        this.SelecionaListItem(this.CmbBxCidade, objCidadeTemp.IdCidade);

                        if (this.CmbBxCidade.SelectedIndex > 0)
                            this.CmbBxBairro.Enabled = true;

                        this.PopulaBairro(objCidadeTemp.IdCidade);
                        this.SelecionaListItem(this.CmbBxBairro, objBairroTemp.IdBairro);

                        this.TxtBxEndereco.Text = enderecoTemp;
                        HddnFldCepAnterior.Value = TxtBxCEP.Text;
                        TxtBxNumero.Focus();
                    }
                    else
                    {
                        TxtBxCEP.Text = HddnFldCepAnterior.Value;
                        MessageBox(this.Page, "Este CEP é de um Estado que não está participando do FGA.");
                        ImgBttnBuscarCep_Click(null, null);
                        TxtBxCEP.Focus();
                    }
                }
                catch (Exception ex1)
                {
                    this.SelecionaListItem(this.CmbBxEstado, 0);

                    this.PopulaCidade(0);
                    this.SelecionaListItem(this.CmbBxCidade, 0);

                    this.PopulaBairro(0);
                    this.SelecionaListItem(this.CmbBxBairro, 0);

                    this.TxtBxEndereco.Text = "";
                    MessageBox(this.Page, "Endereço não localizado automaticamente. Por favor, preencha os campos de endereço.");
                    TxtBxCEP.Text = HddnFldCepAnterior.Value;
                    ImgBttnBuscarCep_Click(null, null);
                    TxtBxCEP.Focus();
                }
            }
        }

        protected void ImgBttnBuscarCepContato_Click(object sender, EventArgs e)
        {
            String cepTemp = StringUtils.OnlyNumbers(TxtBxCEPContato.Text);
            if (cepTemp.Length == 8)
            {
                try
                {
                    String teste = new SiacWEB_CadastroAtenderWS().Util_Rec_EnderecoPorCEP(cepTemp);
                    EntEstado objEstadoTemp = new BllIntegracaoSiac().ObterEstadoPorCep(teste);
                    EntCidade objCidadeTemp = new BllIntegracaoSiac().ObterCidadePorCep(teste);
                    EntBairro objBairroTemp = new BllIntegracaoSiac().ObterBairroPorCep(teste);
                    String enderecoTemp = new BllIntegracaoSiac().ObterEnderecoPorCep(teste);

                    this.SelecionaListItem(this.CmbBxEstadoContato, objEstadoTemp.IdEstado);

                    if (CmbBxEstadoContato.SelectedValue == objEstadoTemp.IdEstado.ToString())
                    {
                        if (this.CmbBxEstadoContato.SelectedIndex > 0)
                            this.CmbBxCidadeContato.Enabled = true;

                        this.PopulaCidadeContato(objEstadoTemp.IdEstado);
                        this.SelecionaListItem(this.CmbBxCidadeContato, objCidadeTemp.IdCidade);

                        if (this.CmbBxCidadeContato.SelectedIndex > 0)
                            this.CmbBxBairroContato.Enabled = true;

                        this.PopulaBairroContato(objCidadeTemp.IdCidade);
                        this.SelecionaListItem(this.CmbBxBairroContato, objBairroTemp.IdBairro);

                        this.TxtBxEnderecoCompleto.Text = enderecoTemp;
                        HddnFldCepAnteriorContato.Value = TxtBxCEPContato.Text;
                        TxtBxNumeroContato.Focus();
                    }
                    else
                    {
                        TxtBxCEPContato.Text = HddnFldCepAnteriorContato.Value;
                        MessageBox(this.Page, "Este CEP é de um Estado que não está participando do FGA.");
                        ImgBttnBuscarCepContato_Click(null, null);
                        TxtBxCEPContato.Focus();
                    }
                }
                catch (Exception ex1)
                {
                    this.SelecionaListItem(this.CmbBxEstadoContato, 0);

                    this.PopulaCidadeContato(0);
                    this.SelecionaListItem(this.CmbBxCidadeContato, 0);

                    this.PopulaBairroContato(0);
                    this.SelecionaListItem(this.CmbBxBairroContato, 0);

                    this.TxtBxEnderecoCompleto.Text = "";
                    MessageBox(this.Page, "Endereço não localizado automaticamente. Por favor, preencha os campos de endereço.");
                    TxtBxCEPContato.Text = HddnFldCepAnteriorContato.Value;
                    ImgBttnBuscarCepContato_Click(null, null);
                    TxtBxCEPContato.Focus();
                }
            }
        }

    }
}



