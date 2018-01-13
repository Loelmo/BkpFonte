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
    /// Classe de Dados que representa um Relatorio RAA
    /// </summary>
    public class DalRelatorioRAA
    {
        /// <summary>
        /// Retorna um entidade de Relatorio RAA
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntRelatorioRAA">Lista de EntRelatorioRAA</list></returns>
        public List<EntRelatorioRAA> ObterRelatorioPorFiltro(Int32 IdEmpresaCadastro, Int32 IdTurma, Int32 IdPrograma, Boolean? IsAvaliador, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaHistoricoQuestionarioRAAPorFiltro");
            db.AddInParameter(dbCommand, "@nCDA_EMP_CADASTRO", DbType.Int32, IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IdTurma);
            db.AddInParameter(dbCommand, "@bIS_AVALIADOR", DbType.Boolean, (IsAvaliador.HasValue ? IsAvaliador : null));
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
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_EMPREENDEDORISMO", DbType.Int32, (int)EnumType.Questionario.Empreendedorismo);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL", DbType.Int32, (int)EnumType.Questionario.ResponsabilidadeSocial);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_INOVACAO", DbType.Int32, (int)EnumType.Questionario.Inovacao);
            //---------------------------------------------------------------------
            //--------Tipo Etapa--------------
            if (IdPrograma == EntPrograma.PROGRAMA_MPE)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_CANDIDATURA_EMPRESA", DbType.Int32, (int)EnumType.TipoEtapaMpe.InscriçãoCandidaturaEmpresa);
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_CANDIDATURA_ADMINISTRATIVO", DbType.Int32, (int)EnumType.TipoEtapaMpe.InscriçãoCandidaturaAdministrativo);
            }
            else if (IdPrograma == EntPrograma.PROGRAMA_FGA)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_CANDIDATURA_EMPRESA", DbType.Int32, (int)EnumType.TipoEtapaFga.Autodiagnostico);
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_CANDIDATURA_ADMINISTRATIVO", DbType.Int32, (int)EnumType.TipoEtapaFga.AutodiagnosticoAdministrativo);
            }
            else if (IdPrograma == EntPrograma.PROGRAMA_PEG)
            {
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_CANDIDATURA_EMPRESA", DbType.Int32, (int)EnumType.TipoEtapaPeg.Autodiagnostico);
                db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA_CANDIDATURA_ADMINISTRATIVO", DbType.Int32, (int)EnumType.TipoEtapaPeg.AutodiagnosticoAdministrativo);
            }
            //---------------------------------------------------------------------

            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntRelatorioRAA>();
                }
            }
        }

        /// <summary>
        /// Popula Etapa, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntRelatorioRAA">Lista de EntRelatorioRAA</list></returns>
        private List<EntRelatorioRAA> Popular(DbDataReader dtrDados)
        {
            List<EntRelatorioRAA> listEntReturn = new List<EntRelatorioRAA>();
            EntRelatorioRAA entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntRelatorioRAA();

                    entReturn.Ano = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]).Year;
                    entReturn.DataEnvio = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                    entReturn.CriterioCliente = ObjectUtils.ToDouble(dtrDados["CriterioCliente"]);
                    entReturn.CriterioSociedade = ObjectUtils.ToDouble(dtrDados["CriterioSociedade"]);
                    entReturn.CriterioLideranca = ObjectUtils.ToDouble(dtrDados["CriterioLideranca"]);
                    entReturn.CriterioEstrategiaPlano = ObjectUtils.ToDouble(dtrDados["CriterioEstrategiaPlano"]);
                    entReturn.CriterioPessoa = ObjectUtils.ToDouble(dtrDados["CriterioPessoa"]);
                    entReturn.CriterioProcesso = ObjectUtils.ToDouble(dtrDados["CriterioProcesso"]);
                    entReturn.CriterioInformacaoConhecimento = ObjectUtils.ToDouble(dtrDados["CriterioInformacaoConhecimento"]);
                    entReturn.CriterioResultadoControle = ObjectUtils.ToDouble(dtrDados["CriterioResultadoControle"]);
                    entReturn.CriterioResultadoTendencia = ObjectUtils.ToDouble(dtrDados["CriterioResultadoTendencia"]);
                    entReturn.AvaliacaoEmpreendedor = ObjectUtils.ToDouble(dtrDados["AvaliacaoEmpreendedor"]);
                    entReturn.AvaliacaoResponsabilidadeSocial = ObjectUtils.ToDouble(dtrDados["AvaliacaoResponsabilidadeSocial"]);
                    entReturn.AvaliacaoInovacao = ObjectUtils.ToDouble(dtrDados["AvaliacaoInovacao"]);
                    entReturn.TotalGestao = ObjectUtils.ToDouble(dtrDados["TotalGestao"]);
                    entReturn.Avaliador = ObjectUtils.ToBoolean(dtrDados["FL_AVALIADOR"]);
                    entReturn.Protocolo = ObjectUtils.ToString(dtrDados["TX_PROTOCOLO"]);
                    entReturn.Programa = ObjectUtils.ToInt(dtrDados["CDA_PROGRAMA"]);
                    entReturn.TipoEtapa = ObjectUtils.ToInt(dtrDados["CEA_TIPO_ETAPA"]);
                    entReturn.Categoria = ObjectUtils.ToString(dtrDados["TX_CATEGORIA"]);
                    entReturn.AtividadeEconomica = ObjectUtils.ToString(dtrDados["TX_ATIVIDADE_ECONOMICA"]);
                    entReturn.Faturamento = ObjectUtils.ToString(dtrDados["TX_FATURAMENTO"]);
                    entReturn.Bairro = ObjectUtils.ToString(dtrDados["TX_BAIRRO"]);
                    entReturn.Cidade = ObjectUtils.ToString(dtrDados["TX_CIDADE"]);
                    entReturn.Estado = ObjectUtils.ToString(dtrDados["TX_ESTADO"]);
                    entReturn.Cargo = ObjectUtils.ToString(dtrDados["TX_CARGO"]);
                    entReturn.EmailContato = ObjectUtils.ToString(dtrDados["TX_EMAIL_CONTATO"]);

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