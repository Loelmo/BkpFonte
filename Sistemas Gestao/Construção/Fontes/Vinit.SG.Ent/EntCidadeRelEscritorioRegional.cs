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
    public class EntCidadeRelEscritorioRegional
    {
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
    }
}
