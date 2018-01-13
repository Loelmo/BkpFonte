using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vinit.SG.Common;
using Vinit.SG.Ent;
using Vinit.SG.BLL;
using System.Web.UI.HtmlControls;
using Sistema_de_Gestao.Utilitarios;

namespace Sistema_de_Gestao.FGA.Paginas
{
    public partial class PaginaRelatorio : System.Web.UI.Page
    {
        //String link = caminhoPaginaRelatorio + "?CDA_EMP_CADASTRO=" + cdaEmpCadastro + "&TX_CPF_CNPJ=" + cpfCnpj + "&Chave=" + chave + "&Avaliador=" + avaliador + "&Intro=" + intro + "&CEA_QUESTIONARIO_EMPRESA=" + cdaQuestionarioEmpresa + "&" + protocolo + "&programaId=" + programaId;

        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 IdQuestionarioEmpresa = StringUtils.ToInt(Request["CEA_QUESTIONARIO_EMPRESA"]);
            Int32 IdEmpresaCadastro = StringUtils.ToInt(Request["CDA_EMP_CADASTRO"]);
            Boolean IsAvaliador = StringUtils.ToBoolean(Request["Avaliador"]);
            Int32 IdTurma = StringUtils.ToInt(Request["turmaId"]);
            Int32 IdPrograma = StringUtils.ToInt(Request["programaId"]);
            Int32 nIntro = StringUtils.ToInt(Request["Intro"]);
            DadosDaEmpresa(IdEmpresaCadastro, IdPrograma);
            GeraQuestionario(IdQuestionarioEmpresa, IsAvaliador);
            
            GerarGraficoRadar(IdQuestionarioEmpresa, IsAvaliador);
            GerarGraficoLinha(IdQuestionarioEmpresa, IdEmpresaCadastro, IdTurma, IsAvaliador);

            comentariosAvaliador.Visible = false;
            coluna1Fase4.Visible = false;
            coluna2Fase4.Visible = false;
            coluna3Fase4.Visible = false;

            if (IsAvaliador)
            {
                imgAA.Visible = false;
                imgA.Visible = true;
                introTxt.Visible = false;
                comentariosAvaliador.Visible = true;
                ComentarioDoAvaliador(IdQuestionarioEmpresa);
            }
            else
            {
                imgAA.Visible = true;
                imgA.Visible = false;
            }

            if (nIntro == 0)
            {
/*                imgIntro.Visible = false;
                introTxt.Visible = false;
                introTxt2.Visible = false;
                txtRadar.Visible = false;*/
            }
        }

        private void GerarGraficoLinha(Int32 IdQuestionarioEmpresa, Int32 IdTurma, Int32 IdQuestionario, Boolean IsAvaliador)
        {
            //Consulta Pontuação para componente gráfico   
            List<EntQuestionarioPontuacao> listQuestionarioPontuacao = new List<EntQuestionarioPontuacao>();
            //listQuestionarioPontuacao = new BllQuestionarioPontuacao().ObterPorQuestionario(IdQuestionarioEmpresa, IdTurma, (Int32)EnumType.Questionario.Empreendedorismo, IsAvaliador);
            listQuestionarioPontuacao = new BllQuestionarioPontuacao().ObterPorQuestionarioEmpresa(IdQuestionarioEmpresa, IsAvaliador);

            if (listQuestionarioPontuacao != null)
            {
                //Parâmetros para componente gráfico
                string[,] valorXY1 = new string[listQuestionarioPontuacao.Count, 3];
                Int32 row = 0;

                //Atribui valores para parâmetros do componente gráfico
                foreach (EntQuestionarioPontuacao objQuestionarioPontuacao in listQuestionarioPontuacao)
                {
                    valorXY1[row, 0] = Convert.ToDouble((Convert.ToDecimal(objQuestionarioPontuacao.Ponto))).ToString();
                    valorXY1[row, 1] = ((Convert.ToDecimal(objQuestionarioPontuacao.Ponto))).ToString("N1") + "%";
                    valorXY1[row, 2] = (row + 1).ToString();

                    row += 1;
                }
            }
        }

