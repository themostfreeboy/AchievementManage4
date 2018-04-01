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
    public partial class frmAchievementSearchComplex : Form
    {
        public frmAchievementSearchComplex()
        {
            InitializeComponent();
        }

        private string txt_achievement_name = string.Empty;//存储数据库内的主键的值，用于更新记录和删除记录
        private string sql_backup = string.Empty;//存储搜索的sql语句，用于更新记录和删除记录之后的DataGridView控件内的数据更新

        private void frmAchievementSearchComplex_Load(object sender, EventArgs e)//窗体载入时初始化
        {
            txt_achievement_name = string.Empty;
            sql_backup = string.Empty;
            btnUpdate.Enabled = false;//更新此项成果按钮不可点击
            btnDelete.Enabled = false;//删除此项成果按钮不可点击
            btnOutToFile.Text = "导出此检索结果到文件";//导出此检索结果到文件按钮显示内容
            btnOutToFile.Enabled = false;//导出此检索结果到文件按钮不可点击
            dgvData.DataSource = null;//DataGridView控件显示数据
            this.dgvData.AllowUserToAddRows = false;//不允许用户添加新行
            this.cboLogic.SelectedIndex = 0;//逻辑选择combox默认选中第一个逻辑(or)
            cbAchievementDate.Checked = false;//成果时间不限制不选中
            cbAchievementMoney.Checked = false;//支撑基金不限制不选中
            this.dtpAchievementDate.Enabled = true;//成果时间DateTimePacker选择控件可用
            this.txtAchievementMoney.Enabled = true;//支撑基金输入控件可用

            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)//单击单元格的任意部分
        {
            int index = this.dgvData.CurrentCell.RowIndex;//获取当前鼠标单击时的行索引号
            if (index >= 0)
            {
                this.txt_achievement_name = MyDatabase.CharFilter(this.dgvData.Rows[index].Cells[0].Value.ToString().Trim());
                if (txt_achievement_name != string.Empty)
                {
                    btnUpdate.Enabled = true;//更新此项成果按钮可点击
                    btnDelete.Enabled = true;//删除此项成果按钮可点击
                    btnOutToFile.Text = "导出此检索结果到文件";//导出此检索结果到文件按钮显示内容
                    btnOutToFile.Enabled = true;//导出此检索结果到文件按钮可点击
                }
                else
                {
                    btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                    btnDelete.Enabled = false;//删除此项成果按钮不可点击
                    btnOutToFile.Text = "导出此检索结果到文件";//导出此检索结果到文件按钮显示内容
                    btnOutToFile.Enabled = false;//导出此检索结果到文件按钮不可点击
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)//检索
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            if (cbAchievementMoney.Checked == false)//支撑基金不限制未选中
            {
                if (txtAchievementMoney.Text.ToString().Trim() == string.Empty)//支撑基金为空
                {
                    MessageBox.Show("如果检索不打算限制支撑基金，请将支撑基金后面的不限制选中，否则请输入支撑基金，支撑基金不能为空！", "提示");
                    return;
                }
                try//对支撑基金数据格式进行校检
                {
                    Convert.ToDouble(MyDatabase.CharFilter(this.txtAchievementMoney.Text.ToString().Trim()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("支撑基金信息输入格式有误，请重新检查之后再重试！", "提示");
                    //MessageBox.Show(ex.Message);
                    //throw new Exception(ex.Message);
                    return;
                }
            }
            if (cbAchievementDate.Checked == false)//成果时间不限制未选中
            {
                try//对成果时间数据格式进行校检
                {
                    Convert.ToDateTime(this.dtpAchievementDate.Text.ToString().Trim()).ToString("yyyy-MM-dd");//最后加入ToString("yyyy-MM-dd")是为了去除时间只留下日期
                }
                catch (Exception ex)
                {
                    MessageBox.Show("时间信息输入格式有误，请重新检查之后再重试！", "提示");
                    //MessageBox.Show(ex.Message);
                    //throw new Exception(ex.Message);
                    return;
                }
            }
            string sql_result = string.Empty;//最终搜索的sql语句
            string sql_temp = string.Empty;//生成最终搜索sql语句过程中的临时sql语句字符串变量
            sql_result = "select datainfo.AchievementName as '成果名称', datainfo.AchievementType as '成果类型', datainfo.AchievementDate as '时间', datainfo.AchievementAuthor as '作者', datainfo.AchievementCompany as '单位', datainfo.AchievementMoney as '支撑基金' from datainfo where";
            sql_temp = string.Format(" AchievementName like '%{0}%' ",MyDatabase.CharFilter(this.txtAchievementName.Text.ToString().Trim()));
            sql_result = sql_result + sql_temp + this.cboLogic.SelectedItem.ToString().Trim();
            sql_temp = string.Format(" AchievementType like '%{0}%' ", MyDatabase.CharFilter(this.txtAchievementType.Text.ToString().Trim()));
            sql_result = sql_result + sql_temp + this.cboLogic.SelectedItem.ToString().Trim();
            if (cbAchievementDate.Checked == false)//成果时间不限制未选中
            {
                sql_temp = string.Format(" AchievementDate like '%{0}%' ", Convert.ToDateTime(this.dtpAchievementDate.Text.ToString().Trim()).ToString("yyyy-MM-dd"));
                sql_result = sql_result + sql_temp + this.cboLogic.SelectedItem.ToString().Trim();
            }
            sql_temp = string.Format(" AchievementAuthor like '%{0}%' ", MyDatabase.CharFilter(this.txtAchievementAuthor.Text.ToString().Trim()));
            sql_result = sql_result + sql_temp + this.cboLogic.SelectedItem.ToString().Trim();
            sql_temp = string.Format(" AchievementCompany like '%{0}%'", MyDatabase.CharFilter(this.txtAchievementCompany.Text.ToString().Trim()));
            sql_result = sql_result + sql_temp;
            if (cbAchievementMoney.Checked == false)//支撑基金不限制未选中
            {
                sql_result = sql_result + " " + this.cboLogic.SelectedItem.ToString().Trim();
                sql_temp = string.Format(" (AchievementMoney between {0} and {1})", Convert.ToDouble(MyDatabase.CharFilter(this.txtAchievementMoney.Text.ToString().Trim())) - 0.01, Convert.ToDouble(MyDatabase.CharFilter(this.txtAchievementMoney.Text.ToString().Trim())) + 0.01);
                sql_result = sql_result + sql_temp;
            }
            sql_result = sql_result + ";";
            try
            {
                DataTable dt = MyDatabase.GetDataTableBySql(sql_result);
                if (dt == null)//数据库连接失败
                {
                    btnDelete.Enabled = false;//删除此项成果按钮不可点击
                    btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                    btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                    btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                    txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                    sql_backup = string.Empty;
                    this.dgvData.DataSource = null;//DataGridView控件显示数据
                    MessageBox.Show("数据库连接失败！", "提示");
                    return;
                }
                if (dt.Rows.Count == 0)//未检索到符合要求的成果信息
                {
                    btnDelete.Enabled = false;//删除此项成果按钮不可点击
                    btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                    btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                    btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                    txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                    sql_backup = string.Empty;
                    this.dgvData.DataSource = null;//DataGridView控件显示数据
                    MessageBox.Show("未检索到符合要求的成果信息！", "提示");
                    return;
                }
                btnDelete.Enabled = true;//删除此项成果按钮可点击
                btnUpdate.Enabled = true;//更新此项成果按钮可点击
                btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                btnOutToFile.Enabled = true;//导出此检索成果到文件按钮可点击
                this.dgvData.DataSource = null;//先置为null，否则在右键删除DataGridView后再次检索后显示的字段顺序会有误
                this.dgvData.DataSource = dt;//DataGridView控件显示数据
                this.txt_achievement_name = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[0].Value.ToString().Trim());
                sql_backup = sql_result;
                MessageBox.Show("检索成功！", "提示");
                return;
            }
            catch (Exception ex)
            {
                btnDelete.Enabled = false;//删除此项成果按钮不可点击
                btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                sql_backup = string.Empty;
                this.dgvData.DataSource = null;//DataGridView控件显示数据
                MessageBox.Show("检索失败！", "提示");
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)//更新此项成果
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            frmAchievementUpdate achievement_update = new frmAchievementUpdate(txt_achievement_name);//实例化成果更新窗体
            achievement_update.ShowDialog();//成果更新窗体以模式对话框的方式打开

            #region 更新DataGridView控件内的内容
            try
            {
                DataTable dt = MyDatabase.GetDataTableBySql(sql_backup);
                if (dt == null)//数据库连接失败
                {
                    btnDelete.Enabled = false;//删除此项成果按钮不可点击
                    btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                    btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                    btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                    txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                    sql_backup = string.Empty;
                    this.dgvData.DataSource = null;//DataGridView控件显示数据
                    MessageBox.Show("数据库连接失败！", "提示");
                    return;
                }
                if (dt.Rows.Count == 0)//未检索到符合要求的成果信息
                {
                    btnDelete.Enabled = false;//删除此项成果按钮不可点击
                    btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                    btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                    btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                    txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                    sql_backup = string.Empty;
                    this.dgvData.DataSource = null;//DataGridView控件显示数据
                    return;
                }
                btnDelete.Enabled = true;//删除此项成果按钮可点击
                btnUpdate.Enabled = true;//更新此项成果按钮可点击
                btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                btnOutToFile.Enabled = true;//导出此检索成果到文件按钮可点击
                this.dgvData.DataSource = null;//先置为null，否则在右键删除DataGridView后再次检索后显示的字段顺序会有误
                this.dgvData.DataSource = dt;//DataGridView控件显示数据
                this.txt_achievement_name = this.dgvData.Rows[0].Cells[0].Value.ToString().Trim();
                return;
            }
            catch (Exception ex)
            {
                btnDelete.Enabled = false;//删除此项成果按钮不可点击
                btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                sql_backup = string.Empty;
                this.dgvData.DataSource = null;//DataGridView控件显示数据
                return;
            }
            #endregion
        }

        private void btnDelete_Click(object sender, EventArgs e)//删除此项成果
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            DialogResult result = MessageBox.Show("是否确定删除此项成果？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)//确定
            {
                if (txt_achievement_name != string.Empty)
                {
                    string sql_1 = string.Format("delete from datainfo where datainfo.AchievementName='{0}';", txt_achievement_name);//sql语句
                    if (MyDatabase.UpdateDataBySql(sql_1))//删除成功
                    {
                        #region 更新DataGridView控件内的内容
                        try
                        {
                            DataTable dt = MyDatabase.GetDataTableBySql(sql_backup);
                            if (dt == null)//数据库连接失败
                            {
                                btnDelete.Enabled = false;//删除此项成果按钮不可点击
                                btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                                btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                                btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                                txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                                sql_backup = string.Empty;
                                this.dgvData.DataSource = null;//DataGridView控件显示数据
                                MessageBox.Show("数据库连接失败！", "提示");
                                return;
                            }
                            if (dt.Rows.Count == 0)//未检索到符合要求的成果信息
                            {
                                btnDelete.Enabled = false;//删除此项成果按钮不可点击
                                btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                                btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                                btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                                txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                                sql_backup = string.Empty;
                                this.dgvData.DataSource = null;//DataGridView控件显示数据
                                return;
                            }
                            btnDelete.Enabled = true;//删除此项成果按钮可点击
                            btnUpdate.Enabled = true;//更新此项成果按钮可点击
                            btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                            btnOutToFile.Enabled = true;//导出此检索成果到文件按钮可点击
                            this.dgvData.DataSource = null;//先置为null，否则在右键删除DataGridView后再次检索后显示的字段顺序会有误
                            this.dgvData.DataSource = dt;//DataGridView控件显示数据
                            this.txt_achievement_name = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[0].Value.ToString().Trim());
                            return;
                        }
                        catch (Exception ex)
                        {
                            btnDelete.Enabled = false;//删除此项成果按钮不可点击
                            btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                            btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                            btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                            txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                            sql_backup = string.Empty;
                            this.dgvData.DataSource = null;//DataGridView控件显示数据
                            return;
                        }
                        #endregion
                    }
                }
                MessageBox.Show("删除失败！", "提示");
                return;
            }
            else//取消
            {
                return;
            }
        }

        private void btnOutToFile_Click(object sender, EventArgs e)//导出此检索结果到文件
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            if (txt_achievement_name != string.Empty)
            {
                try
                {
                    DataTable dt = MyExcel.GetDgvToTable(dgvData);
                    this.sfdOutToFile.Filter = "Excel 工作簿(*.xlsx)|*.xlsx|文本文档(*.txt)|*.txt";//设置保存类型
                    this.sfdOutToFile.AddExtension = true;//自动添加扩展名
                    DialogResult result = this.sfdOutToFile.ShowDialog();
                    if (result == DialogResult.OK)//点击了保存
                    {
                        btnOutToFile.Text = "正在导出中。。。";//导出此检索成果到文件按钮显示内容
                        btnOutToFile.Enabled = false;//导出此检索成果到文件按钮显示不可点击
                        if (MyData.DataConvert(dt) == false)//对dt内的数据进行单独处理，去除时间(默认值00:00:00)，只保留日期
                        {
                            btnOutToFile.Text = "导出此检索成果到文件";//设置导出此检索成果到文件按钮显示内容
                            btnOutToFile.Enabled = true;//设置导出此检索成果到文件按钮显示可点击
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
                            btnOutToFile.Text = "导出此检索成果到文件";//设置导出此检索成果到文件按钮显示内容
                            btnOutToFile.Enabled = true;//设置导出此检索成果到文件按钮显示可点击
                            MessageBox.Show("导出类型为不支持的类型，导出失败！", "提示");
                            return;
                        }
                        btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                        btnOutToFile.Enabled = true;//导出此检索成果到文件按钮显示可点击
                        MessageBox.Show("导出成功！", "提示");
                        return;
                    }
                    else if (result == DialogResult.Cancel)//点击了取消
                    {
                        btnOutToFile.Text = "导出此检索成果到文件";//设置导出此检索成果到文件按钮显示内容
                        btnOutToFile.Enabled = true;//设置导出此检索成果到文件按钮显示可点击
                        return;
                    }
                }
                catch (Exception ex)
                {
                    btnOutToFile.Text = "导出此检索成果到文件";//设置导出此检索成果到文件按钮显示内容
                    btnOutToFile.Enabled = true;//设置导出此检索成果到文件按钮显示可点击
                    MessageBox.Show("导出失败！", "提示");
                    return;
                }
            }
            btnOutToFile.Text = "导出此检索成果到文件";//设置导出此检索成果到文件按钮显示内容
            btnOutToFile.Enabled = true;//设置导出此检索成果到文件按钮显示可点击
            MessageBox.Show("导出失败！", "提示");
        }

        private void btnExit_Click(object sender, EventArgs e)//退出
        {
            this.Close();//关闭窗体
        }

        private void cbAchievementDate_CheckedChanged(object sender, EventArgs e)//时间不限制checkbox复选框改变
        {
            if (cbAchievementDate.Checked == true)//不限制选中
            {
                this.dtpAchievementDate.Enabled = false;
            }
            else//不限制未选中
            {
                this.dtpAchievementDate.Enabled = true;
            }
        }

        private void cbAchievementMoney_CheckedChanged(object sender, EventArgs e)//支撑基金不限制checkbox复选框改变
        {
            if (cbAchievementMoney.Checked == true)//不限制选中
            {
                this.txtAchievementMoney.Enabled = false;
            }
            else//不限制未选中
            {
                this.txtAchievementMoney.Enabled = true;
            }
        }
    }
}
