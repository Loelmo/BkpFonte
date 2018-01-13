using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using Vinit.SG.Ent;
using PEG.Utilitarios;

namespace PEG.User_Controls
{
    public partial class UCCadastroGrupoEmpresaIncluir : UCBase
    {
        public delegate void AtualizaEmpresasInseridas();
        public AtualizaEmpresasInseridas AtualizaEmpresasInseridasDelegate { get; set; }

        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        public Object ListaGridGEI
        {
            get
            {
                if (Session["ListaGridGEI"] == null)
                {
                    Session["ListaGridGEI"] = new List<Object>();
                }
                return Session["ListaGridGEI"];
            }

            set { Session["ListaGridGEI"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WebUtils.PopulaDropDownList(this.ddlCategoria, EnumType.TipoDropDownList.Categoria, "Todos");
            }
        }

        private void Show()
        {
            Clear();
            this.divUserControl.Visible = true;
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
//            this.DrpDwnLstEstado.SelectedValue = "0";
            this.ddlCategoria.SelectedValue = "0";
            this.ddlEscritorioRegional.SelectedValue = "0";
            this.grdEmpresa.DataSource = new List<EntEmpresaCadastro>();
            this.grdEmpresa.DataBind();
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        public void Inserir(Int32 IdTurma, Int32 IdEstado)
        {

            PopulaEstado(IdTurma, IdEstado, this.Page.Title.ToString());
            this.Show();
            this.HddnFldTurma.Value = IntUtils.ToString(IdTurma);
        }

        private void AtualizaGridEmpresa()
        {
            this.grdEmpresa.DataSource = ListaGridGEI;
            this.grdEmpresa.DataBind();
      //      this.grdEmpresa.SelectedIndex = -1;
        }

        private void PopulaGridEmpresa()
        {
            string sCpfCnpj = StringUtils.OnlyNumbers(this.TxtBxCNPJCPF.Text);
            string sNome = this.TxtNome.Text;
            int nEstado = StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue);
            int nEscritorioRegional = StringUtils.ToInt(this.ddlEscritorioRegional.SelectedValue);
            int nCategoria = StringUtils.ToInt(this.ddlCategoria.SelectedValue);

            ListaGridGEI = new BllEmpresaCadastro().ObterPorFiltro(sCpfCnpj, sNome, nEstado, nEscritorioRegional, nCategoria, StringUtils.ToInt(this.HddnFldTurma.Value));

            this.AtualizaGridEmpresa();

        }

        private void PopulaEstado(Int32 IdTurma, Int32 IdEstado, String sFuncionalidade)
        {
            List<EntEstadosPermitidos> lstEstadosPermitidos1 = UsuarioLogado.lstEstadoPermitidos.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.IdTurma == IdTurma; });

            this.DrpDwnLstEstado.Items.Clear();

