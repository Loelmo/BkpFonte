using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um EstadoRegião
    /// </summary>
    [Serializable()]
    public class EntEstadoRegiao
    {
        public Int32 IdEstadoRegiao { get; set; }

        public String EstadoRegiao { get; set; }

        public Boolean Ativo { get; set; }

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
