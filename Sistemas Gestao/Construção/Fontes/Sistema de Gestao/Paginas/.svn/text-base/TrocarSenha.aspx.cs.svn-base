using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using System.Text;
using Sistema_de_Gestao.Utilitarios;
using Sistema_de_Gestao.Pagina_Base;

namespace Sistema_de_Gestao.Paginas
{
    public partial class TrocarSenha : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UserCD"] != null && Request.QueryString["Tipo"] != null)
            {
                int UserCD = int.Parse(Request.QueryString["UserCD"]);
                int Programa = int.Parse(Request.QueryString["Programa"]);
                String Tipo = Request.QueryString["Tipo"];

                if (Tipo == "Adm")
                {
                    EntAdmUsuario objUsuario = new BllAdmUsuario().ObterPorId(UserCD);

                    if (objUsuario.IdUsuario == 0)
                    {
                        MessageBox(this, "Usuário não encontrado.");
                    }
                    else
                    {
                        // Gerar senha
                        String sNovaSenha = StringUtils.Random(8);
                        objUsuario.Senha = StringUtils.EncryptPassword(sNovaSenha);

                        //Altear a senha do usuário no banco
                        new BllAdmUsuario().AlterarSenha(objUsuario);

                        // Enviar outro email contendo a senha
                        StringBuilder sMensagem = new StringBuilder();

                        sMensagem.AppendLine("Essa é uma mensagem automática, por favor, não responda.");
                        sMensagem.AppendLine();
                        sMensagem.AppendLine("Sua nova senha é: " + sNovaSenha);
                        sMensagem.AppendLine("Acesse o link " + Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port) + "/Paginas/Login.aspx para efetuar o login");
                        sMensagem.AppendLine();
                        sMensagem.AppendLine("Administração MPE.");

                        WebUtils.EnviaEmail(objUsuario.Email, "Solicitação de senha MPE", sMensagem);

                        MessageBox(this, "Sua nova senha foi enviada para: " + objUsuario.Email);
                    }
                }
                else if (Tipo == "Empresa")
                {

                    EntInscricoesEmpresa objUsuario = new BllInscricoesEmpresa().ObterPorIdEmpresaPrograma(UserCD, Programa);
                    
                    if (objUsuario.ProgramaEmpresa.IdProgramaEmpresa == 0)
                    {
                        MessageBox(this, "Usuário não encontrado.");
                    }
                    else
                    {
                        // Gerar senha
                        String sNovaSenha = StringUtils.Random(8);
                        objUsuario.ProgramaEmpresa.Senha = StringUtils.EncryptPassword(sNovaSenha);

                        //Altear a senha do usuário no banco
                        new BllProgramaEmpresa().Alterar(objUsuario.ProgramaEmpresa);

                        // Enviar outro email contendo a senha
                        StringBuilder sMensagem = new StringBuilder();

                        sMensagem.AppendLine("Essa é uma mensagem automática, por favor, não responda.");
                        sMensagem.AppendLine();
                        sMensagem.AppendLine("Sua nova senha é: " + sNovaSenha);
                        sMensagem.AppendLine("Acesse o link " + Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port) + "/Paginas/Login.aspx para efetuar o login");
                        sMensagem.AppendLine();
                        sMensagem.AppendLine("Administração MPE.");

                        WebUtils.EnviaEmail(objUsuario.ProgramaEmpresa.EmailResponsavel, "Solicitação de senha MPE", sMensagem);

                        MessageBox(this, "Sua nova senha foi enviada para: " + objUsuario.ProgramaEmpresa.EmailResponsavel);
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "window.close();", true);
        }
    }
}