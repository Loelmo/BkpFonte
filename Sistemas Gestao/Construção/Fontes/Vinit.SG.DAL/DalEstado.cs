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
    /// Classe de Dados que representa um Estado
    /// </summary>
    public class DalEstado
    {

        /// <summary>
        /// Retorna um Estado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntEstado">EntEstado</returns>
        public EntEstado ObterPorId(Int32 IdEstado, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEstadoPorId");
            db.AddInParameter(dbCommand, "@nIdEstado", DbType.String, IdEstado);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return new EntEstado();
                }
            }
        }

        /// <summary>
        /// Retorna um Estado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntEstado">EntEstado</returns>
        public EntEstado ObterPorIdSiac(Int32 CodSiac, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEstadoPorCodSiac");
            db.AddInParameter(dbCommand, "@nIdEstado", DbType.String, CodSiac);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados)[0];
                }
                else
                {
                    return new EntEstado();
                }
            }
        }

        /// <summary>
        /// Retorna um Estado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntEstado">EntEstado</returns>
        public List<EntEstado> ObterEstadosPorTurma(Int32 IdTurma, Int32 IdTipoEtapa, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEstadosPorTurma");
            db.AddInParameter(dbCommand, "@nIdTipoEtapa", DbType.String, IdTipoEtapa);
            db.AddInParameter(dbCommand, "@nIdTurma", DbType.String, IdTurma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntEstado>();
                }
            }
        }

        /// <summary>
        /// Retorna um Estado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><type="EntEstado">EntEstado</returns>
        public List<EntEstadosPermitidos> ObterEstadosPermitido(Int32 IdUsuario, Int32 IdPrograma, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEstadosPermitido");
            db.AddInParameter(dbCommand, "@nIdUsuario", DbType.String, IdUsuario);
            db.AddInParameter(dbCommand, "@nIdPrograma", DbType.String, IdPrograma);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.PopularCustom(dtrDados);
                }
                else
                {
                    return new List<EntEstadosPermitidos>();
                }
            }
        }

        /// <summary>
        /// Altera um Escritório Regional
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="objEscritorioRegional">Entidade do Escritório Regional</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>        
        public void AlterarDadosSiac(EntEstado objEstado, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_Siac_AtualizaEstado");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@sTX_SIGLA", DbType.String, objEstado.Sigla);
            db.AddInParameter(dbCommand, "@nCOD_SIAC", DbType.Int32, objEstado.CodSiacweb);
            db.ExecuteNonQuery(dbCommand, transaction);
        }

        /// <summary>
        /// Retorna uma lista de entidade de Estado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        public List<EntEstado> ObterTodos(DbTransaction transaction, Database db)
        {

            List<EntEstado> lstEstado = new List<EntEstado>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEstado");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntEstado>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de Estado
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        public List<EntEstado> ObterEstadoEmpresasInscritasPorFiltro(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            List<EntEstado> lstEstado = new List<EntEstado>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEmpresasInscritasEstadoPorFiltro");

            db.AddInParameter(dbCommand, "@CEA_TIPO_ETAPA", DbType.Int32, (int)objRelFiltroRanking.TipoEtapaMpe);
            db.AddInParameter(dbCommand, "@CEA_TURMA", DbType.Int32, objRelFiltroRanking.Turma);
            //--------FILTROS DE TELA----------------------------------------------
            db.AddInParameter(dbCommand, "@sRAZAO_SOCIAL", DbType.String, objRelFiltroRanking.RazaoSocial);
            db.AddInParameter(dbCommand, "@sNOME_FANTASIA", DbType.String, objRelFiltroRanking.NomeFantasia);
            db.AddInParameter(dbCommand, "@CEA_ESTADO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Estado));
            db.AddInParameter(dbCommand, "@CEA_CATEGORIA", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Categoria));
            db.AddInParameter(dbCommand, "@CEA_NIVEL_ESCOLARIDADE", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.EscolaridadeRepresentante));
            db.AddInParameter(dbCommand, "@CEA_FAIXA_ETARIA", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.FaixaEtariaRepresentante));
            db.AddInParameter(dbCommand, "@CEA_CIDADE", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Municipio));
            db.AddInParameter(dbCommand, "@CEA_ESCRITORIO_REGIONAL", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.EscritorioRegional));
            db.AddInParameter(dbCommand, "@CEA_GRUPO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.Grupo));
            db.AddInParameter(dbCommand, "@CEA_FATURAMENTO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.FaixaFaturamento));
            db.AddInParameter(dbCommand, "@PROTOCOLO", DbType.String, objRelFiltroRanking.Protocolo);
            db.AddInParameter(dbCommand, "@CPF_CNPJ", DbType.String, objRelFiltroRanking.CPF_CNPJ);
            db.AddInParameter(dbCommand, "@CEA_ESTADO_REGIAO", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.EstadoRegiao));
            db.AddInParameter(dbCommand, "@TX_SEXO_CONTATO", DbType.String, StringUtils.ToObject(objRelFiltroRanking.SexoRepresentante));
            db.AddInParameter(dbCommand, "@DATAINICIO", DbType.DateTime, DateUtils.ToObject(objRelFiltroRanking.Inicio));
            db.AddInParameter(dbCommand, "@DATAFIM", DbType.DateTime, DateUtils.ToObject(objRelFiltroRanking.Fim));
            db.AddInParameter(dbCommand, "@NU_FUNCIONARIOS", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.NumeroFuncionarios));
            db.AddInParameter(dbCommand, "@TIPO_EMPRESA", DbType.Int32, IntUtils.ToIntNull(objRelFiltroRanking.TipoEmpresa));

            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_RESPONSABILIDADE_SOCIAL", DbType.Int32, (Int32)EnumType.Questionario.ResponsabilidadeSocial);
            db.AddInParameter(dbCommand, "@CEA_QUESTIONARIO_INOVACAO", DbType.Int32, (Int32)EnumType.Questionario.Inovacao);
            db.AddInParameter(dbCommand, "@FL_QUESTIONARIO_INOVACAO", DbType.Boolean, objRelFiltroRanking.PremioEspecial);
            db.AddInParameter(dbCommand, "@FL_QUESTIONARIO_RESP_SOCIAL", DbType.Boolean, objRelFiltroRanking.PremioEspecial);
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, (objRelFiltroRanking.Status == 2 ? 1 : 0));

            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord row in dtrDados)
                    {
                        EntEstado objEstado = new EntEstado();
                        objEstado.IdEstado = ObjectUtils.ToInt(row["CEA_ESTADO"]);
                        objEstado.Estado = ObjectUtils.ToString(row["TX_ESTADO"]);

                        lstEstado.Add(objEstado);
                    }
                    return lstEstado;
                }
                else
                {
                    return new List<EntEstado>();
                }
            }
        }

        /// <summary>
        /// Popula Estado, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        private List<EntEstado> Popular(DbDataReader dtrDados)
        {
            List<EntEstado> listEntReturn = new List<EntEstado>();
            EntEstado entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntEstado();

                    entReturn.IdEstado = ObjectUtils.ToInt(dtrDados["CDA_ESTADO"]);
                    entReturn.Sigla = ObjectUtils.ToString(dtrDados["TX_SIGLA"]);
                    entReturn.Estado = ObjectUtils.ToString(dtrDados["TX_ESTADO"]);
                    entReturn.Style = ObjectUtils.ToString(dtrDados["TX_STYLE"]);
                    entReturn.Email = ObjectUtils.ToString(dtrDados["TX_EMAIL"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    try
                    {
                        entReturn.CodSiacweb = ObjectUtils.ToInt(dtrDados["COD_SIACWEB"]);
                    }
                    catch { }

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
        /// Popula Estado, conforme DataReader passado
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntEstado">Lista de EntEstado</list></returns>
        private List<EntEstadosPermitidos> PopularCustom(DbDataReader dtrDados)
        {
            List<EntEstadosPermitidos> listEntReturn = new List<EntEstadosPermitidos>();
            EntEstadosPermitidos entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntEstadosPermitidos();

                    entReturn.IdEstado = ObjectUtils.ToInt(dtrDados["CDA_ESTADO"]);
                    entReturn.Sigla = ObjectUtils.ToString(dtrDados["TX_SIGLA"]);
                    entReturn.Estado = ObjectUtils.ToString(dtrDados["TX_ESTADO"]);
                    entReturn.Style = ObjectUtils.ToString(dtrDados["TX_STYLE"]);
                    entReturn.Email = ObjectUtils.ToString(dtrDados["TX_EMAIL"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.IdTurma = ObjectUtils.ToInt(dtrDados["CDA_TURMA"]);
                    entReturn.Funcionalidade = ObjectUtils.ToString(dtrDados["TX_FUNCIONALIDADE"]);

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
    }
}
