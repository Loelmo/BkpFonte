using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Bairro
    /// </summary>
    [Serializable()]
    public class EntBairro
    {
        public Int32 IdBairro { get; set; }

        public Int32 CodSiacweb { get; set; }

        public String Bairro { get; set; }

        private EntCidade _Cidade;
        public EntCidade Cidade
        {
            get
            {
                if (_Cidade == null)
                {
                    _Cidade = new EntCidade();
                }
                return _Cidade;
            }

            set { _Cidade = value; }
        }
    }
}
