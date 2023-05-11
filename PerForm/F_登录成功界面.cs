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
    public partial class F_登录成功界面 : Form
    {

        public F_登录成功界面()
        {
            InitializeComponent();
        }
        private string str = "";//防止退后操作关闭整个软件
        MyModuleClass.MyModule MyMenu = new PLC点位_IO测试系统软件.MyModuleClass.MyModule();

        private void F_登录成功界面_Load(object sender, EventArgs e)
        {
            str = "";
            
        }

        private void but_Exit1_Click(object sender, EventArgs e)
        {
            str = "1";
            Close();
            登录界面.f0.Show(); //显示主窗口

        }//退回到登录界面

        private void F_登录成功界面_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if(str!="1")
            {
                //让用户选择点击
                if (MessageBox.Show("确定要关闭系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //判断是否取消事件
                    Application.ExitThread(); //关闭应用程序
                }
                else
                {
                    //取消退出
                    e.Cancel = true;

                }
            }
            
        }//退出整个系统

        private void but_begin_Click(object sender, EventArgs e)
        {

            if (text_project_name.Text != "" & text_treaty_number.Text != "")
            {
                Program.Project_Name = text_project_name.Text;
                Program.Treaty_Number = text_treaty_number.Text;
                //str = "1";
                Form F_PLC品牌选择 = new F_PLC品牌型号选择界面();//FM2 是窗口的(Name)
                F_PLC品牌选择.ShowDialog(this);
                //F_PLC品牌选择.Show(this);
                //this.Close();

            }
            else
            {
                MessageBox.Show("项目名称或合约编号错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //text_project_name.Text = "";
                    //text_treaty_number.Text = "";
            }
        }

        private void text_project_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')  //回车键
                text_treaty_number.Focus();
        }

        private void text_treaty_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')  //回车键
                but_begin.Focus();
        }
    }

}
