using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC点位_IO测试系统软件
{
    static class Program
    {
        #region  全局变量
        public static string Project_Name = ""; //定义全局变量 项目名称
        public static string Treaty_Number = "";  //定义全局变量 合约编号
        public static string Username = "";  //定义全局变量 登录名
        public static int PLC = 0;//定义全局变量 PLC品牌  1汇川  2欧姆龙
        public static string Location_link_number = ""; //定义全局变量 区位联数
        public static string Parking_space = "";  //定义全局变量 车位数
        public static string Location_number = "";  //定义全局变量 区位编号
        public static string front_number = "";//定义全局变量 前排联数
        public static string queen_number = "";//定义全局变量 后排联数
        public static int One_Two = 0; //定义全局变量 单列重列  1单列  2重列
        public static int Yx_Yy = 0; //定义全局变量 单列重列  1有升降  2有横移 3升降横移
        public static int X20_X4 = 0; //非标使用 非标2联横移X20 改为X04 (单列时请选择) 重列不用框选
        #endregion
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 登录界面());

        }
    }
}
