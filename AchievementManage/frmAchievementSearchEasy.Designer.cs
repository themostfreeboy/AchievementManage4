namespace AchievementManage
{
    partial class frmAchievementSearchEasy
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
            this.cboAchievementType = new System.Windows.Forms.ComboBox();
            this.lbAchievementType = new System.Windows.Forms.Label();
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
            this.gbAchievementData.Controls.Add(this.cboAchievementType);
            this.gbAchievementData.Controls.Add(this.lbAchievementType);
            this.gbAchievementData.Location = new System.Drawing.Point(13, 13);
            this.gbAchievementData.Name = "gbAchievementData";
            this.gbAchievementData.Size = new System.Drawing.Size(289, 248);
            this.gbAchievementData.TabIndex = 0;
            this.gbAchievementData.TabStop = false;
            this.gbAchievementData.Text = "检索信息输入";
            // 
            // cboAchievementType
            // 
            this.cboAchievementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAchievementType.FormattingEnabled = true;
            this.cboAchievementType.Location = new System.Drawing.Point(99, 92);
            this.cboAchievementType.Name = "cboAchievementType";
            this.cboAchievementType.Size = new System.Drawing.Size(172, 20);
            this.cboAchievementType.TabIndex = 1;
            // 
            // lbAchievementType
            // 
            this.lbAchievementType.AutoSize = true;
            this.lbAchievementType.Location = new System.Drawing.Point(22, 98);
            this.lbAchievementType.Name = "lbAchievementType";
            this.lbAchievementType.Size = new System.Drawing.Size(53, 12);
            this.lbAchievementType.TabIndex = 0;
            this.lbAchievementType.Text = "成果类型";
            // 
            // gbAchievementView
            // 
            this.gbAchievementView.Controls.Add(this.dgvData);
            this.gbAchievementView.Location = new System.Drawing.Point(308, 13);
            this.gbAchievementView.Name = "gbAchievementView";
            this.gbAchievementView.Size = new System.Drawing.Size(519, 248);
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
            this.dgvData.Size = new System.Drawing.Size(513, 228);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(33, 283);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(172, 283);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "更新此项成果";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(333, 283);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除此项成果";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOutToFile
            // 
            this.btnOutToFile.Location = new System.Drawing.Point(495, 283);
            this.btnOutToFile.Name = "btnOutToFile";
            this.btnOutToFile.Size = new System.Drawing.Size(154, 23);
            this.btnOutToFile.TabIndex = 5;
            this.btnOutToFile.Text = "导出此检索结果到文件";
            this.btnOutToFile.UseVisualStyleBackColor = true;
            this.btnOutToFile.Click += new System.EventHandler(this.btnOutToFile_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(713, 283);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmAchievementSearchEasy
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
            this.Name = "frmAchievementSearchEasy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简单成果检索";
            this.Load += new System.EventHandler(this.frmAchievementSearchEasy_Load);
            this.gbAchievementData.ResumeLayout(false);
            this.gbAchievementData.PerformLayout();
            this.gbAchievementView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAchievementData;
        private System.Windows.Forms.GroupBox gbAchievementView;
        private System.Windows.Forms.Label lbAchievementType;
        private System.Windows.Forms.ComboBox cboAchievementType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOutToFile;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.SaveFileDialog sfdOutToFile;
    }
}