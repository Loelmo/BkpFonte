using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vinit.SG.Ent;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Vinit.SG.Common;
using Vinit.SG.BLL;
using Sistema_de_Gestao.Pagina_Base;
using WebSupergoo.ABCpdf7;
using System.IO;
using System.Threading;
using System.Drawing;
using AjaxControlToolkit;

namespace Sistema_de_Gestão_de_Treinamento.User_Control
{
    public class UCBase : System.Web.UI.UserControl
    {
        public static Int32 IdUsuarioLogado
        {
            get
            {
                return new PaginaBase().IdUsuarioLogado;
            }
        }

        public static EntAdmUsuario UsuarioLogado
        {
            get
            {
                return new PaginaBase().UsuarioLogado;
            }
        }

        public Int32 IdEmpresaLogada
        {
            get
            {
                return new PaginaBase().IdEmpresaLogada;
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
                    Programa.IdPrograma = 1;
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
                    Turma.IdTurma = 6;
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

        public Boolean ValidaPermissaoBotao(System.Web.UI.Page aPage, EnumType.TipoAcao Acao)
        {

            List<EntFuncionalidade> lstFuncionalidade1 = UsuarioLogado.lstFuncionalidade.FindAll(delegate(EntFuncionalidade objFuncionalidade) { return objFuncionalidade.NomePagina == aPage.Title; });

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

        public static void RegistraScriptExcluir(System.Web.UI.Page aPage, System.Web.UI.WebControls.ImageButton ImgBttnExcluir, System.String Msg)
        {
            ImgBttnExcluir.Attributes.Add("onclick", "return Confirm('" + Msg + "');");
        }

        public static void NovaJanela(System.Web.UI.Page aPage, System.String URL)
        {
            ScriptManager.RegisterStartupScript(aPage, aPage.GetType(), Guid.NewGuid().ToString(), "window.open('" + URL + "','Link','toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=0,top=0');", true);
        }

        private static void ClearSingleControl(Control c)
        {
            if (c.GetType() == typeof(TextBox))
            {
                ((TextBox)c).Text = String.Empty;
            }
            else if (c.GetType() == typeof(HiddenField))
            {
                ((HiddenField)c).Value = String.Empty;
            }
            else if (c.GetType() == typeof(CheckBox))
            {
                ((CheckBox)c).Checked = false;
            }
            else if (c.GetType() == typeof(DropDownList))
            {
                ((DropDownList)c).SelectedIndex = -1;
            }
        }

        public static void ClearControl(ControlCollection controls, ControlCollection AExceptControl)
        {

            foreach (Control c in controls)
            {
                if (AExceptControl != null && AExceptControl.Count > 0)
                {
                    if (!AExceptControl.Contains(c))
                    {
                        ClearSingleControl(c);
                    }
                }
                else
                {
                    ClearSingleControl(c);
                }
            }
        }

        public static void ClearControl(ControlCollection controls)
        {
            ClearControl(controls, null);
        }


        private static void EnableSingleControl(Control c, Boolean aValue)
        {
            if (c.GetType() == typeof(TextBox))
            {
                ((TextBox)c).ReadOnly = !aValue;
            }
            else if (c.GetType() == typeof(CheckBox))
            {
                ((CheckBox)c).Enabled = aValue;
            }
            else if (c.GetType() == typeof(DropDownList))
            {
                ((DropDownList)c).Enabled = aValue;
            }
            else if (c.GetType() == typeof(ListBox))
            {
                ((ListBox)c).Enabled = aValue;
            }
            else if (c.GetType() == typeof(Button))
            {
                ((Button)c).Enabled = aValue;
            }
            
        }

        public static void EnableControl(ControlCollection controls, Boolean aValue, ControlCollection AExceptControl)
        {

            foreach (Control c in controls)
            {
                if (AExceptControl != null && AExceptControl.Count > 0)
                {
                    if (!AExceptControl.Contains(c))
                    {
                        EnableSingleControl(c, aValue);
                    }
                }
                else
                {
                    EnableSingleControl(c, aValue);
                }
            }
        }

        public static void EnableControl(ControlCollection controls, Boolean aValue)
        {
            EnableControl(controls, aValue, null);
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


        public static void MessageBox(System.Web.UI.Page aPage, System.String Msg)
        {
            ScriptManager.RegisterStartupScript(aPage, aPage.GetType(), Guid.NewGuid().ToString(), "alert('" + Msg + "');", true);
        }

        public String PathDownloadInscritas
        {
            get { return ConfigurationManager.AppSettings["PathDownloadInscritas"].ToString(); }
        }

        public String PathDownloadArquivos
        {
            get { return ConfigurationManager.AppSettings["PathDownloadArquivos"].ToString(); }
        }

        public void SetSelectedItemInDropDownList(ListControl drpDwnLst, String value)
        {
            if (drpDwnLst.Items.FindByValue(value) != null)
            {
                drpDwnLst.SelectedValue = value;
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
                    new BllQuestionarioEmpresa().Alterar(questionarioAberto);
                }
            }
            else
            {
                if (questionarioAberto != null)
                {
                    //Inativa QUESTIONARIO_EMPRESA atual para o questionario e empresa em questao
                    questionarioAberto.PreencheQuestionario = false;
                    new BllQuestionarioEmpresa().Alterar(questionarioAberto);
                }
            }
        }

        protected EntEtapa verificaEtapaInscricaoAberta()
        {
            EntEtapa etapaInscricao = null;
            if (objPrograma.IdPrograma == EntPrograma.PROGRAMA_MPE)
            {
                if (IdUsuarioLogado > 0)
                {
                    etapaInscricao = new BllEtapa().ObterPorTipoEtapaTurmaEstado(EntTipoEtapa.TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_ADMINISTRATIVO, objTurma.IdTurma, EmpresaLogada.Estado.IdEstado);
                }
                else
                {
                    etapaInscricao = new BllEtapa().ObterPorTipoEtapaTurmaEstado(EntTipoEtapa.TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_EMPRESA, objTurma.IdTurma, EmpresaLogada.Estado.IdEstado);
                }
            }
            else if (objPrograma.IdPrograma == EntPrograma.PROGRAMA_FGA)
            {
                if (IdUsuarioLogado > 0)
                {
                    etapaInscricao = new BllEtapa().ObterPorTipoEtapaTurmaEstado(EntTipoEtapa.TIPO_ETAPA_FGA_INSCRICAO_AUTODIAGNOSTICO_ADMINISTRATIVO, objTurma.IdTurma, EmpresaLogada.Estado.IdEstado);
                }
                else
                {
                    etapaInscricao = new BllEtapa().ObterPorTipoEtapaTurmaEstado(EntTipoEtapa.TIPO_ETAPA_FGA_INSCRICAO_AUTODIAGNOSTICO_EMPRESA, objTurma.IdTurma, EmpresaLogada.Estado.IdEstado);
                }
            }
            else if (objPrograma.IdPrograma == EntPrograma.PROGRAMA_PEG)
            {
                if (IdUsuarioLogado > 0)
                {
                    etapaInscricao = new BllEtapa().ObterPorTipoEtapaTurmaEstado(EntTipoEtapa.TIPO_ETAPA_PEG_INSCRICAO_AUTODIAGNOSTICO_ADMINISTRATIVO, objTurma.IdTurma, EmpresaLogada.Estado.IdEstado);
                }
                else
                {
                    etapaInscricao = new BllEtapa().ObterPorTipoEtapaTurmaEstado(EntTipoEtapa.TIPO_ETAPA_PEG_INSCRICAO_AUTODIAGNOSTICO_EMPRESA, objTurma.IdTurma, EmpresaLogada.Estado.IdEstado);
                }
            }
            return etapaInscricao;
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
            if (((TextBox)source).Text == "")
            {
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