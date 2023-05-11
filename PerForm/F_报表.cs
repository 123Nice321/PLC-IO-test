using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC点位_IO测试系统软件.PerForm
{
    public partial class F_报表 : Form
    {
        public F_报表()
        {
            InitializeComponent();
        }

        private void F_报表_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void but_report_printing_Click(object sender, EventArgs e)
        {
            //获取总联数
            int int1 = Convert.ToInt16(Program.Location_link_number);

            if (Program.PLC == 1)//汇川报表
            {
                //第一步：清除之前的数据
                reportViewer1.LocalReport.DataSources.Clear();
                //第二步：指定报表路径
                this.reportViewer1.LocalReport.ReportPath = "报表打印.rdlc";
                //第三步：构造新的DataTable
                //DataTable dt = new DataTable("DataTable1");
                DataTable dt = new DataTable("DataTable1");
                dt.Columns.Add("测试端子");
                dt.Columns.Add("含义");
                dt.Columns.Add("正确");
                dt.Rows.Add(new object[] { "R1S1T1", "单列外部动力总线", "√" });
                dt.Rows.Add(new object[] { "R2S2T2", "未使用", "  " });
                //判断是否重列
                if (Program.One_Two == 2)
                    dt.Rows.Add(new object[] { "R3S3T3", "重列外部动力总线", "√" });
                else
                    dt.Rows.Add(new object[] { "R3S3T3", "未使用", "  " });
                //判断是否有升降或横移
                if (Program.Yx_Yy == 1 || Program.Yx_Yy == 3)
                    dt.Rows.Add(new object[] { "UxVxWx", "主控箱联升降电源", "√" });
                else
                    dt.Rows.Add(new object[] { "UxVxWx", "未使用", "  " });

                if (Program.Yx_Yy == 2 || Program.Yx_Yy == 3)
                    dt.Rows.Add(new object[] { "UyVyWy", "主控箱联横移电源", "√" });
                else
                    dt.Rows.Add(new object[] { "UyVyWy", "未使用", "  " });
                if (Program.Yx_Yy == 1 || Program.Yx_Yy == 3)
                    dt.Rows.Add(new object[] { "Yx", "主控箱联升降控制", "√" });
                else
                    dt.Rows.Add(new object[] { "Yx", "未使用", "  " });

                if (Program.Yx_Yy == 2 || Program.Yx_Yy == 3)
                    dt.Rows.Add(new object[] { "Yy", "主控箱联横移控制", "√" });
                else
                    dt.Rows.Add(new object[] { "Yy", "未使用", "  " });
                if (Program.Yx_Yy == 1 || Program.Yx_Yy == 3)
                    dt.Rows.Add(new object[] { "10A", "主控箱联挂钩电源", "√" });
                else
                    dt.Rows.Add(new object[] { "10A", "未使用", "  " });
                dt.Rows.Add(new object[] { "R300/S100", "外部电源AC220V", "√" });
                dt.Rows.Add(new object[] { "R200/S100", "未使用", "  " });
                dt.Rows.Add(new object[] { "P24/N24", "控制电源DC24V", "√" });
                dt.Rows.Add(new object[] { "D1+/D1-", "RS485通讯", "√" });
                dt.Rows.Add(new object[] { "D2+/D2-/SG", "RS232通讯", "√" });
                dt.Rows.Add(new object[] { "X01", "人车误入光电1", "√" });
                dt.Rows.Add(new object[] { "X02", "后超光电1", "√" });
                //判断是否重列
                if (Program.One_Two == 2)
                {
                    dt.Rows.Add(new object[] { "X03", "人车误入光电2", "√" });
                    dt.Rows.Add(new object[] { "X04", "后超光电2", "√" });
                }
                else
                {
                    if(Program.X20_X4==1)
                    {
                        dt.Rows.Add(new object[] { "X03", "光电信号1", "√" });
                        dt.Rows.Add(new object[] { "X04", "2联横移信号", "√" });
                    }
                    else
                    {
                        dt.Rows.Add(new object[] { "X03", "光电信号1", "√" });
                        dt.Rows.Add(new object[] { "X04", "光电信号2", "√" });
                    }

                }
                dt.Rows.Add(new object[] { "X05", "钥匙信号1", "√" });
                dt.Rows.Add(new object[] { "JT1", "急停信号1", "√" });
                dt.Rows.Add(new object[] { "000", "未使用", "  " });
                dt.Rows.Add(new object[] { "JT2", "未使用", "  " });
                //1联
                if (0 < int1 & int1 <= 12)
                {
                    dt.Rows.Add(new object[] { "Y06", "1联升降控制", "√" });
                    dt.Rows.Add(new object[] { "Y07", "1联横移控制", "√" });
                    dt.Rows.Add(new object[] { "X07", "1联上极限", "√" });
                    dt.Rows.Add(new object[] { "X10", "1联上定位", "√" });
                    dt.Rows.Add(new object[] { "X11", "1联下定位", "√" });
                    dt.Rows.Add(new object[] { "X12", "1联挂钩信号", "√" });
                    dt.Rows.Add(new object[] { "X13", "1联横移定位", "√" });
                }
                else
                {
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                }
                //2联

                    if (1 < int1 & int1 <= 12)
                    {
                        dt.Rows.Add(new object[] { "Y10", "2联升降控制", "√" });
                        dt.Rows.Add(new object[] { "Y11", "2联横移控制", "√" });
                        dt.Rows.Add(new object[] { "X14", "2联上极限", "√" });
                        dt.Rows.Add(new object[] { "X15", "2联上定位", "√" });
                        dt.Rows.Add(new object[] { "X16", "2联下定位", "√" });
                        dt.Rows.Add(new object[] { "X17", "2联挂钩信号", "√" });
                    if (Program.X20_X4 == 1)
                        dt.Rows.Add(new object[] { " ", " ", " " });
                    else
                        dt.Rows.Add(new object[] { "X20", "2联横移定位", "√" });
                    }

            else
            {
                dt.Rows.Add(new object[] { " ", " ", " " });
                dt.Rows.Add(new object[] { " ", " ", " " });
                dt.Rows.Add(new object[] { " ", " ", " " });
                dt.Rows.Add(new object[] { " ", " ", " " });
                dt.Rows.Add(new object[] { " ", " ", " " });
                dt.Rows.Add(new object[] { " ", " ", " " });
                dt.Rows.Add(new object[] { " ", " ", " " });
            }
                //3联
                if (2 < int1 & int1 <= 12)
                {
                    dt.Rows.Add(new object[] { "Y12", "3联升降控制", "√" });
                    dt.Rows.Add(new object[] { "Y13", "3联横移控制", "√" });
                }
                else
                {
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                }




                //名称不能写错，和报表中的数据集名称一致
                ReportDataSource rdsItem = new ReportDataSource("DataSet1", dt);
                DataTable dt1 = new DataTable("DataTable2");
                dt1.Columns.Add("测试端子");
                dt1.Columns.Add("含义");
                dt1.Columns.Add("正确");
                //3联
                if (2 < int1 & int1 <= 12)
                {
                    dt1.Rows.Add(new object[] { "X21", "3联上极限", "√" });
                    dt1.Rows.Add(new object[] { "X22", "3联上定位", "√" });
                    dt1.Rows.Add(new object[] { "X23", "3联下定位", "√" });
                    dt1.Rows.Add(new object[] { "X24", "3联挂钩信号", "√" });
                    dt1.Rows.Add(new object[] { "X25", "3联横移定位", "√" });
                }
                else
                {
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                }
                //4联
                if (3 < int1 & int1 <= 12)
                {
                    dt1.Rows.Add(new object[] { "Y14", "4联升降控制", "√" });
                    dt1.Rows.Add(new object[] { "Y15", "4联横移控制", "√" });
                    dt1.Rows.Add(new object[] { "X26", "4联上极限", "√" });
                    dt1.Rows.Add(new object[] { "X27", "4联上定位", "√" });
                    dt1.Rows.Add(new object[] { "X30", "4联下定位", "√" });
                    dt1.Rows.Add(new object[] { "X31", "4联挂钩信号", "√" });
                    dt1.Rows.Add(new object[] { "X32", "4联横移定位", "√" });
                }
                else
                {
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                }
                //5联
                if (4 < int1 & int1 <= 12)
                {
                    dt1.Rows.Add(new object[] { "Y16", "5联升降控制", "√" });
                    dt1.Rows.Add(new object[] { "Y17", "5联横移控制", "√" });
                    dt1.Rows.Add(new object[] { "X33", "5联上极限", "√" });
                    dt1.Rows.Add(new object[] { "X34", "5联上定位", "√" });
                    dt1.Rows.Add(new object[] { "X35", "5联下定位", "√" });
                    dt1.Rows.Add(new object[] { "X36", "5联挂钩信号", "√" });
                    dt1.Rows.Add(new object[] { "X37", "5联横移定位", "√" });
                }
                else
                {
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                }
                //6联
                if (5 < int1 & int1 <= 12)
                {
                    dt1.Rows.Add(new object[] { "Y20", "6联升降控制", "√" });
                    dt1.Rows.Add(new object[] { "Y21", "6联横移控制", "√" });
                    dt1.Rows.Add(new object[] { "X40", "6联上极限", "√" });
                    dt1.Rows.Add(new object[] { "X41", "6联上定位", "√" });
                    dt1.Rows.Add(new object[] { "X42", "6联下定位", "√" });
                    dt1.Rows.Add(new object[] { "X43", "6联挂钩信号", "√" });
                    dt1.Rows.Add(new object[] { "X50", "6联横移定位", "√" });
                }
                else
                {
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                }
                //7联
                if (6 < int1 & int1 <= 12)
                {
                    dt1.Rows.Add(new object[] { "Y22", "7联升降控制", "√" });
                    dt1.Rows.Add(new object[] { "Y23", "7联横移控制", "√" });
                    dt1.Rows.Add(new object[] { "X51", "7联上极限", "√" });
                    dt1.Rows.Add(new object[] { "X52", "7联上定位", "√" });
                    dt1.Rows.Add(new object[] { "X53", "7联下定位", "√" });
                    dt1.Rows.Add(new object[] { "X54", "7联挂钩信号", "√" });
                    dt1.Rows.Add(new object[] { "X55", "7联横移定位", "√" });
                }
                else
                {
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                }
                //8联
                if (7 < int1 & int1 <= 12)
                {
                    dt1.Rows.Add(new object[] { "Y24", "8联升降控制", "√" });
                    dt1.Rows.Add(new object[] { "Y25", "8联横移控制", "√" });
                    dt1.Rows.Add(new object[] { "X56", "8联上极限", "√" });
                    dt1.Rows.Add(new object[] { "X57", "8联上定位", "√" });
                }
                else
                {
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                }

                //名称不能写错，和报表中的数据集名称一致
                ReportDataSource rdsItem1 = new ReportDataSource("DataSet2", dt1);

                DataTable dt2 = new DataTable("DataTable3");
                dt2.Columns.Add("测试端子");
                dt2.Columns.Add("含义");
                dt2.Columns.Add("正确");

                //8联
                if (7 < int1 & int1 <= 12)
                {
                    dt2.Rows.Add(new object[] { "X60", "8联下定位", "√" });
                    dt2.Rows.Add(new object[] { "X61", "8联挂钩信号", "√" });
                    dt2.Rows.Add(new object[] { "X62", "8联横移定位", "√" });
                }
                else
                {
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                }
                //9联
                if (8 < int1 & int1 <= 12)
                {
                    dt2.Rows.Add(new object[] { "Y26", "9联升降控制", "√" });
                    dt2.Rows.Add(new object[] { "Y27", "9联横移控制", "√" });
                    dt2.Rows.Add(new object[] { "X63", "9联上极限", "√" });
                    dt2.Rows.Add(new object[] { "X64", "9联上定位", "√" });
                    dt2.Rows.Add(new object[] { "X65", "9联下定位", "√" });
                    dt2.Rows.Add(new object[] { "X66", "9联挂钩信号", "√" });
                    dt2.Rows.Add(new object[] { "X67", "9联横移定位", "√" });
                }
                else
                {
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                }
                //10联
                if (9 < int1 & int1 <= 12)
                {
                    dt2.Rows.Add(new object[] { "Y30", "10联升降控制", "√" });
                    dt2.Rows.Add(new object[] { "Y31", "10联横移控制", "√" });
                    dt2.Rows.Add(new object[] { "X70", "10联上极限", "√" });
                    dt2.Rows.Add(new object[] { "X71", "10联上定位", "√" });
                    dt2.Rows.Add(new object[] { "X72", "10联下定位", "√" });
                    dt2.Rows.Add(new object[] { "X73", "10联挂钩信号", "√" });
                    dt2.Rows.Add(new object[] { "X74", "10联横移定位", "√" });
                }
                else
                {
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                }
                //11联
                if (10 < int1 & int1 <= 12)
                {
                    dt2.Rows.Add(new object[] { "Y32", "11联升降控制", "√" });
                    dt2.Rows.Add(new object[] { "Y33", "11联横移控制", "√" });
                    dt2.Rows.Add(new object[] { "X75", "11联上极限", "√" });
                    dt2.Rows.Add(new object[] { "X76", "11联上定位", "√" });
                    dt2.Rows.Add(new object[] { "X77", "11联下定位", "√" });
                    dt2.Rows.Add(new object[] { "X100", "11联挂钩信号", "√" });
                    dt2.Rows.Add(new object[] { "X101", "11联横移定位", "√" });
                }
                else
                {
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                }
                //12联
                if (11 < int1 & int1 <= 12)
                {
                    dt2.Rows.Add(new object[] { "Y34", "12联升降控制", "√" });
                    dt2.Rows.Add(new object[] { "Y35", "12联横移控制", "√" });
                    dt2.Rows.Add(new object[] { "X102", "12联上极限", "√" });
                    dt2.Rows.Add(new object[] { "X103", "12联上定位", "√" });
                    dt2.Rows.Add(new object[] { "X104", "12联下定位", "√" });
                    dt2.Rows.Add(new object[] { "X105", "12联挂钩信号", "√" });
                    dt2.Rows.Add(new object[] { "X106", "12联横移定位", "√" });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                }
                else
                {
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                }



                //名称不能写错，和报表中的数据集名称一致
                ReportDataSource rdsItem2 = new ReportDataSource("DataSet3", dt2);

                //
                //string str = Program.Project_Name;
                //string str1 = Program.Project_Name;
                //string str2 = Program.Treaty_Number;
                //string str3 = Program.Treaty_Number;
                //DataTable dt3 = new DataTable("DataTable4");
                //dt3.Columns.Add("time11");
                //dt3.Rows.Add(new object[] { "语文2" });
                ////名称不能写错，和报表中的数据集名称一致
                //ReportDataSource rdsItem3 = new ReportDataSource("DataSet4", dt3);


                //此处可以有多个数据源
                this.reportViewer1.LocalReport.DataSources.Add(rdsItem);
                this.reportViewer1.LocalReport.DataSources.Add(rdsItem1);
                this.reportViewer1.LocalReport.DataSources.Add(rdsItem2);
                //this.reportViewer1.LocalReport.DataSources.Add(rdsItem3);
                //第四步：构造参数
                //string str = "这是一个测试文本！";
                List<ReportParameter> lstParameter = new List<ReportParameter>()
            {
                new ReportParameter("测试PLC品牌", "汇川PLC"),
                new ReportParameter("工程名称", Program.Project_Name),
                new ReportParameter("合约编号", Program.Treaty_Number),
                new ReportParameter("区位编号", Program.Location_number),
                new ReportParameter("联数", Program.Location_link_number),
                new ReportParameter("车位数", Program.Parking_space),
                new ReportParameter("测试人员", Program.Username),
                new ReportParameter("前排联数", Program.front_number),
                new ReportParameter("后排联数", Program.queen_number),


            };
                this.reportViewer1.LocalReport.SetParameters(lstParameter);
                //this.reportViewer1.ZoomMode = ZoomMode.FullPage;
                //this.reportViewer1.ZoomPercent = 100;//缩放100

                //第五步：刷新报表
                this.reportViewer1.RefreshReport();
                //打印浏览
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            }
            if (Program.PLC == 2)//欧姆龙报表
            {
                //第一步：清除之前的数据
                reportViewer1.LocalReport.DataSources.Clear();
                //第二步：指定报表路径
                this.reportViewer1.LocalReport.ReportPath = "报表打印.rdlc";
                //第三步：构造新的DataTable
                //DataTable dt = new DataTable("DataTable1");
                DataTable dt = new DataTable("DataTable1");
                dt.Columns.Add("测试端子");
                dt.Columns.Add("含义");
                dt.Columns.Add("正确");
                dt.Rows.Add(new object[] { "R1S1T1", "单列外部动力总线", "√" });
                dt.Rows.Add(new object[] { "R2S2T2", "未使用", "  " });
                //判断是否重列
                if (Program.One_Two == 2)
                    dt.Rows.Add(new object[] { "R3S3T3", "重列外部动力总线", "√" });
                else
                    dt.Rows.Add(new object[] { "R3S3T3", "未使用", "  " });
                //判断是否有升降或横移
                if (Program.Yx_Yy == 1 || Program.Yx_Yy == 3)
                    dt.Rows.Add(new object[] { "UxVxWx", "主控箱联升降电源", "√" });
                else
                    dt.Rows.Add(new object[] { "UxVxWx", "未使用", "  " });

                if (Program.Yx_Yy == 2 || Program.Yx_Yy == 3)
                    dt.Rows.Add(new object[] { "UyVyWy", "主控箱联横移电源", "√" });
                else
                    dt.Rows.Add(new object[] { "UyVyWy", "未使用", "  " });
                if (Program.Yx_Yy == 1 || Program.Yx_Yy == 3)
                    dt.Rows.Add(new object[] { "Yx", "主控箱联升降控制", "√" });
                else
                    dt.Rows.Add(new object[] { "Yx", "未使用", "  " });

                if (Program.Yx_Yy == 2 || Program.Yx_Yy == 3)
                    dt.Rows.Add(new object[] { "Yy", "主控箱联横移控制", "√" });
                else
                    dt.Rows.Add(new object[] { "Yy", "未使用", "  " });
                if (Program.Yx_Yy == 1 || Program.Yx_Yy == 3)
                    dt.Rows.Add(new object[] { "10A", "主控箱联挂钩电源", "√" });
                else
                    dt.Rows.Add(new object[] { "10A", "未使用", "  " });
                dt.Rows.Add(new object[] { "R300/S100", "外部电源AC220V", "√" });
                dt.Rows.Add(new object[] { "R200/S100", "未使用", "  " });
                dt.Rows.Add(new object[] { "P24/N24", "控制电源DC24V", "√" });
                dt.Rows.Add(new object[] { "D1+/D1-", "RS485通讯", "√" });
                dt.Rows.Add(new object[] { "D2+/D2-/SG", "RS232通讯", "√" });
                dt.Rows.Add(new object[] { "0.01", "人车误入光电1", "√" });
                dt.Rows.Add(new object[] { "0.02", "后超光电1", "√" });
                //判断是否重列
                if (Program.One_Two == 2)
                {
                    dt.Rows.Add(new object[] { "0.03", "人车误入光电2", "√" });
                    dt.Rows.Add(new object[] { "0.04", "后超光电2", "√" });
                }
                else
                {
                    dt.Rows.Add(new object[] { "0.03", "光电信号1", "√" });
                    dt.Rows.Add(new object[] { "0.04", "光电信号2", "√" });
                }
                dt.Rows.Add(new object[] { "0.05", "钥匙信号1", "√" });
                dt.Rows.Add(new object[] { "JT1", "急停信号1", "√" });
                dt.Rows.Add(new object[] { "000", "未使用", "  " });
                dt.Rows.Add(new object[] { "JT2", "未使用", "  " });
                //1联
                if (0 < int1 & int1 <= 12)
                {
                    dt.Rows.Add(new object[] { "101.00", "1联升降控制", "√" });
                    dt.Rows.Add(new object[] { "101.01", "1联横移控制", "√" });
                    dt.Rows.Add(new object[] { "0.07", "1联上极限", "√" });
                    dt.Rows.Add(new object[] { "0,08", "1联上定位", "√" });
                    dt.Rows.Add(new object[] { "0.09", "1联下定位", "√" });
                    dt.Rows.Add(new object[] { "0.10", "1联挂钩信号", "√" });
                    dt.Rows.Add(new object[] { "0.11", "1联横移定位", "√" });
                }
                else
                {
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                }
                //2联
                if (1 < int1 & int1 <= 12)
                {
                    dt.Rows.Add(new object[] { "101.02", "2联升降控制", "√" });
                    dt.Rows.Add(new object[] { "101.03", "2联横移控制", "√" });
                    dt.Rows.Add(new object[] { "1.00", "2联上极限", "√" });
                    dt.Rows.Add(new object[] { "1.01", "2联上定位", "√" });
                    dt.Rows.Add(new object[] { "1.02", "2联下定位", "√" });
                    dt.Rows.Add(new object[] { "1.03", "2联挂钩信号", "√" });
                    dt.Rows.Add(new object[] { "1.04", "2联横移定位", "√" });
                }
                else
                {
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                }
                //3联
                if (2 < int1 & int1 <= 12)
                {
                    dt.Rows.Add(new object[] { "101.04", "3联升降控制", "√" });
                    dt.Rows.Add(new object[] { "101.05", "3联横移控制", "√" });
                }
                else
                {
                    dt.Rows.Add(new object[] { " ", " ", " " });
                    dt.Rows.Add(new object[] { " ", " ", " " });
                }




                //名称不能写错，和报表中的数据集名称一致
                ReportDataSource rdsItem = new ReportDataSource("DataSet1", dt);
                DataTable dt1 = new DataTable("DataTable2");
                dt1.Columns.Add("测试端子");
                dt1.Columns.Add("含义");
                dt1.Columns.Add("正确");
                //3联
                if (2 < int1 & int1 <= 12)
                {
                    dt1.Rows.Add(new object[] { "1.05", "3联上极限", "√" });
                    dt1.Rows.Add(new object[] { "1.06", "3联上定位", "√" });
                    dt1.Rows.Add(new object[] { "1.07", "3联下定位", "√" });
                    dt1.Rows.Add(new object[] { "1.08", "3联挂钩信号", "√" });
                    dt1.Rows.Add(new object[] { "1.09", "3联横移定位", "√" });
                }
                else
                {
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                }
                //4联
                if (3 < int1 & int1 <= 12)
                {
                    dt1.Rows.Add(new object[] { "101.06", "4联升降控制", "√" });
                    dt1.Rows.Add(new object[] { "101.07", "4联横移控制", "√" });
                    dt1.Rows.Add(new object[] { "1.10", "4联上极限", "√" });
                    dt1.Rows.Add(new object[] { "1.11", "4联上定位", "√" });
                    dt1.Rows.Add(new object[] { "2.00", "4联下定位", "√" });
                    dt1.Rows.Add(new object[] { "2.01", "4联挂钩信号", "√" });
                    dt1.Rows.Add(new object[] { "2.02", "4联横移定位", "√" });
                }
                else
                {
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                }
                //5联
                if (4 < int1 & int1 <= 12)
                {
                    dt1.Rows.Add(new object[] { "102.00", "5联升降控制", "√" });
                    dt1.Rows.Add(new object[] { "102.01", "5联横移控制", "√" });
                    dt1.Rows.Add(new object[] { "2.03", "5联上极限", "√" });
                    dt1.Rows.Add(new object[] { "2.04", "5联上定位", "√" });
                    dt1.Rows.Add(new object[] { "2.05", "5联下定位", "√" });
                    dt1.Rows.Add(new object[] { "2.06", "5联挂钩信号", "√" });
                    dt1.Rows.Add(new object[] { "2.07", "5联横移定位", "√" });
                }
                else
                {
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                }
                //6联
                if (5 < int1 & int1 <= 12)
                {
                    dt1.Rows.Add(new object[] { "102.02", "6联升降控制", "√" });
                    dt1.Rows.Add(new object[] { "102.03", "6联横移控制", "√" });
                    dt1.Rows.Add(new object[] { "2.08", "6联上极限", "√" });
                    dt1.Rows.Add(new object[] { "2.09", "6联上定位", "√" });
                    dt1.Rows.Add(new object[] { "2.10", "6联下定位", "√" });
                    dt1.Rows.Add(new object[] { "2.11", "6联挂钩信号", "√" });
                    dt1.Rows.Add(new object[] { "3.00", "6联横移定位", "√" });
                }
                else
                {
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                }
                //7联
                if (6 < int1 & int1 <= 12)
                {
                    dt1.Rows.Add(new object[] { "102.04", "7联升降控制", "√" });
                    dt1.Rows.Add(new object[] { "102.05", "7联横移控制", "√" });
                    dt1.Rows.Add(new object[] { "3.01", "7联上极限", "√" });
                    dt1.Rows.Add(new object[] { "3.02", "7联上定位", "√" });
                    dt1.Rows.Add(new object[] { "3.03", "7联下定位", "√" });
                    dt1.Rows.Add(new object[] { "3.04", "7联挂钩信号", "√" });
                    dt1.Rows.Add(new object[] { "3.05", "7联横移定位", "√" });
                }
                else
                {
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                }
                //8联
                if (7 < int1 & int1 <= 12)
                {
                    dt1.Rows.Add(new object[] { "102.6", "8联升降控制", "√" });
                    dt1.Rows.Add(new object[] { "102.7", "8联横移控制", "√" });
                    dt1.Rows.Add(new object[] { "3.06", "8联上极限", "√" });
                    dt1.Rows.Add(new object[] { "3.07", "8联上定位", "√" });
                }
                else
                {
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                    dt1.Rows.Add(new object[] { " ", " ", " " });
                }

                //名称不能写错，和报表中的数据集名称一致
                ReportDataSource rdsItem1 = new ReportDataSource("DataSet2", dt1);

                DataTable dt2 = new DataTable("DataTable3");
                dt2.Columns.Add("测试端子");
                dt2.Columns.Add("含义");
                dt2.Columns.Add("正确");

                //8联
                if (7 < int1 & int1 <= 12)
                {
                    dt2.Rows.Add(new object[] { "3.08", "8联下定位", "√" });
                    dt2.Rows.Add(new object[] { "3.09", "8联挂钩信号", "√" });
                    dt2.Rows.Add(new object[] { "3.10", "8联横移定位", "√" });
                }
                else
                {
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                }
                //9联
                if (8 < int1 & int1 <= 12)
                {
                    dt2.Rows.Add(new object[] { "103.00", "9联升降控制", "√" });
                    dt2.Rows.Add(new object[] { "103.01", "9联横移控制", "√" });
                    dt2.Rows.Add(new object[] { "3.11", "9联上极限", "√" });
                    dt2.Rows.Add(new object[] { "4.00", "9联上定位", "√" });
                    dt2.Rows.Add(new object[] { "4.01", "9联下定位", "√" });
                    dt2.Rows.Add(new object[] { "4.02", "9联挂钩信号", "√" });
                    dt2.Rows.Add(new object[] { "4,03", "9联横移定位", "√" });
                }
                else
                {
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                }
                //10联
                if (9 < int1 & int1 <= 12)
                {
                    dt2.Rows.Add(new object[] { "103.02", "10联升降控制", "√" });
                    dt2.Rows.Add(new object[] { "103.03", "10联横移控制", "√" });
                    dt2.Rows.Add(new object[] { "4.04", "10联上极限", "√" });
                    dt2.Rows.Add(new object[] { "4.05", "10联上定位", "√" });
                    dt2.Rows.Add(new object[] { "4.06", "10联下定位", "√" });
                    dt2.Rows.Add(new object[] { "4.07", "10联挂钩信号", "√" });
                    dt2.Rows.Add(new object[] { "4.08", "10联横移定位", "√" });
                }
                else
                {
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                }
                //11联
                if (10 < int1 & int1 <= 12)
                {
                    dt2.Rows.Add(new object[] { "103.04", "11联升降控制", "√" });
                    dt2.Rows.Add(new object[] { "103.05", "11联横移控制", "√" });
                    dt2.Rows.Add(new object[] { "4.09", "11联上极限", "√" });
                    dt2.Rows.Add(new object[] { "4.10", "11联上定位", "√" });
                    dt2.Rows.Add(new object[] { "4.11", "11联下定位", "√" });
                    dt2.Rows.Add(new object[] { "5.00", "11联挂钩信号", "√" });
                    dt2.Rows.Add(new object[] { "5.01", "11联横移定位", "√" });
                }
                else
                {
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                }
                //12联
                if (11 < int1 & int1 <= 12)
                {
                    dt2.Rows.Add(new object[] { "103.06", "12联升降控制", "√" });
                    dt2.Rows.Add(new object[] { "103.07", "12联横移控制", "√" });
                    dt2.Rows.Add(new object[] { "5.02", "12联上极限", "√" });
                    dt2.Rows.Add(new object[] { "5.03", "12联上定位", "√" });
                    dt2.Rows.Add(new object[] { "5.04", "12联下定位", "√" });
                    dt2.Rows.Add(new object[] { "5.05", "12联挂钩信号", "√" });
                    dt2.Rows.Add(new object[] { "5.06", "12联横移定位", "√" });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                }
                else
                {
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                    dt2.Rows.Add(new object[] { " ", " ", " " });
                }



                //名称不能写错，和报表中的数据集名称一致
                ReportDataSource rdsItem2 = new ReportDataSource("DataSet3", dt2);

                //
                //string str = Program.Project_Name;
                //string str1 = Program.Project_Name;
                //string str2 = Program.Treaty_Number;
                //string str3 = Program.Treaty_Number;
                //DataTable dt3 = new DataTable("DataTable4");
                //dt3.Columns.Add("time11");
                //dt3.Rows.Add(new object[] { "语文2" });
                ////名称不能写错，和报表中的数据集名称一致
                //ReportDataSource rdsItem3 = new ReportDataSource("DataSet4", dt3);


                //此处可以有多个数据源
                this.reportViewer1.LocalReport.DataSources.Add(rdsItem);
                this.reportViewer1.LocalReport.DataSources.Add(rdsItem1);
                this.reportViewer1.LocalReport.DataSources.Add(rdsItem2);
                //this.reportViewer1.LocalReport.DataSources.Add(rdsItem3);
                //第四步：构造参数
                //string str = "这是一个测试文本！";
                List<ReportParameter> lstParameter = new List<ReportParameter>()
            {
                new ReportParameter("测试PLC品牌", "欧姆龙PLC"),
                new ReportParameter("工程名称", Program.Project_Name),
                new ReportParameter("合约编号", Program.Treaty_Number),
                new ReportParameter("区位编号", Program.Location_number),
                new ReportParameter("联数", Program.Location_link_number),
                new ReportParameter("车位数", Program.Parking_space),
                new ReportParameter("测试人员", Program.Username),
                new ReportParameter("前排联数", Program.front_number),
                new ReportParameter("后排联数", Program.queen_number),


            };
                this.reportViewer1.LocalReport.SetParameters(lstParameter);
                //this.reportViewer1.ZoomMode = ZoomMode.FullPage;
                //this.reportViewer1.ZoomPercent = 100;//缩放100

                //第五步：刷新报表
                this.reportViewer1.RefreshReport();
                //打印浏览
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            }
        }

        private void but_Print_Click(object sender, EventArgs e)//报表打印
        {
            reportViewer1.PrintDialog();
        }

        private void but_Report_saving_Click(object sender, EventArgs e)//报表保存为Excel文件
        {
            //然后将指定的字节数组写入文件，然后关闭文件。如果目标文件已经存在，则将其覆盖
            string str1 = Environment.CurrentDirectory+@"\报表\";
            string str = str1 + Program.Project_Name +"-"+ Program.Treaty_Number +"-"+ Program.Location_number+".xls";
            File.WriteAllBytes(str, reportViewer1.LocalReport.Render("Excel"));

            //提示是否查看
            if (MessageBox.Show("文件已在项目目录【报表】文件夹保存 Excel文件格式！是否打开文件夹！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //直接打开目录
                System.Diagnostics.Process.Start("explorer.exe", str1);
            }
        }
    }
}
