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
    public partial class CadastroArquivoCE : PaginaBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (ValidaPermissaoBotao(this, EnumType.TipoAcao.Atualizar))
            {
                this.grdArquivo.Columns[5].HeaderText = "Alterar";
            }
            else
            {
                this.grdArquivo.Columns[5].HeaderText = "Visualizar";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.rdTipoUsuarioEmpresa.Checked)
            {
                lblGrupoAcesso.Style.Add("display", "none");
                drpDwnGrupoAcesso.Style.Add("display", "none");
            }
            else if (this.rdTipoUsuarioAdministrativo.Checked)
            {
                lblGrupoAcesso.Style.Add("display", "block");
                drpDwnGrupoAcesso.Style.Add("display", "block");
            }
            if (!IsPostBack)
            {
                EntArquivo objArquivo = new EntArquivo();
                this.PopulaGrupo();
                this.PopulaPrioridade();

                this.PageToObject(objArquivo);

                this.PopulaGridArquivo();
                this.ImgBttnIncluir.Visible = ValidaPermissaoBotao(this, EnumType.TipoAcao.Inserir);
            }
            this.UCCadastroArquivoIA1.atualizaGrid += this.PopulaGridArquivo;
        }

        private void AtualizaGrid()
        {
            this.grdArquivo.DataSource = ListaGrid;
            this.grdArquivo.DataBind();
            this.grdArquivo.SelectedIndex = -1;
        }

        
        private void PopulaGridArquivo()
        {
            EntArquivo objArquivo = new EntArquivo();

            this.PageToObject(objArquivo);

            ListaGrid = new BllArquivo().ObterPorFiltro(objArquivo);
            this.AtualizaGrid();
        }

        private void PopulaGrupo()
        {
            this.DrpDwnLstGrupo.Items.Clear();

            this.DrpDwnLstGrupo.DataSource = new BllAdmGrupo().ObterTodos(this.objPrograma.IdPrograma);
            this.DrpDwnLstGrupo.DataBind();
            this.DrpDwnLstGrupo.Items.Insert(0, new ListItem("<< Todos >>", "0"));
            this.DrpDwnLstGrupo.SelectedValue = "0";
        }

        private void PopulaPrioridade()
        {
            this.DrpDwnLstPrioridade.Items.Clear();

            this.DrpDwnLstPrioridade.Items.Add(new ListItem("<< Todos >>", "0"));
            this.DrpDwnLstPrioridade.Items.Add(new ListItem("Alta", EntArquivo.ARQUIVO_PRIORIDADE_ALTA.ToString()));
            this.DrpDwnLstPrioridade.Items.Add(new ListItem("Média", EntArquivo.ARQUIVO_PRIORIDADE_MEDIA.ToString()));
            this.DrpDwnLstPrioridade.Items.Add(new ListItem("Baixa", EntArquivo.ARQUIVO_PRIORIDADE_BAIXA.ToString()));
            this.DrpDwnLstPrioridade.SelectedValue = "0";
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCCadastroArquivoIA1.Inserir();
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridArquivo();
        }

        private void PageToObject(EntArquivo objArquivo)
        {
            objArquivo.Titulo = this.TxtBxTitulo.Text;
            objArquivo.Prioridade = int.Parse(this.DrpDwnLstPrioridade.SelectedValue);
            objArquivo.DataCadastroFiltroInicial = StringUtils.ToDate(this.TxtBxDataInicio.Text);
            objArquivo.DataCadastroFiltroFinal = StringUtils.ToDateFim(this.TxtBxDataFim.Text);
            if (rdTipoUsuarioEmpresa.Checked)
            {
                objArquivo.UsuarioAdministrativo = false;
            }
            else if (rdTipoUsuarioAdministrativo.Checked)
            {
                objArquivo.UsuarioAdministrativo = true;
            }
            objArquivo.IdGrupoFiltro = int.Parse(DrpDwnLstGrupo.SelectedValue);
            if (chkBoxAtivo.Checked)
            {
                objArquivo.Ativo = true;
            }
            else
            {
                objArquivo.Ativo = false;
            }
            objArquivo.Estado.IdEstado = UsuarioLogado.Estado.IdEstado;
            objArquivo.Programa.IdPrograma = objPrograma.IdPrograma;
            objTurma.IdTurma = objTurma.IdTurma;
        }

        protected void grdArquivo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdArquivo.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        protected void grdArquivo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataKey dk = this.grdArquivo.DataKeys[e.RowIndex];
            this.grdArquivo.SelectedIndex = -1;
            this.UCCadastroArquivoIA1.Editar(ObjectUtils.ToInt(dk.Value));
        }
         
        protected void grdArquivo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataKey dk = grdArquivo.DataKeys[e.RowIndex];

                EntArquivo objArquivo = new BllArquivo().ObterPorId(ObjectUtils.ToInt(dk.Value));
                objArquivo.Ativo = !objArquivo.Ativo;

                new BllArquivo().Alterar(objArquivo);
                this.PopulaGridArquivo();

                MessageBox(this, "Arquivo alterado com sucesso!");
            }
            catch (Exception)
            {
            }

        }

        protected void grdArquivo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Boolean PermissaoExcluir = ValidaPermissaoBotao(this, EnumType.TipoAcao.Excluir);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnAlterar = ((ImageButton)e.Row.FindControl("ImagBttnAlterar"));
                btnAlterar.ToolTip = "Alterar Arquivo";

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