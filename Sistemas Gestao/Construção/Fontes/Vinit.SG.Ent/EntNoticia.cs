using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Noticia
    /// </summary>
    [Serializable()]
    public class EntNoticia
    {
        public Int32 IdNoticia { get; set; }

        public String Titulo { get; set; }

        public String Noticia { get; set; }

        public String UrlImagem { get; set; }

        public Boolean Ativo { get; set; }

        public Boolean UsuarioAdministrativo { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public DateTime DataVigenciaFim { get; set; }

        public DateTime DataCadastroFiltroInicial { get; set; }

        public DateTime DataCadastroFiltroFinal { get; set; }

        public Int32 IdGrupoFiltro { get; set; }

        private EntTurma _Turma;
        public EntTurma Turma
        {
            get
            {
                if (_Turma == null)
                {
                    _Turma = new EntTurma();
                }
                return _Turma;
            }

            set { _Turma = value; }
        }

        private EntEstado _Estado;
        public EntEstado Estado
        {
            get
            {
                if (_Estado == null)
                {
                    _Estado = new EntEstado();
                }
                return _Estado;
            }

            set { _Estado = value; }
        }

        private EntPrograma _Programa;
        public EntPrograma Programa
        {
            get
            {
                if (_Programa == null)
                {
                    _Programa = new EntPrograma();
                }
                return _Programa;
            }

            set { _Programa = value; }
        }

        private List<EntNoticiaGrupo> _ListNoticiaGrupo;
        public List<EntNoticiaGrupo> ListNoticiaGrupo
        {
            get
            {
                if (_ListNoticiaGrupo == null)
                {
                    _ListNoticiaGrupo = new List<EntNoticiaGrupo>();
                }
                return _ListNoticiaGrupo;
            }

            set { _ListNoticiaGrupo = value; }
        }

    }
}
