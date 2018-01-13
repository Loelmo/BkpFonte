using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.Common;
using Vinit.SG.Ent;

namespace Sistema_de_Gestao.Paginas
{
    public partial class GerenciarEtapaCE : PaginaBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (ValidaPermissaoBotao(this, EnumType.TipoAcao.Atualizar))
            {
                this.grdEtapaNacional.Columns[2].HeaderText = "Resumo";
            }
            else
            {
                this.grdEtapaNacional.Columns[2].HeaderText = "Visualizar";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulaTurma(this.Title);

                this.UCGerenciarEtapaIA1.atualizaGrid += this.AtualizaGridNacional;

                if (StringUtils.ToInt(Request["tipoEtapa"]) == 1 || objPrograma.IdPrograma == EntPrograma.PROGRAMA_FGA || objPrograma.IdPrograma == EntPrograma.PROGRAMA_PEG) // Nacional
                {
                    this.divEstado.Visible = false;
                }
                else // Estadual
                {
                    this.divEstado.Visible = true;
                }
            }
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

            this.DrpDwnLstEstado.Items.Insert(0, new ListItem("<< Selecione um Estado >>", "0"));
            this.DrpDwnLstEstado.SelectedValue = "0";

        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            if (StringUtils.ToInt(Request["tipoEtapa"]) == 1 || objPrograma.IdPrograma == EntPrograma.PROGRAMA_FGA || objPrograma.IdPrograma == EntPrograma.PROGRAMA_PEG) // Nacional
            {
                this.PopulaGridEtapasNacionais();
            }
            else
            {
                this.PopulaGridEtapasEstaduais();
            }
        }

        private void PopulaGridEtapasEstaduais()
        {
            ListaGrid = new BllEtapa().ObterEtapasEstaduais(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedItem.Value), StringUtils.ToInt(this.DrpDwnLstEstado.SelectedItem.Value), UsuarioLogado.IdUsuario);
            this.AtualizaGridNacional();
        }

        private void PopulaGridEtapasNacionais()
        {
            ListaGrid = new BllEtapa().ObterEtapasNacionais(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedItem.Value));
            this.AtualizaGridNacional();
        }

        
        private void AtualizaGridNacional()
        {
            this.grdEtapaNacional.DataSource = ListaGrid;
            this.grdEtapaNacional.DataBind();
        }

        protected void grdEtapaNacional_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdEtapaNacional.PageIndex = e.NewPageIndex;
            this.AtualizaGridNacional();
        }

        protected void grdEtapaNacional_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Resumo")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                this.UCGerenciarEtapaResumo1.VisualizarPorEtapa(index);
            }
        }

        protected void grdEtapaEstadual_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Boolean PermissaoExcluir = ValidaPermissaoBotao(this, EnumType.TipoAcao.Excluir);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnAcao = ((ImageButton)e.Row.FindControl("imgEditar"));

                String imageUrl;
                Label lblAcaoAux = (Label)e.Row.FindControl("LblAcaoEstadual");

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
            }
        }

        protected void grdEtapaNacional_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnAcao = ((ImageButton)e.Row.FindControl("ImagBttnAcao"));

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
            }
        }

        private void CriaResumo(EntEtapaResumo objEtapaResumo, EntEtapa item)
        {
            if (item.Ativo)
            {
                objEtapaResumo.Acao = StringUtils.Concatenar(EnumType.Tabela.EntEtapa, EnumType.TipoAcao.Ativar);
            }
            else
            {
                objEtapaResumo.Acao = StringUtils.Concatenar(EnumType.Tabela.EntEtapa, EnumType.TipoAcao.Inativar);
            }
            objEtapaResumo.AdmUsuario = UsuarioLogado;
            objEtapaResumo.DataCadastro = DateTime.Now;
            objEtapaResumo.Etapa = item;
        }
        
        protected void grdEtapaNacional_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            ImageButton btnAcao = ((ImageButton)grdEtapaNacional.Rows[e.RowIndex].FindControl("ImagBttnAcao"));
            Label lblAcaoAux = (Label)grdEtapaNacional.Rows[e.RowIndex].FindControl("LblIdEtapa");

            EntEtapa objEtapa = new BllEtapa().ObterPorId(int.Parse(lblAcaoAux.Text));
            objEtapa.Ativo = !objEtapa.Ativo;
            EntEtapaResumo objEtapResumo = new EntEtapaResumo();
            this.CriaResumo(objEtapResumo, objEtapa);
            try
            {
                new BllEtapa().AtivaDesativaEtapa(objEtapa, objEtapResumo);
                MessageBox(this.Page, "Etapa Alterada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar alterar Etapa!");
                //logger.Error("Erro ao inserir o EntUsuario!", ex);
            }

            if (StringUtils.ToInt(Request["tipoEtapa"]) == 1) // Nacional
            {
                this.PopulaGridEtapasNacionais();
            }
            else
            {
                this.PopulaGridEtapasEstaduais();
            }
            
        }

        protected void DrpDwnLstTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaEstado(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), this.Page.Title.ToString());
        }
    }
}