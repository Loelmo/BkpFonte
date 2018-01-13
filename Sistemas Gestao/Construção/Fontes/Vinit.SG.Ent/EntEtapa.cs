using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Etapa
    /// </summary>
    [Serializable()]
    public class EntEtapa
    {
        public Int32 IdEtapa { get; set; }

        public String Etapa { get; set; }

        public Boolean Ativo { get; set; }

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

        private EntTipoEtapa _TipoEtapa;
        public EntTipoEtapa TipoEtapa
        {
            get
            {
                if (_TipoEtapa == null)
                {
                    _TipoEtapa = new EntTipoEtapa();
                }
                return _TipoEtapa;
            }

            set { _TipoEtapa = value; }
        }
    }
}
