using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Vinit.SG.Common;
using Vinit.SG.BLL;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Configuration;
using Vinit.SG.Ent;
using System.Threading;
using System.IO;
using WebSupergoo.ABCpdf7;
using AjaxControlToolkit;

namespace Sistema_de_Gestao.Utilitarios
{
    public class WebUtils : System.Web.UI.Page
    {
        public static void PopulaDropDownList(DropDownList DropDownList, EnumType.TipoDropDownList TipoControl, String ValorPadrao = null)
        {
            WebUtils.PopulaDropDownList(DropDownList, TipoControl, false, ValorPadrao);
        }

        public static Boolean EnviaEmailNoticia(String sPara, EntNoticia objNoticia)
        {
            String sAssunto = objNoticia.Titulo;
            StringBuilder sbMensagem = new StringBuilder();
            sbMensagem.Append(objNoticia.Noticia);

            return EnviaEmail(sPara, sAssunto, sbMensagem);
        }

        public static Boolean EnviaEmailRaa(String sPara, String CnpjCpf, String CaminhoAnexo)
        {
            String sAssunto = "Relatório de Autoavaliação - " + CnpjCpf;
            StringBuilder sbMensagem = new StringBuilder();
            sbMensagem.AppendLine("Prezado Empresário,");
            sbMensagem.AppendLine();
            sbMensagem.AppendLine("Enviamos o arquivo anexo com seu  Relatório de Autodiagnóstico com os pontos fortes e oportunidades de melhorias da gestão da sua empresa.");
            sbMensagem.AppendLine();
            sbMensagem.AppendLine("Atenciosamente,");
            sbMensagem.AppendLine();
            sbMensagem.AppendLine("SEBRAE e Fundação Nacional da Qualidade (FNQ)");

            return EnviaEmail(sPara, sAssunto, sbMensagem, CaminhoAnexo);
        }

        public static Boolean EnviaEmail(String sPara, String sAssunto, StringBuilder sbMensagem)
        {
            return EnviaEmail(sPara, sAssunto, sbMensagem, "");
        }

        public static Boolean EnviaEmail(String sPara, String sAssunto, StringBuilder sbMensagem, String Anexo)
        {
            try
            {

                String email_send = "fga@fnq.org.br";
                String email_port = "25";
                //  String email_smtp = "smtp.gmail.com";
                String email_smtp = ConfigurationManager.AppSettings["SmtpServer"].ToString(); ;
                Boolean email_autenticado = false;
                String email_imap_usuario = "sg@vinit.com.br";
                String email_imap_senha = "6546E6";

                SmtpClient client = new SmtpClient();
                MailAddress de = new MailAddress(email_send);
                MailAddress para = new MailAddress(sPara);
                MailMessage mailMessage = new MailMessage(de, para);
                mailMessage.IsBodyHtml = false;
                mailMessage.Subject = sAssunto;
                mailMessage.Body = sbMensagem.ToString();

                if (Anexo != String.Empty)
                {
                    mailMessage.Attachments.Add(new System.Net.Mail.Attachment(Anexo));
                }

                SmtpClient smtpClient = new SmtpClient(email_smtp, Int32.Parse(email_port));

                if (email_autenticado)
                {
                    NetworkCredential Credentials = new NetworkCredential(email_imap_usuario, email_imap_senha);
                    smtpClient.Credentials = Credentials;
                    smtpClient.EnableSsl = true;
                }

                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static void PopulaDropDownList(DropDownList DropDownList, EnumType.TipoDropDownList TipoControl, Boolean isCpf, String ValorPadrao = null)
        {
            switch (TipoControl)
            {
                case EnumType.TipoDropDownList.Categoria:
                    DropDownList.Items.Clear();
                    DropDownList.DataSource = new BllCategoria().ObterTodosFga(true);
                    DropDownList.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        DropDownList.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        DropDownList.SelectedIndex = 0;
                    }
                    break;

                case EnumType.TipoDropDownList.Faturamento:
                    DropDownList.Items.Clear();
                    DropDownList.DataSource = new BllFaturamento().ObterPorIdTipoFaturamento(4);
                    DropDownList.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        DropDownList.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        DropDownList.SelectedIndex = 0;
                    }
                    break;

                case EnumType.TipoDropDownList.Escolaridade:
                    DropDownList.Items.Clear();
                    DropDownList.DataSource = new BllContatoNivelEscolaridade().ObterTodos();
                    DropDownList.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        DropDownList.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        DropDownList.SelectedIndex = 0;
                    }
                    break;

                case EnumType.TipoDropDownList.TipoEmpresa:
                    DropDownList.Items.Clear();
                    DropDownList.DataSource = new BllTipoEmpresa().ObterTodosFga();
                    DropDownList.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        DropDownList.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        DropDownList.SelectedIndex = 0;
                    }
                    break;

