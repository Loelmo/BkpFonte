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
    public partial class UCSelecionaQuestionarioEmpresa : UCBase
    {
        public delegate void AtualizaGrid(Int32 IdGrupo);
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Show()
        {
            this.divQuestionarioControl.Visible = true;
        }

        public void Close()
        {
            this.divQuestionarioControl.Visible = false;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        protected void BtnResponder_Click(object sender, ImageClickEventArgs e)
        {
            this.Gravar();
            this.Close();

            this.Clear();
        }

        private void Gravar()
        {
            EntAdmGrupoRelUsuario objGrupoUsuario = new EntAdmGrupoRelUsuario();

            try
            {
                //Verifica se é Insert ou Update
                if (objGrupoUsuario.IdGrupoUsuario == 0)
                {
                    if (new BllAdmGrupoRelUsuario().ExisteAssociacao(ref objGrupoUsuario))
                    {
                        new BllAdmGrupoRelUsuario().InserirUsuarios(objGrupoUsuario);
                        MessageBoxAlert(this.Page, "Esta Associação já existe, os Usuários foram adicionados a ela!");
                    }
                    else
                    {
                        objGrupoUsuario = new BllAdmGrupoRelUsuario().Inserir(objGrupoUsuario);
                        MessageBoxAlert(this.Page, "Associação inserida com sucesso!");
                    }
                }
                else
                {
                    new BllAdmGrupoRelUsuario().Alterar(objGrupoUsuario);
                    MessageBoxAlert(this.Page, "Associação alterada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBoxError(this.Page, "Erro ao tentar Gravar a Associação!");
                //logger.Error("Erro ao inserir o Usuario!", ex);
            }
        }

    }
}