
namespace PLC点位_IO测试系统软件.PerForm
{
    partial class F_报表
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.but_report_printing = new System.Windows.Forms.Button();
            this.but_Print = new System.Windows.Forms.Button();
            this.but_Report_saving = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PLC点位_IO测试系统软件.报表打印.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(789, 603);
            this.reportViewer1.TabIndex = 0;
            // 
            // but_report_printing
            // 
            this.but_report_printing.Font = new System.Drawing.Font("楷体", 15F);
            this.but_report_printing.Location = new System.Drawing.Point(813, 31);
            this.but_report_printing.Name = "but_report_printing";
            this.but_report_printing.Size = new System.Drawing.Size(150, 57);
            this.but_report_printing.TabIndex = 6;
            this.but_report_printing.Text = "报表刷新";
            this.but_report_printing.UseVisualStyleBackColor = true;
            this.but_report_printing.Click += new System.EventHandler(this.but_report_printing_Click);
            // 
            // but_Print
            // 
            this.but_Print.Font = new System.Drawing.Font("楷体", 14F);
            this.but_Print.Location = new System.Drawing.Point(813, 118);
            this.but_Print.Name = "but_Print";
            this.but_Print.Size = new System.Drawing.Size(150, 58);
            this.but_Print.TabIndex = 7;
            this.but_Print.Text = "报表打印";
            this.but_Print.UseVisualStyleBackColor = true;
            this.but_Print.Click += new System.EventHandler(this.but_Print_Click);
            // 
            // but_Report_saving
            // 
            this.but_Report_saving.Font = new System.Drawing.Font("楷体", 15F);
            this.but_Report_saving.Location = new System.Drawing.Point(813, 213);
            this.but_Report_saving.Name = "but_Report_saving";
            this.but_Report_saving.Size = new System.Drawing.Size(150, 56);
            this.but_Report_saving.TabIndex = 8;
            this.but_Report_saving.Text = "报表保存";
            this.but_Report_saving.UseVisualStyleBackColor = true;
            this.but_Report_saving.Click += new System.EventHandler(this.but_Report_saving_Click);
            // 
            // F_报表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 603);
            this.Controls.Add(this.but_Report_saving);
            this.Controls.Add(this.but_Print);
            this.Controls.Add(this.but_report_printing);
            this.Controls.Add(this.reportViewer1);
            this.Name = "F_报表";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_报表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F_报表_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button but_report_printing;
        private System.Windows.Forms.Button but_Print;
        private System.Windows.Forms.Button but_Report_saving;
    }
}