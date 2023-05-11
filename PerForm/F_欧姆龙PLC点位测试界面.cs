using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Profinet.Omron;  //欧姆龙使用
using System.Windows.Forms;
using System.Threading;

namespace PLC点位_IO测试系统软件.PerForm
{
    public partial class F_欧姆龙PLC点位测试界面 : Form
    {
        public F_欧姆龙PLC点位测试界面()
        {
            InitializeComponent();
            f = 0;//初始化值 操作盒通讯测试用
        }

        #region  设备通讯实例化
        private OmronHostLinkCMode OmronHostLinkCMode = new OmronHostLinkCMode(); //实例化控制板CMode 
        private OmronHostLink OmronHostLink = new OmronHostLink(); //实例化欧姆龙PLC 使用232端口通讯
        #endregion

        #region  全局变量
        private int a;//公共测试变量
        private int f;//公共测试变量
        private string b;//公共测试变量
        private string b1;//公共测试变量
        private string b2;//公共测试变量
        private string c;//升降横移车台
        private string c1;//10A
        private string c2;//YxYy
        private string c3;//UVWxy
        private int sec;//公共测试变量
        private int a_fit_pc;//公共测试变量
        private int a_fit_plc;//公共测试变量
        private int test_bit;

        private char[] arrD0_SPPB;//公共测试变量 10进制转2进制 分解为位
        private char[] arrD1_SPPB;//公共测试变量 10进制转2进制 分解为位
        private char[] arrCIO0_PLC;//公共测试变量 10进制转2进制 分解为位
        private char[] arrCIO1_PLC;//公共测试变量 10进制转2进制 分解为位
        private char[] arrCIO2_PLC;//公共测试变量 10进制转2进制 分解为位
        private char[] arrCIO3_PLC;//公共测试变量 10进制转2进制 分解为位
        private char[] arrCIO4_PLC;//公共测试变量 10进制转2进制 分解为位
        private char[] arrCIO5_PLC;//公共测试变量 10进制转2进制 分解为位
        private char[] arrCIO6_PLC;//公共测试变量 10进制转2进制 分解为位
        //private int int_arr;//读取总位数 
        #endregion

        #region  事假发生处理
        private void F_欧姆龙PLC点位测试界面_Load(object sender, EventArgs e)
        {
            lab_treaty_number.Text = Program.Treaty_Number;
            lab_project_name.Text = Program.Project_Name;
            lab_username.Text = Program.Username;
        }

        private void timer1_Tick(object sender, EventArgs e)//系统时间累计计时
        {
            lab_Time.Text = DateTime.Now.ToLocalTime().ToString();
        }

        private void F_汇川PLC点位测试界面_FormClosing(object sender, FormClosingEventArgs e)//界面关闭时发生
        {
            OmronHostLinkCMode.Close();
            OmronHostLink.Close();
        }
        #endregion

        #region  联数数据改变时发生
        private void com_Location_link_number_TextChanged(object sender, EventArgs e)//总联数发生改变时
        {
            //获取总联数
            int int1 = Convert.ToInt16(com_Location_link_number.Text);



            com_front_number.Text = int1.ToString();
            com_Parking_space.Text = (2 * int1 - 1).ToString();
        }

        private void com_front_number_TextChanged(object sender, EventArgs e)//前排联数发生改变时
        {
            //获取总联数
            int int1 = Convert.ToInt16(com_Location_link_number.Text);
            //前排数量
            int int2 = Convert.ToInt16(com_front_number.Text);

            com_queen_number.Text = (int1 - int2).ToString();

        }

        private void com_queen_number_TextChanged(object sender, EventArgs e)//后排联数发生改变时
        {
            //获取总联数
            int int1 = Convert.ToInt16(com_Location_link_number.Text);

            //后排数量
            int int3 = Convert.ToInt16(com_queen_number.Text);

            com_front_number.Text = (int1 - int3).ToString();
        }
        #endregion

        #region  PLC及继电器电路板读取
        private void SPPB_D1_read()//读取电路板D1的值
        {
            short short_D1 = OmronHostLinkCMode.ReadInt16("D1").Content; // 读取电路板D1组成的字
            //十进制转二进制
            string str = Convert.ToString(short_D1, 2).PadLeft(16, '0');
            arrD1_SPPB = str.ToCharArray();
            //int_arr = arr.Length;

        }
        private void SPPB_D0_read()//读取电路板D0的值
        {
            short short_D0 = OmronHostLinkCMode.ReadInt16("D0").Content; // 读取电路板D0组成的字
            //十进制转二进制
            string str = Convert.ToString(short_D0, 2).PadLeft(16, '0');

            arrD0_SPPB = str.ToCharArray();
            //int_arr = arr.Length;

        }

        private void PLC_CIO0_read()//读取PLC CIO0组成的字
        {
            short short_CIO0 = OmronHostLink.ReadInt16("CIO0").Content; // 读取PLC CIO0组成的字
            //十进制转二进制
            string str = Convert.ToString(short_CIO0, 2).PadLeft(12, '0');
            arrCIO0_PLC = str.ToCharArray();
        }
        private void PLC_CIO1_read()//读取PLC CIO0组成的字
        {
            short short_CIO1 = OmronHostLink.ReadInt16("CIO1").Content; // 读取PLC CIO0组成的字
            //十进制转二进制
            string str = Convert.ToString(short_CIO1, 2).PadLeft(12, '0');
            arrCIO1_PLC = str.ToCharArray();
        }
        private void PLC_CIO2_read()//读取PLC CIO0组成的字
        {
            short short_CIO2 = OmronHostLink.ReadInt16("CIO2").Content; // 读取PLC CIO0组成的字
            //十进制转二进制
            string str = Convert.ToString(short_CIO2, 2).PadLeft(12, '0');
            arrCIO2_PLC = str.ToCharArray();
        }
        private void PLC_CIO3_read()//读取PLC CIO0组成的字
        {
            short short_CIO3 = OmronHostLink.ReadInt16("CIO3").Content; // 读取PLC CIO0组成的字
            //十进制转二进制
            string str = Convert.ToString(short_CIO3, 2).PadLeft(12, '0');
            arrCIO3_PLC = str.ToCharArray();
        }
        private void PLC_CIO4_read()//读取PLC CIO0组成的字
        {
            short short_CIO4 = OmronHostLink.ReadInt16("CIO4").Content; // 读取PLC CIO0组成的字
            //十进制转二进制
            string str = Convert.ToString(short_CIO4, 2).PadLeft(12, '0');
            arrCIO4_PLC = str.ToCharArray();
        }
        private void PLC_CIO5_read()//读取PLC CIO0组成的字
        {
            short short_CIO5 = OmronHostLink.ReadInt16("CIO5").Content; // 读取PLC CIO0组成的字
            //十进制转二进制
            string str = Convert.ToString(short_CIO5, 2).PadLeft(12, '0');
            arrCIO5_PLC = str.ToCharArray();
        }
        private void PLC_CIO6_read()//读取PLC CIO0组成的字
        {
            short short_CIO6 = OmronHostLink.ReadInt16("CIO6").Content; // 读取PLC CIO0组成的字
            //十进制转二进制
            string str = Convert.ToString(short_CIO6, 2).PadLeft(12, '0');
            arrCIO6_PLC = str.ToCharArray();
        }
        #endregion