                case EnumType.TipoDropDownList.FaixaEtaria:
                    DropDownList.Items.Clear();
                    DropDownList.DataSource = new BllContatoFaixaEtaria().ObterTodos();
                    DropDownList.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        DropDownList.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        DropDownList.SelectedIndex = 0;
                    }
                    break;
                case EnumType.TipoDropDownList.Cargo:
                    DropDownList.Items.Clear();
                    DropDownList.DataSource = new BllCargo().ObterTodos();
                    DropDownList.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        DropDownList.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        DropDownList.SelectedIndex = 0;
                    }
                    break;
                case EnumType.TipoDropDownList.AtividadeEconomica:
                    DropDownList.Items.Clear();
                    DropDownList.DataSource = new BllAtividadeEconomica().ObterTodos();
                    DropDownList.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        DropDownList.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        DropDownList.SelectedIndex = 0;
                    }
                    break;
            }
        }


        public static void PopulaDropDownList(ComboBox comboBox, EnumType.TipoDropDownList TipoControl, String ValorPadrao = null)
        {
            switch (TipoControl)
            {
                case EnumType.TipoDropDownList.Categoria:
                    comboBox.Items.Clear();
                    comboBox.DataSource = new BllCategoria().ObterTodosFga(true);
                    comboBox.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        comboBox.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        comboBox.SelectedIndex = 0;
                    }
                    break;

                case EnumType.TipoDropDownList.Faturamento:
                    comboBox.Items.Clear();
                    comboBox.DataSource = new BllFaturamento().ObterPorIdTipoFaturamento(4);
                    comboBox.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        comboBox.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        comboBox.SelectedIndex = 0;
                    }
                    break;

                case EnumType.TipoDropDownList.Escolaridade:
                    comboBox.Items.Clear();
                    comboBox.DataSource = new BllContatoNivelEscolaridade().ObterTodos();
                    comboBox.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        comboBox.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        comboBox.SelectedIndex = 0;
                    }
                    break;

                case EnumType.TipoDropDownList.TipoEmpresa:
                    comboBox.Items.Clear();
                    comboBox.DataSource = new BllTipoEmpresa().ObterTodosFga();
                    comboBox.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        comboBox.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        comboBox.SelectedIndex = 0;
                    }
                    break;

                case EnumType.TipoDropDownList.FaixaEtaria:
                    comboBox.Items.Clear();
                    comboBox.DataSource = new BllContatoFaixaEtaria().ObterTodos();
                    comboBox.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        comboBox.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        comboBox.SelectedIndex = 0;
                    }
                    break;
                case EnumType.TipoDropDownList.Cargo:
                    comboBox.Items.Clear();
                    comboBox.DataSource = new BllCargo().ObterTodos();
                    comboBox.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        comboBox.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        comboBox.SelectedIndex = 0;
                    }
                    break;
                case EnumType.TipoDropDownList.AtividadeEconomica:
                    comboBox.Items.Clear();
                    comboBox.DataSource = new BllAtividadeEconomica().ObterTodos();
                    comboBox.DataBind();

                    if ((!StringUtils.IsEmpty(ValorPadrao)) || (ValorPadrao != null))
                    {
                        comboBox.Items.Insert(0, new ListItem(ValorPadrao, "0"));
                        comboBox.SelectedIndex = 0;
                    }
                    break;
            }
        }

        public static EntPrograma VerificaProgramaPorURL(String Url)
        {
            EntPrograma objPrograma = new EntPrograma();

            String UrlMPE = ConfigurationManager.AppSettings["UrlMPE"];
            String UrlFGA = ConfigurationManager.AppSettings["UrlFGA"];
            String UrlPEG = ConfigurationManager.AppSettings["UrlPEG"];
            
            if (UrlMPE == Url)
                objPrograma.IdPrograma = (int)EnumType.Programa.MPE;
            else if (UrlFGA == Url)
                objPrograma.IdPrograma = (int)EnumType.Programa.FGA;
            else if (UrlPEG == Url)
                objPrograma.IdPrograma = (int)EnumType.Programa.PEG;
            else
                objPrograma.IdPrograma = (int)EnumType.Programa.MPE;

            return objPrograma;
        }

        public static String VerificaUrlPorPrograma(EntPrograma objPrograma)
        {
            String retorno = "";
            switch (objPrograma.IdPrograma)
            {
                case 1:
                    retorno = ConfigurationManager.AppSettings["UrlMPE"];

                    break;
                case 2:
                    retorno = ConfigurationManager.AppSettings["UrlFGA"];

                    break;
                case 3:
                    retorno = ConfigurationManager.AppSettings["UrlPEG"];

                    break;
                default:
                    retorno = ConfigurationManager.AppSettings["UrlMPE"];;
                    break;
            }

            return retorno;
        }

        public static String AplicaEstilo(EntPrograma objPrograma)
        {
            String retorno = "";
            switch (objPrograma.IdPrograma)
            {
                case 1:
                    retorno = "/App_Themes/MPE/theme.css";

                    break;
                case 2:
                    retorno = "/App_Themes/FGA/theme.css";

                    break;
                case 3:
                    retorno = "/App_Themes/PEG/theme.css";

                    break;
                default:
                    retorno = "/App_Themes/MPE/theme.css";
                    break;
            }

            return retorno;
        }

        public static String AplicaFavIcon(EntPrograma objPrograma)
        {
            String retorno = "";
            switch (objPrograma.IdPrograma)
            {
                case 1:
                    retorno = "/favicon.ico";
                    break;
                case 2:
                    retorno = "/Image/Fga/favicon.ico";
                    break;
                case 3:
                    retorno = "/Image/Peg/favicon.ico";
                    break;
                default:
                    retorno = "/favicon.ico";
                    break;
            }

            return retorno;
        }

    }
}