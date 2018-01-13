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

namespace Sistema_de_Gestao.Paginas
{
    public partial class CadastroInscricoesEmpresaBasico : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulaEstado();
                if (Request["CpfCnpj"] != null)
                {
                    this.TxtBxCNPJCPF.Text = StringUtils.trataCpfCnpj(Request["CpfCnpj"]);
                    this.TxtBxCNPJCPF.Enabled = false;
                }

//                MessageBox(this, "Cadastro não localizado, faça sua Inscrição!");
            }
        }

        protected void ImgBtnProcessar_Click(object sender, ImageClickEventArgs e)
        {
                if (VerificaCamposObrigatorios())
                {
                    if (int.Parse(DrpDwnLstEstado.SelectedValue) == -1)
                    {
                        this.Gravar(false);
                    }
                    else
                    {
                        this.Gravar(true);
                    }
                }
                else
                {
                    MessageBox(this, "Favor preencher os campos obrigatórios (em destaque).");
                }
        }

        private Boolean VerificaCamposObrigatorios()
        {
            Boolean res = true;
            res = Valida_TextBox(TxtBxRazaoSocial);
            res &= Valida_DropDownList(DrpDwnLstEstado);
            res &= Valida_TextBox(TxtBxCNPJCPF);
            res &= Valida_TextBox(TxtBxNomeCompleto);
            res &= Valida_TextBoxSenha(TxtBxSenha, TxtBxConfSenha);
            res &= Valida_TextBox(TxtBxEmail);

            return res;
        }

        private void Gravar(Boolean Ativo)
        {

            EntInscricoesEmpresa objInscricoesEmpresa = this.PageToObject(Ativo);

            try
            {
                objInscricoesEmpresa = new BllInscricoesEmpresa().InserirAlterar(objInscricoesEmpresa, false);
                this.EmpresaLogada = objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro;
                //Verifica se é Insert ou Update
                Boolean DataPosterior = false;
                Boolean NumeroColaboradoresAbaixo = false;
                int Aviso = -1;
                DateTime dataComparacao = DateTime.Now;
                dataComparacao = dataComparacao.AddYears(-2);
                
                if (DataPosterior && NumeroColaboradoresAbaixo)
                {
                    Aviso = 1;
                }
                else if (DataPosterior)
                {
                    Aviso = 2;
                }
                else if (NumeroColaboradoresAbaixo)
                {
                    Aviso = 3;
                }
                else
                {
                    Aviso = 0;
                }

                if (Aviso > 0)
                {
                    Response.Redirect("~/Paginas/Principal.aspx?Aviso=" + Aviso);
                }
                else
                {
                    Response.Redirect("~/Paginas/Principal.aspx");
                }
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar a Inscrição Empresa!");
            }
        }

        private EntInscricoesEmpresa PageToObject(Boolean Ativo)
        {
            EntInscricoesEmpresa objInscricoesEmpresa = new EntInscricoesEmpresa();
            objInscricoesEmpresa.TurmaEmpresa = new EntTurmaEmpresa();
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.RazaoSocial = this.TxtBxRazaoSocial.Text;
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.NomeFantasia = "";
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.AberturaEmpresa = DateTime.MinValue;
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.CPF_CNPJ = StringUtils.OnlyNumbers(this.TxtBxCNPJCPF.Text);
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.Estado.IdEstado = StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue);
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.PessoaJuridica = (StringUtils.OnlyNumbers(this.TxtBxCNPJCPF.Text).Length == 14); // provisorio
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.Ativo = Ativo;
            objInscricoesEmpresa.ProgramaEmpresa.Senha = StringUtils.EncryptPassword(this.TxtBxSenha.Text);
            objInscricoesEmpresa.ProgramaEmpresa.NomeResponsavel = this.TxtBxNomeCompleto.Text;
            objInscricoesEmpresa.ProgramaEmpresa.EmailResponsavel = this.TxtBxEmail.Text;
            objInscricoesEmpresa.ProgramaEmpresa.Programa.IdPrograma = objPrograma.IdPrograma;

            objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro = objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro;
            objInscricoesEmpresa.TurmaEmpresa.NomeContato = this.TxtBxNomeCompleto.Text;
            objInscricoesEmpresa.TurmaEmpresa.EmailContato = this.TxtBxEmail.Text;
            objInscricoesEmpresa.TurmaEmpresa.Turma = objTurma;
            objInscricoesEmpresa.TurmaEmpresa.Ativo = true;
            objInscricoesEmpresa.TurmaEmpresa.Cadastro = DateTime.Now;
            objInscricoesEmpresa.TurmaEmpresa.UltimaAlteracao = DateTime.Now;
            objInscricoesEmpresa.TurmaEmpresa.ParticipaPrograma = true;

            return objInscricoesEmpresa;
        }


        private void ObjectToPage(EntInscricoesEmpresa objInscricoesEmpresa)
        {
            // Dados da Empresa
            this.TxtBxRazaoSocial.Text = objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.RazaoSocial;
            if (objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.PessoaJuridica)
            {
                this.TxtBxCNPJCPF.Text = FormatUtils.FormatCPF(objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.CPF_CNPJ);
            }
            else
            {
                this.TxtBxCNPJCPF.Text = FormatUtils.FormatCPF(objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.CPF_CNPJ);
            }
            this.DrpDwnLstEstado.SelectedValue = IntUtils.ToString(objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.Estado.IdEstado);

            // Dados do Contato
            this.TxtBxNomeCompleto.Text = objInscricoesEmpresa.ProgramaEmpresa.NomeResponsavel;
            this.TxtBxEmail.Text = objInscricoesEmpresa.ProgramaEmpresa.EmailResponsavel;

        }

        private void PopulaEstado()
        {
            DrpDwnLstEstado.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "<< Selecione um Estado >>";
            item.Value = "0";
            DrpDwnLstEstado.Items.Add(item);

            List<EntEstado> listEstado = new BllEstado().ObterEstadosPorTurma(objTurma.IdTurma, EntTipoEtapa.TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_EMPRESA);

            foreach (EntEstado objEstado in listEstado)
            {
                item = new ListItem();
                item.Text = objEstado.Estado;
                item.Value = objEstado.IdEstado.ToString();

                DrpDwnLstEstado.Items.Add(item);
            }
            if (listEstado.Count < 27)
            {
                item = new ListItem();
                item.Text = "Outros Estados";
                item.Value = "-1";

                DrpDwnLstEstado.Items.Add(item);
            }

            DrpDwnLstEstado.DataBind();
        }

    }
}