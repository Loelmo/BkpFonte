using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using Vinit.SG.Common;
using System.Web.UI;
using System.Configuration;
using System.Reflection;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Threading;
using WebSupergoo.ABCpdf7;
using PEG.Utilitarios;
using System.Drawing;
using AjaxControlToolkit;

namespace PEG.Pagina_Base
{
    public class PaginaBase : System.Web.UI.Page
    {
        public Int32 IdUsuarioLogado
        {
            get
            {
                if ((EntAdmUsuario)Session["objUsuarioLogado"] == null)
                {
                    return 0;
                }
                else
                {
                    return ((EntAdmUsuario)Session["objUsuarioLogado"]).IdUsuario;
                }
            }
        }

        public EntAdmUsuario UsuarioLogado
        {
            get
            {
                if (Session["objUsuarioLogado"] == null)
                {
                    EntAdmUsuario UsuarioLogado = new BllAdmUsuario().ObterPorPermissoes(IdUsuarioLogado, objPrograma.IdPrograma);
                    Session["objUsuarioLogado"] = UsuarioLogado;
                }

                return (EntAdmUsuario)Session["objUsuarioLogado"];
            }

            set { Session["objUsuarioLogado"] = value; }
        }

        public Int32 IdEmpresaLogada
        {
            get
            {
                if ((EntEmpresaCadastro)Session["objEmpresaLogada"] == null)
                {
                    return 0;
                }
                else
                {
                    return ((EntEmpresaCadastro)Session["objEmpresaLogada"]).IdEmpresaCadastro;
                }
            }
        }

        public EntEmpresaCadastro EmpresaLogada
        {
            get
            {
                if (Session["objEmpresaLogada"] == null)
                {
                    EntEmpresaCadastro EmpresaLogada = new EntEmpresaCadastro();
                    Session["objEmpresaLogada"] = EmpresaLogada;
                }

                return (EntEmpresaCadastro)Session["objEmpresaLogada"];
            }

            set { Session["objEmpresaLogada"] = value; }
        }

        public EntPrograma objPrograma
        {
            get
            {
                if (Session["objPrograma"] == null)
                {
                    EntPrograma Programa = new EntPrograma();
                    Session["objPrograma"] = Programa;
                }

                return (EntPrograma)Session["objPrograma"];
            }

            set { Session["objPrograma"] = value; }
        }

        public EntTurma objTurma
        {
            get
            {
                if (Session["objTurma"] == null)
                {
                    EntTurma Turma = new EntTurma();
                    Session["objTurma"] = Turma;
                }

                return (EntTurma)Session["objTurma"];
            }

            set { Session["objTurma"] = value; }
        }

        public Object ListaGrid
        {
            get
            {
                if (Session["ListaGrid"] == null)
                {
                    Session["ListaGrid"] = new List<Object>();
                }
                return Session["ListaGrid"];
            }

            set { Session["ListaGrid"] = value; }
        }

        public Object ListaGridEtiqueta
        {
            get
            {
                if (Session["ListaGridEtiqueta"] == null)
                {
                    Session["ListaGridEtiqueta"] = new List<Object>();
                }
                return Session["ListaGridEtiqueta"];
            }

            set { Session["ListaGridEtiqueta"] = value; }
        }

        public String GetMapPath
        {
            get { return Server.MapPath(""); }
        }

        public String GetMapPathFull(string path)
        {
            return Server.MapPath(path);
        }

        public String GetPathUpload
        {
            get { return ConfigurationManager.AppSettings["PathUpload"].ToString(); }
        }

        public Boolean ValidaPermissaoBotao(System.Web.UI.Page aPage, EnumType.TipoAcao Acao)
        {

            List<EntFuncionalidade> lstFuncionalidade1 =  UsuarioLogado.lstFuncionalidade.FindAll(delegate(EntFuncionalidade objFuncionalidade) { return objFuncionalidade.NomePagina == aPage.Title; });

            if (lstFuncionalidade1.Count == 1)
            {
                switch (Acao)
                {
                    case EnumType.TipoAcao.Inserir:
                        return lstFuncionalidade1[0].Inserir;
                    case EnumType.TipoAcao.Atualizar:
                        return lstFuncionalidade1[0].Alterar;
                    case EnumType.TipoAcao.Excluir:
                        return lstFuncionalidade1[0].Excluir;
                    default:
                        return false;
                }
            }
            return false;
        }

