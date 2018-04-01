namespace AchievementManage
{
    partial class frmAchievementAddByWrite
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
            this.gbAchievementData = new System.Windows.Forms.GroupBox();
            this.dtpAchievementDate = new System.Windows.Forms.DateTimePicker();
            this.txtAchievementMoney = new System.Windows.Forms.TextBox();
            this.txtAchievementCompany = new System.Windows.Forms.TextBox();
            this.txtAchievementAuthor = new System.Windows.Forms.TextBox();
            this.txtAchievementType = new System.Windows.Forms.TextBox();
            this.cboAchievementType = new System.Windows.Forms.ComboBox();
            this.txtAchievementName = new System.Windows.Forms.TextBox();
            this.lbAchievementMoney = new System.Windows.Forms.Label();
            this.lbAchievementCompany = new System.Windows.Forms.Label();
            this.lbAchievementAuthor = new System.Windows.Forms.Label();
            this.lbAchievementDate = new System.Windows.Forms.Label();
            this.lbAchievementType = new System.Windows.Forms.Label();
            this.lbAchievementName = new System.Windows.Forms.Label();
            this.gbAchievementView = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOutToFile = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.sfdOutToFile = new System.Windows.Forms.SaveFileDialog();
            this.gbAchievementData.SuspendLayout();
            this.gbAchievementView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAchievementData
            // 
            this.gbAchievementData.Controls.Add(this.dtpAchievementDate);
            this.gbAchievementData.Controls.Add(this.txtAchievementMoney);
            this.gbAchievementData.Controls.Add(this.txtAchievementCompany);
            this.gbAchievementData.Controls.Add(this.txtAchievementAuthor);
            this.gbAchievementData.Controls.Add(this.txtAchievementType);
            this.gbAchievementData.Controls.Add(this.cboAchievementType);
            this.gbAchievementData.Controls.Add(this.txtAchievementName);
            this.gbAchievementData.Controls.Add(this.lbAchievementMoney);
            this.gbAchievementData.Controls.Add(this.lbAchievementCompany);
            this.gbAchievementData.Controls.Add(this.lbAchievementAuthor);
            this.gbAchievementData.Controls.Add(this.lbAchievementDate);
            this.gbAchievementData.Controls.Add(this.lbAchievementType);
            this.gbAchievementData.Controls.Add(this.lbAchievementName);
            this.gbAchievementData.Location = new System.Drawing.Point(13, 13);
            this.gbAchievementData.Name = "gbAchievementData";
            this.gbAchievementData.Size = new System.Drawing.Size(306, 254);
            this.gbAchievementData.TabIndex = 0;
            this.gbAchievementData.TabStop = false;
            this.gbAchievementData.Text = "录入信息输入";
            // 
            // dtpAchievementDate
            // 
            this.dtpAchievementDate.Location = new System.Drawing.Point(77, 122);
            this.dtpAchievementDate.Name = "dtpAchievementDate";
            this.dtpAchievementDate.Size = new System.Drawing.Size(223, 21);
            this.dtpAchievementDate.TabIndex = 13;
            // 
            // txtAchievementMoney
            // 
            this.txtAchievementMoney.Location = new System.Drawing.Point(77, 224);
            this.txtAchievementMoney.Name = "txtAchievementMoney";
            this.txtAchievementMoney.Size = new System.Drawing.Size(223, 21);
            this.txtAchievementMoney.TabIndex = 12;
            // 
            // txtAchievementCompany
            // 
            this.txtAchievementCompany.Location = new System.Drawing.Point(77, 191);
            this.txtAchievementCompany.Name = "txtAchievementCompany";
            this.txtAchievementCompany.Size = new System.Drawing.Size(223, 21);
            this.txtAchievementCompany.TabIndex = 11;
            // 
            // txtAchievementAuthor
            // 
            this.txtAchievementAuthor.Location = new System.Drawing.Point(77, 157);
            this.txtAchievementAuthor.Name = "txtAchievementAuthor";
            this.txtAchievementAuthor.Size = new System.Drawing.Size(223, 21);
            this.txtAchievementAuthor.TabIndex = 10;
            // 
            // txtAchievementType
            // 
            this.txtAchievementType.Location = new System.Drawing.Point(77, 89);
            this.txtAchievementType.Name = "txtAchievementType";
            this.txtAchievementType.Size = new System.Drawing.Size(223, 21);
            this.txtAchievementType.TabIndex = 8;
            // 
            // cboAchievementType
            // 
            this.cboAchievementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAchievementType.FormattingEnabled = true;
            this.cboAchievementType.Location = new System.Drawing.Point(77, 54);
            this.cboAchievementType.Name = "cboAchievementType";
            this.cboAchievementType.Size = new System.Drawing.Size(223, 20);
            this.cboAchievementType.TabIndex = 7;
            this.cboAchievementType.SelectedIndexChanged += new System.EventHandler(this.cboAchievementType_SelectedIndexChanged);
            // 
            // txtAchievementName
            // 
            this.txtAchievementName.Location = new System.Drawing.Point(77, 21);
            this.txtAchievementName.Name = "txtAchievementName";
            this.txtAchievementName.Size = new System.Drawing.Size(223, 21);
            this.txtAchievementName.TabIndex = 6;
            // 
            // lbAchievementMoney
            // 
            this.lbAchievementMoney.AutoSize = true;
            this.lbAchievementMoney.Location = new System.Drawing.Point(11, 228);
            this.lbAchievementMoney.Name = "lbAchievementMoney";
            this.lbAchievementMoney.Size = new System.Drawing.Size(53, 12);
            this.lbAchievementMoney.TabIndex = 5;
            this.lbAchievementMoney.Text = "支撑基金";
            // 
            // lbAchievementCompany
            // 
            this.lbAchievementCompany.AutoSize = true;
            this.lbAchievementCompany.Location = new System.Drawing.Point(23, 195);
            this.lbAchievementCompany.Name = "lbAchievementCompany";
            this.lbAchievementCompany.Size = new System.Drawing.Size(29, 12);
            this.lbAchievementCompany.TabIndex = 4;
            this.lbAchievementCompany.Text = "单位";
            // 
            // lbAchievementAuthor
            // 
            this.lbAchievementAuthor.AutoSize = true;
            this.lbAchievementAuthor.Location = new System.Drawing.Point(23, 162);
            this.lbAchievementAuthor.Name = "lbAchievementAuthor";
            this.lbAchievementAuthor.Size = new System.Drawing.Size(29, 12);
            this.lbAchievementAuthor.TabIndex = 3;
            this.lbAchievementAuthor.Text = "作者";
            // 
            // lbAchievementDate
            // 
            this.lbAchievementDate.AutoSize = true;
            this.lbAchievementDate.Location = new System.Drawing.Point(23, 126);
            this.lbAchievementDate.Name = "lbAchievementDate";
            this.lbAchievementDate.Size = new System.Drawing.Size(29, 12);
            this.lbAchievementDate.TabIndex = 2;
            this.lbAchievementDate.Text = "时间";
            // 
            // lbAchievementType
            // 
            this.lbAchievementType.AutoSize = true;
            this.lbAchievementType.Location = new System.Drawing.Point(11, 58);
            this.lbAchievementType.Name = "lbAchievementType";
            this.lbAchievementType.Size = new System.Drawing.Size(53, 12);
            this.lbAchievementType.TabIndex = 1;
            this.lbAchievementType.Text = "成果类型";
            // 
            // lbAchievementName
            // 
            this.lbAchievementName.AutoSize = true;
            this.lbAchievementName.Location = new System.Drawing.Point(11, 26);
            this.lbAchievementName.Name = "lbAchievementName";
            this.lbAchievementName.Size = new System.Drawing.Size(53, 12);
            this.lbAchievementName.TabIndex = 0;
            this.lbAchievementName.Text = "成果名称";
            // 
            // gbAchievementView
            // 
            this.gbAchievementView.Controls.Add(this.dgvData);
            this.gbAchievementView.Location = new System.Drawing.Point(325, 13);
            this.gbAchievementView.Name = "gbAchievementView";
            this.gbAchievementView.Size = new System.Drawing.Size(502, 254);
            this.gbAchievementView.TabIndex = 1;
            this.gbAchievementView.TabStop = false;
            this.gbAchievementView.Text = "录入信息显示";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 17);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(496, 234);
            this.dgvData.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(81, 281);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "录入此项成果";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(277, 281);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除此项成果";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOutToFile
            // 
            this.btnOutToFile.Location = new System.Drawing.Point(453, 281);
            this.btnOutToFile.Name = "btnOutToFile";
            this.btnOutToFile.Size = new System.Drawing.Size(138, 23);
            this.btnOutToFile.TabIndex = 4;
            this.btnOutToFile.Text = "导出此项成果到文件";
            this.btnOutToFile.UseVisualStyleBackColor = true;
            this.btnOutToFile.Click += new System.EventHandler(this.btnOutToFile_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(690, 280);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmAchievementAddByWrite
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(839, 320);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOutToFile);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gbAchievementView);
            this.Controls.Add(this.gbAchievementData);
            this.Name = "frmAchievementAddByWrite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成果录入(手工输入)";
            this.Load += new System.EventHandler(this.frmAchievementAddByWrite_Load);
            this.gbAchievementData.ResumeLayout(false);
            this.gbAchievementData.PerformLayout();
            this.gbAchievementView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAchievementData;
        private System.Windows.Forms.GroupBox gbAchievementView;
        private System.Windows.Forms.Label lbAchievementMoney;
        private System.Windows.Forms.Label lbAchievementCompany;
        private System.Windows.Forms.Label lbAchievementAuthor;
        private System.Windows.Forms.Label lbAchievementDate;
        private System.Windows.Forms.Label lbAchievementType;
        private System.Windows.Forms.Label lbAchievementName;
        private System.Windows.Forms.ComboBox cboAchievementType;
        private System.Windows.Forms.TextBox txtAchievementName;
        private System.Windows.Forms.TextBox txtAchievementMoney;
        private System.Windows.Forms.TextBox txtAchievementCompany;
        private System.Windows.Forms.TextBox txtAchievementAuthor;
        private System.Windows.Forms.TextBox txtAchievementType;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOutToFile;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtpAchievementDate;
        private System.Windows.Forms.SaveFileDialog sfdOutToFile;
    }
}