using System;
using System.Drawing;
using System.Windows.Forms;
using AnimalRecognizeML.Model;

namespace AnimalRecognize
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private string FilePath;
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Input File ";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FilePath = dlg.FileName;
                txtInput.Text = FilePath;
                pbInput.Image = Image.FromFile(FilePath);
                btnRecognize.Enabled = true;
            }
            else
            {
                MessageBox.Show("Try Again !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecognize_Click(object sender, EventArgs e)
        {
            var input = new ModelInput();
            input.ImageSource = FilePath;
            ModelOutput result = ConsumeModel.Predict(input);
            txtResult.Text = result.Prediction;
            foreach (var i in result.Score)
            {
                txtScore.Text += i.ToString() + " , ";
            }
        }
    }
}
