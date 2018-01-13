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
    public partial class UCPerguntaEspecialResponsabilidadeSocial6 : UCQuestionarioBase
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
            MontarQuestionario(lista);
        }

        public void MontarQuestionario(List<EntPergunta> lista)
        {
            for (int i = 11; i < lista.Count; i++)
            {
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_6_QUESTIONARIO_RESPONSABILIDADE_SOCIAL_2009_2010)
                {
                    ((Label)this.FindControl("label" + (i + 46))).Text = lista[i].Pergunta;
                    ((TextBox)this.FindControl("TxtResposta" + (i + 46))).Attributes.Add("perguntaId", lista[i].IdPergunta.ToString());
                    ((TextBox)this.FindControl("TxtResposta" + (i + 46))).Attributes.Add("respostaId", lista[i].ListPerguntaResposta[0].IdPerguntaResposta.ToString());
                    ((TextBox)this.FindControl("TxtResposta" + (i + 46))).Text = lista[i].QuestionarioEmpresaResposta.RespostaTexto;
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
            Pergunta.IdPergunta = int.Parse(TxtResposta61.Attributes["perguntaId"]);

            List<EntQuestionarioEmpresaResposta> listaResposta = new List<EntQuestionarioEmpresaResposta>();

            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 61, pontoForte, oportunidadeMelhoria));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 62, pontoForte, oportunidadeMelhoria));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 63, pontoForte, oportunidadeMelhoria));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 64, pontoForte, oportunidadeMelhoria));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 65, pontoForte, oportunidadeMelhoria));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 66, pontoForte, oportunidadeMelhoria));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 67, pontoForte, oportunidadeMelhoria));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 68, pontoForte, oportunidadeMelhoria));
            listaResposta.Add(retornaResposta(IdQuestionarioEmpresa, 69, pontoForte, oportunidadeMelhoria));

            foreach (EntQuestionarioEmpresaResposta qer in listaResposta)
            {
                new BllQuestionarioEmpresaResposta().InserirAtualizar(qer);
            }
        }

        private EntQuestionarioEmpresaResposta retornaResposta(int IdQuestionarioEmpresa, int NumeroPergunta, String pontoForte, String oportunidadeMelhoria)
        {
            EntQuestionarioEmpresaResposta temp = new EntQuestionarioEmpresaResposta();
            temp.QuestionarioEmpresa.IdQuestionarioEmpresa = IdQuestionarioEmpresa;
            temp = retornaPergunta6(temp, NumeroPergunta);
            temp.UsuarioAvaliador.IdUsuario = IdUsuarioLogado;
            temp.PontoForte = pontoForte;
            temp.OportunidadeMelhoria = oportunidadeMelhoria;
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