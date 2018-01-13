using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um ArquivoGrupo
    /// </summary>
    [Serializable()]
    public class EntArquivoGrupo
    {
        private EntArquivo _Arquivo;
        public EntArquivo Arquivo
        {
            get
            {
                if (_Arquivo == null)
                {
                    _Arquivo = new EntArquivo();
                }
                return _Arquivo;
            }

            set { _Arquivo = value; }
        }

        private EntAdmGrupo _AdmGrupo;
        public EntAdmGrupo AdmGrupo
        {
            get
            {
                if (_AdmGrupo == null)
                {
                    _AdmGrupo = new EntAdmGrupo();
                }
                return _AdmGrupo;
            }

            set { _AdmGrupo = value; }
        }
    }
}
