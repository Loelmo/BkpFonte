using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Pergunta
    /// </summary>
    [Serializable()]
    public class EntPergunta
    {
        public Int32 IdPergunta { get; set; }

        public String Pergunta { get; set; }

        public Int32 Ordem { get; set; }

        public Boolean Ativo { get; set; }

        public Boolean PerguntaInterna { get; set; }

        public String Glossario { get; set; }

        public String SaibaMais { get; set; }

        public String NumeroQuestao { get; set; }

        private EntCriterio _Criterio;
        public EntCriterio Criterio
        {
            get
            {
                if (_Criterio == null)
                {
                    _Criterio = new EntCriterio();
                }
                return _Criterio;
            }

            set { _Criterio = value; }
        }

        private EntPerguntaTipo _PerguntaTipo;
        public EntPerguntaTipo PerguntaTipo
        {
            get
            {
                if (_PerguntaTipo == null)
                {
                    _PerguntaTipo = new EntPerguntaTipo();
                }
                return _PerguntaTipo;
            }

            set { _PerguntaTipo = value; }
        }

        private EntQuestionarioEmpresaResposta _QuestionarioEmpresaResposta;
        public EntQuestionarioEmpresaResposta QuestionarioEmpresaResposta
        {
            get
            {
                if (_QuestionarioEmpresaResposta == null)
                {
                    _QuestionarioEmpresaResposta = new EntQuestionarioEmpresaResposta();
                }
                return _QuestionarioEmpresaResposta;
            }

            set { _QuestionarioEmpresaResposta = value; }
        }

        private List<EntPerguntaResposta> _ListPerguntaResposta;
        public List<EntPerguntaResposta> ListPerguntaResposta
        {
            get
            {
                if (_ListPerguntaResposta == null)
                {
                    _ListPerguntaResposta = new List<EntPerguntaResposta>();
                }
                return _ListPerguntaResposta;
            }

            set { _ListPerguntaResposta = value; }
        }

    }
}
