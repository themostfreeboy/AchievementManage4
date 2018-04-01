using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;//DataColumn和DataRow需要
using System.Windows.Forms;//DataGridView需要

namespace AchievementManage
{
    class MyData
    {
        public static System.Data.DataTable GetDgvToTable(DataGridView dgv)//将DataGridView控件中的内容转化成System.Data.DataTable
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)//列强制转换
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            for (int count = 0; count < dgv.Rows.Count; count++)//循环行
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static string GetFileExtByFileName(string filename)//通过文件名获取文件扩展名
        {
            try
            {
                string fileext = string.Empty;
                fileext = filename.Substring(filename.LastIndexOf(".") + 1);//获取文件扩展名
                fileext = fileext.ToLower();//将所有后缀扩展名转化为小写，便于比较
                return fileext;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                //MessageBox.Show(ex.Message);
                return string.Empty;
            }
        }

        public static bool DataConvert(System.Data.DataTable dt)//此函数主要针对于通过文件导入后，部分格式不正确的数据显示到“导入失败的信息显示”中，尤其出现“(数据格式有误)”时，之前的函数无法将这些数据导出到文件，此函数主要完成此部分的处理(System.Data.DataTable传递的为引用值，类似于地址，结果会影响传入的类，不需要通过返回DataTable来实现改变)
        {
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        try
                        {
                            if (dt.Columns[j].ColumnName == "时间")//对成果时间的数据格式的单独转化
                            {
                                dt.Rows[i][j] = Convert.ToDateTime(dt.Rows[i][j].ToString().Trim()).ToString("yyyy-MM-dd");//去除时间只留日期
                            }
                            else if (dt.Columns[j].ColumnName == "支撑基金")//对成果支撑基金的格式的单独转化
                            {
                                dt.Rows[i][j] = Convert.ToDouble(dt.Rows[i][j].ToString().Trim());
                            }
                            else//其他字段格式不需要转化
                            {
                                dt.Rows[i][j] = dt.Rows[i][j].ToString();
                            }
                        }
                        catch (Exception ex_2)//格式转化出错
                        {
                            //MessageBox.Show(ex_2.Message);
                            //throw new Exception(ex_2.Message);
                            dt.Rows[i][j] = "(数据格式有误)".ToString();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex_1)
            {
                //MessageBox.Show(ex_1.Message);
                //throw new Exception(ex_1.Message);
                return false;
            }
        }
    }
}
