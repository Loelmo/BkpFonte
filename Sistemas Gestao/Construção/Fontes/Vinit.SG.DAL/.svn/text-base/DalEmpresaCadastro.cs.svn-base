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
    /// Classe de Dados que representa uma Empresa
    /// </summary>
    public class DalEmpresaCadastro
    {
        /// <summary>
        /// Inclui um registro na tabela EmpresaCadastro
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objEmpresa">Entidade que representa a tabela EmpresaCadastro</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de EmpresaCadastro</returns>
        public EntEmpresaCadastro Inserir(EntEmpresaCadastro objEmpresaCadastro, DbTransaction transaction, Database db)
        {
            EntEmpresaCadastro objRetorno = null;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereEmpresaCadastro");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddOutParameter(dbCommand, "@nCDA_EMP_CADASTRO", DbType.Int32, objEmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@sTX_RAZAO_SOCIAL", DbType.String, objEmpresaCadastro.RazaoSocial);
            db.AddInParameter(dbCommand, "@sTX_NOME_FANTASIA", DbType.String, objEmpresaCadastro.NomeFantasia);
            db.AddInParameter(dbCommand, "@sTX_CPF_CNPJ", DbType.String, objEmpresaCadastro.CPF_CNPJ);
            db.AddInParameter(dbCommand, "@bFL_PESSOA_JURIDICA", DbType.Boolean, objEmpresaCadastro.PessoaJuridica);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objEmpresaCadastro.Ativo);
            if (objEmpresaCadastro.AberturaEmpresa == DateTime.MinValue)
            {
                db.AddInParameter(dbCommand, "@dDT_ABERTURA_EMPRESA", DbType.DateTime, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "@dDT_ABERTURA_EMPRESA", DbType.DateTime, objEmpresaCadastro.AberturaEmpresa);
            }
            db.AddInParameter(dbCommand, "@bFL_PARTICIPOU_MPE_2006", DbType.Boolean, objEmpresaCadastro.ParticipouMPE2006);
            db.AddInParameter(dbCommand, "@bFL_PARTICIPOU_MPE_2007", DbType.Boolean, objEmpresaCadastro.ParticipouMPE2007);
            db.AddInParameter(dbCommand, "@bFL_PARTICIPOU_MPE_2008", DbType.Boolean, objEmpresaCadastro.ParticipouMPE2008);
            db.AddInParameter(dbCommand, "@bFL_PARTICIPOU_MPE_2009", DbType.Boolean, objEmpresaCadastro.ParticipouMPE2009);
            db.AddInParameter(dbCommand, "@bFL_PARTICIPOU_MPE_2010", DbType.Boolean, objEmpresaCadastro.ParticipouMPE2010);
            db.AddInParameter(dbCommand, "@bFL_PARTICIPOU_MPE_2011", DbType.Boolean, objEmpresaCadastro.ParticipouMPE2011);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, objEmpresaCadastro.Estado.IdEstado);

            db.ExecuteNonQuery(dbCommand, transaction);

            objEmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(db.GetParameterValue(dbCommand, "@nCDA_EMP_CADASTRO"));

            if (objEmpresaCadastro.IdEmpresaCadastro != int.MinValue)
                objRetorno = objEmpresaCadastro;

            return objRetorno;
        }

        /// <summary>
        /// Altera um EmpresaCadastro
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objEmpresaCadastro">Entidade do EmpresaCadastro</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void Alterar(EntEmpresaCadastro objEmpresaCadastro, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaEmpresaCadastro");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCDA_EMP_CADASTRO", DbType.Int32, objEmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@sTX_RAZAO_SOCIAL", DbType.String, objEmpresaCadastro.RazaoSocial);
            db.AddInParameter(dbCommand, "@sTX_NOME_FANTASIA", DbType.String, objEmpresaCadastro.NomeFantasia);
            db.AddInParameter(dbCommand, "@sTX_CPF_CNPJ", DbType.String, objEmpresaCadastro.CPF_CNPJ);
            db.AddInParameter(dbCommand, "@bFL_PESSOA_JURIDICA", DbType.Boolean, objEmpresaCadastro.PessoaJuridica);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objEmpresaCadastro.Ativo);
            db.AddInParameter(dbCommand, "@dDT_ABERTURA_EMPRESA", DbType.DateTime, objEmpresaCadastro.AberturaEmpresa);
            db.AddInParameter(dbCommand, "@bFL_PARTICIPOU_MPE_2006", DbType.Boolean, objEmpresaCadastro.ParticipouMPE2006);
            db.AddInParameter(dbCommand, "@bFL_PARTICIPOU_MPE_2007", DbType.Boolean, objEmpresaCadastro.ParticipouMPE2007);
            db.AddInParameter(dbCommand, "@bFL_PARTICIPOU_MPE_2008", DbType.Boolean, objEmpresaCadastro.ParticipouMPE2008);
            db.AddInParameter(dbCommand, "@bFL_PARTICIPOU_MPE_2009", DbType.Boolean, objEmpresaCadastro.ParticipouMPE2009);
            db.AddInParameter(dbCommand, "@bFL_PARTICIPOU_MPE_2010", DbType.Boolean, objEmpresaCadastro.ParticipouMPE2010);
            db.AddInParameter(dbCommand, "@bFL_PARTICIPOU_MPE_2011", DbType.Boolean, objEmpresaCadastro.ParticipouMPE2011);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, objEmpresaCadastro.Estado.IdEstado);
            db.ExecuteNonQuery(dbCommand, transaction);
        }


        /// <summary>
        /// Retorna uma lista de entidade de EmpresaCadastro
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEmpresaCadastro">Lista de EntEmpresaCadastro</list></returns>
        public List<EntEmpresaCadastro> ObterTodosPorGrupo(Int32 nGrupo, DbTransaction transaction, Database db)
        {
            List<EntEmpresaCadastro> listEntReturn = new List<EntEmpresaCadastro>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEmpresaPorGrupo");
            db.AddInParameter(dbCommand, "@nCEA_GRUPO", DbType.Int32, nGrupo);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord DataRecord in dtrDados)
                    {
                        EntEmpresaCadastro entReturn = new EntEmpresaCadastro();
                        entReturn.IdEmpresaCadastro = ObjectUtils.ToInt(DataRecord["CDA_EMP_CADASTRO"]);
                        entReturn.CPF_CNPJ = ObjectUtils.ToString(DataRecord["TX_CPF_CNPJ"]);
                        entReturn.RazaoSocial = ObjectUtils.ToString(DataRecord["TX_RAZAO_SOCIAL"]);
                        entReturn.NomeFantasia = ObjectUtils.ToString(DataRecord["TX_NOME_FANTASIA"]);

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
        /// Retorna uma lista de entidade de Empresa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEmpresa">Lista de EntEmpresa</list></returns>
        public List<EntEmpresaCadastro> ObterPorFiltro(String sCpfCnpj, String sNome, Int32 nEstado, Int32 nEscritorioRegional, Int32 nCategoria, Int32 nTurma, DbTransaction transaction, Database db)
        {
            List<EntEmpresaCadastro> listEntReturn = new List<EntEmpresaCadastro>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEmpresaCadastroPorFiltros");
            db.AddInParameter(dbCommand, "@sCpfCnpj", DbType.String, sCpfCnpj);
            db.AddInParameter(dbCommand, "@sRazaoSocial", DbType.String, sNome);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.String, IntUtils.ToIntNull(nEstado));
            db.AddInParameter(dbCommand, "@nCEA_ESCRITORIO_REGIONAL", DbType.String, IntUtils.ToIntNull(nEscritorioRegional));
            db.AddInParameter(dbCommand, "@nCEA_CATEGORIA", DbType.String, IntUtils.ToIntNull(nCategoria));
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.String, nTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord DataRecord in dtrDados)
                    {
                        EntEmpresaCadastro entReturn = new EntEmpresaCadastro();
                        entReturn.IdEmpresaCadastro = ObjectUtils.ToInt(DataRecord["CDA_EMP_CADASTRO"]);
                        entReturn.RazaoSocial = ObjectUtils.ToString(DataRecord["TX_RAZAO_SOCIAL"]);
                        entReturn.NomeFantasia = ObjectUtils.ToString(DataRecord["TX_NOME_FANTASIA"]);
                        entReturn.CPF_CNPJ = ObjectUtils.ToString(DataRecord["TX_CPF_CNPJ"]);

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
        /// Retorna um Empresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntEmpresaCadastro">EntEmpresaCadastro</returns>
        public EntEmpresaCadastro ValidaEmpresa(String sCPF_CNPJ, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_ValidaEmpresa");
            db.AddInParameter(dbCommand, "@sCPF_CNPJ", DbType.String, sCPF_CNPJ);
            db.AddInParameter(dbCommand, "@nIdPrograma", DbType.Int32, IdPrograma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularCuston(dtrDados)[0];
                }
                else
                {
                    return new EntEmpresaCadastro();
                }
            }
        }

        /// <summary>
        /// Retorna um Empresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntEmpresaCadastro">EntEmpresaCadastro</returns>
        public EntEmpresaCadastro ObterPorId(Int32 IdEmpresaCadastro, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEmpresaCadastroPorId");
            db.AddInParameter(dbCommand, "@nIdEmpresaCadastro", DbType.String, IdEmpresaCadastro);
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
        /// Retorna um Empresa
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntEmpresaCadastro">EntEmpresaCadastro</returns>
        public List<EntEmpresaCadastro> ObterPorIdPrograma(Int32 IdEmpresaCadastro, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEmpresaCadastroPorIdPrograma");
            db.AddInParameter(dbCommand, "@nCDA_EMP_CADASTRO", DbType.Int32, IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nCEA_PROGRAMA", DbType.Int32, IdPrograma);
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
        /// Retorna um Empresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntEmpresaCadastro">EntEmpresaCadastro</returns>
        public EntEmpresaCadastro ObterPorCpfCnpj(String TxCpfCnpj, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEmpresaCadastroPorCpfCnpj");
            db.AddInParameter(dbCommand, "@TxCpfCnpj", DbType.String, TxCpfCnpj);
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
        /// Retorna uma lista de entidade de Empresa não cadastradas na turma informada como parametro
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEmpresa">Lista de EntEmpresa</list></returns>
        public List<EntEmpresaCadastro> ObterNaoCadastradasNaTurma(String sCpfCnpj, String sNome, Int32 nEstado, int IdTurma, DbTransaction transaction, Database db)
        {
            List<EntEmpresaCadastro> listEntReturn = new List<EntEmpresaCadastro>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEmpresaCadastroNaoInscritasPorFiltro");
            db.AddInParameter(dbCommand, "@sCpfCnpj", DbType.String, sCpfCnpj);
            db.AddInParameter(dbCommand, "@sRazaoSocial", DbType.String, sNome);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(nEstado));
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord DataRecord in dtrDados)
                    {
                        EntEmpresaCadastro entReturn = new EntEmpresaCadastro();
                        entReturn.IdEmpresaCadastro = ObjectUtils.ToInt(DataRecord["CDA_EMP_CADASTRO"]);
                        entReturn.RazaoSocial = ObjectUtils.ToString(DataRecord["TX_RAZAO_SOCIAL"]);
                        entReturn.NomeFantasia = ObjectUtils.ToString(DataRecord["TX_NOME_FANTASIA"]);
                        entReturn.CPF_CNPJ = ObjectUtils.ToString(DataRecord["TX_CPF_CNPJ"]);
                        entReturn.Estado.IdEstado = ObjectUtils.ToInt(DataRecord["CEA_ESTADO"]);
                        entReturn.Estado.Estado = ObjectUtils.ToString(DataRecord["TX_ESTADO"]);

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
        /// Popula Empresa, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntEmpresaCadastro">Lista de EntEmpresaCadastro</list></returns>
        private List<EntEmpresaCadastro> Popular(DbDataReader dtrDados)
        {
            List<EntEmpresaCadastro> listEntReturn = new List<EntEmpresaCadastro>();
            EntEmpresaCadastro entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntEmpresaCadastro();

                    entReturn.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO"]);
                    entReturn.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL"]);
                    entReturn.NomeFantasia = ObjectUtils.ToString(dtrDados["TX_NOME_FANTASIA"]);
                    entReturn.CPF_CNPJ = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                    entReturn.PessoaJuridica = ObjectUtils.ToBoolean(dtrDados["FL_PESSOA_JURIDICA"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.AberturaEmpresa = ObjectUtils.ToDate(dtrDados["DT_ABERTURA_EMPRESA"]);
                    entReturn.ParticipouMPE2006 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2006"]);
                    entReturn.ParticipouMPE2007 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2007"]);
                    entReturn.ParticipouMPE2008 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2008"]);
                    entReturn.ParticipouMPE2009 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2009"]);
                    entReturn.ParticipouMPE2010 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2010"]);
                    entReturn.ParticipouMPE2011 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2011"]);
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                    
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
        /// Popula Empresa, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntEmpresaCadastro">Lista de EntEmpresaCadastro</list></returns>
        private List<EntEmpresaCadastro> PopularCuston(DbDataReader dtrDados)
        {
            List<EntEmpresaCadastro> listEntReturn = new List<EntEmpresaCadastro>();
            EntEmpresaCadastro entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntEmpresaCadastro();

                    entReturn.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO"]);
                    entReturn.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL"]);
                    entReturn.NomeFantasia = ObjectUtils.ToString(dtrDados["TX_NOME_FANTASIA"]);
                    entReturn.CPF_CNPJ = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                    entReturn.PessoaJuridica = ObjectUtils.ToBoolean(dtrDados["FL_PESSOA_JURIDICA"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.AberturaEmpresa = ObjectUtils.ToDate(dtrDados["DT_ABERTURA_EMPRESA"]);
                    entReturn.ParticipouMPE2006 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2006"]);
                    entReturn.ParticipouMPE2007 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2007"]);
                    entReturn.ParticipouMPE2008 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2008"]);
                    entReturn.ParticipouMPE2009 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2009"]);
                    entReturn.ParticipouMPE2010 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2010"]);
                    entReturn.ParticipouMPE2011 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2011"]);
                    entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);

                    entReturn.ProgramaEmpresa.IdProgramaEmpresa = ObjectUtils.ToInt(dtrDados["CDA_PROGRAMA_EMPRESA"]);
                    entReturn.ProgramaEmpresa.Senha = ObjectUtils.ToString(dtrDados["TX_SENHA"]);
                    entReturn.ProgramaEmpresa.NomeResponsavel = ObjectUtils.ToString(dtrDados["TX_NOME_RESPONSAVEL"]);
                    entReturn.ProgramaEmpresa.EmailResponsavel = ObjectUtils.ToString(dtrDados["TX_EMAIL_RESPONSAVEL"]);

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
