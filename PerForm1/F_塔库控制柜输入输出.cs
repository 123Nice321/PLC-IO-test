using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Profinet.Melsec; //三菱使用
namespace PLC点位_IO测试系统软件.PerForm
{
    public partial class F_塔库控制柜输入输出 : Form
    {
        public F_塔库控制柜输入输出()
        {
            InitializeComponent();
        }
        private MelsecMcNet melsec_net = new MelsecMcNet();//实例化三菱 使用以太网通讯

        private void but_PLCLink_Click(object sender, EventArgs e)//PLC连接
        {
            melsec_net.IpAddress = textBox1.Text;//IP地址
            melsec_net.Port = Convert.ToInt32( textBox2.Text);//端口号
            melsec_net.ConnectTimeOut = 2000; // 网络连接的超时时间
            melsec_net.NetworkNumber = 0x00;  // 网络号
            melsec_net.NetworkStationNumber = 0x00; // 网络站号
            melsec_net.ConnectClose();
            OperateResult connect = melsec_net.ConnectServer();
            if (connect.IsSuccess)
            {
                MessageBox.Show("连接成功！");
                userButton1.Visible = true;
                userButton2.Visible = true;
            }
            else
            {
                MessageBox.Show("连接失败！");
                userButton1.Visible = false;
                userButton2.Visible = false;
                groupBox1.Visible = false;
                groupBox2.Visible = false;
            }
        }

        private void userButton1_Click(object sender, EventArgs e)//输入点监测
        {
            groupBox1.Visible = true;
            timer1.Enabled = true;
            groupBox2.Visible = false;
        }

