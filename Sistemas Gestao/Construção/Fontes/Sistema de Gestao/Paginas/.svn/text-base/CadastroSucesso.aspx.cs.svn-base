using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Sistema_de_Gestao.Pagina_Base;

namespace Sistema_de_Gestao.Paginas
{
    public partial class CadastroSucesso : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulaInformacao();
            }
        }

        private void PopulaInformacao()
        {
            EntTurma turma = new BllTurma().ObterPorId(this.objTurma.IdTurma);
            this.UCCadastroSucesso1.TxTitulo = turma.Turma;
        }

    }
}