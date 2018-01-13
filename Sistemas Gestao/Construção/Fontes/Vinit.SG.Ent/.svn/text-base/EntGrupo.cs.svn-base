using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Grupo
    /// </summary>
    [Serializable()]
    public class EntGrupo
    {
        public Int32 IdGrupo { get; set; }

        public String Grupo { get; set; }

        public Boolean Ativo { get; set; }

        public String Descricao { get; set; }

        private EntTurma _Turma;
        public EntTurma Turma
        {
            get
            {
                if (_Turma == null)
                {
                    _Turma = new EntTurma();
                }
                return _Turma;
            }

            set { _Turma = value; }
        }

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

        private EntSetor _Setor;
        public EntSetor Setor
        {
            get
            {
                if (_Setor == null)
                {
                    _Setor = new EntSetor();
                }
                return _Setor;
            }

            set { _Setor = value; }
        }
    }
}
