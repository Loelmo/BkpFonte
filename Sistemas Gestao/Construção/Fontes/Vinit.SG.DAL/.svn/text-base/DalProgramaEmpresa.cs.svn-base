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
    /// Classe de Dados que representa um ProgramaEmpresa
    /// </summary>
    public class DalProgramaEmpresa
    {
        /// <summary>
        /// Retorna um TurmaEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public EntProgramaEmpresa ObterPorProgramaEmpresa(Int32 IdPrograma, Int32 IdEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaProgramaEmpresaPorIdProgramaIdEmpresa");
            db.AddInParameter(dbCommand, "@nIdPrograma", DbType.Int32, IdPrograma);
            db.AddInParameter(dbCommand, "@nIdEmpresa", DbType.Int32, IdEmpresa);
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
        /// Inclui um registro na tabela ProgramaEmpresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objProgramaEmpresa">Entidade que representa a tabela ProgramaEmpresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de ProgramaEmpresa</returns>
        public EntProgramaEmpresa Inserir(EntProgramaEmpresa objProgramaEmpresa, DbTransaction transaction, Database db)
        {
            EntProgramaEmpresa objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereProgramaEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_PROGRAMA_EMPRESA", DbType.Int32, objProgramaEmpresa.IdProgramaEmpresa);
            db.AddInParameter(dbCommand, "@sTX_SENHA", DbType.String, objProgramaEmpresa.Senha);
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, objProgramaEmpresa.Programa.IdPrograma);
            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, objProgramaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@sTX_NOME_RESPONSAVEL", DbType.String, objProgramaEmpresa.NomeResponsavel);
            db.AddInParameter(dbCommand, "@sTX_EMAIL_RESPONSAVEL", DbType.String, objProgramaEmpresa.EmailResponsavel);


            db.ExecuteNonQuery(dbCommand, transaction);

            objProgramaEmpresa.IdProgramaEmpresa = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_PROGRAMA_EMPRESA"));

            if (objProgramaEmpresa.IdProgramaEmpresa != int.MinValue)
                objRetorno = objProgramaEmpresa;

            return objRetorno;
        }

        /// <summary>
        /// Altera um ProgramaEmpresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objEmpresaCadastro">Entidade do ProgramaEmpresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntProgramaEmpresa objProgramaEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaProgramaEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_PROGRAMA_EMPRESA", DbType.Int32, objProgramaEmpresa.IdProgramaEmpresa);
            db.AddInParameter(dbCommand, "@sTX_SENHA", DbType.String, objProgramaEmpresa.Senha);
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, objProgramaEmpresa.Programa.IdPrograma);
            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, objProgramaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@sTX_NOME_RESPONSAVEL", DbType.String, objProgramaEmpresa.NomeResponsavel);
            db.AddInParameter(dbCommand, "@sTX_EMAIL_RESPONSAVEL", DbType.String, objProgramaEmpresa.EmailResponsavel);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna um ProgramaEmpresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntEmpresaCadastro">EntProgramaEmpresa</returns>
        public EntProgramaEmpresa ObterPorId(Int32 IdEmpresa, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaProgramaEmpresaPorId");
            db.AddInParameter(dbCommand, "@nIdEmpresa", DbType.String, IdEmpresa);
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
        /// Popula Empresa, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntProgramaEmpresa">Lista de EntProgramaEmpresa</list></returns>
        private List<EntProgramaEmpresa> Popular(DbDataReader dtrDados)
        {
            List<EntProgramaEmpresa> listEntReturn = new List<EntProgramaEmpresa>();
            EntProgramaEmpresa entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntProgramaEmpresa();

                    entReturn.IdProgramaEmpresa = ObjectUtils.ToInt(dtrDados["CDA_PROGRAMA_EMPRESA"]);
                    entReturn.Senha = ObjectUtils.ToString(dtrDados["TX_SENHA"]);
                    entReturn.Programa.IdPrograma = ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]);
                    entReturn.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CEA_EMP_CADASTRO"]);
                    entReturn.NomeResponsavel = ObjectUtils.ToString(dtrDados["TX_NOME_RESPONSAVEL"]);
                    entReturn.EmailResponsavel = ObjectUtils.ToString(dtrDados["TX_EMAIL_RESPONSAVEL"]);

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
