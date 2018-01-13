using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using PEG.Pagina_Base;

namespace PEG.Paginas
{
    public partial class CadastroGrupoEmpresaCE : PaginaBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (ValidaPermissaoBotao(this, EnumType.TipoAcao.Atualizar))
            {
                this.grdGrupo.Columns[7].HeaderText = "Alterar";
            }
            else
            {
                this.grdGrupo.Columns[7].HeaderText = "Visualizar";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulaTurma(this.Page.Title.ToString());
                this.PopulaSetor();
                this.Pesquisar();
            }
            this.UCCadastroGrupoEmpresaIA1.atualizaGrid += Pesquisar;
            this.ImgBttnIncluir.Visible = ValidaPermissaoBotao(this, EnumType.TipoAcao.Inserir);
        }

        protected void grdGrupo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataKey dk = this.grdGrupo.DataKeys[e.RowIndex];
            this.grdGrupo.SelectedIndex = -1;
            int idGrupo = StringUtils.ToInt(((Label)this.grdGrupo.Rows[e.RowIndex].Cells[0].FindControl("lblIdGrupo")).Text);
            this.UCCadastroGrupoEmpresaIA1.Editar(idGrupo, EnumType.StateIA.Alterar);
        }

        protected void grdGrupo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Copiar")
            {
                int idGrupo = Convert.ToInt32(e.CommandArgument);
                this.UCCadastroGrupoEmpresaIA1.Copiar(idGrupo);
            }
        }

        private void PopulaSetor()
        {
            this.ddlSetor.Items.Clear();
            this.ddlSetor.DataSource = new BllSetor().ObterTodos();
            this.ddlSetor.DataBind();
            this.ddlSetor.Items.Insert(0, new ListItem("Todos", "0"));
            this.ddlSetor.SelectedValue = "0";
        }

        protected void grdGrupo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGrupo.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            grdGrupo.DataSource = ListaGrid;
            grdGrupo.DataBind();
            grdGrupo.SelectedIndex = -1;
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            Pesquisar();
        }

        protected void grdGrupo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Boolean PermissaoExcluir = ValidaPermissaoBotao(this, EnumType.TipoAcao.Excluir);
            Boolean PermissaoIncluir = ValidaPermissaoBotao(this, EnumType.TipoAcao.Inserir);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnAcao = ((ImageButton)e.Row.FindControl("ImagBttnAcao"));
                ImageButton btnCopiar = ((ImageButton)e.Row.FindControl("ImagBttnCopiar"));

                String imageUrl;
                Label lblAcaoAux = (Label)e.Row.FindControl("LblAcao");

                if (lblAcaoAux.Text == "True")
                {
                    imageUrl = "~/Image/_file_Ok2.png";
                }
                else
                {
                    imageUrl = "~/Image/file_delete2.png";
                }

                btnAcao.ImageUrl = imageUrl;
                HabilitaDesabilitaBotao(btnAcao, PermissaoExcluir);
                HabilitaDesabilitaBotao(btnCopiar, PermissaoIncluir);
            }
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCCadastroGrupoEmpresaIA1.Inserir(EnumType.StateIA.Inserir);
        }

        private void Pesquisar()
        {
            String sGrupo = this.txtPesquisa.Text;
            Int32 nEstado = StringUtils.ToInt(this.DrpDwnLstEstado.SelectedItem.Value);
            Int32 nSetor = StringUtils.ToInt(this.ddlSetor.SelectedValue);
            Int32 nTurma = StringUtils.ToInt(this.DrpDwnLstTurma.SelectedItem.Value);
            Boolean bAtivo = this.ChckBxAtivo.Checked;

            List<EntGrupoEmpresa> lstGrupoEmpresa = new BllGrupoEmpresa().ObterPorFiltro(sGrupo, nEstado, nSetor, nTurma, bAtivo, IdUsuarioLogado, objPrograma.IdPrograma);

            ListaGrid = lstGrupoEmpresa;
            AtualizaGrid();
        }

        protected void grdGrupo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                EntGrupo objGrupo = new EntGrupo();
                objGrupo.IdGrupo = StringUtils.ToInt(((Label)this.grdGrupo.Rows[e.RowIndex].Cells[0].FindControl("lblIdGrupo")).Text);

                Label lblAcaoAux = (Label)grdGrupo.Rows[e.RowIndex].FindControl("LblAcao");

                if (lblAcaoAux.Text == "True")
                {
                    objGrupo.Ativo = false;
                }
                else
                {
                    objGrupo.Ativo = true;
                }

                new BllGrupo().AtivaDesativaGrupo(objGrupo);
                this.Pesquisar();
                Pesquisar();
                MessageBox(this, "Ação alterado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox(this, "Erro ao tentar alterar!");
            }
        }

        protected void DrpDwnLstTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaEstado(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), this.Page.Title.ToString());
        }

        public void PopulaTurma(String sFuncionalidade)
        {
            this.DrpDwnLstTurma.Items.Clear();

            this.DrpDwnLstTurma.DataSource = UsuarioLogado.lstTurmasPermitidas.FindAll(delegate(EntTurmasPermitidas objTurmasPermitidas) { return objTurmasPermitidas.Funcionalidade == sFuncionalidade; });
            this.DrpDwnLstTurma.DataBind();

            if (this.DrpDwnLstTurma.Items.Count == 1)
            {
                this.PopulaEstado(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), sFuncionalidade);
            }
        }

        private void PopulaEstado(Int32 IdTurma, String sFuncionalidade)
        {       
            this.DrpDwnLstEstado.Items.Clear();

            List<EntEstadosPermitidos> lstEstadosPermitidos1 = UsuarioLogado.lstEstadoPermitidos.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.IdTurma == IdTurma; });

            this.DrpDwnLstEstado.DataSource = lstEstadosPermitidos1.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.Funcionalidade == sFuncionalidade; });
            this.DrpDwnLstEstado.DataBind();

            if (this.DrpDwnLstEstado.Items.Count == 0)
            {
                //this.DrpDwnLstEstado.DataSource = UsuarioLogado.lstEstadoPermitidos.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.Funcionalidade == sFuncionalidade; });
                this.DrpDwnLstEstado.DataSource = new BllEstado().ObterTodos();
                this.DrpDwnLstEstado.DataBind();
            }

            this.DrpDwnLstEstado.Items.Insert(0, new ListItem("Todos", "0"));
            this.DrpDwnLstEstado.SelectedValue = "0";
         
        }
    }
}