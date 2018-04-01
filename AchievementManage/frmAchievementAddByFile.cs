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
    public partial class frmAchievementAddByFile : Form
    {
        public frmAchievementAddByFile()
        {
            InitializeComponent();
        }

        private void frmAchievementAddByFile_Load(object sender, EventArgs e)//窗体载入时初始化
        {
            btnOutToFileSuccess.Text = "将导入成功的成果导出到文件";//将导入成功的成果导出到文件按钮显示内容
            btnOutToFileSuccess.Enabled = false;//将导入成功的成果导出到文件按钮不可点击
            this.dgvDataSuccess.DataSource = null;//导入成功的信息显示DataGridView控件显示数据
            this.dgvDataSuccess.AllowUserToAddRows = false;//不允许用户添加新行

            btnOutToFileFail.Text = "将导入失败的成果导出到文件";//将导入失败的成果导出到文件按钮显示内容
            btnOutToFileFail.Enabled = false;//将导入失败的成果导出到文件按钮不可点击
            this.dgvDataFail.DataSource = null;//导入失败的信息显示DataGridView控件显示数据
            this.dgvDataFail.AllowUserToAddRows = false;//不允许用户添加新行

            txtResultSuccess.Text = "0";//导入成功成果数目为0
            txtResultFail.Text = "0";//导入失败成果数目为0

            btnAdd.Text = "开始导入";//开始导入按钮显示内容
            btnAdd.Enabled = true;//开始导入按钮可点击

            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)//选择文件
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            try
            {
                this.ofdLoadFromFile.Filter = "Excel 工作簿(*.xlsx)|*.xlsx|Excel 97-2003 工作簿(*.xls)|*.xls|文本文档(*.txt)|*.txt";//设置打开文件类型
                this.ofdLoadFromFile.AddExtension = true;//自动添加扩展名
                DialogResult result = this.ofdLoadFromFile.ShowDialog();
                if (result == DialogResult.OK)//点击了打开
                {
                    txtFilePath.Text = ofdLoadFromFile.FileName;
                }
                else//点击了取消
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件过程中出错！", "提示");
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)//开始导入
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            if (txtFilePath.Text == string.Empty)//判断文件路径是否为空
            {
                MessageBox.Show("文件路径不能为空！", "提示");
                return;
            }
            if (System.IO.File.Exists(txtFilePath.Text) == false)//判断文件是否存在
            {
                MessageBox.Show("文件不存在！", "提示");
                return;
            }
            try
            {
                btnAdd.Text = "正在导入中。。。";//开始导入按钮显示内容
                btnAdd.Enabled = false;//开始导入按钮不可点击
                System.Data.DataTable dt = new System.Data.DataTable();
                if (MyData.GetFileExtByFileName(txtFilePath.Text) == "xlsx" || MyData.GetFileExtByFileName(txtFilePath.Text) == "xls")//从Excel文件导入
                {
                    if (MyExcel.CheckExcelFileData(txtFilePath.Text, 6) == false)
                    {
                        btnAdd.Text = "开始导入";//开始导入按钮显示内容
                        btnAdd.Enabled = true;//开始导入按钮可点击
                        MessageBox.Show("文件数据格式有误，导入失败！", "提示");
                        return;
                    }
                    dt = MyExcel.LoadDataFromExcel(txtFilePath.Text);
                    if (MyExcel.DateTimeConvert(dt) == false)//从Excel文件中读取OA数据格式的日期文件后转换为字符串
                    {
                        btnAdd.Text = "开始导入";//开始导入按钮显示内容
                        btnAdd.Enabled = true;//开始导入按钮可点击
                        MessageBox.Show("文件数据格式有误，导入失败！", "提示");
                        return;
                    }
                }
                else if (MyData.GetFileExtByFileName(txtFilePath.Text) == "txt")//从txt文件导入
                {
                    if (MyTxt.CheckTxtFileData(txtFilePath.Text, 6) == false)
                    {
                        btnAdd.Text = "开始导入";//开始导入按钮显示内容
                        btnAdd.Enabled = true;//开始导入按钮可点击
                        MessageBox.Show("文件数据格式有误，导入失败！", "提示");
                        return;
                    }
                    dt = MyTxt.LoadDataFromTxt(txtFilePath.Text);
                }
                else//扩展名有误
                {
                    btnAdd.Text = "开始导入";//开始导入按钮显示内容
                    btnAdd.Enabled = true;//开始导入按钮可点击
                    MessageBox.Show("文件类型为不支持的导入类型，导入失败！", "提示");
                    return;
                }

                #region 将从文件导入的数据添加到数据库中
                System.Data.DataTable dt_success = new System.Data.DataTable();
                System.Data.DataTable dt_fail = new System.Data.DataTable();
                int success_num = 0;
                int fail_num = 0;
                for (int i = 0; i < dt.Columns.Count; i++)//写入表头信息
                {
                    dt_success.Columns.Add(dt.Columns[i].ColumnName);
                    dt_fail.Columns.Add(dt.Columns[i].ColumnName);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        string sql = string.Empty;
                        sql = string.Format("insert into datainfo values('{0}', '{1}', '{2}', '{3}', '{4}', {5});", MyDatabase.CharFilter(dt.Rows[i][0].ToString().Trim()), MyDatabase.CharFilter(dt.Rows[i][1].ToString().Trim()), Convert.ToDateTime(dt.Rows[i][2].ToString().Trim()).ToString("yyyy-MM-dd"), MyDatabase.CharFilter(dt.Rows[i][3].ToString().Trim()), MyDatabase.CharFilter(dt.Rows[i][4].ToString().Trim()), Convert.ToDouble(MyDatabase.CharFilter(dt.Rows[i][5].ToString().Trim())));//sql语句
                        if (MyDatabase.UpdateDataBySql(sql))//添加成功
                        {
                            success_num++;
                            DataRow dr = dt_success.NewRow();
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                try
                                {
                                    if (j == 2)//对成果时间的数据格式的单独转化
                                    {
                                        dr[j] = Convert.ToDateTime(dt.Rows[i][j].ToString().Trim()).ToString("yyyy-MM-dd");
                                    }
                                    else if (j == 5)//对成果支撑基金的格式的单独转化
                                    {
                                        dr[j] = Convert.ToDouble(MyDatabase.CharFilter(dt.Rows[i][j].ToString().Trim()));
                                    }
                                    else//其他字段格式不需要转化
                                    {
                                        dr[j] = MyDatabase.CharFilter(dt.Rows[i][j].ToString());
                                    }
                                }
                                catch (Exception ex_2)//格式转化出错
                                {
                                    dr[j] = "(数据格式有误)".ToString();
                                }
                            }
                            dt_success.Rows.Add(dr);
                        }
                        else//添加失败
                        {
                            fail_num++;
                            DataRow dr = dt_fail.NewRow();
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                try
                                {
                                    if (j == 2)//对成果时间的数据格式的单独转化
                                    {
                                        dr[j] = Convert.ToDateTime(dt.Rows[i][j].ToString().Trim()).ToString("yyyy-MM-dd");
                                    }
                                    else if (j == 5)//对成果支撑基金的格式的单独转化
                                    {
                                        dr[j] = Convert.ToDouble(MyDatabase.CharFilter(dt.Rows[i][j].ToString().Trim()));
                                    }
                                    else//其他字段格式不需要转化
                                    {
                                        dr[j] = MyDatabase.CharFilter(dt.Rows[i][j].ToString());
                                    }
                                }
                                catch (Exception ex_2)//格式转化出错
                                {
                                    dr[j] = "(数据格式有误)".ToString();
                                }
                            }
                            dt_fail.Rows.Add(dr);
                        }
                    }
                    catch (Exception ex)//添加时发生异常
                    {
                        fail_num++;
                        DataRow dr = dt_fail.NewRow();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            try
                            {
                                if (j == 2)//对成果时间的数据格式的单独转化
                                {
                                    dr[j] = Convert.ToDateTime(dt.Rows[i][j].ToString().Trim()).ToString("yyyy-MM-dd");
                                }
                                else if (j == 5)//对成果支撑基金的格式的单独转化
                                {
                                    dr[j] = Convert.ToDouble(MyDatabase.CharFilter(dt.Rows[i][j].ToString().Trim()));
                                }
                                else//其他字段格式不需要转化
                                {
                                    dr[j] = MyDatabase.CharFilter(dt.Rows[i][j].ToString());
                                }
                            }
                            catch (Exception ex_2)//格式转化出错
                            {
                                dr[j] = "(数据格式有误)".ToString();
                            }
                        }
                        dt_fail.Rows.Add(dr);
                    }
                }
                txtResultSuccess.Text = success_num.ToString();//导入成功成果数目
                txtResultFail.Text = fail_num.ToString();//导入失败成果数目
                if (success_num == 0)
                {
                    btnOutToFileSuccess.Text = "将导入成功的成果导出到文件";//将导入成功的成果导出到文件按钮显示内容
                    btnOutToFileSuccess.Enabled = false;//将导入成功的成果导出到文件按钮不可点击
                    this.dgvDataSuccess.DataSource = null;//导入成功的信息显示DataGridView控件显示数据
                }
                else
                {
                    btnOutToFileSuccess.Text = "将导入成功的成果导出到文件";//将导入成功的成果导出到文件按钮显示内容
                    btnOutToFileSuccess.Enabled = true;//将导入成功的成果导出到文件按钮可点击
                    this.dgvDataSuccess.DataSource = null;//先置为null，否则在右键删除DataGridView后再次检索后显示的字段顺序会有误
                    dgvDataSuccess.DataSource = dt_success;//导入成功的信息显示DataGridView控件显示数据
                }
                if (fail_num == 0)
                {
                    btnOutToFileFail.Text = "将导入失败的成果导出到文件";//将导入失败的成果导出到文件按钮显示内容
                    btnOutToFileFail.Enabled = false;//将导入失败的成果导出到文件按钮不可点击
                    this.dgvDataFail.DataSource = null;//导入失败的信息显示DataGridView控件显示数据
                }
                else
                {
                    btnOutToFileFail.Text = "将导入失败的成果导出到文件";//将导入失败的成果导出到文件按钮显示内容
                    btnOutToFileFail.Enabled = true;//将导入失败的成果导出到文件按钮可点击
                    this.dgvDataFail.DataSource = null;//先置为null，否则在右键删除DataGridView后再次检索后显示的字段顺序会有误
                    dgvDataFail.DataSource = dt_fail;//导入失败的信息显示DataGridView控件显示数据
                }
                #endregion

                btnAdd.Text = "开始导入";//开始导入按钮显示内容
                btnAdd.Enabled = true;//开始导入按钮可点击
                MessageBox.Show("文件导入完成！", "提示");
                return;
            }
            catch (Exception ex_1)
            {
                btnAdd.Text = "开始导入";//开始导入按钮显示内容
                btnAdd.Enabled = true;//开始导入按钮可点击
                MessageBox.Show("文件导入失败！", "提示");
                return;
            }
        }

        private void btnOutToFileSuccess_Click(object sender, EventArgs e)//将导入成功的成果导出到文件
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            try
            {
                DataTable dt = MyExcel.GetDgvToTable(dgvDataSuccess);
                this.sfdOutToFile.Filter = "Excel 工作簿(*.xlsx)|*.xlsx|文本文档(*.txt)|*.txt";//设置保存类型
                this.sfdOutToFile.AddExtension = true;//自动添加扩展名
                DialogResult result = this.sfdOutToFile.ShowDialog();
                if (result == DialogResult.OK)//点击了保存
                {
                    btnOutToFileSuccess.Text = "正在导出中。。。";//将导入成功的成果导出到文件按钮显示内容
                    btnOutToFileSuccess.Enabled = false;//将导入成功的成果导出到文件按钮不可点击
                    if (MyData.DataConvert(dt) == false)//对dt内的数据进行处理，尤其是“(数据格式有误)”这种情况
                    {
                        btnOutToFileSuccess.Text = "将导入成功的成果导出到文件";//设置将导入成功的成果导出到文件按钮显示内容
                        btnOutToFileSuccess.Enabled = true;//设置将导入成功的成果导出到文件按钮可点击
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
                        btnOutToFileSuccess.Text = "将导入成功的成果导出到文件";//设置将导入成功的成果导出到文件按钮显示内容
                        btnOutToFileSuccess.Enabled = true;//设置将导入成功的成果导出到文件按钮可点击
                        MessageBox.Show("导出类型为不支持的类型，导出失败！", "提示");
                        return;
                    }
                    btnOutToFileSuccess.Text = "将导入成功的成果导出到文件";//将导入成功的成果导出到文件按钮显示内容
                    btnOutToFileSuccess.Enabled = true;//将导入成功的成果导出到文件按钮可点击
                    MessageBox.Show("导出成功！", "提示");
                    return;
                }
                else if (result == DialogResult.Cancel)//点击了取消
                {
                    btnOutToFileSuccess.Text = "将导入成功的成果导出到文件";//设置将导入成功的成果导出到文件按钮显示内容
                    btnOutToFileSuccess.Enabled = true;//设置将导入成功的成果导出到文件按钮可点击
                    return;
                }
            }
            catch (Exception ex)
            {
                btnOutToFileSuccess.Text = "将导入成功的成果导出到文件";//设置将导入成功的成果导出到文件按钮显示内容
                btnOutToFileSuccess.Enabled = true;//设置将导入成功的成果导出到文件按钮可点击
                MessageBox.Show("导出失败！", "提示");
                return;
            }
        }

        private void btnOutToFileFail_Click(object sender, EventArgs e)//将导入失败的成果导出到文件
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            try
            {
                DataTable dt = MyExcel.GetDgvToTable(dgvDataFail);
                this.sfdOutToFile.Filter = "Excel 工作簿(*.xlsx)|*.xlsx|文本文档(*.txt)|*.txt";//设置保存类型
                this.sfdOutToFile.AddExtension = true;//自动添加扩展名
                DialogResult result = this.sfdOutToFile.ShowDialog();
                if (result == DialogResult.OK)//点击了保存
                {
                    btnOutToFileFail.Text = "正在导出中。。。";//将导入失败的成果导出到文件按钮显示内容
                    btnOutToFileFail.Enabled = false;//将导入失败的成果导出到文件按钮不可点击
                    if (MyData.DataConvert(dt) == false)//对dt内的数据进行处理，尤其是“(数据格式有误)”这种情况
                    {
                        btnOutToFileFail.Text = "将导入失败的成果导出到文件";//设置将导入失败的成果导出到文件按钮显示内容
                        btnOutToFileFail.Enabled = true;//设置将导入失败的成果导出到文件按钮可点击
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
                        btnOutToFileFail.Text = "将导入失败的成果导出到文件";//设置将导入失败的成果导出到文件按钮显示内容
                        btnOutToFileFail.Enabled = true;//设置将导入失败的成果导出到文件按钮可点击
                        MessageBox.Show("导出类型为不支持的类型，导出失败！", "提示");
                        return;
                    }
                    btnOutToFileFail.Text = "将导入失败的成果导出到文件";//将导入失败的成果导出到文件按钮显示内容
                    btnOutToFileFail.Enabled = true;//将导入失败的成果导出到文件按钮可点击
                    MessageBox.Show("导出成功！", "提示");
                    return;
                }
                else if (result == DialogResult.Cancel)//点击了取消
                {
                    btnOutToFileFail.Text = "将导入失败的成果导出到文件";//设置将导入失败的成果导出到文件按钮显示内容
                    btnOutToFileFail.Enabled = true;//设置将导入失败的成果导出到文件按钮可点击
                    return;
                }
            }
            catch (Exception ex)
            {
                btnOutToFileFail.Text = "将导入失败的成果导出到文件";//设置将导入失败的成果导出到文件按钮显示内容
                btnOutToFileFail.Enabled = true;//设置将导入失败的成果导出到文件按钮可点击
                MessageBox.Show("导出失败！", "提示");
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)//退出
        {
            this.Close();//关闭窗体
        }
    }
}
