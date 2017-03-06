namespace WEHY.Views.Draw
{
    partial class HydroOut
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
            this.cbbRiverFlow = new System.Windows.Forms.ComboBox();
            this.cbbType = new System.Windows.Forms.ComboBox();
            this.btnVisulize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chartHydroOut = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHydroOut)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnVisulize);
            this.groupBox1.Controls.Add(this.cbbType);
            this.groupBox1.Controls.Add(this.cbbRiverFlow);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 485);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chartHydroOut);
            this.groupBox2.Location = new System.Drawing.Point(210, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1044, 485);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // cbbRiverFlow
            // 
            this.cbbRiverFlow.FormattingEnabled = true;
            this.cbbRiverFlow.Location = new System.Drawing.Point(9, 34);
            this.cbbRiverFlow.Name = "cbbRiverFlow";
            this.cbbRiverFlow.Size = new System.Drawing.Size(185, 21);
            this.cbbRiverFlow.TabIndex = 0;
            // 
            // cbbType
            // 
            this.cbbType.FormattingEnabled = true;
            this.cbbType.Location = new System.Drawing.Point(9, 87);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(185, 21);
            this.cbbType.TabIndex = 1;
            // 
            // btnVisulize
            // 
            this.btnVisulize.Location = new System.Drawing.Point(57, 144);
            this.btnVisulize.Name = "btnVisulize";
            this.btnVisulize.Size = new System.Drawing.Size(75, 23);
            this.btnVisulize.TabIndex = 2;
            this.btnVisulize.Text = "Visulize Now";
            this.btnVisulize.UseVisualStyleBackColor = true;
            this.btnVisulize.Click += new System.EventHandler(this.btnVisulize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(57, 215);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chartHydroOut
            // 
            chartArea2.Name = "ChartArea1";
            this.chartHydroOut.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartHydroOut.Legends.Add(legend2);
            this.chartHydroOut.Location = new System.Drawing.Point(9, 12);
            this.chartHydroOut.Name = "chartHydroOut";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Hydro Out";
            this.chartHydroOut.Series.Add(series2);
            this.chartHydroOut.Size = new System.Drawing.Size(1026, 461);
            this.chartHydroOut.TabIndex = 1;
            this.chartHydroOut.Text = "chart1";
            // 
            // HydroOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 500);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "HydroOut";
            this.Text = "Hydro Out";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartHydroOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnVisulize;
        private System.Windows.Forms.ComboBox cbbType;
        private System.Windows.Forms.ComboBox cbbRiverFlow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHydroOut;
    }
}