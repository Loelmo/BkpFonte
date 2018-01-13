using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um ContatoFaixaEtaria
    /// </summary>
    [Serializable()]
    public class EntContatoFaixaEtaria
    {
        public const int FAIXA_ETARIA_MENOS_25 = 1;
        public const int FAIXA_ETARIA_25_A_29 = 2;
        public const int FAIXA_ETARIA_30_A_34 = 3;
        public const int FAIXA_ETARIA_35_A_39 = 4;
        public const int FAIXA_ETARIA_40_A_44 = 5;
        public const int FAIXA_ETARIA_45_A_49 = 6;
        public const int FAIXA_ETARIA_ACIMA_50 = 7;

        public Int32 IdContatoFaixaEtaria { get; set; }

        public String ContatoFaixaEtaria { get; set; }
    }
}
