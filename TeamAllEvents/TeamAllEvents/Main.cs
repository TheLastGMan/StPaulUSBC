using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamAllEvents
{
    public partial class Main : Form
    {

        private bool[] _InputsValid = new bool[3];

        public Main()
        {
            InitializeComponent();
            GenerateReport_button.Enabled = false;
        }

        /// <summary>
        /// Pick the file used to read and show it in the given textbox
        /// </summary>
        /// <param name="tb">TextBox</param>
        private void Choose_InputFile(TextBox tb, int index)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                tb.Text = openFileDialog1.FileName;
            else
                tb.Text = string.Empty;

            _InputsValid[index] = (tb.Text.Length > 0);
            CheckForGeneration();
        }

        private void Bowler_Browse_Click(object sender, EventArgs e)
        {
            Choose_InputFile(textBox_Bowlers, 0);
        }

        private void Divison1_Browse_Click(object sender, EventArgs e)
        {
            Choose_InputFile(textBox_Divison1, 1);
        }

        private void OutputButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                outputFile_TextBox.Text = saveFileDialog1.FileName;
            else
                outputFile_TextBox.Text = string.Empty;

            _InputsValid[2] = (outputFile_TextBox.Text.Length > 0);
            CheckForGeneration();
        }

        private void GenerateReport_Button_Click(object sender, EventArgs e)
        {
            var parser = new Parser();
            var report = new Report();
            try
            {
                var bowlers = parser.LoadBowlers(textBox_Bowlers.Text);
                var divison = parser.LoadDivisions(textBox_Divison1.Text, bowlers);

                var standings = report.GenerateStandings(bowlers, divison);
                var reportCSV = report.CSVReport(standings, (int)teamSize_numericUpDown.Value);

                File.WriteAllLines(outputFile_TextBox.Text, reportCSV.ToArray());
                Result_textBox.Text = "Completed: " + outputFile_TextBox.Text;
            }
            catch (Exception ex)
            {
                Result_textBox.Text = ex.Message;
            }
        }

        private void CheckForGeneration()
        {
            GenerateReport_button.Enabled = _InputsValid.All(f => f == true);
        }
    }
}
