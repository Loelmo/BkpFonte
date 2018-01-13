using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Cidade
    /// </summary>
    [Serializable()]
    public class EntCidade
    {
        public Int32 IdCidade { get; set; }

        public String Cidade { get; set; }

        public Boolean Ativo { get; set; }

        private EntEstadoRegiao _EstadoRegiao;
        public EntEstadoRegiao EstadoRegiao
        {
            get
            {
                if (_EstadoRegiao == null)
                {
                    _EstadoRegiao = new EntEstadoRegiao();
                }
                return _EstadoRegiao;
            }

            set { _EstadoRegiao = value; }
        }

        private EntEscritorioRegional _EscritorioRegional;
        public EntEscritorioRegional EscritorioRegional
        {
            get
            {
                if (_EscritorioRegional == null)
                {
                    _EscritorioRegional = new EntEscritorioRegional();
                }
                return _EscritorioRegional;
            }

            set { _EscritorioRegional = value; }
        }

        public Int32 CodSiacweb { get; set; }

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

    }
}
