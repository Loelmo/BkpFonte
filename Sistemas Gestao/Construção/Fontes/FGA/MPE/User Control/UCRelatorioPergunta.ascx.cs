using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Vinit.SG.BLL;

namespace Sistema_de_Gestao.MPE.User_Control
{
    public partial class UCRelatorioPergunta : System.Web.UI.UserControl
    {
        EntPergunta objPergunta;
        String Justificativa;
        String RespostaAutomatica;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GerarPerguntas(List<EntPergunta> lstEntPergunta, EnumType.Questionario Questionario)
        {
            String html = "";

            switch (Questionario)
            {
                case EnumType.Questionario.ResponsabilidadeSocial:
                    html += "<table>";
                    html += this.MontarQuestionarioResponsabilidadeSocial(lstEntPergunta);
                    this.divPerguntas.Visible = true;
                    html += "</table>";
                    html += "<br/>";
                    break;
                default:
                    this.divPerguntas.Visible = false;
                    foreach (EntPergunta objPergunta in lstEntPergunta)
                    {
                        html += "<table style='width:850px;' cellspacing='10'>";
                        this.objPergunta = objPergunta;
                        html += GerarPergunta(objPergunta);
                        html += "</table>";
                        html += "<br/>";
                    }
                    break;
            }


            this.ltrPerguntas.Text = html;
        }

        private String GerarPergunta(EntPergunta objPergunta)
        {
            String html = "";

            html += "    <tr>";
            html += "       <td colspan='2'><b>";
            html += objPergunta.NumeroQuestao;
            html += "       &nbsp;&nbsp;";
            html += objPergunta.Pergunta;
            html += "       </b></td>";
            html += "    </tr>";
            html += GerarRespostas(objPergunta.ListPerguntaResposta);
            objPergunta.QuestionarioEmpresaResposta.Resposta = new BllPerguntaResposta().ObterPorId(objPergunta.QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta);
            html += GerarJustificativa(objPergunta.QuestionarioEmpresaResposta);
            html += GerarRespostaAutomatica(objPergunta.QuestionarioEmpresaResposta);
            html += "<br>";
            return html;
        }

        private String GerarLetra(Int32 nOrdem)
        {
            switch (nOrdem)
            {
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                case 4:
                    return "D";
            }
            return "";
        }

        private String GerarJustificativa(EntQuestionarioEmpresaResposta objQuestionarioEmpresaResposta)
        {
            String html = "";
            if (objQuestionarioEmpresaResposta.Resposta.PossuiJustificativa)
            {
                if (objQuestionarioEmpresaResposta.Pergunta.PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_MULTIPLA_ESCOLHA_4_OPCOES)
                {
                    html += "    <tr>";
                    html += "       <td colspan='2'>";
                    html += "<b>Justificativa:</b>";
                    html += "       </td>";
                    html += "    </tr>";
                    html += "    <tr>";
                    html += "       <td style='border:1px solid black;' colspan='2'>";
                    html += objQuestionarioEmpresaResposta.Justificativa;
                    html += "       </td>";
                    html += "    </tr>";
                }
                else if (objQuestionarioEmpresaResposta.Pergunta.PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_32_QUESTIONARIO_GESTAO_2011 && objQuestionarioEmpresaResposta.Pergunta.IdPergunta != 208)
                {
                    html += "    <tr>";
                    html += "       <td colspan='2'>";
                    html += "<table style='border:1px solid black;'>";
                    html += "    <tr>";
                    html += "       <td style='border:1px solid black;'>";
                    html += "<b>Resultados relativos a:</b>";
                    html += "       </td>";
                    html += "       <td style='border:1px solid black;'>";
                    html += "<b>2008:</b>";
                    html += "       </td>";
                    html += "       <td style='border:1px solid black;'>";
                    html += "<b>2009:</b>";
                    html += "       </td>";
                    html += "       <td style='border:1px solid black;'>";
                    html += "<b>2010:</b>";
                    html += "       </td>";
                    html += "       <td style='border:1px solid black;'>";
                    html += "<b>Desempenho:</b>";
                    html += "       </td>";
                    html += "    </tr>";
                    html += "    <tr>";
                    html += "       <td style='border:1px solid black;'>";
                    html += "       </td>";
                    html += "       <td style='border:1px solid black;'>";
                    html += objQuestionarioEmpresaResposta.Valor01;
                    html += "       </td>";
                    html += "       <td style='border:1px solid black;'>";
                    html += objQuestionarioEmpresaResposta.Valor02;
                    html += "       </td>";
                    html += "       <td style='border:1px solid black;'>";
                    html += objQuestionarioEmpresaResposta.Valor03;
                    html += "       </td>";
                    html += "       <td style='border:1px solid black;'>";
                    if (objQuestionarioEmpresaResposta.Pergunta.IdPergunta == 206 || objQuestionarioEmpresaResposta.Pergunta.IdPergunta == 204)
                    {
                        html += "Quanto menor melhor";
                    }
                    else
                    {
                        html += "Quanto maior melhor";
                    }
                    html += "       </td>";
                    html += "    </tr>";
                    html += "</table>";
                    html += "       </td>";
                    html += "    </tr>";
                }
            }
            return html;
        }

