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
    public partial class UCPerguntaMultiplaEscolha4Opcoes : UCQuestionarioBase
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
            ent.Pergunta.IdPergunta = this.Pergunta.IdPergunta;
            ent.QuestionarioEmpresa.IdQuestionarioEmpresa = this.IdQuestionarioEmpresa;
            ent.PontoForte = pontoForte;
            ent.OportunidadeMelhoria = oportunidadeMelhoria;
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