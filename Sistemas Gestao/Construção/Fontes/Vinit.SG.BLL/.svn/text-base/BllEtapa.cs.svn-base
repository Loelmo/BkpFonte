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
    /// Classe de Dados que representa uma Etapa
    /// </summary>
    public class BllEtapa : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de Etapa
        /// </summary>
        private DalEtapa dalEtapa = new DalEtapa();

        /// <summary>
        /// Variável privada que representa uma classe de TipoEtapa
        /// </summary>
        private DalTipoEtapa dalTipoEtapa = new DalTipoEtapa();

        /// <summary>
        /// Retorna uma lista de Etapas
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntEtapa">EntEtapa</returns>
        public EntEtapa ObterProximaEtapaPorEtapaEstadoOrdem(Int32 IdEtapa)
        {
            EntEtapa objEtapa = new EntEtapa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objEtapa = dalEtapa.ObterProximaEtapaPorEtapaEstadoOrdem(IdEtapa, transaction, db);

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
            return objEtapa;
        }

        /// <summary>
        /// Retorna uma lista de Etapas
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntEtapa">EntEtapa</returns>
        public EntEtapa ObterEtapaAnteriorPorEtapaEstadoOrdem(Int32 IdEtapa)
        {
            EntEtapa objEtapa = new EntEtapa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objEtapa = dalEtapa.ObterEtapaAnteriorPorEtapaEstadoOrdem(IdEtapa, transaction, db);

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
            return objEtapa;
        }

        /// <summary>
        /// Retorna uma lista de Etapas
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntEtapa">EntEtapa</returns>
        public List<EntEtapa> ObterAtivaPorIdEstadoIdTurma(Int32 IdEstado, Int32 nTipoEtapa, Int32 IdTurma)
        {
            List<EntEtapa> objEtapa = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objEtapa = dalEtapa.ObterAtivaPorIdEstadoIdTurma(IdEstado, nTipoEtapa, IdTurma, transaction, db);

                    foreach (EntEtapa etapa in objEtapa)
                    {
                        if (objEtapa != null)
                        {
                            etapa.Estado = new BllEstado().ObterPorId(etapa.Estado.IdEstado);
                        }
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
            return objEtapa;
        }

        /// <summary>
        /// Retorna uma lista de Etapas
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntEtapa">EntEtapa</returns>
        public List<EntEtapa> ObterPorIdEstado(Int32 IdEstado, Int32 nTipoEtapa)
        {
            List<EntEtapa> lstEtapa = new List<EntEtapa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEtapa = dalEtapa.ObterPorIdEstado(IdEstado, nTipoEtapa, transaction, db);

                    if (lstEtapa != null)
                    {
                        foreach (EntEtapa item in lstEtapa)
                        {
                            item.Estado = new BllEstado().ObterPorId(item.Estado.IdEstado);
                        }
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
            return lstEtapa;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Etapa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntEtapa">Lista de EntEtapa</list></returns>
        public EntEtapa ObterPorId(Int32 nIdEtapa)
        {
            EntEtapa objEtapa = new EntEtapa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objEtapa = dalEtapa.ObterPorId(nIdEtapa, transaction, db);
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

            return objEtapa;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Etapa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntEtapa">Lista de EntEtapa</list></returns>
        public EntEtapa ObterPorTipoEtapaTurmaEstado(Int32 nIdTipoEtapa, Int32 nIdTurma, Int32 nIdEstado)
        {
            EntEtapa objEtapa = new EntEtapa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objEtapa = dalEtapa.ObterPorTipoEtapaTurma(nIdTipoEtapa, nIdTurma, nIdEstado, transaction, db);
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

            return objEtapa;
        }

        /// <summary>
        /// Ativa ou Desativa uma Etapa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        public void AtivaDesativaEtapa(EntEtapa objEtapa, EntEtapaResumo objEtapaResumo)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalEtapa.AtivaDesativaEtapa(objEtapa, transaction, db);
                    objEtapa.TipoEtapa = dalTipoEtapa.ObterPorId(objEtapa.TipoEtapa.IdTipoEtapa, transaction, db);
                    if (objEtapa.TipoEtapa.InativaEtapasAnteriores && objEtapa.Ativo)
                    {
                        dalEtapa.DesativaEtapasAnteriores(objEtapa.Turma.IdTurma, objEtapa.TipoEtapa.OrdemFluxo, objEtapa.Estado.IdEstado, objEtapa.TipoEtapa.EtapaNacional, transaction, db);
                    }
                    new DalEtapaResumo().Inserir(objEtapaResumo, transaction, db);
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
        /// Retorna uma lista de Etapas
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntEtapa">EntEtapa</returns>
        public List<EntEtapa> ObterEtapasEstaduais(Int32 IdTurma, Int32 IdEstado, Int32 IdUsuario)
        {
            List<EntEtapa> lstEtapa = new List<EntEtapa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEtapa = dalEtapa.ObterEtapasEstaduais(IdTurma, IdEstado, IdUsuario, transaction, db);
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
            return lstEtapa;
        }

        /// <summary>
        /// Retorna uma lista de Etapas
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntEtapa">EntEtapa</returns>
        public List<EntEtapa> ObterEtapasNacionais(Int32 IdTurma)
        {
            List<EntEtapa> lstEtapa = new List<EntEtapa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEtapa = dalEtapa.ObterEtapasNacionais(IdTurma, transaction, db);
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
            return lstEtapa;
        }

        /// <summary>
        /// Gera as etapas de uma turma com base nos tipos de etapas existentes, são necessarios o IdTurma e IdPrograma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="objTurma">Entidade de Turma</param>
        /// <returns>EntEtapa</returns>
        public List<EntEtapa> GerarEtapasTurma(EntTurma objTurma)
        {
            List<EntEtapa> objRetorno = null;
            EntEtapa objEtapa = null;
            List<EntTipoEtapa> lstTipoEtapa = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalEtapa.ExcluirTodosPorTurma(objTurma.IdTurma,transaction, db);
                    objRetorno = new List<EntEtapa>();
                    lstTipoEtapa = new DalTipoEtapa().ObterTipoEtapaPorPrograma(objTurma.Programa.IdPrograma,transaction, db);

                    foreach (EntTipoEtapa item in lstTipoEtapa)
                    {
                        if (objTurma.Estado.IdEstado > 0)
                        {
                            objEtapa = new EntEtapa();
                            objEtapa.TipoEtapa = item;
                            objEtapa.Turma = objTurma;
                            objEtapa.Ativo = false;
                            objEtapa.Etapa = item.TipoEtapa;
                            objEtapa.Estado.IdEstado = objTurma.Estado.IdEstado;
                            objEtapa = new DalEtapa().Inserir(objEtapa, transaction, db);
                            if (objEtapa.IdEtapa > 0)
                            {
                                objRetorno.Add(objEtapa);
                            }
                        }
                        else
                        {
                            if (item.EtapaNacional || objTurma.Programa.IdPrograma == EntPrograma.PROGRAMA_PEG)
                            {
                                objEtapa = new EntEtapa();
                                objEtapa.TipoEtapa = item;
                                objEtapa.Turma = objTurma;
                                objEtapa.Ativo = false;
                                objEtapa.Etapa = item.TipoEtapa;
                                objEtapa = new DalEtapa().Inserir(objEtapa, transaction, db);
                                if (objEtapa.IdEtapa > 0)
                                {
                                    objRetorno.Add(objEtapa);
                                }
                            }
                            else
                            {
                                foreach (EntEstado est in new BllEstado().ObterTodos())
                                {
                                    objEtapa = new EntEtapa();
                                    objEtapa.TipoEtapa = item;
                                    objEtapa.Turma = objTurma;
                                    objEtapa.Ativo = false;
                                    objEtapa.Etapa = item.TipoEtapa;
                                    objEtapa.Estado.IdEstado = est.IdEstado;
                                    objEtapa = new DalEtapa().Inserir(objEtapa, transaction, db);
                                    if (objEtapa.IdEtapa > 0)
                                    {
                                        objRetorno.Add(objEtapa);
                                    }
                                }
                            }
                        }
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
        /// Retorna uma lista de Etapas
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <returns><type="EntEtapa">EntEtapa</returns>
        public List<EntEtapa> ObterPorTurma(Int32 nIdTurma)
        {
            List<EntEtapa> lstEtapa = new List<EntEtapa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEtapa = dalEtapa.ObterPorTurma(nIdTurma, transaction, db);
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
            return lstEtapa;
        }

    }
}