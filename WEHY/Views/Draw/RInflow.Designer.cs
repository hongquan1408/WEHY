namespace WEHY.Views.Draw
{
    partial class RInflow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbUpstream = new System.Windows.Forms.RadioButton();
            this.rbLateral = new System.Windows.Forms.RadioButton();
            this.cbbInflow = new System.Windows.Forms.ComboBox();
            this.btnVisulize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chartInFlow = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartInFlow)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnVisulize);
            this.groupBox1.Controls.Add(this.cbbInflow);
            this.groupBox1.Controls.Add(this.rbLateral);
            this.groupBox1.Controls.Add(this.rbUpstream);
            this.groupBox1.Location = new System.Drawing.Point(5, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 487);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chartInFlow);
            this.groupBox2.Location = new System.Drawing.Point(225, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1032, 487);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
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
            // cbbInflow
            // 
            this.cbbInflow.FormattingEnabled = true;
            this.cbbInflow.Location = new System.Drawing.Point(8, 110);
            this.cbbInflow.Name = "cbbInflow";
            this.cbbInflow.Size = new System.Drawing.Size(182, 21);
            this.cbbInflow.TabIndex = 2;
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
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(50, 228);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chartInFlow
            // 
            chartArea2.Name = "ChartArea1";
            this.chartInFlow.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartInFlow.Legends.Add(legend2);
            this.chartInFlow.Location = new System.Drawing.Point(3, 13);
            this.chartInFlow.Name = "chartInFlow";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "In Flow";
            this.chartInFlow.Series.Add(series2);
            this.chartInFlow.Size = new System.Drawing.Size(1026, 461);
            this.chartInFlow.TabIndex = 1;
            this.chartInFlow.Text = "chart1";
            // 
            // RInflow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 500);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RInflow";
            this.Text = "In Flow";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartInFlow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbInflow;
        private System.Windows.Forms.RadioButton rbLateral;
        private System.Windows.Forms.RadioButton rbUpstream;
        private System.Windows.Forms.Button btnVisulize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartInFlow;
    }
}