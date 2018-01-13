using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using PEG.Pagina_Base;
using Vinit.SG.Ent;

namespace PEG
{
    public partial class CadastroEscritorioRegionalCE : PaginaBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (ValidaPermissaoBotao(this, EnumType.TipoAcao.Atualizar))
            {
                this.grdEscritorioRegional.Columns[3].HeaderText = "Alterar";
            }
            else
            {
                this.grdEscritorioRegional.Columns[3].HeaderText = "Visualizar";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulaTurma(this.Page.Title.ToString());
                this.PopulaGridEscritorioRegional();
                this.ImgBtnIncluir.Visible = ValidaPermissaoBotao(this, EnumType.TipoAcao.Inserir);
            }
            this.UCCadastroEscritorioRegionalIA1.atualizaGrid += this.PopulaGridEscritorioRegional;
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
                this.DrpDwnLstEstado.DataSource = new BllEstado().ObterTodos();
                this.DrpDwnLstEstado.DataBind();
            }

            this.DrpDwnLstEstado.Items.Insert(0, new ListItem("Todos", "0"));
            this.DrpDwnLstEstado.SelectedValue = "0";

        }

        private void PopulaGridEscritorioRegional()
        {

            EntEscritorioRegional objEscritorioRegional = new EntEscritorioRegional();

            objEscritorioRegional.EscritorioRegional = this.txtNome.Text;
            objEscritorioRegional.Turma.IdTurma = StringUtils.ToInt(this.DrpDwnLstTurma.SelectedItem.Value);
            objEscritorioRegional.Estado.IdEstado = StringUtils.ToInt(this.DrpDwnLstEstado.SelectedItem.Value);
            objEscritorioRegional.Ativo = this.ChckBxAtivo.Checked;
            objEscritorioRegional.Turma.Programa.IdPrograma = objPrograma.IdPrograma;

            ListaGrid = new BllEscritorioRegional().ObterAtivosPorFiltro(objEscritorioRegional,  UsuarioLogado.IdUsuario);
            this.AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            grdEscritorioRegional.DataSource = ListaGrid;
            grdEscritorioRegional.DataBind();
            this.grdEscritorioRegional.SelectedIndex = -1;
        }

        protected void grdEscritorioRegional_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEscritorioRegional.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        protected void grdEscritorioRegional_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Boolean PermissaoExcluir = ValidaPermissaoBotao(this, EnumType.TipoAcao.Excluir);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnAlterar = ((ImageButton)e.Row.FindControl("imgEditar"));
                btnAlterar.ToolTip = "Alterar Escritório Regional";

                ImageButton btnAtivo = ((ImageButton)e.Row.FindControl("imgExcluir"));
                btnAtivo.ToolTip = "Ativar e Inativar";

                RegistraScriptExcluirGridMensagemLabel(this, btnAtivo, hddMensagem.ClientID);

                String imageUrl;
                Label lblAtivoAux = (Label)e.Row.FindControl("LblAtivo");

                if (lblAtivoAux.Text == "True")
                {
                    imageUrl = "~/Image/_file_Ok2.png";
                    hddMensagem.Value = "Confirma Inativação?";
                }
                else
                {
                    imageUrl = "~/Image/file_delete.png";
                    hddMensagem.Value = "Confirma Ativação?";
                }

                btnAtivo.ImageUrl = imageUrl;
                HabilitaDesabilitaBotao(btnAtivo, PermissaoExcluir);
            }
        }

        protected void grdEscritorioRegional_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataKey dk = grdEscritorioRegional.DataKeys[e.RowIndex];
                EntEscritorioRegional EscritorioRegional = new BllEscritorioRegional().ObterPorId(ObjectUtils.ToInt(dk.Value));
                new BllEscritorioRegional().Excluir(EscritorioRegional);

                this.PopulaGridEscritorioRegional();
                MessageBox(this, "Escritório Regional alterado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox(this, "Erro ao tentar alterar!");
            }

        }

        protected void grdEscritorioRegional_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataKey dk = grdEscritorioRegional.DataKeys[e.RowIndex];
            this.grdEscritorioRegional.SelectedIndex = -1;
            this.UCCadastroEscritorioRegionalIA1.Editar(ObjectUtils.ToInt(dk.Value));
        }

        protected void grdEscritorioRegional_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grdEscritorioRegional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdEscritorioRegional_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridEscritorioRegional();
        }

        protected void ImgBtnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCCadastroEscritorioRegionalIA1.Incluir();
        }

        protected void DrpDwnLstTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaEstado(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), this.Page.Title.ToString());
        }
    }
}