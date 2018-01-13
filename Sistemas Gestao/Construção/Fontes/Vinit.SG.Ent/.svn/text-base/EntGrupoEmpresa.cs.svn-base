using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um GrupoEmpresa
    /// </summary>
    [Serializable()]
    public class EntGrupoEmpresa
    {
        public Int32 IdGrupoEmpresa { get; set; }

        public DateTime DtCadastro { get; set; }

        public Boolean Ativo { get; set; }

        private EntGrupo _Grupo;
        public EntGrupo Grupo
        {
            get
            {
                if (_Grupo == null)
                {
                    _Grupo = new EntGrupo();
                }
                return _Grupo;
            }

            set { _Grupo = value; }
        }

        private EntEmpresaCadastro _EmpresaCadastro;
        public EntEmpresaCadastro EmpresaCadastro
        {
            get
            {
                if (_EmpresaCadastro == null)
                {
                    _EmpresaCadastro = new EntEmpresaCadastro();
                }
                return _EmpresaCadastro;
            }

            set { _EmpresaCadastro = value; }
        }

        
        
    }
}
