namespace AchievementManage
{
    partial class frmConnectToServer
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
            this.lbServer = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbDatabase = new System.Windows.Forms.Label();
            this.lbUid = new System.Windows.Forms.Label();
            this.lbPwd = new System.Windows.Forms.Label();
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnSaveAndTest = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(20, 18);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(41, 12);
            this.lbServer.TabIndex = 0;
            this.lbServer.Text = "服务器";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(20, 55);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(41, 12);
            this.lbPort.TabIndex = 1;
            this.lbPort.Text = "端口号";
            // 
            // lbDatabase
            // 
            this.lbDatabase.AutoSize = true;
            this.lbDatabase.Location = new System.Drawing.Point(20, 86);
            this.lbDatabase.Name = "lbDatabase";
            this.lbDatabase.Size = new System.Drawing.Size(53, 12);
            this.lbDatabase.TabIndex = 2;
            this.lbDatabase.Text = "数据库名";
            // 
            // lbUid
            // 
            this.lbUid.AutoSize = true;
            this.lbUid.Location = new System.Drawing.Point(20, 115);
            this.lbUid.Name = "lbUid";
            this.lbUid.Size = new System.Drawing.Size(41, 12);
            this.lbUid.TabIndex = 3;
            this.lbUid.Text = "用户名";
            // 
            // lbPwd
            // 
            this.lbPwd.AutoSize = true;
            this.lbPwd.Location = new System.Drawing.Point(20, 146);
            this.lbPwd.Name = "lbPwd";
            this.lbPwd.Size = new System.Drawing.Size(29, 12);
            this.lbPwd.TabIndex = 4;
            this.lbPwd.Text = "密码";
            // 
            // cboServer
            // 
            this.cboServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServer.FormattingEnabled = true;
            this.cboServer.Location = new System.Drawing.Point(86, 15);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(100, 20);
            this.cboServer.TabIndex = 5;
            this.cboServer.SelectedIndexChanged += new System.EventHandler(this.cboServer_SelectedIndexChanged);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(202, 15);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(208, 21);
            this.txtServer.TabIndex = 6;
            this.txtServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(86, 52);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 7;
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(86, 83);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(324, 21);
            this.txtDatabase.TabIndex = 8;
            this.txtDatabase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(86, 112);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(324, 21);
            this.txtUid.TabIndex = 9;
            this.txtUid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(86, 143);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(324, 21);
            this.txtPwd.TabIndex = 10;
            this.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSaveAndTest
            // 
            this.btnSaveAndTest.Location = new System.Drawing.Point(19, 188);
            this.btnSaveAndTest.Name = "btnSaveAndTest";
            this.btnSaveAndTest.Size = new System.Drawing.Size(149, 23);
            this.btnSaveAndTest.TabIndex = 11;
            this.btnSaveAndTest.Text = "保存此配置并测试连接";
            this.btnSaveAndTest.UseVisualStyleBackColor = true;
            this.btnSaveAndTest.Click += new System.EventHandler(this.btnSaveAndTest_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(197, 188);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "恢复默认值";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(315, 188);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmConnectToServer
            // 
            this.AcceptButton = this.btnSaveAndTest;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(422, 226);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSaveAndTest);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.cboServer);
            this.Controls.Add(this.lbPwd);
            this.Controls.Add(this.lbUid);
            this.Controls.Add(this.lbDatabase);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbServer);
            this.Name = "frmConnectToServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务器信息配置";
            this.Load += new System.EventHandler(this.frmConnectToServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbDatabase;
        private System.Windows.Forms.Label lbUid;
        private System.Windows.Forms.Label lbPwd;
        private System.Windows.Forms.ComboBox cboServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnSaveAndTest;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
    }
}