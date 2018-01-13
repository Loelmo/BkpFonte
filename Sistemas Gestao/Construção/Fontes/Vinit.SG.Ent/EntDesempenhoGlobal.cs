using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Filtro do Desempenho Global
    /// </summary>
    [Serializable()]
    public class EntDesempenhoGlobal
    {
        public String RazaoSocial { get; set; }
        public String NomeFantasia { get; set; }
        public String CPF_CNPJ { get; set; }
        public Int32 Regiao { get; set; }
        public Int32 Categoria { get; set; }
        public Int32 Grupo { get; set; }
        public Int32 Estado { get; set; }
        public Int32 EstadoRegiao { get; set; }
        public Int32 Cidade { get; set; }
        public Int32 EscritorioRegional { get; set; }
        public Int32 Status { get; set; }
        public Boolean PremioEspecial { get; set; }
        public Int32 Turma { get; set; }
        public String Criterio { get; set; }
        public String PontuacaoMaxima { get; set; }
        public Double PontuacaoObtida { get; set; }
    }
}
