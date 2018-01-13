using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    public class EntProgramaEmpresa
    {

        public Int32 IdProgramaEmpresa { get; set; }

        public String Senha { get; set; }

        public String NomeResponsavel { get; set; }

        public String EmailResponsavel { get; set; }

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

        private EntEmpresaCadastro _EmpresaCadastro;
        public EntEmpresaCadastro EmpresaCadastro
        {
            get
            {
                if (_EmpresaCadastro == null)
                {
                    _EmpresaCadastro = new EntEmpresaCadastro();
                }
                return _EmpresaCadastro;
            }

            set { _EmpresaCadastro = value; }
        }

    }
}
