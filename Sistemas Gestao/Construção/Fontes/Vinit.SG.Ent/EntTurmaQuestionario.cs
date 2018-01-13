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
    public class EntTurmaQuestionario
    {
        private EntTurma _Turma;
        public EntTurma Turma
        {
            get
            {
                if (_Turma == null)
                {
                    _Turma = new EntTurma();
                }
                return _Turma;
            }

            set { _Turma = value; }
        }

        private EntQuestionario _Questionario;
        public EntQuestionario Questionario
        {
            get
            {
                if (_Questionario == null)
                {
                    _Questionario = new EntQuestionario();
                }
                return _Questionario;
            }

            set { _Questionario = value; }
        }

        public Boolean Obrigatorio { get; set; }

        public Int32 Ordem { get; set; }
    }
}
