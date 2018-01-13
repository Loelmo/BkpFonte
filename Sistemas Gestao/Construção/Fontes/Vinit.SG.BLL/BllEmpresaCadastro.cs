using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using System.Data.Common;

namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa uma Empresa
    /// </summary>
    public class BllEmpresaCadastro : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de Empresa
        /// </summary>
        private DalEmpresaCadastro dalEmpresaCadastro = new DalEmpresaCadastro();

        /// <summary>
        /// Retorna uma lista de Empresas
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntEmpresaCadastro">EntEmpresaCadastro</returns>
        public List<EntEmpresaCadastro> ObterTodosPorGrupo(Int32 IdGrupo)
        {
            List<EntEmpresaCadastro> lstEmpresaCadastro = new List<EntEmpresaCadastro>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEmpresaCadastro = dalEmpresaCadastro.ObterTodosPorGrupo(IdGrupo, transaction, db);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return lstEmpresaCadastro;
        }

        /// <summary>
        /// Retorna uma lista de EmpresaCadastro
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntEmpresaCadastro">EntEmpresaCadastro</returns>
        public List<EntEmpresaCadastro> ObterPorFiltro(String sCpfCnpj, String sNome, Int32 nEstado, Int32 nEscritorioRegional, Int32 nCategoria, Int32 IdTurma)
        {
            List<EntEmpresaCadastro> lstEmpresaCadastro = new List<EntEmpresaCadastro>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEmpresaCadastro = dalEmpresaCadastro.ObterPorFiltro(sCpfCnpj, sNome, nEstado, nEscritorioRegional, nCategoria, IdTurma, transaction, db);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return lstEmpresaCadastro;
        }

        /// <summary>
        /// Retorna um Empresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntEmpresaCadastro">EntEmpresaCadastro</returns>
        public EntEmpresaCadastro ValidarEmpresa(String sCPF_CNPJ, Int32 IdPrograma)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalEmpresaCadastro.ValidaEmpresa(sCPF_CNPJ, IdPrograma, transaction, db);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Retorna um Empresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntEmpresaCadastro">EntEmpresaCadastro</returns>
        public EntEmpresaCadastro ObterPorId(Int32 IdEmpresaCadastro)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalEmpresaCadastro.ObterPorId(IdEmpresaCadastro, transaction, db);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Retorna um Empresa
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <returns><type="EntEmpresaCadastro">EntEmpresaCadastro</returns>
        public List<EntEmpresaCadastro> ObterPorIdPrograma(Int32 IdEmpresaCadastro, Int32 IdPrograma)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalEmpresaCadastro.ObterPorIdPrograma(IdEmpresaCadastro, IdPrograma, transaction, db);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Retorna um Empresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntEmpresaCadastro">EntEmpresaCadastro</returns>
        public EntEmpresaCadastro ObterPorCpfCnpj(String CpfCnpj)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalEmpresaCadastro.ObterPorCpfCnpj(CpfCnpj, transaction, db);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de EmpresaCadastro
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntEmpresaCadastro">EntEmpresaCadastro</returns>
        public List<EntEmpresaCadastro> ObterNaoCadastradasNaTurma(String sCpfCnpj, String sNome, Int32 nEstado, Int32 nIdTurma)
        {
            List<EntEmpresaCadastro> lstEmpresaCadastro = new List<EntEmpresaCadastro>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEmpresaCadastro = dalEmpresaCadastro.ObterNaoCadastradasNaTurma(sCpfCnpj, sNome, nEstado, nIdTurma, transaction, db);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return lstEmpresaCadastro;
        }

        /// <summary>
        /// Inclui uma Turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="objEmpresaCadastro">Entidade de Empresa Cadastro</param>
        /// <returns>Entidade de Empresa Cadastro</returns>
        public EntEmpresaCadastro Inserir(EntEmpresaCadastro objEmpresa)
        {
            EntEmpresaCadastro objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    objRetorno = dalEmpresaCadastro.Inserir(objEmpresa, transaction, db);


                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return objRetorno;
        }


        /// <summary>
        /// Editar uma Empresa
        /// </summary>
        /// <autor>Paulo Apoloni</autor>
        /// <param name="objEmpresaCadastro">Entidade de Empresa Cadastro</param>
        /// <returns>Entidade de Empresa Cadastro</returns>
        public void Alterar(EntEmpresaCadastro objEmpresa)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalEmpresaCadastro.Alterar(objEmpresa, transaction, db);

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }


        }
    }
}
