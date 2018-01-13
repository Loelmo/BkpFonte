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

namespace PEG.User_Controls.Avaliacao
{
    public partial class UCAdministrativoGestao2011 : UCQuestionarioBase
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
                this.pergunta1respostaA.Focus();
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
            this.pergunta1respostaA.Focus();
        }

        public void MontarQuestionario(List<EntPergunta> lista)
        {
            int totalRespondidas = 0;

            for (int i = 0; i < 37; i++)
            {
                for (int j = 0; j < lista[i].ListPerguntaResposta.Count; j++)
                {
                    if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_32_QUESTIONARIO_GESTAO_2011)
                    {
                        if (this.FindControl("tx1_" + (i + 1)) != null)
                        {
                            if (lista[i].ListPerguntaResposta[0].PossuiJustificativa)
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaA")).Attributes.Add("onClick", "HabilitaCampos('" + ((TextBox)this.FindControl("tx1_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx2_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx3_" + (i + 1))).ClientID + "')");
                            else
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaA")).Attributes.Add("onClick", "DesabilitaCampos('" + ((TextBox)this.FindControl("tx1_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx2_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx3_" + (i + 1))).ClientID + "')");
                            if (lista[i].ListPerguntaResposta[1].PossuiJustificativa)
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaB")).Attributes.Add("onClick", "HabilitaCampos('" + ((TextBox)this.FindControl("tx1_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx2_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx3_" + (i + 1))).ClientID + "')");
                            else
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaB")).Attributes.Add("onClick", "DesabilitaCampos('" + ((TextBox)this.FindControl("tx1_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx2_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx3_" + (i + 1))).ClientID + "')");
                            if (lista[i].ListPerguntaResposta[2].PossuiJustificativa)
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaC")).Attributes.Add("onClick", "HabilitaCampos('" + ((TextBox)this.FindControl("tx1_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx2_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx3_" + (i + 1))).ClientID + "')");
                            else
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaC")).Attributes.Add("onClick", "DesabilitaCampos('" + ((TextBox)this.FindControl("tx1_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx2_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx3_" + (i + 1))).ClientID + "')");
                            if (lista[i].ListPerguntaResposta[3].PossuiJustificativa)
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaD")).Attributes.Add("onClick", "HabilitaCampos('" + ((TextBox)this.FindControl("tx1_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx2_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx3_" + (i + 1))).ClientID + "')");
                            else
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaD")).Attributes.Add("onClick", "DesabilitaCampos('" + ((TextBox)this.FindControl("tx1_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx2_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx3_" + (i + 1))).ClientID + "')");
                        }
                    }
                    else if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_MULTIPLA_ESCOLHA_4_OPCOES)
                    {
                        if (((TextBox)this.FindControl("justificativa" + (i + 1))) != null)
                        {
                            if (lista[i].ListPerguntaResposta[0].PossuiJustificativa)
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaA")).Attributes.Add("onClick", "HabilitaCampoUnico('" + ((TextBox)this.FindControl("justificativa" + (i + 1))).ClientID + "')");
                            else
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaA")).Attributes.Add("onClick", "DesabilitaCampoUnico('" + ((TextBox)this.FindControl("justificativa" + (i + 1))).ClientID + "')");
                            if (lista[i].ListPerguntaResposta[1].PossuiJustificativa)
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaB")).Attributes.Add("onClick", "HabilitaCampoUnico('" + ((TextBox)this.FindControl("justificativa" + (i + 1))).ClientID + "')");
                            else
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaB")).Attributes.Add("onClick", "DesabilitaCampoUnico('" + ((TextBox)this.FindControl("justificativa" + (i + 1))).ClientID + "')");
                            if (lista[i].ListPerguntaResposta[2].PossuiJustificativa)
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaC")).Attributes.Add("onClick", "HabilitaCampoUnico('" + ((TextBox)this.FindControl("justificativa" + (i + 1))).ClientID + "')");
                            else
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaC")).Attributes.Add("onClick", "DesabilitaCampoUnico('" + ((TextBox)this.FindControl("justificativa" + (i + 1))).ClientID + "')");
                            if (lista[i].ListPerguntaResposta[3].PossuiJustificativa)
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaD")).Attributes.Add("onClick", "HabilitaCampoUnico('" + ((TextBox)this.FindControl("justificativa" + (i + 1))).ClientID + "')");
                            else
                                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaD")).Attributes.Add("onClick", "DesabilitaCampoUnico('" + ((TextBox)this.FindControl("justificativa" + (i + 1))).ClientID + "')");
                        }
                    }
                }

                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_32_QUESTIONARIO_GESTAO_2011)
                {
                    if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[0].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaA")).Checked = true;
                        totalRespondidas++;
                        if (lista[i].ListPerguntaResposta[0].PossuiJustificativa && this.FindControl("tx1_" + (i + 1)) != null)
                        {
                            ((TextBox)this.FindControl("tx1_" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("tx1_" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                            ((TextBox)this.FindControl("tx2_" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("tx2_" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                            ((TextBox)this.FindControl("tx3_" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("tx3_" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                        }
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[1].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaB")).Checked = true;
                        totalRespondidas++;
                        if (lista[i].ListPerguntaResposta[1].PossuiJustificativa && this.FindControl("tx1_" + (i + 1)) != null)
                        {
                            ((TextBox)this.FindControl("tx1_" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("tx1_" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                            ((TextBox)this.FindControl("tx2_" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("tx2_" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                            ((TextBox)this.FindControl("tx3_" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("tx3_" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                        }
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[2].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaC")).Checked = true;
                        totalRespondidas++;
                        if (lista[i].ListPerguntaResposta[2].PossuiJustificativa && this.FindControl("tx1_" + (i + 1)) != null)
                        {
                            ((TextBox)this.FindControl("tx1_" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("tx1_" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                            ((TextBox)this.FindControl("tx2_" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("tx2_" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                            ((TextBox)this.FindControl("tx3_" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("tx3_" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                        }
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[3].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaD")).Checked = true;
                        totalRespondidas++;
                        if (lista[i].ListPerguntaResposta[3].PossuiJustificativa && this.FindControl("tx1_" + (i + 1)) != null)
                        {
                            ((TextBox)this.FindControl("tx1_" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("tx1_" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                            ((TextBox)this.FindControl("tx2_" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("tx2_" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                            ((TextBox)this.FindControl("tx3_" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("tx3_" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                        }
                    }
                    if (this.FindControl("tx1_" + (i + 1)) != null)
                    {
                        ((TextBox)this.FindControl("tx1_" + (i + 1))).Text = lista[i].QuestionarioEmpresaResposta.Valor01;
                        ((TextBox)this.FindControl("tx2_" + (i + 1))).Text = lista[i].QuestionarioEmpresaResposta.Valor02;
                        ((TextBox)this.FindControl("tx3_" + (i + 1))).Text = lista[i].QuestionarioEmpresaResposta.Valor03;
                    }
                }
                else if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_MULTIPLA_ESCOLHA_4_OPCOES)
                {
                    if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[0].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaA")).Checked = true;
                        totalRespondidas++;
                        if (lista[i].ListPerguntaResposta[0].PossuiJustificativa)
                        {
                            ((TextBox)this.FindControl("justificativa" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("justificativa" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                        }
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[1].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaB")).Checked = true;
                        totalRespondidas++;
                        if (lista[i].ListPerguntaResposta[1].PossuiJustificativa)
                        {
                            ((TextBox)this.FindControl("justificativa" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("justificativa" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                        }
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[2].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaC")).Checked = true;
                        totalRespondidas++;
                        if (lista[i].ListPerguntaResposta[2].PossuiJustificativa)
                        {
                            ((TextBox)this.FindControl("justificativa" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("justificativa" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                        }
                    }
                    else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[3].IdPerguntaResposta)
                    {
                        ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaD")).Checked = true;
                        totalRespondidas++;
                        if (lista[i].ListPerguntaResposta[3].PossuiJustificativa)
                        {
                            ((TextBox)this.FindControl("justificativa" + (i + 1))).Attributes.Remove("disabled");
                            ((TextBox)this.FindControl("justificativa" + (i + 1))).Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                        }
                    }
                    if (this.FindControl("justificativa" + (i + 1)) != null)
                    {
                        ((TextBox)this.FindControl("justificativa" + (i + 1))).Text = lista[i].QuestionarioEmpresaResposta.Justificativa;
                    }
                }

                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaA")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaA")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaB")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaB")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[1].IdPerguntaResposta.ToString());
                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaC")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaC")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[2].IdPerguntaResposta.ToString());
                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaD")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaD")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[3].IdPerguntaResposta.ToString());
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
            int i = 1;
            while (i < 38)
            {
                EntQuestionarioEmpresaResposta temp = new EntQuestionarioEmpresaResposta();
                temp.QuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                temp.UsuarioDigitador.IdUsuario = IdUsuarioLogado;
                if (this.FindControl("justificativa" + (i)) != null)
                {
                    temp.Justificativa = ((TextBox)this.FindControl("justificativa" + (i))).Text;
                }
                if (((RadioButton)this.FindControl("pergunta" + i + "respostaA")).Checked)
                {
                    temp.Pergunta.IdPergunta = int.Parse(((RadioButton)this.FindControl("pergunta" + i + "respostaA")).Attributes["perguntaId"]);
                    temp.Resposta.IdPerguntaResposta = int.Parse(((RadioButton)this.FindControl("pergunta" + i + "respostaA")).Attributes["respostaId"]);
                    listaResposta.Add(temp);
                }
                else if (((RadioButton)this.FindControl("pergunta" + i + "respostaB")).Checked)
                {
                    temp.Pergunta.IdPergunta = int.Parse(((RadioButton)this.FindControl("pergunta" + i + "respostaB")).Attributes["perguntaId"]);
                    temp.Resposta.IdPerguntaResposta = int.Parse(((RadioButton)this.FindControl("pergunta" + i + "respostaB")).Attributes["respostaId"]);
                    listaResposta.Add(temp);
                }
                else if (((RadioButton)this.FindControl("pergunta" + i + "respostaC")).Checked)
                {
                    temp.Pergunta.IdPergunta = int.Parse(((RadioButton)this.FindControl("pergunta" + i + "respostaC")).Attributes["perguntaId"]);
                    temp.Resposta.IdPerguntaResposta = int.Parse(((RadioButton)this.FindControl("pergunta" + i + "respostaC")).Attributes["respostaId"]);
                    listaResposta.Add(temp);
                }
                else if (((RadioButton)this.FindControl("pergunta" + i + "respostaD")).Checked)
                {
                    temp.Pergunta.IdPergunta = int.Parse(((RadioButton)this.FindControl("pergunta" + i + "respostaD")).Attributes["perguntaId"]);
                    temp.Resposta.IdPerguntaResposta = int.Parse(((RadioButton)this.FindControl("pergunta" + i + "respostaD")).Attributes["respostaId"]);
                    listaResposta.Add(temp);
                }
                if (i > 31 && i < 37)
                {
                    temp.Valor01 = ((TextBox)this.FindControl("tx1_" + (i))).Text;
                    temp.Valor02 = ((TextBox)this.FindControl("tx2_" + (i))).Text;
                    temp.Valor03 = ((TextBox)this.FindControl("tx3_" + (i))).Text;
                }
                i++;
            }

            foreach (EntQuestionarioEmpresaResposta qer in listaResposta)
            {
                new BllQuestionarioEmpresaResposta().InserirAtualizar(qer);
            }
        }
    }
}