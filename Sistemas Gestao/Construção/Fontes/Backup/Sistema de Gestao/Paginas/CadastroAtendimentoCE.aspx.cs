using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.Ent;

namespace Sistema_de_Gestao
{
    public partial class CadastroAtendimentoCE : PaginaBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (ValidaPermissaoBotao(this, EnumType.TipoAcao.Atualizar))
            {
                this.grdAtendimento.Columns[8].HeaderText = "Alterar";
            }
            else
            {
                this.grdAtendimento.Columns[8].HeaderText = "Visualizar";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EntAtendimento objAtendimento = new EntAtendimento();
                this.PopulaEstado();
                this.PopulaTipo();
                this.PopulaStatus();
                this.PopulaSistema();

                this.PageToObject(objAtendimento);

                this.PopulaGridAtendimento();
                this.ImgBttnIncluir.Visible = ValidaPermissaoBotao(this, EnumType.TipoAcao.Inserir);
            }
            this.UCCadastroAtendimentoIA1.atualizaGrid += this.PopulaGridAtendimento;
        }

        private void AtualizaGrid()
        {
            this.grdAtendimento.DataSource = ListaGrid;
            this.grdAtendimento.DataBind();
            this.grdAtendimento.SelectedIndex = -1;
        }

        
        private void PopulaGridAtendimento()
        {
            EntAtendimento objAtendimento = new EntAtendimento();

            this.PageToObject(objAtendimento);

            if (UsuarioLogado.IdUsuario > 0)
            {
                ListaGrid = new BllAtendimento().ObterPorFiltro(objAtendimento);
            }
            else
            {
                objAtendimento.EmpresaOrigem.IdEmpresaCadastro = EmpresaLogada.IdEmpresaCadastro;
                ListaGrid = new BllAtendimento().ObterPorFiltroEmpresa(objAtendimento);
            }
            this.AtualizaGrid();
        }

        private void PopulaEstado()
        {
            this.DrpDwnLstEstado.Items.Clear();

            this.DrpDwnLstEstado.DataSource = new BllEstado().ObterTodos();
            this.DrpDwnLstEstado.DataBind();
            this.DrpDwnLstEstado.Items.Insert(0, new ListItem("<< Todos >>", "0"));
            this.DrpDwnLstEstado.SelectedValue = "0";
        }

        private void PopulaTipo()
        {
            this.DrpDwnLstTipo.Items.Clear();

            this.DrpDwnLstTipo.DataSource = new BllAtendimentoTipo().ObterTodos();
            this.DrpDwnLstTipo.DataBind();
            this.DrpDwnLstTipo.Items.Insert(0, new ListItem("<< Todos >>", "0"));
            this.DrpDwnLstTipo.SelectedValue = "0";
        }

        private void PopulaStatus()
        {
            this.DrpDwnLstStatus.Items.Clear();

            this.DrpDwnLstStatus.DataSource = new BllAtendimentoStatus().ObterTodos();
            this.DrpDwnLstStatus.DataBind();
            this.DrpDwnLstStatus.Items.Insert(0, new ListItem("<< Todos >>", "0"));
            this.DrpDwnLstStatus.SelectedValue = "0";
        }

        private void PopulaSistema()
        {
            this.DrpDwnLstSistema.Items.Clear();

            this.DrpDwnLstSistema.DataSource = new BllAtendimentoSistema().ObterTodos();
            this.DrpDwnLstSistema.DataBind();
            this.DrpDwnLstSistema.Items.Insert(0, new ListItem("<< Todos >>", "0"));
            this.DrpDwnLstSistema.SelectedValue = "0";
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCCadastroAtendimentoIA1.Inserir();
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridAtendimento();
        }

        private void PageToObject(EntAtendimento objAtendimento)
        {
            objAtendimento.Titulo = this.TxtBxTitulo.Text;
            try
            {
                objAtendimento.IdAtendimento = int.Parse(this.TxtBxNumeroAtendimento.Text);
            }
            catch { }
            objAtendimento.UsuarioResponsavel.Usuario = this.TxtBxUsuarioResponsavel.Text;
            objAtendimento.IdEstado = int.Parse(this.DrpDwnLstEstado.SelectedValue);
            objAtendimento.AtendimentoSistema.IdAtendimentoSistema = int.Parse(this.DrpDwnLstSistema.SelectedValue);
            objAtendimento.AtendimentoStatus.IdAtendimentoStatus = int.Parse(this.DrpDwnLstStatus.SelectedValue);
            objAtendimento.AtendimentoTipo.IdAtendimentoTipo = int.Parse(this.DrpDwnLstTipo.SelectedValue);
            objAtendimento.DataCadastroFiltroInicial = StringUtils.ToDate(this.TxtBxDataInicio.Text);
            objAtendimento.DataCadastroFiltroFinal = StringUtils.ToDate(this.TxtBxDataFim.Text);
            objAtendimento.Programa.IdPrograma = objPrograma.IdPrograma;
        }

        protected void grdAtendimento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAtendimento.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        protected void grdAtendimento_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataKey dk = this.grdAtendimento.DataKeys[e.RowIndex];
            this.grdAtendimento.SelectedIndex = -1;
            this.UCCadastroAtendimentoIA1.Editar(ObjectUtils.ToInt(dk.Value));
        }
         
        protected void grdAtendimento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataKey dk = grdAtendimento.DataKeys[e.RowIndex];

                EntAtendimento objAtendimento = new BllAtendimento().ObterPorId(ObjectUtils.ToInt(dk.Value));
                objAtendimento.Ativo = !objAtendimento.Ativo;

                new BllAtendimento().Alterar(objAtendimento);
                this.PopulaGridAtendimento();

                MessageBox(this, "Atendimento alterado com sucesso!");
            }
            catch (Exception)
            {
            }

        }

        protected void grdAtendimento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Boolean PermissaoExcluir = ValidaPermissaoBotao(this, EnumType.TipoAcao.Excluir);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnAlterar = ((ImageButton)e.Row.FindControl("ImagBttnAlterar"));
                btnAlterar.ToolTip = "Alterar Atendimento";

                ImageButton btnAtivo = ((ImageButton)e.Row.FindControl("ImagBttnAtivo"));
                btnAtivo.ToolTip = "Ativar e Inativar";

                RegistraScriptExcluirGrid(this, btnAtivo, "Confirma Ativação/Inativação?");

                String imageUrl;
                Label lblAtivoAux = (Label)e.Row.FindControl("LblAtivo");

                if (lblAtivoAux.Text == "True")
                {
                    imageUrl = "~/Image/_file_Ok2.png";
                }
                else
                {
                    imageUrl = "~/Image/file_delete2.png";
                }

                btnAtivo.ImageUrl = imageUrl;
                HabilitaDesabilitaBotao(btnAtivo, PermissaoExcluir);
            }

        }
    }
}