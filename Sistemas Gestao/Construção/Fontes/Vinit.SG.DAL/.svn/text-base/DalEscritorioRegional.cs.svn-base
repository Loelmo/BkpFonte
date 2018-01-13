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
    /// Classe de Dados que representa um Escritório Regional
    /// </summary>
    public class DalEscritorioRegional
    {
        /// <summary>
        /// Inclui um registro na tabela TBL_ESCRITORIO_REGIONAL
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objEscritorioRegional">Entidade que representa a tabela Escritório Regional</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Escritório Regional</returns>
        public EntEscritorioRegional Inserir(EntEscritorioRegional objEscritorioRegional, DbTransaction transaction, Database db)
        {
            EntEscritorioRegional objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereEscritorioRegional");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_ESCRITORIO_REGIONAL", DbType.Int32, objEscritorioRegional.IdEscritorioRegional);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, objEscritorioRegional.Estado.IdEstado);
            db.AddInParameter(dbCommand, "@sTX_ESCRITORIO_REGIONAL", DbType.String, objEscritorioRegional.EscritorioRegional);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Byte, objEscritorioRegional.Ativo);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objEscritorioRegional.Turma.IdTurma);

            db.ExecuteNonQuery(dbCommand, transaction);

            objEscritorioRegional.IdEscritorioRegional = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_ESCRITORIO_REGIONAL"));

            if (objEscritorioRegional.IdEscritorioRegional != int.MinValue)
                objRetorno = objEscritorioRegional;

            return objRetorno;
        }

        /// <summary>
        /// Altera um Escritório Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objEscritorioRegional">Entidade do Escritório Regional</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntEscritorioRegional objEscritorioRegional, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaEscritorioRegional");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_ESCRITORIO_REGIONAL", DbType.Int32, objEscritorioRegional.IdEscritorioRegional);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, objEscritorioRegional.Estado.IdEstado);
            db.AddInParameter(dbCommand, "@sTX_ESCRITORIO_REGIONAL", DbType.String, objEscritorioRegional.EscritorioRegional);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Byte, objEscritorioRegional.Ativo);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objEscritorioRegional.Turma.IdTurma);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna uma lista de entidade de Escritório Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEscritorioRegional">Lista de EntEscritorioRegional</list></returns>
        public List<EntEscritorioRegional> ObterAtivosPorFiltro(EntEscritorioRegional objEscritorioRegional, Int32 IdUsuario, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEscritorioRegionalAtivoPorFiltro");
            db.AddInParameter(dbCommand, "@sTX_ESCRITORIO_REGIONAL", DbType.String, objEscritorioRegional.EscritorioRegional);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objEscritorioRegional.Estado.IdEstado));
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objEscritorioRegional.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, objEscritorioRegional.Turma.Programa.IdPrograma);
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, objEscritorioRegional.Ativo);
            db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, IdUsuario);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntEscritorioRegional>();
                }
            }
        }

        /// <summary>
        /// Retorna um Boolean
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param> 
        public Boolean ExisteEscritorioRegional(EntEscritorioRegional objEscritorioRegional, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_ExisteEscritorioRegional");
            db.AddInParameter(dbCommand, "@sTX_ESCRITORIO_REGIONAL", DbType.String, objEscritorioRegional.EscritorioRegional);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, objEscritorioRegional.Estado.IdEstado);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objEscritorioRegional.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, objEscritorioRegional.Turma.Programa.IdPrograma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            Int32 count = (Int32)db.ExecuteScalar(dbCommand, transaction);

            return count > 0;
        }

        /// <summary>
        /// Retorna uma lista de entidade de Escritório Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEscritorioRegional">Lista de EntEscritorioRegional</list></returns>
        public EntEscritorioRegional ObterPorId(Int32 nIdEscritorioRegional, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEscritorioRegionalPorId");
            db.AddInParameter(dbCommand, "@nCDA_ESCRITORIO_REGIONAL", DbType.String, nIdEscritorioRegional);
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
        /// Retorna uma lista de entidade de Escritório Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEscritorioRegional">Lista de EntEscritorioRegional</list></returns>
        public List<EntEscritorioRegional> ObterTodosAtivos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEscritorioRegionalAtivo");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntEscritorioRegional>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de Escritório Regional
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEscritorioRegional">Lista de EntEscritorioRegional</list></returns>
        public List<EntEscritorioRegional> ObterPorIdTurmaEstado(Int32 IdTurma, Int32 IdEstado, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEscritorioRegionalPorIdTurmaEstado");
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.String, IdTurma);
            db.AddInParameter(dbCommand, "@nIdEstado", DbType.String, IdEstado);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntEscritorioRegional>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de Escritório Regional
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEscritorioRegional">Lista de EntEscritorioRegional</list></returns>
        public List<EntEscritoriosRegionaisPermitidos> ObterEscritoriosRegeionaisPermitidos(Int32 IdUsuario, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEscritoriosRegeionaisPermitidos");
            db.AddInParameter(dbCommand, "@nIdUsuario", DbType.String, IdUsuario);
            db.AddInParameter(dbCommand, "@nIdPrograma", DbType.String, IdPrograma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularCustom(dtrDados);
                }
                else
                {
                    return new List<EntEscritoriosRegionaisPermitidos>();
                }
            }
        }

        /// <summary>
        /// Popula Escritório Regional, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntEscritorioRegional">Lista de EntEscritorioRegional</list></returns>
        private List<EntEscritorioRegional> Popular(DbDataReader dtrDados)
        {
            List<EntEscritorioRegional> listEntReturn = new List<EntEscritorioRegional>();
            EntEscritorioRegional entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntEscritorioRegional();

                    entReturn.IdEscritorioRegional = ObjectUtils.ToInt(dtrDados["CDA_ESCRITORIO_REGIONAL"]);
                    entReturn.Estado = new EntEstado();
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.EscritorioRegional = ObjectUtils.ToString(dtrDados["TX_ESCRITORIO_REGIONAL"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.Turma = new EntTurma();
                    entReturn.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                    try
                    {
                        entReturn.Turma.Turma = ObjectUtils.ToString(dtrDados["TX_TURMA"]);
                    }
                    catch { }
                    try
                    {
                        entReturn.Estado.Estado = ObjectUtils.ToString(dtrDados["TX_ESTADO"]);
                    }
                    catch { }

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
        /// Popula Escritório Regional, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntEscritorioRegional">Lista de EntEscritorioRegional</list></returns>
        private List<EntEscritoriosRegionaisPermitidos> PopularCustom(DbDataReader dtrDados)
        {
            List<EntEscritoriosRegionaisPermitidos> listEntReturn = new List<EntEscritoriosRegionaisPermitidos>();
            EntEscritoriosRegionaisPermitidos entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntEscritoriosRegionaisPermitidos();

                    entReturn.IdEscritorioRegional = ObjectUtils.ToInt(dtrDados["CDA_ESCRITORIO_REGIONAL"]);
                    entReturn.Estado = new EntEstado();
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.EscritorioRegional = ObjectUtils.ToString(dtrDados["TX_ESCRITORIO_REGIONAL"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.Turma = new EntTurma();
                    entReturn.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                    entReturn.Funcionalidade = ObjectUtils.ToString(dtrDados["TX_FUNCIONALIDADE"]);

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
        /// Excluir um Escritório Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objEscritorioRegional">Entidade do Escritório Regional</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Excluir(int nIdEscritorioRegional, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_ExcluirEscritorioRegional");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_ESCRITORIO_REGIONAL", DbType.Int32, nIdEscritorioRegional);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

    }
}
