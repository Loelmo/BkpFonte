using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um NoticiaGrupo
    /// </summary>
    [Serializable()]
    public class EntNoticiaGrupo
    {
        private EntNoticia _Noticia;
        public EntNoticia Noticia
        {
            get
            {
                if (_Noticia == null)
                {
                    _Noticia = new EntNoticia();
                }
                return _Noticia;
            }

            set { _Noticia = value; }
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
