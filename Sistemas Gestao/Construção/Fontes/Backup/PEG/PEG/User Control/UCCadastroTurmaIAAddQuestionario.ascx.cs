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

namespace PEG.FGA.User_Controls
{
    public partial class UCCadastroTurmaIAAddQuestionario : UCBase
    {

        public delegate void AtualizaQuestionariosInseridos();
        public AtualizaQuestionariosInseridos AtualizaQuestionariosInseridosDelegate { get; set; }

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //PopulaGridQuestionarioIncluir();
            }
        }

        private void Show()
        {
           
            this.divUserControl.Visible = true;
        }

        public void Close()
        {
            Clear();
            this.divUserControl.Visible = false;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
           
            this.grdQuestionarioIncluir.DataSource = new List<EntQuestionario>();
            this.grdQuestionarioIncluir.DataBind();
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        public void Inserir()
        {
            PopulaGridQuestionarioIncluir();
            this.Show();
        }


        private void PopulaGridQuestionarioIncluir()
        {
            this.grdQuestionarioIncluir.DataSource = new BllQuestionario().ObterQuestionariosPorFiltro(new BllQuestionario().ObterTodosQuestionarios(),(List<EntTurmaQuestionario>)Session["QuestionariosAssociados"]);
            this.grdQuestionarioIncluir.DataBind();
        }

        

        protected void ImgBttnGravar_Click1(object sender, ImageClickEventArgs e)
        {
            Session["QuestionariosAssociados"] = obterQuestionariosSelecionados((List<EntTurmaQuestionario>)Session["QuestionariosAssociados"]);
            this.Close();
            this.AtualizaQuestionariosInseridosDelegate();
        }

        private List<EntTurmaQuestionario> obterQuestionariosSelecionados(List<EntTurmaQuestionario> lstQuestionariosAssociados)
        {
            int Ordem = lstQuestionariosAssociados.Count;
            foreach (GridViewRow item in this.grdQuestionarioIncluir.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {
                    if (((CheckBox)item.Cells[3].Controls[1]).Checked)
                    {
                        EntTurmaQuestionario objQuestionario = new EntTurmaQuestionario();
                        Ordem++;
                        objQuestionario.Questionario.IdQuestionario =  StringUtils.ToInt(((Label)this.grdQuestionarioIncluir.Rows[item.DataItemIndex].Cells[0].FindControl("lblIdQuestionario")).Text);
                        objQuestionario.Questionario.Questionario = ((DataBoundLiteralControl)item.Cells[1].Controls[0]).Text;
                        objQuestionario.Ordem = Ordem;
                        
                        lstQuestionariosAssociados.Add(objQuestionario);
                    }
                }
            }

            return lstQuestionariosAssociados;
        }

        protected void ImgBttnCancelar_Click1(object sender, ImageClickEventArgs e)
        {
            this.Close();
        }

        protected void grdQuestionarioIncluir_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdQuestionarioIncluir.PageIndex = e.NewPageIndex;
            this.PopulaGridQuestionarioIncluir();
        }

        
    }
}