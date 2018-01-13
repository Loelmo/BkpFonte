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
    /// Classe de Dados que representa um Questionario Empresa
    /// </summary>
    public class DalQuestionarioEmpresa
    {

        /// <summary>
        /// Retorna um entidade de Questionario Empresa
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        public EntQuestionarioEmpresa ObterPorId(Int32 IdQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioEmpresaPorId");
            db.AddInParameter(dbCommand, "@nIdQuestionarioEmpresa", DbType.Int32, IdQuestionarioEmpresa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Questionario Empresa
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        public String ObterResumoPorId(Int32 IdQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioEmpresaResumoPorId");
            db.AddInParameter(dbCommand, "@nIdQuestionarioEmpresa", DbType.Int32, IdQuestionarioEmpresa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularResumo(dtrDados);
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Questionario Empresa
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        public List<EntQuestionarioEmpresa> ObterPorProtocolo(String Protocolo, DbTransaction transaction, Database db)
        {
            List<EntQuestionarioEmpresa> entReturn = new List<EntQuestionarioEmpresa>();

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioEmpresaPorProtocolo");
            db.AddInParameter(dbCommand, "@sTX_PROTOCOLO", DbType.String, Protocolo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Questionario Empresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        public EntQuestionarioEmpresa ObterQuestionarioAberto(Int32 IdQuestionario, Int32 IdEmpCadastro, Int32 IdTurma, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioEmpresaAbertoPorQuestionarioEmpresaTurma");
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO", DbType.Int32, IdQuestionario);
            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, IdEmpCadastro);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade Questionario Empresa
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        public EntQuestionarioEmpresa ObterQuestionarioEmpresaPorFiltros(EntQuestionarioEmpresa objQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            EntQuestionarioEmpresa entReturn = null;

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioEmpresaPorFiltro");
            db.AddInParameter(dbCommand, "@IdEmpresaCadastro", DbType.Int32, objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@IdQuestionario", DbType.Int32, objQuestionarioEmpresa.Questionario.IdQuestionario);
            db.AddInParameter(dbCommand, "@IdTipoEtapa", DbType.Int32, objQuestionarioEmpresa.Etapa.IdEtapa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {

                    try
                    {
                        while (dtrDados.Read())
                        {
                            entReturn = new EntQuestionarioEmpresa();

                            entReturn.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
                            entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                            entReturn.DtAlteracao = ObjectUtils.ToDate(dtrDados["DT_ALTERACAO"]);
                            entReturn.Questionario.IdQuestionario = ObjectUtils.ToInt(dtrDados["CEA_QUESTIONARIO"]);
                            entReturn.DtCadastro = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                            entReturn.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CEA_EMP_CADASTRO"]);
                            entReturn.Etapa.IdEtapa = ObjectUtils.ToInt(dtrDados["CEA_ETAPA"]);
                            entReturn.Leitura = ObjectUtils.ToBoolean(dtrDados["FL_LEITURA"]);
                            entReturn.MotivoExcluiu = ObjectUtils.ToString(dtrDados["TX_MOTIVO_EXCLUIU"]);
                            entReturn.PreencheQuestionario = ObjectUtils.ToBoolean(dtrDados["FL_PREENCHE_QUESTIONARIO"]);
                            entReturn.MotivoVenceu = ObjectUtils.ToString(dtrDados["TX_MOTIVO_VENCEU"]);
                            entReturn.PassaProximaEtapa = ObjectUtils.ToBoolean(dtrDados["FL_PASSA_PROXIMA_ETAPA"]);
                            entReturn.Programa.IdPrograma = ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]);
                            entReturn.Protocolo = ObjectUtils.ToString(dtrDados["TX_PROTOCOLO"]);
                            entReturn.SincronizadoSiac = ObjectUtils.ToBoolean(dtrDados["FL_SINCRONIZADO_SIAC"]);
                            entReturn.TotalPontuacao = ObjectUtils.ToDecimal(dtrDados["NU_TOTAL_PONTUACAO"]);
                            entReturn.Usuario.IdUsuario = ObjectUtils.ToInt(dtrDados["CEA_USUARIO"]);
                            entReturn.Usuario.IdUsuario = ObjectUtils.ToInt(dtrDados["FL_PARA_AVALIACAO"]);
                            entReturn.Usuario.IdUsuario = ObjectUtils.ToInt(dtrDados["NU_TOTAL_PONTUACAO_AVALIADOR"]);
                        }

                        dtrDados.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }

                return entReturn;
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade Questionario Empresa
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">EntQuestionarioEmpresa</list></returns>
        public EntQuestionarioEmpresa ObterQuestionarioEmpresaRelatorioRAAPorFiltros(EntQuestionarioEmpresa objQuestionarioEmpresa, EntTurma objTurma, DbTransaction transaction, Database db)
        {
            EntQuestionarioEmpresa entReturn = new EntQuestionarioEmpresa();

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioEmpresaRelatorioRAAPorFiltros");
            db.AddInParameter(dbCommand, "@nIdEmpresaCadastro", DbType.Int32, objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nIdQuestionario", DbType.Int32, objQuestionarioEmpresa.Questionario.IdQuestionario);
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, objTurma.IdTurma);

            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    entReturn = this.Popular(dtrDados)[0];
                }
            }

            return entReturn;
        }

        /// <summary>
        /// Retorna um entidade de Questionario Empresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        public void DesabilitaAnteriores(Int32 IdEmpCadastro, Int32 IdEtapa, Int32 IdQuestionario, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_DesabilitaQuestionarioEmpresaPorEmpresaEtapa");
            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, IdEmpCadastro);
            db.AddInParameter(dbCommand, "@nCEA_ETAPA", DbType.Int32, IdEtapa);
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO", DbType.Int32, IdQuestionario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera a coluna de relatorio gerado dos qustionarios
        /// </summary>
        /// <autor>Fernando Carvalho</autor>   
        public void AlterarRelatorioGeradoPorProtocolo(String Protocolo, Boolean RelatorioGerado, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaRelatorioGeradoPorProtocolo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@TX_PROTOCOLO", DbType.String, Protocolo);
            db.AddInParameter(dbCommand, "@FL_RELATORIO_GERADO", DbType.Boolean, RelatorioGerado);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera um Questionario Empresa somente "Flag Leitura"
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objGrupo">Entidade de Questionario Empresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AlterarSomenteFlagLeitura(Int32 IdQuestionarioEmpresa, Boolean Leitura, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaQuestionarioEmpresaSomenteFlagLeitura");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_QUESTIONARIO_EMPRESA", DbType.Int32, IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@bFL_LEITURA", DbType.Boolean, Leitura);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera um Questionario Empresa de Turma
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objGrupo">Entidade de Questionario Empresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void MudarTurma(EntQuestionarioEmpresa objQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaQuestionarioEmpresaMudarTurmaEtapa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_QUESTIONARIO_EMPRESA", DbType.Int32, objQuestionarioEmpresa.IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@nCEA_ETAPA", DbType.Int32, objQuestionarioEmpresa.Etapa.IdEtapa);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera um Questionario Empresa somente "Flag Leitura"
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objGrupo">Entidade de Questionario Empresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AlterarSomenteDesclassificar(EntQuestionarioEmpresa objQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaQuestionarioEmpresaSomenteDesclassificar");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_QUESTIONARIO_EMPRESA", DbType.Int32, objQuestionarioEmpresa.IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@bFL_DESCLASSIFICAR", DbType.Boolean, objQuestionarioEmpresa.Excluido);
            db.AddInParameter(dbCommand, "@sTX_MOTIVO_DESCLASSIFICAR", DbType.String, objQuestionarioEmpresa.MotivoExcluiu);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera um Questionario Empresa somente "Flag Leitura"
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objGrupo">Entidade de Questionario Empresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AlterarSomentePassaProximaEtapa(Int32 IdQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaQuestionarioEmpresaSomentePassaProximaEtapa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_QUESTIONARIO_EMPRESA", DbType.Int32, IdQuestionarioEmpresa);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera um Questionario Empresa somente "Flag Leitura"
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objGrupo">Entidade de Questionario Empresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AlterarSomenteEnviaQuestionario(EntQuestionarioEmpresa objQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaQuestionarioEmpresaSomenteEnviaQuestionario");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_QUESTIONARIO_EMPRESA", DbType.Int32, objQuestionarioEmpresa.IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@bFL_ENVIA_QUESTIONARIO", DbType.Boolean, objQuestionarioEmpresa.EnviaQuestionario);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera um Questionario Empresa somente "Flag Leitura"
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objGrupo">Entidade de Questionario Empresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AlterarSomenteResumo(Int32 IdQuestionarioEmpresa, String Resumo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaQuestionarioEmpresaInsereResumo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_QUESTIONARIO_EMPRESA", DbType.Int32, IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@TX_RESUMO", DbType.String, Resumo);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera um Questionario Empresa somente "Flag Leitura"
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="objGrupo">Entidade de Questionario Empresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AlterarInsereDevolucao(Int32 IdQuestionarioEmpresa, String Resumo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaQuestionarioEmpresaInsereDevolucao");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_QUESTIONARIO_EMPRESA", DbType.Int32, IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@TX_RESUMO", DbType.String, Resumo);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um entidade de Questionario Empresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        public EntQuestionarioEmpresa ObterQuestionarioPorTurmaQuestionarioEmpresa(Int32 IdQuestionario, Int32 IdEmpCadastro, Int32 IdTurma, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioEmpresaPorQuestionarioEmpresaTurma");
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO", DbType.Int32, IdQuestionario);
            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, IdEmpCadastro);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Questionario Empresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        public EntQuestionarioEmpresa ObterQuestionarioPorEtapaQuestionarioEmpresa(Int32 IdQuestionario, Int32 IdEmpCadastro, Int32 IdEtapa, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioEmpresaPorQuestionarioEmpresaEtapa");
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO", DbType.Int32, IdQuestionario);
            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, IdEmpCadastro);
            db.AddInParameter(dbCommand, "@nCEA_ETAPA", DbType.Int32, IdEtapa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return new EntQuestionarioEmpresa();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Questionario Empresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        public List<EntQuestionarioEmpresa> ObterQuestionarioPorTurmaEmpresa(Int32 IdEmpCadastro, Int32 IdTurma, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioEmpresaPorEmpresaTurma");
            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, IdEmpCadastro);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Questionario Empresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        public List<EntQuestionarioEmpresa> ObterQuestionarioEmpresaAtivoPorTurmaEmpresa(Int32 IdEmpCadastro, Int32 IdTurma, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioEmpresaAtivoPorEmpresaTurma");
            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, IdEmpCadastro);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Questionario Empresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        public List<EntQuestionarioEmpresa> ObterQuestionarioEmpresaAtivoPorEmpresaEtapa(Int32 IdEmpCadastro, Int32 IdEtapa, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioEmpresaAtivoPorEmpresaEtapa");
            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, IdEmpCadastro);
            db.AddInParameter(dbCommand, "@nCEA_ETAPA", DbType.Int32, IdEtapa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new  List<EntQuestionarioEmpresa>();
                }
            }
        }




        /// <summary>
        /// Retorna um entidade de Questionario Empresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        public EntQuestionarioEmpresa ObterQuestionarioAtivoPorTurmaQuestionarioEmpresa(Int32 IdQuestionario, Int32 IdEmpCadastro, Int32 IdTurma, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaQuestionarioEmpresaAtivoPorQuestionarioEmpresaTurma");
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO", DbType.Int32, IdQuestionario);
            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, IdEmpCadastro);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Popula Questionario Empresa, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        private List<EntQuestionarioEmpresa> Popular(DbDataReader dtrDados)
        {
            List<EntQuestionarioEmpresa> listEntReturn = new List<EntQuestionarioEmpresa>();
            EntQuestionarioEmpresa entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntQuestionarioEmpresa();

                    entReturn.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.DtAlteracao = ObjectUtils.ToDate(dtrDados["DT_ALTERACAO"]);
                    entReturn.Questionario.IdQuestionario = ObjectUtils.ToInt(dtrDados["CEA_QUESTIONARIO"]);
                    entReturn.DtCadastro = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                    entReturn.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CEA_EMP_CADASTRO"]);
                    entReturn.Etapa.IdEtapa = ObjectUtils.ToInt(dtrDados["CEA_ETAPA"]);
                    entReturn.Leitura = ObjectUtils.ToBoolean(dtrDados["FL_LEITURA"]);
                    entReturn.MotivoExcluiu = ObjectUtils.ToString(dtrDados["TX_MOTIVO_EXCLUIU"]);
                    entReturn.PreencheQuestionario = ObjectUtils.ToBoolean(dtrDados["FL_PREENCHE_QUESTIONARIO"]);
                    entReturn.MotivoVenceu = ObjectUtils.ToString(dtrDados["TX_MOTIVO_VENCEU"]);
                    entReturn.PassaProximaEtapa = ObjectUtils.ToBoolean(dtrDados["FL_PASSA_PROXIMA_ETAPA"]);
                    entReturn.Programa.IdPrograma = ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]);
                    entReturn.Protocolo = ObjectUtils.ToString(dtrDados["TX_PROTOCOLO"]);
                    entReturn.SincronizadoSiac = ObjectUtils.ToBoolean(dtrDados["FL_SINCRONIZADO_SIAC"]);
                    entReturn.TotalPontuacao = ObjectUtils.ToDecimal(dtrDados["NU_TOTAL_PONTUACAO"]);
                    entReturn.Usuario.IdUsuario = ObjectUtils.ToInt(dtrDados["CEA_USUARIO"]);
                    entReturn.EnviaQuestionario = ObjectUtils.ToBoolean(dtrDados["FL_ENVIAR_QUESTIONARIO"]);
                    entReturn.RelatorioGerado = ObjectUtils.ToBoolean(dtrDados["FL_RELATORIO_GERADO"]);
                    
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

        /// <summary>
        /// Popula Questionario Empresa, conforme DataReader passado
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntQuestionarioEmpresa">Lista de EntQuestionarioEmpresa</list></returns>
        private String PopularResumo(DbDataReader dtrDados)
        {
            String res = "";
            try
            {
                if(dtrDados.Read())
                {
                    res = ObjectUtils.ToString(dtrDados["TX_RESUMO"]);
                }

                dtrDados.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }

        /// <summary>
        /// Inclui um registro na tabela
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objCidade">Entidade que representa a tabela Questionario Empresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Cidade</returns>
        public EntQuestionarioEmpresa Inserir(EntQuestionarioEmpresa objQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereQuestionarioEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCEA_QUESTIONARIO_EMPRESA", DbType.Int32, objQuestionarioEmpresa.IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO", DbType.Int32, objQuestionarioEmpresa.Questionario.IdQuestionario);
            db.AddInParameter(dbCommand, "@CEA_EMPRESA_CADASTRO", DbType.Int32, objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@CEA_ETAPA", DbType.Int32, objQuestionarioEmpresa.Etapa.IdEtapa);
            db.AddInParameter(dbCommand, "@CEA_PROGRAMA", DbType.Int32, objQuestionarioEmpresa.Programa.IdPrograma);

            db.AddInParameter(dbCommand, "@FL_LEITURA", DbType.Boolean, objQuestionarioEmpresa.Leitura);
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, objQuestionarioEmpresa.Ativo);
            db.AddInParameter(dbCommand, "@FL_PASSA_PROXIMA_ETAPA", DbType.Boolean, objQuestionarioEmpresa.PassaProximaEtapa);
            db.AddInParameter(dbCommand, "@FL_PREENCHE_QUESTIONARIO", DbType.Boolean, objQuestionarioEmpresa.PreencheQuestionario);
            db.AddInParameter(dbCommand, "@FL_SINCRONIZADO_SIAC", DbType.Boolean, objQuestionarioEmpresa.SincronizadoSiac);
            db.AddInParameter(dbCommand, "@TOTAL_PONTUACAO", DbType.Decimal, objQuestionarioEmpresa.TotalPontuacao);

            if (objQuestionarioEmpresa.DtAlteracao != null && objQuestionarioEmpresa.DtAlteracao.Year > 1990)
                db.AddInParameter(dbCommand, "@DT_ALTERACAO", DbType.DateTime, objQuestionarioEmpresa.DtAlteracao);
            else
                db.AddInParameter(dbCommand, "@DT_ALTERACAO", DbType.DateTime, DBNull.Value);
            if (objQuestionarioEmpresa.DtCadastro != null && objQuestionarioEmpresa.DtCadastro.Year > 1990)
                db.AddInParameter(dbCommand, "@DT_CADASTRO", DbType.DateTime, objQuestionarioEmpresa.DtCadastro);
            else
                db.AddInParameter(dbCommand, "@DT_CADASTRO", DbType.DateTime, DBNull.Value);
            if (objQuestionarioEmpresa.MotivoExcluiu != null)
                db.AddInParameter(dbCommand, "@MOTIVO_EXCLUIU", DbType.String, objQuestionarioEmpresa.MotivoExcluiu);
            else
                db.AddInParameter(dbCommand, "@MOTIVO_EXCLUIU", DbType.String, DBNull.Value);
            if (objQuestionarioEmpresa.MotivoVenceu != null)
                db.AddInParameter(dbCommand, "@MOTIVO_VENCEU", DbType.String, objQuestionarioEmpresa.MotivoVenceu);
            else
                db.AddInParameter(dbCommand, "@MOTIVO_VENCEU", DbType.String, DBNull.Value);
            if (objQuestionarioEmpresa.Protocolo != null && !objQuestionarioEmpresa.Protocolo.Equals(""))
                db.AddInParameter(dbCommand, "@TX_PROTOCOLO", DbType.String, objQuestionarioEmpresa.Protocolo);
            else
                db.AddInParameter(dbCommand, "@TX_PROTOCOLO", DbType.String, DBNull.Value);
            if (objQuestionarioEmpresa.Usuario != null && objQuestionarioEmpresa.Usuario.IdUsuario > 0)
                db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, objQuestionarioEmpresa.Usuario.IdUsuario);
            else
                db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, DBNull.Value);
            db.AddInParameter(dbCommand, "@FL_PARA_AVALIACAO", DbType.Int32, objQuestionarioEmpresa.ParaAvaliador);
            db.AddInParameter(dbCommand, "@FL_ENVIAR_QUESTIONARIO", DbType.Boolean, objQuestionarioEmpresa.EnviaQuestionario);
            db.AddInParameter(dbCommand, "@FL_MARCA_QUESTOES_ESPECIAIS", DbType.Boolean, objQuestionarioEmpresa.MarcaQuestoesEspeciais);
            db.ExecuteNonQuery(dbCommand, transaction);

            objQuestionarioEmpresa.IdQuestionarioEmpresa = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCEA_QUESTIONARIO_EMPRESA"));

            return objQuestionarioEmpresa;
        }

        /// <summary>
        /// Altera uma Resposta
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="objCidade">Entidade da Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntQuestionarioEmpresa objQuestionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaQuestionarioEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO_EMPRESA", DbType.Int32, objQuestionarioEmpresa.IdQuestionarioEmpresa);
            db.AddInParameter(dbCommand, "@nCEA_QUESTIONARIO", DbType.Int32, objQuestionarioEmpresa.Questionario.IdQuestionario);
            db.AddInParameter(dbCommand, "@CEA_EMPRESA_CADASTRO", DbType.Int32, objQuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@CEA_ETAPA", DbType.Int32, objQuestionarioEmpresa.Etapa.IdEtapa);
            db.AddInParameter(dbCommand, "@CEA_PROGRAMA", DbType.Int32, objQuestionarioEmpresa.Programa.IdPrograma);
            db.AddInParameter(dbCommand, "@FL_MARCA_QUESTOES_ESPECIAIS", DbType.Int32, objQuestionarioEmpresa.MarcaQuestoesEspeciais);

            db.AddInParameter(dbCommand, "@FL_LEITURA", DbType.Boolean, objQuestionarioEmpresa.Leitura);
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, objQuestionarioEmpresa.Ativo);
            db.AddInParameter(dbCommand, "@FL_PASSA_PROXIMA_ETAPA", DbType.Boolean, objQuestionarioEmpresa.PassaProximaEtapa);
            db.AddInParameter(dbCommand, "@FL_PREENCHE_QUESTIONARIO", DbType.Boolean, objQuestionarioEmpresa.PreencheQuestionario);
            db.AddInParameter(dbCommand, "@FL_SINCRONIZADO_SIAC", DbType.Boolean, objQuestionarioEmpresa.SincronizadoSiac);
            db.AddInParameter(dbCommand, "@TOTAL_PONTUACAO", DbType.Decimal, objQuestionarioEmpresa.TotalPontuacao);
            db.AddInParameter(dbCommand, "@TOTAL_PONTUACAO_AVALIACAO", DbType.Decimal, objQuestionarioEmpresa.TotalPontuacaoAvaliacao);

            if (objQuestionarioEmpresa.DtAlteracao != null)
                db.AddInParameter(dbCommand, "@DT_ALTERACAO", DbType.DateTime, objQuestionarioEmpresa.DtAlteracao);
            else
                db.AddInParameter(dbCommand, "@DT_ALTERACAO", DbType.DateTime, DBNull.Value);
            if (objQuestionarioEmpresa.DtCadastro != null)
                db.AddInParameter(dbCommand, "@DT_CADASTRO", DbType.DateTime, objQuestionarioEmpresa.DtCadastro);
            else
                db.AddInParameter(dbCommand, "@DT_CADASTRO", DbType.DateTime, DBNull.Value);
            if (objQuestionarioEmpresa.MotivoExcluiu != null)
                db.AddInParameter(dbCommand, "@MOTIVO_EXCLUIU", DbType.String, objQuestionarioEmpresa.MotivoExcluiu);
            else
                db.AddInParameter(dbCommand, "@MOTIVO_EXCLUIU", DbType.String, DBNull.Value);
            if (objQuestionarioEmpresa.MotivoVenceu != null)
                db.AddInParameter(dbCommand, "@MOTIVO_VENCEU", DbType.String, objQuestionarioEmpresa.MotivoVenceu);
            else
                db.AddInParameter(dbCommand, "@MOTIVO_VENCEU", DbType.String, DBNull.Value);
            if (objQuestionarioEmpresa.Protocolo != null && !objQuestionarioEmpresa.Protocolo.Equals(""))
                db.AddInParameter(dbCommand, "@TX_PROTOCOLO", DbType.String, objQuestionarioEmpresa.Protocolo);
            else
                db.AddInParameter(dbCommand, "@TX_PROTOCOLO", DbType.String, DBNull.Value);
            if (objQuestionarioEmpresa.Usuario != null && objQuestionarioEmpresa.Usuario.IdUsuario > 0)
                db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, objQuestionarioEmpresa.Usuario.IdUsuario);
            else
                db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, DBNull.Value);

            db.AddInParameter(dbCommand, "@FL_ENVIAR_QUESTIONARIO", DbType.Boolean, objQuestionarioEmpresa.EnviaQuestionario);

            db.ExecuteNonQuery(dbCommand, transaction);
        }

    }
}
