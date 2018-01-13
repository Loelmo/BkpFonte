using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um TipoEstado
    /// </summary>
    [Serializable()]
    public class EntAtendimentoTipo
    {
        public const int ATENDIMENTO_TIPO_GESTAO = 1;
        public const int ATENDIMENTO_TIPO_TECNICO = 2;

        public Int32 IdAtendimentoTipo { get; set; }

        public String AtendimentoTipo { get; set; }
    }
}
