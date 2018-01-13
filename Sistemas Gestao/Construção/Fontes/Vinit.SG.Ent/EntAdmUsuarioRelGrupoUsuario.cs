using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa uma UsuarioRelGrupoUsuario
    /// </summary>
    [Serializable()]
    public class EntAdmUsuarioRelGrupoUsuario
    {
        public Int32 IdUsuarioGrupoUsuario { get; set; }

        private EntAdmGrupoRelUsuario _AdmGrupoRelUsuario;
        public EntAdmGrupoRelUsuario AdmGrupoRelUsuario
        {
            get
            {
                if (_AdmGrupoRelUsuario == null)
                {
                    _AdmGrupoRelUsuario = new EntAdmGrupoRelUsuario();
                }
                return _AdmGrupoRelUsuario;
            }

            set { _AdmGrupoRelUsuario = value; }
        }

        private EntAdmUsuario _AdmUsuario;
        public EntAdmUsuario AdmUsuario
        {
            get
            {
                if (_AdmUsuario == null)
                {
                    _AdmUsuario = new EntAdmUsuario();
                }
                return _AdmUsuario;
            }

            set { _AdmUsuario = value; }
        }
    }
}
