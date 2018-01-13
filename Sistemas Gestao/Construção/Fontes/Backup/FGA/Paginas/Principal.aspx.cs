using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestao.Pagina_Base;
using Vinit.SG.Ent;
using Vinit.SG.Common;

namespace Sistema_de_Gestao.Paginas
{
    public partial class Principal : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LblTitulo1.Text = "FERRAMENTAS DE GESTÃO AVANÇADA";
            this.LblDescricao1.Text = "É uma solução integrada, baseada em dez pilares, tais como o diagnóstico da performance e da competitividade da empresa, o desenvolvimento de um plano empresarial, a definição de objetivos estratégicos, a implantação de um modelo de gestão baseado em indicadores e metas e o acompanhamento sistemático da execução e dos resultados.";
            this.LblDescricao2.Text = "Fundamentado nesses pilares, a solução tem como proposta levar conhecimento sobre gestão empresarial para os participantes por meio de workshops, capacitações em áreas chave da gestão empresarial, consultorias individuais e encontros empresariais que estimulam o intercâmbio de experiências e conhecimentos entre empresários.";

            if (!IsPostBack)
            {
                if (Request["Aviso"] != null)
                {
                    switch (StringUtils.ToInt(Request["Aviso"]))
                    {
                        case 1:
                            MessageBox(this, "Você poderá continuar o preenchimento do autodiagnóstico, mas não passará pelo processo de seleção para o FGA, pois não atende aos requisitos mínimos: a empresa ter 2 ou mais anos de vida e acima de 9 colaboradores.");
                            break;
                        case 2:
                            MessageBox(this, "Você poderá continuar o preenchimento do autodiagnóstico, mas não passará pelo processo de seleção para o FGA, pois não atende a um dos requisitos mínimos: a empresa ter 2 ou mais anos de vida.");
                            break;
                        case 3:
                            MessageBox(this, "Você poderá continuar o preenchimento do autodiagnóstico, mas não passará pelo processo de seleção para o FGA, pois não atende a um dos requisitos mínimos: a empresa ter acima de 9 colaboradores.");
                            break;
                        case 4:
                            MessageBox(this.Page, "Inscrição de Empresa inserida com sucesso!");
                            break;
                    }
                }
                // Se o IdUsuarioLogado for maior que zero quer dizer que é um usuário administrativo
                if (IdUsuarioLogado > 0)
                {
                    this.UCStatus1.Visible = false;
                    LblSetaCadastro.Visible = false;
                    divSetasEmpresa.Style.Add("display", "none");
                }
                // Usuário Empresa
                else
                {
                    this.UCStatus1.Visible = true;
                    LblSetaCadastro.Visible = true;
                    divSetasEmpresa.Style.Add("display", "block");
                }
            }
        }

        protected void BtnFase1_Click(object sender, EventArgs e)
        {
            texto1.Visible = !texto1.Visible;
        }
        protected void BtnFase2_Click(object sender, EventArgs e)
        {
            texto2.Visible = !texto2.Visible;
        }
        protected void BtnFase3_Click(object sender, EventArgs e)
        {
            texto3.Visible = !texto3.Visible;
        }
        protected void BtnFase4_Click(object sender, EventArgs e)
        {
            texto4.Visible = !texto4.Visible;
        }
    }
}