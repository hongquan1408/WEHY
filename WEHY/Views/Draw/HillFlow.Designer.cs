namespace WEHY.Views.Draw
{
    partial class HillFlow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnVisulize = new System.Windows.Forms.Button();
            this.cbbRiverFlow = new System.Windows.Forms.ComboBox();
            this.gbVisulize = new System.Windows.Forms.GroupBox();
            this.chartRiverFlow = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbInformation.SuspendLayout();
            this.gbVisulize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRiverFlow)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInformation
            // 
            this.gbInformation.Controls.Add(this.btnClose);
            this.gbInformation.Controls.Add(this.btnVisulize);
            this.gbInformation.Controls.Add(this.cbbRiverFlow);
            this.gbInformation.Location = new System.Drawing.Point(13, 12);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(200, 248);
            this.gbInformation.TabIndex = 0;
            this.gbInformation.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(48, 197);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnVisulize
            // 
            this.btnVisulize.Location = new System.Drawing.Point(48, 114);
            this.btnVisulize.Name = "btnVisulize";
            this.btnVisulize.Size = new System.Drawing.Size(75, 23);
            this.btnVisulize.TabIndex = 1;
            this.btnVisulize.Text = "Visulize Now";
            this.btnVisulize.UseVisualStyleBackColor = true;
            this.btnVisulize.Click += new System.EventHandler(this.btnVisulize_Click);
            // 
            // cbbRiverFlow
            // 
            this.cbbRiverFlow.FormattingEnabled = true;
            this.cbbRiverFlow.Location = new System.Drawing.Point(7, 57);
            this.cbbRiverFlow.Name = "cbbRiverFlow";
            this.cbbRiverFlow.Size = new System.Drawing.Size(187, 21);
            this.cbbRiverFlow.TabIndex = 0;
            // 
            // gbVisulize
            // 
            this.gbVisulize.Controls.Add(this.chartRiverFlow);
            this.gbVisulize.Location = new System.Drawing.Point(219, 12);
            this.gbVisulize.Name = "gbVisulize";
            this.gbVisulize.Size = new System.Drawing.Size(1041, 486);
            this.gbVisulize.TabIndex = 1;
            this.gbVisulize.TabStop = false;
            // 
            // chartRiverFlow
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRiverFlow.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRiverFlow.Legends.Add(legend1);
            this.chartRiverFlow.Location = new System.Drawing.Point(6, 19);
            this.chartRiverFlow.Name = "chartRiverFlow";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "River Flow";
            this.chartRiverFlow.Series.Add(series1);
            this.chartRiverFlow.Size = new System.Drawing.Size(1026, 461);
            this.chartRiverFlow.TabIndex = 0;
            this.chartRiverFlow.Text = "chart1";
            // 
            // HillFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 510);
            this.Controls.Add(this.gbVisulize);
            this.Controls.Add(this.gbInformation);
            this.Name = "HillFlow";
            this.Text = "Hill Flow";
            this.gbInformation.ResumeLayout(false);
            this.gbVisulize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRiverFlow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.GroupBox gbVisulize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnVisulize;
        private System.Windows.Forms.ComboBox cbbRiverFlow;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRiverFlow;
    }
}