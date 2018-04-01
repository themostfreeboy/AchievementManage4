using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AchievementManage
{
    public partial class frmMechanicalDrawing : Form
    {
        public frmMechanicalDrawing()
        {
            InitializeComponent();
        }

        private void frmMechanicalDrawing_Load(object sender, EventArgs e)//窗体载入时初始化
        {
            txtAchievementName.Text = string.Empty;//成果名称显示内容
            txtSaveDirectory.Text = string.Empty;//成果保存目录显示内容
            txtPartNum.Text = "0";//零件图个数显示内容
            txtAssemblyNum.Text = "0";//装配图个数显示内容
            txtDrawingNum.Text = "0";//工程图纸个数显示内容
            this.dgvData.DataSource = null;//机械图信息显示DataGridView控件显示数据
            this.dgvData.AllowUserToAddRows = false;//不允许用户添加新行
            btnCount.Text = "开始统计个数信息";//设置开始统计个数信息按钮显示内容
            btnCount.Enabled = true;//开始统计个数信息按钮可点击
            btnOutToFile.Text = "导出此视图内容到文件";//设置导出此视图内容到文件按钮显示内容
            btnOutToFile.Enabled = false;//设置导出此视图内容到文件按钮不可点击
            btnUpdate.Enabled = false;//更新机械图信息按钮不可点击

            #region 所用软件组合框初始化
            this.cboSoftware.Items.Clear();//清空combox内所有选项
            this.cboSoftware.Items.Add("CAD");
            this.cboSoftware.Items.Add("UG");
            this.cboSoftware.Items.Add("Solidworks");
            this.cboSoftware.Items.Add("Inventor");
            this.cboSoftware.Items.Add("ProE");
            this.cboSoftware.Items.Add("Catia");
            this.cboSoftware.Items.Add("(其他)");
            this.cboSoftware.Items.Add("(Unknown)");//所用软件未知，数据库内该字段的默认值
            this.cboSoftware.SelectedIndex = 7;//选中默认值"(Unknown)"
            #endregion

            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }

            try
            {
                string sql_1 = "select datainfo.AchievementName as '成果名称', datainfo.AchievementType as '成果类型', datainfo.AchievementDate as '时间', datainfo.AchievementAuthor as '作者', datainfo.AchievementCompany as '单位', datainfo.AchievementMoney as '支撑基金' from datainfo where AchievementType='机械图';";
                DataTable dt_1 = MyDatabase.GetDataTableBySql(sql_1);
                if (dt_1.Rows.Count == 0)//未检索到任何机械图成果
                {
                    this.dgvData.DataSource = null;//机械图信息显示DataGridView控件显示数据
                    btnUpdate.Enabled = false;//更新机械图信息按钮不可点击
                    btnOutToFile.Text = "导出此视图内容到文件";//设置导出此视图内容到文件按钮显示内容
                    btnOutToFile.Enabled = false;//设置导出此视图内容到文件按钮不可点击
                    MessageBox.Show("目前未有任何机械图成果，请先添加机械图成果！", "提示");
                    return;
                }
                for (int i = 0; i < dt_1.Rows.Count; i++)//对所有在mechanicaldrawing表中没有的机械图成果自动添加所有值为默认值的记录
                {
                    string sql_2 = string.Format("select mechanicaldrawing.AchievementName as '成果名称', mechanicaldrawing.SaveDirectory as '成果保存目录', mechanicaldrawing.PartNum as '零件图个数', mechanicaldrawing.AssemblyNum as '装配图个数', mechanicaldrawing.DrawingNum as '工程图纸个数' from mechanicaldrawing where mechanicaldrawing.AchievementName='{0}';", MyDatabase.CharFilter(dt_1.Rows[i][0].ToString().Trim()));
                    DataTable dt_2 = MyDatabase.GetDataTableBySql(sql_2);
                    if (dt_2.Rows.Count == 0)//此机械图成果在mechanicaldrawing表无记录，添加所有值为默认值的记录
                    {
                        string sql_3 = string.Format("insert into mechanicaldrawing values('{0}', '(Unknown)', '(Null)', 0, 0, 0);", MyDatabase.CharFilter(dt_1.Rows[i][0].ToString().Trim()));
                        if (MyDatabase.UpdateDataBySql(sql_3) == false)//添加失败
                        {
                            this.dgvData.DataSource = null;//机械图信息显示DataGridView控件显示数据
                            btnUpdate.Enabled = false;//更新机械图信息按钮不可点击
                            btnOutToFile.Text = "导出此视图内容到文件";//设置导出此视图内容到文件按钮显示内容
                            btnOutToFile.Enabled = false;//设置导出此视图内容到文件按钮不可点击
                            MessageBox.Show("获取数据初始化时失败！", "提示");
                            return;
                        }
                    }
                }
                string sql_4 = "select datainfo.AchievementName as '成果名称', datainfo.AchievementType as '成果类型', datainfo.AchievementDate as '时间', datainfo.AchievementAuthor as '作者', datainfo.AchievementCompany as '单位', datainfo.AchievementMoney as '支撑基金', mechanicaldrawing.Software as '所用软件', mechanicaldrawing.SaveDirectory as '成果保存目录', mechanicaldrawing.PartNum as '零件图个数', mechanicaldrawing.AssemblyNum as '装配图个数', mechanicaldrawing.DrawingNum as '工程图纸个数' from datainfo join mechanicaldrawing on datainfo.AchievementName=mechanicaldrawing.AchievementName;";
                DataTable dt_4 = MyDatabase.GetDataTableBySql(sql_4);
                this.dgvData.DataSource = null;//先置为null，否则在右键删除DataGridView后再次检索后显示的字段顺序会有误
                this.dgvData.DataSource = dt_4;//机械图信息显示DataGridView控件显示数据
                btnUpdate.Enabled = true;//更新机械图信息按钮可点击
                btnOutToFile.Text = "导出此视图内容到文件";//设置导出此视图内容到文件按钮显示内容
                btnOutToFile.Enabled = true;//设置导出此视图内容到文件按钮可点击
                this.txtAchievementName.Text = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[0].Value.ToString().Trim());
                this.cboSoftware.Text = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[6].Value.ToString().Trim());
                this.txtSaveDirectory.Text = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[7].Value.ToString().Trim());
                this.txtPartNum.Text = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[8].Value.ToString().Trim());
                this.txtAssemblyNum.Text = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[9].Value.ToString().Trim());
                this.txtDrawingNum.Text = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[10].Value.ToString().Trim());
                return;
            }
            catch (Exception ex)
            {
                this.dgvData.DataSource = null;//机械图信息显示DataGridView控件显示数据
                btnUpdate.Enabled = false;//更新机械图信息按钮不可点击
                btnOutToFile.Text = "导出此视图内容到文件";//设置导出此视图内容到文件按钮显示内容
                btnOutToFile.Enabled = false;//设置导出此视图内容到文件按钮不可点击
                MessageBox.Show("机械图管理界面初始化失败！", "提示");
                return;
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)//单击单元格的任意部分
        {
            int index = this.dgvData.CurrentCell.RowIndex;//获取当前鼠标单击时的行索引号
            if (index >= 0)
            {
                this.txtAchievementName.Text = MyDatabase.CharFilter(this.dgvData.Rows[index].Cells[0].Value.ToString().Trim());
                if (txtAchievementName.Text != string.Empty)//点中了非最后一行的空白行
                {
                    this.cboSoftware.Text = MyDatabase.CharFilter(this.dgvData.Rows[index].Cells[6].Value.ToString().Trim());
                    this.txtSaveDirectory.Text = MyDatabase.CharFilter(this.dgvData.Rows[index].Cells[7].Value.ToString().Trim());
                    this.txtPartNum.Text = MyDatabase.CharFilter(this.dgvData.Rows[index].Cells[8].Value.ToString().Trim());
                    this.txtAssemblyNum.Text = MyDatabase.CharFilter(this.dgvData.Rows[index].Cells[9].Value.ToString().Trim());
                    this.txtDrawingNum.Text = MyDatabase.CharFilter(this.dgvData.Rows[index].Cells[10].Value.ToString().Trim());
                    btnUpdate.Enabled = true;//更新机械图信息按钮可点击
                }
                else//点中了最后一行的空白行
                {
                    this.cboSoftware.SelectedIndex = 7;//选中默认值"(Unknown)"
                    this.txtSaveDirectory.Text = string.Empty;
                    this.txtPartNum.Text = "0";
                    this.txtAssemblyNum.Text = "0";
                    this.txtDrawingNum.Text = "0";
                    btnUpdate.Enabled = false;//更新机械图信息按钮不可点击
                }
            }
        }

        private void btnChooseDirectory_Click(object sender, EventArgs e)//选择目录
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            try
            {
                DialogResult result = this.fbdChooseDirectory.ShowDialog();
                if (result == DialogResult.OK)//点击了确定
                {
                    this.txtSaveDirectory.Text = fbdChooseDirectory.SelectedPath;
                }
                else//点击了取消
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择目录过程中出错！", "提示");
                return;
            }
        }

        private void btnCount_Click(object sender, EventArgs e)//开始统计个数信息
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            if (txtSaveDirectory.Text == string.Empty)//判断成果保存目录是否为空
            {
                txtPartNum.Text = "0";//零件图个数显示内容
                txtAssemblyNum.Text = "0";//装配图个数显示内容
                txtDrawingNum.Text = "0";//工程图纸个数显示内容
                MessageBox.Show("成果保存目录不能为空！", "提示");
                return;
            }
            if (System.IO.Directory.Exists(txtSaveDirectory.Text) == false)//判断成果保存目录是否存在
            {
                txtPartNum.Text = "0";//零件图个数显示内容
                txtAssemblyNum.Text = "0";//装配图个数显示内容
                txtDrawingNum.Text = "0";//工程图纸个数显示内容
                MessageBox.Show("成果保存目录不存在！", "提示");
                return;
            }
            try
            {
                btnCount.Text = "正在统计中。。。";//设置开始统计个数信息按钮显示内容
                btnCount.Enabled = false;//开始统计个数信息按钮不可点击
                int[] num = new int[3];
                num[0] = 0;//零件图个数
                num[1] = 0;//装配图个数
                num[2] = 0;//工程图纸个数
                countFile(txtSaveDirectory.Text, num);
                txtPartNum.Text = num[0].ToString();//零件图个数显示内容
                txtAssemblyNum.Text = num[1].ToString();//装配图个数显示内容
                txtDrawingNum.Text = num[2].ToString();//工程图纸个数显示内容
                btnCount.Text = "开始统计个数信息";//设置开始统计个数信息按钮显示内容
                btnCount.Enabled = true;//开始统计个数信息按钮可点击
                MessageBox.Show("个数信息统计完成！", "提示");
                return;
            }
            catch (Exception ex)
            {
                txtPartNum.Text = "0";//零件图个数显示内容
                txtAssemblyNum.Text = "0";//装配图个数显示内容
                txtDrawingNum.Text = "0";//工程图纸个数显示内容
                btnCount.Text = "开始统计个数信息";//设置开始统计个数信息按钮显示内容
                btnCount.Enabled = true;//开始统计个数信息按钮可点击
                MessageBox.Show("个数信息统计失败！", "提示");
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)//更新机械图信息
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            try
            {
                if (txtSaveDirectory.Text == string.Empty)//判断成果保存目录是否为空
                {
                    txtSaveDirectory.Text = "(Null)";//成果保存目录如果为空，则置其值为(Null)(数据库中默认值)
                }
                string sql_1 = string.Format("update mechanicaldrawing set mechanicaldrawing.AchievementName='{0}', mechanicaldrawing.Software='{1}', mechanicaldrawing.SaveDirectory='{2}', mechanicaldrawing.PartNum={3}, mechanicaldrawing.AssemblyNum={4}, mechanicaldrawing.DrawingNum={5} where mechanicaldrawing.AchievementName='{6}';", MyDatabase.CharFilter(this.txtAchievementName.Text.ToString().Trim()), MyDatabase.CharFilter(this.cboSoftware.Text.ToString().Trim()), MyDatabase.CharFilter(this.txtSaveDirectory.Text.ToString().Trim()), Convert.ToInt32(MyDatabase.CharFilter(this.txtPartNum.Text.ToString().Trim())), Convert.ToInt32(MyDatabase.CharFilter(this.txtAssemblyNum.Text.ToString().Trim())), Convert.ToInt32(MyDatabase.CharFilter(this.txtDrawingNum.Text.ToString().Trim())), MyDatabase.CharFilter(this.txtAchievementName.Text.ToString().Trim()));//sql语句
                if (MyDatabase.UpdateDataBySql(sql_1))//更新成功
                {
                    //更新DataGridView控件内的内容
                    string sql_2 = "select datainfo.AchievementName as '成果名称', datainfo.AchievementType as '成果类型', datainfo.AchievementDate as '时间', datainfo.AchievementAuthor as '作者', datainfo.AchievementCompany as '单位', datainfo.AchievementMoney as '支撑基金', mechanicaldrawing.Software as '所用软件', mechanicaldrawing.SaveDirectory as '成果保存目录', mechanicaldrawing.PartNum as '零件图个数', mechanicaldrawing.AssemblyNum as '装配图个数', mechanicaldrawing.DrawingNum as '工程图纸个数' from datainfo join mechanicaldrawing on datainfo.AchievementName=mechanicaldrawing.AchievementName;";
                    DataTable dt_2 = MyDatabase.GetDataTableBySql(sql_2);
                    this.dgvData.DataSource = dt_2;//机械图信息显示DataGridView控件显示数据
                    btnUpdate.Enabled = true;//更新机械图信息按钮可点击
                    btnOutToFile.Text = "导出此视图内容到文件";//设置导出此视图内容到文件按钮显示内容
                    btnOutToFile.Enabled = true;//设置导出此视图内容到文件按钮可点击
                    MessageBox.Show("更新成功！", "提示");
                    return;
                }
                else//更新失败
                {
                    MessageBox.Show("更新失败！", "提示");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失败！", "提示");
                return;
            }
        }

        private void btnOutToFile_Click(object sender, EventArgs e)//导出此视图内容到文件
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            try
            {
                DataTable dt = MyExcel.GetDgvToTable(dgvData);
                this.sfdOutToFile.Filter = "Excel 工作簿(*.xlsx)|*.xlsx|文本文档(*.txt)|*.txt";//设置保存类型
                this.sfdOutToFile.AddExtension = true;//自动添加扩展名
                DialogResult result = this.sfdOutToFile.ShowDialog();
                if (result == DialogResult.OK)//点击了保存
                {
                    btnOutToFile.Text = "正在导出中。。。";//导出此视图内容到文件按钮显示内容
                    btnOutToFile.Enabled = false;//导出此视图内容到文件按钮不可点击
                    if (MyData.DataConvert(dt) == false)//对dt内的数据进行处理，尤其是“(数据格式有误)”这种情况
                    {
                        btnOutToFile.Text = "导出此视图内容到文件";//设置导出此视图内容到文件按钮显示内容
                        btnOutToFile.Enabled = true;//设置导出此视图内容到文件按钮可点击
                        MessageBox.Show("导出失败！", "提示");
                        return;
                    }
                    if (MyData.GetFileExtByFileName(sfdOutToFile.FileName) == "xlsx")//导出到Excel文件
                    {
                        MyExcel.SaveDataToExcel(dt, sfdOutToFile.FileName);//此过程很慢
                    }
                    else if (MyData.GetFileExtByFileName(sfdOutToFile.FileName) == "txt")//导出到txt文件
                    {
                        MyTxt.SaveDataToTxt(dt, sfdOutToFile.FileName);
                    }
                    else//扩展名有误
                    {
                        btnOutToFile.Text = "导出此视图内容到文件";//设置导出此视图内容到文件按钮显示内容
                        btnOutToFile.Enabled = true;//设置导出此视图内容到文件按钮可点击
                        MessageBox.Show("导出类型为不支持的类型，导出失败！", "提示");
                        return;
                    }
                    btnOutToFile.Text = "导出此视图内容到文件";//导出此视图内容到文件按钮显示内容
                    btnOutToFile.Enabled = true;//导出此视图内容到文件按钮可点击
                    MessageBox.Show("导出成功！", "提示");
                    return;
                }
                else if (result == DialogResult.Cancel)//点击了取消
                {
                    btnOutToFile.Text = "导出此视图内容到文件";//设置导出此视图内容到文件按钮显示内容
                    btnOutToFile.Enabled = true;//设置导出此视图内容到文件按钮可点击
                    return;
                }
            }
            catch (Exception ex)
            {
                btnOutToFile.Text = "导出此视图内容到文件";//设置导出此视图内容到文件按钮显示内容
                btnOutToFile.Enabled = true;//设置导出此视图内容到文件按钮可点击
                MessageBox.Show("导出失败！", "提示");
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)//退出
        {
            this.Close();//关闭窗体
        }

        private void countFile(string path, int[] num)//遍历统计文件信息
        {
            try
            {
                string[] AllFile = System.IO.Directory.GetFiles(path);
                for (int i = 0; i < AllFile.Length; i++)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(AllFile[i]);
                    if (fi.Extension == ".prt" || fi.Extension == ".sldprt" || fi.Extension == ".ipt" || fi.Extension == ".catpart")//零件图
                    {
                        num[0]++;//零件图个数
                    }
                    else if (fi.Extension == ".asm" || fi.Extension == ".sldasm" || fi.Extension == ".iam" || fi.Extension == ".catproduct")//装配图
                    {
                        num[1]++;//装配图个数
                    }
                    else if (fi.Extension == ".dwg" || fi.Extension == ".exb" || fi.Extension == ".dxf" || fi.Extension == ".drw" || fi.Extension == ".slddrw" || fi.Extension == ".catdrawing")//工程图纸
                    {
                        num[2]++;//工程图纸个数
                    }
                }
                string[] AllDir = System.IO.Directory.GetDirectories(path);
                for (int i = 0; i < AllDir.Length; i++)//遍历所有子文件夹
                {
                    countFile(AllDir[i], num);//递归方式遍历所有子文件夹
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
