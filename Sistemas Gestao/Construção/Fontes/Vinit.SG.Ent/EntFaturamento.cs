using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Faturamento
    /// </summary>
    [Serializable()]
    public class EntFaturamento
    {
        public Int32 IdFaturamento { get; set; }

        public String Faturamento { get; set; }

        public String MensuracaoFaturamento { get; set; }

        private EntFaturamentoTipo _FaturamentoTipo;
        public EntFaturamentoTipo FaturamentoTipo
        {
            get
            {
                if (_FaturamentoTipo == null)
                {
                    _FaturamentoTipo = new EntFaturamentoTipo();
                }
                return _FaturamentoTipo;
            }

            set { _FaturamentoTipo = value; }
        }
    }
}