        private String GerarRespostaAutomatica(EntQuestionarioEmpresaResposta objQuestionarioEmpresaResposta)
        {
            String html = "";
            html += "    <tr>";
            html += "       <td colspan='2'>";
            html += "<b>Comentário para a empresa:</b>";
            html += "       </td>";
            html += "    </tr>";
            html += "    <tr>";
            html += "       <td style='width:30px;border:1px solid black;text-align:center;'>";
            html += GerarLetra(objQuestionarioEmpresaResposta.Resposta.Ordem);
            html += "       </td>";
            html += "       <td style='border:1px solid black;'>";
            html += objQuestionarioEmpresaResposta.Resposta.RespostaAutomatica;
            html += "       </td>";
            html += "    </tr>";

            return html;
        }

        private String GerarRespostas(List<EntPerguntaResposta> lstPerguntaRespostas)
        {
            String html = "";
            foreach (EntPerguntaResposta objPerguntaResposta in lstPerguntaRespostas)
            {
                html += GerarResposta(objPerguntaResposta);
            }

            return html;
        }

        private String GerarResposta(EntPerguntaResposta objPerguntaResposta)
        {
            String html = "";
            html += "    <tr" + VerificaPerguntaRespondida(objPerguntaResposta) + " >";
            html += "       <td colspan='2'>";
            html += this.OrdemDaResposta(objPerguntaResposta.Ordem);
            html += "       &nbsp;&nbsp;";
            html += objPerguntaResposta.PerguntaResposta;
            html += "       </td>";
            html += "    </tr>";

            return html;
        }

        private String VerificaPerguntaRespondida(EntPerguntaResposta objPerguntaResposta)
        {
            String style = "";
            if (objPergunta.QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == objPerguntaResposta.IdPerguntaResposta)
            {
                style = " style=\"background-color: lightblue;\" ";
                if (objPerguntaResposta.PossuiJustificativa)
                {
                    this.GeraRespostaParaEmpresa(objPerguntaResposta);
                    this.GeraJustificativa(objPergunta);
                }
            }
            return style;
        }

        private String OrdemDaResposta(Int32 ordem)
        {
            String retorno = "";
            switch (ordem)
            {
                case 1:
                    retorno = "a)";
                    break;
                case 2:
                    retorno = "b)";
                    break;
                case 3:
                    retorno = "c)";
                    break;
                case 4:
                    retorno = "d)";
                    break;
                default:
                    break;
            }

            return retorno;
        }

        private void GeraRespostaParaEmpresa(EntPerguntaResposta objPerguntaResposta)
        {
            String html;
            html = "<br>";
            html += "<strong>Comentário para a empresa: </strong>";
            html += "<table cellspacing=1 cellpadding=3 bgcolor=\"#000000\" width=100%>";
            html += "   <tr bgcolor=\"#FFFFFF\">";
            html += "       <td style=\"width: 33px;\">";
            html += this.OrdemDaResposta(objPerguntaResposta.Ordem);
            html += "       </td>";
            html += "       <td>";
            html += objPerguntaResposta.RespostaAutomatica;
            html += "       </td>";
            html += "   </tr>";
            html += "</table>";
            html += "<br>";
            this.RespostaAutomatica = html;
        }

