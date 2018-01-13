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


namespace PEG.FGA.User_Controls
{
    public partial class UCCadastroEmpresaTurmaIA : UCBase
    {
        public delegate void AtualizaGridEmpresas();
        public AtualizaGridEmpresas AtualizaGridEmpresasDelegate { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCIncluirPreCadastro1.AtualizaGridEmpresasDelegate += this.AtualizaGrid;
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
        }


        private void PopulaEstado()
        {
            this.ddlEstado.Items.Clear();
            this.ddlEstado.DataSource = new BllEstado().ObterTodos();
            this.ddlEstado.DataBind();
            this.ddlEstado.Items.Add(new ListItem("Todos", "0"));
            this.ddlEstado.SelectedValue = "0";
        }



        private void PopulaGridEmpresasInserir()
        {
            Int32 IdTurma = StringUtils.ToInt(this.HddnFldTurma.Value.ToString());
            String NomeFantasia = TxtNome.Text;
            String CPF_CNPJ = TxtCnpjCpf.Text;
            int IdEstado = StringUtils.ToInt(ddlEstado.SelectedValue.ToString());

            populaGridSession(new BllEmpresaCadastro().ObterNaoCadastradasNaTurma(CPF_CNPJ,NomeFantasia,IdEstado,IdTurma));
        }

        private void AtualizaGridInserir()
        {
            this.grdEmpresasNaoInscritas.DataSource = Session["EmpresasNaoInscritas"];
            this.grdEmpresasNaoInscritas.DataBind();
        }

              
        private void populaGridSession(List<EntEmpresaCadastro> list)
        {
            Session["EmpresasNaoInscritas"] = list;
            this.grdEmpresasNaoInscritas.DataSource = Session["EmpresasNaoInscritas"];
            this.grdEmpresasNaoInscritas.DataBind();
        }


        public void Visualizar(int IdTurma, int IdEstado)
        {
            this.HddnFldTurma.Value = IdTurma.ToString();
            this.HddnFldEstado.Value = IdEstado.ToString();
            ddlEstado.Visible = IdEstado == 0;
            lblEstado.Visible = IdEstado == 0;
            this.PopulaEstado();
            ddlEstado.SelectedItem.Value = IdEstado.ToString();
          
            PopulaGridEmpresasInserir();

            this.Show();
        }



        protected void ImgBttnCancelar_Click1(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();

        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            PopulaGridEmpresasInserir();
        }

        protected void ImgBttnGravar_Click(object sender, ImageClickEventArgs e)
        {
            AdcionarSelecionados();
            MessageBox(this.Page, "Empresas incluidas com sucesso!");
            AtualizaGridEmpresasDelegate();
            this.Clear();
            this.Close();

        }

        private void AtualizaGrid()
        {
            AtualizaGridEmpresasDelegate();
            this.Clear();
            this.Close();
        }

        private void AdcionarSelecionados()
        {
            EntTurmaEmpresa objTurmaEmpresa;
            foreach (GridViewRow item in this.grdEmpresasNaoInscritas.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {
                    objTurmaEmpresa = new EntTurmaEmpresa();
                    if (((CheckBox)item.Cells[1].Controls[1]).Checked)
                    {

                        objTurmaEmpresa.Ativo = true;
                        objTurmaEmpresa.Turma.IdTurma = StringUtils.ToInt(this.HddnFldTurma.Value.ToString());
                        objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro = StringUtils.ToInt(((Label)this.grdEmpresasNaoInscritas.Rows[item.DataItemIndex].Cells[0].FindControl("lblIdEmpresaCadastro")).Text);
                        objTurmaEmpresa.Status = 0;
                        objTurmaEmpresa.ParticipaPrograma = true;

                        new BllTurmaEmpresa().Inserir(objTurmaEmpresa);

                    }
                }
            }

        }

        protected void ImgBtnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCIncluirPreCadastro1.Visualizar(StringUtils.ToInt(this.HddnFldTurma.Value.ToString()), StringUtils.ToInt(this.HddnFldEstado.Value));
        }

        protected void grdEmpresasNaoInscritas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEmpresasNaoInscritas.PageIndex = e.NewPageIndex;
            this.AtualizaGridInserir();
        }

       
    }
}