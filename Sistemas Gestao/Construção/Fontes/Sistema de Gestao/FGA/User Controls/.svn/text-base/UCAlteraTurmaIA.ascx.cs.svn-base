using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using System.IO;

namespace Sistema_de_Gestao.FGA.User_Controls
{
    public partial class UCAlteraTurmaIA : UCBase
    {
        public delegate void AtualizaGridEmpresas();
        public AtualizaGridEmpresas AtualizaGridEmpresasDelegate { get; set; }

        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        private void Show()
        {

            this.divUserControl.Visible = true;
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
            ddlTipo.SelectedValue = "2";

        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        public void Alterar(int IdTurma, int IdEmpresaCadastro, string NomeEmpresa, string NomeTurma)
        {
            this.HddnFldTurma.Value = IdTurma.ToString();
            this.HddnFldEmpresaCadastro.Value = IdEmpresaCadastro.ToString();
            txtEmpresa.Text = NomeEmpresa;
            txtTurma.Text = NomeTurma;
            PopularTurma();
            this.Show();
        }

        protected void ImgBttnGravar_Click1(object sender, ImageClickEventArgs e)
        {
            
            this.Close();
            this.AlterarEmpresaDeTurma();
            this.AtualizaGridEmpresasDelegate();
            this.Clear();
        }

        private void PopularTurma()
        {
            int IdTurma = StringUtils.ToInt(this.HddnFldTurma.Value.ToString());
            int TipoTurma = StringUtils.ToInt(this.ddlTipo.SelectedValue.ToString());
            this.ddlTurma.Items.Clear();
            this.ddlTurma.DataSource = new BllTurma().ObterTodasCompativeis(IdTurma, UsuarioLogado.IdUsuario);
            this.ddlTurma.DataBind();
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            PopularTurma();
        }

        private void AlterarEmpresaDeTurma()
        { 
            EntTurmaEmpresa objTurmaEmpresa = new EntTurmaEmpresa();
            objTurmaEmpresa.Turma.IdTurma = StringUtils.ToInt(this.HddnFldTurma.Value.ToString());
            objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro = StringUtils.ToInt(this.HddnFldEmpresaCadastro.Value.ToString());
            int IdTurmaDestino = StringUtils.ToInt(ddlTurma.SelectedItem.Value.ToString());
            if (new BllTurmaEmpresa().MudarTurma(objTurmaEmpresa, IdTurmaDestino))
            {
                List<EntTurmaEmpresa> lstTurmaEmpresa = (List<EntTurmaEmpresa>)Session["EmpresasAssociadasTurma"];

                for (int i = 0; i < lstTurmaEmpresa.Count; i++)
                {
                    if (lstTurmaEmpresa[i].EmpresaCadastro.IdEmpresaCadastro == objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro)
                    {
                        lstTurmaEmpresa.RemoveAt(i);
                        i--;
                    }
                }

                Session["EmpresasAssociadasTurma"] = lstTurmaEmpresa;
                MessageBox(this.Page, "Alteração de turma realizada com sucesso!");
            }
        }

    }
}