        private void GeraJustificativa(EntPergunta objPergunta)
        {
            String html;
            html = "<br>";
            html += "<table cellspacing=1 cellpadding=3 bgcolor=\"#000000\" width=100%>";
            html += "   <tr bgcolor=\"#FFFFFF\">";
            html += "       <td>";
            html += "           <strong>Justificativa:</strong>";
            html += "       </td>";
            html += "   </tr>";
            html += "   <tr bgcolor=\"#FFFFFF\">";
            html += "       <td>";
            html += objPergunta.QuestionarioEmpresaResposta.Justificativa;
            html += "       </td>";
            html += "   </tr>";
            html += "</table>";
            html += "<br>";

            this.Justificativa = html;
        }

        private String MontarQuestionarioResponsabilidadeSocial(List<EntPergunta> lstEntPergunta)
        {
            String html = "";
            String htmlTabelaPopulada = "<table>";
            String htmlTabelaPopulada2 = "<table>";
            String htmlTabelaPopulada3 = "<table>";
            Boolean tabelaPopulada = false;
            Boolean tabelaCampoTexto = false;
            Boolean Questao18Preenchida = false;
            foreach (EntPergunta objPergunta in lstEntPergunta)
            {
                if (!tabelaPopulada && objPergunta.PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_3_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011)
                {
                    MontarTabelaRespSocial(lstEntPergunta);
                    tabelaPopulada = true;
                }
                else if (!tabelaPopulada && objPergunta.PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_MULTIPLA_ESCOLHA_4_OPCOES)
                {
                    this.objPergunta = objPergunta;
                    html += GerarPergunta(objPergunta);
                    html += this.RespostaAutomatica;
                    html += this.Justificativa;
                    html += "<br/>";
                }
                else if (objPergunta.PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_8B_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011)
                {
                    MontarTabelaQuestao18(objPergunta);
                    Questao18Preenchida = true;
                }
                else if (!tabelaCampoTexto && tabelaPopulada && objPergunta.PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_7A_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011)
                {
                    MontarTabelaCampoTexto(objPergunta);
                    tabelaCampoTexto = true;
                }
                else if (tabelaPopulada && objPergunta.PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_MULTIPLA_ESCOLHA_4_OPCOES)
                {
                    this.objPergunta = objPergunta;

                    if (tabelaCampoTexto)
                    {
                        htmlTabelaPopulada2 += GerarPergunta(objPergunta);
                        htmlTabelaPopulada2 += this.RespostaAutomatica;
                        htmlTabelaPopulada2 += this.Justificativa;
                        html += "<br/>";
                    }
                    else if (Questao18Preenchida)
                    {
                        htmlTabelaPopulada3 += GerarPergunta(objPergunta);
                        htmlTabelaPopulada3 += this.RespostaAutomatica;
                        htmlTabelaPopulada3 += this.Justificativa;
                        html += "<br/>";
                    }
                    else
                    {
                        htmlTabelaPopulada += GerarPergunta(objPergunta);
                        htmlTabelaPopulada += this.RespostaAutomatica;
                        htmlTabelaPopulada += this.Justificativa;
                        html += "<br/>";
                    }

                }
                else if (tabelaPopulada && objPergunta.PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_TEXTO)
                {
                    if (tabelaCampoTexto && !Questao18Preenchida)
                    {
                        htmlTabelaPopulada2 += MontarQuestaoCampoTexto(objPergunta);
                    }
                    else if (Questao18Preenchida)
                    {
                        htmlTabelaPopulada3 += MontarQuestaoCampoTexto(objPergunta);
                    }
                }
            }

            htmlTabelaPopulada += "</table>";
            this.ltrRespSocial.Text = htmlTabelaPopulada;
            htmlTabelaPopulada2 += "</table>";
            this.ltrRespSocial2.Text = htmlTabelaPopulada2;
            htmlTabelaPopulada3 += "</table>";
            this.ltrRespSocial3.Text = htmlTabelaPopulada3;
            return html;
        }

