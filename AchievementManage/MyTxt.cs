using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;//DataColumn和DataRow需要
using System.Windows.Forms;//DataGridView需要
using System.IO;//文件读写需要

namespace AchievementManage
{
    class MyTxt:MyData//此类继承于MyData类
    {
        public static System.Data.DataTable LoadDataFromTxt(string filePath)//从指定文件路径中的Txt读取所有内容到System.Data.DataTable(txt默认编码方式为ANSI，在简体中文版Windows系统中对应于GBK编码)
        {
            try
            {
                string[] strs = File.ReadAllLines(filePath, Encoding.Default);//txt默认编码方式为ANSI，在简体中文版Windows系统中对应于GBK编码
                System.Data.DataTable dt = new System.Data.DataTable();
                for (int i = 0; i < strs.Length; i++)
                {
                    strs[i].Replace('\t', ' ');//将所有的'\t'都替换为空格
                    char[] delimiterChars = { ' ', '\t', '\r', '\n' };//分割字符串所采用的分割字符
                    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(?is)(\s+)");//使用正则表达式将多个连续的空格合并为一个空格
                    string result = regex.Replace(strs[i], " ");
                    string[] words = result.Split(delimiterChars);//使用分割字符将字符串分割
                    if (i == 0)//表标题
                    {
                        for (int j = 0; j < words.Length; j++)
                        {
                            if (words[j] != string.Empty)//防止文件每行结尾有多余的空格，多余的空格在进行分隔符等操作后会变为空字符串，导致正常列的最后多了一个空列
                            {
                                dt.Columns.Add(words[j]);
                            }
                        }
                    }
                    else//表内容
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < words.Length; j++)
                        {
                            if (words[j] != string.Empty)//防止文件每行结尾有多余的空格，多余的空格在进行分隔符等操作后会变为空字符串，导致正常列的最后多了一个空列
                            {
                                dr[j] = words[j];
                            }
                        }
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                //MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static bool SaveDataToTxt(System.Data.DataTable dt, string filePath)//将System.Data.DataTable内容存储到指定路径的Txt中(txt默认编码方式为ANSI，在简体中文版Windows系统中对应于GBK编码)
        {
            try
            {
                #region 遍历DataTable dt找出所含最大的字符的字符数，便于后面输出时制表形式的左对齐处理
                int maxbyte = 0;//遍历后所有表头字段和表中数据中最长的字符串(含中英文混合)所占的字节数
                for (int i = 0; i < dt.Columns.Count; i++)//在表头中遍历
                {
                    if (System.Text.Encoding.Default.GetByteCount(dt.Columns[i].ColumnName) > maxbyte)
                    {
                        maxbyte = System.Text.Encoding.Default.GetByteCount(dt.Columns[i].ColumnName);
                    }
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (System.Text.Encoding.Default.GetByteCount(dt.Rows[i][j].ToString()) > maxbyte)
                        {
                            maxbyte = System.Text.Encoding.Default.GetByteCount(dt.Rows[i][j].ToString());
                        }
                    }
                }
                #endregion

                string strline = string.Empty;
                System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, false, Encoding.Default);//txt默认编码方式为ANSI，在简体中文版Windows系统中对应于GBK编码
                const int distance = 4;//定义同一行中相邻两字符串的最小间距字符数(为了输出数据时制表的列对齐)

                #region 写入表头
                strline = string.Empty;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    strline = strline + dt.Columns[i].ColumnName;
                    for (int j = System.Text.Encoding.Default.GetByteCount(dt.Columns[i].ColumnName); j < maxbyte + distance; j++)
                    {
                        strline = strline + ' ';
                    }
                }
                file.WriteLine(strline);// 直接追加文件末尾，换行
                #endregion

                #region 写入表中数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strline = string.Empty;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        strline = strline + dt.Rows[i][j].ToString();
                        for (int k = System.Text.Encoding.Default.GetByteCount(dt.Rows[i][j].ToString()); k < maxbyte + distance; k++)
                        {
                            strline = strline + ' ';
                        }
                    }
                    file.WriteLine(strline);// 直接追加文件末尾，换行
                }
                #endregion

                file.Close();
                return true;
            }
            catch (Exception ex)//导出Txt出错
            {
                //throw new Exception(ex.Message);
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool CheckTxtFileData(string filePath, int columnnum)//检查txt文件数据的合法性
        {
            try
            {
                System.Data.DataTable dt = LoadDataFromTxt(filePath);
                if (dt == null)//txt文件数据不合法
                {
                    return false;
                }
                if (dt.Columns.Count != columnnum)//检测列的数目是否符合条件
                {
                    return false;
                }

                #region 检测表中数据(含表头)是否均非空
                for (int i = 0; i < dt.Columns.Count; i++)//在表头中遍历
                {
                    if (dt.Columns[i].ColumnName == string.Empty)
                    {
                        return false;
                    }
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j].ToString() == string.Empty)
                        {
                            return false;
                        }
                    }
                }
                #endregion

                return true;
            }
            catch (Exception ex)//txt文件数据的不合法
            {
                //throw new Exception(ex.Message);
                //MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
