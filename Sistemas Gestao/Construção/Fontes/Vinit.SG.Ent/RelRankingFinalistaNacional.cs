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
    public class RelRankingFinalistaNacional : RelRankingFinalista
    {

        public Int32 IdQuestionario { get; set; }

    }
}