        public static void RegistraScriptExcluirGrid(System.Web.UI.Page aPage, System.Web.UI.WebControls.ImageButton ImgBttnExcluir, System.String Msg)
        {
            System.String jsScript = "<script language=JavaScript> \n" +
                                     "function confirmDelete() {\n\n" +
                                     " return confirm ('" + Msg + "')\n" +
                                     "}\n" +
                                     "</script>";

            aPage.ClientScript.RegisterClientScriptBlock(aPage.GetType(), "Excluir", jsScript);
            ImgBttnExcluir.Attributes.Add("onclick", "return confirmDelete();");
        }

        public static void RegistraScriptExcluirGridMensagemLabel(System.Web.UI.Page aPage, System.Web.UI.WebControls.ImageButton ImgBttnExcluir, System.String Msg)
        {
            System.String jsScript = "<script language=JavaScript> \n" +
                                     "function confirmDelete() {\n\n" +
                                     " var msg = document.getElementById('" + Msg + "').value; \n\n" +
                                     " return confirm (msg)\n" +
                                     "}\n" +
                                     "</script>";

            aPage.ClientScript.RegisterClientScriptBlock(aPage.GetType(), "Excluir", jsScript);
            ImgBttnExcluir.Attributes.Add("onclick", "return confirmDelete();");
        }
        public String PathUpload
        {
            get { return ConfigurationManager.AppSettings["PathUpload"].ToString(); }
        }

        public static void MessageBox(System.Web.UI.Page aPage, System.String Msg)
        {
            ScriptManager.RegisterStartupScript(aPage, aPage.GetType(), Guid.NewGuid().ToString(), "alert('" + Msg + "');", true);
        }

        public static void NovaJanela(System.Web.UI.Page aPage, System.String URL)
        {
            ScriptManager.RegisterStartupScript(aPage, aPage.GetType(), Guid.NewGuid().ToString(), "window.open('" + URL + "','Link','toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=0,top=0');", true);
        }

        // Loader de UserControls com construtores que recebem parâmetros
        protected UserControl LoadControl(string UserControlPath, params object[] constructorParameters)
        {
            List<Type> constParamTypes = new List<Type>();
            foreach (object constParam in constructorParameters)
            {
                constParamTypes.Add(constParam.GetType());
            }

            UserControl ctl = Page.LoadControl(UserControlPath) as UserControl;

            // Find the relevant constructor
            ConstructorInfo constructor = ctl.GetType().BaseType.GetConstructor(constParamTypes.ToArray());

            //And then call the relevant constructor
            if (constructor == null)
            {
                throw new MemberAccessException("The requested constructor was not found on : " + ctl.GetType().BaseType.ToString());
            }
            else
            {
                constructor.Invoke(ctl, constructorParameters);
            }

            // Finally return the fully initialized UC
            return ctl;
        }

        public String CaminhoFisico
        {
            get
            {
                if (Session["CaminhoFisico"] == null)
                {
                    Session["CaminhoFisico"] = "";
                }
                return Session["CaminhoFisico"].ToString();
            }
            set
            {
                Session["CaminhoFisico"] = value;
            }
        }

        public String CaminhoLogico
        {
            get
            {
                if (Session["CaminhoLogico"] == null)
                {
                    string fileName = Session["CaminhoFisico"].ToString().Substring(Session["CaminhoFisico"].ToString().IndexOf("+_+") + 3);
                    string diretorio = Session["CaminhoFisico"].ToString().Substring(0, Session["CaminhoFisico"].ToString().LastIndexOf("\\"));
                    Session["CaminhoLogico"] = diretorio + "\\" + fileName;
                }
                return Session["CaminhoLogico"].ToString();
            }
            set
            {
                Session["CaminhoLogico"] = value;
            }
        }

        public String PathDownloadInscritas
        {
            get { return ConfigurationManager.AppSettings["PathDownloadInscritas"].ToString(); }
        }

