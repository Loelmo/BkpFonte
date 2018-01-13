using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using System.Web.UI.HtmlControls;
using Sistema_de_Gestao.Pagina_Base;

namespace Sistema_de_Gestao.MPE.User_Control
{
    public partial class UCInscricaoEmpresaIA : UCBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulaEstado();
                this.PopulaEstadoContato();
                this.PopulaTipoEmpresa();
                this.PopulaCategoria();
                this.PopulaNivelEscolaridade();
                this.PopulaFaixaEtaria();
                this.PopulaCargo();
                this.PopulaAtividadeEconomica();
                this.PopulaCidade(0);
                this.PopulaCidadeContato(0);
                this.PopulaBairro(0);
                this.PopulaBairroContato(0);
                this.PopulaFaturamento(4);
                this.PopulaGrupo();
                HabilitaCampos(false);
            }
        }

        private void Show()
        {
            this.divUserControl.Visible = true;
        }

        private void Close()
        {
            this.divUserControl.Visible = false;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        public void Editar(int IdEmpresaCadastro)
        {
            this.HddnFldEmpresaCadastro.Value = IntUtils.ToString(IdEmpresaCadastro);
            this.Show();
        }

        public void Incluir()
        {
            this.HddnFldEmpresaCadastro.Value = "0";
            this.Show();
        }

        private void PopulaTipoEmpresa()
        {
            DrpDwnLstTipoEmpresa.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "Vazio";
            item.Value = "0";
            DrpDwnLstTipoEmpresa.Items.Add(item);

            foreach (EntTipoEmpresa objTipoEmpresa in new BllTipoEmpresa().ObterTodos())
            {
                item = new ListItem();
                item.Text = objTipoEmpresa.TipoEmpresa;
                item.Value = objTipoEmpresa.IdTipoEmpresa.ToString();

                DrpDwnLstTipoEmpresa.Items.Add(item);
            }

            DrpDwnLstTipoEmpresa.DataBind();
        }

        private void PopulaEstado()
        {
            DrpDwnLstEstado.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "Vazio";
            item.Value = "0";
            DrpDwnLstEstado.Items.Add(item);

            foreach (EntEstado objEstado in new BllEstado().ObterTodos())
            {
                item = new ListItem();
                item.Text = objEstado.Estado;
                item.Value = objEstado.IdEstado.ToString();

                DrpDwnLstEstado.Items.Add(item);
            }

            DrpDwnLstEstado.DataBind();
        }

        private void PopulaEstadoContato()
        {
            DrpDwnLstEstadoContato.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "Vazio";
            item.Value = "0";
            DrpDwnLstEstadoContato.Items.Add(item);

            foreach (EntEstado objEstado in new BllEstado().ObterTodos())
            {
                item = new ListItem();
                item.Text = objEstado.Estado;
                item.Value = objEstado.IdEstado.ToString();

                DrpDwnLstEstadoContato.Items.Add(item);
            }

            DrpDwnLstEstadoContato.DataBind();
        }

        private void PopulaCidade(Int32 IdEstado)
        {
            DrpDwnLstCidade.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "<< Selecione um Estado >>";
            item.Value = "0";
            DrpDwnLstCidade.Items.Add(item);

            if (IdEstado != 0)
            {
                foreach (EntCidade objCidade in new BllCidade().ObterCidadePorEstado(IdEstado))
                {
                    item = new ListItem();
                    item.Text = objCidade.Cidade;
                    item.Value = objCidade.IdCidade.ToString();

                    DrpDwnLstCidade.Items.Add(item);
                }
            }

            DrpDwnLstCidade.DataBind();
        }

        private void PopulaCidadeContato(Int32 IdEstado)
        {
            DrpDwnLstCidadeContato.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "<< Selecione um Estado >>";
            item.Value = "0";
            DrpDwnLstCidadeContato.Items.Add(item);

            if (IdEstado != 0)
            {
                foreach (EntCidade objCidade in new BllCidade().ObterCidadePorEstado(IdEstado))
                {
                    item = new ListItem();
                    item.Text = objCidade.Cidade;
                    item.Value = objCidade.IdCidade.ToString();

                    DrpDwnLstCidadeContato.Items.Add(item);
                }
            }

            DrpDwnLstCidadeContato.DataBind();
        }

        private void PopulaBairro(Int32 IdCidade)
        {
            DrpDwnLstBairro.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "<< Selecione uma Cidade >>";
            item.Value = "0";
            DrpDwnLstBairro.Items.Add(item);

            if (IdCidade != 0)
            {
                foreach (EntBairro objBairro in new BllBairro().ObterPorCidade(IdCidade))
                {
                    item = new ListItem();
                    item.Text = objBairro.Bairro;
                    item.Value = objBairro.IdBairro.ToString();

                    DrpDwnLstBairro.Items.Add(item);
                }
            }

            DrpDwnLstBairro.DataBind();
        }

        private void PopulaBairroContato(Int32 IdCidade)
        {
            DrpDwnLstBairroContato.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "<< Selecione uma Cidade >>";
            item.Value = "0";
            DrpDwnLstBairroContato.Items.Add(item);

            if (IdCidade != 0)
            {
                foreach (EntBairro objBairro in new BllBairro().ObterPorCidade(IdCidade))
                {
                    item = new ListItem();
                    item.Text = objBairro.Bairro;
                    item.Value = objBairro.IdBairro.ToString();

                    DrpDwnLstBairroContato.Items.Add(item);
                }
            }

            DrpDwnLstBairroContato.DataBind();
        }

        private void PopulaCategoria()
        {
            DrpDwnLstCategoria.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "Vazio";
            item.Value = "0";
            DrpDwnLstCategoria.Items.Add(item);

            foreach (EntCategoria objCategoria in new BllCategoria().ObterTodos())
            {
                item = new ListItem();
                item.Text = objCategoria.Categoria;
                item.Value = objCategoria.IdCategoria.ToString();

                DrpDwnLstCategoria.Items.Add(item);
            }

            DrpDwnLstCategoria.DataBind();
        }

        private void PopulaNivelEscolaridade()
        {
            DrpDwnLstNivelEscolaridade.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "Vazio";
            item.Value = "0";
            DrpDwnLstNivelEscolaridade.Items.Add(item);

            foreach (EntContatoNivelEscolaridade objContatoNivelEscolaridade in new BllContatoNivelEscolaridade().ObterTodos())
            {
                item = new ListItem();
                item.Text = objContatoNivelEscolaridade.ContatoNivelEscolaridade;
                item.Value = objContatoNivelEscolaridade.IdContatoNivelEscolaridade.ToString();

                DrpDwnLstNivelEscolaridade.Items.Add(item);
            }

            DrpDwnLstNivelEscolaridade.DataBind();
        }

        private void PopulaFaixaEtaria()
        {
            DrpDwnLstFaixaEtaria.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "Vazio";
            item.Value = "0";
            DrpDwnLstFaixaEtaria.Items.Add(item);

            foreach (EntContatoFaixaEtaria objContatoFaixaEtaria in new BllContatoFaixaEtaria().ObterTodos())
            {
                item = new ListItem();
                item.Text = objContatoFaixaEtaria.ContatoFaixaEtaria;
                item.Value = objContatoFaixaEtaria.IdContatoFaixaEtaria.ToString();

                DrpDwnLstFaixaEtaria.Items.Add(item);
            }

            DrpDwnLstFaixaEtaria.DataBind();
        }

        private void PopulaCargo()
        {
            DrpDwnLstCargo.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "Vazio";
            item.Value = "0";
            DrpDwnLstCargo.Items.Add(item);

            foreach (EntCargo objCargo in new BllCargo().ObterTodos())
            {
                item = new ListItem();
                item.Text = objCargo.Cargo;
                item.Value = objCargo.IdCargo.ToString();

                DrpDwnLstCargo.Items.Add(item);
            }

            DrpDwnLstCargo.DataBind();
        }

        private void PopulaAtividadeEconomica()
        {
            DrpDwnLstAtividadeEconomica.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "Vazio";
            item.Value = "0";
            DrpDwnLstAtividadeEconomica.Items.Add(item);

            foreach (EntAtividadeEconomica objAtividadeEconomica in new BllAtividadeEconomica().ObterTodos())
            {
                item = new ListItem();
                item.Text = objAtividadeEconomica.AtividadeEconomica;
                item.Value = objAtividadeEconomica.IdAtividadeEconomica.ToString();

                DrpDwnLstAtividadeEconomica.Items.Add(item);
            }

            DrpDwnLstAtividadeEconomica.DataBind();
        }

        private void PopulaFaturamento(Int32 IdTipoFaturamento)
        {
            DrpDwnLstFaturamento.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "Vazio";
            item.Value = "0";
            DrpDwnLstFaturamento.Items.Add(item);

            foreach (EntFaturamento objFaturamento in new BllFaturamento().ObterPorIdTipoFaturamento(IdTipoFaturamento))
            {
                item = new ListItem();
                item.Text = objFaturamento.Faturamento;
                item.Value = objFaturamento.IdFaturamento.ToString();

                DrpDwnLstFaturamento.Items.Add(item);
            }

            DrpDwnLstFaturamento.DataBind();
        }

        private void PopulaGrupo()
        {
            DrpDwnLstGrupo.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "Vazio";
            item.Value = "0";
            DrpDwnLstGrupo.Items.Add(item);

            foreach (EntGrupo objGrupo in new BllGrupo().ObterTodosAtivos())
            {
                item = new ListItem();
                item.Text = objGrupo.Grupo;
                item.Value = objGrupo.IdGrupo.ToString();

                DrpDwnLstGrupo.Items.Add(item);
            }

            DrpDwnLstCargo.DataBind();
        }

        protected void DrpDwnLstEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaCidade(StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue));
            this.PopulaBairro(StringUtils.ToInt(this.DrpDwnLstCidade.SelectedValue));
        }

        protected void DrpDwnLstCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaBairro(StringUtils.ToInt(this.DrpDwnLstCidade.SelectedValue));
        }

        protected void DrpDwnLstEstadoContato_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaCidadeContato(StringUtils.ToInt(this.DrpDwnLstEstadoContato.SelectedValue));
            this.PopulaBairroContato(StringUtils.ToInt(this.DrpDwnLstCidadeContato.SelectedValue));
        }

        protected void DrpDwnLstCidadeContato_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaBairroContato(StringUtils.ToInt(this.DrpDwnLstCidadeContato.SelectedValue));
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            EntEmpresaCadastro objEmpresaLogin = new BllEmpresaCadastro().ValidarEmpresa(this.TxtBxCNPJCPF.Text);
            if (objEmpresaLogin == null)
            {
                HabilitaCampos(true);
            }
            else
            {
                MessageBox(this.Page, "Empresa já cadastrada.");
            }
        }

        private void HabilitaCampos(Boolean valor)
        {
            this.tblDadosEmpresa.Visible = valor;
            this.DadosContato.Visible = valor;
            this.TesteAutoavaliacao.Visible = valor;
            this.DadosSenha.Visible = valor;
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        protected void ImgBttnConfirma_Click(object sender, ImageClickEventArgs e)
        {
            this.Gravar();
        }

        private void Gravar()
        {
            EntInscricoesEmpresa objInscricoesEmpresa = new EntInscricoesEmpresa();

            this.PageToObject(objInscricoesEmpresa);

            try
            {
                //Verifica se é Insert ou Update
                if (objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro == 0)
                {
                    objInscricoesEmpresa = new BllInscricoesEmpresa().Inserir(objInscricoesEmpresa);
                    MessageBox(this.Page, "Inscrição Empresa inserido com sucesso!");

                }
                else
                {
                    new BllInscricoesEmpresa().Alterar(objInscricoesEmpresa);
                    MessageBoxAlert(this.Page, "Inscrição Empresa alterado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar a Inscrição Empresa!");
            }
        }

        private void PageToObject(EntInscricoesEmpresa objInscricoesEmpresa)
        {
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro = StringUtils.ToInt(this.HddnFldEmpresaCadastro.Value);

            // Dados da Empresa
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.RazaoSocial = this.TxtBxRazaoSocial.Text;
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.NomeFantasia = this.TxtBxNomeFantasia.Text;
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.CPF_CNPJ = StringUtils.OnlyNumbers(this.TxtBxCNPJCPF.Text);
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.AberturaEmpresa = StringUtils.ToDate(this.TxtBxDataAbertura.Text);
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.PessoaJuridica = (StringUtils.OnlyNumbers(this.TxtBxCNPJCPF.Text).Length == 11); // provisorio
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.Ativo = true;
            objInscricoesEmpresa.TurmaEmpresa.NumeroFuncionario = StringUtils.ToInt(this.TxtBxNumeroEmpregados.Text);
            objInscricoesEmpresa.TurmaEmpresa.Endereco = this.TxtBxEndereco.Text;
            objInscricoesEmpresa.TurmaEmpresa.CEP = StringUtils.OnlyNumbers(this.TxtBxCEP.Text);
            objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomicaComplemento = this.TxtBxPrincipalAtividade.Text;
            objInscricoesEmpresa.TurmaEmpresa.TipoEmpresa.IdTipoEmpresa = StringUtils.ToInt(this.DrpDwnLstTipoEmpresa.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Faturamento.IdFaturamento = StringUtils.ToInt(this.DrpDwnLstFaturamento.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Categoria.IdCategoria = StringUtils.ToInt(this.DrpDwnLstCategoria.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomica.IdAtividadeEconomica = StringUtils.ToInt(this.DrpDwnLstAtividadeEconomica.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Estado.IdEstado = StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Cidade.IdCidade = StringUtils.ToInt(this.DrpDwnLstCidade.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Bairro.IdBairro = StringUtils.ToInt(this.DrpDwnLstBairro.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.Estado.IdEstado = StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma = new BllTurma().ObterTurmaAtiva(objPrograma.IdPrograma).IdTurma;
            // objInscricoesEmpresa.TurmaEmpresa. = this.RdBttnLstPergunta.SelectedValue;   ?????    nao tem por enquanto

            // Dados do Contato
            objInscricoesEmpresa.TurmaEmpresa.NomeContato = this.TxtBxNomeCompleto.Text;
            objInscricoesEmpresa.TurmaEmpresa.CPFContato = StringUtils.OnlyNumbers(this.TxtBxCPF.Text);
            objInscricoesEmpresa.TurmaEmpresa.CelularContato = StringUtils.OnlyNumbers(this.TxtBxCelular.Text);
            objInscricoesEmpresa.TurmaEmpresa.EmailContato = this.TxtBxEmail.Text;

            objInscricoesEmpresa.TurmaEmpresa.NascimentoContato = StringUtils.ToDate(this.TxtBxDtNascimento.Text);
            objInscricoesEmpresa.TurmaEmpresa.EnderecoContato = this.TxtBxEnderecoCompleto.Text;
            objInscricoesEmpresa.TurmaEmpresa.CEPContato = StringUtils.OnlyNumbers(this.TxtBxCEPContato.Text);
            objInscricoesEmpresa.TurmaEmpresa.TelefoneContato = StringUtils.OnlyNumbers(this.TxtBxTelefoneFixo.Text);
            objInscricoesEmpresa.TurmaEmpresa.Cargo.IdCargo = StringUtils.ToInt(this.DrpDwnLstCargo.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.EstadoContato.IdEstado = StringUtils.ToInt(this.DrpDwnLstEstadoContato.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.CidadeContato.IdCidade = StringUtils.ToInt(this.DrpDwnLstCidadeContato.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.BairroContato.IdBairro = StringUtils.ToInt(this.DrpDwnLstBairroContato.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.ContatoNivelEscolaridade.IdContatoNivelEscolaridade = StringUtils.ToInt(this.DrpDwnLstNivelEscolaridade.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.FaixaEtaria.IdContatoFaixaEtaria = StringUtils.ToInt(this.DrpDwnLstFaixaEtaria.SelectedValue);

            objInscricoesEmpresa.ProgramaEmpresa.Senha = StringUtils.EncryptPassword(this.TxtBxSenha.Text);
            objInscricoesEmpresa.ProgramaEmpresa.NomeResponsavel = this.TxtBxNomeCompleto.Text;
            objInscricoesEmpresa.ProgramaEmpresa.EmailResponsavel = this.TxtBxEmail.Text;
            objInscricoesEmpresa.ProgramaEmpresa.Programa.IdPrograma = objPrograma.IdPrograma;

            // Teste de AutoAvaliação
            objInscricoesEmpresa.TurmaEmpresa.Pergunta1 = StringUtils.ToBoolean(this.RdBttnLstPergunta1.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Pergunta2 = StringUtils.ToBoolean(this.RdBttnLstPergunta2.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Pergunta3 = StringUtils.ToBoolean(this.RdBttnLstPergunta3.SelectedValue);
            objInscricoesEmpresa.TurmaEmpresa.Pergunta4 = StringUtils.ToBoolean(this.RdBttnLstPergunta4.SelectedValue);
        }

        private void ObjectToPage(EntInscricoesEmpresa objInscricoesEmpresa)
        {
            // Dados da Empresa
            this.TxtBxRazaoSocial.Text = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.RazaoSocial;
            this.TxtBxNomeFantasia.Text = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.NomeFantasia;
            if (objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.PessoaJuridica)
            {
                this.TxtBxCNPJCPF.Text = FormatUtils.FormatCPF(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.CPF_CNPJ);
            }
            else
            {
                this.TxtBxCNPJCPF.Text = FormatUtils.FormatCPF(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.CPF_CNPJ);
            }


            this.TxtBxDataAbertura.Text = DateUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.AberturaEmpresa);
            this.TxtBxNumeroEmpregados.Text = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.NumeroFuncionario);
            this.TxtBxEndereco.Text = objInscricoesEmpresa.TurmaEmpresa.Endereco;
            this.TxtBxCEP.Text = objInscricoesEmpresa.TurmaEmpresa.CEP;
            this.TxtBxPrincipalAtividade.Text = objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomicaComplemento;
            this.DrpDwnLstTipoEmpresa.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.TipoEmpresa.IdTipoEmpresa);
            this.DrpDwnLstFaturamento.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Faturamento.IdFaturamento);
            this.DrpDwnLstCategoria.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Categoria.IdCategoria);
            this.DrpDwnLstAtividadeEconomica.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomica.IdAtividadeEconomica);
            this.DrpDwnLstEstado.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Estado.IdEstado);
            this.PopulaCidade(objInscricoesEmpresa.TurmaEmpresa.Estado.IdEstado);
            this.DrpDwnLstCidade.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Cidade.IdCidade);
            this.PopulaBairro(objInscricoesEmpresa.TurmaEmpresa.Cidade.IdCidade);
            this.DrpDwnLstBairro.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Bairro.IdBairro);
            this.DrpDwnLstEstado.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.Estado.IdEstado);
            // objInscricoesEmpresa.TurmaEmpresa. = this.RdBttnLstPergunta.SelectedValue;   ?????    nao tem por enquanto

            // Dados do Contato
            this.TxtBxNomeCompleto.Text = objInscricoesEmpresa.TurmaEmpresa.NomeContato;
            this.TxtBxCPF.Text = objInscricoesEmpresa.TurmaEmpresa.CPFContato;
            this.TxtBxCelular.Text = objInscricoesEmpresa.TurmaEmpresa.CelularContato;
            this.TxtBxEmail.Text = objInscricoesEmpresa.TurmaEmpresa.EmailContato;

            this.TxtBxDtNascimento.Text = DateUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.NascimentoContato);
            this.TxtBxEnderecoCompleto.Text = objInscricoesEmpresa.TurmaEmpresa.EnderecoContato;
            this.TxtBxCEPContato.Text = objInscricoesEmpresa.TurmaEmpresa.CEPContato;
            this.TxtBxTelefoneFixo.Text = objInscricoesEmpresa.TurmaEmpresa.TelefoneContato;
            this.DrpDwnLstCargo.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.Cargo.IdCargo);
            this.DrpDwnLstEstadoContato.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.EstadoContato.IdEstado);
            this.PopulaCidadeContato(objInscricoesEmpresa.TurmaEmpresa.EstadoContato.IdEstado);
            this.DrpDwnLstCidadeContato.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.CidadeContato.IdCidade);
            this.PopulaBairroContato(objInscricoesEmpresa.TurmaEmpresa.CidadeContato.IdCidade);
            this.DrpDwnLstBairroContato.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.BairroContato.IdBairro);
            this.DrpDwnLstNivelEscolaridade.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.ContatoNivelEscolaridade.IdContatoNivelEscolaridade);
            this.DrpDwnLstFaixaEtaria.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.TurmaEmpresa.FaixaEtaria.IdContatoFaixaEtaria);

            // Teste de AutoAvaliação
            this.RdBttnLstPergunta1.SelectedValue = BooleanUtils.ToInt(objInscricoesEmpresa.TurmaEmpresa.Pergunta1).ToString();
            this.RdBttnLstPergunta2.SelectedValue = BooleanUtils.ToInt(objInscricoesEmpresa.TurmaEmpresa.Pergunta2).ToString();
            this.RdBttnLstPergunta3.SelectedValue = BooleanUtils.ToInt(objInscricoesEmpresa.TurmaEmpresa.Pergunta3).ToString();
            this.RdBttnLstPergunta4.SelectedValue = BooleanUtils.ToInt(objInscricoesEmpresa.TurmaEmpresa.Pergunta4).ToString();

        }
    }
}