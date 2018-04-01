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
    public partial class frmAchievementSearchEasy : Form
    {
        public frmAchievementSearchEasy()
        {
            InitializeComponent();
        }

        private string txt_achievement_name = string.Empty;//存储数据库内的主键的值，用于更新记录和删除记录
        private string txt_achievement_type = string.Empty;//存储数据库内的成果类型的值，用于更新记录和删除记录之后的更新DataGridView控件内的数据

        private void frmAchievementSearchEasy_Load(object sender, EventArgs e)//窗体载入时初始化
        {
            txt_achievement_name = string.Empty;
            txt_achievement_type = string.Empty;
            btnUpdate.Enabled = false;//更新此项成果按钮不可点击
            btnDelete.Enabled = false;//删除此项成果按钮不可点击
            btnOutToFile.Text = "导出此检索结果到文件";//导出此检索结果到文件按钮显示内容
            btnOutToFile.Enabled = false;//导出此检索结果到文件按钮不可点击
            dgvData.DataSource = null;//DataGridView控件显示数据
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
                try//检测数据库中是否没有任何成果类型
                {
                    this.cboAchievementType.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无任何成果类型，无法检索！", "提示");
                    return;
                }
            }
            catch (Exception ex)//数据库可能连接不上，MyDatabase.GetDataSetBySql函数会出错，返回的DataSet值为null，导致下面引用DataSet具体值时会抛出异常(后经改进在DataSet具体值使用之前加入了值是否为null的判断，后又经过改进在每次事件处理前均加入了检测能否成功连接的函数)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)//单击单元格的任意部分
        {
            int index = this.dgvData.CurrentCell.RowIndex;//获取当前鼠标单击时的行索引号
            if (index >= 0)
            {
                this.txt_achievement_name = MyDatabase.CharFilter(this.dgvData.Rows[index].Cells[0].Value.ToString().Trim());
                this.txt_achievement_type = MyDatabase.CharFilter(this.dgvData.Rows[index].Cells[1].Value.ToString().Trim());
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
            try//防止将所有成果类型均删除后，成果类型为空时检索，会导致未引用的异常
            {
                if (this.cboAchievementType.SelectedItem.ToString() == string.Empty)
                {
                    MessageBox.Show("成果类型选择有误", "提示");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("无任何待检索成果类型，检索失败！", "提示");
                return;
            }
            try
            {
                string sql = string.Format("select datainfo.AchievementName as '成果名称', datainfo.AchievementType as '成果类型', datainfo.AchievementDate as '时间', datainfo.AchievementAuthor as '作者', datainfo.AchievementCompany as '单位', datainfo.AchievementMoney as '支撑基金' from datainfo where AchievementType='{0}';", MyDatabase.CharFilter(this.cboAchievementType.SelectedItem.ToString().Trim()));
                DataTable dt = MyDatabase.GetDataTableBySql(sql);
                if (dt == null)//数据库连接失败
                {
                    btnDelete.Enabled = false;//删除此项成果按钮不可点击
                    btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                    btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                    btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                    txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                    txt_achievement_type = string.Empty;
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
                    txt_achievement_type = string.Empty;
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
                this.txt_achievement_type = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[1].Value.ToString().Trim());
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
                txt_achievement_type = string.Empty;
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
            #region 成果类型组合框更新
            if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
            {
                MessageBox.Show("数据库连接失败！", "提示");
                return;
            }
            try
            {
                this.cboAchievementType.Items.Clear();//清空combox内所有选项
                DataTable dt_1 = MyDatabase.GetDataTableBySql("select distinct AchievementType from datainfo;");
                if (dt_1.Rows.Count == 0)//数据库中已无任何成果类型
                {
                    btnDelete.Enabled = false;//删除此项成果按钮不可点击
                    btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                    btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                    btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                    txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                    txt_achievement_type = string.Empty;
                    this.dgvData.DataSource = null;//DataGridView控件显示数据
                    return;
                }
                for (int i = 0; i < dt_1.Rows.Count; i++)
                {
                    this.cboAchievementType.Items.Add(MyDatabase.CharFilter(dt_1.Rows[i][0].ToString().Trim()));
                }
                bool checkresult = false;
                for (int i = 0; i < this.cboAchievementType.Items.Count; i++)
                {
                    if (string.Compare(cboAchievementType.GetItemText(cboAchievementType.Items[i]), txt_achievement_type) == 0)//成果类型combox中还有之前的成果类型
                    {
                        this.cboAchievementType.SelectedIndex = i;
                        checkresult = true;
                        break;
                    }
                }
                if (checkresult == false)//成果类型combox中已无之前的成果类型
                {
                    this.cboAchievementType.SelectedIndex = 0;
                    btnDelete.Enabled = false;//删除此项成果按钮不可点击
                    btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                    btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                    btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                    txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                    txt_achievement_type = string.Empty;
                    dgvData.DataSource = null;
                    return;
                }
            }
            catch (Exception ex)//数据库可能连接不上，MyDatabase.GetDataSetBySql函数会出错，返回的DataSet值为null，导致下面引用DataSet具体值时会抛出异常(后经改进在DataSet具体值使用之前加入了值是否为null的判断，后又经过改进在每次事件处理前均加入了检测能否成功连接的函数)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion

            #region DataGridView控件内容更新
            try
            {
                string sql_2 = string.Format("select datainfo.AchievementName as '成果名称', datainfo.AchievementType as '成果类型', datainfo.AchievementDate as '时间', datainfo.AchievementAuthor as '作者', datainfo.AchievementCompany as '单位', datainfo.AchievementMoney as '支撑基金' from datainfo where AchievementType='{0}';", txt_achievement_type);
                DataTable dt_2 = MyDatabase.GetDataTableBySql(sql_2);
                this.dgvData.DataSource = dt_2;//DataGridView控件显示数据
                txt_achievement_name = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[0].Value.ToString().Trim());
                txt_achievement_type = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[1].Value.ToString().Trim());
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据更新出错！");
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
                        //更新删除后DataGridView控件内的数据
                        try
                        {
                            string sql_2 = string.Format("select datainfo.AchievementName as '成果名称', datainfo.AchievementType as '成果类型', datainfo.AchievementDate as '时间', datainfo.AchievementAuthor as '作者', datainfo.AchievementCompany as '单位', datainfo.AchievementMoney as '支撑基金' from datainfo where AchievementType='{0}';", txt_achievement_type);
                            DataTable dt_2 = MyDatabase.GetDataTableBySql(sql_2);
                            if (dt_2.Rows.Count == 0)//删除此条成果后数据库中已无此成果类型的成果
                            {
                                btnDelete.Enabled = false;//删除此项成果按钮不可点击
                                btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                                btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                                btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                                txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                                txt_achievement_type = string.Empty;
                                this.dgvData.DataSource = null;//DataGridView控件显示数据

                                #region 成果类型组合框更新
                                if (MyDatabase.TestMyDatabaseConnect() == false)//数据库连接失败
                                {
                                    MessageBox.Show("数据库连接失败！", "提示");
                                    return;
                                }
                                try
                                {
                                    this.cboAchievementType.Items.Clear();//清空combox内所有选项
                                    DataTable dt_3 = MyDatabase.GetDataTableBySql("select distinct AchievementType from datainfo;");
                                    if (dt_3.Rows.Count == 0)//删除此条成果后数据库中已无其他成果类型
                                    {
                                        btnDelete.Enabled = false;//删除此项成果按钮不可点击
                                        btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                                        btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                                        btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                                        txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                                        txt_achievement_type = string.Empty;
                                        this.dgvData.DataSource = null;//DataGridView控件显示数据
                                        MessageBox.Show("删除成功！", "提示");
                                        return;
                                    }
                                    for (int i = 0; i < dt_3.Rows.Count; i++)
                                    {
                                        this.cboAchievementType.Items.Add(MyDatabase.CharFilter(dt_3.Rows[i][0].ToString().Trim()));
                                    }
                                    this.cboAchievementType.SelectedIndex = 0;
                                }
                                catch (Exception ex)//数据库可能连接不上，MyDatabase.GetDataSetBySql函数会出错，返回的DataSet值为null，导致下面引用DataSet具体值时会抛出异常(后经改进在DataSet具体值使用之前加入了值是否为null的判断，后又经过改进在每次事件处理前均加入了检测能否成功连接的函数)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                #endregion
                                MessageBox.Show("删除成功！", "提示");
                                return;
                            }
                            btnDelete.Enabled = true;//删除此项成果按钮可点击
                            btnUpdate.Enabled = true;//更新此项成果按钮可点击
                            btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                            btnOutToFile.Enabled = true;//导出此检索成果到文件按钮可点击
                            this.dgvData.DataSource = null;//先置为null，否则在右键删除DataGridView后再次检索后显示的字段顺序会有误
                            this.dgvData.DataSource = dt_2;//DataGridView控件显示数据
                            txt_achievement_name = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[0].Value.ToString().Trim());
                            txt_achievement_type = MyDatabase.CharFilter(this.dgvData.Rows[0].Cells[1].Value.ToString().Trim());
                            MessageBox.Show("删除成功！", "提示");
                            return;
                        }
                        catch (Exception ex)
                        {
                            btnDelete.Enabled = false;//删除此项成果按钮不可点击
                            btnUpdate.Enabled = false;//更新此项成果按钮不可点击
                            btnOutToFile.Text = "导出此检索成果到文件";//导出此检索成果到文件按钮显示内容
                            btnOutToFile.Enabled = false;//导出此检索成果到文件按钮不可点击
                            txt_achievement_name = string.Empty;//记录数据库内主键的值为空
                            txt_achievement_type = string.Empty;
                            this.dgvData.DataSource = null;//DataGridView控件显示数据
                            MessageBox.Show("删除失败！", "提示");
                            return;
                        }
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
    }
}
