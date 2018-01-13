using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Resumo da Etapa
    /// </summary>
    [Serializable()]
    public class EntEtapaResumo
    {
        public Int32 IdEtapaResumo { get; set; }

        public String Acao { get; set; }

        public DateTime DataCadastro { get; set; }

        private EntEtapa _Etapa;
        public EntEtapa Etapa
        {
            get
            {
                if (_Etapa == null)
                {
                    _Etapa = new EntEtapa();
                }
                return _Etapa;
            }

            set { _Etapa = value; }
        }

        private EntAdmUsuario _AdmUsuario;
        public EntAdmUsuario AdmUsuario
        {
            get
            {
                if (_AdmUsuario == null)
                {
                    _AdmUsuario = new EntAdmUsuario();
                }
                return _AdmUsuario;
            }

            set { _AdmUsuario = value; }
        }
    }
}
