using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Vinit.SG.Common;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCCadastroUsuarioIA : UCBase
    {

        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid {get; set;}
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Show(EnumType.StateIA stateIA)
        {
            this.divUserControl.Visible = true;

            Boolean bPermissao;

            if (stateIA == EnumType.StateIA.Inserir)
            {
                bPermissao = ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Inserir);
            }
            else
            {
                bPermissao = ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar);
            }

            if (bPermissao)
            {
                EnableControl(this.PnlFundo.Controls, true);
                this.ImgBttnGravar.Visible = true;
            }
            else
            {
                EnableControl(this.PnlFundo.Controls, false);
                this.ImgBttnGravar.Visible = false;
            }

        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        protected void ImgBttnGravar_Click(object sender, ImageClickEventArgs e)
        {
            if (this.VerificaCamposObrigatoriosCadastro())
		    {
                if (this.Gravar())
                {
                    this.Clear();
                    this.Close();

                    if (atualizaGrid != null)
                    {
                        this.atualizaGrid();
                    }
                }
            }
            else
            {
                MessageBox(this.Page, "Favor preencher os campos obrigatórios (em destaque).");
            }
        }

        private Boolean VerificaCamposObrigatoriosCadastro()
        {
            Boolean res = true;
            res &= Valida_TextBox(TxtBxCPF);
            res &= Valida_TextBox(TxtBxNome);
            res &= Valida_TextBox(TxtBxLogin);
            res &= Valida_TextBox(TxtBxSenha);
            res &= Valida_TextBox(TxtBxConfSenha);
            res &= Valida_DropDownList(DrpDwnLstEstado);

            return res;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        private void EnableSenha(Boolean aValue)
        {
            this.lblSenha.Visible = aValue;
            this.lblConfSenha.Visible = aValue;
            this.divSenha.Visible = aValue;
            this.divConfSenha.Visible = aValue;
        }

        public void Editar(Int32 IdUsuario)
        {
            EntAdmUsuario objUsuario = new BllAdmUsuario().ObterPorId(IdUsuario);
            this.ObjectToPage(objUsuario);
            this.EnableSenha(false);
            this.Show(EnumType.StateIA.Alterar);
        }

        public void Inserir()
        {
            this.EnableSenha(true);
            this.PopulaEstado();
            this.ChckBxAtivo.Checked = true;
            this.Show(EnumType.StateIA.Inserir);
        }

        private void PageToObject(EntAdmUsuario objUsuario)
        {
            objUsuario.IdUsuario = StringUtils.ToInt(this.HddnFldIdUsuario.Value);
            objUsuario.Usuario = this.TxtBxNome.Text;
            objUsuario.Login = this.TxtBxLogin.Text;
            objUsuario.Senha = StringUtils.EncryptPassword(this.TxtBxSenha.Text);
            objUsuario.Estado.IdEstado = StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue);
            objUsuario.CPF = StringUtils.OnlyNumbers(this.TxtBxCPF.Text);
            objUsuario.Telefone = StringUtils.OnlyNumbers(this.TxtBxTelefone.Text);
            objUsuario.Email = this.TxtBxEmail.Text;
            objUsuario.Ativo = this.ChckBxAtivo.Checked;
        }
         
        private void ObjectToPage(EntAdmUsuario objUsuario)
        {
            this.HddnFldIdUsuario.Value = IntUtils.ToString(objUsuario.IdUsuario);
            this.TxtBxNome.Text = objUsuario.Usuario;
            this.TxtBxLogin.Text = objUsuario.Login;
            this.TxtBxSenha.Text = objUsuario.Senha;
            this.TxtBxCPF.Text = FormatUtils.FormatCPF(objUsuario.CPF);
            this.TxtBxTelefone.Text = FormatUtils.FormatTelefone(objUsuario.Telefone);
            this.TxtBxEmail.Text = objUsuario.Email;
            this.ChckBxAtivo.Checked = objUsuario.Ativo;

            this.PopulaEstado();
            this.DrpDwnLstEstado.SelectedValue = objUsuario.Estado.IdEstado.ToString();
        }

        private Boolean Gravar()
        {
            EntAdmUsuario objUsuario = new EntAdmUsuario();

            this.PageToObject(objUsuario);

            try
            {
                //Verifica se é Insert ou Update
                if (objUsuario.IdUsuario == 0)
                {
                    if (new BllAdmUsuario().ExisteUsuario(this.TxtBxLogin.Text))
                    {
                        MessageBox(this.Page, "Login já existente!");
                        return false;
                    }
                    else
                        if ((StringUtils.OnlyNumbers(this.TxtBxLogin.Text).Length) == (this.TxtBxLogin.Text.Length))
                        {
                            MessageBox(this.Page, "Login deve conter pelomenos uma letra!");
                            return false;
                        }
                        else
                            if (new BllAdmUsuario().ExisteCPF(StringUtils.OnlyNumbers(this.TxtBxCPF.Text)))
                            {
                                MessageBox(this.Page, "CPF já existente!");
                                return false;
                            }
                            else
                            {
                                objUsuario = new BllAdmUsuario().Inserir(objUsuario);
                                MessageBox(this.Page, "Usuário inserido com sucesso!");
                            }
                }
                else
                {
                    EntAdmUsuario objUsuarioAux = new BllAdmUsuario().ObterPorId(objUsuario.IdUsuario);

                    if (objUsuarioAux.Login != objUsuario.Login)
                    {
                        if (new BllAdmUsuario().ExisteUsuario(this.TxtBxLogin.Text))
                        {
                            MessageBox(this.Page, "Login já existente!");
                            return false;
                        }
                        else
                            if ((StringUtils.OnlyNumbers(this.TxtBxLogin.Text).Length) == (this.TxtBxLogin.Text.Length))
                            {
                                MessageBox(this.Page, "Login deve conter pelomenos uma letra!");
                                return false;
                            }
                    }
                    else
                    {
                        if (objUsuarioAux.CPF != objUsuario.CPF)
                        {
                            if (new BllAdmUsuario().ExisteCPF(StringUtils.OnlyNumbers(this.TxtBxCPF.Text)))
                            {
                                MessageBox(this.Page, "CPF já existente!");
                                return false;
                            }
                        }
                    }

                    new BllAdmUsuario().Alterar(objUsuario);
                    MessageBox(this.Page, "Usuário alterado com sucesso!");
                            
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar o Usuário!");
                return false;
                //logger.Error("Erro ao inserir o EntUsuario!", ex);
            }
                
        }

        private void PopulaEstado()
        {
            this.DrpDwnLstEstado.Items.Clear();

            this.DrpDwnLstEstado.DataSource = UsuarioLogado.lstEstadoPermitidos.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.Funcionalidade == this.Page.Title; });
            this.DrpDwnLstEstado.DataBind();

            if (this.DrpDwnLstEstado.Items.Count == 0)
            {
                this.DrpDwnLstEstado.DataSource = new BllEstado().ObterTodos();
                this.DrpDwnLstEstado.DataBind();
            }

            this.DrpDwnLstEstado.Items.Insert(0, new ListItem("<< Selecione um Estado >>", "0"));
            this.DrpDwnLstEstado.SelectedValue = "0";

        }


    }
}