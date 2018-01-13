using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.BLL;
using Vinit.SG.Common;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCEstado : UCBase
    {
        public Boolean EscritorioRegional { get; set; }
        public Boolean Regiao { get; set; }
        public Boolean Bairro { get; set; }
        public Boolean Grupo { get; set; }

        public Boolean ObrigatorioTurma { get; set; }
        public Boolean ObrigatorioEstado { get; set; }
        public Boolean ObrigatorioEscritorioRegional { get; set; }
        public Boolean ObrigatorioRegiao { get; set; }
        public Boolean ObrigatorioCidade { get; set; }
        public Boolean ObrigatorioBairro { get; set; }
        public Boolean ObrigatorioGrupo { get; set; }

        public Int16 TabIndex { get; set; }
        public Double WidthCampo { get; set; }

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
                this.PopulaEstado(value, this.Page.Title.ToString());
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
                this.PopulaEscritorioRegional(StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue), this.Page.Title.ToString());
                this.PopulaCidade(StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue), StringUtils.ToInt(this.DrpDwnLstEscritorioRegional.SelectedValue), StringUtils.ToInt(this.DrpDwnLstRegiao.SelectedValue), StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue));
                this.PopulaGrupo(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue));
            }
        }
        
        public Int32 IdEscritorioRegional
        {
            get
            {
                return StringUtils.ToInt(this.DrpDwnLstEscritorioRegional.SelectedValue);
            }

            set
            {
                
                this.DrpDwnLstEscritorioRegional.SelectedValue = IntUtils.ToString(value); 
            }
        }

        public Int32 IdRegiao
        {
            get
            {
                return StringUtils.ToInt(this.DrpDwnLstRegiao.SelectedValue);
            }

            set 
            {
                
                this.DrpDwnLstRegiao.SelectedValue = IntUtils.ToString(value); 
            }
        }

        public Int32 IdCidade
        {
            get
            {
                return StringUtils.ToInt(this.DrpDwnLstCidade.SelectedValue);
            }

            set 
            {
                this.DrpDwnLstCidade.SelectedValue = IntUtils.ToString(value); 
            }
        }

        public Int32 IdGrupo
        {
            get
            {
                return StringUtils.ToInt(this.DrpDwnLstGrupo.SelectedValue);
            }

            set 
            {
                
                this.DrpDwnLstGrupo.SelectedValue = IntUtils.ToString(value); 
            }
        }

        public Int32 IdBairro
        {
            get
            {
                return StringUtils.ToInt(this.DrpDwnLstBairro.SelectedValue);
            }

            set 
            {
                this.PopulaBairro(StringUtils.ToInt(this.DrpDwnLstCidade.SelectedValue));
                this.DrpDwnLstBairro.SelectedValue = IntUtils.ToString(value); 
            }
        }

        public void SetFocus()
        {
            this.DrpDwnLstTurma.Focus();
        }

        public void SetFocusEstado()
        {
            this.DrpDwnLstEstado.Focus();
        }

        public delegate void PopulaEstadoContato();
        public PopulaEstadoContato populaEstadoContato { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.PopulaTurma( this.Page.Title.ToString() );
                this.DrpDwnLstEscritorioRegional.Visible = EscritorioRegional;
                this.DrpDwnLstRegiao.Visible = Regiao;
                this.DrpDwnLstBairro.Visible = Bairro;
                this.DrpDwnLstGrupo.Visible = Grupo;

                this.DrpDwnLstTurma.TabIndex = TabIndex++;

                this.DrpDwnLstEstado.TabIndex = IntUtils.ToInt16(TabIndex++);
                this.DrpDwnLstEscritorioRegional.TabIndex = IntUtils.ToInt16(EscritorioRegional ? TabIndex++ : 99);
                this.DrpDwnLstRegiao.TabIndex = IntUtils.ToInt16(Regiao ? TabIndex++ : 99);
                this.DrpDwnLstCidade.TabIndex = IntUtils.ToInt16(TabIndex++);
                this.DrpDwnLstBairro.TabIndex = IntUtils.ToInt16(Bairro ? TabIndex++ : 99);
                this.DrpDwnLstGrupo.TabIndex = IntUtils.ToInt16(Grupo ? TabIndex++ : 99);

                this.Obrigatoriedade();
            }

           // this.tdDdlEstado.Width = "100";// DoubleUtils.ToString(this.WidthCampo);
        }

        private void Obrigatoriedade()
        {
            this.spTurma.Visible = this.ObrigatorioTurma;
            this.rfvTurma.Enabled = this.ObrigatorioTurma;
            this.rfvTurma.Visible = this.ObrigatorioTurma;
            this.vcTurma.Enabled = this.ObrigatorioTurma;

            this.spEstado.Visible = this.ObrigatorioEstado;
            this.rfvEstado.Enabled = this.ObrigatorioEstado;
            this.rfvEstado.Visible = this.ObrigatorioEstado;
            this.vcEstado.Enabled = this.ObrigatorioEstado;

            this.spEscritorioRegional.Visible = this.ObrigatorioEscritorioRegional;
            this.rfvEscritorioRegional.Enabled = this.ObrigatorioEscritorioRegional;
            this.rfvEscritorioRegional.Visible = this.ObrigatorioEscritorioRegional;
            this.vcEscritorioRegional.Enabled = this.ObrigatorioEscritorioRegional;

            this.spRegiao.Visible = this.ObrigatorioRegiao;
            this.rfvRegiao.Enabled = this.ObrigatorioRegiao;
            this.rfvRegiao.Visible = this.ObrigatorioRegiao;
            this.vcRegiao.Enabled = this.ObrigatorioRegiao;

            this.spCidade.Visible = this.ObrigatorioCidade;
            this.rfvCidade.Enabled = this.ObrigatorioCidade;
            this.rfvCidade.Visible = this.ObrigatorioCidade;
            this.vcCidade.Enabled = this.ObrigatorioCidade;

            this.spBairro.Visible = this.ObrigatorioBairro;
            this.rfvBairro.Enabled = this.ObrigatorioBairro;
            this.rfvBairro.Visible = this.ObrigatorioBairro;
            this.vcBairro.Enabled = this.ObrigatorioBairro;

            this.spGrupo.Visible = this.ObrigatorioGrupo;
            this.rfvGrupo.Enabled = this.ObrigatorioGrupo;
            this.rfvGrupo.Visible = this.ObrigatorioGrupo;
            this.vcGrupo.Enabled = this.ObrigatorioGrupo;
        }

        public void EnableTurma(Boolean avalue)
        {
            this.DrpDwnLstTurma.Enabled = avalue;
        }

        private void PopulaTurma(String sFuncionalidade)
        {
            this.DrpDwnLstTurma.Items.Clear();

            this.DrpDwnLstTurma.DataSource = UsuarioLogado.lstTurmasPermitidas.FindAll(delegate(EntTurmasPermitidas objTurmasPermitidas) { return objTurmasPermitidas.Funcionalidade == sFuncionalidade; });
            this.DrpDwnLstTurma.DataBind();
            //this.DrpDwnLstTurma.Items.Insert(0, new ListItem("Todos", "0"));
            //this.DrpDwnLstTurma.SelectedValue = "0";

  //          if (this.DrpDwnLstTurma.Items.Count == 1 )
    //        {
            this.PopulaEstado(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), sFuncionalidade);
      //      }


        }

        private void PopulaEstado(Int32 IdTurma, String sFuncionalidade)
        {
            this.DrpDwnLstEstado.Items.Clear();

            List<EntEstadosPermitidos> lstEstadosPermitidos1 = UsuarioLogado.lstEstadoPermitidos.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.IdTurma == IdTurma; });
            List<EntEstado> lstEstados = new List<EntEstado>();

            lstEstadosPermitidos1= lstEstadosPermitidos1.FindAll(delegate(EntEstadosPermitidos objEstadosPermitidos) { return objEstadosPermitidos.Funcionalidade == sFuncionalidade; });
            if (ObrigatorioEstado)
            {
                lstEstadosPermitidos1.Insert(0, new EntEstadosPermitidos(0, "<< Selecione o Estado >>"));
            }
            else
            {
                if (lstEstadosPermitidos1.Count == 27)
                {
                    lstEstadosPermitidos1.Insert(0, new EntEstadosPermitidos(0, "Todos"));
                }
            }
            this.DrpDwnLstEstado.DataSource = lstEstadosPermitidos1;

            if (lstEstadosPermitidos1.Count == 0)
            {
                lstEstados = new BllEstado().ObterEstadosPorTurma(IdTurma, EntTipoEtapa.TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_ADMINISTRATIVO);
                if (ObrigatorioEstado)
                {
                    lstEstados.Insert(0, new EntEstado(0, "<< Selecione o Estado >>"));
                }
                else
                {
                    lstEstados.Insert(0, new EntEstado(0, "Todos"));
                }
                this.DrpDwnLstEstado.DataSource = lstEstados;
            }

