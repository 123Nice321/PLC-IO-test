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

namespace PLC点位_IO测试系统软件
{
    public partial class 登录界面 : Form
    {
        MyModuleClass.MyModule MyMenu = new PLC点位_IO测试系统软件.MyModuleClass.MyModule();
        public static 登录界面 f0 = null; //用来引用主窗口
        public 登录界面()
        {
            InitializeComponent();
            f0 = this;
        }

        private void but_Exit0_Click(object sender, EventArgs e)
        {
            //让用户选择点击
            if (MessageBox.Show("确定要关闭系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //判断是否取消事件
                Application.ExitThread(); //关闭应用程序
            }
            //Application.Exit(); //关闭应用程序
        }//关闭该线程所有窗口

        private void but_login_Click(object sender, EventArgs e)
        {
            if (com_username.Text == "Admin" & text_password.Text == "123456")
            {
                Hide();
                MyMenu.Show_Form("后台管理界面", 1);
            }
            else
            {
                //MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //if (com_username.Text == "王哲" & text_password.Text == "123")
                if (com_username.Text != "" & text_password.Text == "123")
                {
                    Program.Username = com_username.Text;
                    //Close();//关闭窗口
                    Hide();
                    MyMenu.Show_Form("登录成功界面", 1);
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }


        }


        private void 登录界面_Load(object sender, EventArgs e)
        {
            com_username.Items.Clear();
            string str1 = Environment.CurrentDirectory;
            string str = str1 + @"\用户名.txt";
            string[] lines = File.ReadAllLines(str);
            //string[] lines = File.ReadAllText("用户名.txt").Trim().Split(); ;
            com_username.Items.AddRange(lines);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = Environment.CurrentDirectory;
            string str = str1 + @"\用户名.txt";
            System.Diagnostics.Process.Start("notepad.exe", str);
            if (MessageBox.Show("用户名已更新！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                com_username.Items.Clear();
                string[] lines = File.ReadAllLines(str);
                //string[] lines = File.ReadAllText("用户名.txt").Trim().Split(); ;
                com_username.Items.AddRange(lines);
            }
        }

        private void com_username_KeyDown(object sender, KeyEventArgs e)
        {
            //if条件检测按下的是不是Enter键
            if (e.KeyCode == Keys.Enter)
            {
                //com_username.Focus();
                text_password.Focus();
            }
        }

        private void text_password_KeyDown(object sender, KeyEventArgs e)
        {
            //if条件检测按下的是不是Enter键
            if (e.KeyCode == Keys.Enter)
            {
                //text_password.Focus();
                //com_username.Focus();
                but_login.Focus();
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/123Nice321/PLC-IO-test.git");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("更新说明：\r\n" +
                "20230320 优化报表功能（增加外框）。\r\n" +
                "20230321 增加欧姆龙二层1-12联测试功能。\r\n" +
                "20230321 增加管理员界面 手动填写报表打印功能（管理员界面）。\r\n" +
                "20230321 增加欧姆龙二层1-12联测试功能。\r\n" +
                "20230322 删除测试成功弹出框，失败时弹出。\r\n" +
                "20230322 修改 点击区位修改关闭通讯(防止线程卡顿)。\r\n" +
                "20230323 增加汇川PLC 2联单列 2L横移点位为X4的报表显示（管理员界面手动打印）。\r\n" +
                "20230323 增加汇川PLC 2联单列 测试功能。\r\n" +
                "20230404 增加-塔库控制柜输入输出测试功能。\r\n" +
                //"20230321增加欧姆龙二层1-12联测试功能。\r\n" +
                //"20230321增加欧姆龙二层1-12联测试功能。\r\n" +
                //"20230321增加欧姆龙二层1-12联测试功能。\r\n" +
                //"20230321增加欧姆龙二层1-12联测试功能。\r\n" +


                "持续跟新中\r\n");

        }
    }
}
