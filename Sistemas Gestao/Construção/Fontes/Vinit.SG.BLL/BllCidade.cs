using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using System.Data.Common;


namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa uma Cidade
    /// </summary>
    public class BllCidade : BllBase
    {

        /// <summary>
        /// Variável privada que representa uma classe de Cidade
        /// </summary>
        private DalCidade dalCidade = new DalCidade();

        /// <summary>
        /// Inclui uma Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade da Cidade</param>
        /// <returns>Entidade de Cidade</returns>
        public EntCidade Inserir(EntCidade objCidade)
        {
            EntCidade objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalCidade.Inserir(objCidade, transaction, db);
                    dalCidade.InserirCidadeEscritorioRegional(objCidade, transaction, db);
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
        /// Remover Escritório Regional de uma Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade da Cidade</param>
        /// <returns>Entidade de Cidade</returns>
        public EntCidade RemoverEscritorioRegional(EntCidade objCidade, Int32 IdTurma)
        {
            EntCidade objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalCidade.RemoverEscritorioRegional(objCidade, IdTurma, transaction, db);
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
        /// Remover Escritório Regional de uma Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objCidade">Entidade da Cidade</param>
        /// <returns>Entidade de Cidade</returns>
        public EntCidade RemoverCidadesDoEscritorioRegional(int nIdEscritorioRegional)
        {
            EntCidade objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalCidade.RemoverCidadesDoEscritorioRegional(nIdEscritorioRegional, transaction, db);
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
        /// Retorna uma Lista de entidade de Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public List<EntCidade> ObterPorEscritorioRegional(Int32 nIdEscritorioRegional)
        {
            List<EntCidade> lstCidade = new List<EntCidade>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCidade = dalCidade.ObterPorEscritorioRegional(nIdEscritorioRegional, transaction, db);
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
            return lstCidade;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public List<EntCidade> ObterTodos()
        {
            List<EntCidade> lstCidade = new List<EntCidade>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCidade = dalCidade.ObterTodos(transaction, db);
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
            return lstCidade;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Cidade
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public List<EntCidade> ObterCidadePorEstado(Int32 IdEstado, Int32 IdTurma)
        {
            List<EntCidade> lstCidade = new List<EntCidade>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCidade = dalCidade.ObterCidadePorEstado(IdEstado, IdTurma, transaction, db);
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
            return lstCidade;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Cidade
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public List<EntCidade> ObterCidadePorEstado2(Int32 IdEstado)
        {
            List<EntCidade> lstCidade = new List<EntCidade>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCidade = dalCidade.ObterCidadePorEstado2(IdEstado, transaction, db);
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
            return lstCidade;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Cidade
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public List<EntCidade> ObterCidadePorEstadoEscritorioRegionalRegiao(Int32 IdEstado, Int32 IdEscritorioRegional, Int32 IdRegiao, Int32 IdTurma)
        {
            List<EntCidade> lstCidade = new List<EntCidade>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCidade = dalCidade.ObterCidadePorEstadoEscritorioRegionalRegiao(IdEstado, IdEscritorioRegional, IdRegiao, IdTurma, transaction, db);
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
            return lstCidade;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Cidade
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        public List<EntCidade> ObterCidadesSemEscritorioRegional(EntEscritorioRegional objEscritorioRegional)
        {
            List<EntCidade> lstCidade = new List<EntCidade>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstCidade = dalCidade.ObterCidadesSemEscritorioRegional(objEscritorioRegional, transaction, db);
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
            return lstCidade;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Cidade que estão disponiveis para associação a um Escritorio Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntCidade">Lista de EntCidade</list></returns>
        //public List<EntCidade>[] VerificaDisponiveisParaEscritorioRegional(List<EntCidade> listCidadesSelecionadas, Int32 IdEscritorioRegional, Int32 IdEstado)
        //{
        //    List<EntCidade> listCidadesDisponiveisBase = this.ObterCidadesSemEscritorioRegional(IdEstado);
        //    List<EntCidade> listCidadesAtuais = this.ObterPorEscritorioRegional(IdEscritorioRegional);
        //    List<EntCidade> listCidadesDisponiveis = new List<EntCidade>();
        //    List<EntCidade> listCidadesIndisponiveis = new List<EntCidade>();
        //    EntCidade objCidade = null;
        //    List<EntCidade>[] listasCidades = new List<EntCidade>[2];

        //    foreach (EntCidade cidade in listCidadesSelecionadas)
        //    {
        //        if (listCidadesDisponiveisBase != null)
        //        {
        //            objCidade = listCidadesDisponiveisBase.Find(
        //                            delegate(EntCidade c) { return c.IdCidade == cidade.IdCidade; }
        //                        );
        //            if (objCidade != null)
        //            {
        //                listCidadesDisponiveis.Add(cidade);
        //            }
        //            else
        //            {
        //                if (listCidadesAtuais != null && !listCidadesAtuais.Exists(
        //                            delegate(EntCidade c) { return c.IdCidade == cidade.IdCidade; }))
        //                {
        //                    listCidadesIndisponiveis.Add(cidade);
        //                }
        //            }
        //        }
        //    }

        //    listasCidades[0] = listCidadesDisponiveis;
        //    listasCidades[1] = listCidadesIndisponiveis;

        //    return listasCidades;
        //}

    }
}
