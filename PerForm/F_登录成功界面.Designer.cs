
namespace PLC点位_IO测试系统软件.PerForm
{
    partial class F_登录成功界面
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_登录成功界面));
            this.label2 = new System.Windows.Forms.Label();
            this.but_begin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.but_Exit1 = new System.Windows.Forms.Button();
            this.text_project_name = new System.Windows.Forms.TextBox();
            this.text_treaty_number = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(190, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 33);
            this.label2.TabIndex = 15;
            this.label2.Text = "项目名称:";
            // 
            // but_begin
            // 
            this.but_begin.Font = new System.Drawing.Font("楷体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_begin.Location = new System.Drawing.Point(404, 386);
            this.but_begin.Margin = new System.Windows.Forms.Padding(4);
            this.but_begin.Name = "but_begin";
            this.but_begin.Size = new System.Drawing.Size(215, 68);
            this.but_begin.TabIndex = 18;
            this.but_begin.Text = "开始测试";
            this.but_begin.UseVisualStyleBackColor = true;
            this.but_begin.Click += new System.EventHandler(this.but_begin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(221, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 68);
            this.label1.TabIndex = 13;
            this.label1.Text = "IO点位测试系统";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(190, 278);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 33);
            this.label3.TabIndex = 14;
            this.label3.Text = "合约编号:";
            // 
            // but_Exit1
            // 
            this.but_Exit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Exit1.Font = new System.Drawing.Font("楷体", 15F);
            this.but_Exit1.Location = new System.Drawing.Point(858, 536);
            this.but_Exit1.Margin = new System.Windows.Forms.Padding(4);
            this.but_Exit1.Name = "but_Exit1";
            this.but_Exit1.Size = new System.Drawing.Size(167, 52);
            this.but_Exit1.TabIndex = 12;
            this.but_Exit1.Text = "退出";
            this.but_Exit1.UseVisualStyleBackColor = true;
            this.but_Exit1.Click += new System.EventHandler(this.but_Exit1_Click);
            // 
            // text_project_name
            // 
            this.text_project_name.Font = new System.Drawing.Font("楷体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_project_name.Location = new System.Drawing.Point(377, 180);
            this.text_project_name.Margin = new System.Windows.Forms.Padding(4);
            this.text_project_name.Name = "text_project_name";
            this.text_project_name.Size = new System.Drawing.Size(323, 45);
            this.text_project_name.TabIndex = 16;
            this.text_project_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_project_name_KeyPress);
            // 
            // text_treaty_number
            // 
            this.text_treaty_number.Font = new System.Drawing.Font("楷体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_treaty_number.Location = new System.Drawing.Point(377, 274);
            this.text_treaty_number.Margin = new System.Windows.Forms.Padding(4);
            this.text_treaty_number.Name = "text_treaty_number";
            this.text_treaty_number.Size = new System.Drawing.Size(323, 45);
            this.text_treaty_number.TabIndex = 17;
            this.text_treaty_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_treaty_number_KeyPress);
            // 
            // F_登录成功界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1038, 601);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.but_begin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.but_Exit1);
            this.Controls.Add(this.text_project_name);
            this.Controls.Add(this.text_treaty_number);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "F_登录成功界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录成功界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_登录成功界面_FormClosing);
            this.Load += new System.EventHandler(this.F_登录成功界面_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button but_begin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button but_Exit1;
        private System.Windows.Forms.TextBox text_project_name;
        private System.Windows.Forms.TextBox text_treaty_number;
    }
}