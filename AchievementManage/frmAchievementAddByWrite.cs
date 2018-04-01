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
    public partial class frmAchievementAddByWrite : Form
    {
        public frmAchievementAddByWrite()
        {
            InitializeComponent();
        }

        private string txt_achievement_name = string.Empty;//存储数据库内的主键的值，用于删除记录

        private void frmAchievementAddByWrite_Load(object sender, EventArgs e)//窗体载入时初始化
        {
            txt_achievement_name = string.Empty;
            txtAchievementType.Visible = false;//成果类型编辑框不可见
            btnDelete.Enabled = false;//删除此项成果按钮不可点击
            btnOutToFile.Text = "导出此项成果到文件";//导出此项成果到文件按钮显示内容
            btnOutToFile.Enabled = false;//导出此项成果到文件按钮不可点击
            this.dgvData.DataSource = null;//DataGridView控件显示数据
            this.dgvData.AllowUserToAddRows = false;//不允许用户添加新行

            #region 成果类型组合框初始化
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            try
            {
                DataTable dt = MyDatabase.GetDataTableBySql("select distinct AchievementType from datainfo;");
                if (dt == null)//数据库连接失败
                {
                    MessageBox.Show("数据库连接失败！", "提示");
                    return;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.cboAchievementType.Items.Add(dt.Rows[i][0].ToString().Trim());
                }
                this.cboAchievementType.Items.Add("(其他)");
                this.cboAchievementType.SelectedIndex = 0;
                //防止数据库中没有任何成果类型而使得成果类型中只有"(其他)"而使得永远无法触发cboAchievementType_SelectedIndexChanged函数使得成果类型编辑框永远不可见，所以加入以下判断代码在初始化代码中
                if (string.Compare(this.cboAchievementType.SelectedItem.ToString(), "(其他)") == 0)
                {
                    txtAchievementType.Visible = true;//成果类型编辑框可见
                }
                else
                {
                    txtAchievementType.Visible = false;//成果类型编辑框不可见
                }
            }
            catch (Exception ex)//数据库可能连接不上，MyDatabase.GetDataSetBySql函数会出错，返回的DataSet值为null，导致下面引用DataSet具体值时会抛出异常(后经改进在DataSet具体值使用之前加入了值是否为null的判断，后又经过改进在每次事件处理前均加入了检测能否成功连接的函数)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void btnAdd_Click(object sender, EventArgs e)//录入此项成果
        {
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            if (this.txtAchievementName.Text.ToString().Trim() == string.Empty || this.dtpAchievementDate.Text.ToString().Trim() == string.Empty || this.txtAchievementAuthor.Text.ToString().Trim() == string.Empty || this.txtAchievementCompany.Text.ToString().Trim() == string.Empty || this.txtAchievementMoney.Text.ToString().Trim() == string.Empty)//数据是否为空检测
            {
                MessageBox.Show("信息输入不完整，请重新检查之后再重试！", "提示");
                return;
            }
            if (string.Compare(this.cboAchievementType.SelectedItem.ToString(), "(其他)") == 0)//对成果类型数据是否为空进行单独判断
            {
                if (this.txtAchievementType.Text.ToString().Trim() == string.Empty)
                {
                    MessageBox.Show("信息输入不完整，请重新检查之后再重试！", "提示");
                    return;
                }
            }
            try//对成果时间和成果支撑基金的数据格式进行检测(如数据有误会throw异常，程序进入catch捕捉代码中)
            {
                Convert.ToDateTime(this.dtpAchievementDate.Text.ToString().Trim()).ToString("yyyy-MM-dd");//最后加入ToString("yyyy-MM-dd")是为了去除时间只留下日期
                Convert.ToDouble(MyDatabase.CharFilter(this.txtAchievementMoney.Text.ToString().Trim()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("信息输入格式有误，请重新检查之后再重试！", "提示");
                //throw new Exception(ex.Message);
                return;
            }
            //所有数据的合法性均检测完毕
            string sql_1 = string.Empty;
            if(string.Compare(this.cboAchievementType.SelectedItem.ToString(), "(其他)") == 0)//对成果类型数据进行判断
            {
                sql_1 = string.Format("insert into datainfo values('{0}', '{1}', '{2}', '{3}', '{4}', {5});", MyDatabase.CharFilter(this.txtAchievementName.Text.ToString().Trim()), MyDatabase.CharFilter(this.txtAchievementType.Text.ToString().Trim()), Convert.ToDateTime(this.dtpAchievementDate.Text.ToString().Trim()).ToString("yyyy-MM-dd"), MyDatabase.CharFilter(this.txtAchievementAuthor.Text.ToString().Trim()), MyDatabase.CharFilter(this.txtAchievementCompany.Text.ToString().Trim()), Convert.ToDouble(MyDatabase.CharFilter(this.txtAchievementMoney.Text.ToString().Trim())));//sql语句                
            }
            else
            {
                sql_1 = string.Format("insert into datainfo values('{0}', '{1}', '{2}', '{3}', '{4}', {5});", MyDatabase.CharFilter(this.txtAchievementName.Text.ToString().Trim()), MyDatabase.CharFilter(this.cboAchievementType.SelectedItem.ToString().Trim()), Convert.ToDateTime(this.dtpAchievementDate.Text.ToString().Trim()).ToString("yyyy-MM-dd"), MyDatabase.CharFilter(this.txtAchievementAuthor.Text.ToString().Trim()), MyDatabase.CharFilter(this.txtAchievementCompany.Text.ToString().Trim()), Convert.ToDouble(MyDatabase.CharFilter(this.txtAchievementMoney.Text.ToString().Trim())));//sql语句
            }
            if (MyDatabase.UpdateDataBySql(sql_1))//添加成功
            {
                btnDelete.Enabled = true;//删除此项成果按钮可点击
                btnOutToFile.Text = "导出此项成果到文件";//导出此项成果到文件按钮显示内容
                btnOutToFile.Enabled = true;//导出此项成果到文件按钮可点击
                txt_achievement_name = MyDatabase.CharFilter(this.txtAchievementName.Text.ToString().Trim());//记录数据库内主键的值
                string sql_2 = string.Format("select datainfo.AchievementName as '成果名称', datainfo.AchievementType as '成果类型', datainfo.AchievementDate as '时间', datainfo.AchievementAuthor as '作者', datainfo.AchievementCompany as '单位', datainfo.AchievementMoney as '支撑基金' from datainfo where AchievementName='{0}';", MyDatabase.CharFilter(this.txtAchievementName.Text.ToString().Trim()));
                DataTable dt = MyDatabase.GetDataTableBySql(sql_2);
                if (dt == null)//数据库连接失败
                {
                    btnDelete.Enabled = false;//删除此项成果按钮不可点击
                    btnOutToFile.Text = "导出此项成果到文件";//导出此项成果到文件按钮显示内容
                    btnOutToFile.Enabled = false;//导出此项成果到文件按钮不可点击
                    txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                    this.dgvData.DataSource = null;//DataGridView控件显示数据
                    MessageBox.Show("数据库连接失败！", "提示");
                    return;
                }
                this.dgvData.DataSource = null;//先置为null，否则在右键删除DataGridView后再次检索后显示的字段顺序会有误
                this.dgvData.DataSource = dt;//DataGridView控件显示数据
                MessageBox.Show("添加成功！", "提示");
            }
            else//添加失败
            {
                btnDelete.Enabled = false;//删除此项成果按钮不可点击
                btnOutToFile.Text = "导出此项成果到文件";//导出此项成果到文件按钮显示内容
                btnOutToFile.Enabled = false;//导出此项成果到文件按钮不可点击
                txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                this.dgvData.DataSource = null;//DataGridView控件显示数据
                MessageBox.Show("添加失败！", "提示");
            }
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
                    string sql = string.Format("delete from datainfo where datainfo.AchievementName='{0}';", txt_achievement_name);//sql语句
                    if (MyDatabase.UpdateDataBySql(sql))//删除成功
                    {
                        btnDelete.Enabled = false;//删除此项成果按钮不可点击
                        btnOutToFile.Text = "导出此项成果到文件";//导出此项成果到文件按钮显示内容
                        btnOutToFile.Enabled = false;//导出此项成果到文件按钮不可点击
                        txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                        this.dgvData.DataSource = null;//DataGridView控件显示数据
                        MessageBox.Show("删除成功！", "提示");
                        return;
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
                            btnOutToFile.Text = "导出此项成果到文件";//设置导出此检索成果到文件按钮显示内容
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

        private void cboAchievementType_SelectedIndexChanged(object sender, EventArgs e)//combox内容变化时
        {
            if (string.Compare(this.cboAchievementType.SelectedItem.ToString(), "(其他)") == 0)
            {
                txtAchievementType.Visible = true;//成果类型编辑框可见
            }
            else
            {
                txtAchievementType.Visible = false;//成果类型编辑框不可见
            }
        }
    }
}
