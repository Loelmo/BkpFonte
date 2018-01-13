using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;

namespace PEG.User_Controls
{
    public partial class UCCadastroEscritorioRegionalIA : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        private List<EntCidade> ListaCidadesRemover
        {
            get
            {
                if (ViewState["ListaCidadesRemover"] == null)
                {
                    ViewState["ListaCidadesRemover"] = new List<EntCidade>();
                }
                return (List<EntCidade>)ViewState["ListaCidadesRemover"];
            }

            set
            {
                ViewState["ListaCidadesRemover"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.PopulaEstado();
                //this.PopulaTurma();
            }
        }

        public void Show(EnumType.StateIA stateIA)
        {
            divUserControl.Visible = true;

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
                EnableControl(this.PnlFundoIA.Controls, true);
                this.ImgBttnGravar.Visible = true;
            }
            else
            {
                EnableControl(this.PnlFundoIA.Controls, false);
                this.ImgBttnGravar.Visible = false;
            }
        }

        public void Close()
        {
            divUserControl.Visible = false;
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        protected void ImgBttnGravar_Click(object sender, ImageClickEventArgs e)
        {
            if (this.VerificaCamposObrigatoriosCadastro())
		    {
                this.Gravar();
                this.Clear();
                this.Close();

                if (atualizaGrid != null)
                {
                    this.atualizaGrid();
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
            res &= Valida_DropDownList(DrpDwnLstTurma);
            res &= Valida_DropDownList(DrpDwnLstEstado);
            res &= Valida_TextBox(txtEscritorioRegional);

            return res;
        }
        private void Clear()
        {

            ClearControl(this.PnlFundoIA.Controls);
            this.lstCidadesSelecionadas.Items.Clear();
            this.lstCidadesDisponiveis.Items.Clear();
        }

        protected void DrpDwnLstEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaCidade(StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue));
        }

        private void PopulaCidade(Int32 IdEstado)
        {
            lstCidadesDisponiveis.Items.Clear();
            lstCidadesSelecionadas.Items.Clear();
            ListItem item;

            if (IdEstado != 0)
            {
                foreach (EntCidade objCidade in new BllCidade().ObterCidadePorEstado(IdEstado, StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue)))
                {
                    item = new ListItem();
                    item.Text = objCidade.Cidade;
                    item.Value = objCidade.IdCidade.ToString();

                    lstCidadesDisponiveis.Items.Add(item);
                }
            }

            lstCidadesDisponiveis.DataBind();
        }

        public void Editar(int IdEscritorioRegional)
        {
            EntEscritorioRegional objEscritorioRegional = new BllEscritorioRegional().ObterPorIdComCidades(IdEscritorioRegional);
            ObjectToPage(objEscritorioRegional);
            this.Show(EnumType.StateIA.Alterar);
        }

        public void Incluir()
        {
            this.PopulaTurma(this.Page.Title);
            this.Clear();
            this.Show(EnumType.StateIA.Inserir);
            this.chkAtivo.Checked = true;
        }

