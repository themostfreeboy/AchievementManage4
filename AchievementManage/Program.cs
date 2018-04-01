using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AchievementManage
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            START:
            try
            {
                Application.Run(new frmMain());
            }
            catch (Exception ex)//对所有此程序未及时处理的异常进行捕捉，防止程序崩溃。
            {
                string string_error = string.Empty;
                string_error = "程序出错，出错原因：\n" + ex.Message + "\n是否重新启动此程序？点击\"确定\"重新启动此程序，点击\"取消\"退出此程序！";
                DialogResult result = MessageBox.Show(string_error, "程序出错", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)//确定
                {
                    goto START;
                }
                else//取消
                {
                    return;
                }
            }
        }
    }
}
