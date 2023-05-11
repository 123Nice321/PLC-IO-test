using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC点位_IO测试系统软件.PerForm
{
    public partial class F_PLC品牌型号选择界面 : Form
    {
        public F_PLC品牌型号选择界面()
        {
            InitializeComponent();
        }

        private void but_OMRPLC_Click(object sender, EventArgs e)
        {
            Program.PLC = 2;
            Form F_欧姆龙PLC = new F_欧姆龙PLC点位测试界面();//FM2 是窗口的(Name)
            F_欧姆龙PLC.ShowDialog(this);
            //F_PLC品牌选择.Show(this);

            //this.Close();
        }

        private void but_HuiChuanPLC_Click(object sender, EventArgs e)
        {
            Program.PLC = 1;
            Form F_汇川PLC = new F_汇川PLC点位测试界面();//FM2 是窗口的(Name)
            F_汇川PLC.ShowDialog(this);
            //F_PLC品牌选择.Show(this);

            //this.Close();
        }

        private void but_Soft01_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能开发中...");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能开发中...");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能开发中...");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能开发中...");
        }
    }
}
