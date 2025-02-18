namespace MMREAPER
{
    partial class MainWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ConnButton = new System.Windows.Forms.Button();
            this.AuthButton = new System.Windows.Forms.Button();
            this.SubButton = new System.Windows.Forms.Button();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CloseButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnButton
            // 
            this.ConnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ConnButton.FlatAppearance.BorderSize = 0;
            this.ConnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.ConnButton.Location = new System.Drawing.Point(657, 97);
            this.ConnButton.Name = "ConnButton";
            this.ConnButton.Size = new System.Drawing.Size(115, 40);
            this.ConnButton.TabIndex = 0;
            this.ConnButton.Text = "Connect";
            this.ConnButton.UseVisualStyleBackColor = false;
            this.ConnButton.Click += new System.EventHandler(this.Connect);
            // 
            // AuthButton
            // 
            this.AuthButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.AuthButton.FlatAppearance.BorderSize = 0;
            this.AuthButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AuthButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.AuthButton.Location = new System.Drawing.Point(657, 143);
            this.AuthButton.Name = "AuthButton";
            this.AuthButton.Size = new System.Drawing.Size(115, 40);
            this.AuthButton.TabIndex = 1;
            this.AuthButton.Text = "Auth";
            this.AuthButton.UseVisualStyleBackColor = false;
            this.AuthButton.Click += new System.EventHandler(this.Authenticate);
            // 
            // SubButton
            // 
            this.SubButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.SubButton.FlatAppearance.BorderSize = 0;
            this.SubButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.SubButton.Location = new System.Drawing.Point(657, 189);
            this.SubButton.Name = "SubButton";
            this.SubButton.Size = new System.Drawing.Size(115, 40);
            this.SubButton.TabIndex = 2;
            this.SubButton.Text = "Subscribe";
            this.SubButton.UseVisualStyleBackColor = false;
            this.SubButton.Click += new System.EventHandler(this.Subscribe);
            // 
            // Chart
            // 
            this.Chart.BackColor = System.Drawing.Color.Transparent;
            this.Chart.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Interval = 150D;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chartArea1.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 72F;
            chartArea1.Position.Width = 80.05473F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 3F;
            chartArea2.AlignWithChartArea = "ChartArea1";
            chartArea2.AxisX.Interval = 150D;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea2";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 30F;
            chartArea2.Position.Width = 80.05473F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 70F;
            this.Chart.ChartAreas.Add(chartArea1);
            this.Chart.ChartAreas.Add(chartArea2);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            this.Chart.Legends.Add(legend1);
            this.Chart.Location = new System.Drawing.Point(-24, 0);
            this.Chart.Name = "Chart";
            this.Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Bid";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Ask";
            series3.ChartArea = "ChartArea2";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.Legend = "Legend1";
            series3.Name = "Volume";
            this.Chart.Series.Add(series1);
            this.Chart.Series.Add(series2);
            this.Chart.Series.Add(series3);
            this.Chart.Size = new System.Drawing.Size(805, 542);
            this.Chart.TabIndex = 3;
            this.Chart.Text = "chart1";
            this.Chart.Click += new System.EventHandler(this.Start);
            this.Chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.CloseButton.Location = new System.Drawing.Point(657, 356);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(115, 40);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Disconnect";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.Close);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.StartButton.Location = new System.Drawing.Point(657, 269);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(115, 40);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start Chart";
            this.StartButton.UseVisualStyleBackColor = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(793, 554);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SubButton);
            this.Controls.Add(this.AuthButton);
            this.Controls.Add(this.ConnButton);
            this.Controls.Add(this.Chart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag);
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConnButton;
        private System.Windows.Forms.Button AuthButton;
        private System.Windows.Forms.Button SubButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button StartButton;
    }
}

