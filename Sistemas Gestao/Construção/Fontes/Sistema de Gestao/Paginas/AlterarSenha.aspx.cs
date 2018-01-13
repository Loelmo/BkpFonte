using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Vinit.SG.BLL;
using System.Text.RegularExpressions;

namespace Sistema_de_Gestao.Paginas
{
    public partial class AlterarSenha : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (UsuarioLogado.IdUsuario > 0)
                {
                    this.TxtBxLogin.Text = UsuarioLogado.Login;
                }
                else
                    if (EmpresaLogada.IdEmpresaCadastro > 0)
                    {
                        this.TxtBxLogin.Text = FormatUtils.FormataCNPJ_CPF(EmpresaLogada.CPF_CNPJ);
                    }
            }
        }

        protected void ImgBttnConfirma_Click(object sender, ImageClickEventArgs e)
        {

            if (Regex.IsMatch(this.TxtBxLogin.Text, "[A-Za-z]"))
            {
                // Administrativo
                EntAdmUsuario objUsuario = UsuarioLogado;

                if (objUsuario.Senha != StringUtils.EncryptPassword(this.TxtBxAntigaSenha.Text))
                {
                    MessageBox(this, "A senha antiga não confere!");
                }
                else
                {
                    this.Gravar(objUsuario);
                }
            }
            else
            {
                // Empresa

                if (this.TxtBxNovaSenha.Text.Length < 6)
                {
                    MessageBox(this, "A senha deve conter no minimo 6 caracteres!");
                }
                else
                {
                    EntProgramaEmpresa objProgramaEmpresa = new BllProgramaEmpresa().ObterPorProgramaEmpresa(objPrograma.IdPrograma, IdEmpresaLogada);

                    if (objProgramaEmpresa.Senha != StringUtils.EncryptPassword(this.TxtBxAntigaSenha.Text))
                    {
                        MessageBox(this, "A senha antiga não confere!");
                    }
                    else
                    {
                        this.GravarEmpresa(objProgramaEmpresa);
                    }
                }

            }


        }

        private void Gravar(EntAdmUsuario objUsuario)
        {
            this.PageToObject(objUsuario);

            try
            {

                new BllAdmUsuario().AlterarSenha(objUsuario);
                MessageBox(this.Page, "Senha alterada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar a Senha!");
                //logger.Error("Erro ao inserir o EntUsuario!", ex);
            }
        }

        private void GravarEmpresa(EntProgramaEmpresa objProgramaEmpresa)
        {
            objProgramaEmpresa.Senha = StringUtils.EncryptPassword(this.TxtBxNovaSenha.Text);

            try
            {
                new BllProgramaEmpresa().Alterar(objProgramaEmpresa);
                MessageBox(this.Page, "Senha alterada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar a Senha!");
                //logger.Error("Erro ao inserir o EntUsuario!", ex);
            }
        }

        protected void ImgBttnCancela_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Paginas/Principal.aspx");
        }

        private void PageToObject(EntAdmUsuario objUsuario)
        {
            objUsuario.Login = this.TxtBxLogin.Text;
            objUsuario.Senha = StringUtils.EncryptPassword(this.TxtBxNovaSenha.Text);
        }

    }
}