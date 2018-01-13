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
    /// Classe de Dados que representa uma Cidade
    /// </summary>
    public class DalCidade
    {
        /// <summary>
        /// Inclui um registro na tabela TBL_CIDADE
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade que representa a tabela Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Cidade</returns>
        public EntCidade Inserir(EntCidade objCidade, DbTransaction transaction, Database db)
        {
            EntCidade objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereCidade");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_CIDADE", DbType.Int32, objCidade.IdCidade);
            db.AddInParameter(dbCommand, "@nCEA_ESCRITORIO_REGIONAL", DbType.Int32, objCidade.EscritorioRegional.IdEscritorioRegional);
            if (objCidade.EstadoRegiao.IdEstadoRegiao > 0)
            {
                db.AddInParameter(dbCommand, "@nCEA_ESTADO_REGIAO", DbType.String, objCidade.EstadoRegiao.IdEstadoRegiao);
            }
            else
            {
                db.AddInParameter(dbCommand, "@nCEA_ESTADO_REGIAO", DbType.String, DBNull.Value);
            }
            db.AddInParameter(dbCommand, "@sTX_CIDADE", DbType.String, objCidade.Cidade);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Int32, objCidade.Ativo);
            db.AddInParameter(dbCommand, "@nCOD_SIACWEB", DbType.Int32, objCidade.CodSiacweb);
            if (objCidade.Estado.IdEstado > 0)
            {
                db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, objCidade.Estado.IdEstado);
            }
            else
            {
                db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, DBNull.Value);
            }

            db.ExecuteNonQuery(dbCommand, transaction);

            objCidade.IdCidade = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_CIDADE"));

            if (objCidade.IdCidade != int.MinValue)
                objRetorno = objCidade;

            return objRetorno;
        }

        /// <summary>
        /// Inclui um registro na tabela TBL_CIDADE
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade que representa a tabela Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Cidade</returns>
        public void InserirCidadeEscritorioRegional(EntCidade objCidade, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereCidadeEscritorioRegional");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCEA_CIDADE", DbType.Int32, objCidade.IdCidade);
            db.AddInParameter(dbCommand, "@nCEA_ESCRITORIO_REGIONAL", DbType.Int32, objCidade.EscritorioRegional.IdEscritorioRegional);

            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna uma lista de entidade de Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public List<EntCidade> ObterPorEscritorioRegional(Int32 nIdEscritorioRegional, DbTransaction transaction, Database db)
        {

            List<EntCidade> lstCidade = new List<EntCidade>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCidadePorEscritorioRegional");
            db.AddInParameter(dbCommand, "@nIdEscritorioRegional", DbType.Int32, nIdEscritorioRegional);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularCuston(dtrDados);
                }
                else
                {
                    return new List<EntCidade>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public EntCidade ObterPorCodSiac(Int32 CodSiac, DbTransaction transaction, Database db)
        {

            List<EntCidade> lstCidade = new List<EntCidade>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCidadePorCodSiac");
            db.AddInParameter(dbCommand, "@CodSiac", DbType.Int32, CodSiac);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return new EntCidade();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public List<EntCidade> ObterTodos(DbTransaction transaction, Database db)
        {

            List<EntCidade> lstCidade = new List<EntCidade>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCidade");
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
        /// Retorna uma lista de entidade de Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public List<EntCidade> ObterCidadePorEstado(Int32 IdEstado, Int32 IdTurma, DbTransaction transaction, Database db)
        {

            List<EntCidade> lstCidade = new List<EntCidade>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCidadePorEstado");
            db.AddInParameter(dbCommand, "@nIdEstado", DbType.Int32, IdEstado);
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularCuston(dtrDados);
                }
                else
                {
                    return new List<EntCidade>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public List<EntCidade> ObterCidadePorEstado2(Int32 IdEstado, DbTransaction transaction, Database db)
        {

            List<EntCidade> lstCidade = new List<EntCidade>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCidadePorEstado2");
            db.AddInParameter(dbCommand, "@nIdEstado", DbType.Int32, IdEstado);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntCidade>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public EntCidade ObterCidadePorNomeEstado(String nome, Int32 IdEstado, DbTransaction transaction, Database db)
        {

            List<EntCidade> lstCidade = new List<EntCidade>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCidadePorNomeEstado");
            db.AddInParameter(dbCommand, "@nIdEstado", DbType.Int32, IdEstado);
            db.AddInParameter(dbCommand, "@sTX_NOME", DbType.String, nome);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularCuston(dtrDados)[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de Cidade
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public List<EntCidade> ObterCidadePorEstadoEscritorioRegionalRegiao(Int32 IdEstado, Int32 IdEscritorioRegional, Int32 IdRegiao, Int32 IdTurma, DbTransaction transaction, Database db)
        {

            List<EntCidade> lstCidade = new List<EntCidade>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCidadePorEstadoEscritorioRegionalRegiao");
            db.AddInParameter(dbCommand, "@nIdEstado", DbType.Int32, IdEstado);
            db.AddInParameter(dbCommand, "@nIdEscritorioRegional", DbType.Int32, IntUtils.ToIntNull(IdEscritorioRegional));
            db.AddInParameter(dbCommand, "@nIdRegiao", DbType.Int32, IntUtils.ToIntNull(IdRegiao));
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularCuston(dtrDados);
                }
                else
                {
                    return new List<EntCidade>();
                }
            }
        }

        /// <summary>
        /// Popula Cidade, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        private List<EntCidade> Popular(DbDataReader dtrDados)
        {
            List<EntCidade> listEntReturn = new List<EntCidade>();
            EntCidade entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntCidade();

                    entReturn.IdCidade = ObjectUtils.ToInt(dtrDados["CDA_CIDADE"]);
                    entReturn.EstadoRegiao.IdEstadoRegiao = ObjectUtils.ToInt(dtrDados["CEA_ESTADO_REGIAO"]);
                    entReturn.Cidade = ObjectUtils.ToString(dtrDados["TX_CIDADE"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    //entReturn.CodSiacweb = ObjectUtils.ToInt(dtrDados["COD_SIACWEB"]);
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
        /// Popula Cidade, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        private List<EntCidade> PopularCuston(DbDataReader dtrDados)
        {
            List<EntCidade> listEntReturn = new List<EntCidade>();
            EntCidade entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntCidade();

                    entReturn.IdCidade = ObjectUtils.ToInt(dtrDados["CDA_CIDADE"]);
                    entReturn.EstadoRegiao.IdEstadoRegiao = ObjectUtils.ToInt(dtrDados["CEA_ESTADO_REGIAO"]);
                    entReturn.Cidade = ObjectUtils.ToString(dtrDados["TX_CIDADE"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.EscritorioRegional.IdEscritorioRegional = ObjectUtils.ToInt(dtrDados["CEA_ESCRITORIO_REGIONAL"]);
                    //entReturn.CodSiacweb = ObjectUtils.ToInt(dtrDados["COD_SIACWEB"]);
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
        /// Altera uma Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade da Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntCidade objCidade, Int32 IdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaCidade");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_CIDADE", DbType.Int32, objCidade.IdCidade);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IdTurma);
            if (objCidade.EscritorioRegional.IdEscritorioRegional != 0)
            {
                db.AddInParameter(dbCommand, "@nCEA_ESCRITORIO_REGIONAL", DbType.Int32, objCidade.EscritorioRegional.IdEscritorioRegional);
            }
            else
            {
                db.AddInParameter(dbCommand, "@nCEA_ESCRITORIO_REGIONAL", DbType.Int32, DBNull.Value);
            }

            db.AddInParameter(dbCommand, "@nCEA_ESTADO_REGIAO", DbType.Int32, IntUtils.ToIntNull(objCidade.EstadoRegiao.IdEstadoRegiao));

            //if (objCidade.EstadoRegiao.IdEstadoRegiao != 0)
            //{
            //    db.AddInParameter(dbCommand, "@nCEA_ESTADO_REGIAO", DbType.Int32, IntUtils.ToIntNull( objCidade.EstadoRegiao.IdEstadoRegiao);
            //}
            //else
            //{
            //    db.AddInParameter(dbCommand, "@nCEA_ESTADO_REGIAO", DbType.Int32, DBNull.Value);
            //}

            db.AddInParameter(dbCommand, "@sTX_CIDADE", DbType.String, objCidade.Cidade);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Byte, objCidade.Ativo);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera uma Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade da Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AlterarDadosSiac(EntCidade objCidade, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_Siac_AtualizaCidade");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCOD_SIAC", DbType.Int32, objCidade.CodSiacweb);
            db.AddInParameter(dbCommand, "@nCDA_CIDADE", DbType.Int32, objCidade.IdCidade);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Remover Escritório Regional de uma Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade da Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void RemoverCidadesDoEscritorioRegional(int nIdEscritorioRegional, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_RemoverCidadesDoEscritorioRegional");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_ESCRITORIO_REGIONAL", DbType.Int32, nIdEscritorioRegional);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Remover Escritório Regional de uma Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade da Cidade</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void RemoverEscritorioRegional(EntCidade objCidade, Int32 IdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_RemoverEscritorioRegionalDaCidade");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_CIDADE", DbType.Int32, objCidade.IdCidade);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IdTurma);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna uma lista de entidade de Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public List<EntCidade> ObterCidadesSemEscritorioRegional(EntEscritorioRegional objEscritorioRegional, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCidadeSemEscritorioRegional");
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, objEscritorioRegional.Estado.IdEstado);
            db.AddInParameter(dbCommand, "@nCEA_ESCRITORIO_REGIONAL", DbType.Int32, objEscritorioRegional.IdEscritorioRegional);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objEscritorioRegional.Turma.IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntCidade>();
                }
            }
        }
    }
}
