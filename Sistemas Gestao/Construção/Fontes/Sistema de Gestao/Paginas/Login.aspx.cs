using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.Common;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using Sistema_de_Gestao.Utilitarios;

namespace Sistema_de_Gestao
{
    public partial class Login : PaginaBase
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
            }
            this.objTurma = new EntTurma();

            this.objPrograma.IdPrograma = EntPrograma.PROGRAMA_MPE;

            lnkStyleSheet.Href = WebUtils.AplicaEstilo(objPrograma);
            lnkFavIcon.Href = WebUtils.AplicaFavIcon(objPrograma);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TxtBxLogin.Focus();
            }
        }

        protected void ImgBttnCancela_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Paginas/Principal.aspx");
        }

        protected void LnkBttnSenha_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.TxtBxLogin.Text.Substring(0, 1), "[A-Za-z]"))
            {
                //  EntAdmUsuario objUsuario = new BllAdmUsuario().ValidaUsuario(this.TxtBxLogin.Text);

                // Se o usuário não está cadastrado na base
                if (UsuarioLogado.IdUsuario == 0)
                {
                    MessageBox(this, "Usuário não encontrado!");
                }
                else
                {
                    this.LblMsgEmail.Text = "Sua solicitação será enviada para: " + UsuarioLogado.Email;
                    this.divEnviarEmail.Visible = true;


                    //   EnviaEmailAdm(objUsuario);
                }
            }
            else
            {
                String txCpfCnpj = StringUtils.OnlyNumbers(this.TxtBxLogin.Text);
                EmpresaLogada = new BllEmpresaCadastro().ValidarEmpresa(txCpfCnpj, objPrograma.IdPrograma);


                if (EmpresaLogada.IdEmpresaCadastro == 0)
                {
                    MessageBox(this, "Empresa não cadastrada!");
                }
                else
                {
                    this.LblMsgEmail.Text = "Sua solicitação será enviada para: " + EmpresaLogada.ProgramaEmpresa.EmailResponsavel;
                    this.divEnviarEmail.Visible = true;

                    //EnviaEmailEmp(EmpresaLogada);
                }

            }
        }

        protected void LNKBttnTrocarUsuario_Click(object sender, EventArgs e)
        {
            this.ImgBttnConfirma1.Visible = true;
            this.ImgBttnConfirma2.Visible = false;
            this.divSenha.Visible = false;
            TxtBxSenha.Text = "";
            TxtBxLogin.Enabled = true;
            TxtBxLogin.Text = "";
            TxtBxLogin.Focus();
            LNKBttnTrocarUsuario.Visible = false;
            LnkBttnSenha.Visible = false;
        }

        private Boolean EnviaEmailAdm(EntAdmUsuario objUsuario)
        {
            // Gerar senha
            String sNovaSenha = StringUtils.Random(8);
            objUsuario.Senha = StringUtils.EncryptPassword(sNovaSenha);

            //Altear a senha do usuário no banco
            new BllAdmUsuario().AlterarSenha(objUsuario);

            // Enviar email alertando para confirmar a alteração da senha.
            StringBuilder sMensagem = new StringBuilder();

            sMensagem.AppendLine("Prezado " + objUsuario.Usuario + ",");
            sMensagem.AppendLine();
            sMensagem.AppendLine("Essa é uma mensagem automática, por favor não responda.");
            sMensagem.AppendLine();
            sMensagem.AppendLine("Sua nova senha para o acesso ao sistema do Prêmio MPE Brasil 2011 é: " + sNovaSenha);
            sMensagem.AppendLine();
            sMensagem.AppendLine("Atenciosamente,");
            sMensagem.AppendLine();
            sMensagem.AppendLine("SEBRAE e Fundação Nacional da Qualidade (FNQ)");

            return WebUtils.EnviaEmail(objUsuario.Email, "Solicitação de senha MPE", sMensagem);
        }

        protected void ImgBttnConfirma1_Click(object sender, ImageClickEventArgs e)
        {
            ValidaUsuario();
        }

        private void ValidaUsuario()
        {
            if (Regex.IsMatch(this.TxtBxLogin.Text, "[A-Za-z]"))
            {
                // Administrativo
                UsuarioLogado = new BllAdmUsuario().ValidaUsuario(this.TxtBxLogin.Text);

                if (UsuarioLogado.IdUsuario == 0)
                {
                    MessageBox(this, "Usuário não encontrado!");
                    this.TxtBxLogin.Focus();
                }
                else
                {
                    this.ImgBttnConfirma1.Visible = false;
                    this.ImgBttnConfirma2.Visible = true;
                    this.divSenha.Visible = true;
                    TxtBxSenha.Focus();
                    TxtBxLogin.Enabled = false;
                    LNKBttnTrocarUsuario.Visible = true;
                    LnkBttnSenha.Visible = true;
                }
            }
            else
            {
                if (StringUtils.OnlyNumbers(this.TxtBxLogin.Text).Length == 11)
                {
                    // CPF

                    if (!StringUtils.ValidaCPF(StringUtils.OnlyNumbers(this.TxtBxLogin.Text)))
                    {
                        MessageBox(this, "CPF Inválido!");
                        TxtBxLogin.Focus();
                    }
                    else
                    {
                        ValidaEmpresa();
                    }
                }
                else if (StringUtils.OnlyNumbers(this.TxtBxLogin.Text).Length == 14)
                {
                    // CNPJ

                    if (!StringUtils.ValidaCNPJ(StringUtils.OnlyNumbers(this.TxtBxLogin.Text)))
                    {
                        MessageBox(this, "CNPJ Inválido!");
                        TxtBxLogin.Focus();
                    }
                    else
                    {
                        ValidaEmpresa();
                    }
                }
                else
                {
                    MessageBox(this, "CPF/CNPJ Inválido!");
                    TxtBxLogin.Focus();
                }
            }
        }

        private void ValidaEmpresa()
        {
            // Existe Empresa Cadastrada?
            EmpresaLogada = new BllEmpresaCadastro().ValidarEmpresa(StringUtils.OnlyNumbers(this.TxtBxLogin.Text), objPrograma.IdPrograma);


            if (EmpresaLogada.IdEmpresaCadastro == 0)
            {
                MessageBox(this, "Cadastro não encontrado!");
                FormsAuthentication.RedirectFromLoginPage("0", false);

                objTurma = new BllTurma().ObterTurmaAtiva(objPrograma.IdPrograma);
                Session["CpfCnpj"] = StringUtils.OnlyNumbers(TxtBxLogin.Text);
                //Response.Redirect("CadastroInscricoesEmpresa.aspx?IdEmpresaCadastro=0&CpfCnpj=" + StringUtils.OnlyNumbers(TxtBxLogin.Text) + "&acesso=" + 1);

                Response.Redirect("~/Paginas/CadastroInscricoesEmpresaBasico.aspx?IdEmpresaCadastro=0&CpfCnpj=" + StringUtils.OnlyNumbers(TxtBxLogin.Text));
            }
            else
            {
                this.ImgBttnConfirma1.Visible = false;
                this.ImgBttnConfirma2.Visible = true;
                this.divSenha.Visible = true;
                TxtBxSenha.Focus();
                TxtBxLogin.Enabled = false;
                LNKBttnTrocarUsuario.Visible = true;
                LnkBttnSenha.Visible = true;
            }
        }

        protected void ImgBttnConfirma2_Click(object sender, ImageClickEventArgs e)
        {
            this.EfetuaLogin(this.TxtBxLogin.Text, this.TxtBxSenha.Text);
        }

        private void EfetuaLogin(String sLogin, String sSenha)
        {
            if (Regex.IsMatch(this.TxtBxLogin.Text.Substring(0, 1), "[A-Za-z]"))
            {
                // Administrativo
                UsuarioLogado = new BllAdmUsuario().ValidaUsuario(this.TxtBxLogin.Text);

                if (UsuarioLogado.Senha == StringUtils.EncryptPassword(sSenha))
                {
                    FormsAuthentication.RedirectFromLoginPage(UsuarioLogado.IdUsuario.ToString(), false);

                    UsuarioLogado = new BllAdmUsuario().ObterPorPermissoes(UsuarioLogado.IdUsuario, objPrograma.IdPrograma);
                    EmpresaLogada = null;
                    Response.Redirect("~/Paginas/Principal.aspx");
                }
                else
                {
                    MessageBox(this, "Senha não confere!");
                    this.TxtBxSenha.Focus();
                }
            }
            else
            {
                // Empresa
                this.UsuarioLogado = null;
                EmpresaLogada = new BllEmpresaCadastro().ValidarEmpresa(StringUtils.OnlyNumbers(this.TxtBxLogin.Text), objPrograma.IdPrograma);

                if (EmpresaLogada.ProgramaEmpresa.Senha == StringUtils.EncryptPassword(sSenha))
                {
                    FormsAuthentication.RedirectFromLoginPage(EmpresaLogada.IdEmpresaCadastro.ToString(), false);
                    UsuarioLogado = null;

                    EntInscricoesEmpresa objInscricoesEmpresa = new BllInscricoesEmpresa().ObterPorIdEmpresaPrograma(EmpresaLogada.IdEmpresaCadastro, objPrograma.IdPrograma);

                    if (objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro > 0 && objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma > 0)
                    {
                        this.EmpresaLogada = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro;
                        this.objTurma = objInscricoesEmpresa.TurmaEmpresa.Turma;
                        Response.Redirect("~/Paginas/Principal.aspx");
                    }
                }
                else
                {
                    MessageBox(this, "Senha não confere!");
                    this.TxtBxSenha.Focus();
                }
            }
        }

        protected void ImgBttnEnviar_Click(object sender, ImageClickEventArgs e)
        {

            if (Regex.IsMatch(this.TxtBxLogin.Text, "[A-Za-z]"))
            {
                if (EnviaEmailAdm(UsuarioLogado))
                {
                    MessageBox(this, "E-mail enviado com sucesso.");
                    this.divEnviarEmail.Visible = false;
                }
                else
                {
                    MessageBox(this, "Erro no servidor de email!");
                }
            }
            else
                if (EnviaEmailEmp(EmpresaLogada))
                {
                    MessageBox(this, "E-mail enviado com sucesso.");
                    this.divEnviarEmail.Visible = false;
                }
                else
                {
                    MessageBox(this, "Erro no servidor de email!");
                }
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.divEnviarEmail.Visible = false;
        }

        protected void LnkBttnGestores_Click(object sender, EventArgs e)
        {
            this.divGestorEstadual.Visible = true;
        }

        protected void ImgBttnFechar_Click(object sender, ImageClickEventArgs e)
        {
            this.divGestorEstadual.Visible = false;
        }

        private Boolean EnviaEmailEmp(EntEmpresaCadastro objEmpresaCadastro)
        {
            // Gerar senha
            String sNovaSenha = StringUtils.Random(8);
            objEmpresaCadastro.ProgramaEmpresa = new BllProgramaEmpresa().ObterPorProgramaEmpresa(objPrograma.IdPrograma, objEmpresaCadastro.IdEmpresaCadastro);
            objEmpresaCadastro.ProgramaEmpresa.Senha = StringUtils.EncryptPassword(sNovaSenha);

            //Altear a senha do usuário no banco
            new BllProgramaEmpresa().Alterar(objEmpresaCadastro.ProgramaEmpresa);

            // Enviar email alertando para confirmar a alteração da senha.
            StringBuilder sMensagem = new StringBuilder();

            sMensagem.AppendLine("Prezado " + objEmpresaCadastro.ProgramaEmpresa.NomeResponsavel + " (Empresa " + FormatUtils.FormataCNPJ_CPF(objEmpresaCadastro.CPF_CNPJ) + "),");
            sMensagem.AppendLine();
            sMensagem.AppendLine("Essa é uma mensagem automática, por favor não responda.");
            sMensagem.AppendLine();
            sMensagem.AppendLine("Sua nova senha para o acesso ao sistema do Prêmio MPE Brasil 2011 é: " + sNovaSenha);
            sMensagem.AppendLine();
            sMensagem.AppendLine("Atenciosamente,");
            sMensagem.AppendLine();
            sMensagem.AppendLine("SEBRAE e Fundação Nacional da Qualidade (FNQ)");

            return WebUtils.EnviaEmail(objEmpresaCadastro.ProgramaEmpresa.EmailResponsavel, "Solicitação de senha MPE", sMensagem);

        }

    }
}