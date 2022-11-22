namespace Gen
{
    partial class GeradorDAO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGerarBO = new System.Windows.Forms.Button();
            this.btnGerarVO = new System.Windows.Forms.Button();
            this.grupCodigo = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnGerarDO = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckAutentica = new System.Windows.Forms.CheckBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.rdoSQLServer = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoMySQL = new System.Windows.Forms.RadioButton();
            this.btnLerBanco = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.lblServidor = new System.Windows.Forms.Label();
            this.grupBanco = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCaminho = new System.Windows.Forms.Button();
            this.lblCaminho = new System.Windows.Forms.Label();
            this.txtCaminho = new System.Windows.Forms.TextBox();
            this.btnClassesArquivo = new System.Windows.Forms.Button();
            this.lblConnstring = new System.Windows.Forms.Label();
            this.grupTabelas = new System.Windows.Forms.GroupBox();
            this.lstTabelas = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chDO = new System.Windows.Forms.CheckBox();
            this.chBO = new System.Windows.Forms.CheckBox();
            this.chVO = new System.Windows.Forms.CheckBox();
            this.grupCodigo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grupBanco.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grupTabelas.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGerarBO
            // 
            this.btnGerarBO.Location = new System.Drawing.Point(174, 13);
            this.btnGerarBO.Name = "btnGerarBO";
            this.btnGerarBO.Size = new System.Drawing.Size(75, 23);
            this.btnGerarBO.TabIndex = 9;
            this.btnGerarBO.Text = "Gerar BO";
            this.btnGerarBO.UseVisualStyleBackColor = true;
            this.btnGerarBO.Click += new System.EventHandler(this.btnGerarBO_Click);
            // 
            // btnGerarVO
            // 
            this.btnGerarVO.Location = new System.Drawing.Point(93, 13);
            this.btnGerarVO.Name = "btnGerarVO";
            this.btnGerarVO.Size = new System.Drawing.Size(75, 23);
            this.btnGerarVO.TabIndex = 8;
            this.btnGerarVO.Text = "Gerar VO";
            this.btnGerarVO.UseVisualStyleBackColor = true;
            this.btnGerarVO.Click += new System.EventHandler(this.btnGerarVO_Click);
            // 
            // grupCodigo
            // 
            this.grupCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grupCodigo.AutoSize = true;
            this.grupCodigo.Controls.Add(this.txtCodigo);
            this.grupCodigo.Controls.Add(this.btnGerarBO);
            this.grupCodigo.Controls.Add(this.btnGerarDO);
            this.grupCodigo.Controls.Add(this.btnGerarVO);
            this.grupCodigo.Location = new System.Drawing.Point(12, 248);
            this.grupCodigo.Name = "grupCodigo";
            this.grupCodigo.Size = new System.Drawing.Size(845, 225);
            this.grupCodigo.TabIndex = 3;
            this.grupCodigo.TabStop = false;
            this.grupCodigo.Text = "Classes C#";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(12, 39);
            this.txtCodigo.Multiline = true;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCodigo.Size = new System.Drawing.Size(827, 180);
            this.txtCodigo.TabIndex = 10;
            // 
            // btnGerarDO
            // 
            this.btnGerarDO.Location = new System.Drawing.Point(12, 13);
            this.btnGerarDO.Name = "btnGerarDO";
            this.btnGerarDO.Size = new System.Drawing.Size(75, 23);
            this.btnGerarDO.TabIndex = 7;
            this.btnGerarDO.Text = "Gerar DO";
            this.btnGerarDO.UseVisualStyleBackColor = true;
            this.btnGerarDO.Click += new System.EventHandler(this.btnGerarDO_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ckAutentica);
            this.panel1.Controls.Add(this.txtSenha);
            this.panel1.Controls.Add(this.rdoSQLServer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rdoMySQL);
            this.panel1.Controls.Add(this.btnLerBanco);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Controls.Add(this.txtBanco);
            this.panel1.Controls.Add(this.lblBanco);
            this.panel1.Controls.Add(this.txtServidor);
            this.panel1.Controls.Add(this.lblServidor);
            this.panel1.Location = new System.Drawing.Point(19, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 176);
            this.panel1.TabIndex = 14;
            // 
            // ckAutentica
            // 
            this.ckAutentica.AutoSize = true;
            this.ckAutentica.Location = new System.Drawing.Point(18, 124);
            this.ckAutentica.Name = "ckAutentica";
            this.ckAutentica.Size = new System.Drawing.Size(161, 17);
            this.ckAutentica.TabIndex = 15;
            this.ckAutentica.Text = "Usar Autenticação Windows";
            this.ckAutentica.UseVisualStyleBackColor = true;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(68, 76);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(140, 20);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.Text = "max3006";
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // rdoSQLServer
            // 
            this.rdoSQLServer.AutoSize = true;
            this.rdoSQLServer.Location = new System.Drawing.Point(90, 3);
            this.rdoSQLServer.Name = "rdoSQLServer";
            this.rdoSQLServer.Size = new System.Drawing.Size(80, 17);
            this.rdoSQLServer.TabIndex = 13;
            this.rdoSQLServer.Text = "SQL Server";
            this.rdoSQLServer.UseVisualStyleBackColor = true;
            this.rdoSQLServer.CheckedChanged += new System.EventHandler(this.rdoSQLServer_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Senha";
            // 
            // rdoMySQL
            // 
            this.rdoMySQL.AutoSize = true;
            this.rdoMySQL.Checked = true;
            this.rdoMySQL.Location = new System.Drawing.Point(18, 3);
            this.rdoMySQL.Name = "rdoMySQL";
            this.rdoMySQL.Size = new System.Drawing.Size(60, 17);
            this.rdoMySQL.TabIndex = 12;
            this.rdoMySQL.TabStop = true;
            this.rdoMySQL.Text = "MySQL";
            this.rdoMySQL.UseVisualStyleBackColor = true;
            this.rdoMySQL.CheckedChanged += new System.EventHandler(this.rdoMySQL_CheckedChanged);
            // 
            // btnLerBanco
            // 
            this.btnLerBanco.Location = new System.Drawing.Point(101, 147);
            this.btnLerBanco.Name = "btnLerBanco";
            this.btnLerBanco.Size = new System.Drawing.Size(107, 23);
            this.btnLerBanco.TabIndex = 6;
            this.btnLerBanco.Text = "Listar Tabelas";
            this.btnLerBanco.UseVisualStyleBackColor = true;
            this.btnLerBanco.Click += new System.EventHandler(this.btnLerBanco_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(68, 51);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(140, 20);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.Text = "root";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(19, 54);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 19;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(68, 100);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(140, 20);
            this.txtBanco.TabIndex = 3;
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(23, 103);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(38, 13);
            this.lblBanco.TabIndex = 16;
            this.lblBanco.Text = "Banco";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(68, 27);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(140, 20);
            this.txtServidor.TabIndex = 0;
            this.txtServidor.Text = "127.0.0.1";
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(15, 30);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(46, 13);
            this.lblServidor.TabIndex = 13;
            this.lblServidor.Text = "Servidor";
            // 
            // grupBanco
            // 
            this.grupBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grupBanco.Controls.Add(this.panel1);
            this.grupBanco.Location = new System.Drawing.Point(12, 12);
            this.grupBanco.Name = "grupBanco";
            this.grupBanco.Size = new System.Drawing.Size(246, 209);
            this.grupBanco.TabIndex = 5;
            this.grupBanco.TabStop = false;
            this.grupBanco.Text = "Banco de Dados";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chVO);
            this.groupBox1.Controls.Add(this.chBO);
            this.groupBox1.Controls.Add(this.chDO);
            this.groupBox1.Controls.Add(this.btnCaminho);
            this.groupBox1.Controls.Add(this.lblCaminho);
            this.groupBox1.Controls.Add(this.txtCaminho);
            this.groupBox1.Controls.Add(this.btnClassesArquivo);
            this.groupBox1.Location = new System.Drawing.Point(474, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 204);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gerar todas as classes";
            // 
            // btnCaminho
            // 
            this.btnCaminho.Location = new System.Drawing.Point(292, 135);
            this.btnCaminho.Name = "btnCaminho";
            this.btnCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnCaminho.TabIndex = 31;
            this.btnCaminho.Text = "Caminho";
            this.btnCaminho.UseVisualStyleBackColor = true;
            this.btnCaminho.Click += new System.EventHandler(this.btnCaminho_Click);
            // 
            // lblCaminho
            // 
            this.lblCaminho.AutoSize = true;
            this.lblCaminho.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaminho.Location = new System.Drawing.Point(6, 118);
            this.lblCaminho.Name = "lblCaminho";
            this.lblCaminho.Size = new System.Drawing.Size(142, 16);
            this.lblCaminho.TabIndex = 30;
            this.lblCaminho.Text = "Caminho das Classes";
            // 
            // txtCaminho
            // 
            this.txtCaminho.Location = new System.Drawing.Point(9, 137);
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.Size = new System.Drawing.Size(277, 20);
            this.txtCaminho.TabIndex = 29;
            // 
            // btnClassesArquivo
            // 
            this.btnClassesArquivo.Location = new System.Drawing.Point(292, 162);
            this.btnClassesArquivo.Name = "btnClassesArquivo";
            this.btnClassesArquivo.Size = new System.Drawing.Size(75, 23);
            this.btnClassesArquivo.TabIndex = 28;
            this.btnClassesArquivo.Text = "Gerar";
            this.btnClassesArquivo.UseVisualStyleBackColor = true;
            this.btnClassesArquivo.Click += new System.EventHandler(this.btnClassesArquivo_Click);
            // 
            // lblConnstring
            // 
            this.lblConnstring.AutoSize = true;
            this.lblConnstring.Location = new System.Drawing.Point(12, 228);
            this.lblConnstring.Name = "lblConnstring";
            this.lblConnstring.Size = new System.Drawing.Size(103, 13);
            this.lblConnstring.TabIndex = 22;
            this.lblConnstring.Text = "String de Conexão:  ";
            // 
            // grupTabelas
            // 
            this.grupTabelas.Controls.Add(this.lstTabelas);
            this.grupTabelas.Location = new System.Drawing.Point(264, 17);
            this.grupTabelas.Name = "grupTabelas";
            this.grupTabelas.Size = new System.Drawing.Size(204, 204);
            this.grupTabelas.TabIndex = 23;
            this.grupTabelas.TabStop = false;
            this.grupTabelas.Text = "Tabelas";
            // 
            // lstTabelas
            // 
            this.lstTabelas.FormattingEnabled = true;
            this.lstTabelas.Location = new System.Drawing.Point(9, 18);
            this.lstTabelas.Name = "lstTabelas";
            this.lstTabelas.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTabelas.Size = new System.Drawing.Size(189, 173);
            this.lstTabelas.Sorted = true;
            this.lstTabelas.TabIndex = 7;
            // 
            // chDO
            // 
            this.chDO.AutoSize = true;
            this.chDO.Location = new System.Drawing.Point(9, 40);
            this.chDO.Name = "chDO";
            this.chDO.Size = new System.Drawing.Size(139, 17);
            this.chDO.TabIndex = 32;
            this.chDO.Text = "Classe de Conexão(DO)";
            this.chDO.UseVisualStyleBackColor = true;
            // 
            // chBO
            // 
            this.chBO.AutoSize = true;
            this.chBO.Checked = true;
            this.chBO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBO.Location = new System.Drawing.Point(9, 63);
            this.chBO.Name = "chBO";
            this.chBO.Size = new System.Drawing.Size(146, 17);
            this.chBO.TabIndex = 33;
            this.chBO.Text = "Classes de Negocios(BO)";
            this.chBO.UseVisualStyleBackColor = true;
            // 
            // chVO
            // 
            this.chVO.AutoSize = true;
            this.chVO.Checked = true;
            this.chVO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chVO.Location = new System.Drawing.Point(9, 86);
            this.chVO.Name = "chVO";
            this.chVO.Size = new System.Drawing.Size(136, 17);
            this.chVO.TabIndex = 34;
            this.chVO.Text = "Classes de Valores(VO)";
            this.chVO.UseVisualStyleBackColor = true;
            // 
            // GeradorDAO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(869, 479);
            this.Controls.Add(this.grupTabelas);
            this.Controls.Add(this.lblConnstring);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grupBanco);
            this.Controls.Add(this.grupCodigo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GeradorDAO";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GeradorDAO";
            this.TopMost = true;
            this.grupCodigo.ResumeLayout(false);
            this.grupCodigo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grupBanco.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grupTabelas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grupCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnGerarDO;
        private System.Windows.Forms.Button btnGerarBO;
        private System.Windows.Forms.Button btnGerarVO;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckAutentica;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.RadioButton rdoSQLServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoMySQL;
        private System.Windows.Forms.Button btnLerBanco;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.GroupBox grupBanco;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCaminho;
        private System.Windows.Forms.TextBox txtCaminho;
        private System.Windows.Forms.Button btnClassesArquivo;
        private System.Windows.Forms.Button btnCaminho;
        private System.Windows.Forms.Label lblConnstring;
        private System.Windows.Forms.GroupBox grupTabelas;
        private System.Windows.Forms.ListBox lstTabelas;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox chVO;
        private System.Windows.Forms.CheckBox chBO;
        private System.Windows.Forms.CheckBox chDO;
    }
}