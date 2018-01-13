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

namespace Sistema_de_Gestao.User_Controls.Avaliacao
{
    public partial class UCPerguntaEspecialResponsabilidadeSocial1 : UCQuestionarioBase
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

            List<EntPergunta> lista = new BllPergunta().ObterPerguntasPorQuestionarioEmpresa(IdQuestionario, IdQuestionarioEmpresa, false);
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

        public void Gravar(String pontoForte, String oportunidadeMelhoria)
        {
            IdQuestionario = int.Parse(this.HdnIdQuestionario.Value);
            IdQuestionarioEmpresa = int.Parse(this.HdnIdQuestionarioEmpresa.Value);
            IdEmpresaCadastro = int.Parse(this.HdnIdEmpresaCadastro.Value);
            IdTurma = int.Parse(this.HdnIdTurma.Value);
            Pergunta = new EntPergunta();
            Pergunta.IdPergunta = int.Parse(pergunta1respostaSim.Attributes["perguntaId"]);

            List<EntQuestionarioEmpresaResposta> listaResposta = new List<EntQuestionarioEmpresaResposta>();

            //pergunta 1
            EntQuestionarioEmpresaResposta temp = new EntQuestionarioEmpresaResposta();
            temp.Pergunta.IdPergunta = int.Parse(pergunta1respostaSim.Attributes["perguntaId"]);
            temp.QuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
            temp.Resposta.IdPerguntaResposta = int.Parse(pergunta1respostaSim.Attributes["respostaId"]);
            temp.PontoForte = pontoForte;
            temp.OportunidadeMelhoria = oportunidadeMelhoria;
            if (pergunta1respostaSim.Checked)
            {
                temp.RespostaBool = true;
            }
            else if (pergunta1respostaNao.Checked)
            {
                temp.RespostaBool = false;
            }
            temp.UsuarioAvaliador.IdUsuario = IdUsuarioLogado;
            listaResposta.Add(temp);

            //tabela 1
            for (int i = 1; i < 11; i++)
            {
                temp = new EntQuestionarioEmpresaResposta();

                temp.QuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
                temp.PontoForte = pontoForte;
                temp.OportunidadeMelhoria = oportunidadeMelhoria;
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
                temp.UsuarioAvaliador.IdUsuario = IdUsuarioLogado;
                listaResposta.Add(temp);
            }

            foreach (EntQuestionarioEmpresaResposta qer in listaResposta)
            {
                new BllQuestionarioEmpresaResposta().InserirAtualizar(qer);
            }
        }
    }
}