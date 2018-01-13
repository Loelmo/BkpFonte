using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.Ent;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using Vinit.SG.Common;

namespace Vinit.SG.DAL
{
    /// <summary>
    /// Classe de Dados que representa um Tipo Empresa
    /// </summary>
    public class DalTipoEmpresa
    {
        /// <summary>
        /// Retorna um entidade de Tipo Empresa
        /// </summary>
        /// <autor>Fernando Carvalo</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTipoEmpresa">Lista de EntTipoEmpresa</list></returns>
        public EntTipoEmpresa ObterPorId(Int32 IdTipoEmpresa, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTipoEmpresaPorId");
            db.AddInParameter(dbCommand, "@nIdTipoEmpresa", DbType.String, IdTipoEmpresa);
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
        /// Retorna um entidade de Tipo Empresa
        /// </summary>
        /// <autor>Fernando Carvalo</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTipoEmpresa">Lista de EntTipoEmpresa</list></returns>
        public EntTipoEmpresa ObterPorNome(String NomeTipoEmpresa, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTipoEmpresaPorNome");
            db.AddInParameter(dbCommand, "@sTipoEmpresa", DbType.String, NomeTipoEmpresa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularComSiac(dtrDados)[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Tipo Empresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTipoEmpresa">Lista de EntTipoEmpresa</list></returns>
        public List<EntTipoEmpresa> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTipoEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntTipoEmpresa>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Tipo Empresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTipoEmpresa">Lista de EntTipoEmpresa</list></returns>
        public List<EntTipoEmpresa> ObterTodosFga(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTipoEmpresaFga");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntTipoEmpresa>();
                }
            }
        }

        /// <summary>
        /// Inclui um registro na tabela TBL_CIDADE
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade que representa a tabela Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Cidade</returns>
        public EntTipoEmpresa Inserir(EntTipoEmpresa objTipoEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereTipoEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_TIPO_EMPRESA", DbType.Int32, objTipoEmpresa.IdTipoEmpresa);
            db.AddInParameter(dbCommand, "@sTX_TIPO_EMPRESA", DbType.String, objTipoEmpresa.TipoEmpresa);
            db.AddInParameter(dbCommand, "@nCOD_SIACWEB", DbType.Int32, objTipoEmpresa.CodSiacweb);

            db.ExecuteNonQuery(dbCommand, transaction);

            objTipoEmpresa.IdTipoEmpresa = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_TIPO_EMPRESA"));

            return objTipoEmpresa;
        }

        /// <summary>
        /// Altera um Escritório Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objEscritorioRegional">Entidade do Escritório Regional</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AlterarDadosSiac(EntTipoEmpresa objTipoEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_Siac_AtualizaTipoEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_TIPO_EMPRESA", DbType.Int32, objTipoEmpresa.IdTipoEmpresa);
            db.AddInParameter(dbCommand, "@nCOD_SIAC", DbType.Int32, objTipoEmpresa.CodSiacweb);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Popula Tipo Empresa, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntTipoEmpresa">Lista de EntTipoEmpresa</list></returns>
        private List<EntTipoEmpresa> Popular(DbDataReader dtrDados)
        {
            List<EntTipoEmpresa> listEntReturn = new List<EntTipoEmpresa>();
            EntTipoEmpresa entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntTipoEmpresa();

                    entReturn.IdTipoEmpresa = ObjectUtils.ToInt(dtrDados["CDA_TIPO_EMPRESA"]);
                    entReturn.TipoEmpresa = ObjectUtils.ToString(dtrDados["TX_TIPO_EMPRESA"]);
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
        /// Popula Tipo Empresa, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntTipoEmpresa">Lista de EntTipoEmpresa</list></returns>
        private List<EntTipoEmpresa> PopularComSiac(DbDataReader dtrDados)
        {
            List<EntTipoEmpresa> listEntReturn = new List<EntTipoEmpresa>();
            EntTipoEmpresa entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntTipoEmpresa();

                    entReturn.IdTipoEmpresa = ObjectUtils.ToInt(dtrDados["CDA_TIPO_EMPRESA"]);
                    entReturn.TipoEmpresa = ObjectUtils.ToString(dtrDados["TX_TIPO_EMPRESA"]);
                    entReturn.CodSiacweb = ObjectUtils.ToInt(dtrDados["COD_SIACWEB"]);
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
