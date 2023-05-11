using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLC点位_IO测试系统软件;
namespace PLC点位_IO测试系统软件.MyModuleClass
{
    class MyModule
    {
        //public static string Project_Name = ""; //定义全局变量，记录当前登录的用户编号
        //public static string Treaty_Number = "";  //定义全局变量，记录当前登录的用户名
        //#region  全局变量

        ////public static string Mean_SQL = "", Mean_Table = "", Mean_Field = "";  //定义全局变量，记录“基础信息”各窗体中的表名及SQL语句
        ////public static SqlConnection My_con;  //定义一个SqlConnection类型的公共变量My_con，用于判断数据库是否连接成功
        ////public static string M_str_sqlcon = "Data Source=DESKTOP-RURUH6T;Database=SPECM;User id=sa;PWD=1214";
        ////public static string M_str_sqlcon = "Data Source=DESKTOP-QOIRUA2\\SQL;Initial Catalog=db_PWMS;Integrated Security=True";


        ////public static int Login_n = 0;  //用户登录与重新登录的标识
        //#endregion



        #region  窗体的调用
        /// <summary>
        /// 窗体的调用.
        /// </summary>
        /// <param name="FrmName">调用窗体的Text属性值</param>
        /// <param name="n">标识</param>
        public void Show_Form(string FrmName, int n)
        {
            if (FrmName == "登录成功界面")
            {
                PerForm.F_登录成功界面 FrmManFile = new PLC点位_IO测试系统软件.PerForm.F_登录成功界面();
                FrmManFile.Text = "项目名称及合约编号";   //设置窗体名称
                FrmManFile.ShowDialog();    //显示窗体
                FrmManFile.Dispose();//释放资源
            }
            if (FrmName == "后台管理界面")
            {
                PerForm.F_管理员后台界面 FrmManFile = new PLC点位_IO测试系统软件.PerForm.F_管理员后台界面();
                FrmManFile.Text = "管理员后台界面";   //设置窗体名称
                FrmManFile.ShowDialog();    //显示窗体
                FrmManFile.Dispose();//释放资源
            }
            //if (FrmName == "PLC选择界面")
            //{
            //    PerForm.F_PLC选择界面 FrmManFile = new PLC点位_IO测试系统软件.PerForm.F_PLC选择界面();
            //    FrmManFile.Text = "PLC型号品牌选择界面";   //设置窗体名称
            //    FrmManFile.ShowDialog();    //显示窗体
            //    FrmManFile.Dispose();//释放资源
            //}
            //if (FrmName == "参数设置")
            //{
            //    PerForm.F_syssetup FrmFind = new 停车管理系统数据库管理系统.PerForm.F_syssetup();
            //    FrmFind.Text = "参数设置";
            //    FrmFind.ShowDialog();
            //    FrmFind.Dispose();
            //}
            ////    FrmUser.Dispose();
            ////}
            //if (FrmName == "计算器")
            //{
            //    System.Diagnostics.Process.Start("calc.exe");
            //}
            //if (FrmName == "记事本")
            //{
            //    System.Diagnostics.Process.Start("notepad.exe");
            //}
            //if (FrmName == "系统帮助")
            //{
            //    System.Diagnostics.Process.Start(@"E:\Winfrom项目文件夹\PWMS\readme1.doc");
            //}
        }
        #endregion
    }
}
