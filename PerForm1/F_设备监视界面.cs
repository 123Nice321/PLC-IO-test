using HslCommunication.Profinet.Inovance;
using HslCommunication.Profinet.Omron;
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
    public partial class F_设备监视界面 : Form
    {
        public F_设备监视界面()
        {
            InitializeComponent();
            //获取当前计算机的串口端口名的数组 并写入到 com串口名的集合（Items）中
            com_PLCserial_port.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            com_SPPBserial_port.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
        }
        private OmronHostLink OmronHostLink = new OmronHostLink(); //实例化欧姆龙 使用232端口通讯
        private OmronHostLinkCMode OmronHostLinkCMode = new OmronHostLinkCMode(); //实例化欧姆龙CMode 使用232端口通讯
        private InovanceSerial InovanceSerial = new InovanceSerial();//实例化汇川Modbus-Rtu串口通讯
        private int in1;
        private void but_PLC_link_Click(object sender, EventArgs e)
        {
            if (but_PLC_link.Text == "连接")
            {
                try
                {
                    InovanceSerial.SerialPortInni(sp =>
                {
                    sp.PortName = com_PLCserial_port.Text;
                    sp.BaudRate = 9600;
                    sp.DataBits = 8;
                    sp.StopBits = System.IO.Ports.StopBits.Two;
                    sp.Parity = System.IO.Ports.Parity.None;
                });
                    InovanceSerial.Series = InovanceSeries.H3U;
                    InovanceSerial.Open();
                    if (InovanceSerial.IsOpen())
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
                InovanceSerial.Close();
                but_PLC_link.Text = "连接";
                but_PLC_link.BackColor = Color.Green;
            }
        }

        private void but_SPPB_link_Click(object sender, EventArgs e)
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

        private void F_设备监视界面_FormClosing(object sender, FormClosingEventArgs e)
        {
            OmronHostLink.Close();
            InovanceSerial.Close();
            OmronHostLinkCMode.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "连接")
            {
                try
                {
                    OmronHostLink.SerialPortInni(sp =>
                    {
                        sp.PortName =comboBox1.Text;
                        sp.BaudRate = 9600;
                        sp.DataBits = 7;
                        sp.StopBits = System.IO.Ports.StopBits.One;
                        sp.Parity = System.IO.Ports.Parity.Even;
                    });

                    OmronHostLink.Open();
                    if (OmronHostLink.IsOpen())
                    {
                        button1.Text = "断开";
                        button1.BackColor = Color.Red;
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
                button1.Text = "连接";
                button1.BackColor = Color.Green;
            }
        }

        private void but_verification1_Click(object sender, EventArgs e)
        {

            //bool D100_7 = InovanceSerial.ReadBool("D100.7").Content;  // 读取D100.7是否通断，注意D100.0等同于D100
            short short_D0 = InovanceSerial.ReadInt16("D0").Content; // 读取D100组成的字
            //label13.Text = short_D100.ToString();
            //十进制转二进制
            //C# 关于转换成二进制位数不够时补齐位数PadLeft（）
            label13.Text=Convert.ToString(short_D0, 2).PadLeft(16, '0'); ;
            char[] arr = label13.Text.ToCharArray();
            //short写入最大值为±32767
            //ushort写入最大值为65535
            label14.Text =  arr[0].ToString();
            label15.Text = arr.Length.ToString() ;
            int in1 = Convert.ToInt32(arr[2]);
            label21.Text = in1.ToString();

        }

        private void but_verification2_Click(object sender, EventArgs e)
        {
            //bool D100_7 = InovanceSerial.ReadBool("D100.7").Content;  // 读取D100.7是否通断，注意D100.0等同于D100
            //short short_D100 = OmronHostLinkCMode.ReadInt16("D100").Content; // 读取D100组成的字
            //label14.Text = short_D100.ToString();
            int in1 = Convert.ToInt32(textBox1.Text);
            //InovanceSerial.Write("100", (short)12345);// 写入寄存器100为12345
            InovanceSerial.Write("D100", (ushort)in1);// 写入寄存器100为45678
        }



        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            in1 = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            in1 = in1 + 1;
            label6.Text = in1.ToString();
            if (in1 == 1)
                progressBar1.Value = 10;
            if (in1 == 2)
                progressBar1.Value = 30;
            if (in1 == 3)
                progressBar1.Value = 50;
            if (in1 == 4)
                progressBar1.Value = 70;
                

            if (in1 == 5)
            {
                progressBar1.Value = 100;
                timer1.Enabled = false;
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            //bool D100_7 = InovanceSerial.ReadBool("D100.7").Content;  // 读取D100.7是否通断，注意D100.0等同于D100
            short short_D20 = OmronHostLinkCMode.ReadInt16("D20").Content; // 读取D100组成的字
            //label13.Text = short_D100.ToString();
            //十进制转二进制
            //C# 关于转换成二进制位数不够时补齐位数PadLeft（）
            label19.Text = Convert.ToString(short_D20, 2).PadLeft(16, '0');
            char[] arr = label19.Text.ToCharArray();
            //short写入最大值为±32767
            //ushort写入最大值为65535
            label17.Text = arr[0].ToString();
            label18.Text = arr.Length.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //label14.Text = short_D100.ToString();
            int in1 = Convert.ToInt32(textBox2.Text);
            //InovanceSerial.Write("100", (short)12345);// 写入寄存器20为12345
            OmronHostLinkCMode.Write("D20", (ushort)in1);// 写入寄存器20为45678
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //bool D100_7 = InovanceSerial.ReadBool("D100.7").Content;  // 读取D100.7是否通断，注意D100.0等同于D100
            short short_D0 = OmronHostLinkCMode.ReadInt16("D0").Content; // 读取D100组成的字
            //label13.Text = short_D100.ToString();
            //十进制转二进制
            //C# 关于转换成二进制位数不够时补齐位数PadLeft（）
            label20.Text = Convert.ToString(short_D0, 2).PadLeft(16, '0');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //label14.Text = short_D100.ToString();
            int in1 = Convert.ToInt32(textBox3.Text);
            //InovanceSerial.Write("100", (short)12345);// 写入寄存器20为12345
            OmronHostLink.Write("CIO100", (ushort)in1);// 写入寄存器20为45678
        }
        private void but_verification3_Click(object sender, EventArgs e)
        {
            //bool D100_7 = InovanceSerial.ReadBool("D100.7").Content;  // 读取D100.7是否通断，注意D100.0等同于D100

            short short_CIO0 = OmronHostLink.ReadInt16("CIO00").Content; // 读取D100组成的字

            //label13.Text = short_D100.ToString();
            //十进制转二进制
            //C# 关于转换成二进制位数不够时补齐位数PadLeft（）

            label25.Text = Convert.ToString(short_CIO0, 2).PadLeft(12, '0');
            char[] arr = label25.Text.ToCharArray();

            //short写入最大值为±32767
            //ushort写入最大值为 65535

            label26.Text = arr[0].ToString();
            label27.Text = arr.Length.ToString();

        }
    }
}
