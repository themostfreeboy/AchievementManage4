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
    public partial class frmConnectToServer : Form
    {
        frmMain frm_main;

        public frmConnectToServer(frmMain frmmain)
        {
            InitializeComponent();
            frm_main = frmmain;
        }

        private void frmConnectToServer_Load(object sender, EventArgs e)//窗体载入时初始化
        {
            this.cboServer.Items.Clear();//清空combox内所有选项
            this.cboServer.Items.Add("本地服务器");
            this.cboServer.Items.Add("远程服务器");
            this.cboServer.SelectedIndex = 0;
            txtServer.Text = "127.0.0.1";
            txtServer.ReadOnly = true;
            txtPort.Text = "3306";
            txtDatabase.Text = "achievementmanage";
            txtUid.Text = "root";
            txtPwd.Text = "123456";
            btnSaveAndTest.Text = "保存此配置并测试连接";//保存此配置并测试连接按钮显示内容
            btnSaveAndTest.Enabled = true;//保存此配置并测试连接按钮可点击
        }

        private void cboServer_SelectedIndexChanged(object sender, EventArgs e)//combox内容变化时
        {
            if (string.Compare(this.cboServer.SelectedItem.ToString(), "本地服务器") == 0)
            {
                txtServer.Text = "127.0.0.1";
                txtServer.ReadOnly = true;
                return;
            }
            else if (string.Compare(this.cboServer.SelectedItem.ToString(), "远程服务器") == 0)
            {
                txtServer.Text = "(请输入远程服务器ip)";
                txtServer.ReadOnly = false;
                return;
            }
            else
            {
                MessageBox.Show("选项选择出错！");
                txtServer.ReadOnly = false;
                return;
            }
        }

        private void btnSaveAndTest_Click(object sender, EventArgs e)//保存此配置并测试连接
        {
            try
            {
                btnSaveAndTest.Text = "正在测试连接。。。";//保存此配置并测试连接按钮显示内容
                btnSaveAndTest.Enabled = false;//保存此配置并测试连接按钮不可点击
                MyDatabase.SetServer(txtServer.Text.Trim());
                MyDatabase.SetPort(txtPort.Text.Trim());
                MyDatabase.SetDatabase(txtDatabase.Text.Trim());
                MyDatabase.SetUid(txtUid.Text.Trim());
                MyDatabase.SetPwd(txtPwd.Text.Trim());
                if (MyDatabase.TestMyDatabaseConnect() == true)
                {
                    frm_main.tsmniAchievementManage.Enabled = true;//成果管理可点击
                    frm_main.tsmniMechanicalDrawing.Enabled = true;//机械图管理可点击
                    btnSaveAndTest.Text = "保存此配置并测试连接";//保存此配置并测试连接按钮显示内容
                    btnSaveAndTest.Enabled = true;//保存此配置并测试连接按钮可点击
                    MessageBox.Show("数据库连接成功！\n此配置已保存！");
                    this.Close();//关闭窗体
                }
                else
                {
                    frm_main.tsmniAchievementManage.Enabled = false;//成果管理不可点击
                    frm_main.tsmniMechanicalDrawing.Enabled = false;//机械图管理不可点击
                    btnSaveAndTest.Text = "保存此配置并测试连接";//保存此配置并测试连接按钮显示内容
                    btnSaveAndTest.Enabled = true;//保存此配置并测试连接按钮可点击
                    MessageBox.Show("数据库连接失败！\n请重新修改配置信息！");
                    return;
                }
            }
            catch (Exception ex)
            {
                frm_main.tsmniAchievementManage.Enabled = false;//成果管理不可点击
                frm_main.tsmniMechanicalDrawing.Enabled = false;//机械图管理不可点击
                btnSaveAndTest.Text = "保存此配置并测试连接";//保存此配置并测试连接按钮显示内容
                btnSaveAndTest.Enabled = true;//保存此配置并测试连接按钮可点击
                //MessageBox.Show(ex.Message);
                //throw new Exception(ex.Message);
                MessageBox.Show("数据库连接失败！\n请重新修改配置信息！");
                return;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)//恢复默认值
        {
            this.cboServer.Items.Clear();//清空combox内所有选项
            this.cboServer.Items.Add("本地服务器");
            this.cboServer.Items.Add("远程服务器");
            this.cboServer.SelectedIndex = 0;
            txtServer.Text = "127.0.0.1";
            txtServer.ReadOnly = true;
            txtPort.Text = "3306";
            txtDatabase.Text = "achievementmanage";
            txtUid.Text = "root";
            txtPwd.Text = "123456";
        }

        private void btnExit_Click(object sender, EventArgs e)//退出
        {
            this.Close();//关闭窗体
        }
    }
}
