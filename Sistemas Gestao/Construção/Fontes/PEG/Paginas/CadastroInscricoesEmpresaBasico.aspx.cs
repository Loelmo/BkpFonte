using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PEG.Pagina_Base;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;

namespace PEG.Paginas
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
                    this.Gravar(true);
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
            res &= Valida_TextBoxData(TxtBxDataAbertura);
            res &= Valida_TextBox(TxtBxNomeFantasia);
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
                if (objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.IdEmpresaCadastro == 0)
                {
                    MessageBox(this.Page, "Inscrição de Empresa inserida com sucesso!");
                }
                else
                {
                    MessageBox(this.Page, "Inscrição de Empresa alterada com sucesso!");
                }

                Response.Redirect("~/Paginas/Empresa/SelecionaTurma.aspx");
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar a Inscrição Empresa!");
            }
        }

        private EntInscricoesEmpresa PageToObject(Boolean Ativo)
        {
            EntInscricoesEmpresa objInscricoesEmpresa = new EntInscricoesEmpresa();
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.RazaoSocial = this.TxtBxRazaoSocial.Text;
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.NomeFantasia = this.TxtBxNomeFantasia.Text;
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.CPF_CNPJ = StringUtils.OnlyNumbers(this.TxtBxCNPJCPF.Text);
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.Estado.IdEstado = StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue);
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.AberturaEmpresa = StringUtils.ToDate(this.TxtBxDataAbertura.Text);
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.PessoaJuridica = (StringUtils.OnlyNumbers(this.TxtBxCNPJCPF.Text).Length == 14); // provisorio
            objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.Ativo = Ativo;
            objInscricoesEmpresa.ProgramaEmpresa.Senha = StringUtils.EncryptPassword(this.TxtBxSenha.Text);
            objInscricoesEmpresa.ProgramaEmpresa.NomeResponsavel = this.TxtBxNomeCompleto.Text;
            objInscricoesEmpresa.ProgramaEmpresa.EmailResponsavel = this.TxtBxEmail.Text;
            objInscricoesEmpresa.ProgramaEmpresa.Programa.IdPrograma = objPrograma.IdPrograma;

            return objInscricoesEmpresa;
        }


        private void ObjectToPage(EntInscricoesEmpresa objInscricoesEmpresa)
        {
            // Dados da Empresa
            this.TxtBxRazaoSocial.Text = objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.RazaoSocial;
            this.TxtBxNomeFantasia.Text = objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.NomeFantasia;
            if (objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.PessoaJuridica)
            {
                this.TxtBxCNPJCPF.Text = FormatUtils.FormatCPF(objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.CPF_CNPJ);
            }
            else
            {
                this.TxtBxCNPJCPF.Text = FormatUtils.FormatCPF(objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.CPF_CNPJ);
            }
            this.TxtBxDataAbertura.Text = DateUtils.ToString(objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.AberturaEmpresa);
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

            foreach (EntEstado objEstado in new BllEstado().ObterTodos())
            {
                item = new ListItem();
                item.Text = objEstado.Estado;
                item.Value = objEstado.IdEstado.ToString();

                DrpDwnLstEstado.Items.Add(item);
            }

            DrpDwnLstEstado.DataBind();
        }

    }
}