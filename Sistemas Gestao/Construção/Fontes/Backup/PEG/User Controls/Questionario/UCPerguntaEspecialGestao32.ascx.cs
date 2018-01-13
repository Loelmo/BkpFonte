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

namespace PEG.User_Controls
{
    public partial class UCPerguntaEspecialGestao32 : UCQuestionarioBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.HdnIdQuestionario.Value = IdQuestionario.ToString();
                this.HdnIdQuestionarioEmpresa.Value = IdQuestionarioEmpresa.ToString();
                this.HdnIdEmpresaCadastro.Value = IdEmpresaCadastro.ToString();
                this.HdnIdTurma.Value = IdTurma.ToString();
                this.HdnIdPergunta.Value = Pergunta.IdPergunta.ToString();

                this.lblPergunta.Text = this.Pergunta.Pergunta;
                this.lblTabela.Text = this.Pergunta.Pergunta;
                this.lblNumeroPergunta.Text = this.Pergunta.NumeroQuestao;
                this.lblPerguntaAjuda.Text = this.Pergunta.SaibaMais;
                this.lblRespostaA.Text = this.Pergunta.ListPerguntaResposta[0].PerguntaResposta;
                this.hdnRespostaA_Just.Value = this.Pergunta.ListPerguntaResposta[0].PossuiJustificativa.ToString();
                this.tickRespA.Style.Add("display", "none");
                this.lblRespostaB.Text = this.Pergunta.ListPerguntaResposta[1].PerguntaResposta;
                this.hdnRespostaB_Just.Value = this.Pergunta.ListPerguntaResposta[1].PossuiJustificativa.ToString();
                this.tickRespB.Style.Add("display", "none");
                this.lblRespostaC.Text = this.Pergunta.ListPerguntaResposta[2].PerguntaResposta;
                this.hdnRespostaC_Just.Value = this.Pergunta.ListPerguntaResposta[2].PossuiJustificativa.ToString();
                this.tickRespC.Style.Add("display", "none");
                this.lblRespostaD.Text = this.Pergunta.ListPerguntaResposta[3].PerguntaResposta;
                this.hdnRespostaD_Just.Value = this.Pergunta.ListPerguntaResposta[3].PossuiJustificativa.ToString();
                this.tickRespD.Style.Add("display", "none");
                this.cmbCriterios.Items.Clear();

                EntQuestionario q = new BllQuestionario().ObterPorIdTurmaIdQuestionarioEmpresa(IdTurma, IdQuestionarioEmpresa);
                porcent.InnerHtml = q.PorcentagemPreenchida + "% preenchido";
                barraPercent.Style.Value = "width:" + q.PorcentagemPreenchida + "%";
                if (this.isUltimaPergunta(q.IdQuestionario, Pergunta.IdPergunta))
                {
                    this.BtnProximo.ImageUrl = "/Image/finalizar.gif";
                    this.tableValores.Visible = false;
                }

