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
    public partial class UCCadastroGrupoUsuarioIA : UCBase
    {
        public delegate void AtualizaGrid(Int32 IdGrupo);
        public AtualizaGrid atualizaGrid { get; set; }

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
                EnableControl(this.PnlFundoIA.Controls, true);
                this.ImgBttnGravar.Visible = true;
            }
            else
            {
                EnableControl(this.PnlFundoIA.Controls, false);
                this.ImgBttnGravar.Visible = false;
            }
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundoIA.Controls);
            this.LstBxUsuariosAssociados.Items.Clear();
            this.LstBxUsuariosDisponiveis.Items.Clear();
        }

        protected void ImgBttnGravar_Click(object sender, ImageClickEventArgs e)
        {
            this.Gravar();
            this.Close();

            if (atualizaGrid != null)
            {
                this.atualizaGrid(StringUtils.ToInt(this.HddnFldIdGrupo.Value));
            }

            this.Clear();
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        public void Editar(Int32 IdGrupo, Int32 IdGrupoUsuario, String nomeGrupoAcesso)
        {
            legendaAssociacao.InnerText = "Alterar Associação - " + nomeGrupoAcesso;
            this.Clear();
            this.HddnFldIdGrupo.Value = IntUtils.ToString(IdGrupo);
            this.HddnFldIdGrupoUsuario.Value = IntUtils.ToString(IdGrupoUsuario);

            EntAdmGrupoRelUsuario objGrupoUsuario = new BllAdmGrupoRelUsuario().ObterPorId(IdGrupoUsuario);
            this.ObjectToPage(objGrupoUsuario);
            this.Show(EnumType.StateIA.Alterar);
        }

        public void Inserir(Int32 IdGrupo, String nomeGrupoAcesso)
        {
            legendaAssociacao.InnerText = "Nova Associação - " + nomeGrupoAcesso;
            this.HddnFldIdGrupo.Value = IntUtils.ToString(IdGrupo);

            this.PopulaTurma();
            this.PopulaEstado();
            this.PopulaEscritorioRegional(0,0);

            foreach (EntAdmUsuario objUsuario in new BllAdmUsuario().ObterTodos())
            {
                ListItem item = new ListItem();

                item.Text = objUsuario.Usuario;
                item.Value = IntUtils.ToString(objUsuario.IdUsuario);

                this.LstBxUsuariosDisponiveis.Items.Add(item);
            }

            this.Show(EnumType.StateIA.Inserir);
        }

        private void PageToObject(EntAdmGrupoRelUsuario objGrupoUsuario)
        {
            objGrupoUsuario.IdGrupoUsuario = StringUtils.ToInt(this.HddnFldIdGrupoUsuario.Value);
            objGrupoUsuario.AdmGrupo.IdGrupo = StringUtils.ToInt(this.HddnFldIdGrupo.Value);
            objGrupoUsuario.Turma.IdTurma = StringUtils.ToInt(DrpDwnLstTurma.SelectedValue);
            objGrupoUsuario.Estado.IdEstado = StringUtils.ToInt(DrpDwnLstEstado.SelectedValue);
            objGrupoUsuario.EscritorioRegional.IdEscritorioRegional = StringUtils.ToInt(DrpDwnLstEscritorioRegional.SelectedValue);
            objGrupoUsuario.Programa.IdPrograma = objPrograma.IdPrograma;

            foreach (ListItem item in LstBxUsuariosAssociados.Items)
            {
                EntAdmUsuario objUsuario = new EntAdmUsuario();
                objUsuario.IdUsuario = StringUtils.ToInt(item.Value);
                objUsuario.Usuario = item.Text;

                objGrupoUsuario.lstUsuarioAssociados.Add(objUsuario);
            }

            foreach (ListItem item in LstBxUsuariosDisponiveis.Items)
            {
                EntAdmUsuario objUsuario = new EntAdmUsuario();
                objUsuario.IdUsuario = StringUtils.ToInt(item.Value);
                objUsuario.Usuario = item.Text;

                objGrupoUsuario.lstUsuarioDisponiveis.Add(objUsuario);
            }
        }

        private void ObjectToPage(EntAdmGrupoRelUsuario objGrupoUsuario)
        {
            this.PopulaTurma();
            DrpDwnLstTurma.SelectedValue = objGrupoUsuario.Turma.IdTurma.ToString();
            this.PopulaEstado();
            DrpDwnLstEstado.SelectedValue = objGrupoUsuario.Estado.IdEstado.ToString();
            this.PopulaEscritorioRegional(objGrupoUsuario.Turma.IdTurma, objGrupoUsuario.Estado.IdEstado);
            DrpDwnLstEscritorioRegional.SelectedValue = objGrupoUsuario.EscritorioRegional.IdEscritorioRegional.ToString();

            foreach (EntAdmUsuario objUsuario in objGrupoUsuario.lstUsuarioAssociados)
            {
                ListItem item = new ListItem();

                item.Text = objUsuario.Usuario;
                item.Value = IntUtils.ToString(objUsuario.IdUsuario);

                this.LstBxUsuariosAssociados.Items.Add(item);
            }

            foreach (EntAdmUsuario objUsuario in objGrupoUsuario.lstUsuarioDisponiveis)
            {
                ListItem item = new ListItem();

                item.Text = objUsuario.Usuario;
                item.Value = IntUtils.ToString(objUsuario.IdUsuario);

                this.LstBxUsuariosDisponiveis.Items.Add(item);
            }

        }

        private void Gravar()
        {
            EntAdmGrupoRelUsuario objGrupoUsuario = new EntAdmGrupoRelUsuario();

            this.PageToObject(objGrupoUsuario);
            
            try
            {
                //Verifica se é Insert ou Update
                if (objGrupoUsuario.IdGrupoUsuario == 0)
                {
                    if (new BllAdmGrupoRelUsuario().ExisteAssociacao(ref objGrupoUsuario))
                    {
                        new BllAdmGrupoRelUsuario().InserirUsuarios(objGrupoUsuario);
                        MessageBox(this.Page, "Esta Associação já existe, os Usuários foram adicionados a ela!");
                    }
                    else
                    {
                        objGrupoUsuario = new BllAdmGrupoRelUsuario().Inserir(objGrupoUsuario);
                        MessageBox(this.Page, "Associação inserida com sucesso!");
                    }
                }
                else
                {
                    new BllAdmGrupoRelUsuario().Alterar(objGrupoUsuario);
                    MessageBox(this.Page, "Associação alterada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar a Associação!");
                //logger.Error("Erro ao inserir o EntUsuario!", ex);
            }
        }

        private void PopulaTurma()
        {
            DrpDwnLstTurma.Items.Clear();

            foreach (EntTurma objTurma in new BllTurma().ObterPorIdPrograma(objPrograma.IdPrograma))
            {
                ListItem item = new ListItem();
                item.Text = objTurma.Turma;
                item.Value = objTurma.IdTurma.ToString();

                DrpDwnLstTurma.Items.Add(item);
            }
            DrpDwnLstTurma.DataBind();
        }

        private void PopulaEstado()
        {
            this.DrpDwnLstEstado.Items.Clear();

            this.DrpDwnLstEstado.DataSource = new BllEstado().ObterTodos();
            this.DrpDwnLstEstado.DataBind();
            this.DrpDwnLstEstado.Items.Insert(0, new ListItem("Nacional", "0"));
            this.DrpDwnLstEstado.SelectedValue = "0";
        }

        private void PopulaEscritorioRegional(Int32 IdTurma, Int32 IdEstado)
        {
            DrpDwnLstEscritorioRegional.Items.Clear();
            ListItem item;

            //Insere Item Vazio
            item = new ListItem();
            item.Text = "Vazio";
            item.Value = "0";
            DrpDwnLstEscritorioRegional.Items.Add(item);

            foreach (EntEscritorioRegional objEscritorioRegional in new BllEscritorioRegional().ObterPorIdTurmaEstado(IdTurma, IdEstado))
            {
                item = new ListItem();
                item.Text = objEscritorioRegional.EscritorioRegional;
                item.Value = objEscritorioRegional.IdEscritorioRegional.ToString();

                DrpDwnLstEscritorioRegional.Items.Add(item);
            }

            DrpDwnLstEscritorioRegional.DataBind();
        }

        protected void BttnParaAssociados_Click(object sender, EventArgs e)
        {
            if (this.LstBxUsuariosDisponiveis.SelectedIndex != -1)
            {
                foreach (ListItem itemLista in LstBxUsuariosDisponiveis.Items)
                {
                    if (itemLista.Selected)
                    {
                        this.LstBxUsuariosAssociados.Items.Add(itemLista);
                    }
                }
                this.LstBxUsuariosAssociados.DataBind();

                for (int count = 0; LstBxUsuariosDisponiveis.Items.Count > count; count++)
                {
                    if (LstBxUsuariosDisponiveis.Items[count].Selected)
                    {
                        LstBxUsuariosDisponiveis.Items.RemoveAt(count);
                        count--;
                    }
                }
            }
            else
            {
               // MessageBoxAlert(this.Page, "Selecione um Usuári1o");
            }
        }

        protected void BttnParaDisponiveis_Click(object sender, EventArgs e)
        {
            if (this.LstBxUsuariosAssociados.SelectedIndex != -1)
            {
                foreach (ListItem itemLista in LstBxUsuariosAssociados.Items)
                {
                    if (itemLista.Selected)
                    {
                        this.LstBxUsuariosDisponiveis.Items.Add(itemLista);
                    }
                }
                this.LstBxUsuariosDisponiveis.DataBind();

                for (int count = 0; LstBxUsuariosAssociados.Items.Count > count; count++)
                {
                    if (LstBxUsuariosAssociados.Items[count].Selected)
                    {
                        LstBxUsuariosAssociados.Items.RemoveAt(count);
                        count--;
                    }
                }
            }
            else
            {
              //  MessageBoxAlert(this.Page, "Selecione um Usuári1o");
            }

            //EnableControls();
        }

        private void EnableControls()
        {
            this.DrpDwnLstTurma.Visible = true;
        }

        protected void DrpDwnLstEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaEscritorioRegional(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue));
        }

        protected void DrpDwnLstTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaEscritorioRegional(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue));
        }

    }
}