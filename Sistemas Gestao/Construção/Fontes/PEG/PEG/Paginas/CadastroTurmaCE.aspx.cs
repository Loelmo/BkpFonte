﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PEG.Pagina_Base;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using Vinit.SG.Ent;

namespace PEG.FGA.Paginas
{
    public partial class CadastroTurmaCE : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulaEstado();
                this.Pesquisar();

                this.ImgBtnIncluir.Visible = ValidaPermissaoBotao(this, EnumType.TipoAcao.Inserir);

            }
            this.UCCadastroTurmaIA.atualizaGrid += Pesquisar;
            
        }

        private void PopulaEstado()
        {
            this.ddlEstado.Items.Clear();

            List<EntEstadosPermitidos> listaEstadosPermitidos = UsuarioLogado.lstEstadoPermitidos.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.Funcionalidade == this.Title; });
            int i = 1;
            if (listaEstadosPermitidos.Count > 1)
            {
                while (i < listaEstadosPermitidos.Count)
                {
                    if (listaEstadosPermitidos[i].IdEstado == listaEstadosPermitidos[i - 1].IdEstado)
                    {
                        listaEstadosPermitidos.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            this.ddlEstado.DataSource = listaEstadosPermitidos;
            this.ddlEstado.DataBind();

            if (this.ddlEstado.Items.Count == 0)
            {
                this.ddlEstado.DataSource = new BllEstado().ObterTodos();
                this.ddlEstado.DataBind();
            }

            this.ddlEstado.Items.Insert(0, new ListItem("Todos", "0"));
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
            Boolean PermissaoExcluir = ValidaPermissaoBotao(this, EnumType.TipoAcao.Excluir);
            Boolean PermissaoEtapas = ValidaPermissaoBotao(this, EnumType.TipoAcao.Atualizar);
            Page temp = new Page();
            temp.Title = "Inscrições";
            Boolean PermissaoEmpresa = ValidaPermissaoBotao(temp, EnumType.TipoAcao.Atualizar);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnAcao = ((ImageButton)e.Row.FindControl("ImagBttnAcao"));
                ImageButton imgEditar = ((ImageButton)e.Row.FindControl("imgEditar"));
                ImageButton ImagBttnAssociar = ((ImageButton)e.Row.FindControl("ImagBttnAssociar"));
                ImageButton ImagBttnEtapas = ((ImageButton)e.Row.FindControl("ImagBttnAssociar2"));

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
                HabilitaDesabilitaBotao(btnAcao, PermissaoExcluir);
                HabilitaDesabilitaBotao(ImagBttnAssociar, PermissaoEmpresa);
                HabilitaDesabilitaBotao(ImagBttnEtapas, PermissaoEtapas);
                HabilitaDesabilitaBotao(imgEditar, PermissaoEtapas);

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