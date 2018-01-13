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
    public partial class UCPerguntaEspecialGestao31 : UCQuestionarioBase
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
            for (int i = 30; i < lista.Count; i++)
            {
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_31_QUESTIONARIO_GESTAO_2009_2010)
                {
                    ((RadioButton)this.FindControl("rdSim" + (i + 1))).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((RadioButton)this.FindControl("rdSim" + (i + 1))).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                    if (lista[i].QuestionarioEmpresaResposta.RespostaBool)
                    {
                        ((RadioButton)this.FindControl("rdSim" + (i + 1))).Checked = true;
                        ((TextBox)this.FindControl("tx1_" + (i + 1))).Enabled = true;
                        ((TextBox)this.FindControl("tx2_" + (i + 1))).Enabled = true;
                        ((TextBox)this.FindControl("tx3_" + (i + 1))).Enabled = true;
                    }
                    else
                    {
                        ((RadioButton)this.FindControl("rdNao" + (i + 1))).Checked = true;
                    }
                    ((TextBox)this.FindControl("tx1_" + (i + 1))).Text = lista[i].QuestionarioEmpresaResposta.Valor01;
                    ((TextBox)this.FindControl("tx2_" + (i + 1))).Text = lista[i].QuestionarioEmpresaResposta.Valor02;
                    ((TextBox)this.FindControl("tx3_" + (i + 1))).Text = lista[i].QuestionarioEmpresaResposta.Valor03;

                    ((RadioButton)this.FindControl("rdSim" + (i + 1))).Attributes.Add("onClick", "HabilitaCampos('" + ((TextBox)this.FindControl("tx1_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx2_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx3_" + (i + 1))).ClientID + "')");
                    ((RadioButton)this.FindControl("rdNao" + (i + 1))).Attributes.Add("onClick", "DesabilitaCampos('" + ((TextBox)this.FindControl("tx1_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx2_" + (i + 1))).ClientID + "','" + ((TextBox)this.FindControl("tx3_" + (i + 1))).ClientID + "')");
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
            Pergunta.IdPergunta = int.Parse(rdSim31.Attributes["perguntaId"]);

            List<EntQuestionarioEmpresaResposta> listaResposta = new List<EntQuestionarioEmpresaResposta>();
            int i = 31;
            while (i < 39)
            {
                EntQuestionarioEmpresaResposta temp = new EntQuestionarioEmpresaResposta();
                temp.QuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                temp.UsuarioDigitador.IdUsuario = IdUsuarioLogado;
                temp.Pergunta.IdPergunta = int.Parse(((RadioButton)this.FindControl("rdSim" + i)).Attributes["perguntaId"]);
                temp.Resposta.IdPerguntaResposta = int.Parse(((RadioButton)this.FindControl("rdSim" + i)).Attributes["respostaId"]);

                if (((RadioButton)this.FindControl("rdSim" + (i))).Checked)
                {
                    temp.RespostaBool = true;
                }
                else
                {
                    temp.RespostaBool = false;
                }
                temp.Valor01 = ((TextBox)this.FindControl("tx1_" + (i))).Text;
                temp.Valor02 = ((TextBox)this.FindControl("tx2_" + (i))).Text;
                temp.Valor03 = ((TextBox)this.FindControl("tx3_" + (i))).Text;
                i++;
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