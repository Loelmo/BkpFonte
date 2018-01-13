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
    /// Classe de Dados que representa uma TurmaEmpresa
    /// </summary>
    public class DalAuxiliar
    {

        public EntTurmaEmpresa Inserir(EntTurmaEmpresa objTurmaEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereTurmaEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nCEA_CATEGORIA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Categoria.IdCategoria));
            db.AddInParameter(dbCommand, "@nCEA_ATIVIDADE_ECONOMICA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.AtividadeEconomica.IdAtividadeEconomica));
            db.AddInParameter(dbCommand, "@nCEA_FATURAMENTO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Faturamento.IdFaturamento));
            db.AddInParameter(dbCommand, "@nNU_FUNCIONARIO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.NumeroFuncionario));
            db.AddInParameter(dbCommand, "@sTX_CEP", DbType.String, objTurmaEmpresa.CEP);
            db.AddInParameter(dbCommand, "@sTX_ENDERECO", DbType.String, objTurmaEmpresa.Endereco);
            db.AddInParameter(dbCommand, "@sTX_COMPLEMENTO", DbType.String, objTurmaEmpresa.Complemento);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objTurmaEmpresa.Ativo);
            db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Usuario.IdUsuario));
            db.AddInParameter(dbCommand, "@nCEA_CIDADE", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Cidade.IdCidade));
            db.AddInParameter(dbCommand, "@dDT_ULTIMA_ALTERACAO", DbType.DateTime, System.DateTime.Now);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Estado.IdEstado));
            db.AddInParameter(dbCommand, "@nCEA_PAIS", DbType.Int32, 1);
            db.AddInParameter(dbCommand, "@dDT_CADASTRO", DbType.DateTime, System.DateTime.Now);
            db.AddInParameter(dbCommand, "@sTX_ATIVIDADE_ECONOMICA", DbType.String, objTurmaEmpresa.AtividadeEconomicaComplemento);
            db.AddInParameter(dbCommand, "@bFL_PARTICIPA_PROGRAMA", DbType.Boolean, objTurmaEmpresa.ParticipaPrograma);
            db.AddInParameter(dbCommand, "@sTX_NOME_CONTATO", DbType.String, objTurmaEmpresa.NomeContato);
            db.AddInParameter(dbCommand, "@sTX_TELEFONE_CONTATO", DbType.String, objTurmaEmpresa.TelefoneContato);
            db.AddInParameter(dbCommand, "@sTX_CELULAR_CONTATO", DbType.String, objTurmaEmpresa.CelularContato);
            db.AddInParameter(dbCommand, "@sTX_EMAIL_CONTATO", DbType.String, objTurmaEmpresa.EmailContato);
            db.AddInParameter(dbCommand, "@sTX_MENSAGEM_CONTATO", DbType.String, objTurmaEmpresa.MensagemContato);
            db.AddInParameter(dbCommand, "@sTX_CPF_CONTATO", DbType.String, objTurmaEmpresa.CPFContato);
            db.AddInParameter(dbCommand, "@dDT_DATA_NASCIMENTO_CONTATO", DbType.DateTime, objTurmaEmpresa.NascimentoContato);
            db.AddInParameter(dbCommand, "@sTX_ENDERECO_CONTATO", DbType.String, objTurmaEmpresa.EnderecoContato);
            db.AddInParameter(dbCommand, "@sTX_SEXO_CONTATO", DbType.String, objTurmaEmpresa.SexoContato);
            db.AddInParameter(dbCommand, "@nCEA_NIVEL_ESCOLARIDADE", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.ContatoNivelEscolaridade.IdContatoNivelEscolaridade));
            db.AddInParameter(dbCommand, "@nCEA_FAIXA_ETARIA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.FaixaEtaria.IdContatoFaixaEtaria));
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Turma.IdTurma));
            db.AddInParameter(dbCommand, "@nCEA_TIPO_EMPRESA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.TipoEmpresa.IdTipoEmpresa));
            db.AddInParameter(dbCommand, "@nCEA_BAIRRO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Bairro.IdBairro));
            db.AddInParameter(dbCommand, "@nCEA_CARGO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Cargo.IdCargo));
            db.AddInParameter(dbCommand, "@sTX_CEP_CONTATO", DbType.String, objTurmaEmpresa.CEPContato);
            db.AddInParameter(dbCommand, "@bFL_PERGUNTA1", DbType.Boolean, objTurmaEmpresa.Pergunta1);
            db.AddInParameter(dbCommand, "@bFL_PERGUNTA2", DbType.Boolean, objTurmaEmpresa.Pergunta2);
            db.AddInParameter(dbCommand, "@bFL_PERGUNTA3", DbType.Boolean, objTurmaEmpresa.Pergunta3);
            db.AddInParameter(dbCommand, "@bFL_PERGUNTA4", DbType.Boolean, objTurmaEmpresa.Pergunta4);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO_CONTATO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.EstadoContato.IdEstado));
            db.AddInParameter(dbCommand, "@nCEA_CIDADE_CONTATO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.CidadeContato.IdCidade));
            db.AddInParameter(dbCommand, "@nCEA_BAIRRO_CONTATO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.BairroContato.IdBairro));

            db.ExecuteNonQuery(dbCommand, transaction);

            return objTurmaEmpresa;
        }

        public void Alterar(EntTurmaEmpresa objTurmaEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaTurmaEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, objTurmaEmpresa.Ativo);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        public List<EntTurmaEmpresa> ObterTodasInscritasPorEstado(String estado, Int32 programaId, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_Auxiliar_SelecionaTurmaEmpresaPorEstado");
            db.AddInParameter(dbCommand, "@Estado", DbType.String, estado);
            db.AddInParameter(dbCommand, "@Programa", DbType.Int32, programaId);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntTurmaEmpresa>();
                }
            }
        }

        public EntQuestionarioEmpresa ObterDadosQuestionarioEmpresa(EntQuestionarioEmpresa questionarioEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_Auxiliar_QuestionarioAvaliadorPorEmpresaPrograma");
            db.AddInParameter(dbCommand, "@QuestionarioEmpresa", DbType.Int32, questionarioEmpresa.IdQuestionarioEmpresa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    questionarioEmpresa.ListQuestionarioEmpresaAvaliador = this.PopularListAvaliador(dtrDados, true);
                }
            }
            dbCommand = db.GetStoredProcCommand("STP_Auxiliar_QuestionarioAcompanhantePorEmpresaPrograma");
            db.AddInParameter(dbCommand, "@QuestionarioEmpresa", DbType.Int32, questionarioEmpresa.IdQuestionarioEmpresa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    questionarioEmpresa.ListQuestionarioEmpresaAvaliador.AddRange(this.PopularListAvaliador(dtrDados, false));
                }
            }
