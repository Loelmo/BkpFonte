using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Xml;
using System.Data;
using System.IO;
using Vinit.SG.Common;

namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa uma TurmaEmpresa
    /// </summary>
    public class BllIntegracaoSiac : BllBase
    {
//        private DalIntegracaoSiac dalIntegracaoSiac = new DalIntegracaoSiac();

        private DalQuestionarioEmpresa dalQuestionarioEmpresa = new DalQuestionarioEmpresa();
        private DalTurmaEmpresa dalTurmaEmpresa = new DalTurmaEmpresa();
        private DalQuestionarioEmpresaAvaliador dalQuestionarioEmpresaAvaliador = new DalQuestionarioEmpresaAvaliador();
        private DalQuestionarioPontuacao dalQuestionarioPontuacao = new DalQuestionarioPontuacao();
        private DalEstado dalEstado = new DalEstado();
        private DalCidade dalCidade = new DalCidade();
        private DalBairro dalBairro = new DalBairro();
        private DalAtividadeEconomica dalAtividadeEconomica = new DalAtividadeEconomica();
        private DalTipoEmpresa dalTipoEmpresa = new DalTipoEmpresa();

        public void ObterEstadosSiac(String xml)
        {
            xml = ProcessaXmlEstados(xml);
            var dataTable = new DataTable();
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
            dataTable.ReadXml(xmlReader);
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        EntEstado entReturn = new EntEstado();
                        entReturn.CodSiacweb = ObjectUtils.ToInt(dataTable.Rows[i]["CodEst"]);
                        entReturn.Sigla = ObjectUtils.ToString(dataTable.Rows[i]["AbrevEst"]);
                        dalEstado.AlterarDadosSiac(entReturn, transaction, db);
                        transaction.Commit();
                    }
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

        public void ObterCidadesSiac(String xml, Int32 IdEstado)
        {
            xml = ProcessaXmlCidades(xml);
            var dataTable = new DataTable();
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
            dataTable.ReadXml(xmlReader);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                EntCidade entReturn = new EntCidade();
                entReturn.CodSiacweb = ObjectUtils.ToInt(dataTable.Rows[i]["codcid"]);
                entReturn.Cidade = ObjectUtils.ToString(dataTable.Rows[i]["DescCid"]);
                entReturn.Estado.IdEstado = IdEstado;
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        EntCidade cidadeTemp = dalCidade.ObterCidadePorNomeEstado(entReturn.Cidade, entReturn.Estado.IdEstado, transaction, db);
                        if (cidadeTemp != null)
                        {
                            cidadeTemp.CodSiacweb = entReturn.CodSiacweb;
                            dalCidade.AlterarDadosSiac(cidadeTemp, transaction, db);
                        }
                        else
                        {
                            dalCidade.Inserir(entReturn, transaction, db);
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

        public void ObterBairrosSiac(String xml, Int32 IdCidade)
        {
            xml = ProcessaXmlBairros(xml);
            var dataTable = new DataTable();
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
            dataTable.ReadXml(xmlReader);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                EntBairro entReturn = new EntBairro();
                entReturn.CodSiacweb = ObjectUtils.ToInt(dataTable.Rows[i]["CodBairro"]);
                entReturn.Bairro = ObjectUtils.ToString(dataTable.Rows[i]["DescBairro"]);
                entReturn.Cidade.IdCidade = IdCidade;
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        EntBairro bairroTemp = dalBairro.ObterBairroPorNomeCidade(entReturn.Bairro, entReturn.Cidade.IdCidade, transaction, db);
                        if (bairroTemp != null)
                        {
                            bairroTemp.CodSiacweb = entReturn.CodSiacweb;
                            dalBairro.AlterarDadosSiac(bairroTemp, transaction, db);
                        }
                        else
                        {
                            dalBairro.Inserir(entReturn, transaction, db);
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

        public void ObterAtividadesEconomicasSiac(String xml)
        {
            xml = ProcessaXmlAtividadesEconomicas(xml);
            var dataTable = new DataTable();
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
            dataTable.ReadXml(xmlReader);
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        EntAtividadeEconomica entReturn = new EntAtividadeEconomica();
                        entReturn = dalAtividadeEconomica.ObterPorNome(ObjectUtils.ToString(dataTable.Rows[i]["DescCnaeFiscal"]), transaction, db);
                        entReturn.Codigo = ObjectUtils.ToInt(dataTable.Rows[i]["Codigo"]);
                        entReturn.AtividadeEconomica = ObjectUtils.ToString(dataTable.Rows[i]["DescCnaeFiscal"]);
                        dalAtividadeEconomica.AlterarDadosSiac(entReturn, transaction, db);
                        transaction.Commit();
                    }
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

        public void ObterCargosSiac()
        {
        }

        public void ObterEscolaridadesSiac()
        {
        }

        public void ObterFaturamentosSiac()
        {
        }

        public void ObterPortesSiac()
        {
        }

        public void ObterSetoresSiac()
        {
        }

        public void ObterTiposEmpresasSiac(String xml)
        {
            xml = ProcessaXmlTipoEmpresa(xml);
            var dataTable = new DataTable();
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
            dataTable.ReadXml(xmlReader);
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        EntTipoEmpresa entReturn = new EntTipoEmpresa();
                        entReturn = dalTipoEmpresa.ObterPorNome(ObjectUtils.ToString(dataTable.Rows[i]["DescConst"]), transaction, db);
                        if (entReturn == null)
                        {
                            entReturn = new EntTipoEmpresa();
                            entReturn.TipoEmpresa = ObjectUtils.ToString(dataTable.Rows[i]["DescConst"]);
                            entReturn.CodSiacweb = ObjectUtils.ToInt(dataTable.Rows[i]["CodConst"]);
                            entReturn = dalTipoEmpresa.Inserir(entReturn, transaction, db);
                        }
                        else
                        {
                            entReturn.CodSiacweb = ObjectUtils.ToInt(dataTable.Rows[i]["CodConst"]);
                            dalTipoEmpresa.AlterarDadosSiac(entReturn, transaction, db);
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

        public void InserirCadastroSiac(String xml)
        {
            xml = ProcessaXmlEstados(xml);
            var dataTable = new DataTable();
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
            dataTable.ReadXml(xmlReader);
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        EntEstado entReturn = new EntEstado();
                        entReturn.CodSiacweb = ObjectUtils.ToInt(dataTable.Rows[i]["CodEst"]);
                        entReturn.Sigla = ObjectUtils.ToString(dataTable.Rows[i]["AbrevEst"]);
                        dalEstado.AlterarDadosSiac(entReturn, transaction, db);
                        transaction.Commit();
                    }
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

        public EntEstado ObterEstadoPorCep(String xml)
        {
            EntEstado entReturn = new EntEstado();
            xml = ProcessaXmlEnderecoPeloCep(xml);
            var dataTable = new DataTable();
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
            dataTable.ReadXml(xmlReader);
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    for (int i = 0; i < 1; i++)
                    {
                        entReturn.CodSiacweb = ObjectUtils.ToInt(dataTable.Rows[i]["CodEst"]);
                        entReturn = dalEstado.ObterPorIdSiac(entReturn.CodSiacweb, transaction, db);
                        transaction.Commit();
                    }
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
            return entReturn;
        }

        public EntCidade ObterCidadePorCep(String xml)
        {
            EntCidade entReturn = new EntCidade();
            xml = ProcessaXmlEnderecoPeloCep(xml);
            var dataTable = new DataTable();
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
            dataTable.ReadXml(xmlReader);
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    for (int i = 0; i < 1; i++)
                    {
                        entReturn.CodSiacweb = ObjectUtils.ToInt(dataTable.Rows[i]["CodCid"]);
                        entReturn = dalCidade.ObterPorCodSiac(entReturn.CodSiacweb, transaction, db);
                        transaction.Commit();
                    }
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
            return entReturn;
        }

        public EntBairro ObterBairroPorCep(String xml)
        {
            EntBairro entReturn = new EntBairro();
            xml = ProcessaXmlEnderecoPeloCep(xml);
            var dataTable = new DataTable();
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
            dataTable.ReadXml(xmlReader);
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    for (int i = 0; i < 1; i++)
                    {
                        entReturn.CodSiacweb = ObjectUtils.ToInt(dataTable.Rows[i]["codbairro"]);
                        entReturn = dalBairro.ObterPorIdSiac(entReturn.CodSiacweb, transaction, db);
                        transaction.Commit();
                    }
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
            return entReturn;
        }

        public String ObterEnderecoPorCep(String xml)
        {
            String entReturn = "";
            xml = ProcessaXmlEnderecoPeloCep(xml);
            var dataTable = new DataTable();
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
            dataTable.ReadXml(xmlReader);
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    for (int i = 0; i < 1; i++)
                    {
                        entReturn = ObjectUtils.ToString(dataTable.Rows[i]["NomeLogr"]);
                        transaction.Commit();
                    }
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
            return entReturn;
        }

        private String ProcessaXmlAtividadesEconomicas(String xml)
        {
            xml = "<NewDataSet xmlns=\"\">\n" +
            "<xs:schema id=\"NewDataSet\" xmlns=\"\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">\n" +
            "<xs:element name=\"NewDataSet\" msdata:IsDataSet=\"true\" msdata:MainDataTable=\"Table\" msdata:UseCurrentLocale=\"true\">\n" +
            "<xs:complexType>\n      <xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\n        <xs:element name=\"Table\">\n" +
            "<xs:complexType>\n            <xs:sequence>\n              <xs:element name=\"Codigo\" type=\"xs:int\" minOccurs=\"0\" />\n" +
            "<xs:element name=\"DescCnaeFiscal\" type=\"xs:string\" minOccurs=\"0\" />\n" +
            "<xs:element name=\"codsetor\" type=\"xs:int\" minOccurs=\"0\" />\n" +
            "</xs:sequence>\n          </xs:complexType>\n        </xs:element>\n      </xs:choice>\n    </xs:complexType>\n  </xs:element>\n</xs:schema>" +
            xml.Substring(12);

            return xml;
        }

        private String ProcessaXmlTipoEmpresa(String xml)
        {
            xml = "<NewDataSet xmlns=\"\">\n" +
            "<xs:schema id=\"NewDataSet\" xmlns=\"\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">\n" +
            "<xs:element name=\"NewDataSet\" msdata:IsDataSet=\"true\" msdata:MainDataTable=\"Table\" msdata:UseCurrentLocale=\"true\">\n" +
            "<xs:complexType>\n      <xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\n        <xs:element name=\"Table\">\n" +
            "<xs:complexType>\n            <xs:sequence>\n              <xs:element name=\"CodConst\" type=\"xs:int\" minOccurs=\"0\" />\n" +
            "<xs:element name=\"DescConst\" type=\"xs:string\" minOccurs=\"0\" />\n" +
            "</xs:sequence>\n          </xs:complexType>\n        </xs:element>\n      </xs:choice>\n    </xs:complexType>\n  </xs:element>\n</xs:schema>" +
            xml.Substring(12);

            return xml;
        }

        private String ProcessaXmlEstados(String xml)
        {
            xml = "<NewDataSet xmlns=\"\">\n" + 
            "<xs:schema id=\"NewDataSet\" xmlns=\"\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">\n" + 
            "<xs:element name=\"NewDataSet\" msdata:IsDataSet=\"true\" msdata:MainDataTable=\"Table\" msdata:UseCurrentLocale=\"true\">\n" + 
            "<xs:complexType>\n      <xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\n        <xs:element name=\"Table\">\n" + 
            "<xs:complexType>\n            <xs:sequence>\n              <xs:element name=\"DescEst\" type=\"xs:string\" minOccurs=\"0\" />\n" + 
            "<xs:element name=\"AbrevEst\" type=\"xs:string\" minOccurs=\"0\" />\n" + 
            "<xs:element name=\"CodEst\" type=\"xs:int\" minOccurs=\"0\" />\n" + 
            "</xs:sequence>\n          </xs:complexType>\n        </xs:element>\n      </xs:choice>\n    </xs:complexType>\n  </xs:element>\n</xs:schema>" +
            xml.Substring(12);

            return xml;
        }

        private String ProcessaXmlCidades(String xml)
        {
            xml = "<NewDataSet xmlns=\"\">\n" +
            "<xs:schema id=\"NewDataSet\" xmlns=\"\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">\n" +
            "<xs:element name=\"NewDataSet\" msdata:IsDataSet=\"true\" msdata:MainDataTable=\"Table\" msdata:UseCurrentLocale=\"true\">\n" +
            "<xs:complexType>\n      <xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\n        <xs:element name=\"Table\">\n" +
            "<xs:complexType>\n            <xs:sequence>\n              " +
            "<xs:element name=\"DescCid\" type=\"xs:string\" minOccurs=\"0\" />\n" +
            "<xs:element name=\"codcid\" type=\"xs:int\" minOccurs=\"0\" />\n" +
            "</xs:sequence>\n          </xs:complexType>\n        </xs:element>\n      </xs:choice>\n    </xs:complexType>\n  </xs:element>\n</xs:schema>" +
            xml.Substring(12);

            return xml;
        }

        private String ProcessaXmlBairros(String xml)
        {
            xml = "<NewDataSet xmlns=\"\">\n" +
            "<xs:schema id=\"NewDataSet\" xmlns=\"\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">\n" +
            "<xs:element name=\"NewDataSet\" msdata:IsDataSet=\"true\" msdata:MainDataTable=\"Table\" msdata:UseCurrentLocale=\"true\">\n" +
            "<xs:complexType>\n      <xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\n        <xs:element name=\"Table\">\n" +
            "<xs:complexType>\n            <xs:sequence>\n              " +
            "<xs:element name=\"DescBairro\" type=\"xs:string\" minOccurs=\"0\" />\n" +
            "<xs:element name=\"CodBairro\" type=\"xs:int\" minOccurs=\"0\" />\n" +
            "</xs:sequence>\n          </xs:complexType>\n        </xs:element>\n      </xs:choice>\n    </xs:complexType>\n  </xs:element>\n</xs:schema>" +
            xml.Substring(12);

            return xml;
        }

        private String ProcessaXmlEnderecoPeloCep(String xml)
        {
            xml = "<NewDataSet xmlns=\"\">\n" +
            "<xs:schema id=\"NewDataSet\" xmlns=\"\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">\n" +
            "<xs:element name=\"NewDataSet\" msdata:IsDataSet=\"true\" msdata:MainDataTable=\"Table\" msdata:UseCurrentLocale=\"true\">\n" +
            "<xs:complexType>\n      <xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">\n        <xs:element name=\"Table\">\n" +
            "<xs:complexType>\n            <xs:sequence>\n              <xs:element name=\"DescEst\" type=\"xs:string\" minOccurs=\"0\" />\n" +
            "<xs:element name=\"DescCid\" type=\"xs:string\" minOccurs=\"0\" />\n" +
            "<xs:element name=\"Descbairro\" type=\"xs:string\" minOccurs=\"0\" />\n" +
            "<xs:element name=\"NomeLogr\" type=\"xs:string\" minOccurs=\"0\" />\n" +
            "<xs:element name=\"codpais\" type=\"xs:int\" minOccurs=\"0\" />\n" +
            "<xs:element name=\"CodEst\" type=\"xs:int\" minOccurs=\"0\" />\n" +
            "<xs:element name=\"CodCid\" type=\"xs:int\" minOccurs=\"0\" />\n" +
            "<xs:element name=\"codbairro\" type=\"xs:int\" minOccurs=\"0\" />\n" +
            "<xs:element name=\"Cep\" type=\"xs:string\" minOccurs=\"0\" />\n" +
            "</xs:sequence>\n          </xs:complexType>\n        </xs:element>\n      </xs:choice>\n    </xs:complexType>\n  </xs:element>\n</xs:schema>" +
            xml.Substring(12);

            return xml;
        }
    }
}
