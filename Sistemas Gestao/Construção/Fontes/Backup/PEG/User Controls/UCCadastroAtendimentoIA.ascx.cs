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
using System.Net;
using PEG.Utilitarios;
using System.Text;

namespace PEG.User_Controls
{
    public partial class UCCadastroAtendimentoIA : UCBase
    {

        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid {get; set;}
        

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void Show()
        {
            this.divUserControl.Visible = true;

            if (!ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar))
            {
                EnableControl(this.PnlFundo.Controls, false);
                this.ImgBttnGravar.Visible = false;
            }
            else
            {
                EnableControl(this.PnlFundo.Controls, true);
                this.ImgBttnGravar.Visible = true;
                this.ChckBxAtivo.Enabled = ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Excluir);
            }
        }

        public void Close()
        {
            this.Clear();
            this.divUserControl.Visible = false;
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Close();
        }

        protected void ImgBttnGravar_Click(object sender, ImageClickEventArgs e)
        {
            if (this.VerificaCamposObrigatoriosCadastro())
		    {
                if (this.Gravar())
                {
                    EnviaEmail();
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
            res &= Valida_TextBox(TxtBxNome);
            res &= Valida_TextBox(TxtBxDescricao);
            res &= Valida_DropDownList(DrpDwnLstStatus);
            res &= Valida_DropDownList(DrpDwnLstTipo);
            res &= Valida_DropDownList(DrpDwnLstSistema);
            
            return res;
        }

        private void EnviaEmail()
        {
            //WebUtils.EnviaEmail();
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        public void Editar(Int32 IdAtendimento)
        {
            EntAtendimento objAtendimento = new BllAtendimento().ObterPorId(IdAtendimento);
            this.ObjectToPage(objAtendimento);
            this.Show();
        }

        public void Inserir()
        {
            this.PopulaStatus();
            this.PopulaSistema();
            this.PopulaTipo();
            this.Show();
        }

        private void PageToObject(EntAtendimento objAtendimento)
        {
            objAtendimento.IdAtendimento = StringUtils.ToInt(this.HddnFldIdAtendimento.Value);
            objAtendimento.Programa.IdPrograma = this.objPrograma.IdPrograma;
            objAtendimento.Ativo = this.ChckBxAtivo.Checked;
            objAtendimento.Titulo = this.TxtBxNome.Text;
            objAtendimento.Descricao = this.TxtBxDescricao.Text;
            objAtendimento.DataAlteracao = DateTime.Now;
            objAtendimento.AtendimentoSistema.IdAtendimentoSistema = int.Parse(this.DrpDwnLstSistema.SelectedValue);
            objAtendimento.AtendimentoStatus.IdAtendimentoStatus = int.Parse(this.DrpDwnLstStatus.SelectedValue);
            objAtendimento.AtendimentoTipo.IdAtendimentoTipo = int.Parse(this.DrpDwnLstTipo.SelectedValue);
            objAtendimento.UsuarioOrigem.IdUsuario = UsuarioLogado.IdUsuario;
        }
         
        private void ObjectToPage(EntAtendimento objAtendimento)
        {
            this.HddnFldIdAtendimento.Value = IntUtils.ToString(objAtendimento.IdAtendimento);
            this.TxtBxNome.Text = objAtendimento.Titulo;
            this.TxtBxDescricao.Text = objAtendimento.Descricao;
            this.ChckBxAtivo.Checked = objAtendimento.Ativo;

            this.PopulaStatus();
            this.PopulaSistema();
            this.PopulaTipo();
            this.DrpDwnLstTipo.SelectedValue = objAtendimento.AtendimentoTipo.IdAtendimentoTipo.ToString();
            this.DrpDwnLstStatus.SelectedValue = objAtendimento.AtendimentoStatus.IdAtendimentoStatus.ToString();
            this.DrpDwnLstSistema.SelectedValue = objAtendimento.AtendimentoSistema.IdAtendimentoSistema.ToString();
        }

        private Boolean Gravar()
        {
            EntAtendimento objAtendimento = new EntAtendimento();

            this.PageToObject(objAtendimento);

            try
            {
                //Verifica se é Insert ou Update
                if (objAtendimento.IdAtendimento == 0)
                {
                    Int32 IdEstado = -1;
                    if (UsuarioLogado.IdUsuario > 0)
                    {
                        IdEstado = UsuarioLogado.Estado.IdEstado;
                    }
                    else
                    {
                        IdEstado = EmpresaLogada.Estado.IdEstado;
                    }
                    List<EntAdmUsuario> listUsuario = new BllAdmUsuario().ObterPorFuncionalidade(this.Page.Title, IdEstado, objPrograma.IdPrograma, objTurma.IdTurma);
                    if(listUsuario.Count == 0){
                        listUsuario = new BllAdmUsuario().ObterTodos();
                    }
                    objAtendimento.UsuarioResponsavel = listUsuario[0];
                    objAtendimento = new BllAtendimento().Inserir(objAtendimento);
                    StringBuilder sMensagem = new StringBuilder();

                    sMensagem.AppendLine("Essa é uma mensagem automática, por favor, não responda.");
                    sMensagem.AppendLine();
                    sMensagem.AppendLine("Foi criado um novo chamado, e o mesmo encontra-se designado para o seu usuário.");
                    sMensagem.AppendLine("Para verificar acesse o link: " + Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port) + "/Paginas/Login.aspx");
                    sMensagem.AppendLine();
                    sMensagem.AppendLine("Em caso de dúvida, contate o Gestor do Programa.");
                    sMensagem.AppendLine();
                    sMensagem.AppendLine("Administração PEG.");
                    WebUtils.EnviaEmail(objAtendimento.UsuarioResponsavel.Email, "Chamado de Atendimento PEG", sMensagem);
                    MessageBox(this.Page, "Atendimento inserido com sucesso!");
                }
                else
                {
                    new BllAtendimento().Alterar(objAtendimento);
                    MessageBox(this.Page, "Atendimento alterado com sucesso!");
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar o Atendimento!");
                return false;
            }
        }

        private void PopulaTipo()
        {
            this.DrpDwnLstTipo.Items.Clear();

            this.DrpDwnLstTipo.DataSource = new BllAtendimentoTipo().ObterTodos();
            this.DrpDwnLstTipo.DataBind();
            this.DrpDwnLstTipo.Items.Insert(0, new ListItem("<< Selecione >>", "0"));
            this.DrpDwnLstTipo.SelectedValue = "0";
        }

        private void PopulaStatus()
        {
            this.DrpDwnLstStatus.Items.Clear();

            this.DrpDwnLstStatus.DataSource = new BllAtendimentoStatus().ObterTodos();
            this.DrpDwnLstStatus.DataBind();
            this.DrpDwnLstStatus.Items.Insert(0, new ListItem("<< Selecione >>", "0"));
            this.DrpDwnLstStatus.SelectedValue = "0";
        }

        private void PopulaSistema()
        {
            this.DrpDwnLstSistema.Items.Clear();

            this.DrpDwnLstSistema.DataSource = new BllAtendimentoSistema().ObterTodos();
            this.DrpDwnLstSistema.DataBind();
            this.DrpDwnLstSistema.Items.Insert(0, new ListItem("<< Selecione >>", "0"));
            this.DrpDwnLstSistema.SelectedValue = "0";
        }
    }
}