        #region  按钮合集
        private void but_Location_recognition_Click(object sender, EventArgs e)//区位信息确认按钮
        {
            if (but_Location_recognition.Text == "确认")
            {
                if (text_Location_number.Text != "" & com_front_number.Text != "" & com_Location_link_number.Text != "" & com_queen_number.Text != "" & com_Parking_space.Text != "")
                {
                    groupBox3.Enabled = false;
                    groupBox2.Visible = true;
                    groupBox2.Enabled = true;

                    but_Location_recognition.Text = "修改";
                    but_Location_recognition.BackColor = Color.Red;
                    //获取当前计算机的串口端口名的数组 并写入到 com串口名的集合（Items）中
                    com_PLCserial_port.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                    com_SPPBserial_port.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                    Program.Location_link_number = com_Location_link_number.Text;//区位联数
                    Program.Location_number = text_Location_number.Text;//区位编号
                    Program.Parking_space = com_Parking_space.Text;//车位数
                    Program.queen_number = com_queen_number.Text;//后排联数
                    Program.front_number = com_front_number.Text;//前排联数
                    if (checkBox1.Checked == true & checkBox2.Checked == false)
                        Program.Yx_Yy = 1;
                    if (checkBox1.Checked == false & checkBox2.Checked == true)
                        Program.Yx_Yy = 2;
                    if (checkBox1.Checked == true & checkBox2.Checked == true)
                        Program.Yx_Yy = 3;
                    timer2.Enabled = false;

                }
                else
                {
                    MessageBox.Show("区位信息输入错误！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                groupBox3.Enabled = true;
                groupBox2.Enabled = false;
                groupBox2.Visible = false;
                but_Location_recognition.Text = "确认";
                but_Location_recognition.BackColor = Color.Green;
                //清除集合中的所有数值
                com_PLCserial_port.Items.Clear();
                com_SPPBserial_port.Items.Clear();

                but_double_deck_1.Visible = false;
                but_double_deck_2.Visible = false;
                but_1L.Visible = false;
                but_2L.Visible = false;
                but_3L.Visible = false;
                but_4L.Visible = false;
                but_5L.Visible = false;
                but_6L.Visible = false;
                but_7L.Visible = false;
                but_8L.Visible = false;
                but_9L.Visible = false;
                but_10L.Visible = false;
                but_11L.Visible = false;
                but_12L.Visible = false;
                but_1L.Enabled = false;
                but_2L.Enabled = false;
                but_3L.Enabled = false;
                but_4L.Enabled = false;
                but_5L.Enabled = false;
                but_6L.Enabled = false;
                but_7L.Enabled = false;
                but_8L.Enabled = false;
                but_9L.Enabled = false;
                but_10L.Enabled = false;
                but_11L.Enabled = false;
                but_12L.Enabled = false;
                but_report_printing.Visible = false;
                groupBox4.Visible = false;
                Program.One_Two = 0;
                //关闭PLC通讯
                OmronHostLink.Close();
                but_PLC_link.Text = "连接";
                but_PLC_link.BackColor = Color.Green;
                //关闭SPBB通讯
                OmronHostLinkCMode.Close();
                but_SPPB_link.Text = "连接";
                but_SPPB_link.BackColor = Color.Green;
            }

        }
        private void but_PLC_link_Click(object sender, EventArgs e)//PLC串口连接按钮
        {
            if (but_PLC_link.Text == "连接")
            {
                try
                {
                    OmronHostLink.SerialPortInni(sp =>
                    {
                        sp.PortName = com_PLCserial_port.Text;
                        sp.BaudRate = 9600;
                        sp.DataBits = 7;
                        sp.StopBits = System.IO.Ports.StopBits.One;
                        sp.Parity = System.IO.Ports.Parity.Even;
                    });
                    OmronHostLink.Open();
                    if (OmronHostLink.IsOpen())
                    {
                        but_PLC_link.Text = "断开";
                        but_PLC_link.BackColor = Color.Red;
                        MessageBox.Show("连接成功");
                    }
                    else
                    {
                        MessageBox.Show("连接失败");
                    }
                }
                catch
                {
                    MessageBox.Show("错误请检查！");
                }

            }
            else
            {
                OmronHostLink.Close();
                but_PLC_link.Text = "连接";
                but_PLC_link.BackColor = Color.Green;
            }

        }
        private void but_verification_Click(object sender, EventArgs e)//通讯测试按钮
        {
            string b001;
            OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, 0));// 写入PC寄存器20
            PLC_CIO0_read();
            Thread.Sleep(100);

            b001 = arrCIO0_PLC[10].ToString();


            timer2.Enabled = true;
            if (b001 == "1")
            {
                ////读取汇川PLC D100的值
                //short int_D100 = InovanceSerial.ReadInt16("D100").Content;
                //label13.Text = int_D100.ToString();
                //short int_D20 = OmronHostLink.ReadInt16("D20").Content;
                //label14.Text = int_D20.ToString();

                //获取总联数
                int int1 = Convert.ToInt16(Program.Location_link_number);
                //int int2 = Convert.ToInt16(Program.Location_link_number);
                //int int3 = Convert.ToInt16(Program.Location_link_number);

                groupBox2.Visible = false;
                groupBox4.Visible = true;
                if (Program.queen_number != "0")
                    but_double_deck_2.Visible = true;
                else
                    but_double_deck_1.Visible = true;

                if (0 < int1 & int1 <= 12)
                    but_1L.Visible = true;
                if (1 < int1 & int1 <= 12)
                    but_2L.Visible = true;
                if (2 < int1 & int1 <= 12)
                    but_3L.Visible = true;
                if (3 < int1 & int1 <= 12)
                    but_4L.Visible = true;
                if (4 < int1 & int1 <= 12)
                    but_5L.Visible = true;
                if (5 < int1 & int1 <= 12)
                    but_6L.Visible = true;
                if (6 < int1 & int1 <= 12)
                    but_7L.Visible = true;
                if (7 < int1 & int1 <= 12)
                    but_8L.Visible = true;
                if (8 < int1 & int1 <= 12)
                    but_9L.Visible = true;
                if (9 < int1 & int1 <= 12)
                    but_10L.Visible = true;
                if (10 < int1 & int1 <= 12)
                    but_11L.Visible = true;
                if (11 < int1 & int1 <= 12)
                    but_12L.Visible = true;
                MessageBox.Show("通讯成功！");
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
            }
            else
                MessageBox.Show("通讯错误请检查！");
        }
        private void but_SPPB_link_Click(object sender, EventArgs e)//SPPB电路板串口连接按钮
        {
            if (but_SPPB_link.Text == "连接")
            {
                try
                {
                    OmronHostLinkCMode.SerialPortInni(sp =>
                    {
                        sp.PortName = com_SPPBserial_port.Text;
                        sp.BaudRate = 9600;
                        sp.DataBits = 8;
                        sp.StopBits = System.IO.Ports.StopBits.One;
                        sp.Parity = System.IO.Ports.Parity.None;
                    });

                    OmronHostLinkCMode.Open();
                    if (OmronHostLinkCMode.IsOpen())
                    {
                        but_SPPB_link.Text = "断开";
                        but_SPPB_link.BackColor = Color.Red;
                        MessageBox.Show("连接成功");
                    }
                    else
                    {
                        MessageBox.Show("连接失败");
                    }
                }
                catch
                {
                    MessageBox.Show("错误请检查！");
                }
            }
            else
            {
                OmronHostLinkCMode.Close();
                but_SPPB_link.Text = "连接";
                but_SPPB_link.BackColor = Color.Green;
            }
        }
        private void but_double_deck_1_Click(object sender, EventArgs e)//双层端子单列按钮
        {
            Program.One_Two = 1;
            time_double_deck1.Enabled = true;

        }
        private void but_double_deck_2_Click(object sender, EventArgs e)//双层端子重列按钮
        {
            Program.One_Two = 2;
            time_double_deck2.Enabled = true;
        }
        private void but_1L_Click(object sender, EventArgs e)//1联按钮
        {
            lab_show.Text = "测试中...";
            a_fit_pc = 0;//公共测试变量
            a_fit_plc = 0;//公共测试变量
            test_bit = 0;
            a = 0;
            b = "0";
            b1 = "0";
            b2 = "0";
            c = "0";
            c1 = "0";
            c2 = "0";
            c3 = "0";
            sec = 0;
            time_1L.Enabled = true;
        }
        private void but_2L_Click(object sender, EventArgs e)//2联按钮
        {
            lab_show.Text = "测试中...";
            a_fit_pc = 0;//公共测试变量
            a_fit_plc = 0;//公共测试变量
            test_bit = 0;
            a = 0;
            b = "0";
            b1 = "0";
            b2 = "0";
            c = "0";
            c1 = "0";
            c2 = "0";
            c3 = "0";
            sec = 0;
            time_2L.Enabled = true;
        }
        private void but_3L_Click(object sender, EventArgs e)//3联按钮
        {
            lab_show.Text = "测试中...";
            a_fit_pc = 0;//公共测试变量
            a_fit_plc = 0;//公共测试变量
            test_bit = 0;
            a = 0;
            b = "0";
            b1 = "0";
            b2 = "0";
            c = "0";
            c1 = "0";
            c2 = "0";
            c3 = "0";
            sec = 0;
            time_3L.Enabled = true;
        }
        private void but_4L_Click(object sender, EventArgs e)//4联按钮
        {
            lab_show.Text = "测试中...";
            a_fit_pc = 0;//公共测试变量
            a_fit_plc = 0;//公共测试变量
            test_bit = 0;
            a = 0;
            b = "0";
            b1 = "0";
            b2 = "0";
            c = "0";
            c1 = "0";
            c2 = "0";
            c3 = "0";
            sec = 0;
            time_4L.Enabled = true;
        }
        private void but_5L_Click(object sender, EventArgs e)//5联按钮
        {
            lab_show.Text = "测试中...";
            a_fit_pc = 0;//公共测试变量
            a_fit_plc = 0;//公共测试变量
            test_bit = 0;
            a = 0;
            b = "0";
            b1 = "0";
            b2 = "0";
            c = "0";
            c1 = "0";
            c2 = "0";
            c3 = "0";
            sec = 0;
            time_5L.Enabled = true;
        }
        private void but_6L_Click(object sender, EventArgs e)//6联按钮
        {
            lab_show.Text = "测试中...";
            a_fit_pc = 0;//公共测试变量
            a_fit_plc = 0;//公共测试变量
            test_bit = 0;
            a = 0;
            b = "0";
            b1 = "0";
            b2 = "0";
            c = "0";
            c1 = "0";
            c2 = "0";
            c3 = "0";
            sec = 0;
            time_6L.Enabled = true;
        }
        private void but_7L_Click(object sender, EventArgs e)//7联按钮
        {
            lab_show.Text = "测试中...";
            a_fit_pc = 0;//公共测试变量
            a_fit_plc = 0;//公共测试变量
            test_bit = 0;
            a = 0;
            b = "0";
            b1 = "0";
            b2 = "0";
            c = "0";
            c1 = "0";
            c2 = "0";
            c3 = "0";
            sec = 0;
            time_7L.Enabled = true;
        }
        private void but_8L_Click(object sender, EventArgs e)//8联按钮
        {
            lab_show.Text = "测试中...";
            a_fit_pc = 0;//公共测试变量
            a_fit_plc = 0;//公共测试变量
            test_bit = 0;
            a = 0;
            b = "0";
            b1 = "0";
            b2 = "0";
            c = "0";
            c1 = "0";
            c2 = "0";
            c3 = "0";
            sec = 0;
            time_8L.Enabled = true;
        }
        private void but_9L_Click(object sender, EventArgs e)//9联按钮
        {
            lab_show.Text = "测试中...";
            a_fit_pc = 0;//公共测试变量
            a_fit_plc = 0;//公共测试变量
            test_bit = 0;
            a = 0;
            b = "0";
            b1 = "0";
            b2 = "0";
            c = "0";
            c1 = "0";
            c2 = "0";
            c3 = "0";
            sec = 0;
            time_9L.Enabled = true;
        }
        private void but_10L_Click(object sender, EventArgs e)//10联按钮
        {
            lab_show.Text = "测试中...";
            a_fit_pc = 0;//公共测试变量
            a_fit_plc = 0;//公共测试变量
            test_bit = 0;
            a = 0;
            b = "0";
            b1 = "0";
            b2 = "0";
            c = "0";
            c1 = "0";
            c2 = "0";
            c3 = "0";
            sec = 0;
            time_10L.Enabled = true;
        }
        private void but_11L_Click(object sender, EventArgs e)//11联按钮
        {
            lab_show.Text = "测试中...";
            a_fit_pc = 0;//公共测试变量
            a_fit_plc = 0;//公共测试变量
            test_bit = 0;
            a = 0;
            b = "0";
            b1 = "0";
            b2 = "0";
            c = "0";
            c1 = "0";
            c2 = "0";
            c3 = "0";
            sec = 0;
            time_11L.Enabled = true;
        }
        private void but_12L_Click(object sender, EventArgs e)//12联按钮
        {
            lab_show.Text = "测试中...";
            a_fit_pc = 0;//公共测试变量
            a_fit_plc = 0;//公共测试变量
            test_bit = 0;
            a = 0;
            b = "0";
            b1 = "0";
            b2 = "0";
            c = "0";
            c1 = "0";
            c2 = "0";
            c3 = "0";
            sec = 0;
            time_12L.Enabled = true;
        }
        private void but_report_printing_Click(object sender, EventArgs e)//报表打印按钮
        {
            Form F_报表 = new F_报表();//FM2 是窗口的(Name)
            F_报表.ShowDialog(this);
        }
        private void but_Stop_Click(object sender, EventArgs e)//急停复位按钮
        {
            string b001;
            string b002;
            //string b003;
            //string b004;

            PLC_CIO0_read();
            Thread.Sleep(100);
            b001 = arrCIO0_PLC[6].ToString();
            b002 = arrCIO0_PLC[5].ToString();
            //b003 = arrD0_PLC[14].ToString();
            if (b001 == "1" & b002 == "0")
                OmronHostLink.Write("CIO100", (ushort)Math.Pow(2, 0));// 写入PC寄存器20




        }