                foreach (EntCriterio c in new BllCriterio().ObterPorQuestionarioComPerguntas(IdQuestionario))
                {
                    ListItem li = new ListItem();
                    li.Text = c.Criterio;
                    li.Value = c.IdCriterio.ToString();
                    if (c.IdCriterio.Equals(this.Pergunta.Criterio.IdCriterio))
                    {
                        li.Selected = true;
                        this.lblCriterioAjuda.Text = c.Ajuda;
                    }
                    this.cmbCriterios.Items.Add(li);
                }
                if (this.Pergunta.QuestionarioEmpresaResposta != null && this.Pergunta.QuestionarioEmpresaResposta.QuestionarioEmpresa != null)
                {
                    if (this.Pergunta.QuestionarioEmpresaResposta.Resposta.PossuiJustificativa)
                    {
                        this.tx1_31.Text = this.Pergunta.QuestionarioEmpresaResposta.Valor01;
                        this.tx2_31.Text = this.Pergunta.QuestionarioEmpresaResposta.Valor02;
                        this.tx3_31.Text = this.Pergunta.QuestionarioEmpresaResposta.Valor03;
                        this.tx1_31.Attributes.Remove("disabled");
                        this.tx1_31.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                        this.tx2_31.Attributes.Remove("disabled");
                        this.tx2_31.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                        this.tx3_31.Attributes.Remove("disabled");
                        this.tx3_31.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                    }
                    else
                    {
                        this.tx1_31.Attributes.Add("disabled","true");
                        this.tx2_31.Attributes.Add("disabled", "true");
                        this.tx3_31.Attributes.Add("disabled", "true");
                    }
                    if (this.Pergunta.QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == this.Pergunta.ListPerguntaResposta[0].IdPerguntaResposta)
                    {
                        this.respostaSelecionada.Value = "A";
                        this.tickRespA.Style.Add("display", "block");
                        this.coluna1RespostaA.Style.Add("background-color", "#89AFF5");
                        this.coluna2RespostaA.Style.Add("background-color", "#89AFF5");
                        this.respostaA.Style.Add("background-color", "#89AFF5");
                    }
                    else if (this.Pergunta.QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == this.Pergunta.ListPerguntaResposta[1].IdPerguntaResposta)
                    {
                        this.respostaSelecionada.Value = "B";
                        this.tickRespB.Style.Add("display", "block");
                        this.coluna1RespostaB.Style.Add("background-color", "#89AFF5");
                        this.coluna2RespostaB.Style.Add("background-color", "#89AFF5");
                        this.respostaB.Style.Add("background-color", "#89AFF5");
                    }
                    else if (this.Pergunta.QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == this.Pergunta.ListPerguntaResposta[2].IdPerguntaResposta)
                    {
                        this.respostaSelecionada.Value = "C";
                        this.tickRespC.Style.Add("display", "block");
                        this.coluna1RespostaC.Style.Add("background-color", "#89AFF5");
                        this.coluna2RespostaC.Style.Add("background-color", "#89AFF5");
                        this.respostaC.Style.Add("background-color", "#89AFF5");
                    }
                    else if (this.Pergunta.QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == this.Pergunta.ListPerguntaResposta[3].IdPerguntaResposta)
                    {
                        this.respostaSelecionada.Value = "D";
                        this.tickRespD.Style.Add("display", "block");
                        this.coluna1RespostaD.Style.Add("background-color", "#89AFF5");
                        this.coluna2RespostaD.Style.Add("background-color", "#89AFF5");
                        this.respostaD.Style.Add("background-color", "#89AFF5");
                    }
                }
            }
        }

        protected void cmbCriterios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gravar();

            //Redireciona para a próxima pergunta
            this.Pergunta = new BllPergunta().ObterPrimeiraPerguntaPorQuestionarioCriterio(IdQuestionario, int.Parse(cmbCriterios.SelectedItem.Value));
            Redireciona();
        }

        protected void BtnAnterior_Click(object sender, EventArgs e)
        {
            Gravar();

            //Redireciona para a próxima pergunta
            this.Pergunta = new BllPergunta().ObterPerguntaAnteriorPorQuestionarioPergunta(IdQuestionario, Pergunta.IdPergunta);
            Redireciona();
        }

        protected void BtnProximo_Click(object sender, EventArgs e)
        {
            Gravar();

            //Redireciona para a próxima pergunta
            this.Pergunta = new BllPergunta().ObterPerguntaProximaPorQuestionarioPergunta(IdQuestionario, Pergunta.IdPergunta);
            if (Pergunta == null && this.habilitaEnvioQuestionario())
            {
                this.UCEnviaQuestionarioEmpresa1.Show();
            }
            else
            {
                Redireciona();
            }
        }

        protected void Gravar()
        {
            IdQuestionario = int.Parse(this.HdnIdQuestionario.Value);
            IdQuestionarioEmpresa = int.Parse(this.HdnIdQuestionarioEmpresa.Value);
            IdEmpresaCadastro = int.Parse(this.HdnIdEmpresaCadastro.Value);
            IdTurma = int.Parse(this.HdnIdTurma.Value);
            Pergunta = new EntPergunta();
            Pergunta.IdPergunta = int.Parse(this.HdnIdPergunta.Value);
            Pergunta = new BllPergunta().ObterPerguntaPorQuestionarioEmpresaPergunta(IdQuestionarioEmpresa, Pergunta.IdPergunta, false);

            //armazena resposta em BD
            EntQuestionarioEmpresaResposta ent = new EntQuestionarioEmpresaResposta();
            ent.Valor01 = this.tx1_31.Text;
            ent.Valor02 = this.tx2_31.Text;
            ent.Valor03 = this.tx3_31.Text;
            ent.Pergunta.IdPergunta = this.Pergunta.IdPergunta;
            ent.QuestionarioEmpresa.IdQuestionarioEmpresa = this.IdQuestionarioEmpresa;
            if (this.respostaSelecionada.Value.Equals("A"))
            {
                ent.Resposta.IdPerguntaResposta = this.Pergunta.ListPerguntaResposta[0].IdPerguntaResposta;
            }
            else if (this.respostaSelecionada.Value.Equals("B"))
            {
                ent.Resposta.IdPerguntaResposta = this.Pergunta.ListPerguntaResposta[1].IdPerguntaResposta;
            }
            else if (this.respostaSelecionada.Value.Equals("C"))
            {
                ent.Resposta.IdPerguntaResposta = this.Pergunta.ListPerguntaResposta[2].IdPerguntaResposta;
            }
            else if (this.respostaSelecionada.Value.Equals("D"))
            {
                ent.Resposta.IdPerguntaResposta = this.Pergunta.ListPerguntaResposta[3].IdPerguntaResposta;
            }
            if (IdUsuarioLogado > 0)
            {
                ent.UsuarioDigitador.IdUsuario = IdUsuarioLogado;
            }
            if (ent.Resposta.IdPerguntaResposta > 0)
            {
                new BllQuestionarioEmpresaResposta().InserirAtualizar(ent);
            }
        }
    }
}