﻿namespace WEHY.Views.Draw
{
    partial class HCHillFlow
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
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnVisulize = new System.Windows.Forms.Button();
            this.cbbRiverFlow = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webBrowserchart = new System.Windows.Forms.WebBrowser();
            this.gbInformation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInformation
            // 
            this.gbInformation.Controls.Add(this.btnClose);
            this.gbInformation.Controls.Add(this.btnVisulize);
            this.gbInformation.Controls.Add(this.cbbRiverFlow);
            this.gbInformation.Location = new System.Drawing.Point(12, 12);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(200, 248);
            this.gbInformation.TabIndex = 1;
            this.gbInformation.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(48, 201);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webBrowserchart);
            this.groupBox1.Location = new System.Drawing.Point(218, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1039, 497);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // webBrowserchart
            // 
            this.webBrowserchart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserchart.Location = new System.Drawing.Point(3, 16);
            this.webBrowserchart.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserchart.Name = "webBrowserchart";
            this.webBrowserchart.Size = new System.Drawing.Size(1033, 478);
            this.webBrowserchart.TabIndex = 1;
            // 
            // HCHillFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 521);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbInformation);
            this.Name = "HCHillFlow";
            this.Text = "Hill Flow";
            this.gbInformation.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnVisulize;
        private System.Windows.Forms.ComboBox cbbRiverFlow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.WebBrowser webBrowserchart;
    }
}