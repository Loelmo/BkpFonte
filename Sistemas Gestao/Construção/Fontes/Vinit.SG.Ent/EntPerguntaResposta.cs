using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um PerguntaResposta
    /// </summary>
    [Serializable()]
    public class EntPerguntaResposta
    {
        public Int32 IdPerguntaResposta { get; set; }

        public String PerguntaResposta { get; set; }

        public Int32 Ordem { get; set; }

        public Decimal Ponto { get; set; }

        public String RespostaAutomatica { get; set; }

        public Boolean PossuiJustificativa { get; set; }

        public String Valor1 { get; set; }
        
        public String Valor2 { get; set; }
        
        public String Valor3 { get; set; }
        
        public String Valor4 { get; set; }
        
        public String Valor5 { get; set; }
        
        public String Valor6 { get; set; }
        
        public String Valor7 { get; set; }
        
        public String Valor8 { get; set; }
        
        public String Valor9 { get; set; }
        
        public String Valor10 { get; set; }

        private EntPergunta _Pergunta;
        public EntPergunta Pergunta
        {
            get
            {
                if (_Pergunta == null)
                {
                    _Pergunta = new EntPergunta();
                }
                return _Pergunta;
            }

            set { _Pergunta = value; }
        }

    }
}
