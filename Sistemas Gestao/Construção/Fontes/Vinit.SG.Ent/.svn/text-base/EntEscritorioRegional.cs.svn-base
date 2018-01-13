using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um EscritorioRegional
    /// </summary>
    [Serializable()]
    public class EntEscritorioRegional
    {
        public Int32 IdEscritorioRegional { get; set; }

        public String EscritorioRegional { get; set; }

        public Boolean Ativo { get; set; }

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

        private EntEstado _Estado;
        public EntEstado Estado
        {
            get
            {
                if (_Estado == null)
                {
                    _Estado = new EntEstado();
                }
                return _Estado;
            }

            set { _Estado = value; }
        }

        private List<EntCidade> _lstcidades;
        public List<EntCidade> LstCidades
        {
            get
            {
                if (_lstcidades == null)
                {
                    _lstcidades = new List<EntCidade>();

                }
                return _lstcidades;
            }
            set { _lstcidades = value; }

        }
    }
}
