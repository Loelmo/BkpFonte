using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PEG.Pagina_Base;
using Vinit.SG.Ent;
using Vinit.SG.Common;

namespace PEG.Paginas
{
    public partial class Principal : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LblTitulo1.Text = "PEG";
            this.LblDescricao1.Text = "É uma solução integrada, baseada em dez pilares, tais como o diagnóstico da performance e da competitividade da empresa, o desenvolvimento de um plano empresarial, a definição de objetivos estratégicos, a implantação de um modelo de gestão baseado em indicadores e metas e o acompanhamento sistemático da execução e dos resultados.";
            this.LblDescricao2.Text = "Fundamentado nesses pilares, a solução tem como proposta levar conhecimento sobre gestão empresarial para os participantes por meio de palestras, capacitações em áreas chave da gestão empresarial, consultorias individuais e encontros empresariais que estimulam o intercâmbio de experiências e conhecimentos entre empresários.";

            if (!IsPostBack)
            {
                // Se o IdUsuarioLogado for maior que zero quer dizer que é um usuário administrativo
                if (IdUsuarioLogado > 0)
                {
                    this.UCStatus1.Visible = false;
                }
                // Usuário Empresa
                else
                {
                    this.UCStatus1.Visible = true;
                }
            }
        }
    }
}