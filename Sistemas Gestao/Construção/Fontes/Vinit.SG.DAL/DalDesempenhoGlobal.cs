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
    /// Classe de Dados que representa um Desempenho Global
    /// </summary>
    public class DalDesempenhoGlobal
    {

        /// <summary>
        /// Retorna um Desempenho Global
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCargo">Lista de EntDesempenhoGlobal</list></returns>
        public List<EntDesempenhoGlobal> GerarDesempenhoGlobal2010(EntDesempenhoGlobal objDesempenhoGlobal, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaDesempenhoGlobal2010");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@NomeFantasia", DbType.String, objDesempenhoGlobal.NomeFantasia);
            db.AddInParameter(dbCommand, "@CPF_CNPJ", DbType.String, objDesempenhoGlobal.CPF_CNPJ);
            db.AddInParameter(dbCommand, "@Regiao", DbType.Int32, objDesempenhoGlobal.Regiao);
            db.AddInParameter(dbCommand, "@Categoria", DbType.Int32, objDesempenhoGlobal.Categoria);
            db.AddInParameter(dbCommand, "@Grupo", DbType.Int32, objDesempenhoGlobal.Grupo);
            db.AddInParameter(dbCommand, "@Estado", DbType.Int32, objDesempenhoGlobal.Estado);
            db.AddInParameter(dbCommand, "@EstadoRegiao", DbType.Int32, objDesempenhoGlobal.EstadoRegiao);
            db.AddInParameter(dbCommand, "@Cidade", DbType.Int32, objDesempenhoGlobal.Cidade);
            db.AddInParameter(dbCommand, "@EscritorioRegional", DbType.Int32, objDesempenhoGlobal.EscritorioRegional);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, objDesempenhoGlobal.Status);
            db.AddInParameter(dbCommand, "@PremioEspecial", DbType.Int32, objDesempenhoGlobal.PremioEspecial);
            db.AddInParameter(dbCommand, "@Turma", DbType.Int32, objDesempenhoGlobal.Turma);



            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntDesempenhoGlobal>();
                }
            }
        }

        /// <summary>
        /// Retorna um Desempenho Global
        /// </summary>
        /// <autor>Fernando Carvalho</autor>
        /// <param name="transaction">Transaction</param>
        /// <param name="db">DataBase</param>          
        /// <returns><list type="EntCargo">Lista de EntDesempenhoGlobal</list></returns>
        public List<EntDesempenhoGlobal> GerarDesempenhoGlobal2011(EntDesempenhoGlobal objDesempenhoGlobal, DbTransaction transaction, Database db)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("STP_SelecionaDesempenhoGlobal2011");
            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            db.AddInParameter(dbCommand, "@NomeFantasia", DbType.String, objDesempenhoGlobal.NomeFantasia);
            db.AddInParameter(dbCommand, "@CPF_CNPJ", DbType.String, objDesempenhoGlobal.CPF_CNPJ);
            db.AddInParameter(dbCommand, "@Regiao", DbType.Int32, IntUtils.ToIntNull(objDesempenhoGlobal.Regiao));
            db.AddInParameter(dbCommand, "@Categoria", DbType.Int32, IntUtils.ToIntNull(objDesempenhoGlobal.Categoria));
            db.AddInParameter(dbCommand, "@Grupo", DbType.Int32, IntUtils.ToIntNull(objDesempenhoGlobal.Grupo));
            db.AddInParameter(dbCommand, "@Estado", DbType.Int32, IntUtils.ToIntNull(objDesempenhoGlobal.Estado));
            db.AddInParameter(dbCommand, "@EstadoRegiao", DbType.Int32, IntUtils.ToIntNull(objDesempenhoGlobal.EstadoRegiao));
            db.AddInParameter(dbCommand, "@Cidade", DbType.Int32, IntUtils.ToIntNull(objDesempenhoGlobal.Cidade));
            db.AddInParameter(dbCommand, "@EscritorioRegional", DbType.Int32, IntUtils.ToIntNull(objDesempenhoGlobal.EscritorioRegional));
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, IntUtils.ToIntNull(objDesempenhoGlobal.Status));
            db.AddInParameter(dbCommand, "@PremioEspecial", DbType.Int32, BooleanUtils.ToInt(objDesempenhoGlobal.PremioEspecial));
            db.AddInParameter(dbCommand, "@Turma", DbType.Int32, IntUtils.ToIntNull(objDesempenhoGlobal.Turma));



            dbCommand.CommandTimeout = BdConfig.CommmandTimeout;

            using (DbDataReader dtrDados = (System.Data.Common.DbDataReader)db.ExecuteReader(dbCommand, transaction))
            {
                if (dtrDados != null && dtrDados.HasRows)
                {
                    return this.Popular(dtrDados);
                }
                else
                {
                    return new List<EntDesempenhoGlobal>();
                }
            }
        }



        /// <summary>
        /// Popula Relatorio Desempenho Global, conforme DataReader passado
        /// </summary>
        /// <autor>Robinson Campos</autor>
        /// <param name="dtrDados">DataReader a ser percorrido.</param>
        /// <returns><list type="EntCargo">Lista de RelRankingFinalista</list></returns>
        private List<EntDesempenhoGlobal> Popular(DbDataReader dtrDados)
        {
            List<EntDesempenhoGlobal> listEntReturn = new List<EntDesempenhoGlobal>();
            EntDesempenhoGlobal entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntDesempenhoGlobal();

                    entReturn.Criterio = ObjectUtils.ToString(dtrDados["CRITERIO"]);
                    entReturn.PontuacaoMaxima = ObjectUtils.ToString(dtrDados["PONTUACAO_MAXIMA"]);
                    entReturn.PontuacaoObtida = ObjectUtils.ToDouble(dtrDados["PONTUACAO_OBTIDA"]);
                    
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
