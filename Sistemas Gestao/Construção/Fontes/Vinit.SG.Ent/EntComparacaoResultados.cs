using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    public class EntComparacaoResultados
    {
        private RelRankingClassificada _Fase1;
        public RelRankingClassificada Fase1
        {
            get
            {
                if (_Fase1 == null)
                {
                    _Fase1 = new RelRankingClassificada();
                }
                return _Fase1;
            }

            set { _Fase1 = value; }
        }


        private RelRankingClassificada _Fase4;
        public RelRankingClassificada Fase4
        {
            get
            {
                if (_Fase4 == null)
                {
                    _Fase4 = new RelRankingClassificada();
                }
                return _Fase4;
            }

            set { _Fase4 = value; }
        }
    }
}
