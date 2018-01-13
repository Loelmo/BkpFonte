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
    public partial class UCPerguntaEspecialResponsabilidadeSocial6 : UCQuestionarioBase
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
                MontarQuestionario(lista);
            }
        }

        public void MontarQuestionario(List<EntPergunta> lista)
        {
            for (int i = 11; i < lista.Count; i++)
            {
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_6_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2009_2010)
                {
                    ((Label)this.FindControl("label" + (i + 46))).Text = lista[i].Pergunta;
                    ((TextBox)this.FindControl("TxtResposta" + (i + 46))).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((TextBox)this.FindControl("TxtResposta" + (i + 46))).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                    ((TextBox)this.FindControl("TxtResposta" + (i + 46))).Text = lista[i].QuestionarioEmpresaResposta.RespostaTexto;
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
            Pergunta.IdPergunta = int.Parse(TxtResposta61.Attributes["perguntaId"]);

            List<EntQuestionarioEmpresaResposta> listaResposta = new List<EntQuestionarioEmpresaResposta>();

            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 61));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 62));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 63));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 64));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 65));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 66));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 67));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 68));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 69));

            foreach (EntQuestionarioEmpresaResposta qer in listaResposta)
            {
                new BllQuestionarioEmpresaResposta().InserirAtualizar(qer);
            }
        }

        private EntQuestionarioEmpresaResposta retornaResposta(int IdQuestionarioEmpresa, int NumeroPergunta)
        {
            EntQuestionarioEmpresaResposta temp = new EntQuestionarioEmpresaResposta();
            temp.QuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
            temp = retornaPergunta6(temp, NumeroPergunta);
            if (IdUsuarioLogado > 0)
            {
                temp.UsuarioDigitador.IdUsuario = IdUsuarioLogado;
            }
            return temp;
        }

        private EntQuestionarioEmpresaResposta retornaPergunta6(EntQuestionarioEmpresaResposta temp, int Numero)
        {
            temp.Pergunta.IdPergunta = int.Parse(((TextBox)this.FindControl("TxtResposta" + (Numero))).Attributes["perguntaId"]);
            temp.Resposta.IdPerguntaResposta = int.Parse(((TextBox)this.FindControl("TxtResposta" + (Numero))).Attributes["respostaId"]);
            temp.RespostaTexto = ((TextBox)this.FindControl("TxtResposta" + (Numero))).Text;

            return temp;
        }
    }
}