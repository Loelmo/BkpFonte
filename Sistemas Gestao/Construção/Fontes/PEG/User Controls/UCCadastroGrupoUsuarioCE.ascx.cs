using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;

namespace PEG.User_Controls
{
    public partial class UCCadastroGrupoUsuarioCE : UCBase
    {
        public Object ListaGridIA
        {
            get
            {
                if (Session["ListaGridIA"] == null)
                {
                    Session["ListaGridIA"] = new List<Object>();
                }
                return Session["ListaGridIA"];
            }

            set { Session["ListaGridIA"] = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar))
            {
                this.grdGrupoUsuario.Columns[4].HeaderText = "Alterar";
            }
            else
            {
                this.grdGrupoUsuario.Columns[4].HeaderText = "Visualizar";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ImgBttnIncluir.Visible = ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Inserir);
            }

            this.UCCadastroGrupoUsuarioIA1.atualizaGrid += this.PopulaGridGrupoUsuario;
        }

        private void Show()
        {
            this.divUserControl.Visible = true;
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        public void Editar(Int32 IdAdmGrupo)
        {
            //this.Clear();
            this.HddnFldIdAdmGrupo.Value = IntUtils.ToString(IdAdmGrupo);
            this.PopulaGridGrupoUsuario(IdAdmGrupo);
            this.Show();
        }

        private void PopulaGridGrupoUsuario(Int32 IdAdmGrupo)
        {
            ListaGridIA = new BllAdmGrupoRelUsuario().ObterPorIdGrupo(IdAdmGrupo, this.objPrograma.IdPrograma, UsuarioLogado.IdUsuario);

            EntAdmGrupo objAdmGrupo = new BllAdmGrupo().ObterPorId(IdAdmGrupo);

            if (objAdmGrupo.IdGrupo > 0)
            {
                LblGrupo.Text = "Grupo de Acesso: " + objAdmGrupo.Grupo;
            }

            this.AtualizaGridGrupoUsuario();
        }

        private void AtualizaGridGrupoUsuario()
        {
            this.grdGrupoUsuario.DataSource = ListaGridIA;
            this.grdGrupoUsuario.DataBind();
            this.grdGrupoUsuario.SelectedIndex = -1;
        }

        protected void grdGrupoUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGrupoUsuario.PageIndex = e.NewPageIndex;
            AtualizaGridGrupoUsuario();
        }

        protected void grdGrupoUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Boolean PermissaoExcluir = ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Excluir);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnExcluir = ((ImageButton)e.Row.FindControl("ImgBttnExcluir"));
                btnExcluir.ToolTip = "Excluir";

                RegistraScriptExcluirGrid(this.Page, btnExcluir, "Confirma Exclusão?");

                HabilitaDesabilitaBotao(btnExcluir, PermissaoExcluir);

            }
        }

        protected void grdGrupoUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataKey dk = grdGrupoUsuario.DataKeys[e.RowIndex];
                new BllAdmGrupoRelUsuario().Excluir(ObjectUtils.ToInt(dk.Value));
                PopulaGridGrupoUsuario(StringUtils.ToInt(this.HddnFldIdAdmGrupo.Value));

                MessageBox(this.Page, "Registro excluido com sucesso!");
            }
            catch (Exception)
            {
                MessageBox(this.Page, "Erro ao tentar excluir o registro!");
            }
                        
        }

        protected void grdGrupoUsuario_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataKey dk = this.grdGrupoUsuario.DataKeys[e.RowIndex];
            this.grdGrupoUsuario.SelectedIndex = -1;
            this.UCCadastroGrupoUsuarioIA1.Editar(StringUtils.ToInt(this.HddnFldIdAdmGrupo.Value), ObjectUtils.ToInt(dk.Value), LblGrupo.Text.Remove(0, 17));
        }

        protected void grdGrupoUsuario_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCCadastroGrupoUsuarioIA1.Inserir(StringUtils.ToInt(this.HddnFldIdAdmGrupo.Value), LblGrupo.Text.Remove(0,17));
        }

        protected void ImgBttnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            this.Close();
        }
    }
}