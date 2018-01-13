using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.Ent;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Vinit.SG.Common;
using System.Data;

namespace Vinit.SG.DAL
{
    /// <summary>
    /// Classe de Dados que representa um Relatorio de Ranking
    /// </summary>
    public class DalRanking
    {
        /// <summary>
        /// Retorna um entidade de Ranking
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntRanking">Lista de EntRanking</list></returns>
        public List<EntRankingClassificada> RankingClassificadasEstadualSimplificadoPorTipoEtapaFiltros(EntQuestionarioEmpresa objQuestionarioEmpresa, EntTurmaEmpresa objTurmaEmpresa, Int32 nIdGrupo, Int32 nIdEscritorioRegional, Int32 nIdEstadoRegiao, DateTime dDataInicio, DateTime dDataFim, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_RankingEstadualPorTipoEtapaFiltros");

            db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, objQuestionarioEmpresa.Etapa.TipoEtapa.IdTipoEtapa);
            db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_FINAL", DbType.Int32, EnumType.TipoEtapaMpe.JulgamentoFinalistasEstaduais);
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objTurmaEmpresa.Turma.IdTurma);
            //----------CRITERIOS GESTÃO-------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_CLIENTE", DbType.Int32, (int)EnumType.CriteriosGestao.Cliente);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_SOCIEDADE", DbType.Int32, (int)EnumType.CriteriosGestao.Sociedade);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_LIDERANCA", DbType.Int32, (int)EnumType.CriteriosGestao.Lideranca);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_ESTRATEGIA_PLANO", DbType.Int32, (int)EnumType.CriteriosGestao.EstrategiaPlano);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PESSOAS", DbType.Int32, (int)EnumType.CriteriosGestao.Pessoas);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_PROCESSOS", DbType.Int32, (int)EnumType.CriteriosGestao.Processos);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_INFORMACAO_CONHECIMENTO", DbType.Int32, (int)EnumType.CriteriosGestao.InformacaoConhecimento);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_CONTROLE", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoControle);
            db.AddInParameter(dbCommand, "@CEA_CRITERIO_RESULTADO_TENDENCIA", DbType.Int32, (int)EnumType.CriteriosGestao.ResultadoTendencia);
            //---------------------------------------------------------------------
            //-------QUESTIONARIOS-------------------------------------------------
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_GESTAO", DbType.Int32, (int)EnumType.Questionario.Gestao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_INOVACAO", DbType.Int32, (int)EnumType.Questionario.Inovacao);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_EMPREENDEDORISMO", DbType.Int32, (int)EnumType.Questionario.Empreendedorismo);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL", DbType.Int32, (int)EnumType.Questionario.ResponsabilidadeSocial);
            //--------FILTROS DE TELA----------------------------------------------
            db.AddInParameter(dbCommand, "@sNOME_FANTASIA", DbType.String, objTurmaEmpresa.EmpresaCadastro.NomeFantasia);
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Estado.IdEstado));
            db.AddInParameter(dbCommand, "@CEA_CATEGORIA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Categoria.IdCategoria));
            db.AddInParameter(dbCommand, "@CEA_NIVEL_ESCOLARIDADE", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.ContatoNivelEscolaridade.IdContatoNivelEscolaridade));
            db.AddInParameter(dbCommand, "@CEA_FAIXA_ETARIA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.FaixaEtaria.IdContatoFaixaEtaria));
            db.AddInParameter(dbCommand, "@CEA_CIDADE", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Cidade.IdCidade));
            db.AddInParameter(dbCommand, "@CEA_ESCRITORIO_REGIONAL", DbType.Int32, IntUtils.ToIntNull(nIdEscritorioRegional));
            db.AddInParameter(dbCommand, "@STATUS", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Status));
            db.AddInParameter(dbCommand, "@CEA_GRUPO", DbType.Int32, IntUtils.ToIntNull(nIdGrupo));
            db.AddInParameter(dbCommand, "@CEA_FATURAMENTO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Faturamento.IdFaturamento));
            db.AddInParameter(dbCommand, "@PROTOCOLO", DbType.String, objQuestionarioEmpresa.Protocolo);
            db.AddInParameter(dbCommand, "@CPF_CNPJ", DbType.String, objTurmaEmpresa.EmpresaCadastro.CPF_CNPJ);
            db.AddInParameter(dbCommand, "@CEA_ESTADO_REGIAO", DbType.Int32, IntUtils.ToIntNull(nIdEstadoRegiao));
            db.AddInParameter(dbCommand, "@TX_SEXO_CONTATO", DbType.String, objTurmaEmpresa.SexoContato == "" ? null : objTurmaEmpresa.SexoContato);
            db.AddInParameter(dbCommand, "@DATAINICIO", DbType.DateTime, dDataInicio);
            db.AddInParameter(dbCommand, "@DATAFIM", DbType.DateTime, dDataFim);
            db.AddInParameter(dbCommand, "@NU_FUNCIONARIOS", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.NumeroFuncionario));
            db.AddInParameter(dbCommand, "@TIPO_EMPRESA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.TipoEmpresa.IdTipoEmpresa));
            //-------------------------------------------------------------------


            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularRowSimplificadoClassificadaEstadual(dtrDados);
                }
                else
                {
                    return new List<EntRankingClassificada>();
                }
            }
        }

        /// <summary>
        /// Popula Etapa, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntRanking">Lista de EntRanking</list></returns>
        private List<EntRankingClassificada> PopularRowSimplificadoClassificadaEstadual(DbDataReader dtrDados)
        {
            List<EntRankingClassificada> listEntReturn = new List<EntRankingClassificada>();
            EntRankingClassificada entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntRankingClassificada();

                    entReturn.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO"]);
                    entReturn.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
                    entReturn.CpfCnpj = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                    entReturn.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL"]);
                    entReturn.PontuacaoTotalPosVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPosVisita"]);
                    entReturn.EnfoquePosVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePosVisita"]);
                    entReturn.ResultadoControlePosVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePosVisita"]);
                    entReturn.ResultadoTendenciaPosVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPosVisita"]);
                    entReturn.TotalEmpreendendorismoPosVisita = ObjectUtils.ToDouble(dtrDados["TotalEmpreendedorismoPosVisita"]);
                    entReturn.RelacaoMelhorCategoriaPosVisita = ObjectUtils.ToDouble(dtrDados["RelacaoComMelhorDaCategoriaPosVisita"]);
                    entReturn.PontuacaoRankingPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoRankingPreVisita"]);
                    entReturn.EnfoquePreVisita = ObjectUtils.ToDouble(dtrDados["TotalEnfoquePreVisita"]);
                    entReturn.ResultadoControlePreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoControlePreVisita"]);
                    entReturn.ResultadoTendenciaPreVisita = ObjectUtils.ToDouble(dtrDados["ResultadoTendenciaPreVisita"]);
                    entReturn.PontuacaoTotalPreVisita = ObjectUtils.ToDouble(dtrDados["PontuacaoTotalPreVisita"]);
                    entReturn.RelacaoMelhorCategoriaPreVisita = ObjectUtils.ToDouble(dtrDados["RelacaoComMelhorDaCategoriaPreVisita"]);
                    entReturn.PossuiResponsabilidadeSocial = ObjectUtils.ToBoolean(dtrDados["PossuiResponsabilidadeSocial"]);
                    entReturn.PossuiInovacao = ObjectUtils.ToBoolean(dtrDados["PossuiInovacao"]);
                    entReturn.Finalista = ObjectUtils.ToBoolean(dtrDados["Finalista"]);
                    entReturn.FinalistaResponsabilidadeSocial = ObjectUtils.ToBoolean(dtrDados["FinalistaResponsabilidadeSocial"]);
                    entReturn.FinalistaInovacao = ObjectUtils.ToBoolean(dtrDados["FinalistaInovacao"]);

                    listEntReturn.Add(entReturn);
                }

                dtrDados.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listEntReturn;
        }
    }
}