        private void userButton2_Click(object sender, EventArgs e)//输出点监测
        {
            groupBox1.Visible = false;
            timer1.Enabled = false;
            groupBox2.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//打开测试软件PLC测试程序
        {
            //然后将指定的字节数组写入文件，然后关闭文件。如果目标文件已经存在，则将其覆盖
            string str1 = Environment.CurrentDirectory + @"\测试程序目录\塔库IO测试程序\";
            string str = str1;

            //提示是否查看
            if (MessageBox.Show("打开塔库IO测试程序文件夹！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //直接打开目录
                System.Diagnostics.Process.Start("explorer.exe", str1);
            }
        }

        private void F_塔库控制柜输入输出_FormClosing(object sender, FormClosingEventArgs e)//关闭窗口断开连接
        {
            melsec_net.ConnectClose();
        }


        #region  PLC输入端读取
        private void X20_X2F()
        {
            // X100-X10F读取显示
            OperateResult<bool[]> read = melsec_net.ReadBool("X20", 16);
            if (read.IsSuccess)
            {
                // 成功读取，True代表通，False代表不通
                bool X020 = read.Content[0];
                bool X021 = read.Content[1];
                bool X022 = read.Content[2];
                bool X023 = read.Content[3];
                bool X024 = read.Content[4];
                bool X025 = read.Content[5];
                bool X026 = read.Content[6];
                bool X027 = read.Content[7];
                bool X028 = read.Content[8];
                bool X029 = read.Content[9];
                bool X02A = read.Content[10];
                bool X02B = read.Content[11];
                bool X02C = read.Content[12];
                bool X02D = read.Content[13];
                bool X02E = read.Content[14];
                bool X02F = read.Content[15];
                // 显示
                //bool[] X020_X02F = { X020, X021, X022, X023, X024, X025, X026, X027, X028, X029, X02A, X02B, X02C, X02D, X02E, X02E, X02F };
                if (X020 == true)userLantern1.LanternBackground = Color.Green;
                else userLantern1.LanternBackground = Color.White;
                if (X021 == true) userLantern2.LanternBackground = Color.Green;
                else userLantern2.LanternBackground = Color.White;
                if (X022 == true) userLantern3.LanternBackground = Color.Green;
                else userLantern3.LanternBackground = Color.White;
                if (X023 == true) userLantern4.LanternBackground = Color.Green;
                else userLantern4.LanternBackground = Color.White;
                if (X024 == true) userLantern5.LanternBackground = Color.Green;
                else userLantern5.LanternBackground = Color.White;
                if (X025 == true) userLantern6.LanternBackground = Color.Green;
                else userLantern6.LanternBackground = Color.White;
                if (X026 == true) userLantern7.LanternBackground = Color.Green;
                else userLantern7.LanternBackground = Color.White;
                if (X027 == true) userLantern8.LanternBackground = Color.Green;
                else userLantern8.LanternBackground = Color.White;
                if (X028 == true) userLantern9.LanternBackground = Color.Green;
                else userLantern9.LanternBackground = Color.White;
                if (X029 == true) userLantern10.LanternBackground = Color.Green;
                else userLantern10.LanternBackground = Color.White;
                if (X02A == true) userLantern11.LanternBackground = Color.Green;
                else userLantern11.LanternBackground = Color.White;
                if (X02B == true) userLantern12.LanternBackground = Color.Green;
                else userLantern12.LanternBackground = Color.White;
                if (X02C == true) userLantern13.LanternBackground = Color.Green;
                else userLantern13.LanternBackground = Color.White;
                if (X02D == true) userLantern14.LanternBackground = Color.Green;
                else userLantern14.LanternBackground = Color.White;
                if (X02E == true) userLantern15.LanternBackground = Color.Green;
                else userLantern15.LanternBackground = Color.White;
                if (X02F == true) userLantern16.LanternBackground = Color.Green;
                else userLantern16.LanternBackground = Color.White;
            }
            else
            {
                timer1.Enabled = false;
                //失败读取，显示失败信息
                MessageBox.Show(read.ToMessageShowString());
                
            }
        }   
        private void X30_X3F()
        {
            // X100-X10F读取显示
            OperateResult<bool[]> read = melsec_net.ReadBool("X30", 16);
            if (read.IsSuccess)
            {
                // 成功读取，True代表通，False代表不通
                bool X030 = read.Content[0];
                bool X031 = read.Content[1];
                bool X032 = read.Content[2];
                bool X033 = read.Content[3];
                bool X034 = read.Content[4];
                bool X035 = read.Content[5];
                bool X036 = read.Content[6];
                bool X037 = read.Content[7];
                bool X038 = read.Content[8];
                bool X039 = read.Content[9];
                bool X03A = read.Content[10];
                bool X03B = read.Content[11];
                bool X03C = read.Content[12];
                bool X03D = read.Content[13];
                bool X03E = read.Content[14];
                bool X03F = read.Content[15];
                // 显示
                //bool[] X020_X02F = { X020, X021, X022, X023, X024, X025, X026, X027, X028, X029, X02A, X02B, X02C, X02D, X02E, X02E, X02F };
                if (X030 == true) userLantern17.LanternBackground = Color.Green;
                else userLantern17.LanternBackground = Color.White;
                if (X031 == true) userLantern18.LanternBackground = Color.Green;
                else userLantern18.LanternBackground = Color.White;
                if (X032 == true) userLantern19.LanternBackground = Color.Green;
                else userLantern19.LanternBackground = Color.White;
                if (X033 == true) userLantern20.LanternBackground = Color.Green;
                else userLantern20.LanternBackground = Color.White;
                if (X034 == true) userLantern21.LanternBackground = Color.Green;
                else userLantern21.LanternBackground = Color.White;
                if (X035 == true) userLantern22.LanternBackground = Color.Green;
                else userLantern22.LanternBackground = Color.White;
                if (X036 == true) userLantern23.LanternBackground = Color.Green;
                else userLantern23.LanternBackground = Color.White;
                if (X037 == true) userLantern24.LanternBackground = Color.Green;
                else userLantern24.LanternBackground = Color.White;
                if (X038 == true) userLantern25.LanternBackground = Color.Green;
                else userLantern25.LanternBackground = Color.White;
                if (X039 == true) userLantern26.LanternBackground = Color.Green;
                else userLantern26.LanternBackground = Color.White;
                if (X03A == true) userLantern27.LanternBackground = Color.Green;
                else userLantern27.LanternBackground = Color.White;
                if (X03B == true) userLantern28.LanternBackground = Color.Green;
                else userLantern28.LanternBackground = Color.White;
                if (X03C == true) userLantern29.LanternBackground = Color.Green;
                else userLantern29.LanternBackground = Color.White;
                if (X03D == true) userLantern30.LanternBackground = Color.Green;
                else userLantern30.LanternBackground = Color.White;
                if (X03E == true) userLantern31.LanternBackground = Color.Green;
                else userLantern31.LanternBackground = Color.White;
                if (X03F == true) userLantern32.LanternBackground = Color.Green;
                else userLantern32.LanternBackground = Color.White;
            }
            else
            {
                timer1.Enabled = false;
                //失败读取，显示失败信息
                MessageBox.Show(read.ToMessageShowString());
                
            }
        }
        private void X40_X4F()
        {
            // X100-X10F读取显示
            OperateResult<bool[]> read = melsec_net.ReadBool("X40", 16);
            if (read.IsSuccess)
            {
                // 成功读取，True代表通，False代表不通
                bool X040 = read.Content[0];
                bool X041 = read.Content[1];
                bool X042 = read.Content[2];
                bool X043 = read.Content[3];
                bool X044 = read.Content[4];
                bool X045 = read.Content[5];
                bool X046 = read.Content[6];
                bool X047 = read.Content[7];
                bool X048 = read.Content[8];
                bool X049 = read.Content[9];
                bool X04A = read.Content[10];
                bool X04B = read.Content[11];
                bool X04C = read.Content[12];
                bool X04D = read.Content[13];
                bool X04E = read.Content[14];
                bool X04F = read.Content[15];
                // 显示
                //bool[] X020_X02F = { X020, X021, X022, X023, X024, X025, X026, X027, X028, X029, X02A, X02B, X02C, X02D, X02E, X02E, X02F };
                if (X040 == true) userLantern33.LanternBackground = Color.Green;
                else userLantern33.LanternBackground = Color.White;
                if (X041 == true) userLantern34.LanternBackground = Color.Green;
                else userLantern34.LanternBackground = Color.White;
                if (X042 == true) userLantern35.LanternBackground = Color.Green;
                else userLantern35.LanternBackground = Color.White;
                if (X043 == true) userLantern36.LanternBackground = Color.Green;
                else userLantern36.LanternBackground = Color.White;
                if (X044 == true) userLantern37.LanternBackground = Color.Green;
                else userLantern37.LanternBackground = Color.White;
                if (X045 == true) userLantern38.LanternBackground = Color.Green;
                else userLantern38.LanternBackground = Color.White;
                if (X046 == true) userLantern39.LanternBackground = Color.Green;
                else userLantern39.LanternBackground = Color.White;
                if (X047 == true) userLantern40.LanternBackground = Color.Green;
                else userLantern40.LanternBackground = Color.White;
                if (X048 == true) userLantern41.LanternBackground = Color.Green;
                else userLantern41.LanternBackground = Color.White;
                if (X049 == true) userLantern42.LanternBackground = Color.Green;
                else userLantern42.LanternBackground = Color.White;
                if (X04A == true) userLantern43.LanternBackground = Color.Green;
                else userLantern43.LanternBackground = Color.White;
                if (X04B == true) userLantern44.LanternBackground = Color.Green;
                else userLantern44.LanternBackground = Color.White;
                if (X04C == true) userLantern45.LanternBackground = Color.Green;
                else userLantern45.LanternBackground = Color.White;
                if (X04D == true) userLantern46.LanternBackground = Color.Green;
                else userLantern46.LanternBackground = Color.White;
                if (X04E == true) userLantern47.LanternBackground = Color.Green;
                else userLantern47.LanternBackground = Color.White;
                if (X04F == true) userLantern48.LanternBackground = Color.Green;
                else userLantern48.LanternBackground = Color.White;
            }
            else
            {
                timer1.Enabled = false;
                //失败读取，显示失败信息
                MessageBox.Show(read.ToMessageShowString());
                
            }
        }
        private void X50_X5F()
        {
            // X100-X10F读取显示
            OperateResult<bool[]> read = melsec_net.ReadBool("X50", 16);
            if (read.IsSuccess)
            {
                // 成功读取，True代表通，False代表不通
                bool X050 = read.Content[0];
                bool X051 = read.Content[1];
                bool X052 = read.Content[2];
                bool X053 = read.Content[3];
                bool X054 = read.Content[4];
                bool X055 = read.Content[5];
                bool X056 = read.Content[6];
                bool X057 = read.Content[7];
                bool X058 = read.Content[8];
                bool X059 = read.Content[9];
                bool X05A = read.Content[10];
                bool X05B = read.Content[11];
                bool X05C = read.Content[12];
                bool X05D = read.Content[13];
                bool X05E = read.Content[14];
                bool X05F = read.Content[15];

                // 显示
                //bool[] X020_X02F = { X020, X021, X022, X023, X024, X025, X026, X027, X028, X029, X02A, X02B, X02C, X02D, X02E, X02E, X02F };
                if (X050 == true) userLantern49.LanternBackground = Color.Green;
                else userLantern49.LanternBackground = Color.White;
                if (X051 == true) userLantern50.LanternBackground = Color.Green;
                else userLantern50.LanternBackground = Color.White;
                if (X052 == true) userLantern51.LanternBackground = Color.Green;
                else userLantern51.LanternBackground = Color.White;
                if (X053 == true) userLantern52.LanternBackground = Color.Green;
                else userLantern52.LanternBackground = Color.White;
                if (X054 == true) userLantern53.LanternBackground = Color.Green;
                else userLantern53.LanternBackground = Color.White;
                if (X055 == true) userLantern54.LanternBackground = Color.Green;
                else userLantern54.LanternBackground = Color.White;
                if (X056 == true) userLantern55.LanternBackground = Color.Green;
                else userLantern55.LanternBackground = Color.White;
                if (X057 == true) userLantern56.LanternBackground = Color.Green;
                else userLantern56.LanternBackground = Color.White;
                if (X058 == true) userLantern57.LanternBackground = Color.Green;
                else userLantern57.LanternBackground = Color.White;
                if (X059 == true) userLantern58.LanternBackground = Color.Green;
                else userLantern58.LanternBackground = Color.White;
                if (X05A == true) userLantern59.LanternBackground = Color.Green;
                else userLantern59.LanternBackground = Color.White;
                if (X05B == true) userLantern60.LanternBackground = Color.Green;
                else userLantern60.LanternBackground = Color.White;
                if (X05C == true) userLantern61.LanternBackground = Color.Green;
                else userLantern61.LanternBackground = Color.White;
                if (X05D == true) userLantern62.LanternBackground = Color.Green;
                else userLantern62.LanternBackground = Color.White;
                if (X05E == true) userLantern63.LanternBackground = Color.Green;
                else userLantern63.LanternBackground = Color.White;
                if (X05F == true) userLantern64.LanternBackground = Color.Green;
                else userLantern64.LanternBackground = Color.White;
            }
            else
            {
                timer1.Enabled = false;
                //失败读取，显示失败信息
                MessageBox.Show(read.ToMessageShowString());
                
            }
        }
        private void X60_X6F()
        {
            // X100-X10F读取显示
            OperateResult<bool[]> read = melsec_net.ReadBool("X60", 16);
            if (read.IsSuccess)
            {
                // 成功读取，True代表通，False代表不通
                bool X060 = read.Content[0];
                bool X061 = read.Content[1];
                bool X062 = read.Content[2];
                bool X063 = read.Content[3];
                bool X064 = read.Content[4];
                bool X065 = read.Content[5];
                bool X066 = read.Content[6];
                bool X067 = read.Content[7];
                bool X068 = read.Content[8];
                bool X069 = read.Content[9];
                bool X06A = read.Content[10];
                bool X06B = read.Content[11];
                bool X06C = read.Content[12];
                bool X06D = read.Content[13];
                bool X06E = read.Content[14];
                bool X06F = read.Content[15];

                // 显示
                //bool[] X020_X02F = { X020, X021, X022, X023, X024, X025, X026, X027, X028, X029, X02A, X02B, X02C, X02D, X02E, X02E, X02F };
                if (X060 == true) userLantern65.LanternBackground = Color.Green;
                else userLantern65.LanternBackground = Color.White;
                if (X061 == true) userLantern66.LanternBackground = Color.Green;
                else userLantern66.LanternBackground = Color.White;
                if (X062 == true) userLantern67.LanternBackground = Color.Green;
                else userLantern67.LanternBackground = Color.White;
                if (X063 == true) userLantern68.LanternBackground = Color.Green;
                else userLantern68.LanternBackground = Color.White;
                if (X064 == true) userLantern69.LanternBackground = Color.Green;
                else userLantern69.LanternBackground = Color.White;
                if (X065 == true) userLantern70.LanternBackground = Color.Green;
                else userLantern70.LanternBackground = Color.White;
                if (X066 == true) userLantern71.LanternBackground = Color.Green;
                else userLantern71.LanternBackground = Color.White;
                if (X067 == true) userLantern72.LanternBackground = Color.Green;
                else userLantern72.LanternBackground = Color.White;
                if (X068 == true) userLantern73.LanternBackground = Color.Green;
                else userLantern73.LanternBackground = Color.White;
                if (X069 == true) userLantern74.LanternBackground = Color.Green;
                else userLantern74.LanternBackground = Color.White;
                if (X06A == true) userLantern75.LanternBackground = Color.Green;
                else userLantern75.LanternBackground = Color.White;
                if (X06B == true) userLantern76.LanternBackground = Color.Green;
                else userLantern76.LanternBackground = Color.White;
                if (X06C == true) userLantern77.LanternBackground = Color.Green;
                else userLantern77.LanternBackground = Color.White;
                if (X06D == true) userLantern78.LanternBackground = Color.Green;
                else userLantern78.LanternBackground = Color.White;
                if (X06E == true) userLantern79.LanternBackground = Color.Green;
                else userLantern79.LanternBackground = Color.White;
                if (X06F == true) userLantern80.LanternBackground = Color.Green;
                else userLantern80.LanternBackground = Color.White;
            }
            else
            {
                timer1.Enabled = false;
                //失败读取，显示失败信息
                MessageBox.Show(read.ToMessageShowString());
                
            }
        }
        private void X70_X7F()
        {
            // X100-X10F读取显示
            OperateResult<bool[]> read = melsec_net.ReadBool("X70", 16);
            if (read.IsSuccess)
            {
                // 成功读取，True代表通，False代表不通
                bool X070 = read.Content[0];
                bool X071 = read.Content[1];
                bool X072 = read.Content[2];
                bool X073 = read.Content[3];
                bool X074 = read.Content[4];
                bool X075 = read.Content[5];
                bool X076 = read.Content[6];
                bool X077 = read.Content[7];
                bool X078 = read.Content[8];
                bool X079 = read.Content[9];
                bool X07A = read.Content[10];
                bool X07B = read.Content[11];
                bool X07C = read.Content[12];
                bool X07D = read.Content[13];
                bool X07E = read.Content[14];
                bool X07F = read.Content[15];
                // 显示
                //bool[] X020_X02F = { X020, X021, X022, X023, X024, X025, X026, X027, X028, X029, X02A, X02B, X02C, X02D, X02E, X02E, X02F };
                if (X070 == true) userLantern81.LanternBackground = Color.Green;
                else userLantern81.LanternBackground = Color.White;
                if (X071 == true) userLantern82.LanternBackground = Color.Green;
                else userLantern82.LanternBackground = Color.White;
                if (X072 == true) userLantern83.LanternBackground = Color.Green;
                else userLantern83.LanternBackground = Color.White;
                if (X073 == true) userLantern84.LanternBackground = Color.Green;
                else userLantern84.LanternBackground = Color.White;
                if (X074 == true) userLantern85.LanternBackground = Color.Green;
                else userLantern85.LanternBackground = Color.White;
                if (X075 == true) userLantern86.LanternBackground = Color.Green;
                else userLantern86.LanternBackground = Color.White;
                if (X076 == true) userLantern87.LanternBackground = Color.Green;
                else userLantern87.LanternBackground = Color.White;
                if (X077 == true) userLantern88.LanternBackground = Color.Green;
                else userLantern88.LanternBackground = Color.White;
                if (X078 == true) userLantern89.LanternBackground = Color.Green;
                else userLantern89.LanternBackground = Color.White;
                if (X079 == true) userLantern90.LanternBackground = Color.Green;
                else userLantern90.LanternBackground = Color.White;
                if (X07A == true) userLantern91.LanternBackground = Color.Green;
                else userLantern91.LanternBackground = Color.White;
                if (X07B == true) userLantern92.LanternBackground = Color.Green;
                else userLantern92.LanternBackground = Color.White;
                if (X07C == true) userLantern93.LanternBackground = Color.Green;
                else userLantern93.LanternBackground = Color.White;
                if (X07D == true) userLantern94.LanternBackground = Color.Green;
                else userLantern94.LanternBackground = Color.White;
                if (X07E == true) userLantern95.LanternBackground = Color.Green;
                else userLantern95.LanternBackground = Color.White;
                if (X07F == true) userLantern96.LanternBackground = Color.Green;
                else userLantern96.LanternBackground = Color.White;
            }
            else
            {
                timer1.Enabled = false;
                //失败读取，显示失败信息
                MessageBox.Show(read.ToMessageShowString());
                
            }
        }
        private void X80_X8F()
        {
            // X100-X10F读取显示
            OperateResult<bool[]> read = melsec_net.ReadBool("X80", 16);
            if (read.IsSuccess)
            {
                // 成功读取，True代表通，False代表不通
                bool X080 = read.Content[0];
                bool X081 = read.Content[1];
                bool X082 = read.Content[2];
                bool X083 = read.Content[3];
                bool X084 = read.Content[4];
                bool X085 = read.Content[5];
                bool X086 = read.Content[6];
                bool X087 = read.Content[7];
                bool X088 = read.Content[8];
                bool X089 = read.Content[9];
                bool X08A = read.Content[10];
                bool X08B = read.Content[11];
                bool X08C = read.Content[12];
                bool X08D = read.Content[13];
                bool X08E = read.Content[14];
                bool X08F = read.Content[15];
                // 显示
                //bool[] X020_X02F = { X020, X021, X022, X023, X024, X025, X026, X027, X028, X029, X02A, X02B, X02C, X02D, X02E, X02E, X02F };
                if (X080 == true) userLantern97.LanternBackground = Color.Green;
                else userLantern97.LanternBackground = Color.White;
                if (X081 == true) userLantern98.LanternBackground = Color.Green;
                else userLantern98.LanternBackground = Color.White;
                if (X082 == true) userLantern99.LanternBackground = Color.Green;
                else userLantern99.LanternBackground = Color.White;
                if (X083 == true) userLantern100.LanternBackground = Color.Green;
                else userLantern100.LanternBackground = Color.White;
                if (X084 == true) userLantern101.LanternBackground = Color.Green;
                else userLantern101.LanternBackground = Color.White;
                if (X085 == true) userLantern102.LanternBackground = Color.Green;
                else userLantern102.LanternBackground = Color.White;
                if (X086 == true) userLantern103.LanternBackground = Color.Green;
                else userLantern103.LanternBackground = Color.White;
                if (X087 == true) userLantern104.LanternBackground = Color.Green;
                else userLantern104.LanternBackground = Color.White;
                if (X088 == true) userLantern105.LanternBackground = Color.Green;
                else userLantern105.LanternBackground = Color.White;
                if (X089 == true) userLantern106.LanternBackground = Color.Green;
                else userLantern106.LanternBackground = Color.White;
                if (X08A == true) userLantern107.LanternBackground = Color.Green;
                else userLantern107.LanternBackground = Color.White;
                if (X08B == true) userLantern108.LanternBackground = Color.Green;
                else userLantern108.LanternBackground = Color.White;
                if (X08C == true) userLantern109.LanternBackground = Color.Green;
                else userLantern109.LanternBackground = Color.White;
                if (X08D == true) userLantern110.LanternBackground = Color.Green;
                else userLantern110.LanternBackground = Color.White;
                if (X08E == true) userLantern111.LanternBackground = Color.Green;
                else userLantern111.LanternBackground = Color.White;
                if (X08F == true) userLantern112.LanternBackground = Color.Green;
                else userLantern112.LanternBackground = Color.White;
            }
            else
            {
                timer1.Enabled = false;
                //失败读取，显示失败信息
                MessageBox.Show(read.ToMessageShowString());
                
            }
        }
        private void X90_X9F()
        {
            // X100-X10F读取显示
            OperateResult<bool[]> read = melsec_net.ReadBool("X90", 16);
            if (read.IsSuccess)
            {
                // 成功读取，True代表通，False代表不通
                bool X090 = read.Content[0];
                bool X091 = read.Content[1];
                bool X092 = read.Content[2];
                bool X093 = read.Content[3];
                bool X094 = read.Content[4];
                bool X095 = read.Content[5];
                bool X096 = read.Content[6];
                bool X097 = read.Content[7];
                bool X098 = read.Content[8];
                bool X099 = read.Content[9];
                bool X09A = read.Content[10];
                bool X09B = read.Content[11];
                bool X09C = read.Content[12];
                bool X09D = read.Content[13];
                bool X09E = read.Content[14];
                bool X09F = read.Content[15];
                // 显示
                //bool[] X020_X02F = { X020, X021, X022, X023, X024, X025, X026, X027, X028, X029, X02A, X02B, X02C, X02D, X02E, X02E, X02F };
                if (X090 == true) userLantern113.LanternBackground = Color.Green;
                else userLantern113.LanternBackground = Color.White;
                if (X091 == true) userLantern114.LanternBackground = Color.Green;
                else userLantern114.LanternBackground = Color.White;
                if (X092 == true) userLantern115.LanternBackground = Color.Green;
                else userLantern115.LanternBackground = Color.White;
                if (X093 == true) userLantern116.LanternBackground = Color.Green;
                else userLantern116.LanternBackground = Color.White;
                if (X094 == true) userLantern117.LanternBackground = Color.Green;
                else userLantern117.LanternBackground = Color.White;
                if (X095 == true) userLantern118.LanternBackground = Color.Green;
                else userLantern118.LanternBackground = Color.White;
                if (X096 == true) userLantern119.LanternBackground = Color.Green;
                else userLantern119.LanternBackground = Color.White;
                if (X097 == true) userLantern120.LanternBackground = Color.Green;
                else userLantern120.LanternBackground = Color.White;
                if (X098 == true) userLantern121.LanternBackground = Color.Green;
                else userLantern121.LanternBackground = Color.White;
                if (X099 == true) userLantern122.LanternBackground = Color.Green;
                else userLantern122.LanternBackground = Color.White;
                if (X09A == true) userLantern123.LanternBackground = Color.Green;
                else userLantern123.LanternBackground = Color.White;
                if (X09B == true) userLantern124.LanternBackground = Color.Green;
                else userLantern124.LanternBackground = Color.White;
                if (X09C == true) userLantern125.LanternBackground = Color.Green;
                else userLantern125.LanternBackground = Color.White;
                if (X09D == true) userLantern126.LanternBackground = Color.Green;
                else userLantern126.LanternBackground = Color.White;
                if (X09E == true) userLantern127.LanternBackground = Color.Green;
                else userLantern127.LanternBackground = Color.White;
                if (X09F == true) userLantern128.LanternBackground = Color.Green;
                else userLantern128.LanternBackground = Color.White;
            }
            else
            {
                timer1.Enabled = false;
                //失败读取，显示失败信息
                MessageBox.Show(read.ToMessageShowString());
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            X20_X2F();
            X30_X3F();
            X40_X4F();
            X50_X5F();
            X60_X6F();
            X70_X7F();
            X80_X8F();
            X90_X9F();
        }

        #endregion

        #region  PLC强制输出 YA0-YAF
        private void button1_Click(object sender, EventArgs e)// 写入YA0
        {
            if(button1.BackColor==Color.White)
            {
                melsec_net.Write("YA0", new bool[] { true });
                button1.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YA0", new bool[] { false });
                button1.BackColor = Color.White;
            }
            
        }
        private void button2_Click(object sender, EventArgs e)// 写入YA1
        {
            if (button2.BackColor == Color.White)
            {
                melsec_net.Write("YA1", new bool[] { true });
                button2.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YA1", new bool[] { false });
                button2.BackColor = Color.White;
            }
        }
        private void button3_Click(object sender, EventArgs e)// 写入YA2
        {
            if (button3.BackColor == Color.White)
            {
                melsec_net.Write("YA2", new bool[] { true });
                button3.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YA2", new bool[] { false });
                button3.BackColor = Color.White;
            }
        }
        private void button4_Click(object sender, EventArgs e)// 写入YA3
        {
            if (button4.BackColor == Color.White)
            {
                melsec_net.Write("YA3", new bool[] { true });
                button4.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YA3", new bool[] { false });
                button4.BackColor = Color.White;
            }
        }
        private void button5_Click(object sender, EventArgs e)// 写入YA4
        {
            if (button5.BackColor == Color.White)
            {
                melsec_net.Write("YA4", new bool[] { true });
                button5.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YA4", new bool[] { false });
                button5.BackColor = Color.White;
            }
        }
        private void button6_Click(object sender, EventArgs e)// 写入YA5
        {
            if (button6.BackColor == Color.White)
            {
                melsec_net.Write("YA5", new bool[] { true });
                button6.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YA5", new bool[] { false });
                button6.BackColor = Color.White;
            }
        }
        private void button7_Click(object sender, EventArgs e)// 写入YA6
        {
            if (button7.BackColor == Color.White)
            {
                melsec_net.Write("YA6", new bool[] { true });
                button7.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YA6", new bool[] { false });
                button7.BackColor = Color.White;
            }
        }
        private void button8_Click(object sender, EventArgs e)// 写入YA7
        {
            if (button8.BackColor == Color.White)
            {
                melsec_net.Write("YA7", new bool[] { true });
                button8.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YA7", new bool[] { false });
                button8.BackColor = Color.White;
            }
        }
        private void button9_Click(object sender, EventArgs e)// 写入YA8
        {
            if (button9.BackColor == Color.White)
            {
                melsec_net.Write("YA8", new bool[] { true });
                button9.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YA8", new bool[] { false });
                button9.BackColor = Color.White;
            }
        }
        private void button10_Click(object sender, EventArgs e)// 写入YA9
        {
            if (button10.BackColor == Color.White)
            {
                melsec_net.Write("YA9", new bool[] { true });
                button10.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YA9", new bool[] { false });
                button10.BackColor = Color.White;
            }
        }
        private void button11_Click(object sender, EventArgs e)// 写入YAA
        {
            if (button11.BackColor == Color.White)
            {
                melsec_net.Write("YAA", new bool[] { true });
                button11.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YAA", new bool[] { false });
                button11.BackColor = Color.White;
            }
        }
        private void button12_Click(object sender, EventArgs e)// 写入YAB
        {
            if (button12.BackColor == Color.White)
            {
                melsec_net.Write("YAB", new bool[] { true });
                button12.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YAB", new bool[] { false });
                button12.BackColor = Color.White;
            }
        }
        private void button13_Click(object sender, EventArgs e)// 写入YAC
        {
            if (button13.BackColor == Color.White)
            {
                melsec_net.Write("YAC", new bool[] { true });
                button13.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YAC", new bool[] { false });
                button13.BackColor = Color.White;
            }
        }
        private void button14_Click(object sender, EventArgs e)// 写入YAD
        {
            if (button14.BackColor == Color.White)
            {
                melsec_net.Write("YAD", new bool[] { true });
                button14.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YAD", new bool[] { false });
                button14.BackColor = Color.White;
            }
        }
        private void button15_Click(object sender, EventArgs e)// 写入YAE
        {
            if (button15.BackColor == Color.White)
            {
                melsec_net.Write("YAE", new bool[] { true });
                button15.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YAE", new bool[] { false });
                button15.BackColor = Color.White;
            }
        }
        private void button16_Click(object sender, EventArgs e)// 写入YAF
        {
            if (button16.BackColor == Color.White)
            {
                melsec_net.Write("YAF", new bool[] { true });
                button16.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YAF", new bool[] { false });
                button16.BackColor = Color.White;
            }
        }


        #endregion

        #region  PLC强制输出 YB0-YBF
        private void button17_Click(object sender, EventArgs e)// 写入YB0
        {
            if (button17.BackColor == Color.White)
            {
                melsec_net.Write("YB0", new bool[] { true });
                button17.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YB0", new bool[] { false });
                button17.BackColor = Color.White;
            }
        }
        private void button18_Click(object sender, EventArgs e)// 写入YB1
        {
            if (button18.BackColor == Color.White)
            {
                melsec_net.Write("YB1", new bool[] { true });
                button18.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YB1", new bool[] { false });
                button18.BackColor = Color.White;
            }
        }
        private void button19_Click(object sender, EventArgs e)// 写入YB2
        {
            if (button19.BackColor == Color.White)
            {
                melsec_net.Write("YB2", new bool[] { true });
                button19.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YB2", new bool[] { false });
                button19.BackColor = Color.White;
            }
        }
        private void button20_Click(object sender, EventArgs e)// 写入YB3
        {
            if (button20.BackColor == Color.White)
            {
                melsec_net.Write("YB3", new bool[] { true });
                button20.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YB3", new bool[] { false });
                button20.BackColor = Color.White;
            }
        }
        private void button21_Click(object sender, EventArgs e)// 写入YB4
        {
            if (button21.BackColor == Color.White)
            {
                melsec_net.Write("YB4", new bool[] { true });
                button21.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YB4", new bool[] { false });
                button21.BackColor = Color.White;
            }
        }
        private void button22_Click(object sender, EventArgs e)// 写入YB5
        {
            if (button22.BackColor == Color.White)
            {
                melsec_net.Write("YB5", new bool[] { true });
                button22.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YB5", new bool[] { false });
                button22.BackColor = Color.White;
            }
        }
        private void button23_Click(object sender, EventArgs e)// 写入YB6
        {
            if (button23.BackColor == Color.White)
            {
                melsec_net.Write("YB6", new bool[] { true });
                button23.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YB6", new bool[] { false });
                button23.BackColor = Color.White;
            }
        }
        private void button24_Click(object sender, EventArgs e)// 写入YB7
        {
            if (button24.BackColor == Color.White)
            {
                melsec_net.Write("YB7", new bool[] { true });
                button24.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YB7", new bool[] { false });
                button24.BackColor = Color.White;
            }
        }
        private void button25_Click(object sender, EventArgs e)// 写入YB8
        {
            if (button25.BackColor == Color.White)
            {
                melsec_net.Write("YB8", new bool[] { true });
                button25.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YB8", new bool[] { false });
                button25.BackColor = Color.White;
            }
        }
        private void button26_Click(object sender, EventArgs e)// 写入YB9
        {
            if (button26.BackColor == Color.White)
            {
                melsec_net.Write("YB9", new bool[] { true });
                button26.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YB9", new bool[] { false });
                button26.BackColor = Color.White;
            }
        }
        private void button27_Click(object sender, EventArgs e)// 写入YBA
        {
            if (button27.BackColor == Color.White)
            {
                melsec_net.Write("YBA", new bool[] { true });
                button27.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YBA", new bool[] { false });
                button27.BackColor = Color.White;
            }
        }
        private void button28_Click(object sender, EventArgs e)// 写入YBB
        {
            if (button28.BackColor == Color.White)
            {
                melsec_net.Write("YBB", new bool[] { true });
                button28.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YBB", new bool[] { false });
                button28.BackColor = Color.White;
            }
        }
        private void button29_Click(object sender, EventArgs e)// 写入YBC
        {
            if (button29.BackColor == Color.White)
            {
                melsec_net.Write("YBC", new bool[] { true });
                button29.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YBC", new bool[] { false });
                button29.BackColor = Color.White;
            }
        }
        private void button30_Click(object sender, EventArgs e)// 写入YBD
        {
            if (button30.BackColor == Color.White)
            {
                melsec_net.Write("YBD", new bool[] { true });
                button30.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YBD", new bool[] { false });
                button30.BackColor = Color.White;
            }
        }
        private void button31_Click(object sender, EventArgs e)// 写入YBE
        {
            if (button31.BackColor == Color.White)
            {
                melsec_net.Write("YBE", new bool[] { true });
                button31.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YBE", new bool[] { false });
                button31.BackColor = Color.White;
            }
        }
        private void button32_Click(object sender, EventArgs e)// 写入YBF
        {
            if (button32.BackColor == Color.White)
            {
                melsec_net.Write("YBF", new bool[] { true });
                button32.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YBF", new bool[] { false });
                button32.BackColor = Color.White;
            }
        }

        #endregion

        #region  PLC强制输出 YC0-YCF
        private void button33_Click(object sender, EventArgs e)// 写入YC0
        {
            if (button33.BackColor == Color.White)
            {
                melsec_net.Write("YC0", new bool[] { true });
                button33.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YC0", new bool[] { false });
                button33.BackColor = Color.White;
            }
        }
        private void button34_Click(object sender, EventArgs e)// 写入YC1
        {
            if (button34.BackColor == Color.White)
            {
                melsec_net.Write("YC1", new bool[] { true });
                button34.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YC1", new bool[] { false });
                button34.BackColor = Color.White;
            }
        }
        private void button35_Click(object sender, EventArgs e)// 写入YC2
        {
            if (button35.BackColor == Color.White)
            {
                melsec_net.Write("YC2", new bool[] { true });
                button35.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YC2", new bool[] { false });
                button35.BackColor = Color.White;
            }
        }
        private void button36_Click(object sender, EventArgs e)// 写入YC3
        {
            if (button36.BackColor == Color.White)
            {
                melsec_net.Write("YC3", new bool[] { true });
                button36.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YC3", new bool[] { false });
                button36.BackColor = Color.White;
            }
        }
        private void button37_Click(object sender, EventArgs e)// 写入YC4
        {
            if (button37.BackColor == Color.White)
            {
                melsec_net.Write("YC4", new bool[] { true });
                button37.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YC4", new bool[] { false });
                button37.BackColor = Color.White;
            }
        }
        private void button38_Click(object sender, EventArgs e)// 写入YC5
        {
            if (button38.BackColor == Color.White)
            {
                melsec_net.Write("YC5", new bool[] { true });
                button38.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YC5", new bool[] { false });
                button38.BackColor = Color.White;
            }
        }
        private void button39_Click(object sender, EventArgs e)// 写入YC6
        {
            if (button39.BackColor == Color.White)
            {
                melsec_net.Write("YC6", new bool[] { true });
                button39.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YC6", new bool[] { false });
                button39.BackColor = Color.White;
            }
        }
        private void button40_Click(object sender, EventArgs e)// 写入YC7
        {
            if (button40.BackColor == Color.White)
            {
                melsec_net.Write("YC7", new bool[] { true });
                button40.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YC7", new bool[] { false });
                button40.BackColor = Color.White;
            }
        }
        private void button41_Click(object sender, EventArgs e)// 写入YC8
        {
            if (button41.BackColor == Color.White)
            {
                melsec_net.Write("YC8", new bool[] { true });
                button41.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YC8", new bool[] { false });
                button41.BackColor = Color.White;
            }
        }
        private void button42_Click(object sender, EventArgs e)// 写入YC9
        {
            if (button42.BackColor == Color.White)
            {
                melsec_net.Write("YC9", new bool[] { true });
                button42.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YC9", new bool[] { false });
                button42.BackColor = Color.White;
            }
        }
        private void button43_Click(object sender, EventArgs e)// 写入YCA
        {
            if (button43.BackColor == Color.White)
            {
                melsec_net.Write("YCA", new bool[] { true });
                button43.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YCA", new bool[] { false });
                button43.BackColor = Color.White;
            }
        }
        private void button44_Click(object sender, EventArgs e)// 写入YCB
        {
            if (button44.BackColor == Color.White)
            {
                melsec_net.Write("YCB", new bool[] { true });
                button44.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YCB", new bool[] { false });
                button44.BackColor = Color.White;
            }
        }
        private void button45_Click(object sender, EventArgs e)// 写入YCC
        {
            if (button45.BackColor == Color.White)
            {
                melsec_net.Write("YCC", new bool[] { true });
                button45.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YCC", new bool[] { false });
                button45.BackColor = Color.White;
            }
        }
        private void button46_Click(object sender, EventArgs e)// 写入YCD
        {
            if (button46.BackColor == Color.White)
            {
                melsec_net.Write("YCD", new bool[] { true });
                button46.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YCD", new bool[] { false });
                button46.BackColor = Color.White;
            }
        }
        private void button47_Click(object sender, EventArgs e)// 写入YCE
        {
            if (button47.BackColor == Color.White)
            {
                melsec_net.Write("YCE", new bool[] { true });
                button47.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YCE", new bool[] { false });
                button47.BackColor = Color.White;
            }
        }
        private void button48_Click(object sender, EventArgs e)// 写入YCF
        {
            if (button48.BackColor == Color.White)
            {
                melsec_net.Write("YCF", new bool[] { true });
                button48.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YCF", new bool[] { false });
                button48.BackColor = Color.White;
            }
        }
        #endregion

        #region  PLC强制输出 YD0-YDF
        private void button49_Click(object sender, EventArgs e)// 写入YD0
        {
            if (button49.BackColor == Color.White)
            {
                melsec_net.Write("YD0", new bool[] { true });
                button49.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YD0", new bool[] { false });
                button49.BackColor = Color.White;
            }
        }
        private void button50_Click(object sender, EventArgs e)// 写入YD1
        {
            if (button50.BackColor == Color.White)
            {
                melsec_net.Write("YD1", new bool[] { true });
                button50.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YD1", new bool[] { false });
                button50.BackColor = Color.White;
            }
        }
        private void button51_Click(object sender, EventArgs e)// 写入YD2
        {
            if (button51.BackColor == Color.White)
            {
                melsec_net.Write("YD2", new bool[] { true });
                button51.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YD2", new bool[] { false });
                button51.BackColor = Color.White;
            }
        }
        private void button52_Click(object sender, EventArgs e)// 写入YD3
        {
            if (button52.BackColor == Color.White)
            {
                melsec_net.Write("YD3", new bool[] { true });
                button52.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YD3", new bool[] { false });
                button52.BackColor = Color.White;
            }
        }
        private void button53_Click(object sender, EventArgs e)// 写入YD4
        {
            if (button53.BackColor == Color.White)
            {
                melsec_net.Write("YD4", new bool[] { true });
                button53.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YD4", new bool[] { false });
                button53.BackColor = Color.White;
            }
        }
        private void button54_Click(object sender, EventArgs e)// 写入YD5
        {
            if (button54.BackColor == Color.White)
            {
                melsec_net.Write("YD5", new bool[] { true });
                button54.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YD5", new bool[] { false });
                button54.BackColor = Color.White;
            }
        }
        private void button55_Click(object sender, EventArgs e)// 写入YD6
        {
            if (button55.BackColor == Color.White)
            {
                melsec_net.Write("YD6", new bool[] { true });
                button55.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YD6", new bool[] { false });
                button55.BackColor = Color.White;
            }
        }
        private void button56_Click(object sender, EventArgs e)// 写入YD7
        {
            if (button56.BackColor == Color.White)
            {
                melsec_net.Write("YD7", new bool[] { true });
                button56.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YD7", new bool[] { false });
                button56.BackColor = Color.White;
            }
        }
        private void button57_Click(object sender, EventArgs e)// 写入YD8
        {
            if (button57.BackColor == Color.White)
            {
                melsec_net.Write("YD8", new bool[] { true });
                button57.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YD8", new bool[] { false });
                button57.BackColor = Color.White;
            }
        }
        private void button58_Click(object sender, EventArgs e)// 写入YD9
        {
            if (button58.BackColor == Color.White)
            {
                melsec_net.Write("YD9", new bool[] { true });
                button58.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YD9", new bool[] { false });
                button58.BackColor = Color.White;
            }
        }
        private void button59_Click(object sender, EventArgs e)// 写入YDA
        {
            if (button59.BackColor == Color.White)
            {
                melsec_net.Write("YDA", new bool[] { true });
                button59.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YDA", new bool[] { false });
                button59.BackColor = Color.White;
            }
        }
        private void button60_Click(object sender, EventArgs e)// 写入YDB
        {
            if (button60.BackColor == Color.White)
            {
                melsec_net.Write("YDB", new bool[] { true });
                button60.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YDB", new bool[] { false });
                button60.BackColor = Color.White;
            }
        }
        private void button61_Click(object sender, EventArgs e)// 写入YDC
        {
            if (button61.BackColor == Color.White)
            {
                melsec_net.Write("YDC", new bool[] { true });
                button61.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YDC", new bool[] { false });
                button61.BackColor = Color.White;
            }
        }
        private void button62_Click(object sender, EventArgs e)// 写入YDD
        {
            if (button62.BackColor == Color.White)
            {
                melsec_net.Write("YDD", new bool[] { true });
                button62.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YDD", new bool[] { false });
                button62.BackColor = Color.White;
            }
        }
        private void button63_Click(object sender, EventArgs e)// 写入YDE
        {
            if (button63.BackColor == Color.White)
            {
                melsec_net.Write("YDE", new bool[] { true });
                button63.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YDE", new bool[] { false });
                button63.BackColor = Color.White;
            }
        }
        private void button64_Click(object sender, EventArgs e)// 写入YDF
        {
            if (button64.BackColor == Color.White)
            {
                melsec_net.Write("YDF", new bool[] { true });
                button64.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YDF", new bool[] { false });
                button64.BackColor = Color.White;
            }
        }
        #endregion

        #region  PLC强制输出 YE0-YEF

        private void button65_Click(object sender, EventArgs e)// 写入YE0
        {
            if (button65.BackColor == Color.White)
            {
                melsec_net.Write("YE0", new bool[] { true });
                button65.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YE0", new bool[] { false });
                button65.BackColor = Color.White;
            }
        }
        private void button66_Click(object sender, EventArgs e)// 写入YE1
        {
            if (button66.BackColor == Color.White)
            {
                melsec_net.Write("YE1", new bool[] { true });
                button66.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YE1", new bool[] { false });
                button66.BackColor = Color.White;
            }
        }
        private void button67_Click(object sender, EventArgs e)// 写入YE2
        {
            if (button67.BackColor == Color.White)
            {
                melsec_net.Write("YE2", new bool[] { true });
                button67.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YE2", new bool[] { false });
                button67.BackColor = Color.White;
            }
        }
        private void button68_Click(object sender, EventArgs e)// 写入YE3
        {
            if (button68.BackColor == Color.White)
            {
                melsec_net.Write("YE3", new bool[] { true });
                button68.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YE3", new bool[] { false });
                button68.BackColor = Color.White;
            }
        }
        private void button69_Click(object sender, EventArgs e)// 写入YE4
        {
            if (button69.BackColor == Color.White)
            {
                melsec_net.Write("YE4", new bool[] { true });
                button69.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YE4", new bool[] { false });
                button69.BackColor = Color.White;
            }
        }
        private void button70_Click(object sender, EventArgs e)// 写入YE5
        {
            if (button70.BackColor == Color.White)
            {
                melsec_net.Write("YE5", new bool[] { true });
                button70.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YE5", new bool[] { false });
                button70.BackColor = Color.White;
            }
        }
        private void button71_Click(object sender, EventArgs e)// 写入YE6
        {
            if (button71.BackColor == Color.White)
            {
                melsec_net.Write("YE6", new bool[] { true });
                button71.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YE6", new bool[] { false });
                button71.BackColor = Color.White;
            }
        }
        private void button72_Click(object sender, EventArgs e)// 写入YE7
        {
            if (button72.BackColor == Color.White)
            {
                melsec_net.Write("YE7", new bool[] { true });
                button72.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YE7", new bool[] { false });
                button72.BackColor = Color.White;
            }
        }
        private void button73_Click(object sender, EventArgs e)// 写入YE8
        {
            if (button73.BackColor == Color.White)
            {
                melsec_net.Write("YE8", new bool[] { true });
                button73.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YE8", new bool[] { false });
                button73.BackColor = Color.White;
            }
        }
        private void button74_Click(object sender, EventArgs e)// 写入YE9
        {
            if (button74.BackColor == Color.White)
            {
                melsec_net.Write("YE9", new bool[] { true });
                button74.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YE9", new bool[] { false });
                button74.BackColor = Color.White;
            }
        }
        private void button75_Click(object sender, EventArgs e)// 写入YEA
        {
            if (button75.BackColor == Color.White)
            {
                melsec_net.Write("YEA", new bool[] { true });
                button75.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YEA", new bool[] { false });
                button75.BackColor = Color.White;
            }
        }
        private void button76_Click(object sender, EventArgs e)// 写入YEB
        {
            if (button76.BackColor == Color.White)
            {
                melsec_net.Write("YEB", new bool[] { true });
                button76.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YEB", new bool[] { false });
                button76.BackColor = Color.White;
            }
        }
        private void button77_Click(object sender, EventArgs e)// 写入YEC
        {
            if (button77.BackColor == Color.White)
            {
                melsec_net.Write("YEC", new bool[] { true });
                button77.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YEC", new bool[] { false });
                button77.BackColor = Color.White;
            }
        }
        private void button78_Click(object sender, EventArgs e)// 写入YED
        {
            if (button78.BackColor == Color.White)
            {
                melsec_net.Write("YED", new bool[] { true });
                button78.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YED", new bool[] { false });
                button78.BackColor = Color.White;
            }
        }
        private void button79_Click(object sender, EventArgs e)// 写入YEE
        {
            if (button79.BackColor == Color.White)
            {
                melsec_net.Write("YEE", new bool[] { true });
                button79.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YEE", new bool[] { false });
                button79.BackColor = Color.White;
            }
        }
        private void button80_Click(object sender, EventArgs e)// 写入YEF
        {
            if (button80.BackColor == Color.White)
            {
                melsec_net.Write("YEF", new bool[] { true });
                button80.BackColor = Color.Red;
            }
            else
            {
                melsec_net.Write("YEF", new bool[] { false });
                button80.BackColor = Color.White;
            }
        }



        #endregion

    }
}
