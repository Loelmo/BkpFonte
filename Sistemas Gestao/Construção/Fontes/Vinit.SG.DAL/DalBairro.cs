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
    /// Classe de Dados que representa um Bairro
    /// </summary>
    public class DalBairro
    {
        /// <summary>
        /// Retorna um entidade de Bairro
        /// </summary>
        /// <autor>Fernando Carvalo</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntBairro">Lista de EntBairro</list></returns>
        public EntBairro ObterPorId(Int32 IdBairro, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaBairroPorId");
            db.AddInParameter(dbCommand, "@nIdBairro", DbType.String, IdBairro);
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
        /// Retorna um entidade de Bairro
        /// </summary>
        /// <autor>Fernando Carvalo</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntBairro">Lista de EntBairro</list></returns>
        public EntBairro ObterPorIdSiac(Int32 CodSiac, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaBairroPorCodSiac");
            db.AddInParameter(dbCommand, "@CodSiac", DbType.String, CodSiac);
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
        /// Retorna um entidade de Bairro
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntBairro">Lista de EntBairro</list></returns>
        public List<EntBairro> ObterPorCidade(Int32 IdCidade, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaBairroPorCidade");
            db.AddInParameter(dbCommand, "@nIdCidade", DbType.String, IdCidade);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntBairro>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Bairro
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntBairro">Lista de EntBairro</list></returns>
        public EntBairro ObterBairroPorNomeCidade(String nome, Int32 IdCidade, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaBairroPorNomeCidade");
            db.AddInParameter(dbCommand, "@nIdCidade", DbType.String, IdCidade);
            db.AddInParameter(dbCommand, "@sTX_NOME", DbType.String, nome);
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
        /// Inclui um registro na tabela TBL_CIDADE
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade que representa a tabela Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Cidade</returns>
        public EntBairro Inserir(EntBairro objBairro, DbTransaction transaction, Database db)
        {
            EntBairro objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereBairro");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_BAIRRO", DbType.Int32, objBairro.IdBairro);
            db.AddInParameter(dbCommand, "@nCEA_CIDADE", DbType.String, objBairro.Cidade.IdCidade);
            db.AddInParameter(dbCommand, "@sTX_BAIRRO", DbType.String, objBairro.Bairro);
            db.AddInParameter(dbCommand, "@nCOD_SIACWEB", DbType.Int32, objBairro.CodSiacweb);

            db.ExecuteNonQuery(dbCommand, transaction);

            objBairro.IdBairro = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_BAIRRO"));

            if (objBairro.IdBairro != int.MinValue)
                objRetorno = objBairro;

            return objRetorno;
        }

        /// <summary>
        /// Altera uma Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade da Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AlterarDadosSiac(EntBairro objBairro, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_Siac_AtualizaBairro");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCOD_SIAC", DbType.Int32, objBairro.CodSiacweb);
            db.AddInParameter(dbCommand, "@nCDA_BAIRRO", DbType.Int32, objBairro.IdBairro);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um entidade de Bairro
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntBairro">Lista de EntBairro</list></returns>
        public List<EntBairro> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaBairro");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntBairro>();
                }
            }
        }

        /// <summary>
        /// Popula Bairro, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntBairro">Lista de EntBairro</list></returns>
        private List<EntBairro> Popular(DbDataReader dtrDados)
        {
            List<EntBairro> listEntReturn = new List<EntBairro>();
            EntBairro entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntBairro();

                    entReturn.IdBairro = ObjectUtils.ToInt(dtrDados["CDA_BAIRRO"]);
                    entReturn.Bairro = ObjectUtils.ToString(dtrDados["TX_BAIRRO"]);
                    entReturn.Cidade.IdCidade = ObjectUtils.ToInt(dtrDados["CEA_CIDADE"]);
                    try
                    {
                        entReturn.CodSiacweb = ObjectUtils.ToInt(dtrDados["COD_SIACWEB"]);
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
    }
}
