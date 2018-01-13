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
    /// Classe de Dados que representa uma TurmaEmpresa
    /// </summary>
    public class BllTurmaEmpresa : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de TurmaEmpresa
        /// </summary>
        private DalTurmaEmpresa dalTurmaEmpresa = new DalTurmaEmpresa();

        /// <summary>
        /// Variável privada que representa uma classe de QuestionarioEmpresa
        /// </summary>
        private DalQuestionarioEmpresa dalQuestionarioEmpresa = new DalQuestionarioEmpresa();

        /// <summary>
        /// Variável privada que representa uma classe de QuestionarioEmpresa
        /// </summary>
        private DalEmpresaCadastro dalEmpresaCadastro = new DalEmpresaCadastro();

        /// <summary>
        /// Variável privada que representa uma classe de Etapa
        /// </summary>
        private DalEtapa dalEtapa = new DalEtapa();

        /// <summary>
        /// Retorna uma lista de TurmaEmpresas
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public List<EntTurmaEmpresa> ObterTodasInscritasPorFiltros(EntTurmaEmpresa objTurmaEmpresa, EntGrupo objGrupo, String sProtocolo, DateTime dDataInicio, DateTime dDataFim, Int32 IdTipoEtapa)
        {
            List<EntTurmaEmpresa> lstTurmaEmpresa = new List<EntTurmaEmpresa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurmaEmpresa = dalTurmaEmpresa.ObterTodasInscritasPorFiltros(objTurmaEmpresa, objGrupo, sProtocolo, dDataInicio, dDataFim, IdTipoEtapa, transaction, db);
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
            return lstTurmaEmpresa;
        }

        /// <summary>
        /// Retorna uma lista de TurmaEmpresas por filtro simples
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public List<EntTurmaEmpresa> ObterTodasInscritasPorFiltros(EntTurmaEmpresa objTurmaEmpresa)
        {
            List<EntTurmaEmpresa> lstTurmaEmpresa = new List<EntTurmaEmpresa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurmaEmpresa = dalTurmaEmpresa.ObterTodasInscritasPorFiltros(objTurmaEmpresa, transaction, db);
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
            return lstTurmaEmpresa;
        }

        /// <summary>
        /// Retorna uma lista de TurmaEmpresas
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public EntTurmaEmpresa ObterTurmaEmpresaAnteriorPorEmpresaCadastro(Int32 IdEmpresaCadastro, Int32 IdPrograma, Int32 IdTurma)
        {
            EntTurmaEmpresa objTurmaEmpresa = new EntTurmaEmpresa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objTurmaEmpresa = dalTurmaEmpresa.ObterTurmaEmpresaAnteriorPorEmpresaCadastro(IdEmpresaCadastro, IdPrograma, IdTurma, transaction, db);
                    objTurmaEmpresa.AtividadeEconomica = new DalAtividadeEconomica().ObterPorId(objTurmaEmpresa.AtividadeEconomica.IdAtividadeEconomica, transaction, db);
                    
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
            return objTurmaEmpresa;
        }

        /// <summary>
        /// Retorna uma lista de TurmaEmpresas
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public List<EntTurmaEmpresa> ObterTurmaCorrentePorIdUsuario(Int32 IdUsuario)
        {
            List<EntTurmaEmpresa> lstTurmaEmpresa = new List<EntTurmaEmpresa>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurmaEmpresa = dalTurmaEmpresa.ObterTurmaCorrentePorIdUsuario(IdUsuario, transaction, db);
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
            return lstTurmaEmpresa;
        }

        /// <summary>
        /// Retorna uma TurmaEmpresas
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public EntTurmaEmpresa ObterPorTurmaEmpresa(EntTurmaEmpresa objTurmaEmpresa)
        {
            EntTurmaEmpresa turmaEmpresa = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    turmaEmpresa = dalTurmaEmpresa.ObterPorTurmaEmpresa(objTurmaEmpresa, transaction, db);
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
            return turmaEmpresa;
        }

        /// <summary>
        /// Retorna uma TurmaEmpresas
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public EntTurmaEmpresa ObterPorIdEmpresaIdPrograma(Int32 IdEmpresa, Int32 IdPrograma)
        {
            EntTurmaEmpresa objTurmaEmpresa = new EntTurmaEmpresa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objTurmaEmpresa = dalTurmaEmpresa.ObterPorIdEmpresaIdPrograma(IdEmpresa, IdPrograma, transaction, db);
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
            return objTurmaEmpresa;
        }

        /// <summary>
        /// Retorna uma TurmaEmpresas
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public EntTurmaEmpresa InsereInscricaoTurmaEmpresa(Int32 IdPrograma, Int32 IdEmpresaCadastro, Int32 IdTurma, Int32 IdEstado, Int32 IdUsuario)
        {
            EntTurmaEmpresa turmaEmpresa = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    turmaEmpresa = dalTurmaEmpresa.ObterUltimoPorProgramaEmpresa(IdPrograma, IdEmpresaCadastro, transaction, db);
                    if (turmaEmpresa == null)
                    {
                        turmaEmpresa = new EntTurmaEmpresa();
                        turmaEmpresa.Ativo = true;
                        turmaEmpresa.Cadastro = DateTime.Now;
                        turmaEmpresa.UltimaAlteracao = DateTime.Now;
                        turmaEmpresa.EmpresaCadastro.IdEmpresaCadastro = IdEmpresaCadastro;
                        turmaEmpresa.Estado.IdEstado = IdEstado;
                        turmaEmpresa.Pais.IdPais = EntPais.PAIS_BRASIL;
                        turmaEmpresa.ParticipaPrograma = true;
                        turmaEmpresa.Turma.IdTurma = IdTurma;
                        if (IdUsuario > 0)
                        {
                            turmaEmpresa.Usuario.IdUsuario = IdUsuario;
                        }
                    }
                    else
                    {
                        turmaEmpresa.Ativo = true;
                        turmaEmpresa.Cadastro = DateTime.Now;
                        turmaEmpresa.UltimaAlteracao = DateTime.Now;
                        turmaEmpresa.Faturamento = null;
                        turmaEmpresa.NumeroFuncionario = -1;
                        turmaEmpresa.ParticipaPrograma = true;
                        turmaEmpresa.Turma.IdTurma = IdTurma;
                        if(IdUsuario > 0)
                        {
                            turmaEmpresa.Usuario.IdUsuario = IdUsuario;
                        }
                    }
                    dalTurmaEmpresa.Inserir(turmaEmpresa, transaction, db);
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
            return turmaEmpresa;
        }

        /// <summary>
        /// Mudar 
        /// </summary>
        /// <param name="objTurma"></param>
        public bool MudarTurma(EntTurmaEmpresa objTurmaEmpresa, int IdTurmaDestino)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objTurmaEmpresa.EmpresaCadastro = dalEmpresaCadastro.ObterPorId(objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro, transaction, db);
                    dalTurmaEmpresa.MudarTurma(objTurmaEmpresa, IdTurmaDestino, transaction, db);
                    List<EntQuestionarioEmpresa> listQuestionarioEmpresa = dalQuestionarioEmpresa.ObterQuestionarioPorTurmaEmpresa(objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro, objTurmaEmpresa.Turma.IdTurma, transaction, db);
                    foreach (EntQuestionarioEmpresa objQuestionarioEmpresa in listQuestionarioEmpresa)
                    {
                        objQuestionarioEmpresa.Etapa = dalEtapa.ObterPorId(objQuestionarioEmpresa.Etapa.IdEtapa, transaction, db);
                        List<EntEtapa> listTemp = dalEtapa.ObterAtivaPorIdEstadoIdTurma(objTurmaEmpresa.EmpresaCadastro.Estado.IdEstado, objQuestionarioEmpresa.Etapa.TipoEtapa.IdTipoEtapa, IdTurmaDestino, transaction, db);
                        if (listTemp.Count > 0)
                        {
                            objQuestionarioEmpresa.Etapa = listTemp[0];
                            dalQuestionarioEmpresa.MudarTurma(objQuestionarioEmpresa, transaction, db);
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Ativa ou Desativa uma TurmaEmpresa na turma selecionada
        /// </summary>
        /// <param name="objTurmaEmpresa"></param>
        public void AtivaDesativaEmpresaNaTurma(EntTurmaEmpresa objTurmaEmpresa)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalTurmaEmpresa.AtivaInativa(objTurmaEmpresa, transaction, db);
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
        /// Ativa ou Desativa uma TurmaEmpresa na turma selecionada
        /// </summary>
        /// <param name="objTurmaEmpresa"></param>
        public void ParticiparPrograma(EntTurmaEmpresa objTurmaEmpresa)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalTurmaEmpresa.ParticiparPrograma(objTurmaEmpresa, transaction, db);
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
        /// Inclui uma TurmaEmpresa
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="objTurmaEmpresa">Entidade de TurmaEmpresa</param>
        /// <returns>Entidade de TurmaEmpresa</returns>
        public EntTurmaEmpresa Inserir(EntTurmaEmpresa objTurmaEmpresa)
        {
            EntTurmaEmpresa objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objRetorno = dalTurmaEmpresa.Inserir(objTurmaEmpresa, transaction, db);


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

    }
}
