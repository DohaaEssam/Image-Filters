using System;

namespace ImageFilters
{
    partial class Form1
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
                components.Dispose();
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnGraph;
            this.dev1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputGraph = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.finalPicture = new System.Windows.Forms.PictureBox();
            this.originalPicture = new System.Windows.Forms.PictureBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.inputTrim = new System.Windows.Forms.TextBox();
            this.labelTrim = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.comboBoxAlgorithm = new System.Windows.Forms.ComboBox();
            this.inputMaxSize = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnOpenImage = new System.Windows.Forms.Button();
            btnGraph = new System.Windows.Forms.Button();
            this.dev1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finalPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGraph
            // 
            btnGraph.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnGraph.Location = new System.Drawing.Point(1130, 589);
            btnGraph.Margin = new System.Windows.Forms.Padding(4);
            btnGraph.Name = "btnGraph";
            btnGraph.Size = new System.Drawing.Size(272, 38);
            btnGraph.TabIndex = 7;
            btnGraph.Text = "Graph";
            btnGraph.UseVisualStyleBackColor = true;
            btnGraph.Click += new System.EventHandler(this.btnZGraph_Click);
            // 
            // dev1
            // 
            this.dev1.Controls.Add(this.label3);
            this.dev1.Controls.Add(this.inputGraph);
            this.dev1.Controls.Add(this.label2);
            this.dev1.Controls.Add(this.label1);
            this.dev1.Controls.Add(this.labelTime);
            this.dev1.Controls.Add(this.finalPicture);
            this.dev1.Controls.Add(this.originalPicture);
            this.dev1.Controls.Add(this.labelScore);
            this.dev1.Controls.Add(btnGraph);
            this.dev1.Controls.Add(this.inputTrim);
            this.dev1.Controls.Add(this.labelTrim);
            this.dev1.Controls.Add(this.labelSize);
            this.dev1.Controls.Add(this.comboBoxFilter);
            this.dev1.Controls.Add(this.comboBoxAlgorithm);
            this.dev1.Controls.Add(this.inputMaxSize);
            this.dev1.Controls.Add(this.btnFilter);
            this.dev1.Controls.Add(this.btnOpenImage);
            this.dev1.Location = new System.Drawing.Point(13, 13);
            this.dev1.Margin = new System.Windows.Forms.Padding(4);
            this.dev1.Name = "dev1";
            this.dev1.Padding = new System.Windows.Forms.Padding(4);
            this.dev1.Size = new System.Drawing.Size(1546, 644);
            this.dev1.TabIndex = 1;
            this.dev1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1125, 549);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "Graph Size";
            // 
            // inputGraph
            // 
            this.inputGraph.Location = new System.Drawing.Point(1293, 553);
            this.inputGraph.Margin = new System.Windows.Forms.Padding(4);
            this.inputGraph.Name = "inputGraph";
            this.inputGraph.Size = new System.Drawing.Size(109, 22);
            this.inputGraph.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(546, 592);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "Sort";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(546, 547);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Filter";
            // 
            // labelTime
            // 
            this.labelTime.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(878, 598);
            this.labelTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(86, 28);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "Time:";
            // 
            // finalPicture
            // 
            this.finalPicture.Location = new System.Drawing.Point(778, 23);
            this.finalPicture.Margin = new System.Windows.Forms.Padding(4);
            this.finalPicture.Name = "finalPicture";
            this.finalPicture.Size = new System.Drawing.Size(720, 500);
            this.finalPicture.TabIndex = 2;
            this.finalPicture.TabStop = false;
            // 
            // originalPicture
            // 
            this.originalPicture.Location = new System.Drawing.Point(37, 23);
            this.originalPicture.Margin = new System.Windows.Forms.Padding(4);
            this.originalPicture.Name = "originalPicture";
            this.originalPicture.Size = new System.Drawing.Size(720, 500);
            this.originalPicture.TabIndex = 3;
            this.originalPicture.TabStop = false;
            // 
            // labelScore
            // 
            this.labelScore.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(962, 598);
            this.labelScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(122, 28);
            this.labelScore.TabIndex = 0;
            this.labelScore.Text = " Sec";
            // 
            // inputTrim
            // 
            this.inputTrim.Location = new System.Drawing.Point(353, 598);
            this.inputTrim.Margin = new System.Windows.Forms.Padding(4);
            this.inputTrim.Name = "inputTrim";
            this.inputTrim.Size = new System.Drawing.Size(109, 22);
            this.inputTrim.TabIndex = 6;
            // 
            // labelTrim
            // 
            this.labelTrim.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrim.Location = new System.Drawing.Point(238, 592);
            this.labelTrim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTrim.Name = "labelTrim";
            this.labelTrim.Size = new System.Drawing.Size(81, 28);
            this.labelTrim.TabIndex = 5;
            this.labelTrim.Text = "Trim";
            // 
            // labelSize
            // 
            this.labelSize.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSize.Location = new System.Drawing.Point(238, 543);
            this.labelSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(81, 28);
            this.labelSize.TabIndex = 4;
            this.labelSize.Text = "Size";
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.Items.AddRange(new object[] {
            "1- Alpha Trim",
            "2- Adaptive med"});
            this.comboBoxFilter.Location = new System.Drawing.Point(639, 550);
            this.comboBoxFilter.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(168, 24);
            this.comboBoxFilter.TabIndex = 0;
            // 
            // comboBoxAlgorithm
            // 
            this.comboBoxAlgorithm.Items.AddRange(new object[] {
            "1- Quick Sort",
            "2- Counting Sort",
            "3- Select k value"});
            this.comboBoxAlgorithm.Location = new System.Drawing.Point(639, 596);
            this.comboBoxAlgorithm.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            this.comboBoxAlgorithm.Size = new System.Drawing.Size(168, 24);
            this.comboBoxAlgorithm.TabIndex = 1;
            // 
            // inputMaxSize
            // 
            this.inputMaxSize.Location = new System.Drawing.Point(353, 549);
            this.inputMaxSize.Margin = new System.Windows.Forms.Padding(4);
            this.inputMaxSize.Name = "inputMaxSize";
            this.inputMaxSize.Size = new System.Drawing.Size(109, 22);
            this.inputMaxSize.TabIndex = 2;
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(883, 547);
            this.btnFilter.Size = new System.Drawing.Size(145, 38);
            this.btnFilter.Text = "Filter";
            this.btnFilter.Click += new System.EventHandler(this.btnFilterClicked);
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenImage.Location = new System.Drawing.Point(37, 547);
            this.btnOpenImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(150, 77);
            this.btnOpenImage.TabIndex = 3;
            this.btnOpenImage.Text = "Open Image";
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 670);
            this.Controls.Add(this.dev1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Image Filters";
            this.dev1.ResumeLayout(false);
            this.dev1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finalPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPicture)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.GroupBox dev1;
        private System.Windows.Forms.PictureBox finalPicture;
        private System.Windows.Forms.PictureBox originalPicture;
        private System.Windows.Forms.TextBox inputMaxSize;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.ComboBox comboBoxAlgorithm;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TextBox inputTrim;
        private System.Windows.Forms.Label labelTrim;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputGraph;
    }
}

