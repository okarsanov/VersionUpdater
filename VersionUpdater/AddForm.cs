using System;
using System.IO;
using System.Windows.Forms;
using TextReplacer;

namespace VersionUpdater
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxProjectName.Text))
            {
                MessageBox.Show(@"Enter project name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPath.Text))
            {
                MessageBox.Show(@"Enter path", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!File.Exists(textBoxPath.Text))
            {
                MessageBox.Show($@"File '{textBoxPath.Text}' not found", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TextProcessor processor = new TextProcessor();

            var project = new Project
            {
                Name = textBoxProjectName.Text,
                Path = textBoxPath.Text
            };
            project.Current = processor.GetVersion(project.Path);

            var form = Application.OpenForms["MainForm"];
        }
    }
}
