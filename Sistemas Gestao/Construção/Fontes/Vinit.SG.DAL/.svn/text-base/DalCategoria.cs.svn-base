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
    public class DalCategoria
    {
        /// <summary>
        /// Retorna um entidade de Categoria
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCategoria">Lista de EntCategoria</list></returns>
        public EntCategoria ObterPorId(Int32 nIdCategoria, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCategoriaPorId");
            db.AddInParameter(dbCommand, "@nCDA_Categoria", DbType.String, nIdCategoria);
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
        /// Retorna um entidade de Categoria
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCategoria">Lista de EntCategoria</list></returns>
        public List<EntCategoria> ObterTodos(bool flUsaCpf, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCategoriaByFlAceitaCpf");
            db.AddInParameter(dbCommand, "@flAceitaCpf", DbType.String, flUsaCpf);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntCategoria>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Categoria
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCategoria">Lista de EntCategoria</list></returns>
        public List<EntCategoria> ObterTodosFga(bool flUsaCpf, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCategoriaFgaByFlAceitaCpf");
            db.AddInParameter(dbCommand, "@flAceitaCpf", DbType.String, flUsaCpf);
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntCategoria>();
                }
            }
        }

        /// <summary>
        /// Retorna um entidade de Categoria
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCategoria">Lista de EntCategoria</list></returns>
        public List<EntCategoria> ObterTodos(DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaCategoria");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntCategoria>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de Categoria
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEstado">Lista de EntCategoria</list></returns>
        public List<EntCategoriaCustom> ObterCategoriaEmpresasInscritasPorFiltro(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            List<EntCategoriaCustom> lstCategoria = new List<EntCategoriaCustom>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEmpresasInscritasCategoriaPorFiltro");

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
            db.AddInParameter(dbCommand, "@FL_ATIVO", DbType.Boolean, (objRelFiltroRanking.Status == 2 ? 1 : 0) );

            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    foreach (DbDataRecord row in dtrDados)
                    {
                        EntCategoriaCustom objCategoria = new EntCategoriaCustom();
                        objCategoria.IdCategoria = ObjectUtils.ToInt(row["CDA_CATEGORIA"]);
                        objCategoria.Categoria = ObjectUtils.ToString(row["TX_CATEGORIA"]);
                            
                        lstCategoria.Add(objCategoria);
                    }
                    return lstCategoria;
                }
                else
                {
                    return new List<EntCategoriaCustom>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de Categoria
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEstado">Lista de EntCategoria</list></returns>
        public List<EntCategoriaCustom> ObterDigitadorEmpresasInscritasPorFiltro(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            List<EntCategoriaCustom> lstCategoria = new List<EntCategoriaCustom>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEmpresasInscritasDigitadorPorFiltro");

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
                        EntCategoriaCustom objCategoria = new EntCategoriaCustom();
                        objCategoria.IdCategoria = ObjectUtils.ToInt(row["CDA_CATEGORIA"]);
                        objCategoria.Categoria = ObjectUtils.ToString(row["TX_CATEGORIA"]);
                        objCategoria.Estado.IdEstado = ObjectUtils.ToInt(row["CEA_ESTADO"]);
                        objCategoria.CountEmpresas = ObjectUtils.ToInt(row["QTD"]);

                        lstCategoria.Add(objCategoria);
                    }
                    return lstCategoria;
                }
                else
                {
                    return new List<EntCategoriaCustom>();
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de entidade de Categoria
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntEstado">Lista de EntCategoria</list></returns>
        public List<EntCategoriaCustom> ObterAdminEmpresasInscritasPorFiltro(RelFiltroRanking objRelFiltroRanking, DbTransaction transaction, Database db)
        {
            List<EntCategoriaCustom> lstCategoria = new List<EntCategoriaCustom>();
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaEmpresasInscritasAdministradorPorFiltro");

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
                        EntCategoriaCustom objCategoria = new EntCategoriaCustom();
                        objCategoria.IdCategoria = ObjectUtils.ToInt(row["CDA_CATEGORIA"]);
                        objCategoria.Categoria = ObjectUtils.ToString(row["TX_CATEGORIA"]);
                        objCategoria.Estado.IdEstado = ObjectUtils.ToInt(row["CEA_ESTADO"]);
                        objCategoria.CountEmpresas = ObjectUtils.ToInt(row["QTD"]);

                        lstCategoria.Add(objCategoria);
                    }
                    return lstCategoria;
                }
                else
                {
                    return new List<EntCategoriaCustom>();
                }
            }
        }

        /// <summary>
        /// Popula Categoria, conforme DataReader passado
        /// </summary>
        /// <autor>Fabio Senziani</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntCategoria">Lista de EntCategoria</list></returns>
        private List<EntCategoria> Popular(DbDataReader dtrDados)
        {
            List<EntCategoria> listEntReturn = new List<EntCategoria>();
            EntCategoria entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntCategoria();

                    entReturn.IdCategoria = ObjectUtils.ToInt(dtrDados["CDA_Categoria"]);
                    entReturn.Categoria = ObjectUtils.ToString(dtrDados["TX_Categoria"]);
                    entReturn.Ativo = ObjectUtils.ToBoolean(dtrDados["FL_ATIVO"]);
                    entReturn.AceitaCpf = ObjectUtils.ToBoolean(dtrDados["FL_ACEITA_CPF"]);
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
