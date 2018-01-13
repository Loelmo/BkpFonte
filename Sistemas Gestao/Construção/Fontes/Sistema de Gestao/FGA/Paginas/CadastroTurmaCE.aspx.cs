using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using Vinit.SG.Ent;

namespace Sistema_de_Gestao.FGA.Paginas
{
    public partial class CadastroTurmaCE : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulaEstado();
                this.Pesquisar();
                
            }
            this.UCCadastroTurmaIA.atualizaGrid += Pesquisar;
            
        }

        private void PopulaEstado()
        {
            this.ddlEstado.Items.Clear();
            this.ddlEstado.DataSource = new BllEstado().ObterTodos();
            this.ddlEstado.DataBind();
            this.ddlEstado.Items.Add(new ListItem("Todos", "0"));
            this.ddlEstado.SelectedValue = "0";
        }
              

        private void AtualizaGrid()
        {
            grdTurmas.DataSource = ListaGrid;
            grdTurmas.DataBind();
            grdTurmas.SelectedIndex = -1;
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            Pesquisar();
        }


        private void Pesquisar()
        {
            string sNome = this.txtNome.Text;
            int nEstado = StringUtils.ToInt(this.ddlEstado.SelectedValue);
            int nTipo = StringUtils.ToInt(this.ddlTipo.SelectedValue);
           
            DateTime dDataInicio = StringUtils.ToDate(this.txtDataInicio.Text);
            DateTime dDataFim = StringUtils.ToDateFim(this.txtDataFim.Text);

            List<EntTurma> lstTurma = new BllTurma().ObterPorFiltro(sNome, nEstado, nTipo, dDataInicio, dDataFim, objPrograma.IdPrograma, UsuarioLogado.IdUsuario);

            ListaGrid = lstTurma;
            AtualizaGrid();
        }

        protected void grdTurmas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnAcao = ((ImageButton)e.Row.FindControl("ImagBttnAcao"));

                String imageUrl;
                Label lblAcaoAux = (Label)e.Row.FindControl("LblAcao");
                Label lblTipoAux = (Label)e.Row.FindControl("lblTipo");

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

                if (lblTipoAux.Text == "False")
                {
                    lblTipoAux.Text = "Publica";
                }
                else 
                {
                    lblTipoAux.Text = "Privada";
                }
            }
        }

        protected void grdTurmas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                EntTurma objTurma = new EntTurma();
                objTurma.IdTurma = StringUtils.ToInt(((Label)this.grdTurmas.Rows[e.RowIndex].Cells[0].FindControl("lblIdTurma")).Text);

                Label lblAcaoAux = (Label)grdTurmas.Rows[e.RowIndex].FindControl("LblAcao");

                if (lblAcaoAux.Text == "True")
                {
                    objTurma.Ativo = false;
                }
                else
                {
                    objTurma.Ativo = true;
                }

                new BllTurma().AtivaDesativaTurma(objTurma);
                this.Pesquisar();

                MessageBox(this, "Turma alterada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox(this, "Erro ao tentar alterar!");
            }
        }

        protected void ImgBtnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCCadastroTurmaIA.Inserir();
        }

        protected void grdTurmas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataKey dk = this.grdTurmas.DataKeys[e.RowIndex];
            this.grdTurmas.SelectedIndex = -1;
            int idTurma = StringUtils.ToInt(((Label)this.grdTurmas.Rows[e.RowIndex].Cells[0].FindControl("lblIdTurma")).Text);
            this.UCCadastroTurmaIA.Editar(idTurma);
        }

        protected void grdTurmas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VizualizaEmpresas")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idTurma = StringUtils.ToInt(((Label)this.grdTurmas.Rows[index].Cells[0].FindControl("lblIdTurma")).Text);
                string nomeTurma = ((Label)this.grdTurmas.Rows[index].Cells[1].FindControl("lblNomeTurma")).Text;
                int idEstado = StringUtils.ToInt(((Label)this.grdTurmas.Rows[index].Cells[4].FindControl("lblIdEstado")).Text);

                this.UCVisualizaEmpresaTurmaCE.Visualizar(idTurma, nomeTurma, idEstado);
            }
            if (e.CommandName =="GerenciarEtapas")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idTurma = StringUtils.ToInt(((Label)this.grdTurmas.Rows[index].Cells[0].FindControl("lblIdTurma")).Text);
                this.UCGerenciarEtapaIA1.Editar(idTurma);
            }
        }

        protected void grdTurmas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTurmas.PageIndex = e.NewPageIndex;
            this.AtualizaGrid();
        }


    }
}