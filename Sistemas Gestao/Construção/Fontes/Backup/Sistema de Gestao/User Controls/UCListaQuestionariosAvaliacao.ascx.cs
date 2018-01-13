using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCListaQuestionariosAvaliacao : UCBase
    {
        public delegate void AtualizaGrid();
        public AtualizaGrid atualizaGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPerguntaAvaliar1.atualizaGrid += this.AtualizaGridPerguntas;
        }

        private void Show()
        {
            this.divUserControl.Visible = true;

            if (!ValidaPermissaoBotao(this.Page, EnumType.TipoAcao.Atualizar))
            {
                EnableControl(this.PnlFundo.Controls, false);
                this.ImgBttnEnviar.Visible = false;
            }
            else
            {
                EnableControl(this.PnlFundo.Controls, true);
                this.ImgBttnEnviar.Visible = true;
            }
        }

        public void Close()
        {
            this.divUserControl.Visible = false;
        }

        public void Editar(Int32 IdEmpresaCadastro, Int32 IdEtapa, Int32 IdTurma)
        {
            this.HddnFldIdEmpresaCadastro.Value = IdEmpresaCadastro.ToString();
            this.HddnFldIdEtapa.Value = IdEtapa.ToString();
            this.HddnFldIdTurma.Value = IdTurma.ToString();
            AtualizaGridPerguntas();
            this.Show();
        }

        private void AtualizaGridPerguntas()
        {
            ListaGrid = new BllQuestionarioEmpresaResposta().ObterRespostasEmpresaPorEmpresaParaAvaliacao(int.Parse(this.HddnFldIdEmpresaCadastro.Value), int.Parse(this.HddnFldIdEtapa.Value));
            this.grdPerguntas.DataSource = ListaGrid;
            this.grdPerguntas.DataBind();
            this.grdPerguntas.SelectedIndex = -1;

            try
            {
                List<EntQuestionarioEmpresaAvaliador> listQuestionarioEmpresaAvaliador = new BllQuestionarioEmpresaAvaliador().ObterPorIdQuestionarioEmpresa(((List<EntQuestionarioEmpresaResposta>)ListaGrid)[0].QuestionarioEmpresa.IdQuestionarioEmpresa);
                this.TxtJustificativa.Text = listQuestionarioEmpresaAvaliador[0].Banca;
            }
            catch { }
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        protected void grdPerguntas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPerguntas.PageIndex = e.NewPageIndex;
            AtualizaGridPerguntas();
        }

        protected void ImgBttnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            this.Close();
        }

        protected void ImgBttnEnviar_Click(object sender, ImageClickEventArgs e)
        {
            if (this.VerificaCamposObrigatorios())
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

        private Boolean VerificaCamposObrigatorios()
        {
            Boolean res = true;
            res &= Valida_TextBox(TxtJustificativa);
 
            return res;
        }

        protected Boolean Gravar()
        {
            Boolean isCompleto = true;
            ListaGrid = new BllQuestionarioEmpresaResposta().ObterRespostasEmpresaPorEmpresaParaAvaliacao(int.Parse(this.HddnFldIdEmpresaCadastro.Value), int.Parse(this.HddnFldIdEtapa.Value));
            foreach (EntQuestionarioEmpresaResposta resposta in (List<EntQuestionarioEmpresaResposta>)ListaGrid)
            {
                if (resposta.UsuarioAvaliador.IdUsuario == 0)
                {
                    isCompleto = false;
                }
            }

            if (isCompleto)
            {
                new BllQuestionarioEmpresaCalculoPontuacao().CalculaPontuacoesByEtapa(int.Parse(this.HddnFldIdTurma.Value), int.Parse(this.HddnFldIdEtapa.Value), int.Parse(this.HddnFldIdEmpresaCadastro.Value), true, this.TxtJustificativa.Text);
                new BllQuestionarioEmpresaCalculoPontuacao().RemoveAvaliador(int.Parse(this.HddnFldIdTurma.Value), int.Parse(this.HddnFldIdEtapa.Value), int.Parse(this.HddnFldIdEmpresaCadastro.Value), this.TxtJustificativa.Text);
                MessageBox(this.Page, "Avaliação concluida com sucesso!");
                return true;
            }
            else
            {
                MessageBox(this.Page, "Avaliação não finalizada!");
                return false;
            }
        }
        
        protected void grdPerguntas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label idAvaliador = ((Label)e.Row.FindControl("IdAvaliador"));
                ImageButton btnAlterar = ((ImageButton)e.Row.FindControl("ImgBttnAvaliar"));
                if (int.Parse(idAvaliador.Text) > 0)
                {
                    btnAlterar.ImageUrl = "~/Image/button_ok.gif";
                }
            }
        }

        protected void grdPerguntas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Index = ObjectUtils.ToInt(e.CommandArgument) - (grdPerguntas.PageIndex * grdPerguntas.PageSize);

            if (e.CommandName == "Avaliar")
            {
                Label lblIdQuestionarioEmpresa = ((Label)grdPerguntas.Rows[Index].FindControl("lblIdQuestionarioEmpresa"));
                int IdQuestionarioEmpresa = StringUtils.ToInt(lblIdQuestionarioEmpresa.Text);
                Label lblIdPergunta = ((Label)grdPerguntas.Rows[Index].FindControl("lblIdPergunta"));
                int IdPergunta = StringUtils.ToInt(lblIdPergunta.Text);
                this.grdPerguntas.SelectedIndex = -1;
                this.UCPerguntaAvaliar1.Editar(IdQuestionarioEmpresa, IdPergunta);
            }
        }
    }
}