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
    /// Classe de Dados que representa um Turma
    /// </summary>
    public class DalTurma
    {

        /// <summary>
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTurma">Lista de EntTurma</list></returns>
        public EntTurma ObterPorId(Int32 nIdTurma, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaPorId");
            db.AddInParameter(dbCommand, "@nCDA_TURMA", DbType.String, nIdTurma);
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
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTurma">Lista de EntTurma</list></returns>
        public EntTurma ObterTurmaAtiva(Int32 IdPrograma, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaAtiva");
            db.AddInParameter(dbCommand, "@nIdPrograma", DbType.String, IdPrograma);
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
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTurma">Lista de EntTurma</list></returns>
        public List<EntTurma> ObterAbertasPorProgramaEmpresaEstado(Int32 IdPrograma, Int32 IdEmpresaCadastro, Int32 IdEstado, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaAbertaPorProgramaEmpresaEstado");
            db.AddInParameter(dbCommand, "@nIdPrograma", DbType.Int32, IdPrograma);
            db.AddInParameter(dbCommand, "@nIdEmpresaCadastro", DbType.Int32, IdEmpresaCadastro);
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
                    return new List<EntTurma>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTurma">Lista de EntTurma</list></returns>
        public List<EntTurma> ObterPorIdPrograma(Int32 nIdPrograma, DbTransaction transaction, Database db)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaPorIdPrograma");
            db.AddInParameter(dbCommand, "@nIdPrograma", DbType.Int32, nIdPrograma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntTurma>();
                }
            }
        }

        /// <summary>
        /// Retorna um Estado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntEstado">EntEstado</returns>
        public List<EntTurmasPermitidas> ObterTurmasPermitidas(Int32 IdUsuario, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmasPermitidas");
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
                    return new List<EntTurmasPermitidas>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTurma">Lista de EntTurma</list></returns>
        public List<EntTurma> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurma");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntTurma>();
                }
            }
        }

        /// <summary>
        /// Popula Turma, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntTurma">Lista de EntTurma</list></returns>
        private List<EntTurma> Popular(DbDataReader dtrDados)
        {
            List<EntTurma> listEntReturn = new List<EntTurma>();
            EntTurma entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntTurma();

                    entReturn.IdTurma = ObjectUtils.ToInt(dtrDados["CDA_TURMA"]);
                    entReturn.Programa.IdPrograma = ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]);
                    entReturn.Turma = ObjectUtils.ToString(dtrDados["TX_CICLO"]);
                    entReturn.DtCadastro = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.Descricao = ObjectUtils.ToString(dtrDados["TX_DESCRICAO"]);
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.Privada = ObjectUtils.ToBoolean(dtrDados["FL_PRIVADA"]);
                    try
                    {
                        entReturn.EmpresaInscrita = ObjectUtils.ToBoolean(dtrDados["FL_EMPRESA_INSCRITA"]);
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
        /// Popula Turma, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntTurma">Lista de EntTurma</list></returns>
        private List<EntTurmasPermitidas> PopularCustom(DbDataReader dtrDados)
        {
            List<EntTurmasPermitidas> listEntReturn = new List<EntTurmasPermitidas>();
            EntTurmasPermitidas entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntTurmasPermitidas();

                    entReturn.IdTurma = ObjectUtils.ToInt(dtrDados["CDA_TURMA"]);
                    entReturn.Programa.IdPrograma = ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]);
                    entReturn.Turma = ObjectUtils.ToString(dtrDados["TX_CICLO"]);
                    entReturn.DtCadastro = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.Descricao = ObjectUtils.ToString(dtrDados["TX_DESCRICAO"]);
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    entReturn.Privada = ObjectUtils.ToBoolean(dtrDados["FL_PRIVADA"]);
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
        /// Retorna uma lista de entidade de Turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEmpresa">Lista de EntTurma</list></returns>
        public List<EntTurma> ObterPorFiltro(String sNome, Int32 nEstado, Int32 nPrivada, DateTime dDataInicial,DateTime dDataFinal, Int32 nPrograma, Int32 IdUsuario, DbTransaction transaction, Database db)
        {
            List<EntTurma> listEntReturn = new List<EntTurma>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaFiltros");
            db.AddInParameter(dbCommand, "@sTX_TURMA", DbType.String, sNome);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(nEstado));
            db.AddInParameter(dbCommand, "@nPrivada", DbType.Int32, IntUtils.ToIntBoolNull(nPrivada));
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, IntUtils.ToIntNull(nPrograma));
            db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, IntUtils.ToIntNull(IdUsuario));
            db.AddInParameter(dbCommand, "@dDATA_INICIAL", DbType.DateTime, dDataInicial);
            db.AddInParameter(dbCommand, "@dDATA_FINAL", DbType.DateTime, dDataFinal);
            
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord DataRecord in dtrDados)
                    {
                        EntTurma entReturn = new EntTurma();
                        entReturn.IdTurma = ObjectUtils.ToInt(dtrDados["CDA_TURMA"]);
                        entReturn.Programa.IdPrograma = ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]);
                        entReturn.Turma = ObjectUtils.ToString(dtrDados["TX_CICLO"]);
                        entReturn.DtCadastro = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                        entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                        entReturn.Descricao = ObjectUtils.ToString(dtrDados["TX_DESCRICAO"]);
                        entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                        entReturn.Privada = ObjectUtils.ToBoolean(dtrDados["FL_PRIVADA"]);
                        

                        listEntReturn.Add(entReturn);
                    }

                    return listEntReturn;
                }
                else
                {
                    return new List<EntTurma>();
                }
            }
        }

        /// <summary>
        /// Altera uma Turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="objTurma">Entidade de Turma</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AtivaDesativaTurma(EntTurma objTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtivaDesativaTurma");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_TURMA", DbType.Int32, objTurma.IdTurma);
            db.AddInParameter(dbCommand, "@nFL_ATIVO", DbType.Int32, objTurma.Ativo);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Inclui um registro na tabela turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="objTurma">Entidade da Turma</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de Turma</returns>
        public EntTurma Inserir(EntTurma objTurma, DbTransaction transaction, Database db)
        {
            EntTurma objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereTurma");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_TURMA", DbType.Int32, objTurma.IdTurma);
            db.AddInParameter(dbCommand, "@TX_CICLO", DbType.String, objTurma.Turma);
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, objTurma.Ativo);
            db.AddInParameter(dbCommand, "@CEA_PROGRAMA", DbType.Int32, objTurma.Programa.IdPrograma);
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objTurma.Estado.IdEstado));
            db.AddInParameter(dbCommand, "@DT_CADASTRO", DbType.DateTime, objTurma.DtCadastro);
            db.AddInParameter(dbCommand, "@TX_DESCRICAO", DbType.String, objTurma.Descricao);
            db.AddInParameter(dbCommand, "@FL_PRIVADA", DbType.Boolean, objTurma.Privada);

            db.ExecuteNonQuery(dbCommand, transaction);

            objTurma.IdTurma = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_TURMA"));

            if (objTurma.IdTurma != int.MinValue)
                objRetorno = objTurma;

            return objRetorno;
        }

        /// <summary>
        /// Retorna um entidade de Turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTurma">Lista de EntTurma</list></returns>
        public List<EntTurma> ObterTodasCompativeis(int IdTurma, int IdUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaCompativel");
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, IdTurma);
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
                    return new List<EntTurma>();
                }
            }
        }


        /// <summary>
        /// Altera uma Turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="objTurma">Entidade da Turma</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntTurma objTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaTurma");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_TURMA", DbType.Int32, objTurma.IdTurma);
            db.AddInParameter(dbCommand, "@TX_CICLO", DbType.String, objTurma.Turma);
            db.AddInParameter(dbCommand, "@CEA_PROGRAMA", DbType.Int32, objTurma.Programa.IdPrograma);
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objTurma.Estado.IdEstado));
            db.AddInParameter(dbCommand, "@TX_DESCRICAO", DbType.String, objTurma.Descricao);
            db.AddInParameter(dbCommand, "@FL_PRIVADA", DbType.Boolean, objTurma.Privada);

            db.ExecuteNonQuery(dbCommand, transaction);
        }
    }
}