        protected void AlterarCheck(ImageButton imgBttn, Boolean isMarcado, Boolean isEtapaAtiva)
        {
            if (isMarcado)
            {
                imgBttn.ImageUrl = "~/Image/checked.gif";
            }
            else
            {
                imgBttn.ImageUrl = "~/Image/unchecked.gif";
            }
            if (isEtapaAtiva)
            {
                HabilitaDesabilitaBotao(imgBttn, true);
            }
            else
            {
                HabilitaDesabilitaBotao(imgBttn, false);
            }
        }

        //Inscreve ou remove inscrição de empresa em questionário
        protected void AlteraParticipacao(Int32 IdQuestionario, Boolean queroParticipar)
        {
            EntQuestionarioEmpresa questionarioAberto = new BllQuestionarioEmpresa().ObterQuestionarioAberto(IdQuestionario, this.EmpresaLogada.IdEmpresaCadastro, this.objTurma.IdTurma);

            if (queroParticipar)
            {
                //Cria QUESTIONARIO_EMPRESA para o questionario e empresa em questao
                if (questionarioAberto == null)
                {
                    questionarioAberto = new EntQuestionarioEmpresa();
                    questionarioAberto.Ativo = false;
                    questionarioAberto.DtCadastro = DateTime.Now;
                    questionarioAberto.DtAlteracao = DateTime.Now;
                    questionarioAberto.EmpresaCadastro.IdEmpresaCadastro = this.EmpresaLogada.IdEmpresaCadastro;
                    questionarioAberto.Leitura = false;
                    questionarioAberto.PassaProximaEtapa = false;
                    questionarioAberto.PreencheQuestionario = true;
                    questionarioAberto.Programa.IdPrograma = this.objPrograma.IdPrograma;
                    questionarioAberto.Questionario.IdQuestionario = IdQuestionario;
                    questionarioAberto.SincronizadoSiac = false;

                    questionarioAberto.Etapa.IdEtapa = verificaEtapaInscricaoAberta().IdEtapa;

                    if (IdUsuarioLogado > 0)
                    {
                        questionarioAberto.Usuario.IdUsuario = IdUsuarioLogado;
                    }
                    new BllQuestionarioEmpresa().Inserir(questionarioAberto);
                }
                else
                {
                    questionarioAberto.PreencheQuestionario = true;
                    questionarioAberto.EnviaQuestionario = false;
                    new BllQuestionarioEmpresa().Alterar(questionarioAberto);
                }
            }
            else
            {
                if (questionarioAberto != null)
                {
                    //Inativa QUESTIONARIO_EMPRESA atual para o questionario e empresa em questao
                    questionarioAberto.PreencheQuestionario = false;
                    questionarioAberto.EnviaQuestionario = false;
                    new BllQuestionarioEmpresa().Alterar(questionarioAberto);
                }
            }
        }

        protected EntEtapa verificaEtapaInscricaoAberta()
        {
            EntEtapa etapaInscricao = null;
            if (IdUsuarioLogado > 0)
            {
                etapaInscricao = new BllEtapa().ObterPorTipoEtapaTurmaEstado(EntTipoEtapa.TIPO_ETAPA_PEG_INSCRICAO_AUTODIAGNOSTICO_ADMINISTRATIVO, objTurma.IdTurma, EmpresaLogada.Estado.IdEstado);
            }
            else
            {
                etapaInscricao = new BllEtapa().ObterPorTipoEtapaTurmaEstado(EntTipoEtapa.TIPO_ETAPA_PEG_INSCRICAO_AUTODIAGNOSTICO_EMPRESA, objTurma.IdTurma, EmpresaLogada.Estado.IdEstado);
                if (etapaInscricao.IdEtapa == 0)
                {
                    etapaInscricao = new BllEtapa().ObterPorTipoEtapaTurmaEstado(EntTipoEtapa.TIPO_ETAPA_PEG_FASE_4, objTurma.IdTurma, EmpresaLogada.Estado.IdEstado);
                }
            }
            return etapaInscricao;
        }

        public string TrueOrFalse(Object value)
        {
            if (value.ToString() == "True")
            {
                return "Sim";
            }
            else
            {
                return "Não";
            }
        }

