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

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCPerguntaEspecialResponsabilidadeSocial3 : UCQuestionarioBase
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

                List<EntPergunta> lista = new BllPergunta().ObterPerguntasPorQuestionarioEmpresa(IdQuestionario, IdQuestionarioEmpresa, false);
                MontarTabela(lista);
            }
        }

        public void MontarTabela(List<EntPergunta> lista)
        {

            for (int i = 3; i < 11; i++)
            {
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_3_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011)
                {
                    ((RadioButton)this.FindControl("resposta" + (i - 2) + "_1")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("resposta" + (i - 2) + "_1")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                    ((RadioButton)this.FindControl("resposta" + (i - 2) + "_2")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("resposta" + (i - 2) + "_2")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[1].IdPerguntaResposta.ToString());
                    ((RadioButton)this.FindControl("resposta" + (i - 2) + "_3")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("resposta" + (i - 2) + "_3")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[2].IdPerguntaResposta.ToString());
                    ((RadioButton)this.FindControl("resposta" + (i - 2) + "_4")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("resposta" + (i - 2) + "_4")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[3].IdPerguntaResposta.ToString());

                    if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[0].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("resposta" + (i - 2) + "_1")).Checked = true;
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[1].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("resposta" + (i - 2) + "_2")).Checked = true;
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[2].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("resposta" + (i - 2) + "_3")).Checked = true;
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[3].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("resposta" + (i - 2) + "_4")).Checked = true;
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
            Pergunta.IdPergunta = int.Parse(resposta1_1.Attributes["perguntaId"]);

            List<EntQuestionarioEmpresaResposta> listaResposta = new List<EntQuestionarioEmpresaResposta>();

            //tabela 1
            for (int i = 1; i < 9; i++)
            {
                EntQuestionarioEmpresaResposta temp = new EntQuestionarioEmpresaResposta();

                temp.QuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                temp.Pergunta.IdPergunta = int.Parse(((CheckBox)this.FindControl("resposta" + (i) + "_1")).Attributes["perguntaId"]);
                if (((RadioButton)this.FindControl("resposta" + (i) + "_1")).Checked)
                {
                    temp.Resposta.IdPerguntaResposta = int.Parse(((RadioButton)this.FindControl("resposta" + (i) + "_1")).Attributes["respostaId"]);
                }
                else if (((RadioButton)this.FindControl("resposta" + (i) + "_2")).Checked)
                {
                    temp.Resposta.IdPerguntaResposta = int.Parse(((RadioButton)this.FindControl("resposta" + (i) + "_2")).Attributes["respostaId"]);
                }
                else if (((RadioButton)this.FindControl("resposta" + (i) + "_3")).Checked)
                {
                    temp.Resposta.IdPerguntaResposta = int.Parse(((RadioButton)this.FindControl("resposta" + (i) + "_3")).Attributes["respostaId"]);
                }
                else if (((RadioButton)this.FindControl("resposta" + (i) + "_4")).Checked)
                {
                    temp.Resposta.IdPerguntaResposta = int.Parse(((RadioButton)this.FindControl("resposta" + (i) + "_4")).Attributes["respostaId"]);
                }
                if (IdUsuarioLogado > 0)
                {
                    temp.UsuarioDigitador.IdUsuario = IdUsuarioLogado;
                }
                listaResposta.Add(temp);
            }

            foreach (EntQuestionarioEmpresaResposta qer in listaResposta)
            {
                new BllQuestionarioEmpresaResposta().InserirAtualizar(qer);
            }
        }
    }
}