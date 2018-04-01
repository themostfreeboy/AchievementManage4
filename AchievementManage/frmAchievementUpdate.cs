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
    public partial class frmAchievementUpdate : Form
    {
        public frmAchievementUpdate()
        {
            InitializeComponent();
        }

        public frmAchievementUpdate(string txt_achievement_name_in)//自定义构造函数
        {
            InitializeComponent();
            this.txt_achievement_name = txt_achievement_name_in;
        }

        private string txt_achievement_name = string.Empty;//存储数据库内的主键的值，用于更新记录和删除记录

        private void frmAchievementUpdate_Load(object sender, EventArgs e)//窗体载入时初始化
        {
            btnOutToFile.Enabled = true;//导出此项结果到文件按钮可点击
            btnOutToFile.Text = "导出此项结果到文件";//导出此项结果到文件按钮显示内容
            this.dgvData.AllowUserToAddRows = false;//不允许用户添加新行
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                btnOutToFile.Enabled = false;//导出此项结果到文件按钮不可点击
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            try
            {
                string sql = string.Format("select datainfo.AchievementName as '成果名称', datainfo.AchievementType as '成果类型', datainfo.AchievementDate as '时间', datainfo.AchievementAuthor as '作者', datainfo.AchievementCompany as '单位', datainfo.AchievementMoney as '支撑基金' from datainfo where AchievementName='{0}';", txt_achievement_name);
                DataTable dt = MyDatabase.GetDataTableBySql(sql);
                if (dt == null)//数据库连接失败
                {
                    btnOutToFile.Enabled = false;//导出此项结果到文件按钮不可点击
                    btnOutToFile.Text = "导出此项结果到文件";//导出此项结果到文件按钮显示内容
                    this.dgvData.DataSource = null;//DataGridView控件显示数据
                    MessageBox.Show("数据库连接失败！", "提示");
                    return;
                }
                this.dgvData.DataSource = null;//先置为null，否则在右键删除DataGridView后再次检索后显示的字段顺序会有误
                this.dgvData.DataSource = dt;//DataGridView控件显示数据
                txtAchievementName.Text = txt_achievement_name;
                txtAchievementType.Text = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[1].Value.ToString().Trim());
                dtpAchievementDate.Text = this.dgvData.Rows[0].Cells[2].Value.ToString().Trim();
                txtAchievementAuthor.Text = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[3].Value.ToString().Trim());
                txtAchievementCompany.Text = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[4].Value.ToString().Trim());
                txtAchievementMoney.Text = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[5].Value.ToString().Trim());
                return;
            }
            catch (Exception ex)
            {
                btnOutToFile.Enabled = false;//导出此项结果到文件按钮不可点击
                btnOutToFile.Text = "导出此项结果到文件";//导出此项结果到文件按钮显示内容
                this.dgvData.DataSource = null;//DataGridView控件显示数据
                MessageBox.Show("更新界面初始化失败！", "提示");
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)//更新
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            if (this.txtAchievementName.Text.ToString().Trim() == string.Empty || this.txtAchievementType.Text.ToString().Trim() == string.Empty || this.dtpAchievementDate.Text.ToString().Trim() == string.Empty || this.txtAchievementAuthor.Text.ToString().Trim() == string.Empty || this.txtAchievementCompany.Text.ToString().Trim() == string.Empty || this.txtAchievementMoney.Text.ToString().Trim() == string.Empty)//是否所有数据均未改动检测
            {
                MessageBox.Show("信息输入不完整，请重新检查之后再重试！", "提示");
                return;
            }
            try//对成果时间和成果支撑基金的数据格式进行检测(如数据有误会throw异常，程序进入catch捕捉代码中)
            {
                Convert.ToDateTime(MyDatabase.CharFilter(this.dtpAchievementDate.Text.ToString().Trim()));
                Convert.ToDouble(MyDatabase.CharFilter(this.txtAchievementMoney.Text.ToString().Trim()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("信息输入格式有误，请重新检查之后再重试！", "提示");
                //throw new Exception(ex.Message);
                return;
            }
            //所有数据的合法性均检测完毕
            string sql_1 = string.Format("update datainfo set AchievementName='{0}', AchievementType='{1}', AchievementDate='{2}', AchievementAuthor='{3}', AchievementCompany='{4}', AchievementMoney={5} where AchievementName='{6}';", MyDatabase.CharFilter(this.txtAchievementName.Text.ToString().Trim()), MyDatabase.CharFilter(this.txtAchievementType.Text.ToString().Trim()), Convert.ToDateTime(MyDatabase.CharFilter(this.dtpAchievementDate.Text.ToString().Trim())), MyDatabase.CharFilter(this.txtAchievementAuthor.Text.ToString().Trim()), MyDatabase.CharFilter(this.txtAchievementCompany.Text.ToString().Trim()), Convert.ToDouble(MyDatabase.CharFilter(this.txtAchievementMoney.Text.ToString().Trim())), txt_achievement_name);//sql语句
            if (MyDatabase.UpdateDataBySql(sql_1))//更新成功
            {
                //更新DataGridView控件内的内容
                txt_achievement_name = MyDatabase.CharFilter(this.txtAchievementName.Text.ToString().Trim());
                string sql_2 = string.Format("select datainfo.AchievementName as '成果名称', datainfo.AchievementType as '成果类型', datainfo.AchievementDate as '时间', datainfo.AchievementAuthor as '作者', datainfo.AchievementCompany as '单位', datainfo.AchievementMoney as '支撑基金' from datainfo where AchievementName='{0}';", txt_achievement_name);
                DataTable dt = MyDatabase.GetDataTableBySql(sql_2);
                if (dt == null)//数据库连接失败
                {
                    MessageBox.Show("数据库连接失败！", "提示");
                    return;
                }
                this.dgvData.DataSource = null;//先置为null，否则在右键删除DataGridView后再次检索后显示的字段顺序会有误
                this.dgvData.DataSource = dt;//DataGridView控件显示数据
                MessageBox.Show("更新成功！", "提示");
            }
            else//更新失败
            {
                MessageBox.Show("更新失败！", "提示");
            }
        }

        private void btnOutToFile_Click(object sender, EventArgs e)//导出此项成果到文件
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
                        btnOutToFile.Text = "正在导出中。。。";//导出此项成果到文件按钮显示内容
                        btnOutToFile.Enabled = false;//导出此项成果到文件按钮显示不可点击
                        if (MyData.DataConvert(dt) == false)//对dt内的数据进行单独处理，去除时间(默认值00:00:00)，只保留日期
                        {
                            btnOutToFile.Text = "导出此项成果到文件";//设置导出此项成果到文件按钮显示内容
                            btnOutToFile.Enabled = true;//设置导出此项成果到文件按钮显示可点击
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
                        btnOutToFile.Text = "导出此项成果到文件";//导出此项成果到文件按钮显示内容
                        btnOutToFile.Enabled = true;//导出此项成果到文件按钮显示可点击
                        MessageBox.Show("导出成功！", "提示");
                        return;
                    }
                    else if (result == DialogResult.Cancel)//点击了取消
                    {
                        btnOutToFile.Text = "导出此项成果到文件";//设置导出此项成果到文件按钮显示内容
                        btnOutToFile.Enabled = true;//设置导出此项成果到文件按钮显示可点击
                        return;
                    }
                }
                catch (Exception ex)
                {
                    btnOutToFile.Text = "导出此项成果到文件";//设置导出此项成果到文件按钮显示内容
                    btnOutToFile.Enabled = true;//设置导出此项成果到文件按钮显示可点击
                    MessageBox.Show("导出失败！", "提示");
                    return;
                }
            }
            btnOutToFile.Text = "导出此项成果到文件";//设置导出此项成果到文件按钮显示内容
            btnOutToFile.Enabled = true;//设置导出此项成果到文件按钮显示可点击
            MessageBox.Show("导出失败！", "提示");
        }

        private void btnExit_Click(object sender, EventArgs e)//退出
        {
            this.Close();//关闭窗体
        }
    }
}
