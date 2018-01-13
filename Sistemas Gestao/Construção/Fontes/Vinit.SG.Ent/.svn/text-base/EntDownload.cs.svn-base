using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Download
    /// </summary>
    [Serializable()]
    public class EntDownload
    {
        public Int32 IdDownload { get; set; }

        public String Path { get; set; }

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

        private EntPrograma _Programa;
        public EntPrograma Programa
        {
            get
            {
                if (_Programa == null)
                {
                    _Programa = new EntPrograma();
                }
                return _Programa;
            }

            set { _Programa = value; }
        }

    }
}
