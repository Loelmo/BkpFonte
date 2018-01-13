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

namespace PEG.User_Controls.Avaliacao
{
    public partial class UCAdministrativoResponsabilidadeSocial : UCQuestionarioBase
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
                MontarTabela(lista);
            }
        }

        public void SetValores(Int32 IdQuestionario, Int32 IdQuestionarioEmpresa, Int32 IdEmpresaCadastro, Int32 IdTurma)
        {
            this.IdQuestionario = IdQuestionario;
            this.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
            this.IdEmpresaCadastro = IdEmpresaCadastro;
            this.IdTurma = IdTurma;
            this.HdnIdQuestionario.Value = IdQuestionario.ToString();
            this.HdnIdQuestionarioEmpresa.Value = IdQuestionarioEmpresa.ToString();
            this.HdnIdEmpresaCadastro.Value = IdEmpresaCadastro.ToString();
            this.HdnIdTurma.Value = IdTurma.ToString();
            List<EntPergunta> lista = new BllPergunta().ObterPerguntasPorQuestionarioEmpresa(IdQuestionario, IdQuestionarioEmpresa, false);
            MontarQuestionario(lista);
            MontarTabela(lista);
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
        public void MontarQuestionario(List<EntPergunta> lista)
        {
            for (int i = 11; i < lista.Count; i++)
            {
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_SIM_NAO)
                {
                    ((RadioButton)this.FindControl("pergunta" + (i - 9) + "_Sim")).Attributes.Add("onClick", "mostraAjuda('" + ((HtmlGenericControl)this.FindControl("justificativa" + (i - 9))).ClientID + "')");
                    ((RadioButton)this.FindControl("pergunta" + (i - 9) + "_Nao")).Attributes.Add("onClick", "escondeAjuda('" + ((HtmlGenericControl)this.FindControl("justificativa" + (i - 9))).ClientID + "')");
                    ((RadioButton)this.FindControl("pergunta" + (i - 9) + "_Sim")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i - 9) + "_Sim")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                    ((TextBox)this.FindControl("TxtResposta" + (i - 9))).Text = lista[i].QuestionarioEmpresaResposta.Justificativa;
                    if (lista[i].QuestionarioEmpresaResposta.RespostaBool)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i - 9) + "_Sim")).Checked = true;
                        ((HtmlGenericControl)this.FindControl("justificativa" + (i - 9))).Style.Add("display", "block");
                    }
                    else if (!lista[i].QuestionarioEmpresaResposta.RespostaBool)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i - 9) + "_Nao")).Checked = true;
                        ((HtmlGenericControl)this.FindControl("justificativa" + (i - 9))).Style.Add("display", "none");
                    }
                }
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_TEXTO)
                {
                    ((TextBox)this.FindControl("TxtResposta" + (i - 9))).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((TextBox)this.FindControl("TxtResposta" + (i - 9))).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                    ((TextBox)this.FindControl("TxtResposta" + (i - 9))).Text = lista[i].QuestionarioEmpresaResposta.RespostaTexto;
                }
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_MULTIPLA_ESCOLHA_4_OPCOES)
                {
                    if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[0].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i - 9) + "respostaA")).Checked = true;
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[1].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i - 9) + "respostaB")).Checked = true;
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[2].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i - 9) + "respostaC")).Checked = true;
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[3].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i - 9) + "respostaD")).Checked = true;
                    }
                    ((RadioButton)this.FindControl("pergunta" + (i - 9) + "respostaA")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i - 9) + "respostaA")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i - 9) + "respostaB")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i - 9) + "respostaB")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[1].IdPerguntaResposta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i - 9) + "respostaC")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i - 9) + "respostaC")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[2].IdPerguntaResposta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i - 9) + "respostaD")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("pergunta" + (i - 9) + "respostaD")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[3].IdPerguntaResposta.ToString());
                }
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_6_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2009_2010)
                {
                    ((Label)this.FindControl("label" + (i + 46))).Text = lista[i].Pergunta;
                    ((TextBox)this.FindControl("TxtResposta" + (i + 46))).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((TextBox)this.FindControl("TxtResposta" + (i + 46))).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                    ((TextBox)this.FindControl("TxtResposta" + (i + 46))).Text = lista[i].QuestionarioEmpresaResposta.RespostaTexto;
                }
            }
        }

        public void Close()
        {
            this.divPerguntas.Visible = false;
        }

        public void Gravar()
        {
            IdQuestionario = int.Parse(this.HdnIdQuestionario.Value);
            IdQuestionarioEmpresa = int.Parse(this.HdnIdQuestionarioEmpresa.Value);
            IdEmpresaCadastro = int.Parse(this.HdnIdEmpresaCadastro.Value);
            IdTurma = int.Parse(this.HdnIdTurma.Value);

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
            if(IdUsuarioLogado > 0){
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
                if(IdUsuarioLogado > 0){
                    temp.UsuarioDigitador.IdUsuario = IdUsuarioLogado;
                }
                listaResposta.Add(temp);
            }

            //demais perguntas
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 2));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 3));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 4));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 5));
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

            switch (NumeroPergunta){
                case 2:
                    temp = retornaPergunta2(temp);
                    break;
                case 3:
                    temp = retornaPergunta3(temp);
                    break;
                case 4:
                    temp = retornaPergunta4(temp);
                    break;
                case 5:
                    temp = retornaPergunta5(temp);
                    break;
               default:
                    temp = retornaPergunta6(temp, NumeroPergunta);
                    break;
            }
            return temp;
        }

        private EntQuestionarioEmpresaResposta retornaPergunta2(EntQuestionarioEmpresaResposta temp)
        {
            temp.Pergunta.IdPergunta = int.Parse(pergunta2_Sim.Attributes["perguntaId"]);
            temp.Resposta.IdPerguntaResposta = int.Parse(pergunta2_Sim.Attributes["respostaId"]);
            if (pergunta2_Sim.Checked)
            {
                temp.RespostaBool = true;
            }
            else if (pergunta2_Nao.Checked)
            {
                temp.RespostaBool = false;
            }
            temp.Justificativa = TxtResposta2.Text;

            return temp;
        }

        private EntQuestionarioEmpresaResposta retornaPergunta3(EntQuestionarioEmpresaResposta temp)
        {
            temp.Pergunta.IdPergunta = int.Parse(TxtResposta3.Attributes["perguntaId"]);
            temp.Resposta.IdPerguntaResposta = int.Parse(TxtResposta3.Attributes["respostaId"]);
            temp.RespostaTexto = TxtResposta3.Text;

            return temp;
        }

        private EntQuestionarioEmpresaResposta retornaPergunta4(EntQuestionarioEmpresaResposta temp)
        {
            temp.Pergunta.IdPergunta = int.Parse(TxtResposta4.Attributes["perguntaId"]);
            temp.Resposta.IdPerguntaResposta = int.Parse(TxtResposta4.Attributes["respostaId"]);
            temp.RespostaTexto = TxtResposta4.Text;

            return temp;
        }

        private EntQuestionarioEmpresaResposta retornaPergunta5(EntQuestionarioEmpresaResposta temp)
        {
            temp.Pergunta.IdPergunta = int.Parse(pergunta5respostaA.Attributes["perguntaId"]);
            if (pergunta5respostaA.Checked)
            {
                temp.Resposta.IdPerguntaResposta = int.Parse(pergunta5respostaA.Attributes["respostaId"]);
            }
            else if (pergunta5respostaB.Checked)
            {
                temp.Resposta.IdPerguntaResposta = int.Parse(pergunta5respostaB.Attributes["respostaId"]);
            }
            else if (pergunta5respostaC.Checked)
            {
                temp.Resposta.IdPerguntaResposta = int.Parse(pergunta5respostaC.Attributes["respostaId"]);
            }
            else if (pergunta5respostaD.Checked)
            {
                temp.Resposta.IdPerguntaResposta = int.Parse(pergunta5respostaD.Attributes["respostaId"]);
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