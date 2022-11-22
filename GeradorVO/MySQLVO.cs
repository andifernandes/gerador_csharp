using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace GeradorVO
{
    /// <summary>
    /// Classe VO
    /// Criador: Anderson R Fernandes
    /// Criada em 25/09/2010
    /// Contato: andersonrfernandes@yahoo.com.br
    /// </summary>
    public class MySQLVO
    {
        // Atributos
        public string strData = null;
        public string[] arrTabelas = null;
        public string s = null;
        public string tb = null;
        public StringBuilder objCodigo = null;
        public Banco.MySQL objBanco = null;
        public MySqlDataReader objDr = null;
        private Library.Library objLib = null;


        // Contrutor
        public MySQLVO()
        {
            strData = DateTime.Today.ToShortDateString();
            s = " ";
            tb = "      ";

        }

        // Metodos
        public StringBuilder GeraCodigoVO(string strTabela, string _conexao, string _banco)
        {
            objCodigo = new StringBuilder();

            objCodigo.AppendLine("using System;");
            objCodigo.AppendLine("using System.Collections.Generic;");
            objCodigo.AppendLine("using System.Text;");
            objCodigo.AppendLine();
            objCodigo.AppendLine("namespace MySQL");
            objCodigo.AppendLine("{");


            if (strTabela != string.Empty)
            {
                // Abre conexão com o banco
                objBanco = new Banco.MySQL(_conexao);
                // Cria o objeto da classe Library
                objLib = new Library.Library();

                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + "/// <summary>");
                objCodigo.AppendLine(tb + "/// Classe VO: Value Objects");
                objCodigo.AppendLine(tb + "/// Criador: Anderson R Fernandes");
                objCodigo.AppendLine(tb + "/// Criada em " + strData);
                objCodigo.AppendLine(tb + "/// Contato: andersonrfernandes@yahoo.com.br");
                objCodigo.AppendLine(tb + "/// </summary>");
                objCodigo.AppendLine(tb + "public class " + strTabela + "VO");
                objCodigo.AppendLine(tb + "{");
                objCodigo.AppendLine(tb + tb + "// Atributos");

                // Faz a leitura de todas as colunas da tabela
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                // Conta o número de colunas
                int nunrec = objDr.FieldCount;

                for (int i = 0; i < nunrec; i++)
                {
                    // declara os atributos da classe

                    objCodigo.AppendLine(tb + tb + "private " + objLib.DefineTipo(objDr.GetDataTypeName(i).ToString()) + " _" + objDr.GetName(i) + ";");

                }

                objCodigo.AppendLine();
                objCodigo.AppendLine(tb + tb + "// Propriedades");

                for (int i = 0; i < nunrec; i++)
                {
                    // declara as propriedades da classe

                    objCodigo.AppendLine(tb + tb + "public " + objLib.DefineTipo(objDr.GetDataTypeName(i).ToString()) +
                        " " + objDr.GetName(i));

                    objCodigo.AppendLine(tb + tb + "{");
                    objCodigo.AppendLine(tb + tb + tb + "get { return _" + objDr.GetName(i) + "; }");
                    objCodigo.AppendLine(tb + tb + tb + "set { _" + objDr.GetName(i) + " = value; }");
                    objCodigo.AppendLine(tb + tb + "}");

                }
                objCodigo.AppendLine(tb + "}");
                // fecha conexão
                objBanco.CloseConn();
                objLib = null;
            }
            objCodigo.AppendLine("}");

            return objCodigo;
        }

    }
}
