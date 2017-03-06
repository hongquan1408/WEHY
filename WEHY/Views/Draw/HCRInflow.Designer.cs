namespace WEHY.Views.Draw
{
    partial class HCRInflow
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnVisulize = new System.Windows.Forms.Button();
            this.cbbInflow = new System.Windows.Forms.ComboBox();
            this.rbLateral = new System.Windows.Forms.RadioButton();
            this.rbUpstream = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowserChart = new System.Windows.Forms.WebBrowser();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnVisulize);
            this.groupBox1.Controls.Add(this.cbbInflow);
            this.groupBox1.Controls.Add(this.rbLateral);
            this.groupBox1.Controls.Add(this.rbUpstream);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 487);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(50, 240);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnVisulize
            // 
            this.btnVisulize.Location = new System.Drawing.Point(50, 168);
            this.btnVisulize.Name = "btnVisulize";
            this.btnVisulize.Size = new System.Drawing.Size(75, 23);
            this.btnVisulize.TabIndex = 3;
            this.btnVisulize.Text = "Visulize Now";
            this.btnVisulize.UseVisualStyleBackColor = true;
            this.btnVisulize.Click += new System.EventHandler(this.btnVisulize_Click);
            // 
            // cbbInflow
            // 
            this.cbbInflow.FormattingEnabled = true;
            this.cbbInflow.Location = new System.Drawing.Point(8, 110);
            this.cbbInflow.Name = "cbbInflow";
            this.cbbInflow.Size = new System.Drawing.Size(200, 21);
            this.cbbInflow.TabIndex = 2;
            // 
            // rbLateral
            // 
            this.rbLateral.AutoSize = true;
            this.rbLateral.Location = new System.Drawing.Point(133, 50);
            this.rbLateral.Name = "rbLateral";
            this.rbLateral.Size = new System.Drawing.Size(57, 17);
            this.rbLateral.TabIndex = 1;
            this.rbLateral.TabStop = true;
            this.rbLateral.Text = "Lateral";
            this.rbLateral.UseVisualStyleBackColor = true;
            this.rbLateral.CheckedChanged += new System.EventHandler(this.rbLateral_CheckedChanged);
            // 
            // rbUpstream
            // 
            this.rbUpstream.AutoSize = true;
            this.rbUpstream.Location = new System.Drawing.Point(8, 50);
            this.rbUpstream.Name = "rbUpstream";
            this.rbUpstream.Size = new System.Drawing.Size(118, 17);
            this.rbUpstream.TabIndex = 0;
            this.rbUpstream.TabStop = true;
            this.rbUpstream.Text = "Upstream Boundary";
            this.rbUpstream.UseVisualStyleBackColor = true;
            this.rbUpstream.CheckedChanged += new System.EventHandler(this.rbUpstream_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowserChart);
            this.groupBox2.Location = new System.Drawing.Point(224, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1035, 506);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // webBrowserChart
            // 
            this.webBrowserChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserChart.Location = new System.Drawing.Point(3, 16);
            this.webBrowserChart.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserChart.Name = "webBrowserChart";
            this.webBrowserChart.Size = new System.Drawing.Size(1029, 487);
            this.webBrowserChart.TabIndex = 0;
            // 
            // HCRInflow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 519);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "HCRInflow";
            this.Text = "In Flow";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnVisulize;
        private System.Windows.Forms.ComboBox cbbInflow;
        private System.Windows.Forms.RadioButton rbLateral;
        private System.Windows.Forms.RadioButton rbUpstream;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowserChart;
    }
}