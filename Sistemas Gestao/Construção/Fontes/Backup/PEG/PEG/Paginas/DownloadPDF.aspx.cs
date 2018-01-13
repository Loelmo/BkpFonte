using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net;
using System.Drawing;
using System.Text;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using System.Threading;
using WebSupergoo.ABCpdf7;
using PEG.Utilitarios;
using PEG.Pagina_Base;

public partial class Enviar_Questionario_DownloadPDF : PaginaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["protocolo"] != null)
            {
                String estado = null;
                String categoria = null;

                List<EntQuestionarioEmpresa> listQuestionarioEmpresa = new BllQuestionarioEmpresa().ObterPorProtocolo(Request["protocolo"]);

                new BllQuestionarioEmpresa().AlterarRelatorioGeradoPorProtocolo(Request["protocolo"], true);
                
                if (listQuestionarioEmpresa != null)
                {
                    List<EntEmpresaCadastro> listEmpresaCadastro = new BllEmpresaCadastro().ObterPorIdPrograma(listQuestionarioEmpresa[0].EmpresaCadastro.IdEmpresaCadastro, StringUtils.ToInt(Request["programaId"]));

                    if (listEmpresaCadastro != null)
                    {
                        Boolean comentarios = ObjectUtils.ToBoolean(Request["comentarios"]);
                        Int32 programaId = ObjectUtils.ToInt(Request["programaId"]);
                        Int32 turmaId = ObjectUtils.ToInt(Request["turmaId"]);
                        Int32 avaliador = ObjectUtils.ToInt(Request["avaliacao"]);
                        Int32 intro = ObjectUtils.ToInt(Request["intro"]);
                        gerarRelatorioPDF(listEmpresaCadastro[0].IdEmpresaCadastro.ToString(), listEmpresaCadastro[0].CPF_CNPJ, listQuestionarioEmpresa[0].IdQuestionarioEmpresa.ToString(), Request["protocolo"], estado, categoria, comentarios, programaId, turmaId, avaliador, intro, false, this.Page);
                    }
                }
            }
        }
    }

    
}
