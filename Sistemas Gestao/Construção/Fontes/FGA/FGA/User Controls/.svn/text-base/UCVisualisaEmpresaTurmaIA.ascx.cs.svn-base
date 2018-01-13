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
    public partial class UCVisualisaEmpresaTurmaIA : UCBase
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCAlteraTurmaIA1.AtualizaGridEmpresasDelegate += this.AtualizaGridEmpresasDelegate;
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
            this.HddnFldTurma.Value = "0";
            this.HddnFldNomeTurma.Value = "";
        }

       
        private void PopulaEstado()
        {
            this.ddlEstado.Items.Clear();
            this.ddlEstado.DataSource = new BllEstado().ObterTodos();
            this.ddlEstado.DataBind();
            this.ddlEstado.Items.Add(new ListItem("Todos", "0"));
            this.ddlEstado.SelectedValue = "0";
        }

        private void PopulaCategoria()
        {
            this.ddlCategoria.Items.Clear();
            this.ddlCategoria.DataSource = new BllCategoria().ObterTodos();
            this.ddlCategoria.DataBind();
            this.ddlCategoria.Items.Add(new ListItem("Todas", "0"));
            this.ddlCategoria.SelectedValue = "0";
        }


        private void PopulaGridEmpresas()
        {
            Int32 IdTurma = StringUtils.ToInt(this.HddnFldTurma.Value.ToString());
            EntTurmaEmpresa objTurmaEmpresa = new EntTurmaEmpresa();
            objTurmaEmpresa.Turma.IdTurma = IdTurma;
            objTurmaEmpresa.EmpresaCadastro.NomeFantasia = TxtNome.Text;
            objTurmaEmpresa.EmpresaCadastro.CPF_CNPJ = TxtCnpjCpf.Text;
            objTurmaEmpresa.Estado.IdEstado = StringUtils.ToInt(ddlEstado.SelectedValue.ToString());
            objTurmaEmpresa.Categoria.IdCategoria = StringUtils.ToInt(ddlCategoria.SelectedValue.ToString());
            DateTime DataInicial = new DateTime(1753, 1, 1);
            populaGridSession(new BllTurmaEmpresa().ObterTodasInscritasPorFiltros(objTurmaEmpresa,0,0,"",0,null,null,null,null,DataInicial,DateTime.Now));
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
           // this.UCCadastroTurmaIAAddQuestionario.Inserir();
        }

        private void AtualizaGridEmpresasDelegate()
        {
            this.Show();
            populaGridSession((List<EntTurmaEmpresa>)Session["EmpresasAssociadasTurma"]);
        }

       

        private void populaGridSession(List<EntTurmaEmpresa> list)
        {
            Session["EmpresasAssociadasTurma"] = list;
            this.grdEmpresasCadastradas.DataSource = Session["EmpresasAssociadasTurma"];
            this.grdEmpresasCadastradas.DataBind();
        }


        private void Gravar()
        {
            
        }

       
        public void Visualizar(int IdTurma, string NomeTurma)
        {
            this.HddnFldTurma.Value = IdTurma.ToString();
            this.HddnFldNomeTurma.Value = NomeTurma;
            this.PopulaEstado();
            this.PopulaCategoria();
            
            PopulaGridEmpresas();
            
            this.Show();
        }

        

        protected void ImgBttnCancelar_Click1(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();

        }

        protected void ImgBttnGravar_Click1(object sender, ImageClickEventArgs e)
        {
            this.Gravar();
            this.Clear();
            this.Close();
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            PopulaGridEmpresas();
        }

        protected void grdEmpresasCadastradas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AlterarTurma")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idTurmaEmpresa = StringUtils.ToInt(((Label)this.grdEmpresasCadastradas.Rows[index].Cells[0].FindControl("lblIdEmpresaCadastro")).Text);
                string nomeEmpresa = ((Label)this.grdEmpresasCadastradas.Rows[index].Cells[3].FindControl("lblNomeEmpresa")).Text;
                string nomeTurma = this.HddnFldNomeTurma.Value.ToString();
                int IdTurma = StringUtils.ToInt(this.HddnFldTurma.Value.ToString());
                this.UCAlteraTurmaIA1.Alterar(IdTurma, idTurmaEmpresa, nomeEmpresa, nomeTurma);
            }
        }

        protected void grdEmpresasCadastradas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                EntTurmaEmpresa objTurmaEmpresa = new EntTurmaEmpresa();
                objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro = StringUtils.ToInt(((Label)this.grdEmpresasCadastradas.Rows[e.RowIndex].Cells[0].FindControl("lblIdEmpresaCadastro")).Text);
                objTurmaEmpresa.Turma.IdTurma = StringUtils.ToInt(this.HddnFldTurma.Value.ToString());

                Label lblAcaoAux = (Label)grdEmpresasCadastradas.Rows[e.RowIndex].FindControl("LblAcao");

                if (lblAcaoAux.Text == "True")
                {
                    objTurmaEmpresa.Ativo = false;
                }
                else
                {
                    objTurmaEmpresa.Ativo = true;
                }


                new BllTurmaEmpresa().AtivaDesativaEmpresaNaTurma(objTurmaEmpresa);
                this.PopulaGridEmpresas();

                
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar alterar!");
            }
        }

        protected void grdEmpresasCadastradas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnAcao = ((ImageButton)e.Row.FindControl("ImagBttnAcao"));

                String imageUrl;
                Label lblAcaoAux = (Label)e.Row.FindControl("LblAcao");
               

                if (lblAcaoAux.Text == "True")
                {
                    imageUrl = "~/Image/button_ok.gif";
                    btnAcao.ToolTip = "Ativa";
                }
                else
                {
                    imageUrl = "~/Image/button_cancel.gif";
                    btnAcao.ToolTip = "Inativa";
                }

                btnAcao.ImageUrl = imageUrl;

            }
        }//FAZER ALTERAR EMPRESA E TURMA SOH NO GRAVAR!!!!
        
    }
}