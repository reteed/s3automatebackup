using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s3automatebackup.Forms
{
    public partial class PrivateKeyForm : Form
    {
        public string PrivateKey { get; private set; }
        ResourceManager resourceManager = new ResourceManager("s3automatebackup.Forms.PrivateKeyForm", typeof(PrivateKeyForm).Assembly);

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
                MessageBox.Show(resourceManager.GetString("EnterValidPrivateKey"), resourceManager.GetString("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
