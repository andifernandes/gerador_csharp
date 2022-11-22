using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
//using System.Text;

namespace Gen
{
    public partial class GeradorDAO : Form
    {
        public StringBuilder strConnstring = null;
        public string[] arrTabelas = null;
        
        public Banco.SQLServer objBanco = null;
        public GeradorDO.SQLServerDO objSQLServerDO = null;
        public GeradorVO.SQLServerVO objSQLServerVO = null;
        public GeradorBO.SQLServerBO objSQLServerBO = null;
        public SqlDataReader dr = null;

        public Banco.MySQL objBanco_m = null;
        public GeradorDO.MySQLDO objMySQLDO = null;
        public GeradorVO.MySQLVO objMySQLVO = null;
        public GeradorBO.MySQLBO objMySQLBO = null;
        public MySqlDataReader dr_m = null;

        public GeradorDAO()
        {
            InitializeComponent();
        }

        private void btnLerBanco_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstTabelas.Items.Count; i++)
            {
                lstTabelas.Items.RemoveAt(i);
            }

            if ((txtServidor.Text.Trim() != "") || (txtBanco.Text.Trim() != ""))
            {
                if (rdoMySQL.Checked)
                {
                    Conecta_MySQL(); 
                }
                else if (rdoSQLServer.Checked)
                {
                    Conecta_SQLServer();
                }
            }
            else
            {
                MessageBox.Show("Informe a string de conexão com o banco.");
            }
        }

        private void Conecta_MySQL()
        {
            //conexão MySQL
            strConnstring = new StringBuilder();
            strConnstring.Append("server=" + txtServidor.Text.Replace("'", "") + ";");
            strConnstring.Append("user id=" + txtUsuario.Text.Replace("'", "") + ";");
            strConnstring.Append("password=" + txtSenha.Text.Replace("'", "") + ";");
            strConnstring.Append("database =" + txtBanco.Text.Replace("'", "") + ";");
            strConnstring.Append("port=3306; pooling=false");

            // Conecta com o banco
            try
            {
                objBanco_m = new Banco.MySQL(strConnstring.ToString());
                // Ler as tabelas                        
                dr_m = objBanco_m.QueryConsulta("show table status from " + txtBanco.Text + " where engine is not NULL");
                while (dr_m.Read())
                {
                    lstTabelas.Items.Add(dr_m["NAME"].ToString());
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao ler o banco de dados.");
            }
            finally
            {
                lblConnstring.Text = strConnstring.ToString();
            }  
        }

        private void Conecta_SQLServer()
        {
            // Monta a string de conexão
            //Data Source=ELNBSBSRV12;Initial Catalog=Eletronorte;User ID=elnweb; Password=elnweb;
            strConnstring = new StringBuilder();
            strConnstring.Append("Data Source=" + txtServidor.Text.Replace("'", "") + ";");
            strConnstring.Append("Initial Catalog=" + txtBanco.Text.Replace("'", "") + ";");

            if ((ckAutentica.Checked == false) && (txtUsuario.Text.Trim() != ""))
            {
                strConnstring.Append("User ID=" + txtUsuario.Text.Replace("'", "") + ";");
                strConnstring.Append("Password=" + txtSenha.Text.Replace("'", "") + ";");
            }
            else
            {
                // Usar autenticação segura
                strConnstring.Append("Integrated Security=True;");
            }

            // Conecta com o banco
            try
            {
                objBanco = new Banco.SQLServer(strConnstring.ToString());
                // Ler as tabelas                        
                dr = objBanco.QueryConsulta("SELECT * FROM SYSOBJECTS WHERE TYPE = 'U' ORDER BY NAME");
                while (dr.Read())
                {
                    lstTabelas.Items.Add(dr["NAME"].ToString());
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Erro ao ler o banco de dados.");
            }
            finally
            {
                lblConnstring.Text = strConnstring.ToString();
            }  
        }


        private void ckAutentica_Click(object sender, EventArgs e)
        {
            if (ckAutentica.Checked == true)
            {
                txtSenha.Enabled = false;
                txtUsuario.Enabled = false;
            }
            else
            {
                txtSenha.Enabled = true;
                txtUsuario.Enabled = true;
            }
        }

        // Gera a classe DO
        private void btnGerarDO_Click(object sender, EventArgs e)
        {
            if (ChecaLeitura())
            {
                if (txtBanco.Text.Trim() != "")
                {
                    if (rdoMySQL.Checked)
                    {
                        objMySQLDO = new GeradorDO.MySQLDO();
                        txtCodigo.Text = objMySQLDO.GeraCodigoDO(txtBanco.Text.Trim(), strConnstring.ToString()).ToString();
                    }
                    else
                    {
                        objSQLServerDO = new GeradorDO.SQLServerDO();
                        txtCodigo.Text = objSQLServerDO.GeraCodigoDO(txtBanco.Text.Trim(), strConnstring.ToString()).ToString();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Informe o nome do banco.");
                }
            }
            
        }

        // Gera as classes VO
        private void btnGerarVO_Click(object sender, EventArgs e)
        {
            if (ChecaLeitura())
            {
                if (lstTabelas.SelectedItems.Count != 0)
                {
                    arrTabelas = new string[lstTabelas.SelectedItems.Count];

                    for (int i = 0; i < lstTabelas.SelectedItems.Count; i++)
                    {
                        arrTabelas[i] = lstTabelas.SelectedItems[i].ToString();
                    }
                    if (rdoMySQL.Checked)
                    {
                        objMySQLVO = new GeradorVO.MySQLVO();
                        txtCodigo.Text = objMySQLVO.GeraCodigoVO(arrTabelas[0], strConnstring.ToString(), txtBanco.Text.Trim()).ToString();
                    }
                    else
                    {
                        objSQLServerVO = new GeradorVO.SQLServerVO();
                        txtCodigo.Text = objSQLServerVO.GeraCodigoVO(arrTabelas[0], strConnstring.ToString(), txtBanco.Text.Trim()).ToString();
                    }

                }
                else
                {
                    MessageBox.Show("Selecione pelo menos uma tabela.");
                }
            }
        }


        private bool ChecaLeitura()
        {
            if (strConnstring == null)
            {
                MessageBox.Show("Faça a leitura do banco.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnGerarBO_Click(object sender, EventArgs e)
        {
            if (ChecaLeitura())
            {
                if (lstTabelas.SelectedItems.Count != 0)
                {
                    arrTabelas = new string[lstTabelas.SelectedItems.Count];

                    for (int i = 0; i < lstTabelas.SelectedItems.Count; i++)
                    {
                        arrTabelas[i] = lstTabelas.SelectedItems[i].ToString();
                    }
                    if (rdoMySQL.Checked)
                    {
                        objMySQLBO = new GeradorBO.MySQLBO();
                        txtCodigo.Text = objMySQLBO.GeraCodigoBO(arrTabelas[0], strConnstring.ToString(), txtBanco.Text.Trim()).ToString();                        
                    }
                    else
                    {
                        objSQLServerBO = new GeradorBO.SQLServerBO();
                        txtCodigo.Text = objSQLServerBO.GeraCodigoBO(arrTabelas[0], strConnstring.ToString(), txtBanco.Text.Trim()).ToString();                        
                    }
                    
                }
                else
                {
                    MessageBox.Show("Selecione pelo menos uma tabela.");
                }
            }
            
        }

        private void btnCaminho_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            txtCaminho.Text = folderBrowserDialog1.SelectedPath;
            
        }

        private void rdoSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            txtServidor.Text = "andi-0009";
            txtUsuario.Text = "sa";
            txtSenha.Text = "159753";
            ckAutentica.Enabled = true;
        }

        private void rdoMySQL_CheckedChanged(object sender, EventArgs e)
        {
            txtServidor.Text = "127.0.0.1";
            txtUsuario.Text = "root";
            txtSenha.Text = "max3006";
            ckAutentica.Enabled = false; 
        }

        private void btnClassesArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChecaLeitura() && txtCaminho.Text != string.Empty)
                {
                    if (lstTabelas.SelectedItems.Count != 0)
                    {
                        //Cria Diretorio das classes
                        Directory.CreateDirectory(txtCaminho.Text + "\\dados");
                        Directory.CreateDirectory(txtCaminho.Text + "\\business");

                        //Gera classe DO
                        if (chDO.Checked == true)
                        {
                            StreamWriter Arquivo = new StreamWriter(txtCaminho.Text + "\\dados\\" + txtBanco.Text + ".cs", true, Encoding.ASCII);
                            if (rdoMySQL.Checked)
                            {
                                objMySQLDO = new GeradorDO.MySQLDO();
                                Arquivo.Write(objMySQLDO.GeraCodigoDO(txtBanco.Text.Trim(), strConnstring.ToString()).ToString());
                            }
                            else
                            {
                                objSQLServerDO = new GeradorDO.SQLServerDO();
                                Arquivo.Write(objSQLServerDO.GeraCodigoDO(txtBanco.Text.Trim(), strConnstring.ToString()).ToString());
                            }
                            Arquivo.Close();
                        }
                        
                        arrTabelas = new string[lstTabelas.SelectedItems.Count];

                        for (int i = 0; i < lstTabelas.SelectedItems.Count; i++)
                        {
                            arrTabelas[i] = lstTabelas.SelectedItems[i].ToString();
                        }

                        //Gera Classes BO
                        if (chBO.Checked == true)
                        {
                            foreach (string strTabela in arrTabelas)
                            {
                                StreamWriter Arquivo1 = new StreamWriter(txtCaminho.Text + "\\business\\" + strTabela + "BO.cs", true, Encoding.ASCII);
                                if (rdoMySQL.Checked)
                                {
                                    objMySQLBO = new GeradorBO.MySQLBO();
                                    Arquivo1.Write(objMySQLBO.GeraCodigoBO(strTabela, strConnstring.ToString(), txtBanco.Text.Trim()).ToString());
                                }
                                else
                                {
                                    objSQLServerBO = new GeradorBO.SQLServerBO();
                                    Arquivo1.Write(objSQLServerBO.GeraCodigoBO(strTabela, strConnstring.ToString(), txtBanco.Text.Trim()).ToString());
                                }
                                Arquivo1.Flush();
                                Arquivo1.Close();
                            }
                        }

                        //Gera Classes VO
                        if (chVO.Checked == true)
                        {
                            foreach (string strTabela in arrTabelas)
                            {
                                StreamWriter Arquivo2 = new StreamWriter(txtCaminho.Text + "\\dados\\" + strTabela + "VO.cs", true, Encoding.ASCII);
                                if (rdoMySQL.Checked)
                                {
                                    objMySQLVO = new GeradorVO.MySQLVO();
                                    Arquivo2.Write(objMySQLVO.GeraCodigoVO(strTabela, strConnstring.ToString(), txtBanco.Text.Trim()).ToString());
                                }
                                else
                                {
                                    objSQLServerVO = new GeradorVO.SQLServerVO();
                                    Arquivo2.Write(objSQLServerVO.GeraCodigoVO(strTabela, strConnstring.ToString(), txtBanco.Text.Trim()).ToString());
                                }
                                Arquivo2.Flush();
                                Arquivo2.Close();
                            }
                        }
                        MessageBox.Show("OK!!!, Classes geradas");
                     }
                }
                else
                {
                    MessageBox.Show("Campo caminho vazio"); 
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Erro ao gravar o arquivo");
            }
            finally
            {
                
            }
        }

    }
}