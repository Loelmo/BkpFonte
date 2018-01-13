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
    public partial class UCPerguntaEspecialGestao32 : UCQuestionarioBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        public void Editar(Int32 IdQuestionario, Int32 IdQuestionarioEmpresa, Int32 IdEmpresaCadastro, Int32 IdTurma, EntPergunta Pergunta)
        {
            this.IdQuestionario = IdQuestionario;
            this.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
            this.IdEmpresaCadastro = IdEmpresaCadastro;
            this.IdTurma = IdTurma;
            this.Pergunta = Pergunta;
            this.HdnIdQuestionario.Value = IdQuestionario.ToString();
            this.HdnIdQuestionarioEmpresa.Value = IdQuestionarioEmpresa.ToString();
            this.HdnIdEmpresaCadastro.Value = IdEmpresaCadastro.ToString();
            this.HdnIdTurma.Value = IdTurma.ToString();
            this.HdnIdPergunta.Value = Pergunta.IdPergunta.ToString();

            this.lblTabela.Text = this.Pergunta.Pergunta;
            if (this.Pergunta.QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == this.Pergunta.ListPerguntaResposta[0].IdPerguntaResposta)
            {
                this.radioA.Checked = true;
            }
            else if (this.Pergunta.QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == this.Pergunta.ListPerguntaResposta[1].IdPerguntaResposta)
            {
                this.radioB.Checked = true;
            }
            else if (this.Pergunta.QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == this.Pergunta.ListPerguntaResposta[2].IdPerguntaResposta)
            {
                this.radioC.Checked = true;
            }
            else if (this.Pergunta.QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == this.Pergunta.ListPerguntaResposta[3].IdPerguntaResposta)
            {
                this.radioD.Checked = true;
            }
            this.lblRespostaA.Text = this.Pergunta.ListPerguntaResposta[0].PerguntaResposta;
            this.lblRespostaB.Text = this.Pergunta.ListPerguntaResposta[1].PerguntaResposta;
            this.lblRespostaC.Text = this.Pergunta.ListPerguntaResposta[2].PerguntaResposta;
            this.lblRespostaD.Text = this.Pergunta.ListPerguntaResposta[3].PerguntaResposta;

            radioA.Attributes.Add("onClick", "DesabilitaCampos('" + ((TextBox)this.FindControl("tx1_31")).ClientID + "','" + ((TextBox)this.FindControl("tx2_31")).ClientID + "','" + ((TextBox)this.FindControl("tx3_31")).ClientID + "')");
            radioB.Attributes.Add("onClick", "HabilitaCampos('" + ((TextBox)this.FindControl("tx1_31")).ClientID + "','" + ((TextBox)this.FindControl("tx2_31")).ClientID + "','" + ((TextBox)this.FindControl("tx3_31")).ClientID + "')");
            radioC.Attributes.Add("onClick", "HabilitaCampos('" + ((TextBox)this.FindControl("tx1_31")).ClientID + "','" + ((TextBox)this.FindControl("tx2_31")).ClientID + "','" + ((TextBox)this.FindControl("tx3_31")).ClientID + "')");
            radioD.Attributes.Add("onClick", "HabilitaCampos('" + ((TextBox)this.FindControl("tx1_31")).ClientID + "','" + ((TextBox)this.FindControl("tx2_31")).ClientID + "','" + ((TextBox)this.FindControl("tx3_31")).ClientID + "')");

            if (this.Pergunta.QuestionarioEmpresaResposta != null && this.Pergunta.QuestionarioEmpresaResposta.QuestionarioEmpresa != null)
            {
                this.tx1_31.Text = this.Pergunta.QuestionarioEmpresaResposta.Valor01;
                this.tx2_31.Text = this.Pergunta.QuestionarioEmpresaResposta.Valor02;
                this.tx3_31.Text = this.Pergunta.QuestionarioEmpresaResposta.Valor03;
                if (this.Pergunta.QuestionarioEmpresaResposta.Resposta.PossuiJustificativa)
                {
                    this.tx1_31.Enabled = true;
                    this.tx1_31.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                    this.tx2_31.Enabled = true;
                    this.tx2_31.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                    this.tx3_31.Enabled = true;
                    this.tx3_31.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                }
            }
        }

        public void Gravar(String pontoForte, String oportunidadeMelhoria)
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
            ent.PontoForte = pontoForte;
            ent.OportunidadeMelhoria = oportunidadeMelhoria;
            ent.Valor01 = this.tx1_31.Text;
            ent.Valor02 = this.tx2_31.Text;
            ent.Valor03 = this.tx3_31.Text;
            ent.Pergunta.IdPergunta = this.Pergunta.IdPergunta;
            ent.QuestionarioEmpresa.IdQuestionarioEmpresa = this.IdQuestionarioEmpresa;
            if (this.radioA.Checked)
            {
                ent.Resposta.IdPerguntaResposta = this.Pergunta.ListPerguntaResposta[0].IdPerguntaResposta;
            }
            else if (this.radioB.Checked)
            {
                ent.Resposta.IdPerguntaResposta = this.Pergunta.ListPerguntaResposta[1].IdPerguntaResposta;
            }
            else if (this.radioC.Checked)
            {
                ent.Resposta.IdPerguntaResposta = this.Pergunta.ListPerguntaResposta[2].IdPerguntaResposta;
            }
            else if (this.radioD.Checked)
            {
                ent.Resposta.IdPerguntaResposta = this.Pergunta.ListPerguntaResposta[3].IdPerguntaResposta;
            }

            ent.UsuarioAvaliador.IdUsuario = IdUsuarioLogado;
            if (ent.Resposta.IdPerguntaResposta > 0)
            {
                new BllQuestionarioEmpresaResposta().InserirAtualizar(ent);
            }
        }
    }
}