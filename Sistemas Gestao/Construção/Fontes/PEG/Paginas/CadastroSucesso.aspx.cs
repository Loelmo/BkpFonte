using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using PEG.Pagina_Base;

namespace PEG.Paginas
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