using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using TextReplacer;

namespace VersionUpdater
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private static Project _currentProject;
        private static int _currentIndex;
        private const string NotFoundText = "Not found";

        

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            var settingsFolder = PathHelper.GetSettingsFolder();
            if (!Directory.Exists(settingsFolder))
                Directory.CreateDirectory(settingsFolder);

            var settingsFile = Path.Combine(settingsFolder, "settings.ini");
            if (!File.Exists(settingsFile))
                File.Create(settingsFile);

            var json = File.ReadAllText(Path.Combine(settingsFolder, settingsFile));
            var projects = JsonConvert.DeserializeObject<List<Project>>(json);

            //get actual versions
            TextProcessor processor = new TextProcessor();
            foreach (var project in projects)
            {
                project.Current = File.Exists(project.Path) ? processor.GetVersion(project.Path) : NotFoundText;
            }

            gridView.DataSource = projects;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            _currentIndex = grid.CurrentCell.RowIndex;
            var row = grid.Rows[_currentIndex];

            _currentProject = new Project
            {
                Name = row.Cells[0].Value.ToString(),
                Path = row.Cells[1].Value.ToString(),
                Current = row.Cells[2].Value.ToString()
            };

            labelProjectName.Text = _currentProject.Name;

            var parts = _currentProject.Current.Split('.');
            if (parts.Length != 4)
            {
                MessageBox.Show(@"Version must be consists fron 4 parts", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            textBoxSeniorNumber.Text = parts[0];//старший номер
            textBoxJuniorNumber.Text = parts[1];//младший номер
            textBoxLayoutNumber.Text = parts[2];//номер компоновки
            textBoxRevisionNumber.Text = parts[3];//номер редакции
        }

        private void buttonSeniorNumber_Click(object sender, System.EventArgs e)
        {
            int SeniorNumber = Convert.ToInt32(textBoxSeniorNumber.Text);
            SeniorNumber++;
            textBoxSeniorNumber.Text = SeniorNumber.ToString();
        }

        private void buttonJuniorNumber_Click(object sender, EventArgs e)
        {
            int JuniorNumber = Convert.ToInt32(textBoxJuniorNumber.Text);
            JuniorNumber++;
            textBoxJuniorNumber.Text = JuniorNumber.ToString();
        }

        private void buttonLayoutNumber_Click(object sender, EventArgs e)
        {
            int LayoutNumber = Convert.ToInt32(textBoxLayoutNumber.Text);
            LayoutNumber++;
            textBoxLayoutNumber.Text = LayoutNumber.ToString();
        }

        private void buttonRevisionNumber_Click(object sender, EventArgs e)
        {
            int RevisionNumber = Convert.ToInt32(textBoxRevisionNumber.Text);
            RevisionNumber++;
            textBoxRevisionNumber.Text = RevisionNumber.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(!File.Exists(_currentProject.Path))
            {
                MessageBox.Show(@"Version must be consists from 4 parts", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newVersion = $"{textBoxSeniorNumber.Text}.{textBoxJuniorNumber.Text}.{textBoxLayoutNumber.Text}.{textBoxRevisionNumber.Text}";

            try
            {
                var textProcessor = new TextProcessor();
                textProcessor.ReplaceText(_currentProject.Path, $"[assembly: AssemblyVersion(\"{_currentProject.Current}\")]", $"[assembly: AssemblyVersion(\"{newVersion}\")]");
                MessageBox.Show(@"Successful", @"Done!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gridView.Rows[_currentIndex].Cells[2].Value = newVersion;
            }
            catch (Exception exception)
            {
                MessageBox.Show($@"ERROR! {exception.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog(this);
        }
    }
}
