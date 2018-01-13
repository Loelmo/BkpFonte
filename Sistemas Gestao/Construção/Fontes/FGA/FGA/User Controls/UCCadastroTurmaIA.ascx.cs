using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using System.IO;

namespace Sistema_de_Gestao.FGA.User_Control
{
    public partial class UCCadastroTurmaIA : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCCadastroTurmaIAAddQuestionario.AtualizaQuestionariosInseridosDelegate += this.AtualizaQuestionariosInseridosDelegate;
        }

        private void Show()
        {
            this.divUserControl.Visible = true;
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
            btnGerarEtapas.Visible = false;
        }

        public void Inserir()
        {
            this.HddnFldTurma.Value = "0";

            PopulaGridQuestionario(0);
            this.PopulaEstado();

            this.Show();
        }


        public void Editar(int IdTurma)
        {
            this.HddnFldTurma.Value = "0";
            this.PopulaEstado();

            EntTurma objTurma = new BllTurma().ObterPorId(IdTurma);
            PopulaGridQuestionario(objTurma.IdTurma);
            ObjectToPage(objTurma);
            //btnGerarEtapas.Visible = true;
            this.Show();
        }

        private void PopulaEstado()
        {
            this.ddlEstado.Items.Clear();
            this.ddlEstado.DataSource = new BllEstado().ObterTodos();
            this.ddlEstado.DataBind();
            this.ddlEstado.Items.Add(new ListItem("Todos", "0"));
            this.ddlEstado.SelectedValue = "0";
        }

        private void PopulaGridQuestionario(Int32 IdTurma)
        {
            populaGridSession(new BllTurmaQuestionario().ObterTodosPorTurma(IdTurma));
        }

        private void AtualizaGridQuestionario()
        {
            this.grdTurmaQuestionario.DataSource = Session["QuestionariosAssociados"];
            this.grdTurmaQuestionario.DataBind();
        }

        protected void ImgBttnIncluir_Click(object sender, ImageClickEventArgs e)
        {
            this.UCCadastroTurmaIAAddQuestionario.Inserir();
        }

        private void AtualizaQuestionariosInseridosDelegate()
        {
            this.Show();
            populaGridSession((List<EntTurmaQuestionario>)Session["QuestionariosAssociados"]);
        }

        protected void grdTurmaQuestionario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<EntTurmaQuestionario> lstTurmaQuestionario = (List<EntTurmaQuestionario>)Session["QuestionariosAssociados"];

            for (int i = 0; i < lstTurmaQuestionario.Count; i++)
            {
                if (lstTurmaQuestionario[i].Questionario.IdQuestionario == StringUtils.ToInt(((Label)this.grdTurmaQuestionario.Rows[e.RowIndex].Cells[0].FindControl("lblIdQuestionario")).Text))
                {
                    lstTurmaQuestionario.RemoveAt(i);
                    i--;
                }
            }
            populaGridSession(lstTurmaQuestionario);
        }

        private void populaGridSession(List<EntTurmaQuestionario> list)
        {
            Session["QuestionariosAssociados"] = list;
            this.grdTurmaQuestionario.DataSource = Session["QuestionariosAssociados"];
            this.grdTurmaQuestionario.DataBind();
        }

      
        private void Gravar()
        {
            EntTurma objTurma = new EntTurma();
            PageToObject(objTurma);

            try
            {
                string msg = "";
                //Verifica se é Insert ou Update
                if (objTurma.IdTurma == 0)
                {
                    objTurma = new BllTurma().Inserir(objTurma);
                    if (objTurma.IdTurma > 0)
                    {
                        msg = "Turma inserida com sucesso!";
                        MessageBox(this.Page, msg);
                    }
                    
                }
                else
                {
                    new BllTurma().Alterar(objTurma);
                    msg = "Turma alterada com sucesso!";
                    MessageBox(this.Page, msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox(this.Page, "Erro ao tentar Gravar!");
                //logger.Error("Erro ao inserir o Escritório Regional!", ex);
            }
        }

        private void PageToObject(EntTurma objTurma)
        {
            objTurma.IdTurma = StringUtils.ToInt(this.HddnFldTurma.Value.ToString());
            objTurma.Estado.IdEstado = StringUtils.ToInt(this.ddlEstado.SelectedItem.Value);
            objTurma.Estado.Estado = this.ddlEstado.SelectedValue.ToString();
            objTurma.Turma = this.TxtNome.Text;
            objTurma.Descricao = this.TxtDescricao.Text;
            objTurma.Privada = StringUtils.ToBoolean(this.rbTipo.SelectedValue.ToString());
            objTurma.Programa.IdPrograma = this.objPrograma.IdPrograma;
            objTurma.Questionarios = ObterDadosGrid((List<EntTurmaQuestionario>)Session["QuestionariosAssociados"]);
            objTurma.DtCadastro = DateTime.Now;
            objTurma.Ativo = true;
        }

        private void ObjectToPage(EntTurma objTurma)
        {
            this.HddnFldTurma.Value = objTurma.IdTurma.ToString();
            this.ddlEstado.SelectedValue = objTurma.Estado.IdEstado.ToString();
            this.TxtNome.Text = objTurma.Turma;
            this.TxtDescricao.Text = objTurma.Descricao;
            this.rbTipo.SelectedValue = BooleanUtils.ToInt(objTurma.Privada).ToString();

        }

        public void Copiar(int IdTurma)
        {
            this.PopulaEstado();

            EntTurma objTurma = new BllTurma().ObterPorId(IdTurma);
            PopulaGridQuestionario(objTurma.IdTurma);
            ObjectToPage(objTurma);
            this.HddnFldTurma.Value = "0";
            this.Show();
        }

        protected void ImgBttnCancelar_Click1(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();

        }

        protected void ImgBttnGravar_Click1(object sender, ImageClickEventArgs e)
        {
            if (this.VerificaCamposObrigatoriosCadastro())
            {
                this.Gravar();
                this.Clear();
                this.atualizaGrid();
                this.Close();
            }
            else
            {
                MessageBox(this.Page, "Favor preencher os campos obrigatórios (em destaque).");
            }
        }

        private Boolean VerificaCamposObrigatoriosCadastro()
        {
            Boolean res = true;
            res &= Valida_TextBox(TxtNome);
            res &= Valida_TextBox(TxtDescricao);
            
            return res;
        }

        protected void grdTurmaQuestionario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblOrdem = (Label)e.Row.FindControl("lblOrdem");
                lblOrdem.Text = IntUtils.ToString(e.Row.RowIndex + 1);                
            }
        }

        protected void grdTurmaQuestionario_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //int idTurma = StringUtils.ToInt(((Label)this.grdTurmas.Rows[e.RowIndex].Cells[0].FindControl("lblIdTurma")).Text);
            if (e.RowIndex > 0)
            {
                List<EntTurmaQuestionario> lstTurmaQuestionario = (List<EntTurmaQuestionario>)Session["QuestionariosAssociados"];

                for (int i = 0; i < lstTurmaQuestionario.Count; i++)
                {
                    if (lstTurmaQuestionario[i].Questionario.IdQuestionario == StringUtils.ToInt(((Label)this.grdTurmaQuestionario.Rows[e.RowIndex].Cells[0].FindControl("lblIdQuestionario")).Text))
                    {
                        lstTurmaQuestionario[i].Ordem--;
                        lstTurmaQuestionario[i - 1].Ordem++;
                        //i--;
                    }
                }
                OrdenarQuestionario(lstTurmaQuestionario);
            }

        }

        private void  OrdenarQuestionario(List<EntTurmaQuestionario> lstQuestionario)
        {
            lstQuestionario.Sort(delegate(EntTurmaQuestionario Q1, EntTurmaQuestionario Q2) { return Q1.Ordem.CompareTo(Q2.Ordem); });
            populaGridSession(lstQuestionario);
           
        }


        private List<EntTurmaQuestionario> ObterDadosGrid(List<EntTurmaQuestionario> lstTurmaQuestionario)
        {
            foreach (GridViewRow item in this.grdTurmaQuestionario.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {

                    for (int i = 0; i < lstTurmaQuestionario.Count; i++)
                    {
                        if (lstTurmaQuestionario[i].Questionario.IdQuestionario == StringUtils.ToInt(((Label)this.grdTurmaQuestionario.Rows[item.DataItemIndex].Cells[0].FindControl("lblIdQuestionario")).Text))
                            lstTurmaQuestionario[i].Obrigatorio = ((CheckBox)this.grdTurmaQuestionario.Rows[item.DataItemIndex].Cells[6].FindControl("ChkObrigatorio")).Checked;

                    }


                }
            }

            return lstTurmaQuestionario;
        }

        protected void btnGerarEtapas_Click(object sender, EventArgs e)
        {
            EntTurma objTurma = new EntTurma();
            PageToObject(objTurma);
            objTurma.Etapas =  new BllEtapa().GerarEtapasTurma(objTurma);
            if (objTurma.Etapas.Count > 0)
            {
                MessageBox(this.Page, "Etapas geradas com sucesso!");
            }
        }

        protected void grdTurmaQuestionario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTurmaQuestionario.PageIndex = e.NewPageIndex;
            this.AtualizaGridQuestionario();
        }
    

        
    }
}