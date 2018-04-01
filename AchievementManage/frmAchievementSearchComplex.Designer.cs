namespace AchievementManage
{
    partial class frmAchievementSearchComplex
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
            this.cbAchievementMoney = new System.Windows.Forms.CheckBox();
            this.cbAchievementDate = new System.Windows.Forms.CheckBox();
            this.cboLogic = new System.Windows.Forms.ComboBox();
            this.lbLogic = new System.Windows.Forms.Label();
            this.txtAchievementMoney = new System.Windows.Forms.TextBox();
            this.txtAchievementCompany = new System.Windows.Forms.TextBox();
            this.txtAchievementAuthor = new System.Windows.Forms.TextBox();
            this.dtpAchievementDate = new System.Windows.Forms.DateTimePicker();
            this.txtAchievementType = new System.Windows.Forms.TextBox();
            this.txtAchievementName = new System.Windows.Forms.TextBox();
            this.lbAchievementMoney = new System.Windows.Forms.Label();
            this.lbAchievementCompany = new System.Windows.Forms.Label();
            this.lbAchievementAuthor = new System.Windows.Forms.Label();
            this.lbAchievementDate = new System.Windows.Forms.Label();
            this.lbAchievementType = new System.Windows.Forms.Label();
            this.lbAchievementName = new System.Windows.Forms.Label();
            this.gbAchievementView = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
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
            this.gbAchievementData.Controls.Add(this.cbAchievementMoney);
            this.gbAchievementData.Controls.Add(this.cbAchievementDate);
            this.gbAchievementData.Controls.Add(this.cboLogic);
            this.gbAchievementData.Controls.Add(this.lbLogic);
            this.gbAchievementData.Controls.Add(this.txtAchievementMoney);
            this.gbAchievementData.Controls.Add(this.txtAchievementCompany);
            this.gbAchievementData.Controls.Add(this.txtAchievementAuthor);
            this.gbAchievementData.Controls.Add(this.dtpAchievementDate);
            this.gbAchievementData.Controls.Add(this.txtAchievementType);
            this.gbAchievementData.Controls.Add(this.txtAchievementName);
            this.gbAchievementData.Controls.Add(this.lbAchievementMoney);
            this.gbAchievementData.Controls.Add(this.lbAchievementCompany);
            this.gbAchievementData.Controls.Add(this.lbAchievementAuthor);
            this.gbAchievementData.Controls.Add(this.lbAchievementDate);
            this.gbAchievementData.Controls.Add(this.lbAchievementType);
            this.gbAchievementData.Controls.Add(this.lbAchievementName);
            this.gbAchievementData.Location = new System.Drawing.Point(13, 13);
            this.gbAchievementData.Name = "gbAchievementData";
            this.gbAchievementData.Size = new System.Drawing.Size(314, 260);
            this.gbAchievementData.TabIndex = 0;
            this.gbAchievementData.TabStop = false;
            this.gbAchievementData.Text = "检索信息输入";
            // 
            // cbAchievementMoney
            // 
            this.cbAchievementMoney.AutoSize = true;
            this.cbAchievementMoney.Location = new System.Drawing.Point(245, 184);
            this.cbAchievementMoney.Name = "cbAchievementMoney";
            this.cbAchievementMoney.Size = new System.Drawing.Size(60, 16);
            this.cbAchievementMoney.TabIndex = 15;
            this.cbAchievementMoney.Text = "不限制";
            this.cbAchievementMoney.UseVisualStyleBackColor = true;
            this.cbAchievementMoney.CheckedChanged += new System.EventHandler(this.cbAchievementMoney_CheckedChanged);
            // 
            // cbAchievementDate
            // 
            this.cbAchievementDate.AutoSize = true;
            this.cbAchievementDate.Location = new System.Drawing.Point(245, 85);
            this.cbAchievementDate.Name = "cbAchievementDate";
            this.cbAchievementDate.Size = new System.Drawing.Size(60, 16);
            this.cbAchievementDate.TabIndex = 14;
            this.cbAchievementDate.Text = "不限制";
            this.cbAchievementDate.UseVisualStyleBackColor = true;
            this.cbAchievementDate.CheckedChanged += new System.EventHandler(this.cbAchievementDate_CheckedChanged);
            // 
            // cboLogic
            // 
            this.cboLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLogic.FormattingEnabled = true;
            this.cboLogic.Items.AddRange(new object[] {
            "and",
            "or"});
            this.cboLogic.Location = new System.Drawing.Point(166, 217);
            this.cboLogic.Name = "cboLogic";
            this.cboLogic.Size = new System.Drawing.Size(69, 20);
            this.cboLogic.TabIndex = 13;
            // 
            // lbLogic
            // 
            this.lbLogic.AutoSize = true;
            this.lbLogic.Location = new System.Drawing.Point(9, 222);
            this.lbLogic.Name = "lbLogic";
            this.lbLogic.Size = new System.Drawing.Size(137, 12);
            this.lbLogic.TabIndex = 12;
            this.lbLogic.Text = "所有检索条件间逻辑关系";
            // 
            // txtAchievementMoney
            // 
            this.txtAchievementMoney.Location = new System.Drawing.Point(98, 181);
            this.txtAchievementMoney.Name = "txtAchievementMoney";
            this.txtAchievementMoney.Size = new System.Drawing.Size(137, 21);
            this.txtAchievementMoney.TabIndex = 11;
            // 
            // txtAchievementCompany
            // 
            this.txtAchievementCompany.Location = new System.Drawing.Point(98, 147);
            this.txtAchievementCompany.Name = "txtAchievementCompany";
            this.txtAchievementCompany.Size = new System.Drawing.Size(137, 21);
            this.txtAchievementCompany.TabIndex = 10;
            // 
            // txtAchievementAuthor
            // 
            this.txtAchievementAuthor.Location = new System.Drawing.Point(98, 116);
            this.txtAchievementAuthor.Name = "txtAchievementAuthor";
            this.txtAchievementAuthor.Size = new System.Drawing.Size(137, 21);
            this.txtAchievementAuthor.TabIndex = 9;
            // 
            // dtpAchievementDate
            // 
            this.dtpAchievementDate.Location = new System.Drawing.Point(98, 83);
            this.dtpAchievementDate.Name = "dtpAchievementDate";
            this.dtpAchievementDate.Size = new System.Drawing.Size(137, 21);
            this.dtpAchievementDate.TabIndex = 8;
            // 
            // txtAchievementType
            // 
            this.txtAchievementType.Location = new System.Drawing.Point(98, 51);
            this.txtAchievementType.Name = "txtAchievementType";
            this.txtAchievementType.Size = new System.Drawing.Size(137, 21);
            this.txtAchievementType.TabIndex = 7;
            // 
            // txtAchievementName
            // 
            this.txtAchievementName.Location = new System.Drawing.Point(98, 20);
            this.txtAchievementName.Name = "txtAchievementName";
            this.txtAchievementName.Size = new System.Drawing.Size(137, 21);
            this.txtAchievementName.TabIndex = 6;
            // 
            // lbAchievementMoney
            // 
            this.lbAchievementMoney.AutoSize = true;
            this.lbAchievementMoney.Location = new System.Drawing.Point(9, 188);
            this.lbAchievementMoney.Name = "lbAchievementMoney";
            this.lbAchievementMoney.Size = new System.Drawing.Size(53, 12);
            this.lbAchievementMoney.TabIndex = 5;
            this.lbAchievementMoney.Text = "支撑基金";
            // 
            // lbAchievementCompany
            // 
            this.lbAchievementCompany.AutoSize = true;
            this.lbAchievementCompany.Location = new System.Drawing.Point(21, 154);
            this.lbAchievementCompany.Name = "lbAchievementCompany";
            this.lbAchievementCompany.Size = new System.Drawing.Size(29, 12);
            this.lbAchievementCompany.TabIndex = 4;
            this.lbAchievementCompany.Text = "单位";
            // 
            // lbAchievementAuthor
            // 
            this.lbAchievementAuthor.AutoSize = true;
            this.lbAchievementAuthor.Location = new System.Drawing.Point(21, 122);
            this.lbAchievementAuthor.Name = "lbAchievementAuthor";
            this.lbAchievementAuthor.Size = new System.Drawing.Size(29, 12);
            this.lbAchievementAuthor.TabIndex = 3;
            this.lbAchievementAuthor.Text = "作者";
            // 
            // lbAchievementDate
            // 
            this.lbAchievementDate.AutoSize = true;
            this.lbAchievementDate.Location = new System.Drawing.Point(21, 89);
            this.lbAchievementDate.Name = "lbAchievementDate";
            this.lbAchievementDate.Size = new System.Drawing.Size(29, 12);
            this.lbAchievementDate.TabIndex = 2;
            this.lbAchievementDate.Text = "时间";
            // 
            // lbAchievementType
            // 
            this.lbAchievementType.AutoSize = true;
            this.lbAchievementType.Location = new System.Drawing.Point(9, 55);
            this.lbAchievementType.Name = "lbAchievementType";
            this.lbAchievementType.Size = new System.Drawing.Size(53, 12);
            this.lbAchievementType.TabIndex = 1;
            this.lbAchievementType.Text = "成果类型";
            // 
            // lbAchievementName
            // 
            this.lbAchievementName.AutoSize = true;
            this.lbAchievementName.Location = new System.Drawing.Point(9, 24);
            this.lbAchievementName.Name = "lbAchievementName";
            this.lbAchievementName.Size = new System.Drawing.Size(53, 12);
            this.lbAchievementName.TabIndex = 0;
            this.lbAchievementName.Text = "成果名称";
            // 
            // gbAchievementView
            // 
            this.gbAchievementView.Controls.Add(this.dgvData);
            this.gbAchievementView.Location = new System.Drawing.Point(333, 13);
            this.gbAchievementView.Name = "gbAchievementView";
            this.gbAchievementView.Size = new System.Drawing.Size(494, 260);
            this.gbAchievementView.TabIndex = 1;
            this.gbAchievementView.TabStop = false;
            this.gbAchievementView.Text = "检索信息显示";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 17);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(488, 240);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(31, 284);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(173, 284);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "更新此项成果";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(339, 284);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除此项成果";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOutToFile
            // 
            this.btnOutToFile.Location = new System.Drawing.Point(519, 284);
            this.btnOutToFile.Name = "btnOutToFile";
            this.btnOutToFile.Size = new System.Drawing.Size(151, 23);
            this.btnOutToFile.TabIndex = 5;
            this.btnOutToFile.Text = "导出此检索结果到文件";
            this.btnOutToFile.UseVisualStyleBackColor = true;
            this.btnOutToFile.Click += new System.EventHandler(this.btnOutToFile_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(730, 284);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmAchievementSearchComplex
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(839, 320);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOutToFile);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.gbAchievementView);
            this.Controls.Add(this.gbAchievementData);
            this.Name = "frmAchievementSearchComplex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "高级成果检索";
            this.Load += new System.EventHandler(this.frmAchievementSearchComplex_Load);
            this.gbAchievementData.ResumeLayout(false);
            this.gbAchievementData.PerformLayout();
            this.gbAchievementView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAchievementData;
        private System.Windows.Forms.GroupBox gbAchievementView;
        private System.Windows.Forms.Label lbAchievementName;
        private System.Windows.Forms.Label lbAchievementType;
        private System.Windows.Forms.Label lbAchievementAuthor;
        private System.Windows.Forms.Label lbAchievementDate;
        private System.Windows.Forms.Label lbAchievementMoney;
        private System.Windows.Forms.Label lbAchievementCompany;
        private System.Windows.Forms.TextBox txtAchievementMoney;
        private System.Windows.Forms.TextBox txtAchievementCompany;
        private System.Windows.Forms.TextBox txtAchievementAuthor;
        private System.Windows.Forms.DateTimePicker dtpAchievementDate;
        private System.Windows.Forms.TextBox txtAchievementType;
        private System.Windows.Forms.TextBox txtAchievementName;
        private System.Windows.Forms.CheckBox cbAchievementMoney;
        private System.Windows.Forms.CheckBox cbAchievementDate;
        private System.Windows.Forms.ComboBox cboLogic;
        private System.Windows.Forms.Label lbLogic;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOutToFile;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.SaveFileDialog sfdOutToFile;
    }
}