        private void MontarTabelaRespSocial(List<EntPergunta> lista)
        {
            for (int i = 3; i < 11; i++)
            {
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_3_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2011)
                {
                    this.divPerguntas.Visible = true;
                    ((RadioButton)divPerguntas.FindControl("resposta" + (i - 2) + "_1")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)divPerguntas.FindControl("resposta" + (i - 2) + "_1")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                    ((RadioButton)divPerguntas.FindControl("resposta" + (i - 2) + "_2")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)divPerguntas.FindControl("resposta" + (i - 2) + "_2")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[1].IdPerguntaResposta.ToString());
                    ((RadioButton)divPerguntas.FindControl("resposta" + (i - 2) + "_3")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)divPerguntas.FindControl("resposta" + (i - 2) + "_3")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[2].IdPerguntaResposta.ToString());
                    ((RadioButton)divPerguntas.FindControl("resposta" + (i - 2) + "_4")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)divPerguntas.FindControl("resposta" + (i - 2) + "_4")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[3].IdPerguntaResposta.ToString());

                    if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[0].IdPerguntaResposta)
                    {
                        ((RadioButton)divPerguntas.FindControl("resposta" + (i - 2) + "_1")).Checked = true;
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[1].IdPerguntaResposta)
                    {
                        ((RadioButton)divPerguntas.FindControl("resposta" + (i - 2) + "_2")).Checked = true;
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[2].IdPerguntaResposta)
                    {
                        ((RadioButton)divPerguntas.FindControl("resposta" + (i - 2) + "_3")).Checked = true;
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[3].IdPerguntaResposta)
                    {
                        ((RadioButton)divPerguntas.FindControl("resposta" + (i - 2) + "_4")).Checked = true;
                    }
                }
            }
        }

        private void MontarTabelaCampoTexto(EntPergunta Pergunta)
        {
            this.label9.Text = Pergunta.ListPerguntaResposta[0].Valor1;
            this.label10.Text = Pergunta.ListPerguntaResposta[0].Valor2;
            this.label11.Text = Pergunta.ListPerguntaResposta[0].Valor3;
            this.label12.Text = Pergunta.ListPerguntaResposta[0].Valor4;
            this.label13.Text = Pergunta.ListPerguntaResposta[0].Valor5;
            this.resposta1.Text = Pergunta.QuestionarioEmpresaResposta.Valor01;
            this.resposta2.Text = Pergunta.QuestionarioEmpresaResposta.Valor02;
            this.resposta3.Text = Pergunta.QuestionarioEmpresaResposta.Valor03;
            this.resposta4.Text = Pergunta.QuestionarioEmpresaResposta.Valor04;
            this.resposta5.Text = Pergunta.QuestionarioEmpresaResposta.Valor05;

        }

        private String MontarQuestaoCampoTexto(EntPergunta Pergunta)
        {
            String html = "";
            html = "<table>";
            html += "    <tr>";
            html += "       <td>";
            html += Pergunta.Ordem;
            html += "       .&nbsp;&nbsp;";
            html += Pergunta.Pergunta;
            html += "       </td>";
            html += "    </tr>";
            html += "    <tr>";
            html += "       <td>";
            html += "           <textarea name=" + Pergunta.IdPergunta + "rows=\"5\" cols=\"20\" id=" + Pergunta.IdPergunta + " style=\"font-family:Arial;font-size:12px;width:99%;\">" + Pergunta.QuestionarioEmpresaResposta.RespostaTexto + "</textarea>";
            html += "       </td>";
            html += "    </tr>";
            html += "</table>";

            return html;
        }

        private void MontarTabelaQuestao18(EntPergunta Pergunta)
        {
            this.resposta1_1.Text = Pergunta.QuestionarioEmpresaResposta.Valor01;
            this.resposta1_2.Text = Pergunta.QuestionarioEmpresaResposta.Valor02;
            this.resposta2_1.Text = Pergunta.QuestionarioEmpresaResposta.Valor03;
            this.resposta2_2.Text = Pergunta.QuestionarioEmpresaResposta.Valor04;
        }

    }
}