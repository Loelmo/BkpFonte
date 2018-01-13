using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Questionario
    /// </summary>
    [Serializable()]
    public class EntQuestionario
    {
        public const int QUESTIONARIO_GESTAO_2006 = 2;
        public const int QUESTIONARIO_GESTAO_2007 = 3;
        public const int QUESTIONARIO_GESTAO_2009 = 5;
        public const int QUESTIONARIO_GESTAO_2011 = 6;
        public const int QUESTIONARIO_EMPREENDEDORISMO_2009 = 7;
        public const int QUESTIONARIO_EMPREENDEDORISMO_2011 = 14;
        public const int QUESTIONARIO_RESPONSABILIDADE_2009 = 8;
        public const int QUESTIONARIO_INOVACAO_2011 = 9;
        public const int QUESTIONARIO_RESPONSABILIDADE_2011 = 13;

        public Int32 IdQuestionario { get; set; }

        public String Questionario { get; set; }

        public String Descricao { get; set; }

        public String Protocolo { get; set; }

        public DateTime DtQuestionario { get; set; }

        public Boolean Ativo { get; set; }

        public Boolean Obrigatorio { get; set; }

        public Boolean Publicado { get; set; }

        public Boolean PreenchimentoRapido { get; set; }

        public Boolean EmpresaParticipa { get; set; }

        public Int32 Ciclo { get; set; }

        public Int32 PorcentagemPreenchida { get; set; }

        private List<EntPergunta> _ListPergunta;
        public List<EntPergunta> ListPergunta
        {
            get
            {
                if (_ListPergunta == null)
                {
                    _ListPergunta = new List<EntPergunta>();
                }
                return _ListPergunta;
            }

            set { _ListPergunta = value; }
        }

    }
}
