using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestao.Utilitarios;
using Vinit.SG.Common;
using Vinit.SG.Ent;
using Vinit.SG.BLL;

namespace Sistema_de_Gestao.Paginas
{
    public partial class DesempenhoGlobal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // parametros do User Control
            this.UCEstado1.EscritorioRegional = true;
            this.UCEstado1.Regiao = true;
            this.UCEstado1.Grupo = true;

            if (!IsPostBack)
            {
                WebUtils.PopulaDropDownList(this.DrpDwnLstCategoria, EnumType.TipoDropDownList.Categoria, "Todos");
            }


        }

        protected void ImgBttnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            EntDesempenhoGlobal objDesempenhoGlobal = new EntDesempenhoGlobal();

            this.PageToObject(objDesempenhoGlobal);

            //List<EntDesempenhoGlobal> lstDesempenhoGlobal2010 = new BllDesempenhoGlobal().GerarDesempenhoGlobal2010(objDesempenhoGlobal);
            List<EntDesempenhoGlobal> lstDesempenhoGlobal2011 = new BllDesempenhoGlobal().GerarDesempenhoGlobal2011(objDesempenhoGlobal);

            //this.PopulaGridDesempenhoGlobal2010(lstDesempenhoGlobal2010);
            this.PopulaGridDesempenhoGlobal2011(lstDesempenhoGlobal2011);

            this.GerarGraficoRadar(lstDesempenhoGlobal2011);

            this.divGrafico.Visible = true;

            this.GeraQuestionario();
        }

        private void PopulaGridDesempenhoGlobal2011(List<EntDesempenhoGlobal> lstDesempenhoGlobal2011)
        {
            this.grdDesempenhoGlobal2011.DataSource = lstDesempenhoGlobal2011;
            this.grdDesempenhoGlobal2011.DataBind();
        }

        private void PageToObject(EntDesempenhoGlobal objDesempenhoGlobal)
        {
            objDesempenhoGlobal.CPF_CNPJ = StringUtils.OnlyNumbers(this.TxtBxCNPJ_CPF.Text);
            objDesempenhoGlobal.NomeFantasia = this.TxtBxNome.Text;
            objDesempenhoGlobal.Turma = this.UCEstado1.IdTurma;
            objDesempenhoGlobal.EscritorioRegional = this.UCEstado1.IdEscritorioRegional;
            objDesempenhoGlobal.Regiao = this.UCEstado1.IdRegiao;
            objDesempenhoGlobal.Cidade = this.UCEstado1.IdCidade;
            objDesempenhoGlobal.Grupo = this.UCEstado1.IdGrupo;
            objDesempenhoGlobal.Categoria = StringUtils.ToInt(DrpDwnLstCategoria.SelectedValue);
            objDesempenhoGlobal.Status = StringUtils.ToInt(DrpDwnLstStatus.SelectedValue);
            objDesempenhoGlobal.PremioEspecial = this.ChckBxPremiosEspeciais.Checked;
        }

        private void GerarGraficoRadar(List<EntDesempenhoGlobal> lstDesempenhoGlobal2011)
        {
            String parametrosRadarCorrente = "";

            //parametrosRadarAnterior += ((lstDesempenhoGlobal2010[0].PontuacaoObtida * 100) / 9).ToString("0") + ",";
            parametrosRadarCorrente += ((lstDesempenhoGlobal2011[0].PontuacaoObtida * 100) / 9).ToString("0") + ",";

            //parametrosRadarAnterior += ((lstDesempenhoGlobal2010[1].PontuacaoObtida * 100) / 6).ToString("0") + ",";
            parametrosRadarCorrente += ((lstDesempenhoGlobal2011[1].PontuacaoObtida * 100) / 6).ToString("0") + ",";

            //parametrosRadarAnterior += ((lstDesempenhoGlobal2010[2].PontuacaoObtida * 100) / 15).ToString("0") + ",";
            parametrosRadarCorrente += ((lstDesempenhoGlobal2011[2].PontuacaoObtida * 100) / 15).ToString("0") + ",";

            //parametrosRadarAnterior += ((lstDesempenhoGlobal2010[3].PontuacaoObtida * 100) / 9).ToString("0") + ",";
            parametrosRadarCorrente += ((lstDesempenhoGlobal2011[3].PontuacaoObtida * 100) / 9).ToString("0") + ",";

            //parametrosRadarAnterior += ((lstDesempenhoGlobal2010[4].PontuacaoObtida * 100) / 9).ToString("0") + ",";
            parametrosRadarCorrente += ((lstDesempenhoGlobal2011[4].PontuacaoObtida * 100) / 9).ToString("0") + ",";

            //parametrosRadarAnterior += ((lstDesempenhoGlobal2010[5].PontuacaoObtida * 100) / 16).ToString("0") + ",";
            parametrosRadarCorrente += ((lstDesempenhoGlobal2011[5].PontuacaoObtida * 100) / 16).ToString("0") + ",";

            //parametrosRadarAnterior += ((lstDesempenhoGlobal2010[6].PontuacaoObtida * 100) / 6).ToString("0") + ",";
            parametrosRadarCorrente += ((lstDesempenhoGlobal2011[6].PontuacaoObtida * 100) / 6).ToString("0") + ",";

            //parametrosRadarAnterior += ((lstDesempenhoGlobal2010[7].PontuacaoObtida * 100) / 9).ToString("0") + ",";
            parametrosRadarCorrente += ((lstDesempenhoGlobal2011[7].PontuacaoObtida * 100) / 9).ToString("0") + ",";

            //Retira virgula do final da string
            //parametrosRadarAnterior = parametrosRadarAnterior.Substring(0, parametrosRadarAnterior.Length - 1);
            parametrosRadarCorrente = parametrosRadarCorrente.Substring(0, parametrosRadarCorrente.Length - 1);
            

            //Graficos
            //imgGraficoRadarAnterior.ImageUrl = "../MPE/Paginas/imgGraficoRadar.aspx?valor=" + parametrosRadarAnterior;
            imgGraficoRadarCorrente.ImageUrl = "../MPE/Paginas/imgGraficoRadar.aspx?valor=" + parametrosRadarCorrente;
            

            //Soma total pontuação obtida
            Double TotalPontuacao = lstDesempenhoGlobal2011.Sum<EntDesempenhoGlobal>(PontuacaoObtidas => PontuacaoObtidas.PontuacaoObtida);
            Label lblTotalPontuacaoObtida = ((Label)grdDesempenhoGlobal2011.FooterRow.FindControl("lblTotalPontuacaoObtida"));

            //Total Pontuação
            lblTotalPontuacaoObtida.Text = TotalPontuacao.ToString("0.00") + "%";
        }

        private void GeraQuestionario()
        {
            List<EntPergunta> lstEntPergunta = new BllPergunta().ObterPerguntasQuestionarioDesempenhoGlobal((int)EnumType.Questionario.Gestao);

           
            String html = "";

    //        foreach (EntPergunta objPergunta in lstEntPergunta)
    //        {
    ////             html += "<table bgcolor=\"#FFFFFF\" align=\"left\">";
    //            html += GerarPergunta(objPergunta);
    ////             html += "</table>";
    //            html += "<br/>";
    //        }


            foreach (EntPergunta objPergunta in lstEntPergunta)
            {

                html += "<table style=\"font-size: small\">";
                html += "<tr>";
                html += "<td>";
                html += objPergunta.Ordem;
                html += "       .&nbsp;&nbsp;";
                html += objPergunta.Pergunta;
                html += "</td>";
                html += "</tr>";
                
                foreach (EntPerguntaResposta objPerguntaResposta in objPergunta.ListPerguntaResposta)
                {
                    html += "<tr>";
                    html += "<td>";
                    html += this.OrdemDaResposta(objPerguntaResposta.Ordem);
                    html += "       &nbsp;&nbsp;";
                    html += objPerguntaResposta.PerguntaResposta;
                    html += "</td>";
                    html += "</tr>";

                }

                html += "</table>";
                html += "<br />";

            }

            //foreach (EntPerguntaResposta objPerguntaResposta in objPergunta.ListPerguntaResposta)
            //{
            //    html += "    <tr bgcolor=\"#FFFFFF\">";
            //    html += "       <td style=\"width: 800px; font-size:small\">";
            //    //html += this.OrdemDaResposta(objPerguntaResposta.Ordem);
            //    html += "       &nbsp;&nbsp;";
            //    html += objPerguntaResposta.PerguntaResposta;
            //    html += "       </td>";
            //    html += "    </tr>";
            //}


            this.ltrPerguntas.Text = html;
            

        }

        private String GerarPergunta(EntPergunta objPergunta)
        {
            String html = "";
          //  html += "<table cellspacing=1 cellpadding=3 bgcolor=\"#FFFFFF\" width=100%>";
            html += "    <tr bgcolor=\"#FFFFFF\">";
            html += "       <td style=\"width: 500px; font-size:small\">";
            html += objPergunta.Ordem;
            html += "       .&nbsp;&nbsp;";
            html += objPergunta.Pergunta;
            html += "       </td>";
            html += "    </tr>";

            foreach (EntPerguntaResposta objPerguntaResposta in objPergunta.ListPerguntaResposta)
            {
                html += "    <tr bgcolor=\"#FFFFFF\">";
                html += "       <td style=\"width: 800px; font-size:small\">";
                //html += this.OrdemDaResposta(objPerguntaResposta.Ordem);
                html += "       &nbsp;&nbsp;";
                html += objPerguntaResposta.PerguntaResposta;
                html += "       </td>";
                html += "    </tr>";
            }

            //html += GerarRespostas(objPergunta.ListPerguntaResposta);
      //      html += "    </table>";
            return html;
        }

        private String GerarRespostas(List<EntPerguntaResposta> lstPerguntaRespostas)
        {
            String html = "";
            foreach (EntPerguntaResposta objPerguntaResposta in lstPerguntaRespostas)
            {
                html += GerarResposta(objPerguntaResposta);
            }

            return html;
        }

        private String GerarResposta(EntPerguntaResposta objPerguntaResposta)
        {
            String html = "";
            html += "    <tr> ";
            html += "       <td style=\"width: 300px;\">";
            html += this.OrdemDaResposta(objPerguntaResposta.Ordem);
            html += "       &nbsp;&nbsp;";
            html += objPerguntaResposta.PerguntaResposta;
            html += "       </td>";
            html += "    </tr>";

            return html;
        }

        private String OrdemDaResposta(Int32 ordem)
        {
            String retorno = "";
            switch (ordem)
            {
                case 1:
                    retorno = "a)";
                    break;
                case 2:
                    retorno = "b)";
                    break;
                case 3:
                    retorno = "c)";
                    break;
                case 4:
                    retorno = "d)";
                    break;
                default:
                    break;
            }

            return retorno;
        }
    }
}