        private void PageToObject(EntEscritorioRegional objEscritorioRegional)
        {
            objEscritorioRegional.IdEscritorioRegional = StringUtils.ToInt(this.HddnFldIdEscritorioRegional.Value);
            objEscritorioRegional.Ativo = this.chkAtivo.Checked;
            objEscritorioRegional.Turma.IdTurma = StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue);
            objEscritorioRegional.Estado.IdEstado = StringUtils.ToInt(this.DrpDwnLstEstado.SelectedValue);
            objEscritorioRegional.EscritorioRegional = this.txtEscritorioRegional.Text;
            objEscritorioRegional.LstCidades = ListaCidadesSelecionadas(this.lstCidadesSelecionadas, objEscritorioRegional);
            objEscritorioRegional.Ativo = this.chkAtivo.Checked;
            objEscritorioRegional.Turma.Programa.IdPrograma = objPrograma.IdPrograma;
        }

        private void ObjectToPage(EntEscritorioRegional objEscritorioRegional)
        {
            this.HddnFldIdEscritorioRegional.Value = IntUtils.ToString(objEscritorioRegional.IdEscritorioRegional);
            this.chkAtivo.Checked = objEscritorioRegional.Ativo;
            this.PopulaTurma(this.Page.Title);
            this.DrpDwnLstTurma.SelectedValue = IntUtils.ToString(objEscritorioRegional.Turma.IdTurma);
            this.PopulaEstado(objEscritorioRegional.Turma.IdTurma, this.Page.Title);
            this.DrpDwnLstEstado.SelectedValue = IntUtils.ToString(objEscritorioRegional.Estado.IdEstado);
            this.txtEscritorioRegional.Text = objEscritorioRegional.EscritorioRegional;
            
            this.lstCidadesDisponiveis.Items.Clear();
            this.lstCidadesDisponiveis.DataSource = new BllCidade().ObterCidadesSemEscritorioRegional(objEscritorioRegional);
            this.lstCidadesDisponiveis.DataBind();
            
            this.lstCidadesSelecionadas.Items.Clear();
            this.lstCidadesSelecionadas.DataSource = objEscritorioRegional.LstCidades;
            this.lstCidadesSelecionadas.DataBind();
        }

        private List<EntCidade> ListaCidadesSelecionadas(ListBox lstCidadesSelecionadas, EntEscritorioRegional objEscritorioRegional)
        {
            List<EntCidade> listCidades = new List<EntCidade>();
            foreach (ListItem item in lstCidadesSelecionadas.Items)
            {
                EntCidade objCidade = new EntCidade();
                objCidade.IdCidade = StringUtils.ToInt(item.Value);
                objCidade.Cidade = item.Text;
                objCidade.EscritorioRegional = objEscritorioRegional;
                listCidades.Add(objCidade);
            }
            return listCidades;
        }

        private void Gravar()
        {
            EntEscritorioRegional objEscritorioRegional = new EntEscritorioRegional();
            PageToObject(objEscritorioRegional);

            try
            {
                string msg = "";
                //Verifica se é Insert ou Update
                if (objEscritorioRegional.IdEscritorioRegional == 0)
                {
                    if (new BllEscritorioRegional().ExisteEscritorioRegional(objEscritorioRegional))
                    {
                        msg = "Já existe um Escritório Regional com este nome, para este estado!";
                    }
                    else
                    {
                        objEscritorioRegional = new BllEscritorioRegional().InserirComCidades(objEscritorioRegional);
                        msg = "Escritório Regional inserido com sucesso!";
                    }
                    MessageBox(this.Page, msg);
                }
                else
                {
                    new BllEscritorioRegional().AlterarComCidades(objEscritorioRegional);
                    msg = "Escritório Regional alterado com sucesso!";
                    MessageBox(this.Page, msg);
                }
                ListaCidadesRemover = new List<EntCidade>();
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar o Escritório Regional!");
                //logger.Error("Erro ao inserir o Escritório Regional!", ex);
            }
        }

        // Movendo itens do ListBox1 para o ListBox2 (esquerda para direita) 
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Lê todos os itens do ListBox1 
            foreach (ListItem item in this.lstCidadesDisponiveis.Items)
            {
                // Verifica se o item está selecionado 
                if (item.Selected)
                {
                    // Remove a seleção do item 
                    item.Selected = false;
                    // Adiciona o item ao ListBox2 
                    this.lstCidadesSelecionadas.Items.Add(item);
                    AdicionarRemoverCidades(item, true);
                }
            }

            // Lê todos os itens do ListBox2 
            foreach (ListItem item in this.lstCidadesSelecionadas.Items)
            {
                // Verifica se o ListBox1 contém o item 
                if (this.lstCidadesDisponiveis.Items.Contains(item))
                    // Remove o item do ListBox1 
                    this.lstCidadesDisponiveis.Items.Remove(item);
            }
        }

        // Movendo itens do ListBox2 para o ListBox1 (direita para esquerda) 
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            // Lê todos os itens do ListBox2 
            foreach (ListItem item in this.lstCidadesSelecionadas.Items)
            {
                // Verifica se o item está selecionado 
                if (item.Selected)
                {
                    // Remove a seleção do item 
                    item.Selected = false;
                    // Adiciona o item ao ListBox1 
                    this.lstCidadesDisponiveis.Items.Add(item);
                    AdicionarRemoverCidades(item, false);
                }
            }

            // Lê todos os itens do ListBox1 
            foreach (ListItem item in this.lstCidadesDisponiveis.Items)
            {
                // Verifica se o ListBox2 contém o item 
                if (this.lstCidadesSelecionadas.Items.Contains(item))
                    // Remove o item do ListBox2 
                    this.lstCidadesSelecionadas.Items.Remove(item);
            }
        }

        private void AdicionarRemoverCidades(ListItem item, bool inclusao)
        {
            EntCidade objCidade = new EntCidade();
            objCidade.IdCidade = (StringUtils.ToInt(item.Value));
            objCidade.Cidade = item.Text;

            if (inclusao)
            {
                this.ListaCidadesRemover.Remove(objCidade);
            }
            else
            {
                if (!this.ListaCidadesRemover.Exists(delegate(EntCidade c) { return c.IdCidade == objCidade.IdCidade; }))
                {
                    objCidade.EscritorioRegional = new EntEscritorioRegional();
                    this.ListaCidadesRemover.Add(objCidade);
                }
            }
        }

        public void PopulaTurma(String sFuncionalidade)
        {
            this.DrpDwnLstTurma.Items.Clear();

            this.DrpDwnLstTurma.DataSource = UsuarioLogado.lstTurmasPermitidas.FindAll(delegate(EntTurmasPermitidas objTurmasPermitidas) { return objTurmasPermitidas.Funcionalidade == sFuncionalidade; });
            this.DrpDwnLstTurma.DataBind();

            //if (this.DrpDwnLstTurma.Items.Count == 1)
            //{
            //    this.PopulaEstado(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), sFuncionalidade);
            //}
            this.DrpDwnLstTurma.Items.Insert(0, new ListItem("<< Selecione uma Turma >>", "0"));
            this.DrpDwnLstTurma.SelectedValue = "0";
        }

        private void PopulaEstado(Int32 IdTurma, String sFuncionalidade)
        {

            if (IdTurma != 0)
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

                this.DrpDwnLstEstado.Items.Insert(0, new ListItem("<< Selecione um Estado >>", "0"));
                this.DrpDwnLstEstado.SelectedValue = "0";
            }
            else
            {
                this.DrpDwnLstEstado.Items.Clear();
                this.DrpDwnLstEstado.Items.Insert(0, new ListItem("<< Selecione uma Turma>>", "0"));
                this.DrpDwnLstEstado.SelectedValue = "0";
            }
        }

        protected void DrpDwnLstTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulaEstado(StringUtils.ToInt(this.DrpDwnLstTurma.SelectedValue), this.Page.Title.ToString());
            this.lstCidadesDisponiveis.Items.Clear();
            this.lstCidadesSelecionadas.Items.Clear();
        }
    }
}