        private void GerarGraficoRadar(Int32 IdQuestionarioEmpresa, Boolean IsAvaliador)
        {
            //Consulta Pontuação para componente gráfico
            List<EntQuestionarioPontuacao> listQuestionarioPontuacao = new List<EntQuestionarioPontuacao>();
            listQuestionarioPontuacao = new BllQuestionarioPontuacao().ObterPorQuestionarioEmpresa(IdQuestionarioEmpresa, IsAvaliador);
            
            //Soma total pontuação obtida
            decimal TotalPontuacao = listQuestionarioPontuacao.Sum<EntQuestionarioPontuacao>(Pontos => Pontos.Ponto);
            string parametrosRadarCorrente = "", parametrosRadarAnterior = "";

            //Parametros para componente gráfico
            foreach (EntQuestionarioPontuacao objQuestionarioPontuacao in listQuestionarioPontuacao)
            {
                switch ((EnumType.CriteriosGestao)objQuestionarioPontuacao.Criterio.IdCriterio)
                {
                    case EnumType.CriteriosGestao.Cliente:

                        parametrosRadarCorrente += ((objQuestionarioPontuacao.Ponto * 100) / 9).ToString("0") + ",";
                        parametrosRadarAnterior += ((objQuestionarioPontuacao.Criterio.QuestionarioGestaoPontuacaoAnterior * 100) / 9).ToString("0") + ",";

                        break;
                    case EnumType.CriteriosGestao.Sociedade:

                        parametrosRadarCorrente += ((objQuestionarioPontuacao.Ponto * 100) / 6).ToString("0") + ",";
                        parametrosRadarAnterior += ((objQuestionarioPontuacao.Criterio.QuestionarioGestaoPontuacaoAnterior * 100) / 6).ToString("0") + ",";

                        break;
                    case EnumType.CriteriosGestao.Lideranca:

                        parametrosRadarCorrente += ((objQuestionarioPontuacao.Ponto * 100) / 15).ToString("0") + ",";
                        parametrosRadarAnterior += ((objQuestionarioPontuacao.Criterio.QuestionarioGestaoPontuacaoAnterior * 100) / 15).ToString("0") + ",";

                        break;
                    case EnumType.CriteriosGestao.EstrategiaPlano:

                        parametrosRadarCorrente += ((objQuestionarioPontuacao.Ponto * 100) / 9).ToString("0") + ",";
                        parametrosRadarAnterior += ((objQuestionarioPontuacao.Criterio.QuestionarioGestaoPontuacaoAnterior * 100) / 9).ToString("0") + ",";

                        break;
                    case EnumType.CriteriosGestao.Pessoas:

                        parametrosRadarCorrente += ((objQuestionarioPontuacao.Ponto * 100) / 9).ToString("0") + ",";
                        parametrosRadarAnterior += ((objQuestionarioPontuacao.Criterio.QuestionarioGestaoPontuacaoAnterior * 100) / 9).ToString("0") + ",";

                        break;
                    case EnumType.CriteriosGestao.Processos:

                        parametrosRadarCorrente += ((objQuestionarioPontuacao.Ponto * 100) / 16).ToString("0") + ",";
                        parametrosRadarAnterior += ((objQuestionarioPontuacao.Criterio.QuestionarioGestaoPontuacaoAnterior * 100) / 16).ToString("0") + ",";

                        break;
                    case EnumType.CriteriosGestao.InformacaoConhecimento:

                        parametrosRadarCorrente += ((objQuestionarioPontuacao.Ponto * 100) / 6).ToString("0") + ",";
                        parametrosRadarAnterior += ((objQuestionarioPontuacao.Criterio.QuestionarioGestaoPontuacaoAnterior * 100) / 6).ToString("0") + ",";

                        break;
                    case EnumType.CriteriosGestao.ResultadoControle:

                        parametrosRadarCorrente += ((objQuestionarioPontuacao.Ponto * 100) / 9).ToString("0") + ",";
                        parametrosRadarAnterior += ((objQuestionarioPontuacao.Criterio.QuestionarioGestaoPontuacaoAnterior * 100) / 9).ToString("0") + ",";

                        break;
                    case EnumType.CriteriosGestao.ResultadoTendencia:

                        parametrosRadarCorrente += ((objQuestionarioPontuacao.Ponto * 100) / 21).ToString("0") + ",";
                        parametrosRadarAnterior += ((objQuestionarioPontuacao.Criterio.QuestionarioGestaoPontuacaoAnterior * 100) / 21).ToString("0") + ",";

                        break;
                    default:
                        break;
                }

            }

            //Retira virgula do final da string
            parametrosRadarCorrente = parametrosRadarCorrente.Substring(0, parametrosRadarCorrente.Length - 1);
            parametrosRadarAnterior = parametrosRadarAnterior.Substring(0, parametrosRadarAnterior.Length - 1);

            //Graficos
            imgGraficoRadarInicial.ImageUrl = "~/FGA/Paginas/imgGraficoRadar.aspx?valor=" + parametrosRadarCorrente;
            imgGraficoRadarFinal.ImageUrl = "~/FGA/Paginas/imgGraficoRadar.aspx?valor=" + parametrosRadarAnterior;

            //Lista Critérios X Pontuação Corrente/Pontuação Anterior
            grdDesempenhoEmpresaGestao.DataSource = listQuestionarioPontuacao;
            grdDesempenhoEmpresaGestao.DataBind();

            Label lblTotalPontuacaoObtida = ((Label)grdDesempenhoEmpresaGestao.FooterRow.FindControl("lblTotalPontuacaoObtida"));

            //Total Pontuação
            lblTotalPontuacaoObtida.Text = TotalPontuacao.ToString("0.00") + "%";
        }

