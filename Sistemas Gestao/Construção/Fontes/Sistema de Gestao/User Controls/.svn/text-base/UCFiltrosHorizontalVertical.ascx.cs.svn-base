using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;
using Vinit.SG.Ent;
using Vinit.SG.BLL;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCFiltrosHorizontalVertical : UCBase
    {
        public Int16 TabIndex { get; set; }

        public Boolean Horizontal { get; set; }

        public Double WidthLabel { get; set; }

        public Double WidthCampo { get; set; }

        public Boolean TurmaObrigatoria { get; set; }

        public Boolean EstadoObrigatorio { get; set; }

        public String ValidationGroup { get; set; }

        public String EmpytValue { get; set; }

        public Int32 IdTurma
        {
            get
            {
                return StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue);
            }

            set
            {
                this.PopulaTurma(this.Page.Title.ToString());
                this.DrpDwnLstTurma.SelectedValue = IntUtils.ToString(value);
             //   this.PopulaEstado(value, this.Page.Title.ToString());
            }
        }

        public Int32 IdEstado
        {
            get
            {
                return StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue);
            }

            set
            {
                this.DrpDwnLstEstado.SelectedValue = IntUtils.ToString(value);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DimensoesTabela();

            if (!IsPostBack)
            {
                this.PopulaTurma(this.Page.Title.ToString());

                this.DrpDwnLstTurma.TabIndex = TabIndex;
                this.DrpDwnLstEstado.TabIndex = IntUtils.ToInt16(TabIndex + 1);

                this.HorizontalVertical();
                
                this.Obrigatoriedade();
            }
        }

        public void Clear()
        {
            this.DrpDwnLstTurma.Items.Clear();
            this.DrpDwnLstEstado.Items.Clear();
        }

        public void Enable(Boolean value)
        {
            this.DrpDwnLstTurma.Enabled = value;
            this.DrpDwnLstEstado.Enabled = value;
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
            this.DrpDwnLstTurma.Items.Insert(0, new ListItem(EmpytValue, "0"));
            this.DrpDwnLstTurma.SelectedValue = "0";
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

        protected void DrpDwnLstTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaEstado(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), this.Page.Title.ToString());
        }

        private void HorizontalVertical()
        {
            if (this.Horizontal)
            {
                this.ltrTabela.Text = "";
            }
            else
            {
                this.ltrTabela.Text = "</tr><tr>";
            }
        }

        private void DimensoesTabela()
        {
            this.tdLblEstado.Width = DoubleUtils.ToString(this.WidthLabel);
            this.tdLblTurma.Width = DoubleUtils.ToString(this.WidthLabel);

            this.tdDdlEstado.Width = DoubleUtils.ToString(this.WidthCampo);
            this.tdDdlTurma.Width = DoubleUtils.ToString(this.WidthCampo);
        }

        private void Obrigatoriedade()
        {
            this.spTurma.Visible = this.TurmaObrigatoria;
            this.spEstado.Visible = this.EstadoObrigatorio;
        }


        public Boolean VerificaCamposObrigatoriosCadastro()
        {
            Boolean res = true;

            if (this.TurmaObrigatoria)
            {
                res &= Valida_DropDownList(DrpDwnLstTurma);
            }

            if (this.EstadoObrigatorio)
            {
                res &= Valida_DropDownList(DrpDwnLstEstado);
            }

            
            return res;
        }

    }
}