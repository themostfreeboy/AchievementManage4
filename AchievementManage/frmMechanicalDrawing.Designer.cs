namespace AchievementManage
{
    partial class frmMechanicalDrawing
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
            this.gbMechanicalDrawingData = new System.Windows.Forms.GroupBox();
            this.cboSoftware = new System.Windows.Forms.ComboBox();
            this.txtDrawingNum = new System.Windows.Forms.TextBox();
            this.txtAssemblyNum = new System.Windows.Forms.TextBox();
            this.txtPartNum = new System.Windows.Forms.TextBox();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnChooseDirectory = new System.Windows.Forms.Button();
            this.txtSaveDirectory = new System.Windows.Forms.TextBox();
            this.txtAchievementName = new System.Windows.Forms.TextBox();
            this.lbDrawingNum = new System.Windows.Forms.Label();
            this.lbAssemblyNum = new System.Windows.Forms.Label();
            this.lbPartNum = new System.Windows.Forms.Label();
            this.lbSaveDirectory = new System.Windows.Forms.Label();
            this.lbSoftware = new System.Windows.Forms.Label();
            this.lbAchievementName = new System.Windows.Forms.Label();
            this.gbMechanicalDrawingView = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnOutToFile = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.fbdChooseDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.sfdOutToFile = new System.Windows.Forms.SaveFileDialog();
            this.gbMechanicalDrawingData.SuspendLayout();
            this.gbMechanicalDrawingView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMechanicalDrawingData
            // 
            this.gbMechanicalDrawingData.Controls.Add(this.cboSoftware);
            this.gbMechanicalDrawingData.Controls.Add(this.txtDrawingNum);
            this.gbMechanicalDrawingData.Controls.Add(this.txtAssemblyNum);
            this.gbMechanicalDrawingData.Controls.Add(this.txtPartNum);
            this.gbMechanicalDrawingData.Controls.Add(this.btnCount);
            this.gbMechanicalDrawingData.Controls.Add(this.btnChooseDirectory);
            this.gbMechanicalDrawingData.Controls.Add(this.txtSaveDirectory);
            this.gbMechanicalDrawingData.Controls.Add(this.txtAchievementName);
            this.gbMechanicalDrawingData.Controls.Add(this.lbDrawingNum);
            this.gbMechanicalDrawingData.Controls.Add(this.lbAssemblyNum);
            this.gbMechanicalDrawingData.Controls.Add(this.lbPartNum);
            this.gbMechanicalDrawingData.Controls.Add(this.lbSaveDirectory);
            this.gbMechanicalDrawingData.Controls.Add(this.lbSoftware);
            this.gbMechanicalDrawingData.Controls.Add(this.lbAchievementName);
            this.gbMechanicalDrawingData.Location = new System.Drawing.Point(12, 12);
            this.gbMechanicalDrawingData.Name = "gbMechanicalDrawingData";
            this.gbMechanicalDrawingData.Size = new System.Drawing.Size(417, 253);
            this.gbMechanicalDrawingData.TabIndex = 0;
            this.gbMechanicalDrawingData.TabStop = false;
            this.gbMechanicalDrawingData.Text = "机械图信息输入";
            // 
            // cboSoftware
            // 
            this.cboSoftware.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSoftware.FormattingEnabled = true;
            this.cboSoftware.Location = new System.Drawing.Point(109, 48);
            this.cboSoftware.Name = "cboSoftware";
            this.cboSoftware.Size = new System.Drawing.Size(293, 20);
            this.cboSoftware.TabIndex = 14;
            // 
            // txtDrawingNum
            // 
            this.txtDrawingNum.Location = new System.Drawing.Point(109, 222);
            this.txtDrawingNum.Name = "txtDrawingNum";
            this.txtDrawingNum.ReadOnly = true;
            this.txtDrawingNum.Size = new System.Drawing.Size(125, 21);
            this.txtDrawingNum.TabIndex = 13;
            this.txtDrawingNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAssemblyNum
            // 
            this.txtAssemblyNum.Location = new System.Drawing.Point(109, 189);
            this.txtAssemblyNum.Name = "txtAssemblyNum";
            this.txtAssemblyNum.ReadOnly = true;
            this.txtAssemblyNum.Size = new System.Drawing.Size(125, 21);
            this.txtAssemblyNum.TabIndex = 12;
            this.txtAssemblyNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPartNum
            // 
            this.txtPartNum.Location = new System.Drawing.Point(109, 149);
            this.txtPartNum.Name = "txtPartNum";
            this.txtPartNum.ReadOnly = true;
            this.txtPartNum.Size = new System.Drawing.Size(125, 21);
            this.txtPartNum.TabIndex = 11;
            this.txtPartNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCount
            // 
            this.btnCount.Location = new System.Drawing.Point(262, 112);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(122, 23);
            this.btnCount.TabIndex = 10;
            this.btnCount.Text = "开始统计个数信息";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // btnChooseDirectory
            // 
            this.btnChooseDirectory.Location = new System.Drawing.Point(136, 112);
            this.btnChooseDirectory.Name = "btnChooseDirectory";
            this.btnChooseDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnChooseDirectory.TabIndex = 9;
            this.btnChooseDirectory.Text = "选择目录";
            this.btnChooseDirectory.UseVisualStyleBackColor = true;
            this.btnChooseDirectory.Click += new System.EventHandler(this.btnChooseDirectory_Click);
            // 
            // txtSaveDirectory
            // 
            this.txtSaveDirectory.Location = new System.Drawing.Point(109, 80);
            this.txtSaveDirectory.Name = "txtSaveDirectory";
            this.txtSaveDirectory.Size = new System.Drawing.Size(293, 21);
            this.txtSaveDirectory.TabIndex = 8;
            // 
            // txtAchievementName
            // 
            this.txtAchievementName.Location = new System.Drawing.Point(109, 16);
            this.txtAchievementName.Name = "txtAchievementName";
            this.txtAchievementName.ReadOnly = true;
            this.txtAchievementName.Size = new System.Drawing.Size(293, 21);
            this.txtAchievementName.TabIndex = 6;
            // 
            // lbDrawingNum
            // 
            this.lbDrawingNum.AutoSize = true;
            this.lbDrawingNum.Location = new System.Drawing.Point(19, 225);
            this.lbDrawingNum.Name = "lbDrawingNum";
            this.lbDrawingNum.Size = new System.Drawing.Size(77, 12);
            this.lbDrawingNum.TabIndex = 5;
            this.lbDrawingNum.Text = "工程图纸个数";
            // 
            // lbAssemblyNum
            // 
            this.lbAssemblyNum.AutoSize = true;
            this.lbAssemblyNum.Location = new System.Drawing.Point(19, 192);
            this.lbAssemblyNum.Name = "lbAssemblyNum";
            this.lbAssemblyNum.Size = new System.Drawing.Size(65, 12);
            this.lbAssemblyNum.TabIndex = 4;
            this.lbAssemblyNum.Text = "装配图个数";
            // 
            // lbPartNum
            // 
            this.lbPartNum.AutoSize = true;
            this.lbPartNum.Location = new System.Drawing.Point(19, 152);
            this.lbPartNum.Name = "lbPartNum";
            this.lbPartNum.Size = new System.Drawing.Size(65, 12);
            this.lbPartNum.TabIndex = 3;
            this.lbPartNum.Text = "零件图个数";
            // 
            // lbSaveDirectory
            // 
            this.lbSaveDirectory.AutoSize = true;
            this.lbSaveDirectory.Location = new System.Drawing.Point(19, 83);
            this.lbSaveDirectory.Name = "lbSaveDirectory";
            this.lbSaveDirectory.Size = new System.Drawing.Size(77, 12);
            this.lbSaveDirectory.TabIndex = 2;
            this.lbSaveDirectory.Text = "成果保存目录";
            // 
            // lbSoftware
            // 
            this.lbSoftware.AutoSize = true;
            this.lbSoftware.Location = new System.Drawing.Point(19, 51);
            this.lbSoftware.Name = "lbSoftware";
            this.lbSoftware.Size = new System.Drawing.Size(53, 12);
            this.lbSoftware.TabIndex = 1;
            this.lbSoftware.Text = "所用软件";
            // 
            // lbAchievementName
            // 
            this.lbAchievementName.AutoSize = true;
            this.lbAchievementName.Location = new System.Drawing.Point(19, 19);
            this.lbAchievementName.Name = "lbAchievementName";
            this.lbAchievementName.Size = new System.Drawing.Size(53, 12);
            this.lbAchievementName.TabIndex = 0;
            this.lbAchievementName.Text = "成果名称";
            // 
            // gbMechanicalDrawingView
            // 
            this.gbMechanicalDrawingView.Controls.Add(this.dgvData);
            this.gbMechanicalDrawingView.Location = new System.Drawing.Point(432, 12);
            this.gbMechanicalDrawingView.Name = "gbMechanicalDrawingView";
            this.gbMechanicalDrawingView.Size = new System.Drawing.Size(395, 253);
            this.gbMechanicalDrawingView.TabIndex = 1;
            this.gbMechanicalDrawingView.TabStop = false;
            this.gbMechanicalDrawingView.Text = "机械图信息显示";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 17);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(389, 233);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(86, 285);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(117, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "更新机械图信息";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnOutToFile
            // 
            this.btnOutToFile.Location = new System.Drawing.Point(362, 285);
            this.btnOutToFile.Name = "btnOutToFile";
            this.btnOutToFile.Size = new System.Drawing.Size(154, 23);
            this.btnOutToFile.TabIndex = 3;
            this.btnOutToFile.Text = "导出此视图内容到文件";
            this.btnOutToFile.UseVisualStyleBackColor = true;
            this.btnOutToFile.Click += new System.EventHandler(this.btnOutToFile_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(685, 285);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmMechanicalDrawing
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(839, 320);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOutToFile);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.gbMechanicalDrawingView);
            this.Controls.Add(this.gbMechanicalDrawingData);
            this.Name = "frmMechanicalDrawing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "机械图管理";
            this.Load += new System.EventHandler(this.frmMechanicalDrawing_Load);
            this.gbMechanicalDrawingData.ResumeLayout(false);
            this.gbMechanicalDrawingData.PerformLayout();
            this.gbMechanicalDrawingView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMechanicalDrawingData;
        private System.Windows.Forms.GroupBox gbMechanicalDrawingView;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lbSaveDirectory;
        private System.Windows.Forms.Label lbSoftware;
        private System.Windows.Forms.Label lbAchievementName;
        private System.Windows.Forms.Button btnChooseDirectory;
        private System.Windows.Forms.TextBox txtSaveDirectory;
        private System.Windows.Forms.TextBox txtAchievementName;
        private System.Windows.Forms.Label lbDrawingNum;
        private System.Windows.Forms.Label lbAssemblyNum;
        private System.Windows.Forms.Label lbPartNum;
        private System.Windows.Forms.TextBox txtDrawingNum;
        private System.Windows.Forms.TextBox txtAssemblyNum;
        private System.Windows.Forms.TextBox txtPartNum;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnOutToFile;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.FolderBrowserDialog fbdChooseDirectory;
        private System.Windows.Forms.SaveFileDialog sfdOutToFile;
        private System.Windows.Forms.ComboBox cboSoftware;
    }
}