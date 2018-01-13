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
    /// Classe de Dados que representa um EntUsuario
    /// </summary>
    public class BllInscricoesEmpresa : BllBase
    {
        /// <summary>
        /// Variável privada que representa uma classe de Empresa
        /// </summary>
        private DalEmpresaCadastro dalEmpresaCadastro = new DalEmpresaCadastro();

        /// <summary>
        /// Variável privada que representa uma classe de TurmaEmpresa
        /// </summary>
        private DalTurmaEmpresa dalTurmaEmpresa = new DalTurmaEmpresa();

        /// <summary>
        /// Variável privada que representa uma classe de Etapa
        /// </summary>
        private DalEtapa dalEtapa = new DalEtapa();

        /// <summary>
        /// Variável privada que representa uma classe de Questionario
        /// </summary>
        private DalQuestionario dalQuestionario = new DalQuestionario();

        /// <summary>
        /// Variável privada que representa uma classe de QuestionarioEmpresa
        /// </summary>
        private DalQuestionarioEmpresa dalQuestionarioEmpresa = new DalQuestionarioEmpresa();

        /// <summary>
        /// Variável privada que representa uma classe de Turma
        /// </summary>
        private DalTurma dalTurma = new DalTurma();

        /// <summary>
        /// Variável privada que representa uma classe de ProgramaEmpresa
        /// </summary>
        private DalProgramaEmpresa dalProgramaEmpresa = new DalProgramaEmpresa();

        /// <summary>
        /// Variável privada que representa uma classe de ProgramaEmpresa
        /// </summary>
        private DalAtividadeEconomica dalAtividadeEconomica = new DalAtividadeEconomica();

        public EntInscricoesEmpresa InserirAlterar(EntInscricoesEmpresa objInscricoesEmpresa)
        {
            return this.InserirAlterar(objInscricoesEmpresa, true);
        }

        /// <summary>
        /// Inclui um InscricoesEmpresa
        /// </summary>
        /// <autor>Fernando Carvalho, mas... foi alterado por alguem</autor>
        /// <param name="objUsuario">Entidade do InscricoesEmpresa</param>
        /// <returns>Entidade de InscricoesEmpresa</returns>
        public EntInscricoesEmpresa InserirAlterar(EntInscricoesEmpresa objInscricoesEmpresa, Boolean flGeraQuestionarios)
        {
            Boolean isNovoCadastro = true;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    EntEmpresaCadastro empCadastro = dalEmpresaCadastro.ObterPorCpfCnpj(objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.CPF_CNPJ, transaction, db);
                    if (empCadastro != null)
                    {
                        empCadastro.AberturaEmpresa = objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.AberturaEmpresa;
                        empCadastro.Ativo = true;
                        empCadastro.CPF_CNPJ = objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.CPF_CNPJ;
                        empCadastro.Estado.IdEstado = objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.Estado.IdEstado;
                        empCadastro.NomeFantasia = objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.NomeFantasia;
                        empCadastro.PessoaJuridica = objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.PessoaJuridica;
                        empCadastro.RazaoSocial = objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.RazaoSocial;
                        objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro = empCadastro;
                        objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro = objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro;
                        dalEmpresaCadastro.Alterar(objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro, transaction, db);
                    }
                    else
                    {
                        objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro = dalEmpresaCadastro.Inserir(objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro, transaction, db);
                    }
                    if (objInscricoesEmpresa.TurmaEmpresa != null && objInscricoesEmpresa.TurmaEmpresa.Turma != null && objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma > 0)
                    {
                        objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.IdEmpresaCadastro = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro;
                        if (new BllTurmaEmpresa().ObterPorTurmaEmpresa(objInscricoesEmpresa.TurmaEmpresa) != null)
                        {
                            objInscricoesEmpresa.TurmaEmpresa.Ativo = !objInscricoesEmpresa.TurmaEmpresa.Ativo;
                            dalTurmaEmpresa.AtivaInativa(objInscricoesEmpresa.TurmaEmpresa, transaction, db);
                            isNovoCadastro = false;
                        }
                        List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterAbertosPorIdTurmaIdEmpresa(objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma, objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
                        Boolean Participa = false;
                        foreach (EntQuestionario eq in listaQuestionarios)
                        {
                            if (eq.EmpresaParticipa)
                            {
                                Participa = true;
                            }
                        }
                        if (Participa)
                        {
                            flGeraQuestionarios = false;
                        }
                        if (dalQuestionarioEmpresa.ObterQuestionarioPorTurmaEmpresa(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro, objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma, transaction, db) != null)
                        {
                            flGeraQuestionarios = false;
                        }

                        dalTurmaEmpresa.Inserir(objInscricoesEmpresa.TurmaEmpresa, transaction, db);

                        objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.IdEmpresaCadastro = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro;

                        if (flGeraQuestionarios)
                        {
                            insereQuestionariosEmpresaIniciais(objInscricoesEmpresa, transaction, db);
                        }
                        else
                        {
                            verificaEtapaQuestionarioEmpresaAberto(objInscricoesEmpresa, transaction, db);
                        }
                    }
                    EntProgramaEmpresa objProgramEmpresaTemp = new BllProgramaEmpresa().ObterPorProgramaEmpresa(objInscricoesEmpresa.ProgramaEmpresa.Programa.IdPrograma, objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
                    if (objProgramEmpresaTemp != null)
                    {
                        if (objInscricoesEmpresa.ProgramaEmpresa.Senha == null || objInscricoesEmpresa.ProgramaEmpresa.Senha == "D41D8CD98F00B204E9800998ECF8427E")
                        {
                            objInscricoesEmpresa.ProgramaEmpresa.Senha = objProgramEmpresaTemp.Senha;
                        }
                        objInscricoesEmpresa.ProgramaEmpresa.EmailResponsavel = objInscricoesEmpresa.TurmaEmpresa.EmailContato;
                        objInscricoesEmpresa.ProgramaEmpresa.IdProgramaEmpresa = objProgramEmpresaTemp.IdProgramaEmpresa;
                        dalProgramaEmpresa.Alterar(objInscricoesEmpresa.ProgramaEmpresa, transaction, db);
                    }
                    else
                    {
                        dalProgramaEmpresa.Inserir(objInscricoesEmpresa.ProgramaEmpresa, transaction, db);
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
            if (objInscricoesEmpresa.TurmaEmpresa.Usuario.IdUsuario > 0)
            {
                if (isNovoCadastro)
                {
                    new BllLogAcao().Inserir(objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma,
                        objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro,
                        objInscricoesEmpresa.TurmaEmpresa.Usuario.IdUsuario,
                        EntTipoAcao.TIPO_ACAO_CADASTRO_EMPRESA);
                }
                else
                {
                    new BllLogAcao().Inserir(objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma,
                        objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro,
                        objInscricoesEmpresa.TurmaEmpresa.Usuario.IdUsuario,
                        EntTipoAcao.TIPO_ACAO_ALTERACAO_EMPRESA);
                }
            }
            return objInscricoesEmpresa;
        }


        /// <summary>
        /// Inclui um InscricoesEmpresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objUsuario">Entidade do InscricoesEmpresa</param>
        /// <returns>Entidade de InscricoesEmpresa</returns>
        public EntInscricoesEmpresa InserirEmpresaAdm(EntInscricoesEmpresa objInscricoesEmpresa)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro = dalEmpresaCadastro.Inserir(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro, transaction, db);

                    dalTurmaEmpresa.Inserir(objInscricoesEmpresa.TurmaEmpresa, transaction, db);

                    objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.IdEmpresaCadastro = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro;

                    dalProgramaEmpresa.Inserir(objInscricoesEmpresa.ProgramaEmpresa, transaction, db);

                    objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.Estado.IdEstado = objInscricoesEmpresa.TurmaEmpresa.Estado.IdEstado;
                    insereQuestionariosEmpresaIniciais(objInscricoesEmpresa, transaction, db);

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
            return objInscricoesEmpresa;
        }


        /// <summary>
        /// Alterar um InscricoesEmpresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objUsuario">Entidade do InscricoesEmpresa</param>
        /// <returns>Entidade de InscricoesEmpresa</returns>
        public EntInscricoesEmpresa AlterarEmpresaAdm(EntInscricoesEmpresa objInscricoesEmpresa)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalEmpresaCadastro.Alterar(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro, transaction, db);

                    // Verifica se a empresa ja tem uma turma cadastrata para a turma corrente

                    //if (objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma > 0 && objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma == IdTurmaCorrente)
                    //{


                    //new BllQuestionarioEmpresa().Inserir(

                    dalTurmaEmpresa.AtivaInativa(objInscricoesEmpresa.TurmaEmpresa, transaction, db);

                    dalTurmaEmpresa.Inserir(objInscricoesEmpresa.TurmaEmpresa, transaction, db);

                    //   dalProgramaEmpresa.Alterar(objInscricoesEmpresa.ProgramaEmpresa, transaction, db);
                    //}
                    //else
                    //{
                    //    dalTurmaEmpresa.Inserir(objInscricoesEmpresa.TurmaEmpresa, transaction, db);

                    //    objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.IdEmpresaCadastro = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro;

                    //    dalProgramaEmpresa.Inserir(objInscricoesEmpresa.ProgramaEmpresa, transaction, db);
                    //}


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
            return objInscricoesEmpresa;
        }


        /// <summary>
        /// Retorna um Inscricao Empresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntInscricaoEmpresa">EntInscricaoEmpresa</returns>
        public EntInscricoesEmpresa ObterPorIdEmpresaPrograma(Int32 IdEmpresa, Int32 IdPrograma)
        {
            EntInscricoesEmpresa objInscricoesEmpresa = new EntInscricoesEmpresa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objInscricoesEmpresa.TurmaEmpresa = dalTurmaEmpresa.ObterPorIdEmpresaIdPrograma(IdEmpresa, IdPrograma, transaction, db);
                    objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro = dalEmpresaCadastro.ObterPorId(IdEmpresa, transaction, db);
                    objInscricoesEmpresa.TurmaEmpresa.Turma = dalTurma.ObterPorId(objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma, transaction, db);
                    objInscricoesEmpresa.ProgramaEmpresa = dalProgramaEmpresa.ObterPorId(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro, IdPrograma, transaction, db);
                    objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro;
                    objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomica = dalAtividadeEconomica.ObterPorId(objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomica.IdAtividadeEconomica, transaction, db);
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
            return objInscricoesEmpresa;
        }

        /// <summary>
        /// Retorna um Inscricao Empresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <returns><type="EntInscricaoEmpresa">EntInscricaoEmpresa</returns>
        public EntInscricoesEmpresa ObterPorIdEmpresaTurma(EntTurmaEmpresa objTurmaEmpresa, Int32 IdPrograma)
        {
            EntInscricoesEmpresa objInscricoesEmpresa = new EntInscricoesEmpresa();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    objInscricoesEmpresa.TurmaEmpresa = dalTurmaEmpresa.ObterPorTurmaEmpresa(objTurmaEmpresa, transaction, db);
                    objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro = dalEmpresaCadastro.ObterPorId(objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro, transaction, db);
                    objInscricoesEmpresa.TurmaEmpresa.Turma = dalTurma.ObterPorId(objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma, transaction, db);
                    objInscricoesEmpresa.ProgramaEmpresa = dalProgramaEmpresa.ObterPorProgramaEmpresa(IdPrograma, objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro, transaction, db);
                    objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro;
                    objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomica = dalAtividadeEconomica.ObterPorId(objInscricoesEmpresa.TurmaEmpresa.AtividadeEconomica.IdAtividadeEconomica, transaction, db);
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
            return objInscricoesEmpresa;
        }

        /// <summary>
        /// Inclui um InscricoesEmpresa com GrupoEmpresa
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="objInscricoesEmpresa">Entidade do InscricoesEmpresa</param>
        /// <returns>Entidade de InscricoesEmpresa</returns>
        public EntInscricoesEmpresa InserirAdministrativo(EntInscricoesEmpresa objInscricoesEmpresa, EntGrupoEmpresa objGrupoEmpresa)
        {
            EntInscricoesEmpresa objRetorno = null;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    dalEmpresaCadastro.Inserir(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro, transaction, db);
                    dalTurmaEmpresa.Inserir(objInscricoesEmpresa.TurmaEmpresa, transaction, db);
                    objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.IdEmpresaCadastro = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro;
                    dalProgramaEmpresa.Inserir(objInscricoesEmpresa.ProgramaEmpresa, transaction, db);
                    new DalGrupoEmpresa().Inserir(objGrupoEmpresa, transaction, db);

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
        /// Altera um InscricoesEmpresa com GrupoEmpresa
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="objInscricoesEmpresa">Entidade de InscricoesEmpresa</param>
        public void AlterarAdministrativo(EntInscricoesEmpresa objInscricoesEmpresa, EntGrupoEmpresa objGrupoEmpresa)
        {

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    dalEmpresaCadastro.Alterar(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro, transaction, db);
                    dalTurmaEmpresa.AtivaInativa(objInscricoesEmpresa.TurmaEmpresa, transaction, db);
                    dalProgramaEmpresa.Alterar(objInscricoesEmpresa.ProgramaEmpresa, transaction, db);
                    //new DalGrupoEmpresa().ExcluirTodosPorTurmaEmpresa(objInscricoesEmpresa.TurmaEmpresa, transaction, db);
                    new DalGrupoEmpresa().Inserir(objGrupoEmpresa, transaction, db);

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
        /// Ativa ou Inativa uma InscricoesEmpresa
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="objInscricoesEmpresa">Entidade de InscricoesEmpresa</param>
        public void AtivaInativa(EntTurmaEmpresa objTurmaEmpresa)
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
        /// Ativa ou Inativa a Participacao
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="objInscricoesEmpresa">Entidade de InscricoesEmpresa</param>
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

        private void verificaEtapaQuestionarioEmpresaAberto(EntInscricoesEmpresa objInscricoesEmpresa, DbTransaction transaction, Database db)
        {
            List<EntQuestionarioEmpresa> listQuestionarioEmpresa = dalQuestionarioEmpresa.ObterQuestionarioPorTurmaEmpresa(objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro, objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma, transaction, db);
            if (listQuestionarioEmpresa != null)
            {
                foreach (EntQuestionarioEmpresa objQuestionarioEmpresa in listQuestionarioEmpresa)
                {
                    EntEtapa objEtapa = dalEtapa.ObterPorId(objQuestionarioEmpresa.Etapa.IdEtapa, transaction, db);
                    EntEtapa objEtapaTemp = dalEtapa.ObterPorTipoEtapaTurma(objEtapa.TipoEtapa.IdTipoEtapa, objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma, objInscricoesEmpresa.TurmaEmpresa.Estado.IdEstado, transaction, db);
                    if (objEtapa.IdEtapa != objEtapaTemp.IdEtapa)
                    {
                        objQuestionarioEmpresa.Etapa = objEtapaTemp;
                        dalQuestionarioEmpresa.Alterar(objQuestionarioEmpresa, transaction, db);
                    }
                }
            }
        }

        private void insereQuestionariosEmpresaIniciais(EntInscricoesEmpresa objInscricoesEmpresa, DbTransaction transaction, Database db)
        {
            List<EntQuestionario> listaQuestionariosObrigatorios = dalQuestionario.ObterObrigatoriosPorIdTurma(objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma, transaction, db);
            foreach (EntQuestionario q in listaQuestionariosObrigatorios)
            {
                EntQuestionarioEmpresa qeTemp = dalQuestionarioEmpresa.ObterQuestionarioPorTurmaQuestionarioEmpresa(q.IdQuestionario, objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro, objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma, transaction, db);
                if (qeTemp == null)
                {
                    EntQuestionarioEmpresa qe = new EntQuestionarioEmpresa();
                    qe.Ativo = false;
                    qe.DtCadastro = DateTime.Now;
                    qe.DtAlteracao = DateTime.Now;
                    qe.PreencheQuestionario = true;
                    qe.EmpresaCadastro.IdEmpresaCadastro = objInscricoesEmpresa.TurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro;
                    qe.Programa.IdPrograma = objInscricoesEmpresa.ProgramaEmpresa.Programa.IdPrograma;
                    qe.Questionario.IdQuestionario = q.IdQuestionario;
                    if (objInscricoesEmpresa.TurmaEmpresa.Usuario.IdUsuario > 0)
                    {
                        qe.Usuario.IdUsuario = objInscricoesEmpresa.TurmaEmpresa.Usuario.IdUsuario;
                        if (objInscricoesEmpresa.ProgramaEmpresa.Programa.IdPrograma == EntPrograma.PROGRAMA_MPE)
                            qe.Etapa.TipoEtapa.IdTipoEtapa = EntTipoEtapa.TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_ADMINISTRATIVO;
                        else if (objInscricoesEmpresa.ProgramaEmpresa.Programa.IdPrograma == EntPrograma.PROGRAMA_FGA)
                            qe.Etapa.TipoEtapa.IdTipoEtapa = EntTipoEtapa.TIPO_ETAPA_FGA_INSCRICAO_AUTODIAGNOSTICO_ADMINISTRATIVO;
                        else if (objInscricoesEmpresa.ProgramaEmpresa.Programa.IdPrograma == EntPrograma.PROGRAMA_PEG)
                            qe.Etapa.TipoEtapa.IdTipoEtapa = EntTipoEtapa.TIPO_ETAPA_PEG_INSCRICAO_AUTODIAGNOSTICO_ADMINISTRATIVO;
                    }
                    else
                    {
                        if (objInscricoesEmpresa.ProgramaEmpresa.Programa.IdPrograma == EntPrograma.PROGRAMA_MPE)
                            qe.Etapa.TipoEtapa.IdTipoEtapa = EntTipoEtapa.TIPO_ETAPA_MPE_INSCRICAO_CANDIDATURA_EMPRESA;
                        else if (objInscricoesEmpresa.ProgramaEmpresa.Programa.IdPrograma == EntPrograma.PROGRAMA_FGA)
                            qe.Etapa.TipoEtapa.IdTipoEtapa = EntTipoEtapa.TIPO_ETAPA_FGA_INSCRICAO_AUTODIAGNOSTICO_EMPRESA;
                        else if (objInscricoesEmpresa.ProgramaEmpresa.Programa.IdPrograma == EntPrograma.PROGRAMA_PEG)
                            qe.Etapa.TipoEtapa.IdTipoEtapa = EntTipoEtapa.TIPO_ETAPA_PEG_INSCRICAO_AUTODIAGNOSTICO_EMPRESA;
                    }
                    qe.Etapa = dalEtapa.ObterPorTipoEtapaTurma(qe.Etapa.TipoEtapa.IdTipoEtapa, objInscricoesEmpresa.TurmaEmpresa.Turma.IdTurma, objInscricoesEmpresa.ProgramaEmpresa.EmpresaCadastro.Estado.IdEstado, transaction, db);
                    qe.ParaAvaliador = false;
                    dalQuestionarioEmpresa.Inserir(qe, transaction, db);
                }
            }
        }
    }
}
