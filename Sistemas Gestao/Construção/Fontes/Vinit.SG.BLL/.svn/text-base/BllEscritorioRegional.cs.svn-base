using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa um Escritório Regional
    /// </summary>
    public class BllEscritorioRegional : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de Escritório Regional
        /// </summary>
        private DalEscritorioRegional dalEscritorioRegional = new DalEscritorioRegional();

        /// <summary>
        /// Variável privada que representa uma classe de Cidade
        /// </summary>
        private DalCidade dalCidade = new DalCidade();

        /// <summary>
        /// Variável privada que representa uma classe de CidadeRelEscritorioRegional
        /// </summary>
        private DalCidadeRelEscritorioRegional dalCidadeRelEscritorioRegional = new DalCidadeRelEscritorioRegional();

        /// <summary>
        /// Inclui um Escritório Regional sem a lista de cidades
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objEscritorioRegional">Entidade do Escritório Regional</param>
        /// <returns>Entidade de Escritório Regional</returns>
        public EntEscritorioRegional InserirSemCidades(EntEscritorioRegional objEscritorioRegional)
        {
            EntEscritorioRegional objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalEscritorioRegional.Inserir(objEscritorioRegional, transaction, db);
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
        /// Inclui um Escritório Regional com lista de cidades
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objEscritorioRegional">Entidade do Escritório Regional</param>
        public EntEscritorioRegional InserirComCidades(EntEscritorioRegional objEscritorioRegional)
        {
            EntEscritorioRegional objRetorno = null;
            
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalEscritorioRegional.Inserir(objEscritorioRegional, transaction, db);

                    EntCidadeRelEscritorioRegional objCidadeRelEscritorioRegional = new EntCidadeRelEscritorioRegional();

                    objCidadeRelEscritorioRegional.EscritorioRegional.IdEscritorioRegional = objRetorno.IdEscritorioRegional;

                    foreach (EntCidade cidade in objEscritorioRegional.LstCidades)
                    {
                        // inserir todas as cidades na tabela de relacionamento
                        objCidadeRelEscritorioRegional.Cidade.IdCidade = cidade.IdCidade;
                        dalCidadeRelEscritorioRegional.Inserir(objCidadeRelEscritorioRegional, transaction, db);
                    }

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
        /// Altera um Escritório Regional sem lista de cidades
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="objEscritorioRegional">Entidade de Escritório Regional</param>
        public void AlterarSemCidades(EntEscritorioRegional objEscritorioRegional)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalEscritorioRegional.Alterar(objEscritorioRegional, transaction, db);
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

        /// <summary>
        /// Altera um Escritório Regional com listas de cidades e retorna as 
        /// cidades insdiponiveis para associação com Escritório Regional
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="objEscritorioRegional">Entidade de Escritório Regional</param>
        public void AlterarComCidades(EntEscritorioRegional objEscritorioRegional)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    //Altera dados do Escritório Regional
                    dalEscritorioRegional.Alterar(objEscritorioRegional, transaction, db);

                    dalCidadeRelEscritorioRegional.Excluir(objEscritorioRegional.IdEscritorioRegional, transaction, db);

                    EntCidadeRelEscritorioRegional objCidadeRelEscritorioRegional = new EntCidadeRelEscritorioRegional();

                    objCidadeRelEscritorioRegional.EscritorioRegional.IdEscritorioRegional = objEscritorioRegional.IdEscritorioRegional;
                    
                    ////Exclui cidades do Relacionamento Cidade x Escritório Regional
                    //foreach (EntCidade cidade in objEscritorioRegional.LstCidades)
                    //{
                    //    dalCidadeRelEscritorioRegional.Excluir(cidade.IdCidade, transaction, db);
                    //}

                    //Insere cidades do Escritório Regional
                    foreach (EntCidade cidade in objEscritorioRegional.LstCidades)
                    {
                        // inserir todas as cidades na tabela de relacionamento
                        objCidadeRelEscritorioRegional.Cidade.IdCidade = cidade.IdCidade;
                        dalCidadeRelEscritorioRegional.Inserir(objCidadeRelEscritorioRegional, transaction, db);
                    }

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

        /// <summary>
        /// Retorna uma Lista de entidade de Escritório Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntEscritorioRegional">Lista de EntEntEscritorioRegional</list></returns>
        public List<EntEscritorioRegional> ObterAtivosPorFiltro(EntEscritorioRegional objEscritorioRegional,  Int32 IdUsuario)
        {
            List<EntEscritorioRegional> lstEscritorioRegional = new List<EntEscritorioRegional>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEscritorioRegional = dalEscritorioRegional.ObterAtivosPorFiltro(objEscritorioRegional, IdUsuario, transaction, db);
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
            return lstEscritorioRegional;
        }

        /// <summary>
        /// Retorna um Boolean
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        public Boolean ExisteEscritorioRegional(EntEscritorioRegional objEscritorioRegional)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    return dalEscritorioRegional.ExisteEscritorioRegional(objEscritorioRegional, transaction, db);
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
        /// Retorna uma entidade de Escritório Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntEscritorioRegional">EntEscritorioRegional</list></returns>
        public EntEscritorioRegional ObterPorId(Int32 IdEscritorioRegional)
        {
            EntEscritorioRegional objEscritorioRegional = new EntEscritorioRegional();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objEscritorioRegional = dalEscritorioRegional.ObterPorId(IdEscritorioRegional, transaction, db);
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
            return objEscritorioRegional;
        }


        /// <summary>
        /// Retorna uma entidade de Escritório Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntEscritorioRegional">EntEscritorioRegional</list></returns>
        public EntEscritorioRegional ObterPorIdComCidades(Int32 IdEscritorioRegional)
        {
            EntEscritorioRegional objEscritorioRegional = new EntEscritorioRegional();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objEscritorioRegional = dalEscritorioRegional.ObterPorId(IdEscritorioRegional, transaction, db);
                    objEscritorioRegional.LstCidades = dalCidade.ObterPorEscritorioRegional(objEscritorioRegional.IdEscritorioRegional, transaction, db);
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
            return objEscritorioRegional;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Escritório Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntEscritorioRegional">Lista de EntEscritorioRegional</list></returns>
        public List<EntEscritorioRegional> ObterTodosAtivos()
        {
            List<EntEscritorioRegional> lstEscritorioRegional = new List<EntEscritorioRegional>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEscritorioRegional = dalEscritorioRegional.ObterTodosAtivos(transaction, db);
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
            return lstEscritorioRegional;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Escritório Regional
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntEscritorioRegional">Lista de EntEscritorioRegional</list></returns>
        public List<EntEscritorioRegional> ObterPorIdTurmaEstado(Int32 IdTurma, Int32 IdEstado)
        {
            List<EntEscritorioRegional> lstEscritorioRegional = new List<EntEscritorioRegional>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEscritorioRegional = dalEscritorioRegional.ObterPorIdTurmaEstado(IdTurma, IdEstado, transaction, db);
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
            return lstEscritorioRegional;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Escritório Regional
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntEscritorioRegional">Lista de EntEscritorioRegional</list></returns>
        public List<EntEscritoriosRegionaisPermitidos> ObterEscritoriosRegeionaisPermitidos(Int32 IdUsuario, Int32 IdPrograma)
        {
            List<EntEscritoriosRegionaisPermitidos> lstEscritoriosRegionaisPermitidos = new List<EntEscritoriosRegionaisPermitidos>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEscritoriosRegionaisPermitidos = dalEscritorioRegional.ObterEscritoriosRegeionaisPermitidos(IdUsuario, IdPrograma, transaction, db);
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
            return lstEscritoriosRegionaisPermitidos;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Escritório Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntEscritorioRegional">Lista de EntEscritorioRegional</list></returns>
        public List<EntEscritorioRegional> ObterTodosComCidades()
        {
            List<EntEscritorioRegional> lstEscritorioRegional = new List<EntEscritorioRegional>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEscritorioRegional = dalEscritorioRegional.ObterTodosAtivos(transaction, db);

                    foreach (EntEscritorioRegional item in lstEscritorioRegional)
                    {
                        item.LstCidades = dalCidade.ObterPorEscritorioRegional(item.IdEscritorioRegional, transaction, db);
                    }

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
            return lstEscritorioRegional;
        }

        /// <summary>
        /// Exclui logicamente um Escritório Regional sem lista de cidades
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="objEscritorioRegional">Entidade de Escritório Regional</param>
        public void Excluir(EntEscritorioRegional EscritorioRegional)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    EscritorioRegional.Ativo = !EscritorioRegional.Ativo;
                    dalEscritorioRegional.Alterar(EscritorioRegional, transaction, db);
                    if (!EscritorioRegional.Ativo)
                    {
                        dalCidade.RemoverCidadesDoEscritorioRegional(EscritorioRegional.IdEscritorioRegional, transaction, db);
                    }
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
