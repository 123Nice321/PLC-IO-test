
namespace PLC点位_IO测试系统软件.PerForm
{
    partial class F_PLC品牌型号选择界面
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_PLC品牌型号选择界面));
            this.but_OMRPLC = new System.Windows.Forms.Button();
            this.but_HuiChuanPLC = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_OMRPLC
            // 
            this.but_OMRPLC.Font = new System.Drawing.Font("楷体", 13F);
            this.but_OMRPLC.Location = new System.Drawing.Point(23, 30);
            this.but_OMRPLC.Margin = new System.Windows.Forms.Padding(2);
            this.but_OMRPLC.Name = "but_OMRPLC";
            this.but_OMRPLC.Size = new System.Drawing.Size(104, 52);
            this.but_OMRPLC.TabIndex = 0;
            this.but_OMRPLC.Text = "欧姆龙PLC二层";
            this.but_OMRPLC.UseVisualStyleBackColor = true;
            this.but_OMRPLC.Click += new System.EventHandler(this.but_OMRPLC_Click);
            // 
            // but_HuiChuanPLC
            // 
            this.but_HuiChuanPLC.Font = new System.Drawing.Font("楷体", 13F);
            this.but_HuiChuanPLC.Location = new System.Drawing.Point(23, 36);
            this.but_HuiChuanPLC.Margin = new System.Windows.Forms.Padding(2);
            this.but_HuiChuanPLC.Name = "but_HuiChuanPLC";
            this.but_HuiChuanPLC.Size = new System.Drawing.Size(104, 52);
            this.but_HuiChuanPLC.TabIndex = 0;
            this.but_HuiChuanPLC.Text = "汇川PLC 二层";
            this.but_HuiChuanPLC.UseVisualStyleBackColor = true;
            this.but_HuiChuanPLC.Click += new System.EventHandler(this.but_HuiChuanPLC_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.but_HuiChuanPLC);
            this.groupBox1.Location = new System.Drawing.Point(50, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 153);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "汇川PLC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(182, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "汇川测试时，先将测试程序传入PLC\r\n进入下一个界面可以打开测试程序文件夹";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.but_OMRPLC);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(50, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(682, 165);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "欧姆龙PLC";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("楷体", 12F);
            this.button1.Location = new System.Drawing.Point(245, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "底坑三层";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("楷体", 12F);
            this.button2.Location = new System.Drawing.Point(339, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 39);
            this.button2.TabIndex = 4;
            this.button2.Text = "多层升降横移";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("楷体", 12F);
            this.button3.Location = new System.Drawing.Point(339, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 39);
            this.button3.TabIndex = 6;
            this.button3.Text = "多层升降横移";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("楷体", 12F);
            this.button4.Location = new System.Drawing.Point(245, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 39);
            this.button4.TabIndex = 5;
            this.button4.Text = "底坑三层";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // F_PLC品牌型号选择界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(849, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "F_PLC品牌型号选择界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLC品牌型号选择界面";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_OMRPLC;
        private System.Windows.Forms.Button but_HuiChuanPLC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}