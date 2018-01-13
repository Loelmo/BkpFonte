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
    public partial class UCPerguntaSimNao : UCQuestionarioBase
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

            this.respostaSim.Attributes.Add("onClick", "mostraAjuda('" + this.botaoJustificativa.ClientID + "')");
            this.respostaNao.Attributes.Add("onClick", "escondeAjuda('" + this.botaoJustificativa.ClientID + "')");

            this.TxtJustificativa.Text = this.Pergunta.QuestionarioEmpresaResposta.Justificativa;
            if (this.Pergunta.QuestionarioEmpresaResposta.RespostaBool)
            {
                this.respostaSim.Checked = true;
                this.botaoJustificativa.Style.Add("display", "block");
            }
            else if (!this.Pergunta.QuestionarioEmpresaResposta.RespostaBool)
            {
                this.respostaNao.Checked = true;
                this.botaoJustificativa.Style.Add("display", "none");
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
            ent.Justificativa = this.TxtJustificativa.Text;
            ent.Pergunta.IdPergunta = this.Pergunta.IdPergunta;
            ent.QuestionarioEmpresa.IdQuestionarioEmpresa = this.IdQuestionarioEmpresa;
            ent.PontoForte = pontoForte;
            ent.OportunidadeMelhoria = oportunidadeMelhoria;
            if (this.respostaSim.Checked)
            {
                ent.Resposta.IdPerguntaResposta = this.Pergunta.ListPerguntaResposta[0].IdPerguntaResposta;
                ent.RespostaBool = true;
            }
            else if (this.respostaNao.Checked)
            {
                ent.Resposta.IdPerguntaResposta = this.Pergunta.ListPerguntaResposta[1].IdPerguntaResposta;
                ent.RespostaBool = false;
            }
            ent.UsuarioAvaliador.IdUsuario = IdUsuarioLogado;
            if (ent.Resposta.IdPerguntaResposta > 0)
            {
                new BllQuestionarioEmpresaResposta().InserirAtualizar(ent);
            }
        }
    }
}