using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s3automatebackup.Forms
{
    public partial class PrivateKeyForm : Form
    {
        public string PrivateKey { get; private set; }

        public PrivateKeyForm()
        {
            InitializeComponent();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(privateKeyTextBox.Text))
            {
                PrivateKey = privateKeyTextBox.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid private key.");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
