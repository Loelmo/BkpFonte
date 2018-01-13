using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Sistema_de_Gestao.Pagina_Base;
using Sistema_de_Gestao.Utilitarios;

namespace Sistema_de_Gestao.MPE.Paginas
{
    public partial class Etiqueta : PaginaBase
    {

        #region controle de tela
		protected System.Web.UI.WebControls.Repeater repEtiqueta;
		#endregion

		#region Objetos
		private DataView dv;
		#endregion

		#region variáveis
		private string empresaCheck = "";
		private string filtro = "";
		protected System.Web.UI.WebControls.PlaceHolder phPaginacao;
		protected System.Web.UI.WebControls.PlaceHolder phPaginacaoRodape;
		private string[] arrCheck = new string[0];
		#endregion

        #region load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AtualizaDados();
            }
        }
        #endregion

        #region AtualizaDados
        private void AtualizaDados()
        {
            try
            {
                int Pagina = 0;
                try
                {
                    Pagina = int.Parse(Request.QueryString["pagina"]);
                }
                catch { Pagina = 0; }

                this.AtualizarRepeater(Pagina);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        #endregion

        #region Escreve o item do estado na tela
        private void repEtiqueta_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.AlternatingItem:
                case ListItemType.Item:

                    Label lblRazaoSocial = (Label)e.Item.FindControl("lblRazaoSocial");
                    Label lblContato = (Label)e.Item.FindControl("lblContato");
                    Label lblEndereco = (Label)e.Item.FindControl("lblEndereco");
                    Label lblCEP = (Label)e.Item.FindControl("lblCEP");
                    Label lblCidade = (Label)e.Item.FindControl("lblCidade");
                    Label lblEstado = (Label)e.Item.FindControl("lblEstado");

                    lblRazaoSocial.Text = DataBinder.Eval(e.Item.DataItem, "TX_RAZAO_SOCIAL").ToString();
                    lblContato.Text = DataBinder.Eval(e.Item.DataItem, "TX_NOME").ToString();
                    lblEndereco.Text = DataBinder.Eval(e.Item.DataItem, "TX_ENDERECO").ToString();
                    lblCEP.Text = DataBinder.Eval(e.Item.DataItem, "TX_CEP").ToString();
                    lblCidade.Text = DataBinder.Eval(e.Item.DataItem, "TX_CIDADE").ToString();
                    lblEstado.Text = DataBinder.Eval(e.Item.DataItem, "CEA_ESTADO").ToString();

                    break;
            }
        }
        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.repEtiqueta.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.repEtiqueta_ItemDataBound);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region Paginacao
        private void AtualizarRepeater(int pagina)
        {
            try
            {
                //Instaciamos a Classe PagedDataSource que é a responsavel pela Paginação
                PagedDataSource pds = new PagedDataSource();

                //Dizemos que ela esta habilitada para ser paginada
                pds.AllowPaging = true;

                //E Informamos que o DataSource do Objeto é a Classe "receitacomentario".
                pds.DataSource = (List<object>)ListaGrid;

                //Itens exibidos por página.
                pds.PageSize = 20;
                pds.CurrentPageIndex = pagina;

                repEtiqueta.DataSource = pds;
                repEtiqueta.DataBind();

                if (pds.PageCount > 1)
                {
                    this.phPaginacao.Controls.Clear();

                    this.phPaginacaoRodape.Controls.Clear();

                    HyperLink lkbPagina;
                    HyperLink lkbPaginaRodape;

                    if (pagina >= 0)
                    {
                        lkbPagina = new HyperLink();
                        lkbPagina.NavigateUrl = string.Format("etiqueta.aspx?pagina={0}", pagina - 1);
                        lkbPagina.Text = ("<").ToString();

                        lkbPaginaRodape = new HyperLink();
                        lkbPaginaRodape.NavigateUrl = lkbPagina.NavigateUrl;
                        lkbPaginaRodape.Text = lkbPagina.Text;

                        this.phPaginacao.Controls.Add(lkbPagina);
                        this.phPaginacaoRodape.Controls.Add(lkbPaginaRodape);
                    }

                    for (int i = 1; i <= 10; i++)
                    {
                        if (pagina + i <= pds.PageCount)
                        {
                            lkbPagina = new HyperLink();
                            lkbPagina.NavigateUrl = string.Format("etiqueta.aspx?pagina={0}", pagina + i - 1);
                            lkbPagina.Text = (pagina + i).ToString();

                            lkbPaginaRodape = new HyperLink();
                            lkbPaginaRodape.NavigateUrl = lkbPagina.NavigateUrl;
                            lkbPaginaRodape.Text = lkbPagina.Text;

                            if (i > 1)
                            {
                                this.phPaginacao.Controls.Add(new LiteralControl(" | "));
                                this.phPaginacaoRodape.Controls.Add(new LiteralControl(" | "));
                            }
                            this.phPaginacao.Controls.Add(lkbPagina);
                            this.phPaginacaoRodape.Controls.Add(lkbPaginaRodape);
                        }
                    }

                    if (pds.PageCount > (pagina + 10))
                    {
                        lkbPagina = new HyperLink();
                        lkbPagina.NavigateUrl = string.Format("etiqueta.aspx?pagina={0}", pagina + 1);
                        lkbPagina.Text = (">").ToString();

                        lkbPaginaRodape = new HyperLink();
                        lkbPaginaRodape.NavigateUrl = lkbPagina.NavigateUrl;
                        lkbPaginaRodape.Text = lkbPagina.Text;

                        this.phPaginacao.Controls.Add(lkbPagina);
                        this.phPaginacaoRodape.Controls.Add(lkbPaginaRodape);
                    }
                }

                string paginacao = "";

                paginacao = " Total: " + ((List<object>)ListaGrid).Count + " Pg <b>" + (pagina + 1).ToString() + "</b> de " + pds.PageCount;

                this.phPaginacao.Controls.Add(new LiteralControl(paginacao));
                this.phPaginacaoRodape.Controls.Add(new LiteralControl(paginacao));
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        #endregion

    }
}
