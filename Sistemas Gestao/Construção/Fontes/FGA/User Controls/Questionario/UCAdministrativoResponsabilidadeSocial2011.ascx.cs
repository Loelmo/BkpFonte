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
using System.Web.UI.HtmlControls;

namespace Sistema_de_Gestao.User_Controls
{
    public partial class UCAdministrativoResponsabilidadeSocial2011 : UCQuestionarioBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.HdnIdQuestionario.Value = IdQuestionario.ToString();
                this.HdnIdQuestionarioEmpresa.Value = IdQuestionarioEmpresa.ToString();
                this.HdnIdEmpresaCadastro.Value = IdEmpresaCadastro.ToString();
                this.HdnIdTurma.Value = IdTurma.ToString();

                List<EntPergunta> lista = new BllPergunta().ObterPerguntasPorQuestionarioEmpresa(IdQuestionario, IdQuestionarioEmpresa, false);
                MontarQuestionario(lista);
                pergunta1resposta1.Focus();
            }
        }

        public void MontarQuestionario(List<EntPergunta> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_7A_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011)
                {
                    this.resposta15_1.Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    this.resposta15_1.Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());

                    this.resposta15_1.Text = lista[i].QuestionarioEmpresaResposta.Valor01;
                    this.resposta15_2.Text = lista[i].QuestionarioEmpresaResposta.Valor02;
                    this.resposta15_3.Text = lista[i].QuestionarioEmpresaResposta.Valor03;
                    this.resposta15_4.Text = lista[i].QuestionarioEmpresaResposta.Valor04;
                    this.resposta15_5.Text = lista[i].QuestionarioEmpresaResposta.Valor05;
                }
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_8B_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011)
                {
                    this.TxtResposta18_1.Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    this.TxtResposta18_1.Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());

                    this.TxtResposta18_1.Text = lista[i].QuestionarioEmpresaResposta.Valor01;
                    this.TxtResposta18_2.Text = lista[i].QuestionarioEmpresaResposta.Valor02;
                    this.TxtResposta18_3.Text = lista[i].QuestionarioEmpresaResposta.Valor03;
                    this.TxtResposta18_4.Text = lista[i].QuestionarioEmpresaResposta.Valor04;
                }
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_TEXTO)
                {
                    ((TextBox)this.FindControl("TxtResposta" + (i + 1))).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((TextBox)this.FindControl("TxtResposta" + (i + 1))).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                    ((TextBox)this.FindControl("TxtResposta" + (i + 1))).Text = lista[i].QuestionarioEmpresaResposta.RespostaTexto;
                }
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_MULTIPLA_ESCOLHA_4_OPCOES || lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_3_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011)
                {
                    if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[0].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i + 1) + "resposta1")).Checked = true;
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[1].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i + 1) + "resposta2")).Checked = true;
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[2].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i + 1) + "resposta3")).Checked = true;
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[3].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i + 1) + "resposta4")).Checked = true;
                    }
                    ((RadioButton)this.FindControl("pergunta" + (i + 1) + "resposta1")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i + 1) + "resposta1")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i + 1) + "resposta2")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i + 1) + "resposta2")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[1].IdPerguntaResposta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i + 1) + "resposta3")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i + 1) + "resposta3")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[2].IdPerguntaResposta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i + 1) + "resposta4")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i + 1) + "resposta4")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[3].IdPerguntaResposta.ToString());
                }
            }
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Gravar();

            //Redireciona para a próxima pergunta
            Redireciona();
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            //Redireciona para a próxima pergunta
            Redireciona();
        }

        protected void Gravar()
        {
            IdQuestionario = int.Parse(this.HdnIdQuestionario.Value);
            IdQuestionarioEmpresa = int.Parse(this.HdnIdQuestionarioEmpresa.Value);
            IdEmpresaCadastro = int.Parse(this.HdnIdEmpresaCadastro.Value);
            IdTurma = int.Parse(this.HdnIdTurma.Value);

            List<EntQuestionarioEmpresaResposta> listaResposta = new List<EntQuestionarioEmpresaResposta>();

            //perguntas
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 1));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 2));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 3));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 4));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 5));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 6));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 7));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 8));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 9));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 10));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 11));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 12));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 13));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 14));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 15));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 16));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 17));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 18));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 19));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 20));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 21));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 22));

            foreach (EntQuestionarioEmpresaResposta qer in listaResposta)
            {
                new BllQuestionarioEmpresaResposta().InserirAtualizar(qer);
            }
        }

        private EntQuestionarioEmpresaResposta retornaResposta(int IdQuestionarioEmpresa, int NumeroPergunta)
        {
            EntQuestionarioEmpresaResposta temp = new EntQuestionarioEmpresaResposta();

            switch (NumeroPergunta){
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 16:
                    temp = retornaPerguntaMultiplaEscolha(NumeroPergunta);
                    break;
                case 17:
                case 19:
                case 20:
                case 21:
                case 22:
                    temp = retornaPerguntaTexto(NumeroPergunta);
                    break;
                case 15:
                    temp = retornaPergunta7a();
                    break;
                case 18:
                    temp = retornaPergunta8b();
                    break;
            }
            temp.QuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
            temp.UsuarioDigitador.IdUsuario = UsuarioLogado.IdUsuario;

            return temp;
        }

        private EntQuestionarioEmpresaResposta retornaPerguntaTexto(Int32 numero)
        {
            EntQuestionarioEmpresaResposta ent = new EntQuestionarioEmpresaResposta();

            ent.Pergunta.IdPergunta = int.Parse(((TextBox)this.FindControl("TxtResposta" + (numero))).Attributes["perguntaId"]);
            ent.Resposta.IdPerguntaResposta = int.Parse(((TextBox)this.FindControl("TxtResposta" + (numero))).Attributes["respostaId"]);
            ent.RespostaTexto = ((TextBox)this.FindControl("TxtResposta" + (numero))).Text;

            return ent;
        }

        private EntQuestionarioEmpresaResposta retornaPergunta7a()
        {
            EntQuestionarioEmpresaResposta ent = new EntQuestionarioEmpresaResposta();

            ent.Pergunta.IdPergunta = int.Parse(this.resposta15_1.Attributes["perguntaId"]);
            ent.Resposta.IdPerguntaResposta = int.Parse(this.resposta15_1.Attributes["respostaId"]);

            ent.Valor01 = this.resposta15_1.Text;
            ent.Valor02 = this.resposta15_2.Text;
            ent.Valor03 = this.resposta15_3.Text;
            ent.Valor04 = this.resposta15_4.Text;
            ent.Valor05 = this.resposta15_5.Text;

            return ent;
        }

        private EntQuestionarioEmpresaResposta retornaPerguntaMultiplaEscolha(Int32 numero)
        {
            //armazena resposta em BD
            EntQuestionarioEmpresaResposta ent = new EntQuestionarioEmpresaResposta();
            if (((RadioButton)this.FindControl("pergunta" + (numero) + "resposta1")).Checked)
            {
                ent.Pergunta.IdPergunta = int.Parse(((RadioButton)this.FindControl("pergunta" + (numero) + "resposta1")).Attributes["perguntaId"]);
                ent.Resposta.IdPerguntaResposta = int.Parse(((RadioButton)this.FindControl("pergunta" + (numero) + "resposta1")).Attributes["respostaId"]);
            }
            else if (((RadioButton)this.FindControl("pergunta" + (numero) + "resposta2")).Checked)
            {
                ent.Pergunta.IdPergunta = int.Parse(((RadioButton)this.FindControl("pergunta" + (numero) + "resposta2")).Attributes["perguntaId"]);
                ent.Resposta.IdPerguntaResposta = int.Parse(((RadioButton)this.FindControl("pergunta" + (numero) + "resposta2")).Attributes["respostaId"]);
            }
            else if (((RadioButton)this.FindControl("pergunta" + (numero) + "resposta3")).Checked)
            {
                ent.Pergunta.IdPergunta = int.Parse(((RadioButton)this.FindControl("pergunta" + (numero) + "resposta3")).Attributes["perguntaId"]);
                ent.Resposta.IdPerguntaResposta = int.Parse(((RadioButton)this.FindControl("pergunta" + (numero) + "resposta3")).Attributes["respostaId"]);
            }
            else if (((RadioButton)this.FindControl("pergunta" + (numero) + "resposta4")).Checked)
            {
                ent.Pergunta.IdPergunta = int.Parse(((RadioButton)this.FindControl("pergunta" + (numero) + "resposta4")).Attributes["perguntaId"]);
                ent.Resposta.IdPerguntaResposta = int.Parse(((RadioButton)this.FindControl("pergunta" + (numero) + "resposta4")).Attributes["respostaId"]);
            }

            return ent;
        }

        private EntQuestionarioEmpresaResposta retornaPergunta8b()
        {
            EntQuestionarioEmpresaResposta ent = new EntQuestionarioEmpresaResposta();

            ent.Pergunta.IdPergunta = int.Parse(this.TxtResposta18_1.Attributes["perguntaId"]);
            ent.Resposta.IdPerguntaResposta = int.Parse(this.TxtResposta18_1.Attributes["respostaId"]);

            ent.Valor01 = this.TxtResposta18_1.Text;
            ent.Valor02 = this.TxtResposta18_2.Text;
            ent.Valor03 = this.TxtResposta18_3.Text;
            ent.Valor04 = this.TxtResposta18_4.Text;

            return ent;
        }
    }
}