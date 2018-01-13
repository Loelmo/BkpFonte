using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de relatorio que representa um Ranking Finalista
    /// </summary>
    [Serializable()]
    public class RelRankingFinalista : RelRanking
    {

        public Boolean Vencedor { get; set; }

    }
}
