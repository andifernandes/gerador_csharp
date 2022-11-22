using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorDO
{
    /// <summary>
    /// Classe DO
    /// Criador: Anderson R Fernandes
    /// Criada em 25/09/2010
    /// Contato: andersonrfernandes@yahoo.com.br
    /// </summary>
    /// 
    public class SQLServerDO
    {
        // atributos
        public string strData = null;
        public string s = null;
        public string tb = null;
        public StringBuilder objCodigo = null;

        // construtor
        public SQLServerDO()
        {
            strData = DateTime.Today.ToShortDateString();
            s = " ";
            tb = "      ";

        }


        // metodos
        public StringBuilder GeraCodigoDO(string _banco, string _conexao)
        {

            objCodigo = new StringBuilder();

            objCodigo.AppendLine("using System;");
            objCodigo.AppendLine("using System.Collections.Generic;");
            objCodigo.AppendLine("using System.Text;");
            objCodigo.AppendLine("using System.Data;");
            objCodigo.AppendLine("using System.Data.SqlClient;");
            objCodigo.AppendLine();
            objCodigo.AppendLine();
            objCodigo.AppendLine("namespace SQLServer");
            objCodigo.AppendLine("{");
            objCodigo.AppendLine();
            objCodigo.AppendLine(tb + "/// <summary>");
            objCodigo.AppendLine(tb + "/// Classe DO: Data Objects");
            objCodigo.AppendLine(tb + "/// Criador: Anderson R Fernandes");
            objCodigo.AppendLine(tb + "/// Criada em " + strData);
            objCodigo.AppendLine(tb + "/// Contato: andersonrfernandes@yahoo.com.br");
            objCodigo.AppendLine(tb + "/// </summary>");
            objCodigo.AppendLine(tb + "public class " + _banco);
            objCodigo.AppendLine(tb + "{");
            objCodigo.AppendLine(tb + tb + "// Atributos");
            //atributos
            objCodigo.AppendLine(tb + tb + "private SqlConnection oConnection = null;");
            objCodigo.AppendLine(tb + tb + "private string connectionString = null;");
            objCodigo.AppendLine(tb + tb + "private SqlDataAdapter oDataAdapter = null;");
            objCodigo.AppendLine(tb + tb + "private SqlCommand oCommand = null;");
            objCodigo.AppendLine(tb + tb + "private DataSet oDataSet = null;");
            objCodigo.AppendLine(tb + tb + "private string strServidor = null;");
            //construtor
            objCodigo.AppendLine(tb + tb + "//Construtor");
            objCodigo.AppendLine(tb + tb + "public " + _banco + "()");
            objCodigo.AppendLine(tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + "connectionString = \"" + _conexao + "\";");
            objCodigo.AppendLine(tb + tb + tb + "oConnection = new SqlConnection(connectionString);");
            objCodigo.AppendLine(tb + tb + "}");
            //Metodos
            objCodigo.AppendLine(tb + tb + "//Métodos");
            objCodigo.AppendLine(tb + tb + "/// <summary>");
            objCodigo.AppendLine(tb + tb + "/// Executa comandos sql e retorna o número de linhas afetadas.");
            objCodigo.AppendLine(tb + tb + "/// </summary>");
            objCodigo.AppendLine(tb + tb + "/// <param name=\"sSQL\">Comando sql</param>");
            objCodigo.AppendLine(tb + tb + "/// <returns>int regAffect</returns>");
            objCodigo.AppendLine(tb + tb + "/// <returns>int regAffect</returns>");
            objCodigo.AppendLine(tb + tb + "public int ExecutaQuery(string sSQL)");
            objCodigo.AppendLine(tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + "int regAffect = 0;");
            objCodigo.AppendLine(tb + tb + tb + "try");
            objCodigo.AppendLine(tb + tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + tb + "oCommand = new SqlCommand(sSQL, oConnection);");
            objCodigo.AppendLine(tb + tb + tb + tb + "oConnection.Open();");
            objCodigo.AppendLine(tb + tb + tb + tb + "regAffect = oCommand.ExecuteNonQuery();");
            objCodigo.AppendLine(tb + tb + tb + tb + "if (regAffect == 0)");
            objCodigo.AppendLine(tb + tb + tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + tb + tb + "throw new Exception(\"Ocorreu um erro, entre em contato com o administrador do sistema.\");");
            objCodigo.AppendLine(tb + tb + tb + tb + "}");
            objCodigo.AppendLine(tb + tb + tb + tb + "else");
            objCodigo.AppendLine(tb + tb + tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + tb + tb + "return regAffect;");
            objCodigo.AppendLine(tb + tb + tb + tb + "}");
            objCodigo.AppendLine(tb + tb + tb + "}");
            objCodigo.AppendLine(tb + tb + tb + "catch (Exception err)");
            objCodigo.AppendLine(tb + tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + tb + "throw err;");
            objCodigo.AppendLine(tb + tb + tb + "}");
            objCodigo.AppendLine(tb + tb + tb + "finally");
            objCodigo.AppendLine(tb + tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + tb + "oConnection.Dispose();");
            objCodigo.AppendLine(tb + tb + tb + tb + "oCommand.Dispose();");
            objCodigo.AppendLine(tb + tb + tb + "}");
            objCodigo.AppendLine(tb + tb + "}");
            objCodigo.AppendLine();
            objCodigo.AppendLine(tb + tb + "/// <summary>");
            objCodigo.AppendLine(tb + tb + "/// Retorna um data set apartir de um comando sql");
            objCodigo.AppendLine(tb + tb + "/// </summary>");
            objCodigo.AppendLine(tb + tb + "/// <param name=\"command\">Comando sql</param>");
            objCodigo.AppendLine(tb + tb + "/// <param name=\"table\">Nome da tabela</param>");
            objCodigo.AppendLine(tb + tb + "/// <returns>DataSet oDataSet</returns>");
            objCodigo.AppendLine(tb + tb + "public DataSet GetDataSet(string command, string table)");
            objCodigo.AppendLine(tb + tb + "{");
            objCodigo.AppendLine();
            objCodigo.AppendLine(tb + tb + tb + "try");
            objCodigo.AppendLine(tb + tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + tb + "oConnection.Open();");
            objCodigo.AppendLine(tb + tb + tb + tb + "oCommand = new SqlCommand(command, oConnection);");
            objCodigo.AppendLine(tb + tb + tb + tb + "oDataAdapter = new SqlDataAdapter(oCommand);");
            objCodigo.AppendLine(tb + tb + tb + tb + "oDataSet = new DataSet();");
            objCodigo.AppendLine(tb + tb + tb + tb + "oDataAdapter.Fill(oDataSet, table);");
            objCodigo.AppendLine(tb + tb + tb + tb + "return oDataSet;");
            objCodigo.AppendLine(tb + tb + tb + "}");
            objCodigo.AppendLine(tb + tb + tb + "catch (SqlException err)");
            objCodigo.AppendLine(tb + tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + tb + "throw err;");
            objCodigo.AppendLine(tb + tb + tb + "}");
            objCodigo.AppendLine(tb + tb + tb + "finally");
            objCodigo.AppendLine(tb + tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + tb + "oConnection.Dispose();");
            objCodigo.AppendLine(tb + tb + tb + tb + "oCommand.Dispose();");
            objCodigo.AppendLine(tb + tb + tb + tb + "oDataAdapter.Dispose();");
            objCodigo.AppendLine(tb + tb + tb + "}");
            objCodigo.AppendLine(tb + tb + "}");
            objCodigo.AppendLine();
            objCodigo.AppendLine(tb + tb + "/// <summary>");
            objCodigo.AppendLine(tb + tb + "/// Executa select no _banco");
            objCodigo.AppendLine(tb + tb + "/// </summary>");
            objCodigo.AppendLine(tb + tb + "/// <param name=\"command\"></param>");
            objCodigo.AppendLine(tb + tb + "/// <returns>DataReader oCommand.ExecuteReader()</returns>");
            objCodigo.AppendLine(tb + tb + "public SqlDataReader QueryConsulta(string command)");
            objCodigo.AppendLine(tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + "try");
            objCodigo.AppendLine(tb + tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + tb + "oConnection.Open();");
            objCodigo.AppendLine(tb + tb + tb + tb + "oCommand = new SqlCommand(command, oConnection);");
            objCodigo.AppendLine(tb + tb + tb + tb + "return oCommand.ExecuteReader();");
            objCodigo.AppendLine(tb + tb + tb + "}");
            objCodigo.AppendLine(tb + tb + tb + "catch (Exception err)");
            objCodigo.AppendLine(tb + tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + tb + "throw err;");
            objCodigo.AppendLine(tb + tb + tb + "}");
            objCodigo.AppendLine(tb + tb + tb + "finally");
            objCodigo.AppendLine(tb + tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + tb + "//oConnection.Dispose();");
            objCodigo.AppendLine(tb + tb + tb + tb + "//oCommand.Dispose();");
            objCodigo.AppendLine(tb + tb + tb + "}");
            objCodigo.AppendLine(tb + tb + "}");
            objCodigo.AppendLine();
            objCodigo.AppendLine(tb + tb + "public void CloseConn()");
            objCodigo.AppendLine(tb + tb + "{");
            objCodigo.AppendLine(tb + tb + tb + "oConnection.Dispose();");
            objCodigo.AppendLine(tb + tb + "}");
            objCodigo.AppendLine(tb + "}");
            objCodigo.AppendLine("}");

            return objCodigo;


        }
    }
}