//            this.DrpDwnLstEstado.SelectedValue = "0";
            this.DrpDwnLstEstado.DataBind();
        }

        private void PopulaEscritorioRegional(Int32 IdEstado, String sFuncionalidade)
        {

            this.DrpDwnLstEscritorioRegional.Items.Clear();

            List<EntEscritoriosRegionaisPermitidos> lstEntEscritoriosRegionaisPermitidos1 = UsuarioLogado.lstEscritoriosRegionaisPermitidos.FindAll(delegate(EntEscritoriosRegionaisPermitidos objEscritoriosRegionaisPermitidos) { return objEscritoriosRegionaisPermitidos.Estado.IdEstado == IdEstado; });

            this.DrpDwnLstEscritorioRegional.DataSource = lstEntEscritoriosRegionaisPermitidos1.FindAll(delegate(EntEscritoriosRegionaisPermitidos objEscritoriosRegionaisPermitidos) { return objEscritoriosRegionaisPermitidos.Funcionalidade == sFuncionalidade; });
            this.DrpDwnLstEscritorioRegional.DataBind();

            if (this.DrpDwnLstEscritorioRegional.Items.Count == 0)
            {
                this.DrpDwnLstEscritorioRegional.DataSource = new BllEscritorioRegional().ObterPorIdTurmaEstado(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), IdEstado);
                this.DrpDwnLstEscritorioRegional.DataBind();
            }

            if (ObrigatorioEscritorioRegional)
            {
                this.DrpDwnLstEscritorioRegional.Items.Insert(0, new ListItem("<< Selecione o Escritório Regional >>", "0"));
            }
            else
            {
                this.DrpDwnLstEscritorioRegional.Items.Insert(0, new ListItem("Todos", "0"));
            }
            
            this.DrpDwnLstEscritorioRegional.SelectedValue = "0";
        }

        private void PopulaRegiao(Int32 IdEstado)
        {
            this.DrpDwnLstRegiao.Items.Clear();

            this.DrpDwnLstRegiao.DataSource = new BllEstadoRegiao().ObterPorIdEstado(IdEstado);
            this.DrpDwnLstRegiao.DataBind();

            if (ObrigatorioRegiao)
            {
                this.DrpDwnLstRegiao.Items.Insert(0, new ListItem("<< Selecione a Região >>", "0"));
            }
            else
            {
                this.DrpDwnLstRegiao.Items.Insert(0, new ListItem("Todos", "0"));
            }

            
            this.DrpDwnLstRegiao.SelectedValue = "0";
        }

        private void PopulaCidade(Int32 IdEstado, Int32 IdEscritorioRegional, Int32 IdRegiao, Int32 IdTurma)
        {
            this.DrpDwnLstCidade.Items.Clear();

            this.DrpDwnLstCidade.DataSource = new BllCidade().ObterCidadePorEstadoEscritorioRegionalRegiao(IdEstado, IdEscritorioRegional, IdRegiao, IdTurma);
            this.DrpDwnLstCidade.DataBind();

            if (ObrigatorioCidade)
            {
                this.DrpDwnLstCidade.Items.Insert(0, new ListItem("<< Selecione a Cidade >>", "0"));
            }
            else
            {
                this.DrpDwnLstCidade.Items.Insert(0, new ListItem("Todos", "0"));
            }

            
            this.DrpDwnLstCidade.SelectedValue = "0";
            this.DrpDwnLstCidade.Enabled = true;
        }

        private void PopulaBairro(Int32 IdCidade)
        {
            this.DrpDwnLstBairro.Items.Clear();

            this.DrpDwnLstBairro.DataSource = new BllBairro().ObterPorCidade(IdCidade);
            this.DrpDwnLstBairro.DataBind();

            if (ObrigatorioBairro)
            {
                this.DrpDwnLstBairro.Items.Insert(0, new ListItem("<< Selecione o Bairro >>", "0"));
            }
            else
            {
                this.DrpDwnLstBairro.Items.Insert(0, new ListItem("Todos", "0"));
            }

            
            this.DrpDwnLstBairro.SelectedValue = "0";
            this.DrpDwnLstCidade.Enabled = true;
        }

        private void PopulaGrupo(Int32 IdTurma, Int32 IdEstado)
        {
            this.DrpDwnLstGrupo.Items.Clear();

            this.DrpDwnLstGrupo.DataSource = new BllGrupo().ObterPorIdTurmaEstado(IdTurma, IdEstado);
            this.DrpDwnLstGrupo.DataBind();

            if (ObrigatorioGrupo)
            {
                this.DrpDwnLstGrupo.Items.Insert(0, new ListItem("<< Selecione o Grupo >>", "0"));
            }
            else
            {
                this.DrpDwnLstGrupo.Items.Insert(0, new ListItem("Todos", "0"));
            }

            
            this.DrpDwnLstGrupo.SelectedValue = "0";
        }

        protected void DrpDwnLstTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaEstado(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), this.Page.Title.ToString());
            this.PopulaGrupo(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue));

            this.DrpDwnLstEstado.Focus();

            if (populaEstadoContato != null)
            {
                this.populaEstadoContato();
            }

            this.PopulaEscritorioRegional(0, "");
            this.PopulaRegiao(0);
            this.PopulaCidade(0, 0, 0, 0);
            //this.PopulaBairro(0);
            //this.PopulaGrupo(0, 0);
        }

        protected void DrpDwnLstEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EscritorioRegional)
            {
                this.PopulaEscritorioRegional(StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue), this.Page.Title.ToString());
            }

            if (Regiao)
            {
                this.PopulaRegiao(StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue));
            }

            this.PopulaCidade(StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue), StringUtils.ToInt(this.DrpDwnLstEscritorioRegional.SelectedValue), StringUtils.ToInt(this.DrpDwnLstRegiao.SelectedValue), StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue));
            this.PopulaBairro(0);
            this.PopulaGrupo(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue));

            if (EscritorioRegional)
            {
                this.DrpDwnLstEscritorioRegional.Focus();
            }
            else
                if (Regiao)
                {
                    this.DrpDwnLstRegiao.Focus();
                }
                else
                {
                    this.DrpDwnLstCidade.Focus();
                }
        }

        protected void DrpDwnLstEscritorioRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaCidade(StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue), StringUtils.ToInt(this.DrpDwnLstEscritorioRegional.SelectedValue), StringUtils.ToInt(this.DrpDwnLstRegiao.SelectedValue), StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue));
            if (Regiao)
            {
                this.DrpDwnLstRegiao.Focus();
            }
        }

        protected void DrpDwnLstRegiao_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaCidade(StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue), StringUtils.ToInt(this.DrpDwnLstEscritorioRegional.SelectedValue), StringUtils.ToInt(this.DrpDwnLstRegiao.SelectedValue), StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue));
            this.DrpDwnLstCidade.Focus();
        }

        protected void DrpDwnLstCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaBairro(StringUtils.ToInt(this.DrpDwnLstCidade.SelectedValue));
            if (Bairro)
            {
                this.DrpDwnLstBairro.Focus();
            }
        }

        public void Clear()
        {
            DrpDwnLstTurma.SelectedIndex = 0;
            DrpDwnLstEstado.Items.Clear();
            DrpDwnLstEscritorioRegional.Items.Clear();
            this.DrpDwnLstEscritorioRegional.Items.Insert(0, new ListItem("<< Selecione o Escritório Regional >>", "0"));
            DrpDwnLstRegiao.Items.Clear();
            this.DrpDwnLstRegiao.Items.Insert(0, new ListItem("<< Selecione a Região >>", "0"));
            DrpDwnLstCidade.Items.Clear();
            this.DrpDwnLstCidade.Items.Insert(0, new ListItem("<< Selecione a Cidade >>", "0"));
            DrpDwnLstBairro.Items.Clear();
            this.DrpDwnLstBairro.Items.Insert(0, new ListItem("<< Selecione o Bairro >>", "0"));
            DrpDwnLstGrupo.Items.Clear();
            this.DrpDwnLstGrupo.Items.Insert(0, new ListItem("<< Selecione o Grupo >>", "0"));
        }
    }
}