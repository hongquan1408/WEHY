namespace WEHY.Views.Draw
{
    partial class LVHydroOut
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
            this.cbbType = new System.Windows.Forms.ComboBox();
            this.cbbRiverFlow = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnVisulize);
            this.groupBox1.Controls.Add(this.cbbType);
            this.groupBox1.Controls.Add(this.cbbRiverFlow);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 485);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
           
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
            // cbbType
            // 
            this.cbbType.FormattingEnabled = true;
            this.cbbType.Location = new System.Drawing.Point(9, 87);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(185, 21);
            this.cbbType.TabIndex = 1;
            // 
            // cbbRiverFlow
            // 
            this.cbbRiverFlow.FormattingEnabled = true;
            this.cbbRiverFlow.Location = new System.Drawing.Point(9, 34);
            this.cbbRiverFlow.Name = "cbbRiverFlow";
            this.cbbRiverFlow.Size = new System.Drawing.Size(185, 21);
            this.cbbRiverFlow.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cartesianChart1);
            this.groupBox2.Location = new System.Drawing.Point(208, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1063, 507);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Hoverable = true;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 11);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.ScrollHorizontalFrom = 0D;
            this.cartesianChart1.ScrollHorizontalTo = 0D;
            this.cartesianChart1.ScrollMode = LiveCharts.ScrollMode.None;
            this.cartesianChart1.ScrollVerticalFrom = 0D;
            this.cartesianChart1.ScrollVerticalTo = 0D;
            this.cartesianChart1.Size = new System.Drawing.Size(1063, 496);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // LVHydroOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 508);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "LVHydroOut";
            this.Text = "Hydro Out";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnVisulize;
        private System.Windows.Forms.ComboBox cbbType;
        private System.Windows.Forms.ComboBox cbbRiverFlow;
        private System.Windows.Forms.GroupBox groupBox2;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
    }
}