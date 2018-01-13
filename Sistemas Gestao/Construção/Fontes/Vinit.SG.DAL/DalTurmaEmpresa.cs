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
    public class DalTurmaEmpresa
    {
        /// <summary>
        /// Inclui um registro na tabela TurmaEmpresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objTurmaEmpresa">Entidade que representa a tabela TurmaEmpresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>
        /// <returns>Entidade de TurmaEmpresa</returns>
        public EntTurmaEmpresa Inserir(EntTurmaEmpresa objTurmaEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_InsereTurmaEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nCEA_CATEGORIA", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.Categoria.IdCategoria));
            db.AddInParameter(dbCommand, "@nCEA_ATIVIDADE_ECONOMICA", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.AtividadeEconomica.IdAtividadeEconomica));
            db.AddInParameter(dbCommand, "@nCEA_FATURAMENTO", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.Faturamento.IdFaturamento));
            db.AddInParameter(dbCommand, "@nNU_FUNCIONARIO", DbType.Int32, IntUtils.ToIntNullColaborador(objTurmaEmpresa.NumeroFuncionario));
            db.AddInParameter(dbCommand, "@sTX_CEP", DbType.String, StringUtils.ToObject(objTurmaEmpresa.CEP));
            db.AddInParameter(dbCommand, "@sTX_ENDERECO", DbType.String, StringUtils.ToObject(objTurmaEmpresa.Endereco));
            db.AddInParameter(dbCommand, "@sTX_COMPLEMENTO", DbType.String, StringUtils.ToObject(objTurmaEmpresa.Complemento));
            db.AddInParameter(dbCommand, "@sTX_NUMERO", DbType.String, StringUtils.ToObject(objTurmaEmpresa.NumeroEndereco));
            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Boolean, true);
            db.AddInParameter(dbCommand, "@nCEA_USUARIO", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.Usuario.IdUsuario));
            db.AddInParameter(dbCommand, "@nCEA_CIDADE", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.Cidade.IdCidade));
            db.AddInParameter(dbCommand, "@dDT_ULTIMA_ALTERACAO", DbType.DateTime, System.DateTime.Now);
            db.AddInParameter(dbCommand, "@nCEA_ESTADO", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.Estado.IdEstado));
            db.AddInParameter(dbCommand, "@nCEA_PAIS", DbType.Int32, 1);
            db.AddInParameter(dbCommand, "@dDT_CADASTRO", DbType.DateTime, System.DateTime.Now);
            db.AddInParameter(dbCommand, "@sTX_ATIVIDADE_ECONOMICA", DbType.String, StringUtils.ToObject(objTurmaEmpresa.AtividadeEconomicaComplemento));
            db.AddInParameter(dbCommand, "@bFL_PARTICIPA_PROGRAMA", DbType.Boolean, objTurmaEmpresa.ParticipaPrograma);
            db.AddInParameter(dbCommand, "@sTX_NOME_CONTATO", DbType.String, StringUtils.ToObject(objTurmaEmpresa.NomeContato));
            db.AddInParameter(dbCommand, "@sTX_TELEFONE_CONTATO", DbType.String, StringUtils.ToObject(objTurmaEmpresa.TelefoneContato));
            db.AddInParameter(dbCommand, "@sTX_CELULAR_CONTATO", DbType.String, StringUtils.ToObject(objTurmaEmpresa.CelularContato));
            db.AddInParameter(dbCommand, "@sTX_EMAIL_CONTATO", DbType.String, StringUtils.ToObject(objTurmaEmpresa.EmailContato));
            db.AddInParameter(dbCommand, "@sTX_MENSAGEM_CONTATO", DbType.String, StringUtils.ToObject(objTurmaEmpresa.MensagemContato));
            if (objTurmaEmpresa.CPFContato != null)
            {
                db.AddInParameter(dbCommand, "@sTX_CPF_CONTATO", DbType.String, StringUtils.ToObject(StringUtils.removePontuacaoCpfCnpj(objTurmaEmpresa.CPFContato)));
            }
            else
            {
                db.AddInParameter(dbCommand, "@sTX_CPF_CONTATO", DbType.String, DBNull.Value);
            }
            if (objTurmaEmpresa.NascimentoContato.Year > 1900)
            {
                db.AddInParameter(dbCommand, "@dDT_DATA_NASCIMENTO_CONTATO", DbType.DateTime, DateUtils.ToObject(objTurmaEmpresa.NascimentoContato));
            }
            else
            {
                db.AddInParameter(dbCommand, "@dDT_DATA_NASCIMENTO_CONTATO", DbType.DateTime, DBNull.Value);
            }
            db.AddInParameter(dbCommand, "@sTX_ENDERECO_CONTATO", DbType.String, StringUtils.ToObject(objTurmaEmpresa.EnderecoContato));
            db.AddInParameter(dbCommand, "@sTX_COMPLEMENTO_CONTATO", DbType.String, StringUtils.ToObject(objTurmaEmpresa.ComplementoContato));
            db.AddInParameter(dbCommand, "@sTX_NUMERO_CONTATO", DbType.String, StringUtils.ToObject(objTurmaEmpresa.NumeroEnderecoContato));
            db.AddInParameter(dbCommand, "@sTX_SEXO_CONTATO", DbType.String, StringUtils.ToObject(objTurmaEmpresa.SexoContato));
            db.AddInParameter(dbCommand, "@nCEA_NIVEL_ESCOLARIDADE", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.ContatoNivelEscolaridade.IdContatoNivelEscolaridade));
            db.AddInParameter(dbCommand, "@nCEA_FAIXA_ETARIA", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.FaixaEtaria.IdContatoFaixaEtaria));
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.Turma.IdTurma));
            db.AddInParameter(dbCommand, "@nCEA_TIPO_EMPRESA", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.TipoEmpresa.IdTipoEmpresa));
            db.AddInParameter(dbCommand, "@nCEA_BAIRRO", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.Bairro.IdBairro));
            db.AddInParameter(dbCommand, "@nCEA_CARGO", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.Cargo.IdCargo));
            db.AddInParameter(dbCommand, "@sTX_CEP_CONTATO", DbType.String, StringUtils.ToObject(objTurmaEmpresa.CEPContato));
            db.AddInParameter(dbCommand, "@bFL_PERGUNTA1", DbType.Boolean, BooleanUtils.ToObject(objTurmaEmpresa.Pergunta1));
            db.AddInParameter(dbCommand, "@bFL_PERGUNTA2", DbType.Boolean, BooleanUtils.ToObject(objTurmaEmpresa.Pergunta2));
            db.AddInParameter(dbCommand, "@bFL_PERGUNTA3", DbType.Boolean, BooleanUtils.ToObject(objTurmaEmpresa.Pergunta3));
            db.AddInParameter(dbCommand, "@bFL_PERGUNTA4", DbType.Boolean, BooleanUtils.ToObject(objTurmaEmpresa.Pergunta4));
            db.AddInParameter(dbCommand, "@nCEA_ESTADO_CONTATO", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.EstadoContato.IdEstado));
            db.AddInParameter(dbCommand, "@nCEA_CIDADE_CONTATO", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.CidadeContato.IdCidade));
            db.AddInParameter(dbCommand, "@nCEA_BAIRRO_CONTATO", DbType.Int32, IntUtils.ToIntNullProc(objTurmaEmpresa.BairroContato.IdBairro));

            db.ExecuteNonQuery(dbCommand, transaction);

            return objTurmaEmpresa;
        }


        ///// <summary>
        ///// Altera um TurmaEmpresa
        ///// </summary>
        ///// <autor>Fernando Carvalho</autor>
        ///// <param name="objEmpresaCadastro">Entidade do TurmaEmpresa</param>
        ///// <param name="transaction">Transaction</param>
        ///// <param name="db">DataBase</param>        
        //public void Alterar(EntTurmaEmpresa objTurmaEmpresa, DbTransaction transaction, Database db)
        //{
        //    DbCommand dbCommand = db.GetStoredProcCommand("STP_AtualizaTurmaEmpresa");
        //    dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

        //    db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
        //    db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Int32, objTurmaEmpresa.Ativo);
            
        //    db.ExecuteNonQuery(dbCommand, transaction);
        //}

        /// <summary>
        /// Altera um TurmaEmpresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objEmpresaCadastro">Entidade do TurmaEmpresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AtivaInativa(EntTurmaEmpresa objTurmaEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AtivaInativaTurmaEmpresa");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@bFL_ATIVO", DbType.Int32, objTurmaEmpresa.Ativo);
            //  db.AddInParameter(dbCommand, "@bFL_PARTICIPA", DbType.Int32, objTurmaEmpresa.ParticipaPrograma);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objTurmaEmpresa.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Altera um TurmaEmpresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="objEmpresaCadastro">Entidade do TurmaEmpresa</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void ParticiparPrograma(EntTurmaEmpresa objTurmaEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_TurmaParticiparPrograma");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@bFL_PARTICIPA_PROGRAMA", DbType.Int32, objTurmaEmpresa.ParticipaPrograma);
            //  db.AddInParameter(dbCommand, "@bFL_PARTICIPA", DbType.Int32, objTurmaEmpresa.ParticipaPrograma);
            db.AddInParameter(dbCommand, "@nCEA_TURMA", DbType.Int32, objTurmaEmpresa.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@nCEA_EMP_CADASTRO", DbType.Int32, objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.ExecuteNonQuery(dbCommand, transaction);
        }


        /// <summary>
        /// Retorna uma lista de entidade de TurmaEmpresa
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTurmaEmpresa">Lista de EntTurmaEmpresa</list></returns>
        public List<EntTurmaEmpresa> ObterTodasInscritasPorFiltros(EntTurmaEmpresa objTurmaEmpresa, EntGrupo objGrupo, String sProtocolo, DateTime dDataInicio, DateTime dDataFim, Int32 IdTipoEtapa,
                                                                    DbTransaction transaction, Database db)
        {

            List<EntTurmaEmpresa> listEntReturn = new List<EntTurmaEmpresa>();
            EntTurmaEmpresa entReturn;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEmpresaPorFiltro");

            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Turma.IdTurma));
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Estado.IdEstado));
            db.AddInParameter(dbCommand, "@CEA_ESCRITORIO_REGIONAL", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Cidade.EscritorioRegional.IdEscritorioRegional));
            db.AddInParameter(dbCommand, "@CEA_ESTADO_REGIAO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Cidade.EstadoRegiao.IdEstadoRegiao));
            db.AddInParameter(dbCommand, "@CEA_CIDADE", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Cidade.IdCidade));
            db.AddInParameter(dbCommand, "@CEA_FATURAMENTO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Faturamento.IdFaturamento));
            db.AddInParameter(dbCommand, "@NU_FUNCIONARIOS", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.NumeroFuncionario));
            db.AddInParameter(dbCommand, "@CEA_NIVEL_ESCOLARIDADE", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.ContatoNivelEscolaridade.IdContatoNivelEscolaridade));
            db.AddInParameter(dbCommand, "@CEA_FAIXA_ETARIA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.FaixaEtaria.IdContatoFaixaEtaria));
            db.AddInParameter(dbCommand, "@sNOME_FANTASIA", DbType.String, objTurmaEmpresa.EmpresaCadastro.NomeFantasia);
            db.AddInParameter(dbCommand, "@sRAZAO_SOCIAL", DbType.String, objTurmaEmpresa.EmpresaCadastro.RazaoSocial);
            db.AddInParameter(dbCommand, "@CPF_CNPJ", DbType.String, objTurmaEmpresa.EmpresaCadastro.CPF_CNPJ);
            db.AddInParameter(dbCommand, "@STATUS", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Status));
            db.AddInParameter(dbCommand, "@CEA_CATEGORIA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Categoria.IdCategoria));
            db.AddInParameter(dbCommand, "@TIPO_EMPRESA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.TipoEmpresa.IdTipoEmpresa));
            db.AddInParameter(dbCommand, "@TX_SEXO_CONTATO", DbType.String, objTurmaEmpresa.SexoContato == "" ? null : objTurmaEmpresa.SexoContato);
            db.AddInParameter(dbCommand, "@CEA_GRUPO", DbType.Int32, IntUtils.ToIntNull(objGrupo.IdGrupo));
            db.AddInParameter(dbCommand, "@PROTOCOLO", DbType.String, sProtocolo);
            db.AddInParameter(dbCommand, "@DATAINICIO", DbType.DateTime, dDataInicio);
            db.AddInParameter(dbCommand, "@DATAFIM", DbType.DateTime, StringUtils.ToDateFim(dDataFim.ToString()));
            db.AddInParameter(dbCommand, "@FL_PARTICIPA_PROGRAMA", DbType.Int32, objTurmaEmpresa.ParticipaPrograma);
            db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, IdTipoEtapa);
            

            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                try
                {
                    if (dtrDados != null && dtrDados.HasRows)
                    {

                        foreach (DbDataRecord DataRecord in dtrDados)
                        {
                            entReturn = PopularRowSimples(DataRecord);
                            //EmpresaCadastro
                            entReturn.EtapaAtiva = ObjectUtils.ToBoolean(dtrDados["FL_ETAPA_ATIVA"]);
                            entReturn.EstadoContato.Sigla = ObjectUtils.ToString(dtrDados["ESTADO_CONTATO"]);
                            entReturn.BairroContato.Bairro = ObjectUtils.ToString(dtrDados["BAIRRO_CONTATO"]);
                            entReturn.CidadeContato.Cidade = ObjectUtils.ToString(dtrDados["CIDADE_CONTATO"]);
                            entReturn.EmpresaCadastro.RazaoSocial = ObjectUtils.ToString(DataRecord["TX_RAZAO_SOCIAL"]);
                            entReturn.EmpresaCadastro.NomeFantasia = ObjectUtils.ToString(DataRecord["TX_NOME_FANTASIA"]);
                            entReturn.EmpresaCadastro.CPF_CNPJ = ObjectUtils.ToString(DataRecord["TX_CPF_CNPJ"]);
                            entReturn.EmpresaCadastro.AberturaEmpresa = ObjectUtils.ToDate(DataRecord["DT_ABERTURA_EMPRESA"]);
                            entReturn.EmpresaCadastro.ParticipouMPE2006 = ObjectUtils.ToBoolean(DataRecord["FL_PARTICIPOU_MPE_2006"]);
                            entReturn.EmpresaCadastro.ParticipouMPE2007 = ObjectUtils.ToBoolean(DataRecord["FL_PARTICIPOU_MPE_2007"]);
                            entReturn.EmpresaCadastro.ParticipouMPE2008 = ObjectUtils.ToBoolean(DataRecord["FL_PARTICIPOU_MPE_2008"]);
                            entReturn.EmpresaCadastro.ParticipouMPE2009 = ObjectUtils.ToBoolean(DataRecord["FL_PARTICIPOU_MPE_2009"]);
                            entReturn.EmpresaCadastro.ParticipouMPE2010 = ObjectUtils.ToBoolean(DataRecord["FL_PARTICIPOU_MPE_2010"]);
                            entReturn.EmpresaCadastro.ParticipouMPE2011 = ObjectUtils.ToBoolean(DataRecord["FL_PARTICIPOU_MPE_2011"]);
                            entReturn.AtividadeEconomica.AtividadeEconomica = ObjectUtils.ToString(dtrDados["TX_ATIVIDADE_ECONOMICA_PRINCIPAL"]);
                            //Cidade
                            entReturn.Cidade.Cidade = ObjectUtils.ToString(DataRecord["TX_CIDADE"]);
                            //Estado
                            entReturn.Estado.Estado = ObjectUtils.ToString(DataRecord["TX_ESTADO"]);
                            //TipoEmpresa
                            entReturn.TipoEmpresa.TipoEmpresa = ObjectUtils.ToString(DataRecord["TX_TIPO_EMPRESA"]);
                            //Faturamento
                            entReturn.Faturamento.Faturamento = ObjectUtils.ToString(DataRecord["TX_FATURAMENTO"]);
                            //Categoria
                            entReturn.Categoria.Categoria = ObjectUtils.ToString(DataRecord["TX_CATEGORIA"]);
                            //AtividadeEconomica
                            entReturn.AtividadeEconomica.AtividadeEconomica = ObjectUtils.ToString(DataRecord["TX_ATIVIDADE_ECONOMICA"]);
                            //Bairro
                            entReturn.Bairro.Bairro = ObjectUtils.ToString(DataRecord["TX_BAIRRO"]);
                            //Cargo
                            entReturn.Cargo.Cargo = ObjectUtils.ToString(DataRecord["TX_CARGO"]);
                            //ContatoNivelEscolaridade
                            entReturn.ContatoNivelEscolaridade.ContatoNivelEscolaridade = ObjectUtils.ToString(DataRecord["TX_NIVEL_ESCOLARIDADE"]);
                            //FaixaEtaria
                            entReturn.FaixaEtaria.ContatoFaixaEtaria = ObjectUtils.ToString(DataRecord["TX_FAIXA_ETARIA"]);
                            listEntReturn.Add(entReturn);
                        }

                        dtrDados.Close();
                        return listEntReturn;
                    }
                    else
                    {
                        return listEntReturn;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de TurmaEmpresa por filtro simples
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntTurmaEmpresa">Lista de EntTurmaEmpresa</list></returns>
        public List<EntTurmaEmpresa> ObterTodasInscritasPorFiltros(EntTurmaEmpresa objTurmaEmpresa, DbTransaction transaction, Database db)
        {

            List<EntTurmaEmpresa> listEntReturn = new List<EntTurmaEmpresa>();
            EntTurmaEmpresa entReturn;
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEmpresaPorFiltroSimples");
            db.AddInParameter(dbCommand, "@sNOME_FANTASIA", DbType.String, objTurmaEmpresa.EmpresaCadastro.NomeFantasia);
            db.AddInParameter(dbCommand, "@CPF_CNPJ", DbType.String, objTurmaEmpresa.EmpresaCadastro.CPF_CNPJ);
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Estado.IdEstado));
            db.AddInParameter(dbCommand, "@CEA_CATEGORIA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Categoria.IdCategoria));
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, IntUtils.ToIntNull(objTurmaEmpresa.Turma.IdTurma));

            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                try
                {
                    if (dtrDados != null && dtrDados.HasRows)
                    {

                        foreach (DbDataRecord DataRecord in dtrDados)
                        {
                            entReturn = new EntTurmaEmpresa();

                            //EmpresaCadastro
                            entReturn.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(DataRecord["CEA_EMP_CADASTRO"]);
                            entReturn.EmpresaCadastro.RazaoSocial = ObjectUtils.ToString(DataRecord["TX_RAZAO_SOCIAL"]);
                            entReturn.EmpresaCadastro.NomeFantasia = ObjectUtils.ToString(DataRecord["TX_NOME_FANTASIA"]);
                            entReturn.EmpresaCadastro.CPF_CNPJ = ObjectUtils.ToString(DataRecord["TX_CPF_CNPJ"]);
                            entReturn.Categoria.IdCategoria = ObjectUtils.ToInt(dtrDados["CEA_CATEGORIA"]);
                            entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                            //Estado
                            //entReturn.Estado.IdEstado  = ObjectUtils.ToInt(DataRecord["CDA_ESTADO"]);
                            entReturn.Estado.Estado = ObjectUtils.ToString(DataRecord["TX_ESTADO"]);
                            //Categoria
                            //entReturn.Categoria.IdCategoria = ObjectUtils.ToInt(DataRecord["CDA_CATEGORIA"]);
                            entReturn.Categoria.Categoria = ObjectUtils.ToString(DataRecord["TX_CATEGORIA"]);
                            listEntReturn.Add(entReturn);
                        }

                        dtrDados.Close();
                        return listEntReturn;
                    }
                    else
                    {
                        return listEntReturn;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Retorna um TurmaEmpresa
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public EntTurmaEmpresa ObterPorIdEmpresaIdPrograma(Int32 IdEmpresa, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaEmpresaPorIdEmpresaIdPrograma");
            db.AddInParameter(dbCommand, "@nIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@nIdPrograma", DbType.Int32, IdPrograma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            EntTurmaEmpresa objTurmaEmpresa = new EntTurmaEmpresa();

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    try
                    {
                        foreach (DbDataRecord DataRecord in dtrDados)
                        {
                            objTurmaEmpresa = PopularRow(DataRecord);
                            //Cidade
                            objTurmaEmpresa.Cidade.Cidade = ObjectUtils.ToString(DataRecord["TX_CIDADE"]);
                            //Estado
                            objTurmaEmpresa.Estado.Estado = ObjectUtils.ToString(DataRecord["TX_ESTADO"]);
                            //TipoEmpresa
                            objTurmaEmpresa.TipoEmpresa.TipoEmpresa = ObjectUtils.ToString(DataRecord["TX_TIPO_EMPRESA"]);
                            //Faturamento
                            objTurmaEmpresa.Faturamento.Faturamento = ObjectUtils.ToString(DataRecord["TX_FATURAMENTO"]);
                            //Categoria
                            objTurmaEmpresa.Categoria.Categoria = ObjectUtils.ToString(DataRecord["TX_CATEGORIA"]);
                            //AtividadeEconomica
                            objTurmaEmpresa.AtividadeEconomica.AtividadeEconomica = ObjectUtils.ToString(DataRecord["TX_ATIVIDADE_ECONOMICA_PRINCIPAL"]);
                            //Bairro
                            objTurmaEmpresa.Bairro.Bairro = ObjectUtils.ToString(DataRecord["TX_BAIRRO"]);
                            //Cargo
                            objTurmaEmpresa.Cargo.Cargo = ObjectUtils.ToString(DataRecord["TX_CARGO"]);
                            //ContatoNivelEscolaridade
                            objTurmaEmpresa.ContatoNivelEscolaridade.ContatoNivelEscolaridade = ObjectUtils.ToString(DataRecord["TX_NIVEL_ESCOLARIDADE"]);
                            //FaixaEtaria
                            objTurmaEmpresa.FaixaEtaria.ContatoFaixaEtaria = ObjectUtils.ToString(DataRecord["TX_FAIXA_ETARIA"]);

                        }

                        dtrDados.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }

            return objTurmaEmpresa;
        }

        /// <summary>
        /// Retorna um TurmaEmpresa
        /// </summary>
        /// <autor>Fabio Moraes</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public EntTurmaEmpresa ObterTurmaEmpresaAnteriorPorEmpresaCadastro(Int32 IdEmpresaCadastro, Int32 IdPrograma, Int32 IdTurma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaEmpresaAnteriorPorEmpresaCadastro");
            db.AddInParameter(dbCommand, "@CDA_EMP_CADASTRO", DbType.Int32, IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@CEA_PROGRAMA", DbType.Int32, IdPrograma);
            db.AddInParameter(dbCommand, "@CDA_TURMA", DbType.Int32, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return new EntTurmaEmpresa();
                }
            }
        }

        /// <summary>
        /// Retorna um TurmaEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public EntTurmaEmpresa ObterPorTurmaEmpresa(EntTurmaEmpresa objTurmaEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaEmpresaPorIdTurmaIdEmpresa");
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.Int32, objTurmaEmpresa.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@nIdEmpresa", DbType.Int32, objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
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
        /// Retorna um TurmaEmpresa
        /// </summary>
        /// <autor>Thiago Moreira</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public EntTurmaEmpresa ObterUltimoPorProgramaEmpresa(Int32 IdPrograma, Int32 IdEmpresa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaEmpresaUltimaPorIdProgramaIdEmpresa");
            db.AddInParameter(dbCommand, "@nIdPrograma", DbType.Int32, IdPrograma);
            db.AddInParameter(dbCommand, "@nIdEmpresa", DbType.Int32, IdEmpresa);
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
        /// Retorna um TurmaEmpresa
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntTurmaEmpresa">EntTurmaEmpresa</returns>
        public List<EntTurmaEmpresa> ObterTurmaCorrentePorIdUsuario(Int32 IdUsuario, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaTurmaCorrentePorIdUsuario");
            db.AddInParameter(dbCommand, "@nIdUsuario", DbType.Int32, IdUsuario);
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
        /// Popula Grupo, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntGrupo">Lista de EntGrupo</list></returns>
        private List<EntTurmaEmpresa> Popular(DbDataReader dtrDados)
        {
            List<EntTurmaEmpresa> listEntReturn = new List<EntTurmaEmpresa>();
            EntTurmaEmpresa entReturn;

            try
            {
                foreach (DbDataRecord DataRecord in dtrDados)
                {
                    entReturn = PopularRow(DataRecord);
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
        /// Popula Grupo, conforme DataRecord passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">Registro a ser percorrido.</param>
        /// <returns><list type="EntGrupo">EntGrupo</list></returns>
        private EntTurmaEmpresa PopularRow(DbDataRecord dtrDados)
        {
            EntTurmaEmpresa entReturn;

            try
            {
                entReturn = new EntTurmaEmpresa();
                entReturn = this.PopularRowSimples(dtrDados);

                entReturn.NumeroEndereco = ObjectUtils.ToString(dtrDados["TX_NUMERO"]);
                entReturn.NumeroEnderecoContato = ObjectUtils.ToString(dtrDados["TX_NUMERO_CONTATO"]);
                entReturn.ComplementoContato = ObjectUtils.ToString(dtrDados["TX_COMPLEMENTO_CONTATO"]);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entReturn;
        }

        /// <summary>
        /// Popula Grupo, conforme DataRecord passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">Registro a ser percorrido.</param>
        /// <returns><list type="EntGrupo">EntGrupo</list></returns>
        private EntTurmaEmpresa PopularRowSimples(DbDataRecord dtrDados)
        {
            EntTurmaEmpresa entReturn;

            try
            {
                entReturn = new EntTurmaEmpresa();

                entReturn.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CEA_EMP_CADASTRO"]);
                entReturn.Categoria.IdCategoria = ObjectUtils.ToInt(dtrDados["CEA_CATEGORIA"]);
                entReturn.AtividadeEconomica.IdAtividadeEconomica = ObjectUtils.ToInt(dtrDados["CEA_ATIVIDADE_ECONOMICA"]);
                try
                {
                    entReturn.AtividadeEconomica.Codigo = ObjectUtils.ToInt(dtrDados["CODIGO"]);
                }
                catch { }
                entReturn.Faturamento.IdFaturamento = ObjectUtils.ToInt(dtrDados["CEA_FATURAMENTO"]);
                entReturn.NumeroFuncionario = ObjectUtils.ToInt(dtrDados["NU_FUNCIONARIO"]);
                entReturn.CEP = ObjectUtils.ToString(dtrDados["TX_CEP"]);
                entReturn.Endereco = ObjectUtils.ToString(dtrDados["TX_ENDERECO"]);
                entReturn.Complemento = ObjectUtils.ToString(dtrDados["TX_COMPLEMENTO"]);
                entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                entReturn.Usuario.IdUsuario = ObjectUtils.ToInt(dtrDados["CEA_USUARIO"]);
                entReturn.Cidade.IdCidade = ObjectUtils.ToInt(dtrDados["CEA_CIDADE"]);
                entReturn.UltimaAlteracao = ObjectUtils.ToDate(dtrDados["DT_ULTIMA_ALTERACAO"]);
                entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO"]);
                entReturn.Pais.IdPais = ObjectUtils.ToInt(dtrDados["CEA_PAIS"]);
                entReturn.Cadastro = ObjectUtils.ToDate(dtrDados["DT_CADASTRO"]);
                entReturn.AtividadeEconomicaComplemento = ObjectUtils.ToString(dtrDados["TX_ATIVIDADE_ECONOMICA"]);
                entReturn.ParticipaPrograma = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPA_PROGRAMA"]);
                entReturn.NomeContato = ObjectUtils.ToString(dtrDados["TX_NOME_CONTATO"]);
                entReturn.TelefoneContato = ObjectUtils.ToString(dtrDados["TX_TELEFONE_CONTATO"]);
                entReturn.CelularContato = ObjectUtils.ToString(dtrDados["TX_CELULAR_CONTATO"]);
                entReturn.EmailContato = ObjectUtils.ToString(dtrDados["TX_EMAIL_CONTATO"]);
                entReturn.MensagemContato = ObjectUtils.ToString(dtrDados["TX_MENSAGEM_CONTATO"]);
                entReturn.CPFContato = ObjectUtils.ToString(dtrDados["TX_CPF_CONTATO"]);
                entReturn.NascimentoContato = ObjectUtils.ToDate(dtrDados["DT_DATA_NASCIMENTO_CONTATO"]);
                entReturn.EnderecoContato = ObjectUtils.ToString(dtrDados["TX_ENDERECO_CONTATO"]);
                entReturn.SexoContato = ObjectUtils.ToString(dtrDados["TX_SEXO_CONTATO"]);
                entReturn.ContatoNivelEscolaridade.IdContatoNivelEscolaridade = ObjectUtils.ToInt(dtrDados["CEA_NIVEL_ESCOLARIDADE"]);
                entReturn.FaixaEtaria.IdContatoFaixaEtaria = ObjectUtils.ToInt(dtrDados["CEA_FAIXA_ETARIA"]);
                try
                {
                    entReturn.FaixaEtaria.ContatoFaixaEtaria = ObjectUtils.ToString(dtrDados["TX_FAIXA_ETARIA"]);
                }
                catch { }
                entReturn.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);
                entReturn.TipoEmpresa.IdTipoEmpresa = ObjectUtils.ToInt(dtrDados["CEA_TIPO_EMPRESA"]);
                entReturn.Bairro.IdBairro = ObjectUtils.ToInt(dtrDados["CEA_BAIRRO"]);
                entReturn.Cargo.IdCargo = ObjectUtils.ToInt(dtrDados["CEA_CARGO"]);
                entReturn.CEPContato = ObjectUtils.ToString(dtrDados["TX_CEP_CONTATO"]);
                entReturn.Pergunta1 = ObjectUtils.ToBoolean(dtrDados["FL_PERGUNTA1"]);
                entReturn.Pergunta2 = ObjectUtils.ToBoolean(dtrDados["FL_PERGUNTA2"]);
                entReturn.Pergunta3 = ObjectUtils.ToBoolean(dtrDados["FL_PERGUNTA3"]);
                entReturn.Pergunta4 = ObjectUtils.ToBoolean(dtrDados["FL_PERGUNTA4"]);
                entReturn.EstadoContato.IdEstado = ObjectUtils.ToInt(dtrDados["CEA_ESTADO_CONTATO"]);
                try
                {
                    entReturn.EstadoContato.Sigla = ObjectUtils.ToString(dtrDados["ESTADO_CONTATO"]);
                }
                catch { }
                entReturn.CidadeContato.IdCidade = ObjectUtils.ToInt(dtrDados["CEA_CIDADE_CONTATO"]);
                entReturn.BairroContato.IdBairro = ObjectUtils.ToInt(dtrDados["CEA_BAIRRO_CONTATO"]);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entReturn;
        }

        /// <summary>
        /// Popula Grupo, conforme DataRecord passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">Registro a ser percorrido.</param>
        /// <returns><list type="EntGrupo">EntGrupo</list></returns>
        private EntTurmaEmpresa PopularRowCuston(DbDataRecord dtrDados)
        {
            EntTurmaEmpresa entReturn;

            try
            {
                entReturn = new EntTurmaEmpresa();

                entReturn.EmpresaCadastro.IdEmpresaCadastro = ObjectUtils.ToInt(dtrDados["CEA_EMP_CADASTRO"]);
                entReturn.EmpresaCadastro.RazaoSocial = ObjectUtils.ToString(dtrDados["TX_RAZAO_SOCIAL"]);
                entReturn.EmpresaCadastro.NomeFantasia = ObjectUtils.ToString(dtrDados["TX_NOME_FANTASIA"]);
                entReturn.EmpresaCadastro.CPF_CNPJ = ObjectUtils.ToString(dtrDados["TX_CPF_CNPJ"]);
                entReturn.EmpresaCadastro.AberturaEmpresa = ObjectUtils.ToDate(dtrDados["DT_ABERTURA_EMPRESA"]);
                entReturn.EmpresaCadastro.ParticipouMPE2006 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2006"]);
                entReturn.EmpresaCadastro.ParticipouMPE2007 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2007"]);
                entReturn.EmpresaCadastro.ParticipouMPE2008 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2008"]);
                entReturn.EmpresaCadastro.ParticipouMPE2009 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2009"]);
                entReturn.EmpresaCadastro.ParticipouMPE2010 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2010"]);
                entReturn.EmpresaCadastro.ParticipouMPE2011 = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPOU_MPE_2011"]);
                entReturn.Estado.IdEstado = ObjectUtils.ToInt(dtrDados["CDA_ESTADO"]);
                entReturn.Estado.Estado = ObjectUtils.ToString(dtrDados["TX_ESTADO"]);
                entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                entReturn.ParticipaPrograma = ObjectUtils.ToBoolean(dtrDados["FL_PARTICIPA_PROGRAMA"]);
                entReturn.Turma.IdTurma = ObjectUtils.ToInt(dtrDados["CEA_TURMA"]);


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entReturn;
        }


        /// <summary>
        /// Altera a empresa de turma
        /// </summary>
        /// <autor>Diogo T. Machado</autor>
        /// <param name="objTurma">Entidade de Turma</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void MudarTurma(EntTurmaEmpresa objTurmaEmpresa, int IdTurmaDestino, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_AlteraDeTurma");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@nIdEmpresaCadastro", DbType.Int32, objTurmaEmpresa.EmpresaCadastro.IdEmpresaCadastro);
            db.AddInParameter(dbCommand, "@nIdTurmaAtual", DbType.Int32, objTurmaEmpresa.Turma.IdTurma);
            db.AddInParameter(dbCommand, "@nIdTurmaDestino", DbType.Int32, IdTurmaDestino);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

    }
}