        public String gerarRelatorioPDF(string cdaEmpCadastro, string cpfCnpj, string cdaQuestionarioEmpresa, string protocolo, string estado, string categoria, Boolean comentarios, Int32 programaId, Int32 turmaId, Int32 avaliador, Int32 intro, Boolean EnviaEmail, Page page)
        {
            if (avaliador == 0)
            {
                new BllQuestionarioEmpresa().AlterarSomenteFlagLeitura(StringUtils.ToInt(cdaQuestionarioEmpresa), true);
            }

            Session.Timeout = 13000;
            Server.ScriptTimeout = 13000;

            string caminhoFisicoRelatorios = ConfigurationManager.AppSettings["caminhoFisicoRelatorios"];
            string caminhoPaginaRelatorio = ConfigurationManager.AppSettings["caminhoPaginaRelatorio"];

            try
            {
                string[] files = Directory.GetFiles(caminhoFisicoRelatorios);
                foreach (string file in files)
                {
                    if (!File.GetCreationTime(file).ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
                        File.Delete(file);
                }
            }
            catch { }
            string c = "";
            try
            {
                int chave = 0;
                if (comentarios)
                {
                    chave = 1;
                }
                
                //if (programaId == 3)
                //{
                //    caminhoPaginaRelatorio = ConfigurationManager.AppSettings["caminhoPaginaRelatorio2008"];
                //}
                //else if (programaId == 4)
                //{
                //    caminhoPaginaRelatorio = ConfigurationManager.AppSettings["caminhoPaginaRelatorio2009"];
                //}
                //else if (programaId == 7)
                //{
                //    caminhoPaginaRelatorio = ConfigurationManager.AppSettings["caminhoPaginaRelatorioAutoavaliacao"];
                //}

                Doc theDoc = new Doc();
                theDoc.SetInfo(0, "License", "bc8b5c07da69df2b6c476901f513aa8b89ff6d8ce56a16797802be20da7348078ab9ae58bd6c483b");
                theDoc.HtmlOptions.Timeout = 30000000;


                String link = this.getDominio(page) + caminhoPaginaRelatorio + "?CDA_EMP_CADASTRO=" + cdaEmpCadastro + "&TX_CPF_CNPJ=" + cpfCnpj + "&Chave=" + chave + "&Avaliador=" + avaliador + "&Intro=" + intro + "&CEA_QUESTIONARIO_EMPRESA=" + cdaQuestionarioEmpresa + "&Protocolo=" + protocolo + "&turmaId=" + turmaId + "&programaId=" + programaId;

                if (estado != null)
                {
                    link = link + "&naoMostraComentarioJuiz=1";
                }
                else if (page.Request["naoMostraComentarioJuiz"] != null && page.Request["naoMostraComentarioJuiz"].Equals("1"))
                {
                    link = link + "&naoMostraComentarioJuiz=1";
                }
                int theID = theDoc.AddImageUrl(link, true, 1000, true);
                while (true)
                {
                    theDoc.FrameRect();
                    if (!theDoc.Chainable(theID))
                        break;
                    theDoc.Page = theDoc.AddPage();
                    theID = theDoc.AddImageToChain(theID);
                }

                for (int i = 1; i <= theDoc.PageCount; i++)
                {
                    theDoc.PageNumber = i;
                    theDoc.Flatten();
                }

                String ArquivoNome = protocolo + "_" + DateTime.Now.Ticks + ".pdf";
                String CaminhoPDF = caminhoFisicoRelatorios + ArquivoNome;

                CaminhoPDF = Server.MapPath(CaminhoPDF);

                theDoc.Save(CaminhoPDF);
                theDoc.HtmlOptions.PageCacheClear();
                theDoc.Clear();

                theDoc.Delete(theID);
                theDoc.Dispose();

                theDoc = null;
                GC.Collect();


                Thread.Sleep(5000);

                if (EnviaEmail)
                {
                    //WebUtils.EnviaEmail(Request.QueryString["EmailContato"], "Relatório de AutoAvaliação", new System.Text.StringBuilder(), CaminhoPDF);
                    return CaminhoPDF;
                    //ClientScript.RegisterClientScriptBlock(Page.GetType(), "closeWindow", "window.close();", true);
                }
                else
                {
                    //Response.Redirect(getDominio(this.Page) + "/Relatorios/" + ArquivoNome);
                    //return null;
                    return "/Relatorios/" + ArquivoNome;
                }
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
                throw ex;
            }
            return null;
        }

        public String getDominio(Page page)
        {
            String Url = page.Request.Url.AbsoluteUri.Substring(0, page.Request.Url.AbsoluteUri.ToString().IndexOf(page.Request.Url.Authority) + page.Request.Url.Authority.Length);
            return Url;
        }

        protected Boolean Valida_TextBox(TextBox source)
        {
            bool is_valid = source.Text != "";
            source.BackColor = is_valid ? Color.White : Color.Yellow;
            return is_valid;
        }

        protected Boolean Valida_TextBoxSenha(TextBox source, TextBox source2)
        {
            bool is_valid = true;
            if (source.Text == "" || source2.Text == "" || source.Text != source2.Text || source.Text.Length < 6 || source2.Text.Length < 6)
            {
                source.Text = "";
                source2.Text = "";
                source.Focus();
                is_valid = false;
            }
            source.BackColor = is_valid ? Color.White : Color.Yellow;
            source2.BackColor = is_valid ? Color.White : Color.Yellow;
            return is_valid;
        }

        protected Boolean Valida_DropDownList(DropDownList source)
        {
            bool is_valid = source.SelectedValue != "0";
            source.BackColor = is_valid ? Color.White : Color.Yellow;
            return is_valid;
        }

        protected Boolean Valida_RadioButtonList(RadioButtonList source)
        {
            bool is_valid = source.SelectedValue != "";
            source.BackColor = is_valid ? Color.White : Color.Yellow;
            return is_valid;
        }

        protected Boolean Valida_DropDownList(ComboBox source)
        {
            bool is_valid = source.SelectedValue != "0";
            source.BackColor = is_valid ? Color.White : Color.Yellow;
            return is_valid;
        }

        protected Boolean Valida_TextBoxData(TextBox source)
        {
            bool is_valid = true;
            if(((TextBox)source).Text == ""){
                is_valid = false;
            }
            if (DateUtils.ToDateTime(source.Text) < DateUtils.ToDateTime("01/01/1700"))
            {
                is_valid = false;
                source.Text = "";
            }
            if (DateUtils.ToDateTime(source.Text) > DateUtils.ToDateTime("01/01/2015"))
            {
                is_valid = false;
                source.Text = "";
            }
            source.BackColor = is_valid ? Color.White : Color.Yellow;
            return is_valid;
        }

        protected Int32 ProcessaFaixaEtaria(DateTime DataNascimento)
        {
            int anos = DateTime.Now.Year - DataNascimento.Year;

            if (DateTime.Now.Month < DataNascimento.Month || (DateTime.Now.Month == DataNascimento.Month && DateTime.Now.Day < DataNascimento.Day))
            {
                anos--;
            }

            if (anos < 25)
            {
                return EntContatoFaixaEtaria.FAIXA_ETARIA_MENOS_25;
            }
            else if (anos < 30)
            {
                return EntContatoFaixaEtaria.FAIXA_ETARIA_25_A_29;
            }
            else if (anos < 35)
            {
                return EntContatoFaixaEtaria.FAIXA_ETARIA_30_A_34;
            }
            else if (anos < 40)
            {
                return EntContatoFaixaEtaria.FAIXA_ETARIA_35_A_39;
            }
            else if (anos < 45)
            {
                return EntContatoFaixaEtaria.FAIXA_ETARIA_40_A_44;
            }
            else if (anos < 50)
            {
                return EntContatoFaixaEtaria.FAIXA_ETARIA_45_A_49;
            }
            else
            {
                return EntContatoFaixaEtaria.FAIXA_ETARIA_ACIMA_50;
            }
        }

        protected void HabilitaDesabilitaBotao(ImageButton Btn, Boolean Ativar)
        {
            Btn.Enabled = Ativar;
            if (!Ativar)
            {
                Btn.Style.Add("cursor", "default");
            }
        }
    }
}