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
    public partial class UCAdministrativoEmpreendedorismo : UCQuestionarioBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.HdnIdQuestionario.Value = IdQuestionario.ToString();
                this.HdnIdQuestionarioEmpresa.Value = IdQuestionarioEmpresa.ToString();
                this.HdnIdEmpresaCadastro.Value = IdEmpresaCadastro.ToString();
                this.HdnIdTurma.Value = IdTurma.ToString();

                if (UsuarioLogado.IdUsuario > 0)
                {
                    lblEmpresa.Visible = false;
                }
                else
                {
                    lblEmpresa.Visible = true;
                }

                MontarQuestionario();
                this.pergunta1respostaA.Focus();
            }
        }

        public void MontarQuestionario()
        {
            List<EntPergunta> lista = new BllPergunta().ObterPerguntasPorQuestionarioEmpresa(IdQuestionario, IdQuestionarioEmpresa, false);
            int totalRespondidas = 0;

            for (int i = 0; i < lista.Count; i++)
            {
                ((Label)this.FindControl("lblPergunta" + (i + 1))).Text = (i + 1) + ". " + lista[i].Pergunta;
                if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[0].IdPerguntaResposta)
                {
                    ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaA")).Checked = true;
                    totalRespondidas++;
                }
                else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[1].IdPerguntaResposta)
                {
                    ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaB")).Checked = true;
                    totalRespondidas++;
                }
                else if (lista[i].QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == lista[i].ListPerguntaResposta[2].IdPerguntaResposta)
                {
                    ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaC")).Checked = true;
                    totalRespondidas++;
                }
                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaA")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaA")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaB")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaB")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[1].IdPerguntaResposta.ToString());
                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaC")).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                ((RadioButton)this.FindControl("pergunta" + (i + 1) + "respostaC")).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[2].IdPerguntaResposta.ToString());
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
            int i = 1;
            while (i < 31)
            {
                EntQuestionarioEmpresaResposta temp = new EntQuestionarioEmpresaResposta();
                temp.QuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                temp.UsuarioDigitador.IdUsuario = IdUsuarioLogado;
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
                i++;
            }

            foreach (EntQuestionarioEmpresaResposta qer in listaResposta)
            {
                new BllQuestionarioEmpresaResposta().InserirAtualizar(qer);
            }
        }
    }
}