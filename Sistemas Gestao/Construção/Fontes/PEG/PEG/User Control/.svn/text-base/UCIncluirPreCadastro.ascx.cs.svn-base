using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using System.Text;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using PEG.Utilitarios;

namespace PEG.FGA.User_Controls
{
    public partial class UCIncluirPreCadastro : UCBase
    {
        public delegate void AtualizaGridEmpresas();
        public AtualizaGridEmpresas AtualizaGridEmpresasDelegate { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool PessoaJuridica = false;
        private void PopulaEstado()
        {
            int IdEstado = StringUtils.ToInt(this.HddnFldEstado.Value);
            this.ddlEstado.Items.Clear();

            if (IdEstado == 0)
                this.ddlEstado.DataSource = new BllEstado().ObterTodos();
            else
            {
                EntEstado Estado =  new BllEstado().ObterPorId(IdEstado);
                this.ddlEstado.Items.Add(new ListItem(Estado.Estado, Estado.IdEstado.ToString()));
                this.ddlEstado.SelectedValue = Estado.IdEstado.ToString();
                Estado = null;
               
            }
           
            this.ddlEstado.DataBind();
            if (IdEstado == 0)
            {
                this.ddlEstado.Items.Add(new ListItem("Selecione", "0"));
                this.ddlEstado.SelectedValue = "0";
            }
        }

        protected void ImgBttnGravar_Click(object sender, ImageClickEventArgs e)
        {
            ValidaEmpresa();
           

        }

        protected void ValidaEmpresa()
        {
            if (TxtCnpjCpf.Text.Trim() == "")
            {
                MessageBox(this.Page, "Informe um CPF/CNPJ!");
                return;
            }
            if (TxtNome.Text.Trim() == "")
            {
                MessageBox(this.Page, "Informe um Nome!");
                return;
            }
            if (this.ddlEstado.SelectedValue == "0")
            {
                MessageBox(this.Page, "Selecione um Estado!");
                return;
            }
            if (TxtEmail.Text.Trim() == "")
            {
                MessageBox(this.Page, "Informe um E-mail!");
                return;
            }

            if (StringUtils.OnlyNumbers(this.TxtCnpjCpf.Text).Length != this.TxtCnpjCpf.Text.Length)
            {
               
                    MessageBox(this.Page, "CPF/CNPJ Invalido!");
                    return;
                   
            }
            else
            {
                if (StringUtils.OnlyNumbers(this.TxtCnpjCpf.Text).Length == 11)
                {
                    // CPF

                    if (!StringUtils.ValidaCPF(StringUtils.OnlyNumbers(this.TxtCnpjCpf.Text)))
                    {
                        MessageBox(this.Page, "CPF Inválido!");
                        return;
                    }
                }
                else
                {
                    // CNPJ

                    if (!StringUtils.ValidaCNPJ(StringUtils.OnlyNumbers(this.TxtCnpjCpf.Text)))
                    {
                        MessageBox(this.Page, "CNPJ Inválido!");
                        return;
                    }
                    PessoaJuridica = true;
                }
                // Existe Empresa Cadastrada?

              EntEmpresaCadastro  EmpresaLogada = new BllEmpresaCadastro().ValidarEmpresa(this.TxtCnpjCpf.Text, objPrograma.IdPrograma);


                if (EmpresaLogada.IdEmpresaCadastro == 0)
                {
                    IncluirPreCadastro();
                    
                }
                else
                {
                    MessageBox(this.Page, "Empresa ja cadastrada no sistema!");
                    return;
                }
            }
        }

        private void Show()
        {
            PopulaEstado();
            this.divUserControl.Visible = true;
        }

        public void Close()
        {
            this.divUserControl.Visible = false;

        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
            this.HddnFldTurma.Value = "0";
            this.HddnFldEstado.Value = "0";
            PessoaJuridica = false;
        }

        public void Visualizar(int IdTurma, int IdEstado)
        {
            this.HddnFldTurma.Value = IdTurma.ToString();
            this.HddnFldEstado.Value = IdEstado.ToString();
            this.Show();
        }


        protected void ImgBttnCancelar_Click1(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();

        }

        private void IncluirPreCadastro()
        {
            EntEmpresaCadastro Empresa = new EntEmpresaCadastro();
            EntTurmaEmpresa TurmaEmpresa = new EntTurmaEmpresa();
            EntProgramaEmpresa UsuarioResponsavel = new EntProgramaEmpresa();
            EntTurma Turma = new EntTurma();
            string Senha;
            try
            {
                Empresa.RazaoSocial = TxtNome.Text.Trim();
                Empresa.NomeFantasia = TxtNome.Text.Trim();
                Empresa.CPF_CNPJ = TxtCnpjCpf.Text.Trim();
                Empresa.PessoaJuridica = PessoaJuridica;
                Empresa.Ativo = true;
                Empresa.Estado.IdEstado = StringUtils.ToInt(ddlEstado.SelectedValue.ToString());
                Empresa.AberturaEmpresa = new DateTime(1753, 1, 1);

                Empresa = new BllEmpresaCadastro().Inserir(Empresa);
                if (Empresa.IdEmpresaCadastro > 0)
                {
                    Turma = new BllTurma().ObterPorId(StringUtils.ToInt(this.HddnFldTurma.Value.ToString()));

                    TurmaEmpresa.Ativo = true;
                    TurmaEmpresa.Turma = Turma;
                    TurmaEmpresa.EmpresaCadastro = Empresa;
                    TurmaEmpresa.Status = 0;
                    TurmaEmpresa.ParticipaPrograma = true;
                    new BllTurmaEmpresa().Inserir(TurmaEmpresa);


                    UsuarioResponsavel.NomeResponsavel = TxtNome.Text;
                    UsuarioResponsavel.Programa.IdPrograma = Turma.Programa.IdPrograma;
                    UsuarioResponsavel.EmpresaCadastro = Empresa;
                    UsuarioResponsavel.EmailResponsavel = TxtEmail.Text.Trim();
                    Senha = StringUtils.Random(4);
                    UsuarioResponsavel.Senha = StringUtils.EncryptPassword(Senha);

                    UsuarioResponsavel = new BllProgramaEmpresa().Inserir(UsuarioResponsavel);


                    // Enviar email alertando para confirmar a alteração da senha.
                    StringBuilder sMensagem = new StringBuilder();
                    String titulo = "";

                    sMensagem.AppendLine("Esta é uma Mensagem automática, não responda este e-mail.");
                    sMensagem.AppendLine();
                    if (objPrograma.IdPrograma == EntPrograma.PROGRAMA_FGA)
                    {
                        sMensagem.AppendLine("Você foi convidado a participar da turma " + Turma.Turma + " do Programa FGA");
                    }
                    else if (objPrograma.IdPrograma == EntPrograma.PROGRAMA_PEG)
                    {
                        sMensagem.AppendLine("Você foi convidado a participar da turma " + Turma.Turma + " do Programa PEG");
                    }
                    sMensagem.AppendLine("acesse o link  " + Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port) + "/Paginas/Login.aspx ");
                    sMensagem.AppendLine("informe o seu CPF/CNPJ e sua senha temporaria que é " + Senha);
                    sMensagem.AppendLine("para terminar o seu cadastro e completar a sua inscrição.");
                    sMensagem.AppendLine();
                    if (objPrograma.IdPrograma == EntPrograma.PROGRAMA_FGA)
                    {
                        sMensagem.AppendLine("Administração FGA.");
                        titulo = "Pré-Cadastro FGA";
                    }
                    else if (objPrograma.IdPrograma == EntPrograma.PROGRAMA_PEG)
                    {
                        sMensagem.AppendLine("Administração PEG.");
                        titulo = "Pré-Cadastro PEG";
                    }

                    WebUtils.EnviaEmail(TxtEmail.Text.Trim(), titulo, sMensagem);

                    MessageBox(this.Page, "O convite de participação da Turma foi enviada para o responsável pela empresa: " + TxtEmail.Text.Trim() + "\\nSe o e-mail estiver incorreto, contate o Gestor do Programa no seu Estado.");

                    this.Clear();
                    this.Close();
                    AtualizaGridEmpresasDelegate();
                
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


      
        


    }
}