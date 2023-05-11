
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC点位_IO测试系统软件.PerForm
{
    public partial class F_管理员后台界面 : Form
    {
        public F_管理员后台界面()
        {
            InitializeComponent();


        }

        private void but_Exit1_Click(object sender, EventArgs e)
        {
            Close();
            登录界面.f0.Show(); //显示主窗口
        }

        private void F_管理员后台界面_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
            登录界面.f0.Show(); //显示主窗口
        }

       

        private void F_管理员后台界面_Load(object sender, EventArgs e)
        {

        }

        private void but_Report_testing_Click(object sender, EventArgs e)
        {
            //清除原来datatable中的数据
            //dataSet数据集.Clear() ;
            //dataSet1.DataSetName = "resa";
            //给datatable添加新数据，注意数据要与设计的datatable字段对应。
            //DataSet01._DataTable01_0.Rows.Add(new object[] { "2022-01-05-01", "XXXXXX", "XXXXXXX", "XXXXXX", "XXXXX", "XXXXX", "XXXXX", "XXXXX", 10000000, 1300000, 9000000, "XXXXX", "荀彧", "诸葛亮" });

            ////清除原来datatable中的数据
            //DataSet01._DataTable01_1.Rows.Clear();
            ////给datatable添加新数据，注意数据要与设计的datatable字段对应。
            //for (int i = 1; i <= 100; i++)
            //{
            //    DataSet01._DataTable01_1.Rows.Add(new object[] { i, "商品名称" + i, "商品规格" + i, "套", 5, 100, 500, "备注内容" + i });
            //}
            ////清除reportviewer1中原来的数据绑定
            //this.reportViewer1.LocalReport.DataSources.Clear();
            ////重新给reportviewer1绑定数据源，名称需要用我们之前设定的 "DataSet01_0"
            //this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet01_0", (DataTable)DataSet01._DataTable01_0));
            //this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet01_1", (DataTable)DataSet01._DataTable01_1));
            //刷新报表控件，显示最新数据
            //this.reportViewer1.RefreshReport();
            Form F_报表测试界面 = new F_报表测试界面 ();//FM2 是窗口的(Name)
            F_报表测试界面.ShowDialog(this);
            //F_PLC品牌选择.Show(this);
        }

        private void but_PLC_testing_Click(object sender, EventArgs e)
        {
            Form F_设备监视界面 = new F_设备监视界面();//FM2 是窗口的(Name)
            F_设备监视界面.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form F_塔库控制柜输入输出 = new F_塔库控制柜输入输出();//FM2 是窗口的(Name)
            F_塔库控制柜输入输出.ShowDialog(this);
        }
    }
}
