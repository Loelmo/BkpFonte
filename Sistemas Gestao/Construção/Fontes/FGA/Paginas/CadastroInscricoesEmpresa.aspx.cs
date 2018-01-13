using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Sistema_de_Gestao.Utilitarios;
using AjaxControlToolkit;
using FGA.Web_References.SiacWebCadastroAtendimentoWS.ws;

namespace Sistema_de_Gestao.Paginas
{
    public partial class CadastroInscricoesEmpresa : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["IdTurma"] != null)
                {
                    int IdTurma = int.Parse(Request["IdTurma"]);
                    AlteraTurma(IdTurma);
                }
                String cpfCnpj = "";
                if (Request["CpfCnpj"] != null)
                {
                    this.EmpresaLogada = new BllEmpresaCadastro().ObterPorCpfCnpj(Request["CpfCnpj"]);
                    cpfCnpj = StringUtils.trataCpfCnpj(Request["CpfCnpj"]);
                    //this.OrganizaTabIndex();
                    this.TxtBxRazaoSocial.Focus();

                    if (StringUtils.OnlyNumbers(cpfCnpj).Length == 14)
                    {
                        this.TxtBxCNPJCPF.Text = FormatUtils.FormatCNPJ(cpfCnpj);
                        this.LblCPF_CNPJ.Text = "CNPJ:";
                    }
                    else
                    {
                        this.TxtBxCNPJCPF.Text = FormatUtils.FormatCPF(cpfCnpj);
                        this.LblCPF_CNPJ.Text = "CPF:";
                    }
                }

                this.TxtBxCNPJCPF.Text = cpfCnpj;
                this.TxtBxCNPJCPF.Enabled = false;

                String ValorPadrao = "<< Selecione uma Opção >>";

                //WebUtils.PopulaDropDownList(DrpDwnLstTipoEmpresa, EnumType.TipoDropDownList.TipoEmpresa, ValorPadrao);
                //WebUtils.PopulaDropDownList(DrpDwnLstCategoria, EnumType.TipoDropDownList.Categoria, true, ValorPadrao);
                WebUtils.PopulaDropDownList(CmbBxNivelEscolaridade, EnumType.TipoDropDownList.Escolaridade, ValorPadrao);
                WebUtils.PopulaDropDownList(CmbBxFaturamento, EnumType.TipoDropDownList.Faturamento, ValorPadrao);
                WebUtils.PopulaDropDownList(CmbBxCargo, EnumType.TipoDropDownList.Cargo, ValorPadrao);

                WebUtils.PopulaDropDownList(CmbBxTipoEmpresa, EnumType.TipoDropDownList.TipoEmpresa, ValorPadrao);
                WebUtils.PopulaDropDownList(CmbBxCategoria, EnumType.TipoDropDownList.Categoria, ValorPadrao);

                //// teste Combobox
                //this.CmbBxCategoria.Items.Clear();
                //this.CmbBxCategoria.DataSource = new BllCategoria().ObterTodos(true);
                //this.CmbBxCategoria.DataBind();

                //if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                //{
                //    this.CmbBxCategoria.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                //    this.CmbBxCategoria.SelectedIndex = 0;
                //}


                this.PopulaEstado();
                this.PopulaEstadoContato();
                this.PopulaCidade(0);
                this.PopulaCidadeContato(0);
                this.PopulaBairro(0);
                this.PopulaBairroContato(0);

                if (this.EmpresaLogada != null && this.EmpresaLogada.IdEmpresaCadastro > 0)
                {
                    EntInscricoesEmpresa objInscricoesEmpresa = new EntInscricoesEmpresa();
                    EntTurmaEmpresa objTurmaEmpresa = new EntTurmaEmpresa();
                    objTurmaEmpresa.EmpresaCadastro = EmpresaLogada;
                    objTurmaEmpresa.Turma = objTurma;
                    objTurmaEmpresa = new BllTurmaEmpresa().ObterPorTurmaEmpresa(objTurmaEmpresa);

                    objInscricoesEmpresa.ProgramaEmpresa = new BllProgramaEmpresa().ObterPorProgramaEmpresa(objPrograma.IdPrograma, EmpresaLogada.IdEmpresaCadastro);

                    if (objInscricoesEmpresa.ProgramaEmpresa != null)
                    {
                        this.HddnFldIdProgramaEmpresa.Value = IntUtils.ToString(objInscricoesEmpresa.ProgramaEmpresa.IdProgramaEmpresa);
                        this.HddnFldSenha.Value = objInscricoesEmpresa.ProgramaEmpresa.Senha;
                    }

                    if (objTurmaEmpresa != null)
                    {
                        this.ObjectToPage(new BllInscricoesEmpresa().ObterPorIdEmpresaTurma(objTurmaEmpresa, objPrograma.IdPrograma));
                        this.HabilitaCampoSenha(false);
                    }
                    else
                    {
//                        objTurmaEmpresa = new BllTurmaEmpresa().ObterTurmaEmpresaAnteriorPorEmpresaCadastro(EmpresaLogada.IdEmpresaCadastro, objPrograma.IdPrograma, objTurma.IdTurma);
//                        objInscricoesEmpresa.TurmaEmpresa = objTurmaEmpresa;
//                        objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro = EmpresaLogada;

//                        this.ObjectToPageImportacao(objInscricoesEmpresa);
                        this.CmbBxFaturamento.SelectedIndex = 0;
                        this.HabilitaCampoSenha(false);
                    }
                    this.HddnFldIdInscricaoEmpresa.Value = (String)Request.QueryString["IdEmpresaCadastro"];
                }

                //Quando Pessoa Fisica Obrigatóriamente a categoria deve ser AgroNegócio.
                VerificaCpfCNPJ();

                if (Request["CpfCnpj"] != null && (objPrograma.IdPrograma == EntPrograma.PROGRAMA_FGA || objPrograma.IdPrograma == EntPrograma.PROGRAMA_PEG))
                {
                    this.TxtBxRazaoSocial.Text = EmpresaLogada.RazaoSocial;
                    this.TxtBxNomeFantasia.Text = EmpresaLogada.NomeFantasia;
                    this.TxtBxDataAbertura.Text = DateUtils.ToString(EmpresaLogada.AberturaEmpresa);
                    this.CmbBxEstado.SelectedValue = EmpresaLogada.Estado.IdEstado.ToString();
                    this.PopulaCidade(EmpresaLogada.Estado.IdEstado);
                    this.CmbBxCidade.Enabled = true;

                    EntProgramaEmpresa objProgramaEmpresa = new BllProgramaEmpresa().ObterPorProgramaEmpresa(this.objPrograma.IdPrograma, EmpresaLogada.IdEmpresaCadastro);
                    if (objProgramaEmpresa != null)
                    {
                        this.TxtBxNomeCompleto.Text = objProgramaEmpresa.NomeResponsavel;
                        this.TxtBxEmail.Text = objProgramaEmpresa.EmailResponsavel;
                    }
                }

                int numeroEmpregados = StringUtils.ToInt(TxtBxNumeroEmpregados.Text);
                if (numeroEmpregados == -1)
                {
                    TxtBxNumeroEmpregados.Text = "";
                }

                if (StringUtils.ToDate(TxtBxDtNascimento.Text).Year < 1900)
                {
                    TxtBxDtNascimento.Text = "";
                }

            }

            this.UCSelecionaCNAE1.atualizaCampo += this.PopulaAtividadeEconomica;

            TxtBxCEP.Focus();
        }

        private void AlteraTurma(Int32 IdTurma)
        {
            this.objTurma = new BllTurma().ObterPorId(IdTurma);
        }

        protected void ImgBttnProcessar2_Click(object sender, ImageClickEventArgs e)
        {
            this.HddnFldSenha.Value = this.TxtBxSenha.Text;
            this.Etapa2.Visible = false;
        }

        protected void ImgBttnConfirma_Click(object sender, ImageClickEventArgs e)
        {

        }

        private Boolean VerificaCamposObrigatoriosEmpresa()
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

            return res;
        }

        private Boolean VerificaCamposObrigatoriosContato()
        {
            Boolean res = true;
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
//            res &= Valida_TextBoxSenha(TxtBxSenha, TxtBxConfSenha);
            res &= Valida_TextBox(TxtBxCEPContato);

            return res;
        }

        private void Gravar()
        {
            EntInscricoesEmpresa objInscricoesEmpresa = new EntInscricoesEmpresa();

            this.PageToObject(objInscricoesEmpresa);

            try
            {
                Boolean isNovaEmpresa = false;
                if (objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro == 0)
                {
                    isNovaEmpresa = true;
                }
                objInscricoesEmpresa = new BllInscricoesEmpresa().InserirAlterar(objInscricoesEmpresa);

                this.EmpresaLogada = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro;

                //Verifica se é Insert ou Update
                if (isNovaEmpresa)
                {
                    MessageBox(this.Page, "Inscrição Empresa inserida com sucesso!");
                    Response.Redirect("~/Paginas/CadastroSucesso.aspx");
                }
                else
                {
                    MessageBox(this.Page, "Inscrição Empresa alterada com sucesso!");
                    Response.Redirect("~/Paginas/Empresa/SelecionaQuestionario.aspx");
                }
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar a Inscrição Empresa!");
            }

        }

        private void PageToObject(EntInscricoesEmpresa objInscricoesEmpresa)
        {
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro = StringUtils.ToInt(this.HddnFldIdInscricaoEmpresa.Value);
            objInscricoesEmpresa.ProgramaEmpresa.IdProgramaEmpresa = StringUtils.ToInt(this.HddnFldIdProgramaEmpresa.Value);

            // Dados da Empresa
            objInscricoesEmpresa.TurmaEmpresa.Ativo = true;
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.RazaoSocial = this.TxtBxRazaoSocial.Text;
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.NomeFantasia = this.TxtBxNomeFantasia.Text;
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.CPF_CNPJ = StringUtils.OnlyNumbers(this.TxtBxCNPJCPF.Text);
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.AberturaEmpresa = StringUtils.ToDate(this.TxtBxDataAbertura.Text);
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.PessoaJuridica = (StringUtils.OnlyNumbers(this.TxtBxCNPJCPF.Text).Length == 14); // provisorio
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.Ativo = true;
            objInscricoesEmpresa.TurmaEmpresa.NumeroFuncionario = StringUtils.ToInt(this.TxtBxNumeroEmpregados.Text);
            objInscricoesEmpresa.TurmaEmpresa.Endereco = this.TxtBxEndereco.Text;
            objInscricoesEmpresa.TurmaEmpresa.Complemento = this.TxtBxComplemento.Text;
            objInscricoesEmpresa.TurmaEmpresa.NumeroEndereco = this.TxtBxNumero.Text;
            objInscricoesEmpresa.TurmaEmpresa.CEP = StringUtils.OnlyNumbers(this.TxtBxCEP.Text);
            objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomicaComplemento = this.TxtBxPrincipalAtividade.Text;
            objInscricoesEmpresa.TurmaEmpresa.TipoEmpresa.IdTipoEmpresa = StringUtils.ToInt(this.CmbBxTipoEmpresa.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Faturamento.IdFaturamento = StringUtils.ToInt(this.CmbBxFaturamento.SelectedValue);
            //objInscricoesEmpresa.TurmaEmpresa.Categoria.IdCategoria = StringUtils.ToInt(this.DrpDwnLstCategoria.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Categoria.IdCategoria = StringUtils.ToInt(this.CmbBxCategoria.SelectedValue);

            
            objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomica.IdAtividadeEconomica = StringUtils.ToInt(this.HddnIdAtividadeEconomica.Value);
            objInscricoesEmpresa.TurmaEmpresa.Estado.IdEstado = StringUtils.ToInt(this.CmbBxEstado.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Cidade.IdCidade = StringUtils.ToInt(this.CmbBxCidade.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Bairro.IdBairro = StringUtils.ToInt(this.CmbBxBairro.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.Estado.IdEstado = StringUtils.ToInt(this.CmbBxEstado.SelectedValue);
            if (objPrograma.IdPrograma == 1)
            {
                objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma = new BllTurma().ObterTurmaAtiva(objPrograma.IdPrograma).IdTurma;
            }
            else
            {
                objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma = objTurma.IdTurma; ;
            }
            objInscricoesEmpresa.TurmaEmpresa.ParticipaPrograma = true;

            // Dados do Contato
            objInscricoesEmpresa.TurmaEmpresa.NomeContato = this.TxtBxNomeCompleto.Text;
            objInscricoesEmpresa.TurmaEmpresa.CPFContato = StringUtils.OnlyNumbers(this.TxtBxCPF.Text);
            objInscricoesEmpresa.TurmaEmpresa.CelularContato = StringUtils.OnlyNumbers(this.TxtBxCelular.Text);
            objInscricoesEmpresa.TurmaEmpresa.EmailContato = this.TxtBxEmail.Text;
            objInscricoesEmpresa.TurmaEmpresa.SexoContato = this.RdBttnLstSexo.SelectedValue;
            objInscricoesEmpresa.TurmaEmpresa.NascimentoContato = StringUtils.ToDate(this.TxtBxDtNascimento.Text);
            objInscricoesEmpresa.TurmaEmpresa.EnderecoContato = this.TxtBxEnderecoCompleto.Text;
            objInscricoesEmpresa.TurmaEmpresa.ComplementoContato = this.TxtBxComplementoContato.Text;
            objInscricoesEmpresa.TurmaEmpresa.NumeroEnderecoContato = this.TxtBxNumeroContato.Text;
            objInscricoesEmpresa.TurmaEmpresa.CEPContato = StringUtils.OnlyNumbers(this.TxtBxCEPContato.Text);
            objInscricoesEmpresa.TurmaEmpresa.TelefoneContato = StringUtils.OnlyNumbers(this.TxtBxTelefoneFixo.Text);
            objInscricoesEmpresa.TurmaEmpresa.Cargo.IdCargo = StringUtils.ToInt(this.CmbBxCargo.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.EstadoContato.IdEstado = StringUtils.ToInt(this.CmbBxEstadoContato.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.CidadeContato.IdCidade = StringUtils.ToInt(this.CmbBxCidadeContato.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.BairroContato.IdBairro = StringUtils.ToInt(this.CmbBxBairroContato.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.ContatoNivelEscolaridade.IdContatoNivelEscolaridade = StringUtils.ToInt(this.CmbBxNivelEscolaridade.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.FaixaEtaria.IdContatoFaixaEtaria = this.ProcessaFaixaEtaria(StringUtils.ToDate(this.TxtBxDtNascimento.Text));

            //Verifica se é importação, caso seja manter a mesma senha do cadastro importado.
            objInscricoesEmpresa.ProgramaEmpresa.Senha = HddnFldSenha.Value;
            //--------------

            objInscricoesEmpresa.ProgramaEmpresa.NomeResponsavel = this.TxtBxNomeCompleto.Text;
            objInscricoesEmpresa.ProgramaEmpresa.EmailResponsavel = this.TxtBxEmail.Text;
            objInscricoesEmpresa.ProgramaEmpresa.Programa.IdPrograma = objPrograma.IdPrograma;

            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro;
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.ParticipouMPE2011 = true;
        }

        private void SelecionaListItem(DropDownList ddl, Int32 value)
        {
            ListItem objListItem = ddl.Items.FindByValue(IntUtils.ToString(value));
            if (objListItem != null)
            {
                ddl.SelectedValue = objListItem.Value;
            }
        }

        private void SelecionaListItem(ComboBox cbb, Int32 value)
        {
            ListItem objListItem = cbb.Items.FindByValue(IntUtils.ToString(value));
            if (objListItem != null)
            {
                cbb.SelectedValue = objListItem.Value;
            }
        }

        private void ObjectToPage(EntInscricoesEmpresa objInscricoesEmpresa)
        {
            this.HddnFldIdProgramaEmpresa.Value = IntUtils.ToString(objInscricoesEmpresa.ProgramaEmpresa.IdProgramaEmpresa);

            // Dados da Empresa
            this.TxtBxRazaoSocial.Text = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.RazaoSocial;
            this.TxtBxNomeFantasia.Text = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.NomeFantasia;
            if (objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.PessoaJuridica)
            {
                this.TxtBxCNPJCPF.Text = FormatUtils.FormatCNPJ(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.CPF_CNPJ);
                this.LblCPF_CNPJ.Text = "CNPJ:";
            }
            else
            {
                this.TxtBxCNPJCPF.Text = FormatUtils.FormatCPF(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.CPF_CNPJ);
                this.LblCPF_CNPJ.Text = "CPF:";
            }

            this.TxtBxDataAbertura.Text = DateUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.AberturaEmpresa);
            this.TxtBxNumeroEmpregados.Text = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.NumeroFuncionario);
            this.TxtBxEndereco.Text = objInscricoesEmpresa.TurmaEmpresa.Endereco;
            this.TxtBxComplemento.Text = objInscricoesEmpresa.TurmaEmpresa.Complemento;
            this.TxtBxNumero.Text = objInscricoesEmpresa.TurmaEmpresa.NumeroEndereco;
            this.TxtBxCEP.Text = FormatUtils.FormatCEP(objInscricoesEmpresa.TurmaEmpresa.CEP);
            this.TxtBxPrincipalAtividade.Text = objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomicaComplemento;

            //this.SelecionaListItem(this.DrpDwnLstTipoEmpresa, objInscricoesEmpresa.TurmaEmpresa.TipoEmpresa.IdTipoEmpresa);
            this.CmbBxTipoEmpresa.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.TipoEmpresa.IdTipoEmpresa);
            this.SelecionaListItem(this.CmbBxFaturamento, objInscricoesEmpresa.TurmaEmpresa.Faturamento.IdFaturamento);

            //this.SelecionaListItem(this.DrpDwnLstCategoria, objInscricoesEmpresa.TurmaEmpresa.Categoria.IdCategoria);
            this.CmbBxCategoria.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Categoria.IdCategoria);

            this.PopulaAtividadeEconomica(objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomica);

            if (objInscricoesEmpresa.TurmaEmpresa.Estado.IdEstado == 0)
            {
                objInscricoesEmpresa.TurmaEmpresa.Estado = objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.Estado;
            }

            this.SelecionaListItem(this.CmbBxEstado, objInscricoesEmpresa.TurmaEmpresa.Estado.IdEstado);

            if (this.CmbBxEstado.SelectedIndex > 0)
                this.CmbBxCidade.Enabled = true;

            this.PopulaCidade(objInscricoesEmpresa.TurmaEmpresa.Estado.IdEstado);
            this.SelecionaListItem(this.CmbBxCidade, objInscricoesEmpresa.TurmaEmpresa.Cidade.IdCidade);

            if (this.CmbBxCidade.SelectedIndex > 0)
                this.CmbBxBairro.Enabled = true;

            this.PopulaBairro(objInscricoesEmpresa.TurmaEmpresa.Cidade.IdCidade);
            this.SelecionaListItem(this.CmbBxBairro, objInscricoesEmpresa.TurmaEmpresa.Bairro.IdBairro);


            // Dados do Contato
            this.TxtBxNomeCompleto.Text = objInscricoesEmpresa.TurmaEmpresa.NomeContato;
            this.TxtBxCPF.Text = FormatUtils.FormatCPF(objInscricoesEmpresa.TurmaEmpresa.CPFContato);
            this.TxtBxCelular.Text = FormatUtils.FormatTelefone(objInscricoesEmpresa.TurmaEmpresa.CelularContato);
            this.TxtBxEmail.Text = objInscricoesEmpresa.TurmaEmpresa.EmailContato;
            this.RdBttnLstSexo.SelectedValue = objInscricoesEmpresa.TurmaEmpresa.SexoContato;
            this.TxtBxDtNascimento.Text = DateUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.NascimentoContato);
            this.TxtBxEnderecoCompleto.Text = objInscricoesEmpresa.TurmaEmpresa.EnderecoContato;
            this.TxtBxComplementoContato.Text = objInscricoesEmpresa.TurmaEmpresa.ComplementoContato;
            this.TxtBxNumeroContato.Text = objInscricoesEmpresa.TurmaEmpresa.NumeroEnderecoContato;
            this.TxtBxCEPContato.Text = FormatUtils.FormatCEP(objInscricoesEmpresa.TurmaEmpresa.CEPContato);
            this.TxtBxTelefoneFixo.Text = FormatUtils.FormatTelefone(objInscricoesEmpresa.TurmaEmpresa.TelefoneContato);
            this.CmbBxCargo.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Cargo.IdCargo);

            this.SelecionaListItem(this.CmbBxEstadoContato, objInscricoesEmpresa.TurmaEmpresa.EstadoContato.IdEstado);

            if (this.CmbBxEstadoContato.SelectedIndex > 0)
                this.CmbBxCidadeContato.Enabled = true;

            this.PopulaCidadeContato(objInscricoesEmpresa.TurmaEmpresa.EstadoContato.IdEstado);
            this.SelecionaListItem(this.CmbBxCidadeContato, objInscricoesEmpresa.TurmaEmpresa.CidadeContato.IdCidade);

            if (this.CmbBxCidadeContato.SelectedIndex > 0)
                this.CmbBxBairroContato.Enabled = true;

            this.PopulaBairroContato(objInscricoesEmpresa.TurmaEmpresa.CidadeContato.IdCidade);
            this.SelecionaListItem(this.CmbBxBairroContato, objInscricoesEmpresa.TurmaEmpresa.BairroContato.IdBairro);

            this.CmbBxNivelEscolaridade.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.ContatoNivelEscolaridade.IdContatoNivelEscolaridade);
        }

        private void ObjectToPageImportacao(EntInscricoesEmpresa objInscricoesEmpresa)
        {
            // Dados da Empresa
            this.TxtBxRazaoSocial.Text = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.RazaoSocial;
            this.TxtBxNomeFantasia.Text = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.NomeFantasia;
            if (objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.PessoaJuridica)
            {
                this.TxtBxCNPJCPF.Text = FormatUtils.FormatCNPJ(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.CPF_CNPJ);
                this.LblCPF_CNPJ.Text = "CNPJ:";
            }
            else
            {
                this.TxtBxCNPJCPF.Text = FormatUtils.FormatCPF(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.CPF_CNPJ);
                this.LblCPF_CNPJ.Text = "CPF:";
            }

            this.TxtBxDataAbertura.Text = DateUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.AberturaEmpresa);
            this.TxtBxNumeroEmpregados.Text = "";
            this.TxtBxEndereco.Text = "";
            this.TxtBxComplemento.Text = "";
            this.TxtBxNumero.Text = "";
            this.TxtBxCEP.Text = "";
            this.TxtBxPrincipalAtividade.Text = objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomicaComplemento;

            //this.SelecionaListItem(this.DrpDwnLstTipoEmpresa, objInscricoesEmpresa.TurmaEmpresa.TipoEmpresa.IdTipoEmpresa);
            this.CmbBxTipoEmpresa.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.TipoEmpresa.IdTipoEmpresa);
            this.SelecionaListItem(this.CmbBxFaturamento, objInscricoesEmpresa.TurmaEmpresa.Faturamento.IdFaturamento);

            String ValorPadrao = "<< Selecione uma Opção >>";
            WebUtils.PopulaDropDownList(CmbBxCategoria, EnumType.TipoDropDownList.Categoria, ValorPadrao);
            this.CmbBxCategoria.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Categoria.IdCategoria);


            this.PopulaAtividadeEconomica(new EntAtividadeEconomica());

            this.SelecionaListItem(this.CmbBxEstado, 0);

            if (this.CmbBxEstado.SelectedIndex > 0)
                this.CmbBxCidade.Enabled = true;

            this.PopulaCidade(0);
            this.SelecionaListItem(this.CmbBxCidade, 0);

            if (this.CmbBxCidade.SelectedIndex > 0)
                this.CmbBxBairro.Enabled = true;

            this.PopulaBairro(0);
            this.SelecionaListItem(this.CmbBxBairro, 0);

            // Dados do Contato
            this.TxtBxNomeCompleto.Text = String.Empty;
            this.TxtBxCPF.Text = String.Empty;
            this.TxtBxCelular.Text = String.Empty;
            this.TxtBxEmail.Text = String.Empty;
            this.RdBttnLstSexo.SelectedValue = String.Empty;
            this.TxtBxDtNascimento.Text = String.Empty;
            this.TxtBxEnderecoCompleto.Text = String.Empty;
            this.TxtBxComplementoContato.Text = String.Empty;
            this.TxtBxNumeroContato.Text = String.Empty;
            this.TxtBxCEPContato.Text = String.Empty;
            this.TxtBxTelefoneFixo.Text = String.Empty;

            this.CmbBxNivelEscolaridade.SelectedValue = "";
        }

        private void PopulaAtividadeEconomica(EntAtividadeEconomica objAtividadeEconomica)
        {
            String campo = "";
            if (objAtividadeEconomica.Codigo > 0)
            {
                campo = campo + objAtividadeEconomica.Classe + " - ";
            }
            this.TxtBoxAtividadeEconomica.Text = campo + objAtividadeEconomica.AtividadeEconomica;
            this.TxtBoxAtividadeEconomica.ToolTip = campo + objAtividadeEconomica.AtividadeEconomica;
            this.HddnIdAtividadeEconomica.Value = IntUtils.ToString(objAtividadeEconomica.IdAtividadeEconomica);

            TxtBxPrincipalAtividade.Focus();
        }

        private void PopulaEstado()
        {
            CmbBxEstado.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "<< Selecione um Estado >>";
            item.Value = "0";
            CmbBxEstado.Items.Add(item);

            foreach (EntEstado objEstado in new BllEstado().ObterEstadosPorTurma(objTurma.IdTurma, EntTipoEtapa.TIPO_ETAPA_FGA_INSCRICAO_AUTODIAGNOSTICO_EMPRESA))
            {
                item = new ListItem();
                item.Text = objEstado.Estado;
                item.Value = objEstado.IdEstado.ToString();

                CmbBxEstado.Items.Add(item);
            }

            CmbBxEstado.DataBind();
        }

        private void PopulaEstadoContato()
        {
            CmbBxEstadoContato.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "<< Selecione um Estado >>";
            item.Value = "0";
            CmbBxEstadoContato.Items.Add(item);

            foreach (EntEstado objEstado in new BllEstado().ObterTodos())
            {
                item = new ListItem();
                item.Text = objEstado.Estado;
                item.Value = objEstado.IdEstado.ToString();

                CmbBxEstadoContato.Items.Add(item);
            }

            CmbBxEstadoContato.DataBind();
        }

        private void PopulaCidade(Int32 IdEstado)
        {
            CmbBxCidade.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "<< Selecione uma Cidade >>";
            item.Value = "0";
            CmbBxCidade.Items.Add(item);

            if (IdEstado != 0)
            {
                CmbBxCidade.Enabled = true;
                foreach (EntCidade objCidade in new BllCidade().ObterCidadePorEstado2(IdEstado))
                {
                    item = new ListItem();
                    item.Text = objCidade.Cidade;
                    item.Value = objCidade.IdCidade.ToString();

                    CmbBxCidade.Items.Add(item);
                }
            }
            else
            {
                CmbBxCidade.Enabled = false;
            }

            CmbBxCidade.DataBind();
        }

        private void PopulaCidadeContato(Int32 IdEstado)
        {
            CmbBxCidadeContato.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "<< Selecione uma Cidade >>";
            item.Value = "0";
            CmbBxCidadeContato.Items.Add(item);

            if (IdEstado != 0)
            {
                foreach (EntCidade objCidade in new BllCidade().ObterCidadePorEstado2(IdEstado))
                {
                    item = new ListItem();
                    item.Text = objCidade.Cidade;
                    item.Value = objCidade.IdCidade.ToString();

                    CmbBxCidadeContato.Items.Add(item);
                }
                CmbBxCidadeContato.Enabled = true;
            }
            else
            {
                CmbBxCidadeContato.Enabled = false;
            }

            CmbBxCidadeContato.DataBind();
        }

        private void PopulaBairro(Int32 IdCidade)
        {
            CmbBxBairro.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "<< Selecione um Bairro >>";
            item.Value = "0";
            CmbBxBairro.Items.Add(item);

            if (IdCidade != 0)
            {
                foreach (EntBairro objBairro in new BllBairro().ObterPorCidade(IdCidade))
                {
                    item = new ListItem();
                    item.Text = objBairro.Bairro;
                    item.Value = objBairro.IdBairro.ToString();

                    CmbBxBairro.Items.Add(item);
                    CmbBxBairro.Enabled = true;
                }
            }
            else
            {
                CmbBxBairro.Enabled = false;
            }

            CmbBxBairro.DataBind();
        }

        private void PopulaBairroContato(Int32 IdCidade)
        {
            CmbBxBairroContato.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "<< Selecione um Bairro >>";
            item.Value = "0";
            CmbBxBairroContato.Items.Add(item);

            if (IdCidade != 0)
            {
                foreach (EntBairro objBairro in new BllBairro().ObterPorCidade(IdCidade))
                {
                    item = new ListItem();
                    item.Text = objBairro.Bairro;
                    item.Value = objBairro.IdBairro.ToString();

                    CmbBxBairroContato.Items.Add(item);
                }
                CmbBxBairroContato.Enabled = true;
            }
            else
            {
                CmbBxBairroContato.Enabled = false;
            }

            CmbBxBairroContato.DataBind();
        }

        private void VerificaCpfCNPJ()
        {
            if (StringUtils.OnlyNumbers(this.TxtBxCNPJCPF.Text).Length == 11)
            {
                // CPF
                //foreach (ListItem objListItem in DrpDwnLstCategoria.Items)
                foreach (ListItem objListItem in CmbBxCategoria.Items)
                    
                {
                    if (objListItem.Text == "AGRONEGÓCIO")
                    {
                        objListItem.Selected = true;
                    }
                    else
                    {
                        objListItem.Selected = false;
                    }
                }
                foreach (ListItem objListItem in CmbBxTipoEmpresa.Items)
                {
                    if (objListItem.Text == "Produtor Rural")
                    {
                        objListItem.Selected = true;
                    }
                    else
                    {
                        objListItem.Selected = false;
                    }
                }
                //this.DrpDwnLstCategoria.Enabled = false;
                this.CmbBxCategoria.Enabled = false;

                this.CmbBxTipoEmpresa.Enabled = false;
            }
            else
            {
                // CNPJ
                //this.DrpDwnLstCategoria.Enabled = true;
                this.CmbBxCategoria.Enabled = true;

                this.CmbBxTipoEmpresa.Enabled = true;
            }
        }

        protected void LnkBttnSelecionaAtividadeEconomica_Click(object sender, EventArgs e)
        {
            this.UCSelecionaCNAE1.Buscar();
        }

        protected void DrpDwnLstEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CmbBxCidade.Enabled = true;
            this.PopulaCidade(StringUtils.ToInt(this.CmbBxEstado.SelectedValue));
            this.PopulaBairro(0);
            this.CmbBxEstado.Focus();
        }

        protected void DrpDwnLstCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CmbBxBairro.Enabled = true;
            this.PopulaBairro(StringUtils.ToInt(this.CmbBxCidade.SelectedValue));
            this.CmbBxCidade.Focus();
        }

        protected void DrpDwnLstEstadoContato_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CmbBxCidadeContato.Enabled = true;
            this.PopulaCidadeContato(StringUtils.ToInt(this.CmbBxEstadoContato.SelectedValue));
            this.PopulaBairroContato(0);
            this.CmbBxEstadoContato.Focus(); 
        }

        protected void DrpDwnLstCidadeContato_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CmbBxBairroContato.Enabled = true;
            this.PopulaBairroContato(StringUtils.ToInt(this.CmbBxCidadeContato.SelectedValue));
            this.CmbBxCidadeContato.Focus();
        }

        private void HabilitaCampoSenha(Boolean valor)
        {
            this.Label30.Visible = false;
            this.TxtBxSenha.Visible = false;
            this.spSenha.Visible = false;

            this.Label32.Visible = false;
            this.TxtBxConfSenha.Visible = false;
            this.spConfSenha.Visible = false;
        }

        protected void ImgBttnBaixar_Click(object sender, EventArgs e)
        {
            //Obtem dados da TurmaEmpresa Anterior Recente e Valido
            EntTurmaEmpresa objTurmaEmpresa = new BllTurmaEmpresa().ObterTurmaEmpresaAnteriorPorEmpresaCadastro(EmpresaLogada.IdEmpresaCadastro, objPrograma.IdPrograma, objTurma.IdTurma);
            //Obtem dados para Inscrição
            EntInscricoesEmpresa objInscricoesEmpresa = new EntInscricoesEmpresa();
            objInscricoesEmpresa.TurmaEmpresa = objTurmaEmpresa;
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro = EmpresaLogada;

            //  objInscricoesEmpresa.TurmaEmpresa.Cidade = new EntCidade();
            //  objInscricoesEmpresa.TurmaEmpresa.Bairro = new EntBairro();

            //  objInscricoesEmpresa.TurmaEmpresa.CidadeContato = new EntCidade();
            //  objInscricoesEmpresa.TurmaEmpresa.BairroContato = new EntBairro();

            objInscricoesEmpresa.TurmaEmpresa.NumeroFuncionario = 0;
            //  objInscricoesEmpresa.TurmaEmpresa.Faturamento = new EntFaturamento();

            this.ObjectToPage(objInscricoesEmpresa);

            this.ImgBttnBaixar.Visible = false;
        }

        private void PassoAPasso(Int32 Etapa)
        {
            if (Etapa == 1)
            {
                this.Etapa1.Visible = true;
                this.Etapa2.Visible = false;
                this.TxtBxRazaoSocial.Focus();
            }
            else if (Etapa == 2)
            {
                this.Etapa1.Visible = false;
                this.Etapa2.Visible = true;
                this.TxtBxNomeCompleto.Focus();
            }
        }

        protected void BtnProximo_Click(object sender, EventArgs e)
        {
            if (VerificaCamposObrigatoriosEmpresa())
            {
                this.PassoAPasso(2);
            }
            else
            {
                MessageBox(this, "Favor preencher os campos obrigatórios (em destaque).");
            }
        }

        protected void BtnProximo2_Click(object sender, EventArgs e)
        {
            if ((this.TxtBxSenha.Visible) && (this.TxtBxSenha.Text.Length < 6))
            {
                MessageBox(this, "A senha deve conter no minimo 6 caracteres!");
                this.TxtBxSenha.Focus();
            }
            else
            {
                this.PassoAPasso(3);
            }
        }

        protected void BtnVoltar2_Click(object sender, EventArgs e)
        {
            this.PassoAPasso(1);
        }

        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (this.VerificaCamposObrigatoriosContato())
            {
                this.Gravar();
            }
            else
            {
                MessageBox(this, "Favor preencher os campos obrigatórios (em destaque).");
            }
        }

        protected void DrpDwnLstAtividadeEconomica_SelectedIndexChanged(object sender, EventArgs e)
        {

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