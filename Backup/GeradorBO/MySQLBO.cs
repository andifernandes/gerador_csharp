using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace GeradorBO
{
    public class MySQLBO
    {
        // Atributos
        public string strData = null;
        public string[] arrTabelas = null;
        public string s = null;
        public string tb = null;
        public StringBuilder objCodigo = null;
        public Banco.MySQL objBanco = null;
        public MySqlDataReader objDr = null;
        private int nunrec = 0;
        private Library.Library objLib = null;


        // Construtor
        public MySQLBO()
        {
            strData = DateTime.Today.ToShortDateString();
            s = " ";
            tb = "      ";
        }

        // Metodos
        public StringBuilder GeraCodigoBO(string strTabela, string _conexao, string _banco)
        {
            objCodigo = new StringBuilder();

            objCodigo.AppendLine("using System;");
            objCodigo.AppendLine("using System.Collections.Generic;");
            objCodigo.AppendLine("using System.Text;");
            objCodigo.AppendLine("using System.Data;");
            objCodigo.AppendLine("using MySql.Data.MySqlClient;");
            objCodigo.AppendLine("using System.Runtime.InteropServices;");
            objCodigo.AppendLine();
            objCodigo.AppendLine();
            objCodigo.AppendLine("namespace MySQL");
            objCodigo.AppendLine("{");

            if (strTabela != string.Empty)
            {
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + "/// <summary>");
                objCodigo.AppendLine(tb + "/// Classe BO: Business Objects");
                objCodigo.AppendLine(tb + "/// Criador: Anderson R Fernandes");
                objCodigo.AppendLine(tb + "/// Criada em " + strData);
                objCodigo.AppendLine(tb + "/// Contato: andersonrfernandes@yahoo.com.br");
                objCodigo.AppendLine(tb + "/// </summary>");
                objCodigo.AppendLine(tb + "public class " + strTabela + "BO");
                objCodigo.AppendLine(tb + "{");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + "MySQL.funcoes func = new MySQL.funcoes();"); //name space das funcoes principais
                objCodigo.AppendLine(tb + tb + "// Atributos");
                // atributos
                objCodigo.AppendLine(tb + tb + "private MySQL." + _banco + " objDO = null;");
                objCodigo.AppendLine(tb + tb + "private StringBuilder strSql = null;");


                // metodo FindAll--------------------------------
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + "//Métodos");
                objCodigo.AppendLine(tb + tb + "/// <summary>");
                objCodigo.AppendLine(tb + tb + "/// Seleciona todos os registros e retorna um DataSet.");
                objCodigo.AppendLine(tb + tb + "/// </summary>");
                objCodigo.AppendLine(tb + tb + "/// <returns>DataSet</returns>");
                objCodigo.AppendLine(tb + tb + "public DataSet FindAll()");
                objCodigo.AppendLine(tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + "try");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = new StringBuilder();");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" SELECT \"); ");
                objCodigo.AppendLine(tb + tb + tb + tb + "// colunas");
                objCodigo.Append(tb + tb + tb + tb + "strSql.Append(\" ");

                // pega todas as colunas da tabela

                // Abre conexão
                objBanco = new Banco.MySQL(_conexao);
                // Faz a leitura de todas as colunas da tabela
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);

                nunrec = objDr.FieldCount;

                for (int i = 0; i < nunrec - 1; i++)
                {
                    // lista as colunas
                    objCodigo.Append(objDr.GetName(i) + ", ");
                }

                // lista a última coluna sem a virgula
                objCodigo.Append(objDr.GetName(nunrec - 1) + " ");

                // Fecha conexão
                objBanco.CloseConn();
                objBanco = null;

                objCodigo.AppendLine(" \"); ");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" FROM  " + strTabela + "  \");");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "objDO = new MySQL." + _banco + "();");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "// executa consulta e retorna um DataSet");
                objCodigo.AppendLine(tb + tb + tb + tb + "return objDO.GetDataSet(strSql.ToString(), \"" + strTabela + "\");");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "catch (Exception er)");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "throw new Exception(\"Aconteceu um erro:\" + er.Message.ToString()); ");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "finally");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = null;");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + "}");
                objCodigo.AppendLine();

                // metodo FindAll com campo, orderby--------------------------------
                objCodigo.AppendLine(tb + tb + "/// <summary>");
                objCodigo.AppendLine(tb + tb + "/// Seleciona todos os registros com ordenação e retorna um DataSet.");
                objCodigo.AppendLine(tb + tb + "/// </summary>");
                objCodigo.AppendLine(tb + tb + "/// <param name=\"_campos\">campos selecionados na sql</param>");
                objCodigo.AppendLine(tb + tb + "/// <param name=\"_orderby\">campo de ordenação</param>");
                objCodigo.AppendLine(tb + tb + "/// <returns>DataSet</returns>");
                objCodigo.AppendLine(tb + tb + "public DataSet FindAll(string _campos, string _orderby)");
                objCodigo.AppendLine(tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + "try");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = new StringBuilder();");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" SELECT \"); ");
                objCodigo.AppendLine(tb + tb + tb + tb + "// colunas");
                objCodigo.Append(tb + tb + tb + tb + "strSql.Append(_campos != string.Empty ? _campos : \" ");

                // pega todas as colunas da tabela

                // Abre conexão
                objBanco = new Banco.MySQL(_conexao);
                // Faz a leitura de todas as colunas da tabela
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);

                nunrec = objDr.FieldCount;

                for (int i = 0; i < nunrec - 1; i++)
                {
                    // lista as colunas
                    objCodigo.Append(objDr.GetName(i) + ", ");
                }

                // lista a última coluna sem a virgula

                objCodigo.Append(objDr.GetName(nunrec - 1) + " ");

                // Fecha conexão
                objBanco.CloseConn();
                objBanco = null;

                objCodigo.AppendLine(" \"); ");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" FROM  " + strTabela + "  \");");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(_orderby == string.Empty ? string.Empty : \" ORDER BY \" + _orderby);");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "objDO = new MySQL." + _banco + "();");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "// executa consulta e retorna um DataSet");
                objCodigo.AppendLine(tb + tb + tb + tb + "return objDO.GetDataSet(strSql.ToString(), \"" + strTabela + "\");");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "catch (Exception er)");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "throw new Exception(\"Aconteceu um erro:\" + er.Message.ToString()); ");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "finally");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = null;");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + "}");
                objCodigo.AppendLine();

                // metodo FindAllByWhere--------------------------------
                objCodigo.AppendLine(tb + tb + "/// <summary>");
                objCodigo.AppendLine(tb + tb + "/// Seleciona todos os registros com filtro.");
                objCodigo.AppendLine(tb + tb + "/// </summary>");
                objCodigo.AppendLine(tb + tb + "/// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
                objCodigo.AppendLine(tb + tb + "/// <returns>DataSet</returns>");
                objCodigo.AppendLine(tb + tb + "public DataSet FindByWhere(string _filtro)");
                objCodigo.AppendLine(tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + "try");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = new StringBuilder();");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" SELECT \"); ");
                objCodigo.AppendLine(tb + tb + tb + tb + "// colunas");
                objCodigo.Append(tb + tb + tb + tb + "strSql.Append(\" ");

                // pega todas as colunas da tabela

                // Abre conexão
                objBanco = new Banco.MySQL(_conexao);
                // Faz a leitura de todas as colunas da tabela
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);

                nunrec = objDr.FieldCount;

                for (int i = 0; i < nunrec - 1; i++)
                {
                    // lista as colunas
                    objCodigo.Append(objDr.GetName(i) + ", ");
                }

                // lista a última coluna sem a virgula

                objCodigo.Append(objDr.GetName(nunrec - 1) + " ");

                // Fecha conexão
                objBanco.CloseConn();
                objBanco = null;

                objCodigo.AppendLine(" \"); ");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" FROM  " + strTabela + "  \");");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" WHERE ( \" + _filtro + \" ) \");");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "objDO = new MySQL." + _banco + "();");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "// executa consulta e retorna um DataSet");
                objCodigo.AppendLine(tb + tb + tb + tb + "return objDO.GetDataSet(strSql.ToString(), \"" + strTabela + "\");");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "catch (Exception er)");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "throw new Exception(\"Aconteceu um erro:\" + er.Message.ToString()); ");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "finally");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = null;");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + "}");
                objCodigo.AppendLine();

                // metodo FindAllByWhere com ordenação--------------------------------
                objCodigo.AppendLine(tb + tb + "/// <summary>");
                objCodigo.AppendLine(tb + tb + "/// Seleciona todos os registros com filtro e ordenação.");
                objCodigo.AppendLine(tb + tb + "/// </summary>");
                objCodigo.AppendLine(tb + tb + "/// <param name=\"_campos\">campos selecionados na sql</param>");
                objCodigo.AppendLine(tb + tb + "/// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
                objCodigo.AppendLine(tb + tb + "/// <param name=\"_orderby\">campo de ordenação</param>");
                objCodigo.AppendLine(tb + tb + "/// <returns>DataSet</returns>");
                objCodigo.AppendLine(tb + tb + "public DataSet FindByWhere(string _campos, string _filtro, string _orderby)");
                objCodigo.AppendLine(tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + "try");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = new StringBuilder();");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" SELECT \"); ");
                objCodigo.AppendLine(tb + tb + tb + tb + "// colunas");
                objCodigo.Append(tb + tb + tb + tb + "strSql.Append(_campos != string.Empty ? _campos : \" ");

                // pega todas as colunas da tabela

                // Abre conexão
                objBanco = new Banco.MySQL(_conexao);
                // Faz a leitura de todas as colunas da tabela
                objDr = objBanco.QueryConsulta(" SELECT * FROM " + strTabela);

                nunrec = objDr.FieldCount;

                for (int i = 0; i < nunrec - 1; i++)
                {
                    // lista as colunas
                    objCodigo.Append(objDr.GetName(i) + ", ");
                }

                // lista a última coluna sem a virgula

                objCodigo.Append(objDr.GetName(nunrec - 1) + " ");

                // Fecha conexão
                objBanco.CloseConn();
                objBanco = null;

                objCodigo.AppendLine(" \"); ");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" FROM  " + strTabela + "  \");");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" WHERE ( \" + _filtro + \" ) \");");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(_orderby == string.Empty ? string.Empty : \" ORDER BY \" + _orderby);");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "objDO = new MySQL." + _banco + "();");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "// executa consulta e retorna um DataSet");
                objCodigo.AppendLine(tb + tb + tb + tb + "return objDO.GetDataSet(strSql.ToString(), \"" + strTabela + "\");");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "catch (Exception er)");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "throw new Exception(\"Aconteceu um erro:\" + er.Message.ToString()); ");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "finally");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = null;");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + "}");
                objCodigo.AppendLine();

                // MÉTODOS DE SELEÇÃO INDIVIDUAL
                // faz um método de filtro para cada coluna da tabela

                // pega todas as colunas da tabela

                // Abre conexão
                objBanco = new Banco.MySQL(_conexao);
                // Faz a leitura de todas as colunas da tabela
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                // Objeto da clase library
                objLib = new Library.Library();
                nunrec = objDr.FieldCount;

                for (int i = 0; i < nunrec; i++)
                {
                    // lista as colunas
                    // metodo FindAllBy "campo" --------------------------------
                    objCodigo.AppendLine(tb + tb + "/// <summary>");
                    objCodigo.AppendLine(tb + tb + "/// Seleciona todos os registros por " + objDr.GetName(i) + ".");
                    objCodigo.AppendLine(tb + tb + "/// </summary>");
                    objCodigo.AppendLine(tb + tb + "/// <param name=\"_" + objDr.GetName(i) + "\">filtro da consulta</param>");
                    objCodigo.AppendLine(tb + tb + "/// <returns>DataSet</returns>");
                    objCodigo.AppendLine(tb + tb + "public DataSet FindBy_" + objDr.GetName(i) + "(" + objLib.DefineTipo(objDr.GetDataTypeName(i).ToString()) + " _" + objDr.GetName(i) + ")");
                    objCodigo.AppendLine(tb + tb + "{");
                    objCodigo.AppendLine(tb + tb + tb + "try");
                    objCodigo.AppendLine(tb + tb + tb + "{");
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql = new StringBuilder();");
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" SELECT \"); ");
                    objCodigo.AppendLine(tb + tb + tb + tb + "// colunas");
                    objCodigo.Append(tb + tb + tb + tb + "strSql.Append(\" ");

                    for (int j = 0; j < nunrec - 1; j++)
                    {
                        // lista as colunas
                        objCodigo.Append(objDr.GetName(j) + ", ");
                    }

                    // lista a última coluna sem a virgula
                    objCodigo.Append(objDr.GetName(nunrec - 1) + " ");

                    objCodigo.AppendLine(" \"); ");
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" FROM  " + strTabela + "  \");");
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" WHERE ( " + objLib.SelectParam(objDr.GetName(i).ToString(), objDr.GetDataTypeName(i).ToString()) + " ) \");");
                    objCodigo.AppendLine();
                    objCodigo.AppendLine(tb + tb + tb + tb + "objDO = new MySQL." + _banco + "();");
                    objCodigo.AppendLine();
                    objCodigo.AppendLine(tb + tb + tb + tb + "// executa consulta e retorna um DataSet");
                    objCodigo.AppendLine(tb + tb + tb + tb + "return objDO.GetDataSet(strSql.ToString(), \"" + strTabela + "\");");
                    objCodigo.AppendLine(tb + tb + tb + "}");
                    objCodigo.AppendLine(tb + tb + tb + "catch (Exception er)");
                    objCodigo.AppendLine(tb + tb + tb + "{");
                    objCodigo.AppendLine(tb + tb + tb + tb + "throw new Exception(\"Aconteceu um erro:\" + er.Message.ToString()); ");
                    objCodigo.AppendLine(tb + tb + tb + "}");
                    objCodigo.AppendLine(tb + tb + tb + "finally");
                    objCodigo.AppendLine(tb + tb + tb + "{");
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql = null;");
                    objCodigo.AppendLine(tb + tb + tb + "}");
                    objCodigo.AppendLine(tb + tb + "}");
                    objCodigo.AppendLine();

                    // lista as colunas
                    // metodo FindAllBy "campo" --------------------------------
                    objCodigo.AppendLine(tb + tb + "/// <summary>");
                    objCodigo.AppendLine(tb + tb + "/// Seleciona todos os registros por " + objDr.GetName(i) + ".");
                    objCodigo.AppendLine(tb + tb + "/// </summary>");
                    objCodigo.AppendLine(tb + tb + "/// <param name=\"_campos\">campos selecionados na sql</param>");
                    objCodigo.AppendLine(tb + tb + "/// <param name=\"_" + objDr.GetName(i) + "\">filtro da consulta</param>");
                    objCodigo.AppendLine(tb + tb + "/// <param name=\"_orderby\">campo de ordenação</param>");
                    objCodigo.AppendLine(tb + tb + "/// <returns>DataSet</returns>");
                    objCodigo.AppendLine(tb + tb + "public DataSet FindBy_" + objDr.GetName(i) + "(string _campos, " + objLib.DefineTipo(objDr.GetDataTypeName(i).ToString()) + " _" + objDr.GetName(i) + ", string _orderby)");
                    objCodigo.AppendLine(tb + tb + "{");
                    objCodigo.AppendLine(tb + tb + tb + "try");
                    objCodigo.AppendLine(tb + tb + tb + "{");
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql = new StringBuilder();");
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" SELECT \"); ");
                    objCodigo.AppendLine(tb + tb + tb + tb + "// colunas");
                    objCodigo.Append(tb + tb + tb + tb + "strSql.Append(_campos != string.Empty ? _campos : \" ");

                    for (int j = 0; j < nunrec - 1; j++)
                    {
                        // lista as colunas
                        objCodigo.Append(objDr.GetName(j) + ", ");
                    }

                    // lista a última coluna sem a virgula
                    objCodigo.Append(objDr.GetName(nunrec - 1) + " ");

                    objCodigo.AppendLine(" \"); ");
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" FROM  " + strTabela + "  \");");
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" WHERE ( " + objLib.SelectParam(objDr.GetName(i).ToString(), objDr.GetDataTypeName(i).ToString()) + " ) \");");
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(_orderby == string.Empty ? string.Empty : \" ORDER BY \" + _orderby);");
                    objCodigo.AppendLine();
                    objCodigo.AppendLine(tb + tb + tb + tb + "objDO = new MySQL." + _banco + "();");
                    objCodigo.AppendLine();
                    objCodigo.AppendLine(tb + tb + tb + tb + "// executa consulta e retorna um DataSet");
                    objCodigo.AppendLine(tb + tb + tb + tb + "return objDO.GetDataSet(strSql.ToString(), \"" + strTabela + "\");");
                    objCodigo.AppendLine(tb + tb + tb + "}");
                    objCodigo.AppendLine(tb + tb + tb + "catch (Exception er)");
                    objCodigo.AppendLine(tb + tb + tb + "{");
                    objCodigo.AppendLine(tb + tb + tb + tb + "throw new Exception(\"Aconteceu um erro:\" + er.Message.ToString()); ");
                    objCodigo.AppendLine(tb + tb + tb + "}");
                    objCodigo.AppendLine(tb + tb + tb + "finally");
                    objCodigo.AppendLine(tb + tb + tb + "{");
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql = null;");
                    objCodigo.AppendLine(tb + tb + tb + "}");
                    objCodigo.AppendLine(tb + tb + "}");
                    objCodigo.AppendLine();


                }

                // lista a última coluna sem a virgula

                // Fecha conexão
                objBanco.CloseConn();
                objBanco = null;

                // fazer toda validação dos campos
                // metodo Insert--------------------------------
                objCodigo.AppendLine(tb + tb + "/// <summary>");
                objCodigo.AppendLine(tb + tb + "/// Insere os registros do banco e retorna o número de linhas afetadas.");
                objCodigo.AppendLine(tb + tb + "/// </summary>");
                objCodigo.AppendLine(tb + tb + "/// <param name=\"_vo\">objetos vo do banco</param>");
                objCodigo.AppendLine(tb + tb + "/// <returns>int</returns>");
                objCodigo.AppendLine(tb + tb + "public int Insert(MySQL." + strTabela + "VO _vo)");
                objCodigo.AppendLine(tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + "try");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = new StringBuilder();");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" INSERT INTO  " + strTabela + "  \"); ");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" (\"); ");
                objCodigo.AppendLine();

                // pega todas as colunas da tabela

                // Abre conexão
                objBanco = new Banco.MySQL(_conexao);
                // Faz a leitura de todas as colunas da tabela
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);

                nunrec = objDr.FieldCount;

                for (int i = 0; i < nunrec - 1; i++)
                {
                    // lista as colunas
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" " + objDr.GetName(i) + ", \"); ");
                }

                // lista a última coluna sem a virgula
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" " + objDr.GetName(nunrec - 1) + " \"); ");

                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" ) \"); ");

                // Valores
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" VALUES (\"); ");

                // objeto da classe Libary
                objLib = new Library.Library();

                for (int i = 0; i < nunrec - 1; i++)
                {
                    // lista as colunas
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" " + objLib.InsertParam(objDr.GetName(i).ToString(), objDr.GetDataTypeName(i).ToString()) + ", \"); ");
                }

                // lista a última coluna sem a virgula
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" " + objLib.InsertParam(objDr.GetName(nunrec - 1).ToString(), objDr.GetDataTypeName(nunrec - 1).ToString()) + " \"); ");

                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" ) \"); ");

                objCodigo.AppendLine();
                //objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" WHERE (" +
                //   objLib.UpdateParam(objDr.GetName(0).ToString(), objDr.GetDataTypeName(0).ToString()) +
                //    " ) \");");


                // Fecha conexão
                objBanco.CloseConn();
                objBanco = null;



                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "objDO = new MySQL." + _banco + "();");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "// executa comando e retorna o número de linhas afetadas.");
                objCodigo.AppendLine(tb + tb + tb + tb + "return objDO.ExecutaQuery(strSql.ToString());");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "catch (Exception er)");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "throw new Exception(\"Aconteceu um erro:\" + er.Message.ToString()); ");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "finally");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = null;");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + "}");
                objCodigo.AppendLine();


                // metodo Update--------------------------------
                objCodigo.AppendLine(tb + tb + "/// <summary>");
                objCodigo.AppendLine(tb + tb + "/// Atualiza os registros do banco e retorna o número de linhas afetadas.");
                objCodigo.AppendLine(tb + tb + "/// </summary>");
                objCodigo.AppendLine(tb + tb + "/// <param name=\"_vo\">objetos vo do banco</param>");
                objCodigo.AppendLine(tb + tb + "/// <returns>int</returns>");
                objCodigo.AppendLine(tb + tb + "public int Update(MySQL." + strTabela + "VO _vo)");
                objCodigo.AppendLine(tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + "try");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = new StringBuilder();");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" UPDATE  " + strTabela + "  \"); ");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" SET \"); ");
                objCodigo.AppendLine();

                // Abre conexão
                objBanco = new Banco.MySQL(_conexao);
                // Faz a leitura de todas as colunas da tabela
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                // Cria o objeto da classe Library
                objLib = new Library.Library();

                nunrec = objDr.FieldCount;

                for (int i = 1; i < nunrec - 1; i++)
                {

                    // Seta as colunas
                    objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\"  " +
                        objLib.UpdateParam(objDr.GetName(i).ToString(), objDr.GetDataTypeName(i).ToString()) + ", " +
                        " \"); ");
                }

                // Seta a última coluna sem a virgula

                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\"  " +
                    objLib.UpdateParam(objDr.GetName(nunrec - 1).ToString(), objDr.GetDataTypeName(nunrec - 1).ToString()) + " " +
                    " \"); ");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" WHERE (" +
                    objLib.UpdateParam(objDr.GetName(0).ToString(), objDr.GetDataTypeName(0).ToString()) +
                    " ) \");");

                // Fecha conexão
                objBanco.CloseConn();
                objBanco = null;
                objLib = null;

                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "objDO = new MySQL." + _banco + "();");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "// executa comando e retorna o número de linhas afetadas.");
                objCodigo.AppendLine(tb + tb + tb + tb + "return objDO.ExecutaQuery(strSql.ToString());");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "catch (Exception er)");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "throw new Exception(\"Aconteceu um erro:\" + er.Message.ToString()); ");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "finally");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = null;");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + "}");
                objCodigo.AppendLine();

                // metodo Delete--------------------------------
                objCodigo.AppendLine(tb + tb + "/// <summary>");
                objCodigo.AppendLine(tb + tb + "/// Deleta os registros do banco e retorna o número de linhas afetadas.");
                objCodigo.AppendLine(tb + tb + "/// </summary>");
                objCodigo.AppendLine(tb + tb + "/// <param name=\"_vo\">objetos vo do banco</param>");
                objCodigo.AppendLine(tb + tb + "/// <returns>int</returns>");
                objCodigo.AppendLine(tb + tb + "public int Delete(MySQL." + strTabela + "VO _vo)");
                objCodigo.AppendLine(tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + "try");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = new StringBuilder();");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" DELETE FROM " + strTabela + "  \"); ");

                // Abre conexão
                objBanco = new Banco.MySQL(_conexao);
                // Faz a leitura de todas as colunas da tabela
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);

                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" WHERE ( " +
                    objDr.GetName(0).ToString() + " = \" + _vo." + objDr.GetName(0).ToString() + " + \" ) \");");

                // Fecha conexão
                objBanco.CloseConn();
                objBanco = null;

                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "objDO = new MySQL." + _banco + "();");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "// executa comando e retorna o número de linhas afetadas.");
                objCodigo.AppendLine(tb + tb + tb + tb + "return objDO.ExecutaQuery(strSql.ToString());");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "catch (Exception er)");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "throw new Exception(\"Aconteceu um erro:\" + er.Message.ToString()); ");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "finally");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = null;");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + "}");
                objCodigo.AppendLine();

                // metodo LastId--------------------------------
                objCodigo.AppendLine(tb + tb + "/// <summary>");
                objCodigo.AppendLine(tb + tb + "/// Encontre o ultimo id inserido no banco.");
                objCodigo.AppendLine(tb + tb + "/// </summary>");
                objCodigo.AppendLine(tb + tb + "/// <returns>DataSet</returns>");
                objCodigo.AppendLine(tb + tb + "public DataSet last_id()");
                objCodigo.AppendLine(tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + "try");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = new StringBuilder();");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" select max(id)as id from " + strTabela + "  \"); ");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "objDO = new MySQL." + _banco + "();");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "// executa comando e retorna o ultimo id.");
                objCodigo.AppendLine(tb + tb + tb + tb + "return objDO.GetDataSet(strSql.ToString(), \"" + strTabela + "\");");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "catch (Exception er)");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "throw new Exception(\"Aconteceu um erro:\" + er.Message.ToString()); ");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "finally");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = null;");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + "}");
                objCodigo.AppendLine();

                // metodo FindCampos--------------------------------
                objCodigo.AppendLine(tb + tb + "/// <summary>");
                objCodigo.AppendLine(tb + tb + "/// Encontra os nomes de todos os campos de uma tabela.");
                objCodigo.AppendLine(tb + tb + "/// </summary>");
                objCodigo.AppendLine(tb + tb + "/// <returns>DataSet</returns>");
                objCodigo.AppendLine(tb + tb + "public DataSet FindCampos()");
                objCodigo.AppendLine(tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + "try");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = new StringBuilder();");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql.Append(\" show full fields from " + strTabela + "  \"); ");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "objDO = new MySQL." + _banco + "();");
                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + tb + tb + "// executa comando e retorna campos.");
                objCodigo.AppendLine(tb + tb + tb + tb + "return objDO.GetDataSet(strSql.ToString(), \"" + strTabela + "\");");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "catch (Exception er)");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "throw new Exception(\"Aconteceu um erro:\" + er.Message.ToString()); ");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + tb + "finally");
                objCodigo.AppendLine(tb + tb + tb + "{");
                objCodigo.AppendLine(tb + tb + tb + tb + "strSql = null;");
                objCodigo.AppendLine(tb + tb + tb + "}");
                objCodigo.AppendLine(tb + tb + "}");
                objCodigo.AppendLine();

                // Fim dos métodos BO
                objCodigo.AppendLine(tb + "}");
                objCodigo.AppendLine();

            }
            objCodigo.AppendLine("}");

            return objCodigo;
        }


    }
}
