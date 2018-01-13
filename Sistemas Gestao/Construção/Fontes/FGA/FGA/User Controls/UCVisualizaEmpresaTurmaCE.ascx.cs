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
    public partial class UCVisualizaEmpresaTurmaIA : UCBase
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCAlteraTurmaIA1.AtualizaGridEmpresasDelegate += this.AtualizaGridEmpresasDelegate;
            this.UCCadastroEmpresaTurmaIA1.AtualizaGridEmpresasDelegate += this.AtualizaGridEmpresasDelegate;
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

            this.ddlEstado.DataSource = UsuarioLogado.lstEstadoPermitidos.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.Funcionalidade == this.Page.Title; });
            this.ddlEstado.DataBind();

            if (this.ddlEstado.Items.Count == 0)
            {
                this.ddlEstado.DataSource = new BllEstado().ObterTodos();
                this.ddlEstado.DataBind();
            }
        }

        private void PopulaCategoria()
        {
            this.ddlCategoria.Items.Clear();
            this.ddlCategoria.DataSource = new BllCategoria().ObterTodosFga(true);
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
            populaGridSession(new BllTurmaEmpresa().ObterTodasInscritasPorFiltros(objTurmaEmpresa));
        }

        private void AtualizaGridEmpresas()
        {
            this.grdEmpresasCadastradas.DataSource = Session["EmpresasAssociadasTurma"];
            this.grdEmpresasCadastradas.DataBind();
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
          int IdTurma = StringUtils.ToInt(this.HddnFldTurma.Value.ToString());
          int IdEstado = StringUtils.ToInt(this.HddnFldExibeEstado.Value.ToString());
          this.UCCadastroEmpresaTurmaIA1.Visualizar(IdTurma, IdEstado);
        }

        private void AtualizaGridEmpresasDelegate()
        {
            this.Show();
            PopulaGridEmpresas();
        }

       

        private void populaGridSession(List<EntTurmaEmpresa> list)
        {
            Session["EmpresasAssociadasTurma"] = list;
            this.grdEmpresasCadastradas.DataSource = Session["EmpresasAssociadasTurma"];
            this.grdEmpresasCadastradas.DataBind();
        }


        public void Visualizar(int IdTurma, string NomeTurma, int IdEstado)
        {
            ddlEstado.Visible = IdEstado == 0;
            lblEstado.Visible = IdEstado == 0;
            this.HddnFldExibeEstado.Value = IdEstado.ToString();
            this.lblTurma.Text = NomeTurma;
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
                    imageUrl = "~/Image/_file_Ok2.png";
                    btnAcao.ToolTip = "Ativa";
                }
                else
                {
                    imageUrl = "~/Image/file_delete2.png";
                    btnAcao.ToolTip = "Inativa";
                }

                btnAcao.ImageUrl = imageUrl;

            }
        }

        protected void grdEmpresasCadastradas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEmpresasCadastradas.PageIndex = e.NewPageIndex;
            this.AtualizaGridEmpresas();
        }
        
    }
}