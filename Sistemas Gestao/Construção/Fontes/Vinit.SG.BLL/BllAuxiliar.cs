using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa uma TurmaEmpresa
    /// </summary>
    public class BllAuxiliar : BllBase
    {
        private DalAuxiliar dalAuxiliar = new DalAuxiliar();

        private DalQuestionarioEmpresa dalQuestionarioEmpresa = new DalQuestionarioEmpresa();
        private DalTurmaEmpresa dalTurmaEmpresa = new DalTurmaEmpresa();
        private DalQuestionarioEmpresaAvaliador dalQuestionarioEmpresaAvaliador = new DalQuestionarioEmpresaAvaliador();
        private DalQuestionarioPontuacao dalQuestionarioPontuacao = new DalQuestionarioPontuacao();

        public void ObterTodasInscritasPorEstado(String estado, Int32 programaId)
        {
            List<EntTurmaEmpresa> lstTurmaEmpresa = new List<EntTurmaEmpresa>();
            Database db2 = DatabaseFactory.CreateDatabase("mpe_old");
            using (DbConnection connection = db2.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    lstTurmaEmpresa = dalAuxiliar.ObterTodasInscritasPorEstado(estado, programaId, transaction, db2);
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
            using (DbConnection connection = db2.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    foreach (EntTurmaEmpresa turmaEmpresa in lstTurmaEmpresa)
                    {
                        turmaEmpresa.ListQuestionarioEmpresa = dalAuxiliar.ObterQuestionarioEmpresa(turmaEmpresa.EmpresaCadastro.IdEmpresaCadastro, programaId, turmaEmpresa.ParticipaEmpreendedorismo, turmaEmpresa.ParticipaResponsabilidadeSocial, transaction, db);
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
            using (DbConnection connection = db2.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    int i = 0;
                    while(i < lstTurmaEmpresa.Count)
                    {
                        int j = 0;
                        while(j < lstTurmaEmpresa[i].ListQuestionarioEmpresa.Count)
                        {
                            lstTurmaEmpresa[i].ListQuestionarioEmpresa[j] = dalAuxiliar.ObterDadosQuestionarioEmpresa(lstTurmaEmpresa[i].ListQuestionarioEmpresa[j], transaction, db);
                            j++;
                        }
                        i++;
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

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    foreach (EntTurmaEmpresa turmaEmpresa in lstTurmaEmpresa)
                    {
                        try
                        {
                            turmaEmpresa.AtividadeEconomica = dalAuxiliar.ObterAtividadeEconomicaPorNome(turmaEmpresa.AtividadeEconomica.AtividadeEconomica, transaction, db);
                        }
                        catch { }
                        try
                        {
                            turmaEmpresa.Categoria = dalAuxiliar.ObterCategoriaPorNome(turmaEmpresa.Categoria.Categoria, transaction, db);
                        }
                        catch { }
                        try
                        {
                            turmaEmpresa.Cargo = dalAuxiliar.ObterCargoPorNome(turmaEmpresa.Cargo.Cargo, transaction, db);
                        }
                        catch { }
                        try
                        {
                            turmaEmpresa.Estado = dalAuxiliar.ObterEstadoPorNome(turmaEmpresa.Estado.Estado, transaction, db);
                        }
                        catch { }
                        try
                        {
                            turmaEmpresa.Cidade = dalAuxiliar.ObterCidadePorNome(turmaEmpresa.Cidade.Cidade, turmaEmpresa.Estado.IdEstado, transaction, db);
                        }
                        catch { }
                        try
                        {
                            turmaEmpresa.EstadoContato = dalAuxiliar.ObterEstadoPorNome(turmaEmpresa.EstadoContato.Estado, transaction, db);
                        }
                        catch { }
                        try
                        {
                            turmaEmpresa.CidadeContato = dalAuxiliar.ObterCidadePorNome(turmaEmpresa.CidadeContato.Cidade, turmaEmpresa.Estado.IdEstado, transaction, db);
                        }
                        catch { }
                        try
                        {
                            turmaEmpresa.ContatoNivelEscolaridade = dalAuxiliar.ObterNivelEscolaridadePorNome(turmaEmpresa.ContatoNivelEscolaridade.ContatoNivelEscolaridade, transaction, db);
                        }
                        catch { }
                        try
                        {
                            turmaEmpresa.FaixaEtaria = dalAuxiliar.ObterFaixaEtariaPorNome(turmaEmpresa.FaixaEtaria.ContatoFaixaEtaria, transaction, db);
                        }
                        catch { }
                        try
                        {
                            turmaEmpresa.Faturamento = dalAuxiliar.ObterFaturamentoPorNome(turmaEmpresa.Faturamento.Faturamento, transaction, db);
                        }
                        catch { }
                        try
                        {
                            turmaEmpresa.TipoEmpresa = dalAuxiliar.ObterTipoEmpresaPorNome(turmaEmpresa.TipoEmpresa.TipoEmpresa, transaction, db);
                        }
                        catch { }
                        try
                        {
                            turmaEmpresa.Usuario = dalAuxiliar.ObterUsuarioPorEmail(turmaEmpresa.Usuario.Email, transaction, db);
                        }
                        catch { }
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

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    int i = 0;
                    while (i < lstTurmaEmpresa.Count)
                    {
                        if(lstTurmaEmpresa[i].EmpresaCadastro.CPF_CNPJ.Equals("31451164000169") || lstTurmaEmpresa[i].EmpresaCadastro.CPF_CNPJ.Equals("00118922777")){
                        try
                        {
                            lstTurmaEmpresa[i] = dalTurmaEmpresa.Inserir(lstTurmaEmpresa[i], transaction, db);
                            int j = 0;
                            while (j < lstTurmaEmpresa[i].ListQuestionarioEmpresa.Count)
                            {
                                try
                                {
                                    lstTurmaEmpresa[i].ListQuestionarioEmpresa[j] = dalQuestionarioEmpresa.Inserir(lstTurmaEmpresa[i].ListQuestionarioEmpresa[j], transaction, db);
                                    foreach (EntQuestionarioEmpresaAvaliador aval in lstTurmaEmpresa[i].ListQuestionarioEmpresa[j].ListQuestionarioEmpresaAvaliador)
                                    {
                                        dalQuestionarioEmpresaAvaliador.Inserir(aval, transaction, db);
                                    }
                                    foreach (EntQuestionarioPontuacao pont in lstTurmaEmpresa[i].ListQuestionarioEmpresa[j].ListQuestionarioPontuacao)
                                    {
                                        dalQuestionarioPontuacao.Inserir(pont, transaction, db);
                                    }
                                    j++;
                                }
                                catch
                                {
                                    j++;
                                }
                            }
                            i++;
                        }
                        catch
                        {
                            i++;
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
        }

    }
}
