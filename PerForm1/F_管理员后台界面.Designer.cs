
namespace PLC点位_IO测试系统软件.PerForm
{
    partial class F_管理员后台界面
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_管理员后台界面));
            this.but_Exit1 = new System.Windows.Forms.Button();
            this.but_Report_testing = new System.Windows.Forms.Button();
            this.but_PLC_testing = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // but_Exit1
            // 
            this.but_Exit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Exit1.AutoSize = true;
            this.but_Exit1.Font = new System.Drawing.Font("楷体", 15F);
            this.but_Exit1.Location = new System.Drawing.Point(875, 483);
            this.but_Exit1.Name = "but_Exit1";
            this.but_Exit1.Size = new System.Drawing.Size(125, 42);
            this.but_Exit1.TabIndex = 13;
            this.but_Exit1.Text = "退出";
            this.but_Exit1.UseVisualStyleBackColor = true;
            this.but_Exit1.Click += new System.EventHandler(this.but_Exit1_Click);
            // 
            // but_Report_testing
            // 
            this.but_Report_testing.Font = new System.Drawing.Font("楷体", 15F);
            this.but_Report_testing.Location = new System.Drawing.Point(110, 10);
            this.but_Report_testing.Name = "but_Report_testing";
            this.but_Report_testing.Size = new System.Drawing.Size(153, 63);
            this.but_Report_testing.TabIndex = 15;
            this.but_Report_testing.Text = "报表测试界面";
            this.but_Report_testing.UseVisualStyleBackColor = true;
            this.but_Report_testing.Click += new System.EventHandler(this.but_Report_testing_Click);
            // 
            // but_PLC_testing
            // 
            this.but_PLC_testing.Font = new System.Drawing.Font("楷体", 15F);
            this.but_PLC_testing.Location = new System.Drawing.Point(110, 107);
            this.but_PLC_testing.Name = "but_PLC_testing";
            this.but_PLC_testing.Size = new System.Drawing.Size(153, 63);
            this.but_PLC_testing.TabIndex = 15;
            this.but_PLC_testing.Text = "设备测试界面";
            this.but_PLC_testing.UseVisualStyleBackColor = true;
            this.but_PLC_testing.Click += new System.EventHandler(this.but_PLC_testing_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(340, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 63);
            this.button1.TabIndex = 16;
            this.button1.Text = "塔库控制柜 输入输出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // F_管理员后台界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 535);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.but_PLC_testing);
            this.Controls.Add(this.but_Report_testing);
            this.Controls.Add(this.but_Exit1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "F_管理员后台界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_管理员后台界面";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.F_管理员后台界面_FormClosed);
            this.Load += new System.EventHandler(this.F_管理员后台界面_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_Exit1;
        private System.Windows.Forms.Button but_Report_testing;
        private System.Windows.Forms.Button but_PLC_testing;
        private System.Windows.Forms.Button button1;
    }
}