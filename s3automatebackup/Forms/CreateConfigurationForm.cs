using s3automatebackup.Models;
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
    public partial class CreateConfigurationForm : Form
    {
        public Configuration Configuration { get; private set; }

        public CreateConfigurationForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Configuration = new()
            {
                Name = nameTextBox.Text,
                Server = serverTextBox.Text,
                AccessKey = accessKeyTextBox.Text,
                SecretKey = secretKeyTextBox.Text,
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}