        private void DadosDaEmpresa(Int32 IdEmpresaCadastro, Int32 IdPrograma)
        {
            EntEmpresaCadastro objEmpresaCadastro = new BllEmpresaCadastro().ObterPorId(IdEmpresaCadastro);
            EntTurmaEmpresa objTurmaEmpresa = new BllTurmaEmpresa().ObterPorIdEmpresaIdPrograma(objEmpresaCadastro.IdEmpresaCadastro, IdPrograma);
            objTurmaEmpresa.AtividadeEconomica = new BllAtividadeEconomica().ObterPorId(objTurmaEmpresa.AtividadeEconomica.IdAtividadeEconomica);

            this.lblRazaoSocial.Text = objEmpresaCadastro.RazaoSocial;
            this.lblNomeFantasia.Text = objEmpresaCadastro.NomeFantasia;
            this.lblCategoria.Text = objTurmaEmpresa.Categoria.Categoria;
            this.lblCNAE.Text = objTurmaEmpresa.AtividadeEconomica.Codigo + " - " + objTurmaEmpresa.AtividadeEconomica.AtividadeEconomica;
            this.lblAtividadeEconomicaTxt.Text = objTurmaEmpresa.AtividadeEconomicaComplemento;
            this.lblCPFCNPJ.Text = FormatUtils.FormataCNPJ_CPF(objEmpresaCadastro.CPF_CNPJ);
            this.lblFaturamento.Text = objTurmaEmpresa.Faturamento.Faturamento;
            this.lblEmpregados.Text = IntUtils.ToString(objTurmaEmpresa.NumeroFuncionario);
            this.lblDataAbertura.Text = objEmpresaCadastro.AberturaEmpresa.ToShortDateString();
            this.lblBairro.Text = objTurmaEmpresa.Bairro.Bairro;
            this.lblEndereco.Text = objTurmaEmpresa.Endereco;
            this.lblCEP.Text = FormatUtils.FormatCEP(objTurmaEmpresa.CEP);
            this.lblCidade.Text = objTurmaEmpresa.Cidade.Cidade;
            this.lblEstado.Text = objTurmaEmpresa.Estado.Estado;
            this.lblContatoNome.Text = objTurmaEmpresa.NomeContato;
            this.lblContatoCargo.Text = objTurmaEmpresa.Cargo.Cargo;
            this.lblContatoTelefone.Text = FormatUtils.FormatTelefone(objTurmaEmpresa.TelefoneContato);
            this.lblContatoCelular.Text = FormatUtils.FormatTelefone(objTurmaEmpresa.CelularContato);
            this.lblContatoEmail.Text = objTurmaEmpresa.EmailContato;
        }

