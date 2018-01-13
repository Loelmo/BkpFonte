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
    public partial class UCPerguntaEspecialResponsabilidadeSocial1 : UCQuestionarioBase
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

            for (int i = 0; i < 11; i++)
            {
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_1_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2009_2010 && !lista[i].PerguntaInterna)
                {
                    pergunta1respostaSim.Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    pergunta1respostaSim.Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                    pergunta1respostaSim.Attributes.Add("onClick", "mostraAjuda('" + tabela1.ClientID + "')");
                    pergunta1respostaNao.Attributes.Add("onClick", "escondeAjuda('" + tabela1.ClientID + "')");
                    if (lista[i].QuestionarioEmpresaResposta.RespostaBool)
                    {
                        this.pergunta1respostaSim.Checked = true;
                        tabela1.Style.Add("display", "block");
                    }
                    else if (!lista[i].QuestionarioEmpresaResposta.RespostaBool)
                    {
                        this.pergunta1respostaNao.Checked = true;
                        tabela1.Style.Add("display", "none");
                    }
                }
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_1_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2009_2010 && lista[i].PerguntaInterna)
                {
                    ((Label)this.FindControl("label1_" + (i))).Text = lista[i].Pergunta;
                    ((TextBox)this.FindControl("resposta" + (i) + "_1")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((TextBox)this.FindControl("resposta" + (i) + "_1")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                    ((TextBox)this.FindControl("resposta" + (i) + "_1")).Text = lista[i].QuestionarioEmpresaResposta.Valor01;
                    ((TextBox)this.FindControl("resposta" + (i) + "_2")).Text = lista[i].QuestionarioEmpresaResposta.Valor02;

                    if (lista[i].QuestionarioEmpresaResposta.RespostaBool)
                    {
                        ((RadioButton)this.FindControl("resposta" + (i) + "_P")).Checked = true;
                    }
                    else if (!lista[i].QuestionarioEmpresaResposta.RespostaBool)
                    {
                        ((RadioButton)this.FindControl("resposta" + (i) + "_C")).Checked = true;
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
            Pergunta.IdPergunta = int.Parse(pergunta1respostaSim.Attributes["perguntaId"]);

            List<EntQuestionarioEmpresaResposta> listaResposta = new List<EntQuestionarioEmpresaResposta>();

            //pergunta 1
            EntQuestionarioEmpresaResposta temp = new EntQuestionarioEmpresaResposta();
            temp.Pergunta.IdPergunta = int.Parse(pergunta1respostaSim.Attributes["perguntaId"]);
            temp.QuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
            temp.Resposta.IdPerguntaResposta = int.Parse(pergunta1respostaSim.Attributes["respostaId"]);
            if (pergunta1respostaSim.Checked)
            {
                temp.RespostaBool = true;
            }
            else if (pergunta1respostaNao.Checked)
            {
                temp.RespostaBool = false;
            }
            if (IdUsuarioLogado > 0)
            {
                temp.UsuarioDigitador.IdUsuario = IdUsuarioLogado;
            }
            listaResposta.Add(temp);

            //tabela 1
            for (int i = 1; i < 11; i++)
            {
                temp = new EntQuestionarioEmpresaResposta();

                temp.QuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                temp.Pergunta.IdPergunta = int.Parse(((TextBox)this.FindControl("resposta" + (i) + "_1")).Attributes["perguntaId"]);
                temp.Resposta.IdPerguntaResposta = int.Parse(((TextBox)this.FindControl("resposta" + (i) + "_1")).Attributes["respostaId"]);
                temp.Valor01 = ((TextBox)this.FindControl("resposta" + (i) + "_1")).Text;
                temp.Valor02 = ((TextBox)this.FindControl("resposta" + (i) + "_2")).Text;
                if (((RadioButton)this.FindControl("resposta" + (i) + "_P")).Checked)
                {
                    temp.RespostaBool = true;
                }
                else
                {
                    temp.RespostaBool = false;
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