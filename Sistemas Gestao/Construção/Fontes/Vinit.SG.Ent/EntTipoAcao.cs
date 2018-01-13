using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Tipo de Acao
    /// </summary>
    [Serializable()]
    public class EntTipoAcao
    {
        public const int TIPO_ACAO_CADASTRO_EMPRESA = 1;
        public const int TIPO_ACAO_ALTERACAO_EMPRESA = 2;
        public const int TIPO_ACAO_ENVIO_QUESTIONARIO_EMPRESA = 3;

        public Int32 IdTipoAcao
        {
            get;
            set;
        }

        public String TipoAcao
        {
            get;
            set;
        }
    }
}
