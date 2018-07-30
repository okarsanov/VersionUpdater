using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;

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

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            var settingsFolder = "settings";
            var settingsFile = "settings.ini";

            if (!Directory.Exists(settingsFolder))
                Directory.CreateDirectory(settingsFolder);
            if (!File.Exists(Path.Combine(settingsFolder, settingsFile)))
                File.Create(Path.Combine(settingsFolder, settingsFile));

            var json = File.ReadAllText(Path.Combine(settingsFolder, settingsFile));
            //var projects = JsonConvert.DeserializeObject<Projects>(json);
            //var projects = new Projects();

            var test = new {
                Name = "TestName1",
                Path = "C:\\Projects\\CommonAssemblyInfo.cs"
            };

            var alltext = File.ReadAllText(test.Path);
            var regex = new Regex(@"\[assembly: AssemblyVersion\(\""\d+.\d+.\d+.\d+\""\)\]");
            var match = regex.Match(alltext);
            var regex2 = new Regex(@"\d+.\d+.\d+.\d+");
            var match2 = regex2.Match(match.Value);

            var list = new List<Project>();
            list.Add(new Project
            {
                Name = test.Name,
                Path = test.Path,
                Current = match2.Value
            });
            list.Add(new Project
            {
                Name = "TestName2",
                Path = "C:\\Projects",
                Current = "2.0.0.2"
            });
            list.Add(new Project
            {
                Name = "TestName3",
                Path = "C:\\Projects",
                Current = "2.0.0.3455"
            });
            list.Add(new Project
            {
                Name = "TestName4",
                Path = "C:\\Projects",
                Current = "2.0.0.0"
            });
            list.Add(new Project
            {
                Name = "TestName5",
                Path = "C:\\Projects",
                Current = "2.0.2.1"
            });
            gridView.DataSource = list;
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
                MessageBox.Show(@"Version must иу consists fron 4 parts", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(@"Version must иу consists fron 4 parts", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newVersion = $"{textBoxSeniorNumber.Text}.{textBoxJuniorNumber.Text}.{textBoxLayoutNumber.Text}.{textBoxRevisionNumber.Text}";

            try
            {
                ReplaceText(_currentProject.Path, $"[assembly: AssemblyVersion(\"{_currentProject.Current}\")]", $"[assembly: AssemblyVersion(\"{newVersion}\")]");
                MessageBox.Show(@"Successful", @"Done!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gridView.Rows[_currentIndex].Cells[2].Value = newVersion;
            }
            catch (Exception exception)
            {
                MessageBox.Show($@"ERROR! {exception.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ReplaceText(string fileName, string sourceText, string targetTExt)
        {
            var position = (int)GetTextPosition(fileName, sourceText);
            if (position < 0)
            {
                throw new AggregateException($"SourceText NOT FOUND in file {fileName}!");;
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                if(fs.Length > int.MaxValue)
                    throw new AggregateException($"Size of file {fileName} is more then integer type size!");

                var rewritingBytesLength = (int)fs.Length - position - sourceText.Length;

                byte[] rewritingBytes = new byte[rewritingBytesLength];

                fs.Seek(position + sourceText.Length, SeekOrigin.Begin);
                fs.Read(rewritingBytes, 0, rewritingBytesLength);
    
                var chTarget = targetTExt.ToCharArray();
                var chTargetBytes = new byte[chTarget.Length];
                for (int i = 0; i < chTarget.Length; i++)
                {
                    chTargetBytes[i] = (byte)chTarget[i];
                }

                fs.Seek(position, SeekOrigin.Begin);
                fs.Write(chTargetBytes, 0, chTargetBytes.Length);
                fs.Write(rewritingBytes, 0, rewritingBytesLength);
            }
        }

        private static long GetTextPosition(string fileName, string text)
        {
            const int DEFAULT_VALUE = -1;

            var chSource = text.ToCharArray();
            char[] chResult = new char[chSource.Length];

            long changeStartPosition = DEFAULT_VALUE;

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                int index = 0;//индекс массива символов

                while (fs.Position != fs.Length)
                {
                    var b = (char)fs.ReadByte();
                    chResult[index] = b;
                    if (b == chSource[index])
                    {
                        if (index == 0)
                        {
                            changeStartPosition = fs.Position - 1;//минус 1, т.к. ReadByte переводит позицию вперёд
                        }

                        index++;//если считываемые символы совпадают с исходными, счётчик будет непрерывно увеличиваться
                    }
                    else if(index != 0)
                    {
                        //при первом несовпадении, счётчик сбрасывается
                        index = 0;
                        changeStartPosition = DEFAULT_VALUE;
                    }

                    if (index == chSource.Length)
                        break;//все символы текста найдены
                }

                //если цикл пройдёт до конца файла, но не все символы текста найдены
                if (index != chSource.Length)
                    changeStartPosition = DEFAULT_VALUE;
            }

            return changeStartPosition;
        }
    }
}
