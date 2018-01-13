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
            this.LblTitulo1.Text = "MPE BRASIL 2011 - PRÊMIO DE COMPETITIVIDADE PARA MICRO E PEQUENAS EMPRESAS";
            this.LblDescricao1.Text = " O “MPE Brasil - Prêmio de Competitividade para Micro e Pequenas Empresas” se constitui no reconhecimento estadual e nacional às micro e pequenas empresas que promovem o aumento a qualidade, da produtividade e da competitividade, pela disseminação de conceitos e práticas de gestão.";
            this.LblDescricao2.Text = "Nesta área você tem acesso às notícias e arquivos selecionados pelos Gestores Estaduais e Nacionais do Prêmio MPE Brasil 2011 especialmente para a sua empresa.";

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
    }
}