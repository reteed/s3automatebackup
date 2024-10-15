using s3automatebackup.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace s3automatebackup.Forms
{
    public partial class CreateConfigurationForm : Form
    {
        public Configuration Configuration { get; private set; }
        ResourceManager resourceManager = new ResourceManager("s3automatebackup.Forms.CreateConfigurationForm", typeof(CreateConfigurationForm).Assembly);

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
                smtpHostTextBox.Text = Configuration.SmtpHost;
                smtpPortTextBox.Text = Configuration.SmtpPort;
                smtpUsernameTextBox.Text = Configuration.SmtpUsername;
                smtpPasswordTextBox.Text = Configuration.SmtpPassword;
                successEmailTextBox.Text = Configuration.SuccessEmail;
                failureEmailTextBox.Text = Configuration.FailureEmail;
                enableSslCheckBox.Checked = Configuration.EnableSsl;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameTextBox.Text) && !string.IsNullOrWhiteSpace(serverTextBox.Text) && !string.IsNullOrWhiteSpace(accessKeyTextBox.Text) && !string.IsNullOrWhiteSpace(secretKeyTextBox.Text))
            {
                if (Configuration == null)
                {
                    Configuration = new Configuration();
                }

                Configuration.Name = nameTextBox.Text;
                Configuration.Server = serverTextBox.Text;
                Configuration.AccessKey = accessKeyTextBox.Text;
                Configuration.SecretKey = secretKeyTextBox.Text;
                Configuration.SmtpHost = smtpHostTextBox.Text;
                Configuration.SmtpPort = smtpPortTextBox.Text;
                Configuration.SmtpUsername = smtpUsernameTextBox.Text;
                Configuration.SmtpPassword = smtpPasswordTextBox.Text;
                Configuration.SuccessEmail = successEmailTextBox.Text;
                Configuration.FailureEmail = failureEmailTextBox.Text;
                Configuration.EnableSsl = enableSslCheckBox.Checked;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(resourceManager.GetString("RequiredFieldsMissing"), resourceManager.GetString("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void sendTestEmailButton_Click(object sender, EventArgs e)
        {
            // Validate if all fields are filled
            if (string.IsNullOrWhiteSpace(smtpHostTextBox.Text) ||
                string.IsNullOrWhiteSpace(smtpPortTextBox.Text) ||
                string.IsNullOrWhiteSpace(smtpUsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(smtpPasswordTextBox.Text) ||
                string.IsNullOrWhiteSpace(successEmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(failureEmailTextBox.Text))
            {
                MessageBox.Show(resourceManager.GetString("MissingInformation"), resourceManager.GetString("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop execution if validation fails
            }

            // Parse the SMTP port to ensure it's a valid number
            if (!int.TryParse(smtpPortTextBox.Text, out int smtpPort))
            {
                MessageBox.Show(resourceManager.GetString("InvalidPort"), resourceManager.GetString("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop execution if the port is invalid
            }

            // Assign the configuration properties
            Configuration.SmtpHost = smtpHostTextBox.Text;
            Configuration.SmtpPort = smtpPortTextBox.Text;
            Configuration.SmtpUsername = smtpUsernameTextBox.Text;
            Configuration.SmtpPassword = smtpPasswordTextBox.Text;
            Configuration.SuccessEmail = successEmailTextBox.Text;
            Configuration.FailureEmail = failureEmailTextBox.Text;
            Configuration.EnableSsl = enableSslCheckBox.Checked;

            // Proceed with testing the SMTP connection
            try
            {
                using (SmtpClient smtpClient = new SmtpClient(Configuration.SmtpHost, smtpPort))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential(Configuration.SmtpUsername, Configuration.SmtpPassword);
                    smtpClient.EnableSsl = Configuration.EnableSsl;
                    smtpClient.Timeout = 10000;

                    smtpClient.Send(new MailMessage
                    {
                        From = new MailAddress(Configuration.SmtpUsername),
                        To = { Configuration.SmtpUsername }, // Send test email to success email
                        Subject = resourceManager.GetString("SmtpTest"),
                        Body = resourceManager.GetString("SmtpTestMessage")
                    });
                    MessageBox.Show(resourceManager.GetString("SmtpSuccess") + $" Sent to {Configuration.SmtpUsername}.", resourceManager.GetString("Success"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(resourceManager.GetString("SmtpFailure") + " " + ex.Message, resourceManager.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}