            List<EntEstadosPermitidos> listEstadosTemp = lstEstadosPermitidos1.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.Funcionalidade == sFuncionalidade; });

            if (IdEstado > 0)
            {
                int i = 0;
                while (i < listEstadosTemp.Count)
                {
                    if (listEstadosTemp[i].IdEstado == IdEstado)
                    {
                        i++;
                        PopulaEscritorioRegional(IdEstado, this.Page.Title.ToString());
                    }
                    else
                    {
                        listEstadosTemp.RemoveAt(i);
                    }
                }
            }

            this.DrpDwnLstEstado.DataSource = listEstadosTemp;
            this.DrpDwnLstEstado.DataBind();

            if (this.DrpDwnLstEstado.Items.Count == 0 && IdEstado == 0)
            {
                this.DrpDwnLstEstado.Items.Clear();
                this.DrpDwnLstEstado.DataSource = new BllEstado().ObterTodos();
                this.DrpDwnLstEstado.Items.Insert(0, new ListItem("Todos", "0"));
                this.DrpDwnLstEstado.SelectedValue = "0";
                this.DrpDwnLstEstado.DataBind();
            }
            else if (this.DrpDwnLstEstado.Items.Count == 0 && IdEstado > 0)
            {
                this.DrpDwnLstEstado.Items.Clear();
                EntEstado objEstado = new BllEstado().ObterPorId(IdEstado);
                this.DrpDwnLstEstado.Items.Add(new ListItem(objEstado.Estado, objEstado.IdEstado.ToString()));
                PopulaEscritorioRegional(IdEstado, this.Page.Title.ToString());
            }

        }

        private void PopulaEscritorioRegional(Int32 IdEstado, String sFuncionalidade)
        {
            List<EntEscritoriosRegionaisPermitidos> lstEntEscritoriosRegionaisPermitidos1 = UsuarioLogado.lstEscritoriosRegionaisPermitidos.FindAll(delegate(EntEscritoriosRegionaisPermitidos objEscritoriosRegionaisPermitidos) { return objEscritoriosRegionaisPermitidos.Estado.IdEstado == IdEstado; });

            this.ddlEscritorioRegional.Items.Clear();

            this.ddlEscritorioRegional.DataSource = lstEntEscritoriosRegionaisPermitidos1.FindAll(delegate(EntEscritoriosRegionaisPermitidos objEscritoriosRegionaisPermitidos) { return objEscritoriosRegionaisPermitidos.Funcionalidade == sFuncionalidade; }); ;

            if (this.ddlEscritorioRegional.Items.Count == 0)
            {
                this.ddlEscritorioRegional.DataSource = new BllEscritorioRegional().ObterPorIdTurmaEstado(StringUtils.ToInt(this.HddnFldTurma.Value), IdEstado);
            }

            this.ddlEscritorioRegional.DataBind();
            this.ddlEscritorioRegional.Items.Insert(0, new ListItem("Todos", "0"));
            this.ddlEscritorioRegional.SelectedValue = "0";
        }

        protected void DrpDwnLstEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaEscritorioRegional(StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue), this.Page.Title.ToString());
        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.PopulaGridEmpresa();
        }

        protected void ImgBttnGravar_Click1(object sender, ImageClickEventArgs e)
        {
            Session["EmpresasAssociadas"] = obterEmpresasSelecionadas((List<EntEmpresaCadastro>)Session["EmpresasAssociadas"]);
            this.Close();
            this.AtualizaEmpresasInseridasDelegate();
        }

        private List<EntEmpresaCadastro> obterEmpresasSelecionadas(List<EntEmpresaCadastro> lstEmpresaCadastro)
        {
            foreach (GridViewRow item in this.grdEmpresa.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {
                    if (((CheckBox)item.Cells[1].Controls[1]).Checked)
                    {
                        EntEmpresaCadastro objEmpresaCadastro = new EntEmpresaCadastro();
                        objEmpresaCadastro.IdEmpresaCadastro = StringUtils.ToInt(grdEmpresa.DataKeys[item.DataItemIndex].Value.ToString());
                        objEmpresaCadastro.CPF_CNPJ = ((DataBoundLiteralControl)item.Cells[2].Controls[0]).Text;
                        objEmpresaCadastro.RazaoSocial = ((DataBoundLiteralControl)item.Cells[3].Controls[0]).Text;
                        objEmpresaCadastro.NomeFantasia = ((DataBoundLiteralControl)item.Cells[4].Controls[0]).Text;

                        if (!lstEmpresaCadastro.Contains(objEmpresaCadastro))
                        {
                            bool existe = false;
                            foreach (EntEmpresaCadastro obj in lstEmpresaCadastro)
                            {
                                if (obj.IdEmpresaCadastro == objEmpresaCadastro.IdEmpresaCadastro)
                                    existe = true;
                            }

                            if (!existe)
                                lstEmpresaCadastro.Add(objEmpresaCadastro);
                        }
                    }
                }
            }

            return lstEmpresaCadastro;
        }

        protected void ImgBttnCancelar_Click1(object sender, ImageClickEventArgs e)
        {
            this.Close();
        }

        protected void grdEmpresa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEmpresa.PageIndex = e.NewPageIndex;
            AtualizaGridEmpresa();
        }

    }
}