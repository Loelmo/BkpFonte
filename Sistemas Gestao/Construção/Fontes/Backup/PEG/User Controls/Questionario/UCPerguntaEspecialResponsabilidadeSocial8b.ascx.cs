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
    public partial class UCPerguntaEspecialResponsabilidadeSocial8b : UCQuestionarioBase
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
                this.HdnIdResposta.Value = Pergunta.ListPerguntaResposta[0].IdPerguntaResposta.ToString();

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

                MontarTabela(Pergunta);
            }
        }

        public void MontarTabela(EntPergunta Pergunta)
        {
            this.resposta1_1.Text = Pergunta.QuestionarioEmpresaResposta.Valor01;
            this.resposta1_2.Text = Pergunta.QuestionarioEmpresaResposta.Valor02;
            this.resposta2_1.Text = Pergunta.QuestionarioEmpresaResposta.Valor03;
            this.resposta2_2.Text = Pergunta.QuestionarioEmpresaResposta.Valor04;
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
            Pergunta.IdPergunta = int.Parse(HdnIdPergunta.Value);
            Int32 IdResposta = int.Parse(HdnIdResposta.Value);

            EntQuestionarioEmpresaResposta temp = new EntQuestionarioEmpresaResposta();

            temp.QuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
            temp.Pergunta.IdPergunta = Pergunta.IdPergunta;
            temp.Resposta.IdPerguntaResposta = IdResposta;
            temp.Valor01 = this.resposta1_1.Text;
            temp.Valor02 = this.resposta1_2.Text;
            temp.Valor03 = this.resposta2_1.Text;
            temp.Valor04 = this.resposta2_2.Text;
            if (IdUsuarioLogado > 0)
            {
                temp.UsuarioDigitador.IdUsuario = IdUsuarioLogado;
            }

            new BllQuestionarioEmpresaResposta().InserirAtualizar(temp);
        }
    }
}