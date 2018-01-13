using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Vinit.SG.Common;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCCadastroGrupoAcessoIA : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        public Object ListaGridGA
        {
            get
            {
                if (Session["ListaGridGA"] == null)
                {
                    Session["ListaGridGA"] = new List<Object>();
                }
                return Session["ListaGridGA"];
            }

            set { Session["ListaGridGA"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // this.PopulaGridGrupoAcesso();

                
            }
        }

        private void Show(EnumType.StateIA stateIA)
        {
            this.divUserControl.Visible = true;

            Boolean bPermissao;

            if (stateIA == EnumType.StateIA.Inserir)
            {
                bPermissao = ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Inserir);
            }
            else
            {
                bPermissao = ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar);
            }

            if (bPermissao)
            {
                EnableControl(this.divUC.Controls, true);
                this.grdGrupoAcesso.Enabled = true;
                this.ImgBttnGravar.Visible = true;
            }
            else
            {
                EnableControl(this.divUC.Controls, false);
                this.grdGrupoAcesso.Enabled = false;
                this.ImgBttnGravar.Visible = false;
            }
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        protected void ImgBttnGravar_Click(object sender, ImageClickEventArgs e)
        {
            if (this.VerificaCamposObrigatoriosCadastro())
		    {
                if (this.Gravar())
                {
                    this.Clear();
                    this.Close();

                    if (atualizaGrid != null)
                    {
                        this.atualizaGrid();
                    }
                }
            }
            else
            {
                MessageBox(this.Page, "Favor preencher os campos obrigatórios (em destaque).");
            }
        }

        private Boolean VerificaCamposObrigatoriosCadastro()
        {
            Boolean res = true;
            res &= Valida_TextBox(TxtBxNome);

            return res;
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        private void Clear()
        {
            ClearControl(this.divUC.Controls);

            CheckBox ChkBxVisualizarAux;
            CheckBox ChkBxInserirAux;
            CheckBox ChkBxAtualizarAux;
            CheckBox ChkBxExcluirAux;

            for (int i = 0; i <= grdGrupoAcesso.Rows.Count - 1; i++)
            {
                ChkBxVisualizarAux = (CheckBox)grdGrupoAcesso.Rows[i].FindControl("ChkBxVisualizar");
                ChkBxInserirAux = (CheckBox)grdGrupoAcesso.Rows[i].FindControl("ChkBxInserir");
                ChkBxAtualizarAux = (CheckBox)grdGrupoAcesso.Rows[i].FindControl("ChkBxAtualizar");
                ChkBxExcluirAux = (CheckBox)grdGrupoAcesso.Rows[i].FindControl("ChkBxExcluir");

                ChkBxVisualizarAux.Checked = false;
                ChkBxInserirAux.Checked = false;
                ChkBxAtualizarAux.Checked = false;
                ChkBxExcluirAux.Checked = false;
            }

            this.grdGrupoAcesso.PageIndex = 0;

            HddnFldIdAdmGrupo.Value = "0";
            TxtBxNome.Text = "";
            TxtBxDescricao.Text = "";
        }

        public void Editar(Int32 IdAdmGrupo)
        {
            this.Clear();

            EntAdmGrupo objAdmGrupo = new EntAdmGrupo();
            objAdmGrupo.IdGrupo = IdAdmGrupo;

            List<EntAdmFuncionalidadeRelGrupoCustom> lstAdmFuncionalidadeRelGrupoCustom = new BllAdmFuncionalidadeRelGrupo().ObterPorIdCustom(ref objAdmGrupo, objPrograma.IdPrograma);
            if (lstAdmFuncionalidadeRelGrupoCustom != null)
            {
                this.HddnFldIdAdmGrupo.Value = IntUtils.ToString(objAdmGrupo.IdGrupo);
                this.TxtBxNome.Text = objAdmGrupo.Grupo;
                this.TxtBxDescricao.Text = objAdmGrupo.Descricao;

                this.ObjectToPage(lstAdmFuncionalidadeRelGrupoCustom);
            }
            this.Show(EnumType.StateIA.Inserir);
        }

        public void Inserir()
        {
            this.Clear();
            List<EntAdmFuncionalidadeRelGrupoCustom> lstAdmFuncionalidadeRelGrupoCustom = new BllAdmFuncionalidadeRelGrupo().ObterTodosCustom( objPrograma.IdPrograma );
            if (lstAdmFuncionalidadeRelGrupoCustom != null)
            {
                this.ObjectToPage(lstAdmFuncionalidadeRelGrupoCustom);
            }
            this.Show(EnumType.StateIA.Inserir);
        }

        private void PageToObject(List<EntAdmFuncionalidadeRelGrupoCustom> lstAdmFuncionalidadeCustom)
        {
            TextBox txtbxIdFuncionalidadeAux;
            TextBox txtbxIdGrupoAux;
            CheckBox ChkBxVisualizarAux;
            CheckBox ChkBxInserirAux;
            CheckBox ChkBxAtualizarAux;
            CheckBox ChkBxExcluirAux;

            EntAdmGrupo objAdmGrupo = new EntAdmGrupo();
            objAdmGrupo.IdGrupo = StringUtils.ToInt(this.HddnFldIdAdmGrupo.Value);
            objAdmGrupo.Grupo = this.TxtBxNome.Text;
            objAdmGrupo.Descricao = this.TxtBxDescricao.Text;

            for (int i = 0; i <= grdGrupoAcesso.Rows.Count - 1; i++)
            {
                txtbxIdFuncionalidadeAux = (TextBox)grdGrupoAcesso.Rows[i].FindControl("TxtBxIdFuncionalidade");
                txtbxIdGrupoAux = (TextBox)grdGrupoAcesso.Rows[i].FindControl("TxtBxIdGrupo");
                ChkBxVisualizarAux = (CheckBox)grdGrupoAcesso.Rows[i].FindControl("ChkBxVisualizar");
                ChkBxInserirAux = (CheckBox)grdGrupoAcesso.Rows[i].FindControl("ChkBxInserir");
                ChkBxAtualizarAux = (CheckBox)grdGrupoAcesso.Rows[i].FindControl("ChkBxAtualizar");
                ChkBxExcluirAux = (CheckBox)grdGrupoAcesso.Rows[i].FindControl("ChkBxExcluir");

                EntAdmFuncionalidadeRelGrupoCustom objAdmFuncionalidadeCustom = new EntAdmFuncionalidadeRelGrupoCustom();

                objAdmFuncionalidadeCustom.AdmGrupo = objAdmGrupo;

                objAdmFuncionalidadeCustom.IdFuncionalidade = StringUtils.ToInt(txtbxIdFuncionalidadeAux.Text);

                objAdmFuncionalidadeCustom.Visualizar = (ChkBxInserirAux.Checked || ChkBxAtualizarAux.Checked || ChkBxExcluirAux.Checked || ChkBxVisualizarAux.Checked);
                objAdmFuncionalidadeCustom.Inserir = ChkBxInserirAux.Checked;
                objAdmFuncionalidadeCustom.Atualizar = ChkBxAtualizarAux.Checked;
                objAdmFuncionalidadeCustom.Excluir = ChkBxExcluirAux.Checked;

                lstAdmFuncionalidadeCustom.Add(objAdmFuncionalidadeCustom);
            }
        }

        private void ObjectToPage(List<EntAdmFuncionalidadeRelGrupoCustom> lstAdmFuncionalidadeCustom)
        {
            this.PopulaGridGrupoAcesso(lstAdmFuncionalidadeCustom);
        }

        private Boolean Gravar()
        {
            List<EntAdmFuncionalidadeRelGrupoCustom> lstAdmFuncionalidadeCustom = new List<EntAdmFuncionalidadeRelGrupoCustom>();

            this.PageToObject(lstAdmFuncionalidadeCustom);

            try
            {
                MessageBox(this.Page, new BllAdmFuncionalidadeRelGrupo().InserirCustom(lstAdmFuncionalidadeCustom, this.objPrograma.IdPrograma));
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar o Grupo de Acesso!");
                return false;
            }
            return true;
        }

        private void PopulaGridGrupoAcesso()
        {
            ListaGridGA = new BllAdmFuncionalidadeRelGrupo().ObterTodosCustom(objPrograma.IdPrograma);
            this.AtualizaGridGrupoAcesso();
        }

        private void PopulaGridGrupoAcesso(List<EntAdmFuncionalidadeRelGrupoCustom> lstAdmFuncionalidadeCustom)
        {
            ListaGridGA = lstAdmFuncionalidadeCustom;
            this.AtualizaGridGrupoAcesso();
        }

        private void AtualizaGridGrupoAcesso()
        {
            this.grdGrupoAcesso.DataSource = ListaGridGA;
            this.grdGrupoAcesso.DataBind();
            this.grdGrupoAcesso.SelectedIndex = -1;
        }

        protected void grdGrupoAcesso_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Boolean Permissao = ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar) || ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Inserir);

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    CheckBox ChkBxVisualizar = ((CheckBox)e.Row.FindControl("ChkBxVisualizar"));
            //    CheckBox ChkBxInserir = ((CheckBox)e.Row.FindControl("ChkBxInserir"));
            //    CheckBox ChkBxAtualizar = ((CheckBox)e.Row.FindControl("ChkBxAtualizar"));
            //    CheckBox ChkBxExcluir = ((CheckBox)e.Row.FindControl("ChkBxExcluir"));

            //    ChkBxVisualizar.Enabled = Permissao;
            //    ChkBxInserir.Enabled = Permissao;
            //    ChkBxAtualizar.Enabled = Permissao;
            //    ChkBxExcluir.Enabled = Permissao;

            //}


        }

        protected void grdGrupoAcesso_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        //protected void grdGrupoAcesso_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    List<EntAdmFuncionalidadeRelGrupoCustom> lstAdmFuncionalidadeCustom = (List<EntAdmFuncionalidadeRelGrupoCustom>)ListaGrid;

        //    foreach (GridViewRow row in grdGrupoAcesso.Rows)
        //    {
        //        Int32 idFuncinalidade = StringUtils.ToInt(grdGrupoAcesso.DataKeys[row.RowIndex].Value.ToString());
        //        foreach (EntAdmFuncionalidadeRelGrupoCustom item in lstAdmFuncionalidadeCustom)
        //        {
        //            if (item.IdFuncionalidade == idFuncinalidade)
        //            {
        //                //1 - Visualizar
        //                CheckBox ChkBxVisualizar = (CheckBox)row.Cells[2].FindControl("ChkBxVisualizar");
        //                item.Visualizar = ChkBxVisualizar.Checked;
        //                //2 - Inserir
        //                CheckBox ChkBxInserir = (CheckBox)row.Cells[2].FindControl("ChkBxInserir");
        //                item.Inserir = ChkBxInserir.Checked;
        //                //3 - Atualizar
        //                CheckBox ChkBxAtualizar = (CheckBox)row.Cells[2].FindControl("ChkBxAtualizar");
        //                item.Atualizar = ChkBxAtualizar.Checked;
        //                //4 - Excluir
        //                CheckBox ChkBxExcluir = (CheckBox)row.Cells[2].FindControl("ChkBxExcluir");
        //                item.Excluir = ChkBxExcluir.Checked;
        //            }
        //        }
        //    }

        //    ListaGrid = lstAdmFuncionalidadeCustom;
        //    grdGrupoAcesso.PageIndex = e.NewPageIndex;
        //    AtualizaGridGrupoAcesso();
        //}

        protected void grdGrupoAcesso_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

    }
}