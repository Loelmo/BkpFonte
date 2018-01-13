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
    public partial class UCPerguntaTexto : UCQuestionarioBase
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
                this.lblNumeroPergunta.Text = this.Pergunta.NumeroQuestao;
                this.lblPerguntaAjuda.Text = this.Pergunta.SaibaMais;
                this.cmbCriterios.Items.Clear();

                EntQuestionario q = new BllQuestionario().ObterPorIdTurmaIdQuestionarioEmpresa(IdTurma, IdQuestionarioEmpresa);
                porcent.InnerHtml = q.PorcentagemPreenchida + "% preenchido";
                barraPercent.Style.Value = "width:" + q.PorcentagemPreenchida + "%";
                if (this.isUltimaPergunta(q.IdQuestionario, Pergunta.IdPergunta))
                {
                    this.BtnProximo.ImageUrl = "/Image/finalizar.gif";
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

                if (this.Pergunta.QuestionarioEmpresaResposta.RespostaTexto != null)
                {
                    this.TxtResposta.Text = this.Pergunta.QuestionarioEmpresaResposta.RespostaTexto;
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
            ent.Pergunta.IdPergunta = this.Pergunta.IdPergunta;
            ent.QuestionarioEmpresa.IdQuestionarioEmpresa = this.IdQuestionarioEmpresa;
            ent.Resposta.IdPerguntaResposta = this.Pergunta.ListPerguntaResposta[0].IdPerguntaResposta;
            ent.RespostaTexto = this.TxtResposta.Text;
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