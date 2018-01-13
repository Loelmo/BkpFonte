using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace Vinit.SG.DAL
{
    /// <summary>
    /// Classe de Dados que representa um GrupoEmpresa
    /// </summary>
    public class DalGrupoEmpresa
    {
        /// <summary>
        /// Retorna uma lista de entidade de GrupoEmpresa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntGrupoEmpresa">Lista de EntGrupoEmpresa</list></returns>
        public List<EntGrupoEmpresa> ObterPorFiltro(String sGrupo, Int32 nEstado, Int32 nSetor, Int32 nTurma, Int32 nIdUsuario, Boolean bAtivo, Int32 nIdPrograma, DbTransaction transaction, Database db)
        {
            List<EntGrupoEmpresa> listEntReturn = new List<EntGrupoEmpresa>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaGrupoEmpresaPorFiltros");
            db.AddInParameter(dbCommand, "@sTX_GRUPO", DbType.String, sGrupo);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(nEstado));
            db.AddInParameter(dbCommand, "@nCEA_SETOR", DbType.Int32, IntUtils.ToIntNull(nSetor));
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IntUtils.ToIntNull(nTurma));
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Int32, bAtivo);
            db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, IntUtils.ToIntNull(nIdUsuario));
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, IntUtils.ToIntNull(nIdPrograma));
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord DataRecord in dtrDados)
                    {
                        EntGrupoEmpresa entReturn = new EntGrupoEmpresa();
                        entReturn.Grupo.IdGrupo = ObjectUtils.ToInt(DataRecord["CDA_GRUPO"]);
                        entReturn.Grupo.Grupo = ObjectUtils.ToString(DataRecord["TX_GRUPO"]);
                        entReturn.Grupo.Ativo = ObjectUtils.ToBoolean(DataRecord["FL_ATIVO"]);
                        entReturn.EmpresaCadastro.Count = ObjectUtils.ToInt(DataRecord["COUNT"]);
                        entReturn.Grupo.Setor.IdSetor = ObjectUtils.ToInt(DataRecord["CDA_SETOR"]);
                        entReturn.Grupo.Setor.Setor = ObjectUtils.ToString(DataRecord["TX_SETOR"]);
                        entReturn.Grupo.Turma.IdTurma = ObjectUtils.ToInt(DataRecord["CDA_TURMA"]);
                        entReturn.Grupo.Turma.Turma = ObjectUtils.ToString(DataRecord["TX_CICLO"]);
                        entReturn.Grupo.Estado.IdEstado = ObjectUtils.ToInt(DataRecord["CDA_ESTADO"]);
                        entReturn.Grupo.Estado.Estado = ObjectUtils.ToString(DataRecord["TX_ESTADO"]);

                        listEntReturn.Add(entReturn);
                    }

                    return listEntReturn;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de GrupoEmpresa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntGrupoEmpresa">Lista de EntGrupoEmpresa</list></returns>
        public List<EntGrupoEmpresa> ObterTodosPorGrupo(Int32 nGrupo, DbTransaction transaction, Database db)
        {
            List<EntGrupoEmpresa> listEntReturn = new List<EntGrupoEmpresa>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaGrupoEmpresaPorGrupo");
            db.AddInParameter(dbCommand, "@CDA_GRUPO", DbType.Int32, nGrupo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord DataRecord in dtrDados)
                    {
                        EntGrupoEmpresa entReturn = new EntGrupoEmpresa();
                        entReturn = PopularRow(DataRecord);
                        entReturn.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO"]);
                        entReturn.EmpresaCadastro.CPF_CNPJ = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                        entReturn.EmpresaCadastro.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL"]);
                        entReturn.EmpresaCadastro.NomeFantasia = ObjectUtils.ToString(dtrDados["TX_NOME_FANTASIA"]);

                        listEntReturn.Add(entReturn);
                    }

                    return listEntReturn;
                }
                else
                {
                    return listEntReturn;
                }
            }
        }

        /// <summary>
        /// Inclui um registro na tabela GrupoEmpresa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objGrupoEmpresa">Entidade que representa a tabela GrupoEmpresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de GrupoEmpresa</returns>
        public EntGrupoEmpresa Inserir(EntGrupoEmpresa objGrupoEmpresa, DbTransaction transaction, Database db)
        {
            EntGrupoEmpresa objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereGrupoEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_GRUPO_EMPRESA", DbType.Int32, objGrupoEmpresa.IdGrupoEmpresa);
            db.AddInParameter(dbCommand, "@CEA_EMP_CADASTRO", DbType.Int32, objGrupoEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@CEA_GRUPO", DbType.Int32, objGrupoEmpresa.Grupo.IdGrupo);

            db.ExecuteNonQuery(dbCommand, transaction);

            objGrupoEmpresa.IdGrupoEmpresa = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_GRUPO_EMPRESA"));

            if (objGrupoEmpresa.IdGrupoEmpresa != int.MinValue)
                objRetorno = objGrupoEmpresa;

            return objRetorno;
        }

        /// <summary>
        /// Excluir um GrupoEmpresa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="IdGrupo">Id do Grupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void ExcluirTodosPorGrupo(Int32 IdGrupo, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaGrupoEmpresaPorGrupo");
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.Int32, IdGrupo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Excluir um GrupoEmpresa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="IdEmpresaCadastro">Id do Grupo</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        public void ExcluirTodosPorTurmaEmpresa(EntTurmaEmpresa objTurmaEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_DeletaGrupoEmpresaPorEmpresa");
            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objTurmaEmpresa.Turma.IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Popula Grupo, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntGrupo">Lista de EntGrupo</list></returns>
        private List<EntGrupoEmpresa> Popular(DbDataReader dtrDados)
        {
            List<EntGrupoEmpresa> listEntReturn = new List<EntGrupoEmpresa>();
            EntGrupoEmpresa entReturn;

            try
            {
                foreach (DbDataRecord DataRecord in dtrDados)
                {
                    entReturn = PopularRow(DataRecord);

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
        /// Popula Grupo, conforme DataRecord passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">Registro a ser percorrido.</param>
        /// <returns><list type="EntGrupo">EntGrupo</list></returns>
        private EntGrupoEmpresa PopularRow(DbDataRecord dtrDados)
        {
            EntGrupoEmpresa entReturn;

            try
            {
                entReturn = new EntGrupoEmpresa();

                entReturn.IdGrupoEmpresa = ObjectUtils.ToInt(dtrDados["CDA_GRUPO_EMPRESA"]);
                entReturn.DtCadastro = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                entReturn.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CEA_EMP_CADASTRO"]);
                entReturn.Grupo.IdGrupo = ObjectUtils.ToInt(dtrDados["CEA_GRUPO"]);
                entReturn.Grupo.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entReturn;
        }
    }
}
