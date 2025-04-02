using System.Windows.Forms;
using System;
using RegistrosBancarios.Forms;

namespace RegistrosBancarios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            var createFileForm = new CreateFileForm();
            createFileForm.Show();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            var readFileForm = new ReadSequentialAccessFileForm();
            readFileForm.Show();
        }
    }
}
