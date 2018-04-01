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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)//窗体载入时初始化
        {
            this.tsmniAchievementManage.Enabled = false;//成果管理不可点击
            this.tsmniMechanicalDrawing.Enabled = false;//机械图管理不可点击
        }

        private bool checkchildfrm(string childfrmname)//查询子窗体是否存在
        {
            foreach (Form childFrm in this.MdiChildren)//遍历子窗体
            {
                if (childFrm.Name == childfrmname)//判断子窗体的名称
                {
                    if (childFrm.WindowState == FormWindowState.Minimized)//如果子窗体处于最小化的状态
                    {
                        childFrm.WindowState = FormWindowState.Normal;//恢复正常显示
                    }
                    childFrm.Activate();//激活窗体
                    return true;//返回真值
                }
            }
            return false;//返回假值
        }

        private void tsmniConnectToServer_Click(object sender, EventArgs e)//连接服务器
        {
            if (this.checkchildfrm("frmConnectToServer") == true)//检测该窗体是否处于打开状态
            {
                return;//窗口已打开，返回
            }
            frmConnectToServer connect_to_server = new frmConnectToServer(this);//实例化服务器信息配置窗体
            connect_to_server.MdiParent = this;//设置为当前窗体的子窗体
            connect_to_server.Show();//实例化服务器信息配置窗体以非模式对话框的方式打开
        }

        private void tsmniAchievementAddByWrite_Click(object sender, EventArgs e)//手工输入录入信息
        {
            if (this.checkchildfrm("frmAchievementAddByWrite") == true)//检测该窗体是否处于打开状态
            {
                return;//窗口已打开，返回
            }
            frmAchievementAddByWrite achievement_addbywrite = new frmAchievementAddByWrite();//实例化成果录入(手工输入)窗体
            achievement_addbywrite.MdiParent = this;//设置为当前窗体的子窗体
            achievement_addbywrite.Show();//成果录入(手工输入)窗体窗体以非模式对话框的方式打开
        }

        private void tsmniAchievementAddByFile_Click(object sender, EventArgs e)//通过文件批量导入录入信息
        {
            if (this.checkchildfrm("frmAchievementAddByFile") == true)//检测该窗体是否处于打开状态
            {
                return;//窗口已打开，返回
            }
            frmAchievementAddByFile achievement_addbyfile = new frmAchievementAddByFile();//实例化成果录入(通过文件批量导入)窗体
            achievement_addbyfile.MdiParent = this;//设置为当前窗体的子窗体
            achievement_addbyfile.Show();//成果录入(通过文件批量导入)窗体以非模式对话框的方式打开
        }

        private void tsmniAchievementSearchEasy_Click(object sender, EventArgs e)//简单成果检索
        {
            if (this.checkchildfrm("frmAchievementSearchEasy") == true)//检测该窗体是否处于打开状态
            {
                return;//窗口已打开，返回
            }
            frmAchievementSearchEasy achievement_search_easy = new frmAchievementSearchEasy();//实例化简单成果检索窗体
            achievement_search_easy.MdiParent = this;//设置为当前窗体的子窗体
            achievement_search_easy.Show();//简单成果检索窗体以非模式对话框的方式打开
        }

        private void tsmniAchievementSearchComplex_Click(object sender, EventArgs e)//高级成果检索
        {
            if (this.checkchildfrm("frmAchievementSearchComplex") == true)//检测该窗体是否处于打开状态
            {
                return;//窗口已打开，返回
            }
            frmAchievementSearchComplex achievement_search_complex = new frmAchievementSearchComplex();//实例化高级成果检索窗体
            achievement_search_complex.MdiParent = this;//设置为当前窗体的子窗体
            achievement_search_complex.Show();//高级成果检索窗体以非模式对话框的方式打开
        }

        private void tsmniMechanicalDrawing_Click(object sender, EventArgs e)//机械图管理
        {
            if (this.checkchildfrm("frmMechanicalDrawing") == true)//检测该窗体是否处于打开状态
            {
                return;//窗口已打开，返回
            }
            frmMechanicalDrawing mechanical_drawing = new frmMechanicalDrawing();//实例化机械图管理窗体
            mechanical_drawing.MdiParent = this;//设置为当前窗体的子窗体
            mechanical_drawing.Show();//机械图管理窗体以非模式对话框的方式打开
        }

        private void tsmniExit_Click(object sender, EventArgs e)//退出
        {
            Application.Exit();//退出应用程序
        }
    }
}
