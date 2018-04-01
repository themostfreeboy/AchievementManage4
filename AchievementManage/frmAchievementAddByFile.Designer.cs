namespace AchievementManage
{
    partial class frmAchievementAddByFile
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
            this.lbFilePath = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbChooseFile = new System.Windows.Forms.GroupBox();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.txtResultFail = new System.Windows.Forms.TextBox();
            this.lbResultFail = new System.Windows.Forms.Label();
            this.txtResultSuccess = new System.Windows.Forms.TextBox();
            this.lbResultSuccess = new System.Windows.Forms.Label();
            this.gbAchievementViewSuccess = new System.Windows.Forms.GroupBox();
            this.dgvDataSuccess = new System.Windows.Forms.DataGridView();
            this.btnOutToFileSuccess = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbAchievementViewFail = new System.Windows.Forms.GroupBox();
            this.dgvDataFail = new System.Windows.Forms.DataGridView();
            this.btnOutToFileFail = new System.Windows.Forms.Button();
            this.ofdLoadFromFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdOutToFile = new System.Windows.Forms.SaveFileDialog();
            this.gbChooseFile.SuspendLayout();
            this.gbResult.SuspendLayout();
            this.gbAchievementViewSuccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataSuccess)).BeginInit();
            this.gbAchievementViewFail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataFail)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFilePath
            // 
            this.lbFilePath.AutoSize = true;
            this.lbFilePath.Location = new System.Drawing.Point(6, 27);
            this.lbFilePath.Name = "lbFilePath";
            this.lbFilePath.Size = new System.Drawing.Size(53, 12);
            this.lbFilePath.TabIndex = 0;
            this.lbFilePath.Text = "文件路径";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(74, 24);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(512, 21);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(610, 22);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(75, 23);
            this.btnChooseFile.TabIndex = 2;
            this.btnChooseFile.Text = "选择文件";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(695, 22);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "开始导入";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gbChooseFile
            // 
            this.gbChooseFile.Controls.Add(this.txtFilePath);
            this.gbChooseFile.Controls.Add(this.btnAdd);
            this.gbChooseFile.Controls.Add(this.lbFilePath);
            this.gbChooseFile.Controls.Add(this.btnChooseFile);
            this.gbChooseFile.Location = new System.Drawing.Point(12, 7);
            this.gbChooseFile.Name = "gbChooseFile";
            this.gbChooseFile.Size = new System.Drawing.Size(815, 65);
            this.gbChooseFile.TabIndex = 4;
            this.gbChooseFile.TabStop = false;
            this.gbChooseFile.Text = "选择导入文件";
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.txtResultFail);
            this.gbResult.Controls.Add(this.lbResultFail);
            this.gbResult.Controls.Add(this.txtResultSuccess);
            this.gbResult.Controls.Add(this.lbResultSuccess);
            this.gbResult.Location = new System.Drawing.Point(12, 78);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(146, 187);
            this.gbResult.TabIndex = 5;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "导入结果显示";
            // 
            // txtResultFail
            // 
            this.txtResultFail.Location = new System.Drawing.Point(24, 145);
            this.txtResultFail.Name = "txtResultFail";
            this.txtResultFail.ReadOnly = true;
            this.txtResultFail.Size = new System.Drawing.Size(100, 21);
            this.txtResultFail.TabIndex = 3;
            this.txtResultFail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbResultFail
            // 
            this.lbResultFail.AutoSize = true;
            this.lbResultFail.Location = new System.Drawing.Point(9, 112);
            this.lbResultFail.Name = "lbResultFail";
            this.lbResultFail.Size = new System.Drawing.Size(131, 12);
            this.lbResultFail.TabIndex = 2;
            this.lbResultFail.Text = "导入失败成果数目:(项)";
            // 
            // txtResultSuccess
            // 
            this.txtResultSuccess.Location = new System.Drawing.Point(24, 70);
            this.txtResultSuccess.Name = "txtResultSuccess";
            this.txtResultSuccess.ReadOnly = true;
            this.txtResultSuccess.Size = new System.Drawing.Size(100, 21);
            this.txtResultSuccess.TabIndex = 1;
            this.txtResultSuccess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbResultSuccess
            // 
            this.lbResultSuccess.AutoSize = true;
            this.lbResultSuccess.Location = new System.Drawing.Point(9, 34);
            this.lbResultSuccess.Name = "lbResultSuccess";
            this.lbResultSuccess.Size = new System.Drawing.Size(131, 12);
            this.lbResultSuccess.TabIndex = 0;
            this.lbResultSuccess.Text = "导入成功成果数目:(项)";
            // 
            // gbAchievementViewSuccess
            // 
            this.gbAchievementViewSuccess.Controls.Add(this.dgvDataSuccess);
            this.gbAchievementViewSuccess.Location = new System.Drawing.Point(164, 78);
            this.gbAchievementViewSuccess.Name = "gbAchievementViewSuccess";
            this.gbAchievementViewSuccess.Size = new System.Drawing.Size(323, 187);
            this.gbAchievementViewSuccess.TabIndex = 6;
            this.gbAchievementViewSuccess.TabStop = false;
            this.gbAchievementViewSuccess.Text = "导入成功的信息显示";
            // 
            // dgvDataSuccess
            // 
            this.dgvDataSuccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataSuccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataSuccess.Location = new System.Drawing.Point(3, 17);
            this.dgvDataSuccess.Name = "dgvDataSuccess";
            this.dgvDataSuccess.ReadOnly = true;
            this.dgvDataSuccess.RowTemplate.Height = 23;
            this.dgvDataSuccess.Size = new System.Drawing.Size(317, 167);
            this.dgvDataSuccess.TabIndex = 0;
            // 
            // btnOutToFileSuccess
            // 
            this.btnOutToFileSuccess.Location = new System.Drawing.Point(64, 282);
            this.btnOutToFileSuccess.Name = "btnOutToFileSuccess";
            this.btnOutToFileSuccess.Size = new System.Drawing.Size(174, 23);
            this.btnOutToFileSuccess.TabIndex = 7;
            this.btnOutToFileSuccess.Text = "将导入成功的成果导出到文件";
            this.btnOutToFileSuccess.UseVisualStyleBackColor = true;
            this.btnOutToFileSuccess.Click += new System.EventHandler(this.btnOutToFileSuccess_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(707, 282);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gbAchievementViewFail
            // 
            this.gbAchievementViewFail.Controls.Add(this.dgvDataFail);
            this.gbAchievementViewFail.Location = new System.Drawing.Point(493, 78);
            this.gbAchievementViewFail.Name = "gbAchievementViewFail";
            this.gbAchievementViewFail.Size = new System.Drawing.Size(334, 187);
            this.gbAchievementViewFail.TabIndex = 9;
            this.gbAchievementViewFail.TabStop = false;
            this.gbAchievementViewFail.Text = "导入失败的信息显示";
            // 
            // dgvDataFail
            // 
            this.dgvDataFail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataFail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataFail.Location = new System.Drawing.Point(3, 17);
            this.dgvDataFail.Name = "dgvDataFail";
            this.dgvDataFail.ReadOnly = true;
            this.dgvDataFail.RowTemplate.Height = 23;
            this.dgvDataFail.Size = new System.Drawing.Size(328, 167);
            this.dgvDataFail.TabIndex = 0;
            // 
            // btnOutToFileFail
            // 
            this.btnOutToFileFail.Location = new System.Drawing.Point(374, 282);
            this.btnOutToFileFail.Name = "btnOutToFileFail";
            this.btnOutToFileFail.Size = new System.Drawing.Size(173, 23);
            this.btnOutToFileFail.TabIndex = 10;
            this.btnOutToFileFail.Text = "将导入失败的结果导出到文件";
            this.btnOutToFileFail.UseVisualStyleBackColor = true;
            this.btnOutToFileFail.Click += new System.EventHandler(this.btnOutToFileFail_Click);
            // 
            // frmAchievementAddByFile
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(839, 320);
            this.Controls.Add(this.btnOutToFileFail);
            this.Controls.Add(this.gbAchievementViewFail);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOutToFileSuccess);
            this.Controls.Add(this.gbAchievementViewSuccess);
            this.Controls.Add(this.gbResult);
            this.Controls.Add(this.gbChooseFile);
            this.Name = "frmAchievementAddByFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成果录入(通过文件批量导入)";
            this.Load += new System.EventHandler(this.frmAchievementAddByFile_Load);
            this.gbChooseFile.ResumeLayout(false);
            this.gbChooseFile.PerformLayout();
            this.gbResult.ResumeLayout(false);
            this.gbResult.PerformLayout();
            this.gbAchievementViewSuccess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataSuccess)).EndInit();
            this.gbAchievementViewFail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataFail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbFilePath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gbChooseFile;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.GroupBox gbAchievementViewSuccess;
        private System.Windows.Forms.Button btnOutToFileSuccess;
        private System.Windows.Forms.DataGridView dgvDataSuccess;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox gbAchievementViewFail;
        private System.Windows.Forms.DataGridView dgvDataFail;
        private System.Windows.Forms.TextBox txtResultFail;
        private System.Windows.Forms.Label lbResultFail;
        private System.Windows.Forms.TextBox txtResultSuccess;
        private System.Windows.Forms.Label lbResultSuccess;
        private System.Windows.Forms.Button btnOutToFileFail;
        private System.Windows.Forms.OpenFileDialog ofdLoadFromFile;
        private System.Windows.Forms.SaveFileDialog sfdOutToFile;
    }
}