/*            dbCommand = db.GetStoredProcCommand("STP_Auxiliar_QuestionarioRespostaPorEmpresaPrograma");
            db.AddInParameter(dbCommand, "@QuestionarioEmpresa", DbType.Int32, questionarioEmpresa.IdQuestionarioEmpresa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    questionarioEmpresa.ListQuestionarioEmpresaResposta = this.PopularListResposta(dtrDados);
                }
            }*/
            dbCommand = db.GetStoredProcCommand("STP_Auxiliar_QuestionarioPontuacaoPorEmpresaPrograma");
            db.AddInParameter(dbCommand, "@QuestionarioEmpresa", DbType.Int32, questionarioEmpresa.IdQuestionarioEmpresa);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    questionarioEmpresa.ListQuestionarioPontuacao = this.PopularListPontuacao(dtrDados);
                    questionarioEmpresa.TotalPontuacao = 0;
                    questionarioEmpresa.TotalPontuacaoAvaliacao = 0;
                    foreach (EntQuestionarioPontuacao pont in questionarioEmpresa.ListQuestionarioPontuacao)
                    {
                        if (pont.Avaliador)
                        {
                            questionarioEmpresa.TotalPontuacaoAvaliacao += pont.Ponto;
                        }
                        else
                        {
                            questionarioEmpresa.TotalPontuacao += pont.Ponto;
                        }
                    }
                }
            }

            return questionarioEmpresa;
        }

        public List<EntQuestionarioEmpresa> ObterQuestionarioEmpresa(Int32 IdEmpresaCadastro, Int32 programaId, Boolean ParticipaEmpreendedorismo, Boolean ParticipaResponsabilidadeSocial, DbTransaction transaction, Database db)
        {
            List<EntQuestionarioEmpresa> temp = new List<EntQuestionarioEmpresa>();

            DbCommand dbCommand = db.GetStoredProcCommand("STP_Auxiliar_QuestionarioEmpresaStatusPorEmpresaPrograma1");
            db.AddInParameter(dbCommand, "@Empresa", DbType.Int32, IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@Programa", DbType.Int32, programaId);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    temp = this.PopularQuestionarioEmpresa(dtrDados);
                }
            }
            if (ParticipaEmpreendedorismo)
            {
                dbCommand = db.GetStoredProcCommand("STP_Auxiliar_QuestionarioEmpresaStatusPorEmpresaPrograma2");
                db.AddInParameter(dbCommand, "@Empresa", DbType.Int32, IdEmpresaCadastro);
                db.AddInParameter(dbCommand, "@Programa", DbType.Int32, programaId);
                dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

                using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
                {
                    if (dtrDados != null && dtrDados.HasRows)
                    {
                        temp.AddRange(this.PopularQuestionarioEmpresa(dtrDados));
                    }
                }
            }
            if (ParticipaResponsabilidadeSocial)
            {
                dbCommand = db.GetStoredProcCommand("STP_Auxiliar_QuestionarioEmpresaStatusPorEmpresaPrograma3");
                db.AddInParameter(dbCommand, "@Empresa", DbType.Int32, IdEmpresaCadastro);
                db.AddInParameter(dbCommand, "@Programa", DbType.Int32, programaId);
                dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

                using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
                {
                    if (dtrDados != null && dtrDados.HasRows)
                    {
                        temp.AddRange(this.PopularQuestionarioEmpresa(dtrDados));
                    }
                }
            }
            return temp;
        }

        public EntAtividadeEconomica ObterAtividadeEconomicaPorNome(String nome, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_Auxiliar_ObterAtividadeEconomicaPorNome");
            db.AddInParameter(dbCommand, "@Nome", DbType.String, nome);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            EntAtividadeEconomica temp = new EntAtividadeEconomica();

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados.Read())
                {
                    temp.IdAtividadeEconomica = ObjectUtils.ToInt(dtrDados["CDA_ATIVIDADE_ECONOMICA"]);
                }
            }
            return temp;
        }

        public EntCategoria ObterCategoriaPorNome(String nome, DbTransaction transaction, Database db)
        {
            EntCategoria temp = new EntCategoria();
            if (nome.Equals("INDÚSTRIA"))
            {
                temp.IdCategoria = 1;
            }
            else if (nome.Equals("COMÉRCIO"))
            {
                temp.IdCategoria = 2;
            }
            else if (nome.Equals("SERVIÇOS"))
            {
                temp.IdCategoria = 3;
            }
            else if (nome.Equals("AGRONEGÓCIO"))
            {
                temp.IdCategoria = 4;
            }
            else if (nome.Equals("SERVIÇOS DE TURISMO"))
            {
                temp.IdCategoria = 38;
            }
            else if (nome.Equals("SERVIÇOS DE SAÚDE"))
            {
                temp.IdCategoria = 39;
            }
            else if (nome.Equals("SERVIÇOS DE EDUCAÇÃO"))
            {
                temp.IdCategoria = 40;
            }
            else if (nome.Equals("SERVIÇOS DE TECNOLOGIA DA INFORMAÇÃO"))
            {
                temp.IdCategoria = 41;
            }
            return temp;
        }

        public EntCargo ObterCargoPorNome(String nome, DbTransaction transaction, Database db)
        {
            EntCargo temp = new EntCargo();
            if (nome.Equals("ADMINISTRADOR"))
            {
                temp.IdCargo = 1;
            }
            else if (nome.Equals("ADVOGADO"))
            {
                temp.IdCargo = 2;
            }
            else if (nome.Equals("ANALISTA"))
            {
                temp.IdCargo = 3;
            }
            else if (nome.Equals("ASSESSOR"))
            {
                temp.IdCargo = 4;
            }
            else if (nome.Equals("ASSOCIADO"))
            {
                temp.IdCargo = 5;
            }
            else if (nome.Equals("AUXILIAR"))
            {
                temp.IdCargo = 6;
            }
            else if (nome.Equals("CONSELHEIRO"))
            {
                temp.IdCargo = 7;
            }
            else if (nome.Equals("CONSULTOR"))
            {
                temp.IdCargo = 8;
            }
            else if (nome.Equals("CONTADOR"))
            {
                temp.IdCargo = 9;
            }
            else if (nome.Equals("COOPERADO"))
            {
                temp.IdCargo = 10;
            }
            else if (nome.Equals("DEPUTADO"))
            {
                temp.IdCargo = 11;
            }
            else if (nome.Equals("DIRETOR"))
            {
                temp.IdCargo = 12;
            }
            else if (nome.Equals("ESTUDANTE"))
            {
                temp.IdCargo = 13;
            }
            else if (nome.Equals("GERENTE"))
            {
                temp.IdCargo = 14;
            }
            else if (nome.Equals("GOVERNADOR"))
            {
                temp.IdCargo = 15;
            }
            else if (nome.Equals("OUTROS"))
            {
                temp.IdCargo = 16;
            }
            else if (nome.Equals("PREFEITO"))
            {
                temp.IdCargo = 17;
            }
            else if (nome.Equals("PRESIDENTE"))
            {
                temp.IdCargo = 18;
            }
            else if (nome.Equals("PROCURADOR"))
            {
                temp.IdCargo = 19;
            }
            else if (nome.Equals("PROPRIETARIO"))
            {
                temp.IdCargo = 20;
            }
            else if (nome.Equals("REPRESENTANTE"))
            {
                temp.IdCargo = 21;
            }
            else if (nome.Equals("SECRETÁRIO"))
            {
                temp.IdCargo = 22;
            }
            else if (nome.Equals("SENADOR"))
            {
                temp.IdCargo = 23;
            }
            else if (nome.Equals("SUB-GERENTE"))
            {
                temp.IdCargo = 24;
            }
            else if (nome.Equals("SUB-SECRETÁRIO"))
            {
                temp.IdCargo = 25;
            }
            else if (nome.Equals("SUPERINTENDENTE"))
            {
                temp.IdCargo = 26;
            }
            else if (nome.Equals("TÉCNICO"))
            {
                temp.IdCargo = 27;
            }
            else if (nome.Equals("VENDEDOR"))
            {
                temp.IdCargo = 28;
            }
            else if (nome.Equals("VEREADOR"))
            {
                temp.IdCargo = 29;
            }
            else if (nome.Equals("VICE-PREFEITO"))
            {
                temp.IdCargo = 30;
            }
            else if (nome.Equals("VICE-PRESIDENTE"))
            {
                temp.IdCargo = 31;
            }
            return temp;
        }

        public EntEstado ObterEstadoPorNome(String nome, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_Auxiliar_ObterEstadoPorNome");
            db.AddInParameter(dbCommand, "@Nome", DbType.String, nome);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            EntEstado temp = new EntEstado();

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados.Read())
                {
                    temp.IdEstado = ObjectUtils.ToInt(dtrDados["CDA_ESTADO"]);
                }
            }
            return temp;
        }

        public EntCidade ObterCidadePorNome(String nome, Int32 idEstado, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_Auxiliar_ObterCidadePorNome");
            db.AddInParameter(dbCommand, "@Nome", DbType.String, nome);
            db.AddInParameter(dbCommand, "@idEstado", DbType.Int32, idEstado);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            EntCidade temp = new EntCidade();

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados.Read())
                {
                    temp.IdCidade = ObjectUtils.ToInt(dtrDados["CDA_CIDADE"]);
                }
            }
            return temp;
        }

        public EntContatoNivelEscolaridade ObterNivelEscolaridadePorNome(String nome, DbTransaction transaction, Database db)
        {
            EntContatoNivelEscolaridade temp = new EntContatoNivelEscolaridade();
            if (nome.Equals("Ensino Fundamental Incompleto"))
            {
                temp.IdContatoNivelEscolaridade = 1;
            }
            else if (nome.Equals("Ensino Fundamental Completo"))
            {
                temp.IdContatoNivelEscolaridade = 2;
            }
            else if (nome.Equals("Ensino Médio Incompleto"))
            {
                temp.IdContatoNivelEscolaridade = 3;
            }
            else if (nome.Equals("Ensino Médio Completo"))
            {
                temp.IdContatoNivelEscolaridade = 4;
            }
            else if (nome.Equals("Superior Incompleto"))
            {
                temp.IdContatoNivelEscolaridade = 5;
            }
            else if (nome.Equals("Superior Completo"))
            {
                temp.IdContatoNivelEscolaridade = 6;
            }
            else if (nome.Equals("Especialização"))
            {
                temp.IdContatoNivelEscolaridade = 7;
            }
            else if (nome.Equals("Pós-Graduação"))
            {
                temp.IdContatoNivelEscolaridade = 8;
            }
            else if (nome.Equals("Mestrado"))
            {
                temp.IdContatoNivelEscolaridade = 9;
            }
            else if (nome.Equals("Doutorado"))
            {
                temp.IdContatoNivelEscolaridade = 10;
            }
            else if (nome.Equals("Analfabeto"))
            {
                temp.IdContatoNivelEscolaridade = 15;
            }
            else if (nome.Equals("Sem Formação"))
            {
                temp.IdContatoNivelEscolaridade = 16;
            }
            return temp;
        }

        public EntContatoFaixaEtaria ObterFaixaEtariaPorNome(String nome, DbTransaction transaction, Database db)
        {
            EntContatoFaixaEtaria temp = new EntContatoFaixaEtaria();
            if (nome.Equals("Menos de 25 anos"))
            {
                temp.IdContatoFaixaEtaria = 1;
            }
            else if (nome.Equals("Entre 25 e 29"))
            {
                temp.IdContatoFaixaEtaria = 2;
            }
            else if (nome.Equals("Entre 30 e 34"))
            {
                temp.IdContatoFaixaEtaria = 3;
            }
            else if (nome.Equals("Entre 35 e 39"))
            {
                temp.IdContatoFaixaEtaria = 4;
            }
            else if (nome.Equals("Entre 40 e 44"))
            {
                temp.IdContatoFaixaEtaria = 5;
            }
            else if (nome.Equals("Entre 45 e 49"))
            {
                temp.IdContatoFaixaEtaria = 6;
            }
            else if (nome.Equals("Acima de 50"))
            {
                temp.IdContatoFaixaEtaria = 7;
            }
            return temp;
        }

        public EntFaturamento ObterFaturamentoPorNome(String nome, DbTransaction transaction, Database db)
        {
            EntFaturamento temp = new EntFaturamento();
            if (nome.Equals("Até R$ 120.000,00"))
            {
                temp.IdFaturamento = 1;
            }
            else if (nome.Equals("de R$ 120.001,00 a R$ 240.000,00"))
            {
                temp.IdFaturamento = 2;
            }
            else if (nome.Equals("de R$ 240.001,00 a R$ 600.000,00"))
            {
                temp.IdFaturamento = 3;
            }
            else if (nome.Equals("de R$ 600.001,00 a R$ 1.200.000,00"))
            {
                temp.IdFaturamento = 4;
            }
            else if (nome.Equals("de R$ 1.200.001,00 a R$ 1.800.000,00"))
            {
                temp.IdFaturamento = 5;
            }
            else if (nome.Equals("de R$ 1.800.001,00 a R$ 2.400.000,00"))
            {
                temp.IdFaturamento = 6;
            }
            else if (nome.Equals("0,00 a 240.000,00"))
            {
                temp.IdFaturamento = 50;
            }
            else if (nome.Equals("240.001,00 a 1.200.000,00"))
            {
                temp.IdFaturamento = 51;
            }
            else if (nome.Equals("1.200.001,00 a 2.400.000,00"))
            {
                temp.IdFaturamento = 52;
            }
            else if (nome.Equals("acima de 2.400.000,00"))
            {
                temp.IdFaturamento = 53;
            }
            return temp;
        }

        public EntTipoEmpresa ObterTipoEmpresaPorNome(String nome, DbTransaction transaction, Database db)
        {
            EntTipoEmpresa temp = new EntTipoEmpresa();
            if (nome.Equals("Matriz"))
            {
                temp.IdTipoEmpresa = 1;
            }
            else if (nome.Equals("Filial"))
            {
                temp.IdTipoEmpresa = 2;
            }
            else if (nome.Equals("Associação / Cooperativa"))
            {
                temp.IdTipoEmpresa = 3;
            }
            else if (nome.Equals("Outros"))
            {
                temp.IdTipoEmpresa = 4;
            }
            return temp;
        }

        public EntAdmUsuario ObterUsuarioPorEmail(String nome, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_Auxiliar_ObterUsuarioPorEmail");
            db.AddInParameter(dbCommand, "@Nome", DbType.String, nome);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;
            EntAdmUsuario temp = new EntAdmUsuario();

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados.Read())
                {
                    temp.IdUsuario = ObjectUtils.ToInt(dtrDados["CDA_USUARIO"]);
                }
            }
            return temp;
        }

        private List<EntTurmaEmpresa> Popular(DbDataReader dtrDados)
        {
            List<EntTurmaEmpresa> listEntReturn = new List<EntTurmaEmpresa>();
            EntTurmaEmpresa entReturn;

            try
            {
                foreach (DbDataRecord DataRecord in dtrDados)
                {
                    entReturn = PopularRow(DataRecord);
                    if (listEntReturn.Count == 0 || entReturn.EmpresaCadastro.CPF_CNPJ != listEntReturn[listEntReturn.Count - 1].EmpresaCadastro.CPF_CNPJ)
                    {
                        listEntReturn.Add(entReturn);
                    }
                }

                dtrDados.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listEntReturn;
        }

        private EntTurmaEmpresa PopularRow(DbDataRecord dtrDados)
        {
            EntTurmaEmpresa entReturn;

            try
            {
                entReturn = new EntTurmaEmpresa();

                entReturn.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO"]);
                entReturn.EmpresaCadastro.CPF_CNPJ = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                entReturn.Categoria.Categoria = ObjectUtils.ToString(dtrDados["TX_CATEGORIA"]);
                entReturn.AtividadeEconomica.AtividadeEconomica = ObjectUtils.ToString(dtrDados["TX_RAMO_ATIVIDADE"]);
                entReturn.Faturamento.Faturamento = ObjectUtils.ToString(dtrDados["TX_FATURAMENTO"]);
                entReturn.NumeroFuncionario = ObjectUtils.ToInt(dtrDados["NU_FUNCIONARIO"]);
                entReturn.CEP = ObjectUtils.ToString(dtrDados["TX_CEP"]);
                entReturn.Endereco = ObjectUtils.ToString(dtrDados["TX_ENDERECO"]);
                entReturn.Complemento = ObjectUtils.ToString(dtrDados["TX_COMPLEMENTO"]);
                entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                entReturn.Usuario.Email = ObjectUtils.ToString(dtrDados["EMAIL_USUARIO"]);
                entReturn.Cidade.Cidade = ObjectUtils.ToString(dtrDados["TX_CIDADE"]);
                entReturn.UltimaAlteracao = ObjectUtils.ToDate(dtrDados["DT_ULTIMA_ALTERACAO"]);
                entReturn.Estado.Estado = ObjectUtils.ToString(dtrDados["CEA_ESTADO"]);
                entReturn.Pais.IdPais = 1;
                entReturn.Cadastro = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                entReturn.AtividadeEconomicaComplemento = ObjectUtils.ToString(dtrDados["TX_ATIVIDADE_ECONOMICA"]);
                entReturn.ParticipaPrograma = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPA_PROGRAMA"]);
                entReturn.NomeContato = ObjectUtils.ToString(dtrDados["TX_NOME_CONTATO"]);
                entReturn.TelefoneContato = ObjectUtils.ToString(dtrDados["TX_TELEFONE_CONTATO"]);
                entReturn.CelularContato = ObjectUtils.ToString(dtrDados["TX_CELULAR_CONTATO"]);
                entReturn.EmailContato = ObjectUtils.ToString(dtrDados["TX_EMAIL_CONTATO"]);
                entReturn.MensagemContato = ObjectUtils.ToString(dtrDados["TX_MENSAGEM_CONTATO"]);
                entReturn.CPFContato = ObjectUtils.ToString(dtrDados["TX_CPF"]);
                entReturn.NascimentoContato = DateUtils.ToDateTime(ObjectUtils.ToString(dtrDados["tx_data_nascimento"]));
                entReturn.EnderecoContato = ObjectUtils.ToString(dtrDados["TX_ENDERECO_CONTATO"]);
                entReturn.SexoContato = ObjectUtils.ToString(dtrDados["TX_SEXO"]);
                entReturn.ContatoNivelEscolaridade.ContatoNivelEscolaridade = ObjectUtils.ToString(dtrDados["TX_NIVEL_ESCOLARIDADE"]);
                entReturn.FaixaEtaria.ContatoFaixaEtaria = ObjectUtils.ToString(dtrDados["TX_FAIXA_ETARIA"]);
                entReturn.Turma.IdTurma = DePara(ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]));
                entReturn.TipoEmpresa.TipoEmpresa = ObjectUtils.ToString(dtrDados["TX_TIPO_EMPRESA"]);
                entReturn.Bairro.Bairro = ObjectUtils.ToString(dtrDados["TX_BAIRRO"]);
                entReturn.Cargo.Cargo = ObjectUtils.ToString(dtrDados["TX_CARGO"]);
                entReturn.Pergunta1 = ObjectUtils.ToBoolean(dtrDados["FL_PERGUNTA1"]);
                entReturn.Pergunta2 = ObjectUtils.ToBoolean(dtrDados["FL_PERGUNTA2"]);
                entReturn.Pergunta3 = ObjectUtils.ToBoolean(dtrDados["FL_PERGUNTA3"]);
                entReturn.Pergunta4 = ObjectUtils.ToBoolean(dtrDados["FL_PERGUNTA4"]);
                entReturn.EstadoContato.Estado = ObjectUtils.ToString(dtrDados["CEA_ESTADO_CONTATO"]);
                entReturn.CidadeContato.Cidade = ObjectUtils.ToString(dtrDados["tx_cidade_contato"]);
                entReturn.ParticipaEmpreendedorismo = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPA_EMPREENDEDOR"]);
                entReturn.ParticipaResponsabilidadeSocial = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPA_RESP_SOCIAL"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entReturn;
        }

        private List<EntQuestionarioEmpresa> PopularQuestionarioEmpresa(DbDataReader dtrDados)
        {
            List<EntQuestionarioEmpresa> listEntReturn = new List<EntQuestionarioEmpresa>();
            EntQuestionarioEmpresa entReturn;

            try
            {
                foreach (DbDataRecord DataRecord in dtrDados)
                {
                    entReturn = PopularRowQuestionarioEmpresa(DataRecord);
                    if (listEntReturn.Count > 0)
                    {
                        listEntReturn[listEntReturn.Count - 1].PassaProximaEtapa = true;
                    }
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

        private EntQuestionarioEmpresa PopularRowQuestionarioEmpresa(DbDataRecord dtrDados)
        {
            EntQuestionarioEmpresa entReturn;

            try
            {
                entReturn = new EntQuestionarioEmpresa();

                entReturn.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CDA_EMP_CADASTRO"]);
                entReturn.EmpresaCadastro.CPF_CNPJ = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                entReturn.Programa.IdPrograma = DeParaPrograma(ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]));
                entReturn.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
                entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                entReturn.DtAlteracao = ObjectUtils.ToDate(dtrDados["DT_ALTERACAO"]);
                entReturn.DtCadastro = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                entReturn.Usuario.Email = ObjectUtils.ToString(dtrDados["tx_email_usuario"]);
                entReturn.Protocolo = ObjectUtils.ToString(dtrDados["TX_PROTOCOLO"]);
                entReturn.MotivoVenceu = ObjectUtils.ToString(dtrDados["TX_MOTIVO_VENCEU"]) + ObjectUtils.ToString(dtrDados["TX_MOTIVO_VENCEUNACIONAL"]);
                entReturn.MotivoExcluiu = ObjectUtils.ToString(dtrDados["TX_MOTIVO_EXCLUIU"]) + ObjectUtils.ToString(dtrDados["TX_MOTIVO_EXCLUIUNACIONAL"]);
                entReturn.Leitura = true;
                entReturn.PreencheQuestionario = true;
                entReturn.Questionario.IdQuestionario = DeParaQuestionarioGestao(ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]));
                entReturn.Etapa.IdEtapa = DeParaEtapa(ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]), ObjectUtils.ToInt(dtrDados["CEA_QUESTIONARIO_EMPRESA_STATUS"]));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entReturn;
        }

        private List<EntQuestionarioEmpresaAvaliador> PopularListAvaliador(DbDataReader dtrDados, Boolean isPrimario)
        {
            List<EntQuestionarioEmpresaAvaliador> listEntReturn = new List<EntQuestionarioEmpresaAvaliador>();
            EntQuestionarioEmpresaAvaliador entReturn;

            try
            {
                foreach (DbDataRecord DataRecord in dtrDados)
                {
                    entReturn = PopularRowListAvaliador(DataRecord, isPrimario);
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

        private EntQuestionarioEmpresaAvaliador PopularRowListAvaliador(DbDataRecord dtrDados, Boolean isPrimario)
        {
            EntQuestionarioEmpresaAvaliador entReturn;

            try
            {
                entReturn = new EntQuestionarioEmpresaAvaliador();
                entReturn.Avaliado = ObjectUtils.ToBoolean(dtrDados["FL_AVALIADO"]);
                entReturn.Banca = ObjectUtils.ToString(dtrDados["TX_BANCA"]);
                entReturn.MelhorPratica = ObjectUtils.ToString(dtrDados["TX_MELHOR_PRATICA"]);
                entReturn.MotivoDevolucao = ObjectUtils.ToString(dtrDados["TX_MOTIVO_DEVOLUCAO"]);
                entReturn.Primario = isPrimario;
                entReturn.QuestionarioEmpresa.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
                entReturn.Usuario.Email = ObjectUtils.ToString(dtrDados["TX_EMAIL"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entReturn;
        }

        private List<EntQuestionarioPontuacao> PopularListPontuacao(DbDataReader dtrDados)
        {
            List<EntQuestionarioPontuacao> listEntReturn = new List<EntQuestionarioPontuacao>();
            EntQuestionarioPontuacao entReturn;

            try
            {
                foreach (DbDataRecord DataRecord in dtrDados)
                {
                    entReturn = PopularRowListPontuacao(DataRecord);
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

        private EntQuestionarioPontuacao PopularRowListPontuacao(DbDataRecord dtrDados)
        {
            EntQuestionarioPontuacao entReturn;

            try
            {
                entReturn = new EntQuestionarioPontuacao();
                entReturn.Avaliador = ObjectUtils.ToBoolean(dtrDados["FL_AVALIADOR"]);
                entReturn.Criterio.IdCriterio = DeParaCriterio(ObjectUtils.ToInt(dtrDados["CEA_CRITERIO"]), ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]));
                entReturn.Ponto = ObjectUtils.ToDecimal(dtrDados["NU_PERCENTUAL"]);
                entReturn.Questionario.IdQuestionario = DeParaQuestionarioPorCriterio(ObjectUtils.ToInt(dtrDados["CEA_CRITERIO"]), ObjectUtils.ToInt(dtrDados["CEA_PROGRAMA"]));
                entReturn.QuestionarioEmpresa.IdQuestionarioEmpresa = ObjectUtils.ToInt(dtrDados["CDA_QUESTIONARIO_EMPRESA"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entReturn;
        }

        private int DePara(Int32 idPrograma)
        {
            switch (idPrograma)
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                case 4:
                    return 4;
                case 5:
                    return 7;
                case 6:
                    return 5;
                case 7:
                    return 7;
            }
            return 0;
            }

        private int DeParaQuestionarioGestao(Int32 idPrograma)
        {
            switch (idPrograma)
            {
                case 1:
                    return 2;
                case 2:
                    return 3;
                case 3:
                    return 3;
                case 4:
                    return 5;
                case 5:
                    return 5;
                case 6:
                    return 5;
                case 7:
                    return 5;
            }
            return 0;
        }

        private int DeParaQuestionarioPorCriterio(Int32 idCriterio, Int32 idPrograma)
        {
            switch (idPrograma)
            {
                case 1:
                    if (idCriterio < 11)
                    {
                        return 7;
                    }else{
                        return 2;
                    }
                case 2:
                    if (idCriterio < 11)
                    {
                        return 7;
                    }
                    else
                    {
                        return 3;
                    }
                case 3:
                    if (idCriterio < 11)
                    {
                        return 7;
                    }
                    else
                    {
                        return 3;
                    }
                case 4:
                case 5:
                case 6:
                case 7:
                    if (idCriterio < 11)
                    {
                        return 7;
                    }
                    else
                    {
                        return 5;
                    }
            }
            return 0;
        }

        private int DeParaPrograma(Int32 idPrograma)
        {
            switch (idPrograma)
            {
                case 1:
                    return 1;
                case 2:
                    return 1;
                case 3:
                    return 1;
                case 4:
                    return 1;
                case 5:
                    return 2;
                case 6:
                    return 1;
                case 7:
                    return 2;
            }
            return 0;
        }

        private int DeParaEtapa(Int32 idPrograma, Int32 statusEmpresa)
        {
            switch (idPrograma)
            {
                case 1://mpe2006
                    switch (statusEmpresa)
                    {
                        case 1:
                            return 9;
                        case 2:
                            return 10;
                        case 3:
                            return 11;
                        case 4:
                            return 12;
                    }
                    break;
                case 2://mpe2007
                    switch (statusEmpresa)
                    {
                        case 6:
                            return 19;
                        case 7:
                            return 20;
                        case 8:
                            return 21;
                        case 9:
                            return 22;
                    }
                    break;
                case 3://mpe2008
                    switch (statusEmpresa)
                    {
                        case 10:
                            return 602;
                        case 11:
                            return 603;
                        case 12:
                            return 604;
                        case 13:
                            return 605;
                    }
                    break;
                case 4://mpe2009
                    switch (statusEmpresa)
                    {
                        case 16:
                            return 608;
                        case 17:
                            return 609;
                        case 18:
                            return 610;
                        case 20:
                            return 611;
                    }
                    break;
                case 5://fga
                    switch (statusEmpresa)
                    {
                        case 16:
                            return 625;
                        case 17:
                            return 626;
                        case 18:
                            return 627;
                        case 20:
                            return 628;
                    }
                    break;
                case 6://mpe2010
                    switch (statusEmpresa)
                    {
                        case 16:
                            return 615;
                        case 17:
                            return 616;
                        case 18:
                            return 617;
                        case 20:
                            return 618;
                        case 26:
                            return 620;
                        case 27:
                            return 621;
                        case 28:
                            return 622;
                    }
                    break;
                case 7://fga
                    switch (statusEmpresa)
                    {
                        case 16:
                            return 625;
                        case 17:
                            return 626;
                        case 18:
                            return 627;
                        case 20:
                            return 628;
                    }
                    break;
            }
            return 0;
        }

        private int DeParaCriterio(Int32 idPrograma, Int32 idCriterio)
        {
            switch (idPrograma)
            {
                case 1://mpe2006
                    switch (idCriterio)
                    {
                        case 1:
                            return 29;
                        case 2:
                            return 30;
                        case 3:
                            return 31;
                        case 4:
                            return 32;
                        case 5:
                            return 33;
                        case 6:
                            return 34;
                        case 7:
                            return 35;
                        case 8:
                            return 36;
                        case 9:
                            return 37;
                        case 10:
                            return 38;
                        case 11:
                            return 40;
                        case 12:
                            return 41;
                        case 13:
                            return 42;
                        case 14:
                            return 43;
                        case 15:
                            return 44;
                        case 16:
                            return 46;
                        case 17:
                            return 45;
                        case 18:
                            return 64;
                        case 19:
                            return 65;
                    }
                    break;
                case 2://mpe2007
                    switch (idCriterio)
                    {
                        case 1:
                            return 29;
                        case 2:
                            return 30;
                        case 3:
                            return 31;
                        case 4:
                            return 32;
                        case 5:
                            return 33;
                        case 6:
                            return 34;
                        case 7:
                            return 35;
                        case 8:
                            return 36;
                        case 9:
                            return 37;
                        case 10:
                            return 38;
                        case 11:
                            return 40;
                        case 12:
                            return 41;
                        case 13:
                            return 42;
                        case 14:
                            return 43;
                        case 15:
                            return 44;
                        case 16:
                            return 46;
                        case 17:
                            return 45;
                        case 18:
                            return 64;
                        case 19:
                            return 65;
                    }
                    break;
                case 3://mpe2008
                    switch (idCriterio)
                    {
                        case 1:
                            return 29;
                        case 2:
                            return 30;
                        case 3:
                            return 31;
                        case 4:
                            return 32;
                        case 5:
                            return 33;
                        case 6:
                            return 34;
                        case 7:
                            return 35;
                        case 8:
                            return 36;
                        case 9:
                            return 37;
                        case 10:
                            return 38;
                        case 11:
                            return 47;
                        case 12:
                            return 48;
                        case 13:
                            return 49;
                        case 14:
                            return 50;
                        case 15:
                            return 51;
                        case 16:
                            return 53;
                        case 17:
                            return 52;
                        case 18:
                            return 66;
                        case 19:
                            return 67;
                    }
                    break;
                case 4://mpe2009
                case 5://fga
                case 6://mpe2010
                case 7://fga
                    switch (idCriterio)
                    {
                        case 1:
                            return 29;
                        case 2:
                            return 30;
                        case 3:
                            return 31;
                        case 4:
                            return 32;
                        case 5:
                            return 33;
                        case 6:
                            return 34;
                        case 7:
                            return 35;
                        case 8:
                            return 36;
                        case 9:
                            return 37;
                        case 10:
                            return 38;
                        case 11:
                            return 23;
                        case 12:
                            return 24;
                        case 13:
                            return 21;
                        case 14:
                            return 22;
                        case 15:
                            return 27;
                        case 16:
                            return 25;
                        case 17:
                            return 26;
                        case 18:
                            return 61;
                        case 19:
                            return 62;
                    }
                    break;
            }
            return 0;
        }

    }
}
