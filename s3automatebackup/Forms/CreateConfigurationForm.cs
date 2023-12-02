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

        public CreateConfigurationForm(Configuration configuration)
        {
            InitializeComponent();
            Configuration = configuration;

            // Populate form fields with configuration data
            if (Configuration != null)
            {
                nameTextBox.Text = Configuration.Name;
                serverTextBox.Text = Configuration.Server;
                accessKeyTextBox.Text = Configuration.AccessKey;
                secretKeyTextBox.Text = Configuration.SecretKey;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(nameTextBox.Text) && !string.IsNullOrWhiteSpace(serverTextBox.Text) && !string.IsNullOrWhiteSpace(accessKeyTextBox.Text) && !string.IsNullOrWhiteSpace(secretKeyTextBox.Text))
            {
                if (Configuration == null)
                {
                    Configuration = new Configuration();
                }

                Configuration.Name = nameTextBox.Text;
                Configuration.Server = serverTextBox.Text;
                Configuration.AccessKey = accessKeyTextBox.Text;
                Configuration.SecretKey = secretKeyTextBox.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all the required fields before proceeding.", "Required Fields Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}