using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.Common;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Filtro do Ranking
    /// </summary>
    [Serializable()]
    public class RelFiltroRanking
    {
        public String RazaoSocial { get; set; }
        public String NomeFantasia { get; set; }
        public String CPF_CNPJ { get; set; }
        public Int32 Regiao { get; set; }
        public Int32 Municipio { get; set; }
        public Int32 Status { get; set; }
        public String Protocolo { get; set; }
        public Int32 Categoria { get; set; }
        public Int32 Grupo { get; set; }
        public Int32 Estado { get; set; }
        public Int32 EstadoRegiao { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 Cidade { get; set; }
        public Int32 EscritorioRegional { get; set; }
        public Int32 FaixaFaturamento { get; set; }
        public Int32 TipoEmpresa { get; set; }
        public Int32 NumeroFuncionarios { get; set; }
        public Int32 Ano { get; set; }
        public Int32 EscolaridadeRepresentante { get; set; }
        public Int32 FaixaEtariaRepresentante { get; set; }
        public String SexoRepresentante { get; set; }
        public Boolean PremioEspecial { get; set; }
        public Boolean IsAvaliacao { get; set; }
        public Int32 Turma { get; set; }
        public Int32 Programa { get; set; }
        public EnumType.TipoEtapaMpe TipoEtapaMpe { get; set; }
        public EnumType.TipoEtapaFga TipoEtapaFga { get; set; }
        public EnumType.TipoEtapaPeg TipoEtapaPeg { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public EnumType.TipoRelatorio TipoRelatorio { get; set; }
        public EnumType.Questionario Questionario { get; set; }
    }
}