        private void GeraQuestionario(Int32 IdQuestionarioEmpresa, Boolean IsAvaliador)
        {
            List<EntPergunta> lstEntPergunta = new BllPergunta().ObterPerguntasPorQuestionarioEmpresa((int)EnumType.Questionario.Gestao, IdQuestionarioEmpresa, IsAvaliador);

            this.UCRelatorioPerguntaCliente1.GerarPerguntas(lstEntPergunta.FindAll(delegate(EntPergunta objPergunta) { return objPergunta.Criterio.IdCriterio == (int)EnumType.CriteriosGestao.Cliente; }), EnumType.Questionario.Gestao);
            this.UCRelatorioPerguntaSociedade1.GerarPerguntas(lstEntPergunta.FindAll(delegate(EntPergunta objPergunta) { return objPergunta.Criterio.IdCriterio == (int)EnumType.CriteriosGestao.Sociedade; }), EnumType.Questionario.Gestao);
            this.UCRelatorioPerguntaLideranca1.GerarPerguntas(lstEntPergunta.FindAll(delegate(EntPergunta objPergunta) { return objPergunta.Criterio.IdCriterio == (int)EnumType.CriteriosGestao.Lideranca; }), EnumType.Questionario.Gestao);
            this.UCRelatorioPerguntaEstrategia1.GerarPerguntas(lstEntPergunta.FindAll(delegate(EntPergunta objPergunta) { return objPergunta.Criterio.IdCriterio == (int)EnumType.CriteriosGestao.EstrategiaPlano; }), EnumType.Questionario.Gestao);
            this.UCRelatorioPerguntaPessoas1.GerarPerguntas(lstEntPergunta.FindAll(delegate(EntPergunta objPergunta) { return objPergunta.Criterio.IdCriterio == (int)EnumType.CriteriosGestao.Pessoas; }), EnumType.Questionario.Gestao);
            this.UCRelatorioPerguntaProcessos1.GerarPerguntas(lstEntPergunta.FindAll(delegate(EntPergunta objPergunta) { return objPergunta.Criterio.IdCriterio == (int)EnumType.CriteriosGestao.Processos; }), EnumType.Questionario.Gestao);
            this.UCRelatorioPerguntaInformacaoConhecimento1.GerarPerguntas(lstEntPergunta.FindAll(delegate(EntPergunta objPergunta) { return objPergunta.Criterio.IdCriterio == (int)EnumType.CriteriosGestao.InformacaoConhecimento; }), EnumType.Questionario.Gestao);
            this.UCRelatorioPerguntaResultado1.GerarPerguntas(lstEntPergunta.FindAll(delegate(EntPergunta objPergunta) { return objPergunta.Criterio.IdCriterio == (int)EnumType.CriteriosGestao.ResultadoControle; }), EnumType.Questionario.Gestao);

            this.MontarTabela(lstEntPergunta);

        }

        public void MontarTabela(List<EntPergunta> lista)
        {
            for (int i = 0; i < 37; i++)
            {
                if (lista[i].PerguntaTipo.IdPerguntaTipo == EntPerguntaTipo.PERGUNTA_TIPO_ESPECIAL_32_QUESTIONARIO_GESTAO_2011)
                {
                    if (this.FindControl("tx1_" + (i + 1)) != null)
                    {
                        ((TextBox)this.FindControl("tx1_" + (i + 1))).Text = lista[i].QuestionarioEmpresaResposta.Valor01;
                        ((TextBox)this.FindControl("tx2_" + (i + 1))).Text = lista[i].QuestionarioEmpresaResposta.Valor02;
                        ((TextBox)this.FindControl("tx3_" + (i + 1))).Text = lista[i].QuestionarioEmpresaResposta.Valor03;
                    }
                }
            }
        }

        private String VerificaPerguntaRespondida(EntPerguntaResposta objPerguntaResposta, EntPergunta objPergunta)
        {
            String style = "";
            if (objPergunta.QuestionarioEmpresaResposta.Resposta.IdPerguntaResposta == objPerguntaResposta.IdPerguntaResposta)
            {
                style = " style=\"background-color: red;\" ";
            }
            return style;
        }

        private void ComentarioDoAvaliador(Int32 IdQuestionarioEmpresa)
        {
            List<EntQuestionarioEmpresaAvaliador> objQuestionarioEmpresaAvaliador = new BllQuestionarioEmpresaAvaliador().ObterPorIdQuestionarioEmpresa(IdQuestionarioEmpresa);
            if (objQuestionarioEmpresaAvaliador != null && objQuestionarioEmpresaAvaliador.Count > 0)
            {
                this.comentarioAvaliador.Text = objQuestionarioEmpresaAvaliador[0].Banca;
            }
        }
    }
}