        private void but_Stop_MouseCaptureChanged(object sender, EventArgs e)//急停复位事假发生
        {
            string b001;
            string b002;
            //string b003;
            //string b004;

            PLC_CIO0_read();
            Thread.Sleep(100);
            b001 = arrCIO0_PLC[6].ToString();
            b002 = arrCIO0_PLC[5].ToString();
            if (b001 == "1" & b002 == "1")
            {
                OmronHostLink.Write("CIO100", (ushort)0);// 写入PC寄存器20
            }
        }
        #endregion

        #region  Time循环测试用

        private void time_double_deck_Tick(object sender, EventArgs e)//Time汇川（单列）双层端子台测试用
        {
            //正反转1测试
            if (a == 0)
            {
                OmronHostLink.Write("CIO100", (ushort)Math.Pow(2, 4));// 写入寄存器10
                SPPB_D1_read();////读取电路板D1的值
                Thread.Sleep(100);
                b1 = arrD1_SPPB[12].ToString();
                b2 = arrD1_SPPB[13].ToString();
                if (b1 == "0" && b2 == "1")
                {
                    sec = 0;
                    b1 = "0";
                    b2 = "0";
                    OmronHostLink.Write("CIO100", (ushort)0);
                    a = a + 1;
                }
                else
                {
                    sec = sec + 1;
                }
            }
            if (a == 1)
            {
                OmronHostLink.Write("CIO100", (ushort)Math.Pow(2, 5));// 写入寄存器10
                SPPB_D1_read();////读取电路板D1的值
                Thread.Sleep(100);
                b1 = arrD1_SPPB[12].ToString();
                b2 = arrD1_SPPB[13].ToString();
                if (b1 == "1" && b2 == "0")
                {
                    sec = 0;
                    b1 = "0";
                    b2 = "0";
                    OmronHostLink.Write("CIO100", (ushort)0);
                    a = a + 1;
                }
                else
                    sec = sec + 1;
            }
            //正反转2测试
            if (a == 2) a = 4;//跳过
            /*10A、Yx、UVWx*/
            if (a == 4)//Yx
            {
                if (checkBox1.Checked == false) { a = 7; sec = 0; }
                if (checkBox1.Checked == true)
                {
                    OmronHostLink.Write("CIO101", (ushort)Math.Pow(2, 0));// 写入寄存器10 Y061L升降马达
                    SPPB_D0_read();////读取电路板D1的值
                    Thread.Sleep(100);
                    c2 = arrD0_SPPB[4].ToString();//Yx
                    if (c2 == "1")
                    {
                        sec = 0;
                        c2 = "0";
                        //InovanceSerial.Write("D10", (ushort)0);
                        a = a + 1;
                    }
                    else
                        sec = sec + 1;
                }
            }
            if (a == 5)//10A
            {
                SPPB_D0_read();////读取电路板D1的值
                Thread.Sleep(100);
                c1 = arrD0_SPPB[5].ToString();//10A
                if (c1 == "1" & sec >= 2)
                {
                    a = a + 1;
                    sec = 0;
                    c1 = "0";
                }
                else
                    sec = sec + 1;
            }
            if (a == 6)
            {
                OmronHostLink.Write("CIO100", (ushort)Math.Pow(2, 4));// 写入寄存器10 正转输出
                SPPB_D1_read();////读取电路板D1的值
                Thread.Sleep(100);
                c3 = arrD1_SPPB[9].ToString();//UxVxWx
                if (c3 == "1")
                {
                    a = a + 1;
                    sec = 0;
                    c3 = "0";
                    OmronHostLink.Write("CIO101", (ushort)0);

                }
                else
                    sec = sec + 1;

            }
            /*Yy UVWy*/
            if (a == 7)
            {
                if (checkBox2.Checked == false)
                { a = 9; OmronHostLink.Write("CIO100", (ushort)0); sec = 0; }   //无横移车台跳过
                if (checkBox2.Checked == true)
                {
                    OmronHostLink.Write("CIO101", (ushort)2);
                    OmronHostLink.Write("CIO100", (ushort)Math.Pow(2, 4));
                    SPPB_D0_read();////读取电路板D1的值
                    Thread.Sleep(100);
                    c2 = arrD0_SPPB[4].ToString();//Yy
                    if (c2 == "1")
                    {
                        a = a + 1;
                        sec = 0;
                        c2 = "0";
                    }
                    else
                        sec = sec + 1;
                }
            }
            if (a == 8)
            {
                SPPB_D1_read();////读取电路板D1的值
                Thread.Sleep(100);
                c3 = arrD1_SPPB[9].ToString();//UxVxWx
                if (c3 == "1")
                {
                    sec = 0;
                    c3 = "0";
                    OmronHostLink.Write("CIO100", (ushort)0);
                    OmronHostLink.Write("CIO101", (ushort)0);
                    a = a + 1;
                }
                else
                    sec = sec + 1;
            }
            /*PLC输入测试*/
            if (a >= 9 & a <= 12)
            {
                a_fit_pc = a - 9;
                a_fit_plc = 19 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO0_read();
                Thread.Sleep(100);
                b = arrCIO0_PLC[a_fit_plc].ToString();
                if (b == "1") { a = a + 1; sec = 0; b = "0"; }
                else sec = sec + 1;
            }
            if (a >= 13 & a <= 14)
            {
                a_fit_plc = 19 - a;
                PLC_CIO0_read();
                Thread.Sleep(100);
                b = arrCIO0_PLC[a_fit_plc].ToString();
                if (b == "1" & sec >= 2) { a = a + 1; sec = 0; b = "0"; }
                else sec = sec + 1;
            }
            if (a >= 15) a = 17;//单列跳过
            /*测试完成判断*/
            if (a >= 17)//测试正确
            {
                lab_show.Text = "单列双层端子测试完成...."; textBox1.AppendText("0.06急停信号1测试成功！\r\n"); progressBar1.Value = 100;
                a = 0;
                b = "0";
                sec = 0;
                but_double_deck_1.Visible = false;
                but_1L.Enabled = true;
                time_double_deck1.Enabled = false;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                //MessageBox.Show("测试成功！");
            }
            if (sec >= 10 && a <= 16)//测试错误
            {
                test_bit = a + 1;
                if (test_bit == 1 || test_bit == 2)
                { lab_show.Text = "测试失败...."; textBox1.AppendText("RST1测试失败！\r\n"); progressBar1.Value = 0; }
                if (test_bit == 5)
                { lab_show.Text = "测试失败...."; textBox1.AppendText("Yx测试失败！\r\n"); progressBar1.Value = 0; }
                if (test_bit == 6)
                { lab_show.Text = "测试失败...."; textBox1.AppendText("10A测试失败！\r\n"); progressBar1.Value = 0; }
                if (test_bit == 7)
                { lab_show.Text = "测试失败...."; textBox1.AppendText("UVWx测试失败！\r\n"); progressBar1.Value = 0; }
                if (test_bit == 8)
                { lab_show.Text = "测试失败...."; textBox1.AppendText("Yy测试失败！\r\n"); progressBar1.Value = 0; }
                if (test_bit == 9)
                { lab_show.Text = "测试失败...."; textBox1.AppendText("UVWy测试失败！\r\n"); progressBar1.Value = 0; }
                if (test_bit == 10)
                { lab_show.Text = "测试失败...."; textBox1.AppendText("0.01测试失败！\r\n"); progressBar1.Value = 0; }
                if (test_bit == 11)
                { lab_show.Text = "测试失败...."; textBox1.AppendText("0.02测试失败！\r\n"); progressBar1.Value = 0; }
                if (test_bit == 12)
                { lab_show.Text = "测试失败...."; textBox1.AppendText("0.03测试失败！\r\n"); progressBar1.Value = 0; }
                if (test_bit == 13)
                { lab_show.Text = "测试失败...."; textBox1.AppendText("0.04测试失败！\r\n"); progressBar1.Value = 0; }
                if (test_bit == 14)
                { lab_show.Text = "测试失败...."; textBox1.AppendText("0.05测试失败！\r\n"); progressBar1.Value = 0; }
                if (test_bit == 15)
                { lab_show.Text = "测试失败...."; textBox1.AppendText("0.06测试失败！\r\n"); progressBar1.Value = 0; }
                a = 0;
                b = "0";
                b1 = "0";
                b2 = "0";
                sec = 0;
                time_double_deck1.Enabled = false;
                OmronHostLink.Write("CIO100", (ushort)0);
                OmronHostLink.Write("CIO101", (ushort)0);
                OmronHostLink.Write("CIO102", (ushort)0);
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("Yx 测试成功！\r\n"); progressBar1.Value = 10; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("10A 测试成功！\r\n"); progressBar1.Value = 20; }
            if (a == 6)
            { lab_show.Text = "测试中...."; textBox1.AppendText("UVWx 测试成功！\r\n"); progressBar1.Value = 30; }
            if (a == 7)
            { lab_show.Text = "测试中...."; textBox1.AppendText("Yy 测试成功！\r\n"); progressBar1.Value = 40; }
            if (a == 8)
            { lab_show.Text = "测试中...."; textBox1.AppendText("UVWy 测试成功！\r\n"); progressBar1.Value = 50; }
            if (a == 9)
            { lab_show.Text = "测试中...."; textBox1.AppendText("0.01 测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 10)
            { lab_show.Text = "测试中...."; textBox1.AppendText("0.02 测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 11)
            { lab_show.Text = "测试中...."; textBox1.AppendText("0.03 测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 12)
            { lab_show.Text = "测试中...."; textBox1.AppendText("0.04 测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 13)
            { lab_show.Text = "测试中...."; textBox1.AppendText("0.05 测试成功！\r\n"); progressBar1.Value = 80; }
            if (a == 14)
            { lab_show.Text = "测试中...."; textBox1.AppendText("JT1 测试成功！\r\n"); progressBar1.Value = 90; }

        }
        private void time_double_deck2_Tick(object sender, EventArgs e)//Time汇川（重列）双层端子台测试用
        {
            //正反转1测试
            if (a == 0)
            {
                OmronHostLink.Write("CIO100", (ushort)Math.Pow(2, 4));// 写入寄存器10
                SPPB_D1_read();////读取电路板D1的值
                Thread.Sleep(100);
                b1 = arrD1_SPPB[12].ToString();
                b2 = arrD1_SPPB[13].ToString();
                if (b1 == "0" & b2 == "1")
                {
                    sec = 0;
                    b1 = "0";
                    b2 = "0";
                    OmronHostLink.Write("CIO100", (ushort)0);
                    a = a + 1;
                }
                else
                {
                    sec = sec + 1;
                }
            }
            if (a == 1)
            {
                OmronHostLink.Write("CIO100", (ushort)Math.Pow(2, 5));// 写入寄存器10
                SPPB_D1_read();////读取电路板D1的值
                Thread.Sleep(100);
                b1 = arrD1_SPPB[12].ToString();
                b2 = arrD1_SPPB[13].ToString();
                if (b1 == "1" & b2 == "0")
                {
                    sec = 0;
                    b1 = "0";
                    b2 = "0";
                    OmronHostLink.Write("CIO100", (ushort)0);
                    a = a + 1;
                }
                else
                    sec = sec + 1;
            }
            //正反转2测试
            if (a == 2)
            {
                OmronHostLink.Write("CIO100", (ushort)Math.Pow(2, 6));// 写入寄存器10
                SPPB_D1_read();////读取电路板D1的值
                Thread.Sleep(100);
                b1 = arrD1_SPPB[10].ToString();
                b2 = arrD1_SPPB[11].ToString();
                if (b1 == "0" & b2 == "1")
                {
                    sec = 0;
                    b1 = "0";
                    b2 = "0";
                    OmronHostLink.Write("CIO100", (ushort)0);
                    a = a + 1;
                }
                else
                {
                    sec = sec + 1;
                }
            }
            if (a == 3)
            {
                OmronHostLink.Write("CIO100", (ushort)Math.Pow(2, 7));// 写入寄存器10
                SPPB_D1_read();////读取电路板D1的值
                Thread.Sleep(100);
                b1 = arrD1_SPPB[10].ToString();
                b2 = arrD1_SPPB[11].ToString();
                if (b1 == "1" & b2 == "0")
                {
                    sec = 0;
                    b1 = "0";
                    b2 = "0";
                    OmronHostLink.Write("CIO100", (ushort)0);
                    a = a + 1;
                }
                else
                    sec = sec + 1;
            }


            /*10A、Yx、UVWx*/
            if (a == 4)//Yx
            {
                if (checkBox1.Checked == false) { a = 7; sec = 0; }
                if (checkBox1.Checked == true)
                {
                    OmronHostLink.Write("CIO101", (ushort)Math.Pow(2, 0));// 写入寄存器10 Y061L升降马达
                    SPPB_D0_read();////读取电路板D1的值
                    Thread.Sleep(100);
                    c2 = arrD0_SPPB[4].ToString();//Yx
                    if (c2 == "1")
                    {
                        sec = 0;
                        c2 = "0";
                        //InovanceSerial.Write("D10", (ushort)0);
                        a = a + 1;
                    }
                    else
                        sec = sec + 1;
                }
            }
            if (a == 5)//10A
            {
                SPPB_D0_read();////读取电路板D1的值
                Thread.Sleep(100);
                c1 = arrD0_SPPB[5].ToString();//10A
                if (c1 == "1" & sec >= 2)
                {
                    a = a + 1;
                    sec = 0;
                    c1 = "0";
                }
                else
                    sec = sec + 1;
            }
            if (a == 6)
            {
                //OmronHostLink.Write("D10", (ushort)68);// 写入寄存器10 正转输出
                OmronHostLink.Write("CIO100", (ushort)Math.Pow(2, 6));
                SPPB_D1_read();////读取电路板D1的值
                Thread.Sleep(100);
                c3 = arrD1_SPPB[9].ToString();//UxVxWx
                if (c3 == "1")
                {
                    sec = 0;
                    c3 = "0";
                    OmronHostLink.Write("CIO101", (ushort)0);
                    a = a + 1;
                }
                else
                    sec = sec + 1;

            }
            /*Yy UVWy*/
            if (a == 7)
            {
                if (checkBox2.Checked == false ) { a = 9; OmronHostLink.Write("CIO100", (ushort)0); sec = 0; }   //无横移车台跳过
                if (checkBox2.Checked == true )
                {
                    OmronHostLink.Write("CIO100", (ushort)Math.Pow(2, 6));
                    OmronHostLink.Write("CIO101", (ushort)Math.Pow(2, 1));
                    SPPB_D0_read();////读取电路板D1的值
                    Thread.Sleep(100);
                    c2 = arrD0_SPPB[4].ToString();//Yy
                    if (c2 == "1")
                    {
                        a = a + 1;
                        sec = 0;
                        c2 = "0";
                    }
                    else
                        sec = sec + 1;
                }
            }
            if (a == 8)
            {
                SPPB_D1_read();////读取电路板D1的值
                Thread.Sleep(100);
                c3 = arrD1_SPPB[9].ToString();//UxVxWx
                if (c3 == "1")
                {
                    sec = 0;
                    c3 = "0";
                    OmronHostLink.Write("CIO100", (ushort)0);
                    OmronHostLink.Write("CIO101", (ushort)0);
                    a = a + 1;
                }
                else
                    sec = sec + 1;
            }
            /*PLC输入测试*/
            if (a >= 9 & a <= 12)
            {
                a_fit_pc = a - 9;
                a_fit_plc = 19 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO0_read();
                Thread.Sleep(100);
                b = arrCIO0_PLC[a_fit_plc].ToString();
                if (b == "1") { a = a + 1; sec = 0; b = "0"; }
                else sec = sec + 1;
            }
            if (a >= 13 & a <= 14)
            {
                a_fit_plc = 19 - a;
                PLC_CIO0_read();
                Thread.Sleep(100);
                b = arrCIO0_PLC[a_fit_plc].ToString();
                if (b == "1" & sec >= 2) { a = a + 1; sec = 0; b = "0"; }
                else sec = sec + 1;
            }
            if (a >= 15) a = 17;//非合并跳过
            /*测试完成判断*/
            if (a >= 17)//测试正确
            {
                lab_show.Text = "重列列双层端子测试完成...."; textBox1.AppendText("0.06急停信号1测试成功！"); progressBar1.Value = 100;
                a = 0;
                b = "0";
                sec = 0;
                but_double_deck_2.Visible = false;
                but_1L.Enabled = true;
                time_double_deck2.Enabled = false;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                //MessageBox.Show("测试成功！");
            }
            if (sec >= 10 && a <= 16)//测试错误
            {
                test_bit = a + 1;
                if (test_bit == 1 || test_bit == 2)
                { lab_show.Text = "测试失败...."; textBox1.AppendText("RST1测试失败！"); progressBar1.Value = 0; }
                if (test_bit == 3 || test_bit == 4)
                { lab_show.Text = "测试失败"; textBox1.AppendText("RST3测试失败！"); progressBar1.Value = 0; }
                if (test_bit == 5)
                { lab_show.Text = "测试中失败"; textBox1.AppendText("Yx测试失败！"); progressBar1.Value = 0; }
                if (test_bit == 6)
                { lab_show.Text = "测试中失败"; textBox1.AppendText("10A测试失败！"); progressBar1.Value = 0; }
                if (test_bit == 7)
                { lab_show.Text = "测试中失败"; textBox1.AppendText("UVWx测试失败！"); progressBar1.Value = 0; }
                if (test_bit == 8)
                { lab_show.Text = "测试中失败"; textBox1.AppendText("Yy测试失败！"); progressBar1.Value = 0; }
                if (test_bit == 9)
                { lab_show.Text = "测试中失败"; textBox1.AppendText("UVWy测试失败！"); progressBar1.Value = 0; }
                if (test_bit == 10)
                { lab_show.Text = "测试中失败"; textBox1.AppendText("0.01测试失败！"); progressBar1.Value = 0; }
                if (test_bit == 11)
                { lab_show.Text = "测试中失败"; textBox1.AppendText("0.02测试失败！"); progressBar1.Value = 0; }
                if (test_bit == 12)
                { lab_show.Text = "测试中失败"; textBox1.AppendText("0.03测试失败！"); progressBar1.Value = 0; }
                if (test_bit == 13)
                { lab_show.Text = "测试中失败"; textBox1.AppendText("0.04测试失败！"); progressBar1.Value = 0; }
                if (test_bit == 14)
                { lab_show.Text = "测试中失败"; textBox1.AppendText("0.05测试失败！"); progressBar1.Value = 0; }
                if (test_bit == 15)
                { lab_show.Text = "测试中失败"; textBox1.AppendText("JT1测试失败！"); progressBar1.Value = 0; }
                a = 0;
                b = "0";
                b1 = "0";
                b2 = "0";
                sec = 0;
                time_double_deck2.Enabled = false;
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 2)
            { lab_show.Text = "测试中...."; textBox1.AppendText("RST1 PST3 测试成功！"); progressBar1.Value = 10; }
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("Yx 测试成功！"); progressBar1.Value = 10; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("10A 测试成功！"); progressBar1.Value = 20; }
            if (a == 6)
            { lab_show.Text = "测试中...."; textBox1.AppendText("UVWx 测试成功！"); progressBar1.Value = 30; }
            if (a == 7)
            { lab_show.Text = "测试中...."; textBox1.AppendText("Yy 测试成功！"); progressBar1.Value = 40; }
            if (a == 8)
            { lab_show.Text = "测试中...."; textBox1.AppendText("UVWy 测试成功！"); progressBar1.Value = 50; }
            if (a == 9)
            { lab_show.Text = "测试中...."; textBox1.AppendText("0.01 测试成功！"); progressBar1.Value = 60; }
            if (a == 10)
            { lab_show.Text = "测试中...."; textBox1.AppendText("0.02 测试成功！"); progressBar1.Value = 60; }
            if (a == 11)
            { lab_show.Text = "测试中...."; textBox1.AppendText("X0.03 测试成功！"); progressBar1.Value = 70; }
            if (a == 12)
            { lab_show.Text = "测试中...."; textBox1.AppendText("0.04 测试成功！"); progressBar1.Value = 70; }
            if (a == 13)
            { lab_show.Text = "测试中...."; textBox1.AppendText("0.05 测试成功！"); progressBar1.Value = 80; }
            if (a == 14)
            { lab_show.Text = "测试中...."; textBox1.AppendText("JT1 测试成功！"); progressBar1.Value = 90; }
        }
        private void time_1L_Tick(object sender, EventArgs e)//Time欧姆龙1L测试
        {

            /*PLC强制输出，PC板输入检测*/
            if (a <= 1)
            {
                a_fit_pc = 11 - a;
                a_fit_plc = a;
                OmronHostLink.Write("CIO101", (ushort)Math.Pow(2, a_fit_plc));// 写入欧姆龙寄存器101
                SPPB_D0_read();
                Thread.Sleep(100);
                //int_arr = arr.Length;
                //Thread.Sleep(100);
                b = arrD0_SPPB[a_fit_pc].ToString();
                //label15.Text = ;
                //Thread.Sleep(100);
                //label16.Text = arrD0_SPPB[12].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            else
                OmronHostLink.Write("CIO101", (ushort)0);// 写入欧姆龙寄存器101
                                                         //Thread.Sleep(1000);
            /*PC板强制输出，PLC输入检测*/
            if (a >= 2 & a <= 6)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 6 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO0_read();
                //Thread.Sleep(220);
                Thread.Sleep(100);
                b = arrCIO0_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            else
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20

            /*测试完成判断*/
            if (a > 6)//测试正确
            {
                lab_show.Text = "1联测试完成...."; textBox1.AppendText("0.06测试成功！\r\n"); progressBar1.Value = 100;
                //lab_show.Text = "";
                //progressBar1.Value = 0;

                a = 0;
                sec = 0;
                but_1L.Enabled = false;
                but_2L.Enabled = true;
                if (Program.Location_link_number == "1")
                    but_report_printing.Visible = true;
                time_1L.Enabled = false;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                //MessageBox.Show("测试成功！");
            }

            /*测试失败显示故障信息*/
            if (sec >= 5 && a <= 6)
            {
                if (a == 0)
                { lab_show.Text = "测试失败"; textBox1.AppendText("101.00测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 1)
                { lab_show.Text = "测试失败"; textBox1.AppendText("101.01测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 2)
                { lab_show.Text = "测试失败"; textBox1.AppendText("0.07测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 3)
                { lab_show.Text = "测试失败"; textBox1.AppendText("0.08测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 4)
                { lab_show.Text = "测试失败"; textBox1.AppendText("0.09测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 5)
                { lab_show.Text = "测试失败"; textBox1.AppendText("0.10测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 6)
                { lab_show.Text = "测试失败"; textBox1.AppendText("0.11测试失败！\r\n"); progressBar1.Value = 0; }
                a = 0;
                sec = 0;
                time_1L.Enabled = false;
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 1)
            { lab_show.Text = "测试中...."; textBox1.AppendText("101.00测试成功！\r\n"); progressBar1.Value = 20; }
            if (a == 2)
            { lab_show.Text = "测试中...."; textBox1.AppendText("101.01测试成功！\r\n"); progressBar1.Value = 40; }
            if (a == 3)
            { lab_show.Text = "测试中...."; textBox1.AppendText("0.07测试成功！\r\n"); progressBar1.Value = 50; }
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("0.08测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("0.09测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 6)
            { lab_show.Text = "测试中....."; textBox1.AppendText("0.10测试成功！\r\n"); progressBar1.Value = 90; }
        }

        private void time_2L_Tick(object sender, EventArgs e)//Time汇川2L测试
        {
            /*PLC强制输出，PC板输入检测*/
            if (a <= 1)
            {
                a_fit_pc = 11 - a;
                a_fit_plc = a + 2;
                OmronHostLink.Write("CIO101", (ushort)Math.Pow(2, a_fit_plc));// 写入欧姆龙寄存器101
                SPPB_D0_read();
                Thread.Sleep(100);
                b = arrD0_SPPB[a_fit_pc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            else
                OmronHostLink.Write("CIO101", (ushort)0);// 写入欧姆龙寄存器101

            /*PC板强制输出，PLC输入检测*/
            if (a >= 2 & a <= 6)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 13 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO1_read();
                Thread.Sleep(100);
                b = arrCIO1_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }


            /*测试完成判断*/
            if (a > 6)//测试正确
            {
                lab_show.Text = "2联测试完成...."; textBox1.AppendText("1.04测试成功！\r\n"); progressBar1.Value = 100;
                //lab_show.Text = "";
                //progressBar1.Value = 0;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                a = 0;
                sec = 0;
                but_2L.Enabled = false;
                but_3L.Enabled = true;
                if (Program.Location_link_number == "2")
                    but_report_printing.Visible = true;
                time_2L.Enabled = false;
                //MessageBox.Show("测试成功！");
            }

            /*测试失败显示故障信息*/
            if (sec >= 5 && a <= 6)
            {
                if (a == 0)
                { lab_show.Text = "测试失败"; textBox1.AppendText("101.02测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 1)
                { lab_show.Text = "测试失败"; textBox1.AppendText("101.03测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 2)
                { lab_show.Text = "测试失败"; textBox1.AppendText("1.00测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 3)
                { lab_show.Text = "测试失败"; textBox1.AppendText("1.01测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 4)
                { lab_show.Text = "测试失败"; textBox1.AppendText("1.02测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 5)
                { lab_show.Text = "测试失败"; textBox1.AppendText("1.03测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 6)
                { lab_show.Text = "测试失败"; textBox1.AppendText("1.04测试失败！\r\n"); progressBar1.Value = 0; }
                a = 0;
                sec = 0;
                time_2L.Enabled = false;
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 1)
            { lab_show.Text = "测试中...."; textBox1.AppendText("101.02测试成功！\r\n"); progressBar1.Value = 20; }
            if (a == 2)
            { lab_show.Text = "测试中...."; textBox1.AppendText("101.03测试成功！\r\n"); progressBar1.Value = 40; }
            if (a == 3)
            { lab_show.Text = "测试中...."; textBox1.AppendText("1.00测试成功！\r\n"); progressBar1.Value = 50; }
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("1.01测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("1.02测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 6)
            { lab_show.Text = "测试中....."; textBox1.AppendText("1.03测试成功！\r\n"); progressBar1.Value = 90; }
        }

        private void time_3L_Tick(object sender, EventArgs e)//Time汇川3L测试
        {
            /*PLC强制输出，PC板输入检测*/
            if (a <= 1)
            {
                a_fit_pc = 11 - a;
                a_fit_plc = a + 4;
                OmronHostLink.Write("CIO101", (ushort)Math.Pow(2, a_fit_plc));// 写入汇川寄存器10
                SPPB_D0_read();
                Thread.Sleep(100);
                b = arrD0_SPPB[a_fit_pc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            else
                OmronHostLink.Write("CIO101", (ushort)0);// 写入汇川寄存器10

            /*PC板强制输出，PLC输入检测*/
            if (a >= 2 & a <= 6)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 8 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO1_read();
                Thread.Sleep(100);
                b = arrCIO1_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }

            /*测试完成判断*/
            if (a > 6)//测试正确
            {
                lab_show.Text = "3联测试完成...."; textBox1.AppendText("1.09测试成功！"); progressBar1.Value = 100;
                //lab_show.Text = "";
                //progressBar1.Value = 0;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                a = 0;
                sec = 0;
                but_3L.Enabled = false;
                but_4L.Enabled = true;
                if (Program.Location_link_number == "3")
                    but_report_printing.Visible = true;
                time_3L.Enabled = false;
                //MessageBox.Show("测试成功！");
            }

            /*测试失败显示故障信息*/
            if (sec >= 5 && a <= 6)
            {
                if (a == 0)
                { lab_show.Text = "测试失败"; textBox1.AppendText("101.04测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 1)
                { lab_show.Text = "测试失败"; textBox1.AppendText("101.05测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 2)
                { lab_show.Text = "测试失败"; textBox1.AppendText("1.05测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 3)
                { lab_show.Text = "测试失败"; textBox1.AppendText("1.06测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 4)
                { lab_show.Text = "测试失败"; textBox1.AppendText("1.07测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 5)
                { lab_show.Text = "测试失败"; textBox1.AppendText("1.08测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 6)
                { lab_show.Text = "测试失败"; textBox1.AppendText("1.09测试失败！\r\n"); progressBar1.Value = 0; }
                a = 0;
                sec = 0;
                time_3L.Enabled = false;
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 1)
            { lab_show.Text = "测试中...."; textBox1.AppendText("101.04测试成功！\r\n"); progressBar1.Value = 20; }
            if (a == 2)
            { lab_show.Text = "测试中...."; textBox1.AppendText("101.05测试成功！\r\n"); progressBar1.Value = 40; }
            if (a == 3)
            { lab_show.Text = "测试中...."; textBox1.AppendText("1.05测试成功！\r\n"); progressBar1.Value = 50; }
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("1.06测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("1.07测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 6)
            { lab_show.Text = "测试中....."; textBox1.AppendText("1.08测试成功！\r\n"); progressBar1.Value = 90; }
        }
        private void time_4L_Tick(object sender, EventArgs e)//Time汇川4L测试
        {
            /*PLC强制输出，PC板输入检测*/
            if (a <= 1)
            {
                a_fit_pc = 11 - a;
                a_fit_plc = a + 6;
                OmronHostLink.Write("CIO101", (ushort)Math.Pow(2, a_fit_plc));// 写入汇川寄存器10
                SPPB_D0_read();
                Thread.Sleep(100);
                b = arrD0_SPPB[a_fit_pc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            else
                OmronHostLink.Write("CIO101", (ushort)0);// 写入汇川寄存器10

            /*PC板强制输出，PLC输入检测*/
            if (a >= 2 & a < 4)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 3 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO1_read();
                Thread.Sleep(100);
                b = arrCIO1_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            if (a >= 4 & a <= 6)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 15 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO2_read();
                Thread.Sleep(100);
                b = arrCIO2_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            /*测试完成判断*/
            if (a > 6)//测试正确
            {
                lab_show.Text = "4联测试完成...."; textBox1.AppendText("2.02测试成功！"); progressBar1.Value = 100;
                //lab_show.Text = "";
                //progressBar1.Value = 0;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                a = 0;
                sec = 0;
                but_4L.Enabled = false;
                but_5L.Enabled = true;
                if (Program.Location_link_number == "4")
                    but_report_printing.Visible = true;
                time_4L.Enabled = false;
                //MessageBox.Show("测试成功！");
            }

            /*测试失败显示故障信息*/
            if (sec >= 5 && a <= 6)
            {
                if (a == 0)
                { lab_show.Text = "测试失败"; textBox1.AppendText("101.06测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 1)
                { lab_show.Text = "测试失败"; textBox1.AppendText("101.07测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 2)
                { lab_show.Text = "测试失败"; textBox1.AppendText("1.10测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 3)
                { lab_show.Text = "测试失败"; textBox1.AppendText("1.11测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 4)
                { lab_show.Text = "测试失败"; textBox1.AppendText("2.00测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 5)
                { lab_show.Text = "测试失败"; textBox1.AppendText("2.01测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 6)
                { lab_show.Text = "测试失败"; textBox1.AppendText("2.02测试失败！\r\n"); progressBar1.Value = 0; }
                a = 0;
                sec = 0;
                time_4L.Enabled = false;
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 1)
            { lab_show.Text = "测试中...."; textBox1.AppendText("101.06测试成功！\r\n"); progressBar1.Value = 20; }
            if (a == 2)
            { lab_show.Text = "测试中...."; textBox1.AppendText("101.07测试成功！\r\n"); progressBar1.Value = 40; }
            if (a == 3)
            { lab_show.Text = "测试中...."; textBox1.AppendText("1.10测试成功！\r\n"); progressBar1.Value = 50; }
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("1.11测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("2.00测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 6)
            { lab_show.Text = "测试中....."; textBox1.AppendText("2.01测试成功！\r\n"); progressBar1.Value = 90; }
        }

        private void time_5L_Tick(object sender, EventArgs e)//Time汇川5L测试
        {
            /*PLC强制输出，PC板输入检测*/
            if (a <= 1)
            {
                a_fit_pc = 11 - a;
                a_fit_plc = a ;
                OmronHostLink.Write("CIO102", (ushort)Math.Pow(2, a_fit_plc));// 写入汇川寄存器10
                SPPB_D0_read();
                Thread.Sleep(100);
                b = arrD0_SPPB[a_fit_pc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            else
                OmronHostLink.Write("CIO102", (ushort)0);// 写入汇川寄存器10

            /*PC板强制输出，PLC输入检测*/
            if (a >= 2 & a <= 6)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 10 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO2_read();
                Thread.Sleep(100);
                b = arrCIO2_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }

            /*测试完成判断*/
            if (a > 6)//测试正确
            {
                lab_show.Text = "5联测试完成...."; textBox1.AppendText("2.07测试成功！"); progressBar1.Value = 100;
                //lab_show.Text = "";
                //progressBar1.Value = 0;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                a = 0;
                sec = 0;
                but_5L.Enabled = false;
                but_6L.Enabled = true;
                if (Program.Location_link_number == "5")
                    but_report_printing.Visible = true;
                time_5L.Enabled = false;
                //MessageBox.Show("测试成功！");
            }

            /*测试失败显示故障信息*/
            if (sec >= 5 && a <= 6)
            {
                if (a == 0)
                { lab_show.Text = "测试失败"; textBox1.AppendText("102.00测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 1)
                { lab_show.Text = "测试失败"; textBox1.AppendText("102.01测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 2)
                { lab_show.Text = "测试失败"; textBox1.AppendText("2.03测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 3)
                { lab_show.Text = "测试失败"; textBox1.AppendText("2.04测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 4)
                { lab_show.Text = "测试失败"; textBox1.AppendText("2.05测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 5)
                { lab_show.Text = "测试失败"; textBox1.AppendText("2.06测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 6)
                { lab_show.Text = "测试失败"; textBox1.AppendText("2.07测试失败！\r\n"); progressBar1.Value = 0; }
                a = 0;
                sec = 0;
                time_5L.Enabled = false;
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 1)
            { lab_show.Text = "测试中...."; textBox1.AppendText("102.00成功！\r\n"); progressBar1.Value = 20; }
            if (a == 2)
            { lab_show.Text = "测试中...."; textBox1.AppendText("102.01测试成功！\r\n"); progressBar1.Value = 40; }
            if (a == 3)
            { lab_show.Text = "测试中...."; textBox1.AppendText("2.03测试成功！\r\n"); progressBar1.Value = 50; }
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("2.04测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("2.05测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 6)
            { lab_show.Text = "测试中....."; textBox1.AppendText("2.06测试成功！\r\n"); progressBar1.Value = 90; }
        }

        private void time_6L_Tick(object sender, EventArgs e)//Time汇川6L测试
        {
            /*PLC强制输出，PC板输入检测*/
            if (a <= 1)
            {
                a_fit_pc = 11 - a;
                a_fit_plc = a+2;
                OmronHostLink.Write("CIO102", (ushort)Math.Pow(2, a_fit_plc));// 写入汇川寄存器10
                SPPB_D0_read();
                Thread.Sleep(100);
                b = arrD0_SPPB[a_fit_pc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            else
                OmronHostLink.Write("CIO102", (ushort)0);// 写入汇川寄存器10

            /*PC板强制输出，PLC输入检测*/
            if (a >= 2 & a < 6)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 5 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO2_read();
                Thread.Sleep(100);
                b = arrCIO2_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            if (a == 6)
            {
                a_fit_pc = a + 6;
                //a_fit_plc = 22 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO3_read();
                Thread.Sleep(100);
                b = arrCIO3_PLC[11].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            /*测试完成判断*/
            if (a > 6)//测试正确
            {
                lab_show.Text = "6联测试完成...."; textBox1.AppendText("3.00测试成功！"); progressBar1.Value = 100;
                //lab_show.Text = "";
                //progressBar1.Value = 0;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                a = 0;
                sec = 0;
                but_6L.Enabled = false;
                but_7L.Enabled = true;
                if (Program.Location_link_number == "6")
                    but_report_printing.Visible = true;
                time_6L.Enabled = false;
                //MessageBox.Show("测试成功！");
            }

            /*测试失败显示故障信息*/
            if (sec >= 5 && a <= 6)
            {
                if (a == 0)
                { lab_show.Text = "测试失败"; textBox1.AppendText("102.02测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 1)
                { lab_show.Text = "测试失败"; textBox1.AppendText("102.03测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 2)
                { lab_show.Text = "测试失败"; textBox1.AppendText("2.08测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 3)
                { lab_show.Text = "测试失败"; textBox1.AppendText("2.09测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 4)
                { lab_show.Text = "测试失败"; textBox1.AppendText("2.10测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 5)
                { lab_show.Text = "测试失败"; textBox1.AppendText("2.11测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 6)
                { lab_show.Text = "测试失败"; textBox1.AppendText("3.00测试失败！\r\n"); progressBar1.Value = 0; }
                a = 0;
                sec = 0;
                time_6L.Enabled = false;
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 1)
            { lab_show.Text = "测试中...."; textBox1.AppendText("102.02测试成功！\r\n"); progressBar1.Value = 20; }
            if (a == 2)
            { lab_show.Text = "测试中...."; textBox1.AppendText("102.03测试成功！\r\n"); progressBar1.Value = 40; }
            if (a == 3)
            { lab_show.Text = "测试中...."; textBox1.AppendText("2.08测试成功！\r\n"); progressBar1.Value = 50; }
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("2.09测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("2.10测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 6)
            { lab_show.Text = "测试中....."; textBox1.AppendText("2.11测试成功！\r\n"); progressBar1.Value = 90; }
        }
        private void time_7L_Tick(object sender, EventArgs e)//Time汇川7L测试
        {
            /*PLC强制输出，PC板输入检测*/
            if (a <= 1)
            {
                a_fit_pc = 11 - a;
                a_fit_plc = a + 4;
                OmronHostLink.Write("CIO102", (ushort)Math.Pow(2, a_fit_plc));// 写入汇川寄存器10
                SPPB_D0_read();
                Thread.Sleep(100);
                b = arrD0_SPPB[a_fit_pc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            else
                OmronHostLink.Write("CIO102", (ushort)0);// 写入汇川寄存器10

            /*PC板强制输出，PLC输入检测*/
            if (a >= 2 & a <= 6)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 12 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO3_read();
                Thread.Sleep(100);
                b = arrCIO3_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            /*测试完成判断*/
            if (a > 6)//测试正确
            {
                lab_show.Text = "7联测试完成...."; textBox1.AppendText("3.05测试成功！"); progressBar1.Value = 100;
                //lab_show.Text = "";
                //progressBar1.Value = 0;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                a = 0;
                sec = 0;
                but_7L.Enabled = false;
                but_8L.Enabled = true;
                if (Program.Location_link_number == "7")
                    but_report_printing.Visible = true;
                time_7L.Enabled = false;
                //MessageBox.Show("测试成功！");
            }

            /*测试失败显示故障信息*/
            if (sec >= 5 && a <= 6)
            {
                if (a == 0)
                { lab_show.Text = "测试失败"; textBox1.AppendText("102.04测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 1)
                { lab_show.Text = "测试失败"; textBox1.AppendText("102.05测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 2)
                { lab_show.Text = "测试失败"; textBox1.AppendText("3.01测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 3)
                { lab_show.Text = "测试失败"; textBox1.AppendText("3.02测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 4)
                { lab_show.Text = "测试失败"; textBox1.AppendText("3.03测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 5)
                { lab_show.Text = "测试失败"; textBox1.AppendText("3.04测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 6)
                { lab_show.Text = "测试失败"; textBox1.AppendText("3.05测试失败！\r\n"); progressBar1.Value = 0; }
                a = 0;
                sec = 0;
                time_7L.Enabled = false;
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 1)
            { lab_show.Text = "测试中...."; textBox1.AppendText("102.04测试成功！\r\n"); progressBar1.Value = 20; }
            if (a == 2)
            { lab_show.Text = "测试中...."; textBox1.AppendText("102.05测试成功！\r\n"); progressBar1.Value = 40; }
            if (a == 3)
            { lab_show.Text = "测试中...."; textBox1.AppendText("3.01测试成功！\r\n"); progressBar1.Value = 50; }
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("3.02测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("3.03测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 6)
            { lab_show.Text = "测试中....."; textBox1.AppendText("3.04测试成功！\r\n"); progressBar1.Value = 90; }
        }

        private void time_8L_Tick(object sender, EventArgs e)//Time汇川8L测试
        {
            /*PLC强制输出，PC板输入检测*/
            if (a <= 1)
            {
                a_fit_pc = 11 - a;
                a_fit_plc = a + 6;
                OmronHostLink.Write("CIO102", (ushort)Math.Pow(2, a_fit_plc));// 写入汇川寄存器11
                SPPB_D0_read();
                Thread.Sleep(100);
                b = arrD0_SPPB[a_fit_pc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            else
                OmronHostLink.Write("CIO102", (ushort)0);// 写入汇川寄存器10

            /*PC板强制输出，PLC输入检测*/
            if (a >= 2 & a <= 6)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 7 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO3_read();
                Thread.Sleep(100);
                b = arrCIO3_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            /*测试完成判断*/
            if (a > 6)//测试正确
            {
                lab_show.Text = "8联测试完成...."; textBox1.AppendText("3.10测试成功！"); progressBar1.Value = 100;
                //lab_show.Text = "";
                //progressBar1.Value = 0;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                a = 0;
                sec = 0;
                but_8L.Enabled = false;
                but_9L.Enabled = true;
                if (Program.Location_link_number == "8")
                    but_report_printing.Visible = true;
                time_8L.Enabled = false;
                //MessageBox.Show("测试成功！");
            }

            /*测试失败显示故障信息*/
            if (sec >= 5 && a <= 6)
            {
                if (a == 0)
                { lab_show.Text = "测试失败"; textBox1.AppendText("102.06测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 1)
                { lab_show.Text = "测试失败"; textBox1.AppendText("102.07测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 2)
                { lab_show.Text = "测试失败"; textBox1.AppendText("3.06测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 3)
                { lab_show.Text = "测试失败"; textBox1.AppendText("3.07测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 4)
                { lab_show.Text = "测试失败"; textBox1.AppendText("3.08测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 5)
                { lab_show.Text = "测试失败"; textBox1.AppendText("3.09测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 6)
                { lab_show.Text = "测试失败"; textBox1.AppendText("3.10测试失败！\r\n"); progressBar1.Value = 0; }
                a = 0;
                sec = 0;
                time_8L.Enabled = false;
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 1)
            { lab_show.Text = "测试中...."; textBox1.AppendText("102.06测试成功！\r\n"); progressBar1.Value = 20; }
            if (a == 2)
            { lab_show.Text = "测试中...."; textBox1.AppendText("102.07测试成功！\r\n"); progressBar1.Value = 40; }
            if (a == 3)
            { lab_show.Text = "测试中...."; textBox1.AppendText("3.06测试成功！\r\n"); progressBar1.Value = 50; }
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("3.07测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("3.08测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 6)
            { lab_show.Text = "测试中....."; textBox1.AppendText("3.09测试成功！\r\n"); progressBar1.Value = 90; }
        }

        private void time_9L_Tick(object sender, EventArgs e)//Time汇川9L测试
        {
            /*PLC强制输出，PC板输入检测*/
            if (a <= 1)
            {
                a_fit_pc = 11 - a;
                a_fit_plc = a;
                OmronHostLink.Write("CIO103", (ushort)Math.Pow(2, a_fit_plc));// 写入汇川寄存器11
                SPPB_D0_read();
                Thread.Sleep(100);
                b = arrD0_SPPB[a_fit_pc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            else
                OmronHostLink.Write("CIO103", (ushort)0);// 写入汇川寄存器10

            /*PC板强制输出，PLC输入检测*/
            if (a == 2 )
            {
                a_fit_pc = a + 6;
                a_fit_plc = 2 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO3_read();
                Thread.Sleep(100);
                b = arrCIO3_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }


            if (a > 2 & a <= 6)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 14 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO4_read();
                Thread.Sleep(100);
                b = arrCIO4_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            /*测试完成判断*/
            if (a > 6)//测试正确
            {
                lab_show.Text = "9联测试完成...."; textBox1.AppendText("4.03测试成功！"); progressBar1.Value = 100;
                //lab_show.Text = "";
                //progressBar1.Value = 0;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                a = 0;
                sec = 0;
                but_9L.Enabled = false;
                but_10L.Enabled = true;
                if (Program.Location_link_number == "9")
                    but_report_printing.Visible = true;
                time_9L.Enabled = false;
                //MessageBox.Show("测试成功！");
            }

            /*测试失败显示故障信息*/
            if (sec >= 5 && a <= 6)
            {
                if (a == 0)
                { lab_show.Text = "测试失败"; textBox1.AppendText("103.00测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 1)
                { lab_show.Text = "测试失败"; textBox1.AppendText("103.01测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 2)
                { lab_show.Text = "测试失败"; textBox1.AppendText("3.11测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 3)
                { lab_show.Text = "测试失败"; textBox1.AppendText("4.00测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 4)
                { lab_show.Text = "测试失败"; textBox1.AppendText("4.01测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 5)
                { lab_show.Text = "测试失败"; textBox1.AppendText("4.02测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 6)
                { lab_show.Text = "测试失败"; textBox1.AppendText("4.03测试失败！\r\n"); progressBar1.Value = 0; }
                a = 0;
                sec = 0;
                time_9L.Enabled = false;
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 1)
            { lab_show.Text = "测试中...."; textBox1.AppendText("103.00测试成功！\r\n"); progressBar1.Value = 20; }
            if (a == 2)
            { lab_show.Text = "测试中...."; textBox1.AppendText("103.01测试成功！\r\n"); progressBar1.Value = 40; }
            if (a == 3)
            { lab_show.Text = "测试中...."; textBox1.AppendText("3.11测试成功！\r\n"); progressBar1.Value = 50; }
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("4.00测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("4.01测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 6)
            { lab_show.Text = "测试中....."; textBox1.AppendText("4.02测试成功！\r\n"); progressBar1.Value = 90; }
        }

        private void time_10L_Tick(object sender, EventArgs e)//Time汇川10L测试
        {
            /*PLC强制输出，PC板输入检测*/
            if (a <= 1)
            {
                a_fit_pc = 11 - a;
                a_fit_plc = a + 2;
                OmronHostLink.Write("CIO103", (ushort)Math.Pow(2, a_fit_plc));// 写入汇川寄存器11
                SPPB_D0_read();
                Thread.Sleep(100);
                b = arrD0_SPPB[a_fit_pc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            else
                OmronHostLink.Write("CIO103", (ushort)0);// 写入汇川寄存器10

            /*PC板强制输出，PLC输入检测*/
            if (a >= 2 & a <= 6)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 9 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO4_read();
                Thread.Sleep(100);
                b = arrCIO4_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            /*测试完成判断*/
            if (a > 6)//测试正确
            {
                lab_show.Text = "10联测试完成...."; textBox1.AppendText("4.08测试成功！"); progressBar1.Value = 100;
                //lab_show.Text = "";
                //progressBar1.Value = 0;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                a = 0;
                sec = 0;
                but_10L.Enabled = false;
                but_11L.Enabled = true;
                if (Program.Location_link_number == "10")
                    but_report_printing.Visible = true;
                time_10L.Enabled = false;
               // MessageBox.Show("测试成功！");
            }

            /*测试失败显示故障信息*/
            if (sec >= 5 && a <= 6)
            {
                if (a == 0)
                { lab_show.Text = "测试失败"; textBox1.AppendText("103.02测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 1)
                { lab_show.Text = "测试失败"; textBox1.AppendText("103.03测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 2)
                { lab_show.Text = "测试失败"; textBox1.AppendText("4.04测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 3)
                { lab_show.Text = "测试失败"; textBox1.AppendText("4.05测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 4)
                { lab_show.Text = "测试失败"; textBox1.AppendText("4.06测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 5)
                { lab_show.Text = "测试失败"; textBox1.AppendText("4.07测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 6)
                { lab_show.Text = "测试失败"; textBox1.AppendText("4.08测试失败！\r\n"); progressBar1.Value = 0; }
                a = 0;
                sec = 0;
                time_10L.Enabled = false;
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 1)
            { lab_show.Text = "测试中...."; textBox1.AppendText("103.02测试成功！\r\n"); progressBar1.Value = 20; }
            if (a == 2)
            { lab_show.Text = "测试中...."; textBox1.AppendText("103.03测试成功！\r\n"); progressBar1.Value = 40; }
            if (a == 3)
            { lab_show.Text = "测试中...."; textBox1.AppendText("4.04测试成功！\r\n"); progressBar1.Value = 50; }
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("4.05测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("4.06测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 6)
            { lab_show.Text = "测试中....."; textBox1.AppendText("4.07测试成功！\r\n"); progressBar1.Value = 90; }
        }

        private void time_11L_Tick(object sender, EventArgs e)//Time汇川11L测试
        {
            /*PLC强制输出，PC板输入检测*/
            if (a <= 1)
            {
                a_fit_pc = 11 - a;
                a_fit_plc = a + 4;
                OmronHostLink.Write("CIO103", (ushort)Math.Pow(2, a_fit_plc));// 写入汇川寄存器11
                SPPB_D0_read();
                Thread.Sleep(100);
                b = arrD0_SPPB[a_fit_pc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            else
                OmronHostLink.Write("CIO103", (ushort)0);// 写入汇川寄存器10

            /*PC板强制输出，PLC输入检测*/
            if (a >= 2 & a <= 4)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 4 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO4_read();
                Thread.Sleep(100);
                b = arrCIO4_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            /*PC板强制输出，PLC输入检测*/
            if (a >= 5 & a <= 6)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 16 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO5_read();
                Thread.Sleep(100);
                b = arrCIO5_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            /*测试完成判断*/
            if (a > 6)//测试正确
            {
                lab_show.Text = "11联测试完成...."; textBox1.AppendText("5.01测试成功！\r\n"); progressBar1.Value = 100;
                //lab_show.Text = "";
                //progressBar1.Value = 0;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                a = 0;
                sec = 0;
                but_11L.Enabled = false;
                but_12L.Enabled = true;
                if (Program.Location_link_number == "11")
                    but_report_printing.Visible = true;
                time_11L.Enabled = false;
                // MessageBox.Show("测试成功！");
            }

            /*测试失败显示故障信息*/
            if (sec >= 5 && a <= 6)
            {
                if (a == 0)
                { lab_show.Text = "测试失败"; textBox1.AppendText("103.04测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 1)
                { lab_show.Text = "测试失败"; textBox1.AppendText("103.05测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 2)
                { lab_show.Text = "测试失败"; textBox1.AppendText("4.09测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 3)
                { lab_show.Text = "测试失败"; textBox1.AppendText("4.10测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 4)
                { lab_show.Text = "测试失败"; textBox1.AppendText("4.11测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 5)
                { lab_show.Text = "测试失败"; textBox1.AppendText("5.00测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 6)
                { lab_show.Text = "测试失败"; textBox1.AppendText("5.01测试失败！\r\n"); progressBar1.Value = 0; }
                a = 0;
                sec = 0;
                time_11L.Enabled = false;
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 1)
            { lab_show.Text = "测试中...."; textBox1.AppendText("103.04测试成功！\r\n"); progressBar1.Value = 20; }
            if (a == 2)
            { lab_show.Text = "测试中...."; textBox1.AppendText("103.05测试成功！\r\n"); progressBar1.Value = 40; }
            if (a == 3)
            { lab_show.Text = "测试中...."; textBox1.AppendText("4.09测试成功！\r\n"); progressBar1.Value = 50; }
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("4.10测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("4.11测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 6)
            { lab_show.Text = "测试中....."; textBox1.AppendText("5.00测试成功！\r\n"); progressBar1.Value = 90; }
        }

        private void time_12L_Tick(object sender, EventArgs e)//Time汇川12L测试
        {
            /*PLC强制输出，PC板输入检测*/
            if (a <= 1)
            {
                a_fit_pc = 11 - a;
                a_fit_plc = a + 6;
                OmronHostLink.Write("CIO103", (ushort)Math.Pow(2, a_fit_plc));// 写入汇川寄存器11
                SPPB_D0_read();
                Thread.Sleep(100);
                b = arrD0_SPPB[a_fit_pc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            else
                OmronHostLink.Write("CIO103", (ushort)0);// 写入汇川寄存器10

            /*PC板强制输出，PLC输入检测*/
            if (a >= 2 & a <= 6)
            {
                a_fit_pc = a + 6;
                a_fit_plc = 11 - a;
                OmronHostLinkCMode.Write("D20", (ushort)Math.Pow(2, a_fit_pc));// 写入PC寄存器20
                PLC_CIO5_read();
                Thread.Sleep(100);
                b = arrCIO5_PLC[a_fit_plc].ToString();
                if (b == "1")
                {
                    a = a + 1;
                    sec = 0;
                    b = "0";
                }
                else
                    sec = sec + 1;
            }
            /*测试完成判断*/
            if (a > 6)//测试正确
            {
                lab_show.Text = "12联测试完成...."; textBox1.AppendText("5.06测试成功！"); progressBar1.Value = 100;
                //lab_show.Text = "";
                //progressBar1.Value = 0;
                OmronHostLinkCMode.Write("D20", (ushort)0);// 写入PC寄存器20
                a = 0;
                sec = 0;
                but_12L.Enabled = false;
                //but_7L.Enabled = true;
                if (Program.Location_link_number == "12")
                    but_report_printing.Visible = true;
                time_12L.Enabled = false;
                //MessageBox.Show("测试成功！");
            }

            /*测试失败显示故障信息*/
            if (sec >= 5 && a <= 6)
            {
                if (a == 0)
                { lab_show.Text = "测试失败"; textBox1.AppendText("103.06测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 1)
                { lab_show.Text = "测试失败"; textBox1.AppendText("103.07测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 2)
                { lab_show.Text = "测试失败"; textBox1.AppendText("5.02测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 3)
                { lab_show.Text = "测试失败"; textBox1.AppendText("5.03测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 4)
                { lab_show.Text = "测试失败"; textBox1.AppendText("5.04测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 5)
                { lab_show.Text = "测试失败"; textBox1.AppendText("5.05测试失败！\r\n"); progressBar1.Value = 0; }
                if (a == 6)
                { lab_show.Text = "测试失败"; textBox1.AppendText("5.06测试失败！\r\n"); progressBar1.Value = 0; }
                a = 0;
                sec = 0;
                time_12L.Enabled = false;
                MessageBox.Show("测试失败！");
            }
            /*测试完成显示进度条*/
            if (a == 1)
            { lab_show.Text = "测试中...."; textBox1.AppendText("103.06测试成功！\r\n"); progressBar1.Value = 20; }
            if (a == 2)
            { lab_show.Text = "测试中...."; textBox1.AppendText("103.07测试成功！\r\n"); progressBar1.Value = 40; }
            if (a == 3)
            { lab_show.Text = "测试中...."; textBox1.AppendText("5.02测试成功！\r\n"); progressBar1.Value = 50; }
            if (a == 4)
            { lab_show.Text = "测试中...."; textBox1.AppendText("5.03测试成功！\r\n"); progressBar1.Value = 60; }
            if (a == 5)
            { lab_show.Text = "测试中...."; textBox1.AppendText("5.04测试成功！\r\n"); progressBar1.Value = 70; }
            if (a == 6)
            { lab_show.Text = "测试中....."; textBox1.AppendText("5.05测试成功！\r\n"); progressBar1.Value = 90; }
        }

        private void timer2_Tick(object sender, EventArgs e)//测试通讯盒通讯 /*操作盒通讯测试*/
        {
            /*操作盒通讯测试*/
            f = f + 1;
            if (f == 1)
                OmronHostLink.Write("D1000", (ushort)1);// 显示0000号车位运转中正确*
            if (f == 2)
                OmronHostLink.Write("D1000", (ushort)2);// 显示手动运转中
            if (f == 3)
                OmronHostLink.Write("D1000", (ushort)3);// 显示0000未定义故障代码*
            if (f == 4)
                OmronHostLink.Write("D1000", (ushort)4);// 待机界面
            if (f > 4)
                f = 0;
        }
    }

    #endregion

}

