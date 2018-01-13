using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PEG.Pagina_Base;
using Vinit.SG.BLL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
//using PEG.SiacWebCadastroAtendimentoWS;
using System.Data;
using System.IO;
//using PEG.SiacWebCadastroAtendimentoWS.ws;
//using PEG.SiacWebCadastroHistoricoWS.ws;
using PEG.SiacWebCadastroAtendimentoWS.ws;


namespace PEG.Paginas
{
    public partial class Importacao : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void Importa(Int32 programaId)
        {
            //busca dados de programa para cada estado
            List<EntEstado> listEstados = new BllEstado().ObterTodos();
            foreach (EntEstado estado in listEstados)
            {
                ProcessaDadosEstado(programaId, estado.IdEstado, estado.Sigla);
            }

        }

        private void ProcessaDadosEstado(Int32 programaId, Int32 estadoId, String estado)
        {
            //Importa dados de cada empresa (empresa ativa na turma
            new BllAuxiliar().ObterTodasInscritasPorEstado(estado, programaId);
        }

        protected void Label6_Click(object sender, EventArgs e)
        {
            int programaId = int.Parse(TxtBoxPrograma.Text);
            this.Importa(programaId);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String teste = new SiacWEB_CadastroAtenderWS().Util_Rec_Estados();
            new BllIntegracaoSiac().ObterEstadosSiac(teste);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (EntEstado estado in new BllEstado().ObterTodos())
            {
                String teste = new SiacWEB_CadastroAtenderWS().Util_Rec_MunicipiosPorEstado(estado.CodSiacweb);
                new BllIntegracaoSiac().ObterCidadesSiac(teste, estado.IdEstado);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            foreach (EntCidade cidade in new BllCidade().ObterTodos())
            {
                if (cidade.CodSiacweb > 0)
                {
                    String teste = new SiacWEB_CadastroAtenderWS().Util_Rec_BairrosPorMunicipio(cidade.CodSiacweb);
                    new BllIntegracaoSiac().ObterBairrosSiac(teste, cidade.IdCidade);
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String teste = new SiacWEB_CadastroAtenderWS().Util_Rec_AtividadesEconomicas("");
            new BllIntegracaoSiac().ObterAtividadesEconomicasSiac(teste);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            new BllIntegracaoSiac().ObterCargosSiac();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            new BllIntegracaoSiac().ObterEscolaridadesSiac();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            new BllIntegracaoSiac().ObterFaturamentosSiac();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            new BllIntegracaoSiac().ObterPortesSiac();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            new BllIntegracaoSiac().ObterSetoresSiac();
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            String teste = new SiacWEB_CadastroAtenderWS().Util_Rec_TiposDeEmpresa();
            new BllIntegracaoSiac().ObterTiposEmpresasSiac(teste);
        }

        protected void InserirCadastroSiac(object sender, EventArgs e)
        {
//            new SiacWEB_HistoricoWS().Trans_Ins_HistoricoRealizacaoCliente(codigoCliente, codEMpreendimento, dataInicio, dataFim, NomeRealizacao,
//                CodRealizacao, CodRealizacaoComp, TipoRealizacao, Instrumento, Abordagem, DescRealizacao, CodProjeto, CodAcao, MesAnoCompetencia,
//                CargaHoraria, CodSebrae);
            new SiacWEB_CadastroAtenderWS().Trans_Ins_CadastroCompletoPF("");
            new SiacWEB_CadastroAtenderWS().Trans_Ins_CadastroCompletoPJ("");
            new SiacWEB_CadastroAtenderWS().Trans_Ins_CadastroCompletoPJ_InformalFormal("");
            String teste = new SiacWEB_CadastroAtenderWS().Util_Rec_Estados();
            new BllIntegracaoSiac().ObterEstadosSiac(teste);
        }

    }
}