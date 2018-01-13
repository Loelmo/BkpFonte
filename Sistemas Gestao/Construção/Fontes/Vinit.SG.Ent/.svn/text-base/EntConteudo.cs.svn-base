using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Conteudo
    /// </summary>
    [Serializable()]
    public class EntConteudo
    {
        public Int32 IdConteudo { get; set; }

        public String Titulo { get; set; }

        public String Conteudo { get; set; }

        public DateTime Cadastro { get; set; }

        public DateTime Atualizacao { get; set; }

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
