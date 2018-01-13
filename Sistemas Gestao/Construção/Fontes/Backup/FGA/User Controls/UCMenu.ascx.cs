using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Vinit.SG.BLL;

namespace Sistema_de_Gestao.User_Controls
{
    public class ItemMenu
    {
        public String NomePagina { get; set; }
        public String URL { get; set; }
        public int Nivel { get; set; }
        public int Pai { get; set; }
    }

    public partial class UCMenu : UCBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Se o IdUsuarioLogado for maior que zero quer dizer que é um usuário administrativo
                if (IdUsuarioLogado > 0)
                {
                    MontaMenu(0);
                }
                // Usuário Empresa
                else if (EmpresaLogada.IdEmpresaCadastro > 0 || this.Page.Title == "Cadastro Inscrição Empresa - Dados Básicos" || this.Page.Title == "Ajuda" || this.Page.Title == "Como Preencher" || this.Page.Title == "Glossário")
                {
                    MontarMenuEmpresa();
                }
                else
                {
                    Response.Redirect("~/Paginas/Logout.aspx");
                }
            }
        }


        private void MontaMenu(int Pai)
        {
            List<EntFuncionalidade> lstFunc = UsuarioLogado.lstFuncionalidade.FindAll(delegate(EntFuncionalidade fm) { return fm.Pai == Pai; });
            List<EntFuncionalidade> lstFuncMenu = lstFunc.FindAll(delegate(EntFuncionalidade fg) { return fg.Menu == true; });

            if (lstFuncMenu.Count > 0)
            {
                if (Pai == 0)
                {
                    this.phMenu.Controls.Add(new LiteralControl("<ul id='barra' class='menubar'>"));
                    this.phMenu.Controls.Add(new LiteralControl("<li class='menuvertical' style='width: 65px;'><a style='width:64px;' href=\"/Paginas/Principal.aspx\">Home</a>"));
                    this.phMenu.Controls.Add(new LiteralControl("</li>"));
                }
                else
                {
                    this.phMenu.Controls.Add(new LiteralControl("<ul id=\"nav\" class=\"menu\">"));
                }
                for (int i = 0; i < lstFuncMenu.Count; i++)
                {
                    this.phMenu.Controls.Add(new LiteralControl("<li " + (lstFuncMenu[i].Pai == 0 ? "class='menuvertical'" : "class='submenu'") + "><a href=\"" + lstFuncMenu[i].URL + "\">" + lstFuncMenu[i].NomePagina + "</a>"));
                    MontaMenu(lstFuncMenu[i].IdFuncionalidade);
                    this.phMenu.Controls.Add(new LiteralControl("</li>"));
                }
                if (Pai == 0)
                {
                    this.phMenu.Controls.Add(new LiteralControl("<li class='menuvertical' style='width: 65px;'><a style='width:64px;' href=\"/Paginas/AlterarSenha.aspx\">Alterar Senha</a>"));
                    this.phMenu.Controls.Add(new LiteralControl("<li class='menuvertical' style='width: 75px;'><a style='width:64px;' href=\"/Paginas/Ajuda.aspx\">Ajuda</a>"));
                    //this.phMenu.Controls.Add(new LiteralControl("<li class='menuvertical' style='width: 65px;'><a style='width:64px;' href=\"/Paginas/Logout.aspx\">Sair</a>"));
                }
                this.phMenu.Controls.Add(new LiteralControl("</ul>"));
            }

        }

        private void MontarMenuEmpresa()
        {
            /*<asp:Literal ID="ltlMenuEmpresa" runat="server" Visible="false">
            </asp:Literal>*/
            Boolean PrimeiroAcesso = ((StringUtils.ToBoolean(this.Page.Request["Acesso"])) ||
                                       (EmpresaLogada.ParticipouMPE2006) ||
                                       (EmpresaLogada.ParticipouMPE2007) ||
                                       (EmpresaLogada.ParticipouMPE2008) ||
                                       (EmpresaLogada.ParticipouMPE2009) ||
                                       (EmpresaLogada.ParticipouMPE2010));
            

            String Menu = "";
            Menu = "<ul id=\"barra\" class=\"menubar\">";
            if (EmpresaLogada.IdEmpresaCadastro > 0)
            {
                if (objTurma.IdTurma > 0)
                {
                    Menu += "<li class=\"menuvertical\"><a href=\"/Paginas/Principal.aspx\">Home</a></li>";
                }
//                Menu += "<li class=\"menuvertical\"><a href=\"/Paginas/CadastroAtendimentoCE.aspx\">Atendimentos</a></li>";
                Menu += "<li class=\"menuvertical\"><a href=\"/Paginas/AlterarSenha.aspx\">Alterar Senha </a></li>";
                Menu += "<li class=\"menuvertical\"><a href=\"/Paginas/ComoPreencher.aspx\">Como Preencher</a></li>";
                Menu += "<li class=\"menuvertical\"><a href=\"/Paginas/Glossario.aspx\">Glossário</a></li>";
            }
            Menu += "<li class=\"menuvertical\"><a href=\"/Paginas/Ajuda.aspx\">Ajuda</a></li>";
            //Menu += "<li class=\"menuvertical\"><a href=\"/Paginas/Logout.aspx\">Sair </a></li>";
            Menu += "</ul>";

            this.ltlMenuEmpresa.Text = Menu;
            this.ltlMenuEmpresa.Visible = true;
        }
    }
}