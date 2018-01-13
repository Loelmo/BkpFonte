using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa uma Relação de Funcionalidade com Grupo
    /// </summary>
    [Serializable()]
    public class EntAdmFuncionalidadeRelGrupo
    {

        private EntAdmFuncionalidade _AdmFuncionalidade;
        public EntAdmFuncionalidade AdmFuncionalidade
        {
            get
            {
                if (_AdmFuncionalidade == null)
                {
                    _AdmFuncionalidade = new EntAdmFuncionalidade();
                }
                return _AdmFuncionalidade;
            }

            set { _AdmFuncionalidade = value; }
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

        public Boolean Inserir
        {
            get;
            set;
        }

        public Boolean Atualizar
        {
            get;
            set;
        }

        public Boolean Excluir
        {
            get;
            set;
        }

        public Boolean Visualizar
        {
            get;
            set;
        }
    }
}
