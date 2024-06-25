namespace MoveIT
{
    partial class UserView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserView));
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.weightChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuBtn = new System.Windows.Forms.Button();
            this.addWeightBtn = new System.Windows.Forms.Button();
            this.weightTxtBx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.weightChart)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(939, 40);
            this.label2.TabIndex = 0;
            this.label2.Text = "PROGRESSION";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(103, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Poids";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // weightChart
            // 
            chartArea1.Name = "ChartArea1";
            this.weightChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.weightChart.Legends.Add(legend1);
            this.weightChart.Location = new System.Drawing.Point(33, 122);
            this.weightChart.Name = "weightChart";
            this.weightChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.weightChart.Series.Add(series1);
            this.weightChart.Size = new System.Drawing.Size(800, 325);
            this.weightChart.TabIndex = 24;
            // 
            // menuBtn
            // 
            this.menuBtn.BackColor = System.Drawing.Color.Navy;
            this.menuBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.menuBtn.FlatAppearance.BorderSize = 0;
            this.menuBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Navy;
            this.menuBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.menuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuBtn.ForeColor = System.Drawing.Color.White;
            this.menuBtn.Location = new System.Drawing.Point(826, 462);
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.Size = new System.Drawing.Size(125, 35);
            this.menuBtn.TabIndex = 25;
            this.menuBtn.Text = "Menu";
            this.menuBtn.UseVisualStyleBackColor = false;
            this.menuBtn.Click += new System.EventHandler(this.menuBtn_Click);
            // 
            // addWeightBtn
            // 
            this.addWeightBtn.BackColor = System.Drawing.Color.Navy;
            this.addWeightBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addWeightBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addWeightBtn.FlatAppearance.BorderSize = 0;
            this.addWeightBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Navy;
            this.addWeightBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.addWeightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addWeightBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addWeightBtn.ForeColor = System.Drawing.Color.White;
            this.addWeightBtn.Location = new System.Drawing.Point(826, 263);
            this.addWeightBtn.Name = "addWeightBtn";
            this.addWeightBtn.Size = new System.Drawing.Size(118, 35);
            this.addWeightBtn.TabIndex = 25;
            this.addWeightBtn.Text = "Ajouter";
            this.addWeightBtn.UseVisualStyleBackColor = false;
            this.addWeightBtn.Click += new System.EventHandler(this.addWeightBtn_Click);
            this.addWeightBtn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addWeightBtn_KeyPress);
            // 
            // weightTxtBx
            // 
            this.weightTxtBx.Location = new System.Drawing.Point(826, 237);
            this.weightTxtBx.Name = "weightTxtBx";
            this.weightTxtBx.Size = new System.Drawing.Size(90, 20);
            this.weightTxtBx.TabIndex = 26;
            this.weightTxtBx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(719, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nouveau poids";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(922, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "kg";
            // 
            // UserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(964, 511);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.weightTxtBx);
            this.Controls.Add(this.addWeightBtn);
            this.Controls.Add(this.menuBtn);
            this.Controls.Add(this.weightChart);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UserView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserView";
            ((System.ComponentModel.ISupportInitialize)(this.weightChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button menuBtn;
        private System.Windows.Forms.Button addWeightBtn;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox weightTxtBx;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataVisualization.Charting.Chart weightChart;
    }
}