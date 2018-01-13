using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vinit.SG.Ent;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Vinit.SG.Common;
using Vinit.SG.BLL;
using PEG.Pagina_Base;

namespace Sistema_de_Gestão_de_Treinamento.User_Control
{
    public class UCQuestionarioBase : UCBase
    {
        public int IdQuestionarioEmpresa { get; set; }

        public int IdEmpresaCadastro { get; set; }

        public int IdQuestionario { get; set; }

        public int IdTurma { get; set; }

        public EntPergunta Pergunta { get; set; }

        protected Boolean isUltimaPergunta(Int32 IdQuestionario, Int32 IdPergunta)
        {
            EntPergunta Pergunta = new BllPergunta().ObterPerguntaProximaPorQuestionarioPergunta(IdQuestionario, IdPergunta);
            if (Pergunta != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected Boolean habilitaEnvioQuestionario()
        {
            List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterAbertosPorIdTurmaIdEmpresa(this.objTurma.IdTurma, this.EmpresaLogada.IdEmpresaCadastro);
            Boolean preenchimentoFinalizado = true;
            foreach (EntQuestionario eq in listaQuestionarios)
            {
                if (eq.EmpresaParticipa)
                {
                    if (eq.PorcentagemPreenchida < 100)
                    {
                        preenchimentoFinalizado = false;
                    }
                }
            }
            return preenchimentoFinalizado;
        }

        protected void Redireciona()
        {
            if (Pergunta != null)
            {
                Response.Redirect("~/Paginas/Empresa/RespondePerguntaQuestionario.aspx?IdQuestionario=" + this.IdQuestionario + "&IdQuestionarioEmpresa=" + this.IdQuestionarioEmpresa + "&IdEmpresaCadastro=" + IdEmpresaCadastro + "&IdTurma=" + IdTurma + "&IdPergunta=" + Pergunta.IdPergunta);
            }
            else
            {
                Response.Redirect("~/Paginas/Empresa/SelecionaQuestionario.aspx");
            }
        }

    }
}