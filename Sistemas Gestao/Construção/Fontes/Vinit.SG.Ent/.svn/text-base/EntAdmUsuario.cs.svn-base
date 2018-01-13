using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um EntUsuario
    /// </summary>
    [Serializable()]
    public class EntAdmUsuario
    {
        public Int32 IdUsuario { get; set; }

        public String Usuario { get; set; }
        
        public String Login {get; set;}

        public String Senha { get; set; }

        public Boolean Ativo { get; set; }

        public String CPF { get; set; }

        public String Telefone { get; set; }

        public String Email { get; set; }

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

        private List<EntFuncionalidade> _lstFuncionalidade;
        public List<EntFuncionalidade> lstFuncionalidade
        {
            get
            {
                if (_lstFuncionalidade == null)
                {
                    _lstFuncionalidade = new List<EntFuncionalidade>();
                }
                return _lstFuncionalidade;
            }

            set { _lstFuncionalidade = value; }
        }

        private List<EntEstadosPermitidos> _lstEstadoPermitidos;
        public List<EntEstadosPermitidos> lstEstadoPermitidos
        {
            get
            {
                if (_lstEstadoPermitidos == null)
                {
                    _lstEstadoPermitidos = new List<EntEstadosPermitidos>();
                }
                return _lstEstadoPermitidos;
            }

            set { _lstEstadoPermitidos = value; }
        }

        private List<EntTurmasPermitidas> _lstTurmasPermitidas;
        public List<EntTurmasPermitidas> lstTurmasPermitidas
        {
            get
            {
                if (_lstTurmasPermitidas == null)
                {
                    _lstTurmasPermitidas = new List<EntTurmasPermitidas>();
                }
                return _lstTurmasPermitidas;
            }

            set { _lstTurmasPermitidas = value; }
        }

        private List<EntEscritoriosRegionaisPermitidos> _lstEscritoriosRegionaisPermitidos;
        public List<EntEscritoriosRegionaisPermitidos> lstEscritoriosRegionaisPermitidos
        {
            get
            {
                if (_lstEscritoriosRegionaisPermitidos == null)
                {
                    _lstEscritoriosRegionaisPermitidos = new List<EntEscritoriosRegionaisPermitidos>();
                }
                return _lstEscritoriosRegionaisPermitidos;
            }

            set { _lstEscritoriosRegionaisPermitidos = value; }
        }
    }
}
