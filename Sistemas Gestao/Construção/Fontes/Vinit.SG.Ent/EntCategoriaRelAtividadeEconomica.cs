using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um CategoriaRelRamoAtividade
    /// </summary>
    [Serializable()]
    public class EntCategoriaRelAtividadeEconomica
    {
        private EntCategoria _Categoria;
        public EntCategoria Categoria
        {
            get
            {
                if (_Categoria == null)
                {
                    _Categoria = new EntCategoria();
                }
                return _Categoria;
            }

            set { _Categoria = value; }
        }

        private EntAtividadeEconomica _AtividadeEconomica;
        public EntAtividadeEconomica AtividadeEconomica
        {
            get
            {
                if (_AtividadeEconomica == null)
                {
                    _AtividadeEconomica = new EntAtividadeEconomica();
                }
                return _AtividadeEconomica;
            }

            set { _AtividadeEconomica = value; }
        }
    }
}
