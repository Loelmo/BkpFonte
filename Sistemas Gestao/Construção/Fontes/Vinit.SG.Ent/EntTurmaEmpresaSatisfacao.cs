using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Ent
{
    /// <summary>
    /// Classe de entidade que representa um Categoria
    /// </summary>
    [Serializable()]
    public class EntTurmaEmpresaSatisfacao
    {
        public String Resposta1 { get; set; }

        public String Resposta2 { get; set; }

        public String Resposta3 { get; set; }

        public String Resposta4 { get; set; }

        public String Resposta5 { get; set; }

        public String Resposta6 { get; set; }

        public String Resposta7 { get; set; }

        public String Resposta8 { get; set; }

        public String Resposta9 { get; set; }

        public String Resposta10 { get; set; }

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

    }
}
