using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Banco
{
    public class MySQL
    {
        // Atributos
        private MySqlConnection oConnection = null;
        private string connectionString = null;
        private MySqlDataAdapter oDataAdapter = null;
        private MySqlCommand oCommand = null;
        private DataSet oDataSet = null;


        //Construtor
        public MySQL(string strConn)
        {
            //strServidor = 
            connectionString = strConn;
            try
            {
                oConnection = new MySqlConnection(connectionString);
            }
            catch
            {
                throw new Exception("Erro ao conectar com o banco. Verifica a string de conexão.");
            }
        }
        //Métodos

        /// <summary>
        /// Executa comandos sql e retorna o número de linhas afetadas.
        /// </summary>
        /// <param name="sSQL">Comando sql</param>
        /// <returns>int regAffect</returns>
        public int ExecutaQuery(string sSQL)
        {
            int regAffect = 0;
            try
            {
                oCommand = new MySqlCommand(sSQL, oConnection);
                oConnection.Open();
                regAffect = oCommand.ExecuteNonQuery();
                if (regAffect == 0)
                {
                    throw new Exception("Ocorreu um erro no comando sql, entre em contato com o administrador do sistema.");
                }
                else
                {
                    return regAffect;
                }

            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                oConnection.Dispose();
                oCommand.Dispose();
            }

        }

        /// <summary>
        /// Retorna um data set apartir de um comando sql
        /// </summary>
        /// <param name="command">Comando sql</param>
        /// <param name="table">Nome da tabela</param>
        /// <returns>DataSet oDataSet</returns>

        public DataSet GetDataSet(string command, string table)
        {
            try
            {

                oConnection.Open();
                oCommand = new MySqlCommand(command, oConnection);
                oDataAdapter = new MySqlDataAdapter(oCommand);
                oDataSet = new DataSet();
                oDataAdapter.Fill(oDataSet, table);
                return oDataSet;
            }
            catch (MySqlException err)
            {
                throw err;
            }
            finally
            {
                oConnection.Dispose();
                oCommand.Dispose();
                oDataAdapter.Dispose();
            }
        }

        /// <summary>
        /// Executa select no banco
        /// </summary>
        /// <param name="command"></param>
        /// <returns>DataReader oCommand.ExecuteReader()</returns>
        public MySqlDataReader QueryConsulta(string command)
        {
            try
            {
                oConnection.Open();
                oCommand = new MySqlCommand(command, oConnection);
                return oCommand.ExecuteReader();
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                //oConnection.Dispose();
                //oCommand.Dispose();
            }
        }

        public void CloseConn()
        {
            oConnection.Dispose();
        }
    }
}

