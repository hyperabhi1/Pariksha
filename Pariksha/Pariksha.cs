using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Pariksha
{
    public partial class Pariksha : Form
    {
        Timer timerCountDown = null;
        private int counter = 60;
        public Pariksha()
        {
            InitializeComponent();
            InitializePariksha();
            SendPendingMails().Wait();
        }
        private void textBoxFilePath_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_activeFilePath))
            {
                UpdateAppSettingKey(ActiveFilePath, _activeFilePath);
                UpdateAppSettingKey(ActiveFileDirectory, (new FileInfo(_activeFilePath)).DirectoryName);
                textBoxFilePath.Text = _activeFilePath;
                var parsedTxt = Common.ConvertPdf2Txt(_activeFilePath);
                if (!parsedTxt.Item1)
                {
                    _isValidPdf = false;
                    labelMessage.BackColor = Color.LightSalmon;
                    labelMessage.Text = "✘";
                    return;
                }

                bool isValidAnswerSheet = false;
                foreach (var pattern in _patterns.Select(x => x.Value))
                {
                    var temp = IsValidAnswerSheet(pattern, parsedTxt.Item2, RegexOptions.None);
                    if (temp)
                    {
                        isValidAnswerSheet = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (isValidAnswerSheet)
                {
                    _isValidPdf = true;
                    labelMessage.BackColor = Color.Lime;
                    labelMessage.Text = "✔️";
                }
                else
                {
                    _isValidPdf = false;
                    labelMessage.BackColor = Color.LightSalmon;
                    labelMessage.Text = "✘";
                }

                pictureBoxCircle.Visible = false;
                labelOutOff.Visible = false;
                labelMarksObtained.Visible = false;
                label1.Visible = false;

                UpdateDataGrid();


            }
        }

        private void UpdateDataGrid()
        {
            var tables = Common.ConvertKeyValuePairToDataTable(ParsedResult);

            dataGridViewAnswerSheet1.DataSource = tables.Item2[0];
            dataGridViewAnswerSheet1.Columns[0].Width = 50;
            dataGridViewAnswerSheet1.Columns[0].ReadOnly = true;
            dataGridViewAnswerSheet1.Columns[1].Width = 50;
            dataGridViewAnswerSheet1.Rows[25].Frozen = true;

            dataGridViewAnswerSheet2.DataSource = tables.Item2[1];
            dataGridViewAnswerSheet2.Columns[0].Width = 50;
            dataGridViewAnswerSheet2.Columns[0].ReadOnly = true;
            dataGridViewAnswerSheet2.Columns[1].Width = 50;
            dataGridViewAnswerSheet2.Rows[25].Frozen = true;

            dataGridViewAnswerSheet3.DataSource = tables.Item2[2];
            dataGridViewAnswerSheet3.Columns[0].Width = 50;
            dataGridViewAnswerSheet3.Columns[0].ReadOnly = true;
            dataGridViewAnswerSheet3.Columns[1].Width = 50;
            dataGridViewAnswerSheet3.Rows[25].Frozen = true;

            dataGridViewAnswerSheet4.DataSource = tables.Item2[3];
            dataGridViewAnswerSheet4.Columns[0].Width = 50;
            dataGridViewAnswerSheet4.Columns[0].ReadOnly = true;
            dataGridViewAnswerSheet4.Columns[1].Width = 50;
            dataGridViewAnswerSheet4.Rows[25].Frozen = true;

            foreach (DataGridViewColumn column in dataGridViewAnswerSheet1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in dataGridViewAnswerSheet2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in dataGridViewAnswerSheet3.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in dataGridViewAnswerSheet4.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            _metaDataTable = tables.Item1;
        }

        private void ToggleUpdateDataGridView(object sender, int row)
        {
            if ( -1 < row && row < 25)
            {
                _isUpdatingCellValue = true;
                var gridViewNumber = int.Parse(((((DataGridView)sender).Name)[(((DataGridView)sender).Name).Length - 1]).ToString());
                switch (gridViewNumber)
                {
                    case 1:
                        UpdateDataGridViewAnswerSheet1(row, row);
                        break;
                    case 2:
                        UpdateDataGridViewAnswerSheet2(row, row + 25);
                        break;
                    case 3:
                        UpdateDataGridViewAnswerSheet3(row, row + 50);
                        break;
                    case 4:
                        UpdateDataGridViewAnswerSheet4(row, row + 75);
                        break;
                    default:
                        break;
                }
                UpdateAppSettingKey(SavedAnswers,string.Join("|", _submittedAnswers));
                _isUpdatingCellValue = false;
            }
        }

        private async void buttonCalculateScore_Click(object sender, EventArgs e)
        {
            if (!_isSessionStarted)
            {
                MessageBox.Show("Exam not started yet", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_isSessionStarted && !timerCountDown.Enabled)
            {
                MessageBox.Show("Can't submit you've runned out of time", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (AnswerList.ToList().Where(x => x == 1).Any() || AnswerList.ToList().Where(x => x == -1).Any())
            {
                _endTime = DateTime.UtcNow;
                _isSessionStarted = false;
                timerCountDown.Stop();
                double marksObtained = (AnswerList.ToList().Count(x => x == 1) * _correctMarks) - (AnswerList.ToList().Count(x => x == -1) * _inCorrectMarks);

                labelMarksObtained.Text = String.Format("{0:00.00}", marksObtained);
                pictureBoxCircle.Visible = true;
                labelOutOff.Visible = true;
                labelMarksObtained.Visible = true;
                label1.Visible = true;
                _isSubmitted = true;

                labelCorrectAnswers.BackColor = Color.Lime;
                labelCorrectAnswers.Text = "✔️ " + AnswerList.Count(x=>x == 1).ToString("D2");

                labelBlankAnswers.BackColor = Color.LightYellow;
                labelBlankAnswers.Text = "⚫ " + AnswerList.Count(x => x == 0).ToString("D2");

                labelInCorrectAnswers.BackColor = Color.LightSalmon;
                labelInCorrectAnswers.Text = "✘  " + AnswerList.Count(x => x == -1).ToString("D2");

                for (int i = 0; i < 25; i++)
                {
                    if (AnswerList[i] == -1)
                        dataGridViewAnswerSheet1.Rows[i].Cells[0].Style.BackColor = Color.LightSalmon;
                    else if (AnswerList[i] == 1)
                        dataGridViewAnswerSheet1.Rows[i].Cells[0].Style.BackColor = Color.LimeGreen;
                    else
                        dataGridViewAnswerSheet1.Rows[i].Cells[0].Style.BackColor = Color.LightSlateGray;
                }
                for (int i = 0; i < 25; i++)
                {
                    if (AnswerList[25 + i] == -1)
                        dataGridViewAnswerSheet2.Rows[i].Cells[0].Style.BackColor = Color.LightSalmon;
                    else if (AnswerList[25 + i] == 1)
                        dataGridViewAnswerSheet2.Rows[i].Cells[0].Style.BackColor = Color.LimeGreen;
                    else
                        dataGridViewAnswerSheet2.Rows[i].Cells[0].Style.BackColor = Color.LightSlateGray;
                }
                for (int i = 0; i < 25; i++)
                {
                    if (AnswerList[50 + i] == -1)
                        dataGridViewAnswerSheet3.Rows[i].Cells[0].Style.BackColor = Color.LightSalmon;
                    else if (AnswerList[50 + i] == 1)
                        dataGridViewAnswerSheet3.Rows[i].Cells[0].Style.BackColor = Color.LimeGreen;
                    else
                        dataGridViewAnswerSheet3.Rows[i].Cells[0].Style.BackColor = Color.LightSlateGray;
                }
                for (int i = 0; i < 25; i++)
                {
                    if (AnswerList[75 + i] == -1)
                        dataGridViewAnswerSheet4.Rows[i].Cells[0].Style.BackColor = Color.LightSalmon;
                    else if (AnswerList[75 + i] == 1)
                        dataGridViewAnswerSheet4.Rows[i].Cells[0].Style.BackColor = Color.LimeGreen;
                    else
                        dataGridViewAnswerSheet4.Rows[i].Cells[0].Style.BackColor = Color.LightSlateGray;
                }
                linkLabelSuperUser.Enabled = true;
                await SendReport(GetExamProfile());
                buttonQuestionPaper.Enabled = true;
            }
            else
                MessageBox.Show("Please select one or more answers", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private Models GetExamProfile()
        {
            var result = new Models();
            result.AnswerSheet = AnswerList;
            var anserSheetDetails = new FileInfo(_answerSheetFilePath);
            result.AnswerPaperDetails = new FileDetails()
            {
                FileName = anserSheetDetails.Name,
                FilePath = anserSheetDetails.FullName,
                FileSize = anserSheetDetails.Length.ToString().PutCommaBetweenNDigits(3) + " Bytes"
            };
            var questionPaperDetails = new FileInfo(_questionPaperSheetFilePath);
            result.QuestionPaperDetails = new FileDetails()
            {
                FileName = questionPaperDetails.Name,
                FilePath = questionPaperDetails.FullName,
                FileSize = questionPaperDetails.Length.ToString().PutCommaBetweenNDigits(3) + " Bytes"
            };
            result.Score = new Score()
            {
                Correct = AnswerList.ToList().Count(x => x == 1),
                InCorrect = AnswerList.ToList().Count(x => x == -1),
                MarksObtained = (AnswerList.ToList().Count(x => x == 1) * _correctMarks) - (AnswerList.ToList().Count(x => x == -1) * _inCorrectMarks),
                OutOff = 200,
                Skipped = AnswerList.ToList().Count(x => x == 0),
                TimeTaken = (_endTime - _startTime).ToString()
            };
            result.submittedAnswers = _submittedAnswers;
            return result;
        }
        private async void buttonStartTest_Click(object sender, EventArgs e)
        {
            UpdateAppSettingKey(SavedAnswers, "");
            linkLabelSuperUser.Enabled = false;
            if (!string.IsNullOrEmpty(_answerSheetFilePath) && !string.IsNullOrEmpty(_questionPaperSheetFilePath) && _isValidPdf && !_isSubmitted)
            {
                buttonStartTest.Enabled = false;
                _tempKeyLogsFilePath = DateTime.Now.ToString("yyyyMMddHHmmss") + "_KeyStrokes.txt";
                buttonFilePicker.Enabled = false;
                buttonQuestionPaper.Enabled = false;
                _startTime = DateTime.Now;
                UpdateDataGrid();
                AnswerList = new int[100];

                counter = (int)numericUpDownTotalTime.Value * 60;
                timerCountDown = new System.Windows.Forms.Timer();
                timerCountDown.Tick += new EventHandler(timerCountDown_Tick);
                timerCountDown.Interval = 1000;
                timerCountDown.Start();
                this.Text = "Time Remaining " + counter.ToString("HH:mm:ss");

                _isSessionStarted = true;
            }
            else
                MessageBox.Show(_isSubmitted ? "Please restart the application to take test.........." : "Invalid Pdf..........",
                    "!!!Warning Message!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void timerCountDown_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                timerCountDown.Stop();
                MessageBox.Show("Times Up.................", "Application Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            var result = TimeSpan.FromSeconds(counter);
            var h = (int)result.TotalHours;
            var m = result.Minutes;
            var s = result.Seconds;
            this.Text = "Time Remaining " + $"{h.ToString("D2")}:{m.ToString("D2")}:{s.ToString("D2")}";
            labelTimer.Text = "Time Remaining " + $"{h.ToString("D2")}:{m.ToString("D2")}:{s.ToString("D2")}";
        }

        private void buttonQuestionPaper_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                InitialDirectory = _activeFileDirectory,

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = DefaultExt,
                Filter = Filter,
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _questionPaperSheetFilePath = fileDialog.FileName;
                bool IsPdfAvailable = axAcroPDF1.LoadFile(fileDialog.FileName);

                if (IsPdfAvailable == true)
                {
                    axAcroPDF1.LoadFile(fileDialog.FileName);
                    axAcroPDF1.setShowToolbar(true);
                    axAcroPDF1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Selected PDF Template Is Locked By Another Application.", "Application Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                textBoxQuestionPaperFilePath.Text = fileDialog.FileName;
            }
        }

        private void dataGridViewAnswerSheet_KeyMoveMement(object sender, KeyEventArgs e)
        {
            ToggleUpdateDataGridView(sender, ((DataGridView)sender).SelectedCells[0].RowIndex);
        }

        private void dataGridViewAnswerSheet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!_isUpdatingCellValue)
            ToggleUpdateDataGridView(sender, e.RowIndex);
        }

        private void linkLabelSuperUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var superUser = new SuperUser();
            superUser.ShowDialog();
            superUser.ShowIcon = true;
            superUser.ShowInTaskbar = true;
        }

        private void pictureBoxResize_Click(object sender, EventArgs e)
        {
            if (_isSizeToggled)
            {
                //418, 175
                richTextBoxDescription.Size = new Size(418, 175);
                //922, 648
                axAcroPDF1.Size = new Size(922, 648);
                _isSizeToggled = false;
                //962, 12
                textBoxQuestionPaperFilePath.Location = new Point(962, 12);
                //1226, 10
                buttonQuestionPaper.Location = new Point(1226, 10);
            }
            else
            {
                //418, 175
                richTextBoxDescription.Size = new Size(418, 500);
                //922, 648
                axAcroPDF1.Size = new Size(1475, 973);
                _isSizeToggled = true;
                //962, 12
                textBoxQuestionPaperFilePath.Location = new Point(1520, 12);
                //1226, 10
                buttonQuestionPaper.Location = new Point(1780, 10);
            }
        }

        private void buttonReloadAnswers_Click(object sender, EventArgs e)
        {
            ConfigurationManager.RefreshSection("appSettings");
            var savedAnswers = ConfigurationManager.AppSettings[SavedAnswers].Split('|');
            if (savedAnswers.Length == 100)
            {
                for (int i = 0; i < 25; i++)
                {
                    dataGridViewAnswerSheet1.Rows[i].Cells[1].Value = savedAnswers[i];
                    dataGridViewAnswerSheet2.Rows[i].Cells[1].Value = savedAnswers[25 + i];
                    dataGridViewAnswerSheet3.Rows[i].Cells[1].Value = savedAnswers[50 + i];
                    dataGridViewAnswerSheet3.Rows[i].Cells[1].Value = savedAnswers[75 + i];
                }
            }
            else
            {
                MessageBox.Show("No saved record found", "Warning");
            }
        }
    }
}
