namespace TeamAllEvents
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Bowlers = new System.Windows.Forms.TextBox();
            this.Bowler_Browse = new System.Windows.Forms.Button();
            this.Divison1_Browse = new System.Windows.Forms.Button();
            this.textBox_Divison1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.outputFile_TextBox = new System.Windows.Forms.TextBox();
            this.OutputButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.GenerateReport_button = new System.Windows.Forms.Button();
            this.Result_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.teamSize_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamSize_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(624, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(34, 22);
            this.toolStripButton1.Text = "&Quit";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton2.Text = "&About";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bowlers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "Divison Standings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(424, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Header/Format: \"Name, ...\",  Entry #, Roster #, \"Event\", Squad #, Average, Score";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Header/Format: \"Team Name\", Entry, Score";
            // 
            // textBox_Bowlers
            // 
            this.textBox_Bowlers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox_Bowlers.Location = new System.Drawing.Point(34, 90);
            this.textBox_Bowlers.Name = "textBox_Bowlers";
            this.textBox_Bowlers.ReadOnly = true;
            this.textBox_Bowlers.Size = new System.Drawing.Size(479, 23);
            this.textBox_Bowlers.TabIndex = 3;
            // 
            // Bowler_Browse
            // 
            this.Bowler_Browse.Location = new System.Drawing.Point(527, 90);
            this.Bowler_Browse.Name = "Bowler_Browse";
            this.Bowler_Browse.Size = new System.Drawing.Size(75, 23);
            this.Bowler_Browse.TabIndex = 4;
            this.Bowler_Browse.Text = "Browse";
            this.Bowler_Browse.UseVisualStyleBackColor = true;
            this.Bowler_Browse.Click += new System.EventHandler(this.Bowler_Browse_Click);
            // 
            // Divison1_Browse
            // 
            this.Divison1_Browse.Location = new System.Drawing.Point(527, 189);
            this.Divison1_Browse.Name = "Divison1_Browse";
            this.Divison1_Browse.Size = new System.Drawing.Size(75, 23);
            this.Divison1_Browse.TabIndex = 4;
            this.Divison1_Browse.Text = "Browse";
            this.Divison1_Browse.UseVisualStyleBackColor = true;
            this.Divison1_Browse.Click += new System.EventHandler(this.Divison1_Browse_Click);
            // 
            // textBox_Divison1
            // 
            this.textBox_Divison1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox_Divison1.Location = new System.Drawing.Point(34, 189);
            this.textBox_Divison1.Name = "textBox_Divison1";
            this.textBox_Divison1.ReadOnly = true;
            this.textBox_Divison1.Size = new System.Drawing.Size(479, 23);
            this.textBox_Divison1.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.Filter = "CSV|*.csv";
            this.openFileDialog1.InitialDirectory = "./";
            this.openFileDialog1.ReadOnlyChecked = true;
            this.openFileDialog1.ShowReadOnly = true;
            this.openFileDialog1.Title = "Find File";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "TeamAllEventResults.csv";
            this.saveFileDialog1.Filter = "CSV|*.csv";
            this.saveFileDialog1.InitialDirectory = "./";
            this.saveFileDialog1.Title = "Report Generation Output";
            // 
            // outputFile_TextBox
            // 
            this.outputFile_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.outputFile_TextBox.Location = new System.Drawing.Point(34, 273);
            this.outputFile_TextBox.Name = "outputFile_TextBox";
            this.outputFile_TextBox.ReadOnly = true;
            this.outputFile_TextBox.Size = new System.Drawing.Size(479, 23);
            this.outputFile_TextBox.TabIndex = 3;
            // 
            // OutputButton
            // 
            this.OutputButton.Location = new System.Drawing.Point(527, 273);
            this.OutputButton.Name = "OutputButton";
            this.OutputButton.Size = new System.Drawing.Size(75, 23);
            this.OutputButton.TabIndex = 4;
            this.OutputButton.Text = "Browse";
            this.OutputButton.UseVisualStyleBackColor = true;
            this.OutputButton.Click += new System.EventHandler(this.OutputButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(12, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 45);
            this.label8.TabIndex = 1;
            this.label8.Text = "Output File";
            // 
            // GenerateReport_button
            // 
            this.GenerateReport_button.Location = new System.Drawing.Point(34, 420);
            this.GenerateReport_button.Name = "GenerateReport_button";
            this.GenerateReport_button.Size = new System.Drawing.Size(167, 23);
            this.GenerateReport_button.TabIndex = 4;
            this.GenerateReport_button.Text = "&Generate Report";
            this.GenerateReport_button.UseVisualStyleBackColor = true;
            this.GenerateReport_button.Click += new System.EventHandler(this.GenerateReport_Button_Click);
            // 
            // Result_textBox
            // 
            this.Result_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Result_textBox.Location = new System.Drawing.Point(207, 403);
            this.Result_textBox.Multiline = true;
            this.Result_textBox.Name = "Result_textBox";
            this.Result_textBox.ReadOnly = true;
            this.Result_textBox.Size = new System.Drawing.Size(395, 57);
            this.Result_textBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 45);
            this.label3.TabIndex = 1;
            this.label3.Text = "Team Size";
            // 
            // teamSize_numericUpDown
            // 
            this.teamSize_numericUpDown.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.teamSize_numericUpDown.Location = new System.Drawing.Point(34, 357);
            this.teamSize_numericUpDown.Name = "teamSize_numericUpDown";
            this.teamSize_numericUpDown.Size = new System.Drawing.Size(120, 39);
            this.teamSize_numericUpDown.TabIndex = 5;
            this.teamSize_numericUpDown.Value = 5;
            this.teamSize_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 481);
            this.Controls.Add(this.teamSize_numericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Result_textBox);
            this.Controls.Add(this.GenerateReport_button);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.OutputButton);
            this.Controls.Add(this.outputFile_TextBox);
            this.Controls.Add(this.textBox_Divison1);
            this.Controls.Add(this.Divison1_Browse);
            this.Controls.Add(this.Bowler_Browse);
            this.Controls.Add(this.textBox_Bowlers);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Main";
            this.Text = "Team All Event";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamSize_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Bowlers;
        private System.Windows.Forms.Button Bowler_Browse;
        private System.Windows.Forms.Button Divison1_Browse;
        private System.Windows.Forms.TextBox textBox_Divison1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox outputFile_TextBox;
        private System.Windows.Forms.Button OutputButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button GenerateReport_button;
        private System.Windows.Forms.TextBox Result_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown teamSize_numericUpDown;
    }
}

