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
    /// Classe de Dados que representa um Resumo da Etapa
    /// </summary>
    public class BllEtapaResumo : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de Etapa Resumo
        /// </summary>
        private DalEtapaResumo dalEtapaResumo = new DalEtapaResumo();

        /// <summary>
        /// Retorna uma Lista de entidade de Etapa Resumo
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <returns><list type="EntEtapaResumo">Lista de EntEtapaResumo</list></returns>
        public List<EntEtapaResumo> ObterPorIdEtapa(Int32 nIdEtapa)
        {
            List<EntEtapaResumo> lstEtapaResumo = new List<EntEtapaResumo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEtapaResumo = dalEtapaResumo.ObterPorIdEtapa(nIdEtapa, transaction, db);
                    
                    if (lstEtapaResumo != null && lstEtapaResumo.Count > 0)
                    {
                        foreach (EntEtapaResumo objEtapaResumo in lstEtapaResumo)
                        {
                            objEtapaResumo.Etapa = new BllEtapa().ObterPorId(objEtapaResumo.Etapa.IdEtapa);
                            if (objEtapaResumo.Etapa.Estado.IdEstado > 0)
                            {
                                objEtapaResumo.Etapa.Estado = new BllEstado().ObterPorId(objEtapaResumo.Etapa.Estado.IdEstado);
                            }
                            objEtapaResumo.AdmUsuario = new BllAdmUsuario().ObterPorId(objEtapaResumo.AdmUsuario.IdUsuario);
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

            return lstEtapaResumo;
        }

        /// <summary>
        /// Retorna uma Lista de entidade de Etapa Resumo
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <returns><list type="EntEtapaResumo">Lista de EntEtapaResumo</list></returns>
        public List<EntEtapaResumo> ObterPorTurma(int IdTurma)
        {
            List<EntEtapaResumo> lstEtapaResumo = new List<EntEtapaResumo>();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstEtapaResumo = dalEtapaResumo.ObterPorTurma(IdTurma,transaction, db);

                    if (lstEtapaResumo != null && lstEtapaResumo.Count > 0)
                    {
                        foreach (EntEtapaResumo objEtapaResumo in lstEtapaResumo)
                        {
                            objEtapaResumo.Etapa = new BllEtapa().ObterPorId(objEtapaResumo.Etapa.IdEtapa);
                            objEtapaResumo.AdmUsuario = new BllAdmUsuario().ObterPorId(objEtapaResumo.AdmUsuario.IdUsuario);
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

            return lstEtapaResumo;
        }
    }
}