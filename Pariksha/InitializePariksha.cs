using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pariksha
{
    public partial class Pariksha
    {
        private const string ActiveFilePath = "ActiveFilePath";
        private const string ActiveFileDirectory = "ActiveFileDirectory";
        private const string MachineNames = "MachineNames";
        private const string NextPatternNumber = "NextPatternNumber";
        private const string Filter = "pdf files (*.pdf)|*.pdf";
        private const string DefaultExt = "pdf";
        private const string Dots = "...............";
        private const string PatternKey = "PatternKey";
        private const string PatternValue = "PatternValue";
        private const string IsDoingPractice = "IsDoingPractice";
        private const string CorrectMarks = "CorrectMarks";
        private const string InCorrectMarks = "InCorrectMarks";
        private const string Recipients = "Recipients";
        private const string SenderId = "SenderId";
        private const string SenderPassword = "SenderPassword";
        private const string ExludedFolders = "ExludedFolders";
        private const string SavedAnswers = "SavedAnswers";

        private static string _activeFilePath = "";
        private static string _activeFileDirectory = "";
        private static string _machineNames = "";
        private static int _nextPatternNumber = 0;
        private static bool _isDoingPractice = false;
        private static double _correctMarks = 1;
        private static double _inCorrectMarks = 0.33;
        private static bool _isValidPdf = false;
        private static bool _isSubmitted = false;
        private static bool _isSessionStarted = false;
        private static DataTable _metaDataTable = new DataTable();
        private static bool _isUpdatingCellValue = false;
        private static string _answerSheetFilePath = string.Empty;
        private static string _questionPaperSheetFilePath = string.Empty;
        private static DateTime _startTime;
        private static DateTime _endTime;
        private static string[] _recipients;
        private static string _senderId = "";
        private static string _senderPassword = "";
        private static string[] _submittedAnswers = new string[100];
        private static string _tempKeyLogsFilePath = string.Empty;
        private static bool _isSizeToggled = false;
        private static List<string> _exludedFolders = new List<string>();
        private static string [] _savedAnswers = new string[100];

        private static readonly List<KeyValuePair<string, string>> ParsedResult = new List<KeyValuePair<string, string>>();
        private static List<KeyValuePair<int, KeyValuePair<string, string>>> _patterns = new List<KeyValuePair<int, KeyValuePair<string, string>>>();
        private static List<string> PossibleOptions = new List<string>() { "A", "B", "C", "D" };
        private static int[] AnswerList = new int[100];
        public void InitializePariksha()
        {
            LoadPatterns();
            _machineNames = ConfigurationManager.AppSettings[MachineNames];
            _activeFileDirectory = ConfigurationManager.AppSettings[ActiveFileDirectory];
            _activeFilePath = ConfigurationManager.AppSettings[ActiveFilePath];
            _nextPatternNumber = int.Parse(ConfigurationManager.AppSettings[NextPatternNumber]);
            _isDoingPractice = bool.Parse(ConfigurationManager.AppSettings[IsDoingPractice]);
            _correctMarks = double.Parse(ConfigurationManager.AppSettings[CorrectMarks]);
            _inCorrectMarks = double.Parse(ConfigurationManager.AppSettings[InCorrectMarks]);
            _recipients = ConfigurationManager.AppSettings[Recipients].Split('|');
            _senderId = ConfigurationManager.AppSettings[SenderId];
            _senderPassword = ConfigurationManager.AppSettings[SenderPassword];
            _exludedFolders = ConfigurationManager.AppSettings[ExludedFolders].Split('|').ToList();
            _savedAnswers = ConfigurationManager.AppSettings[SavedAnswers].Split('|');
            var isMachineRecordExists = _machineNames.Split('|').Contains(Environment.MachineName);
            if (!isMachineRecordExists)
            {
                UpdateAppSettingKey(ActiveFilePath, "");
                UpdateAppSettingKey(ActiveFileDirectory, "");
                var machineNames = _machineNames.Split('|').ToList();
                machineNames.Add(Environment.MachineName);
                UpdateAppSettingKey(MachineNames, string.Join("|", machineNames));
                UpdateAppSettingKey(IsDoingPractice, "false");
                UpdateAppSettingKey(ExludedFolders, "");
            }

            if (_isDoingPractice)
                checkBoxDoingPractice.Enabled = true;
        }
        private void UpdateAppSettingKey(string key, string value)
        {
            Configuration configuration =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");

            _machineNames = ConfigurationManager.AppSettings[MachineNames];
            _activeFileDirectory = ConfigurationManager.AppSettings[ActiveFileDirectory];
            _activeFilePath = ConfigurationManager.AppSettings[ActiveFilePath];
            _nextPatternNumber = int.Parse(ConfigurationManager.AppSettings[NextPatternNumber]);
        }
        private void AddAppSettingKey(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Add(key, value);
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");

            _machineNames = ConfigurationManager.AppSettings[MachineNames];
            _activeFileDirectory = ConfigurationManager.AppSettings[ActiveFileDirectory];
            _activeFilePath = ConfigurationManager.AppSettings[ActiveFilePath];
            _nextPatternNumber = int.Parse(ConfigurationManager.AppSettings[NextPatternNumber]);
        }

        private void UpdatePatternToAppSetting(string patternRegex, string patternAbsolute)
        {
            AddAppSettingKey($"{PatternKey}_{_nextPatternNumber:D3}", patternRegex);
            AddAppSettingKey($"{PatternValue}_{_nextPatternNumber:D3}", patternAbsolute);
            _nextPatternNumber++;
            UpdateAppSettingKey(NextPatternNumber, _nextPatternNumber.ToString());
            LoadPatterns();
        }

        private void LoadPatterns()
        {
            for (int i = 20; i < 1000; i++)
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[$"{PatternKey}_{i:D3}"]))
                    _patterns.Add(new KeyValuePair<int, KeyValuePair<string, string>>(
                        i,
                        new KeyValuePair<string, string>(
                            ConfigurationManager.AppSettings[$"{PatternKey}_{i:D3}"],
                            ConfigurationManager.AppSettings[$"{PatternValue}_{i:D3}"])));
                else
                    break;
            }
        }

        private void buttonFilePicker_Click(object sender, EventArgs e)
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
                _activeFilePath = fileDialog.FileName;
                _answerSheetFilePath = _activeFilePath;
                //buttonReloadAnswers.Visible = false;
                textBoxFilePath_TextChanged(null, null);
            }

        }

        private bool IsValidAnswerSheet(KeyValuePair<string, string> pattern, string input, RegexOptions regexOptions = RegexOptions.IgnoreCase)
        {
            bool isValid = false;
            try
            {
                ParsedResult.Clear();
                var answerDescription = input.Split(new string[] { pattern.Value }, StringSplitOptions.None);
                var matchedCollection = Regex.Matches(input, pattern.Key, RegexOptions.IgnoreCase);
                for (int i = 0; i < matchedCollection.Count; i++)
                {
                    string key = matchedCollection[i].Groups[1].Value;
                    string value = answerDescription[i + 1];
                    ParsedResult.Add(new KeyValuePair<string, string>(key, value));
                }

                if (ParsedResult.Count == 100)
                {
                    isValid = true;
                }
            }
            catch (Exception e)
            {
                isValid = false;
            }

            return isValid;
        }
        private void UpdateDataGridViews(int row, int gridViewNumber)
        {
            if (-1 < row && row < 25)
            {
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
            }
        }
        private void UpdateDataGridViewAnswerSheet1(int row, int index)
        {
            if (_isSubmitted || (_isDoingPractice && checkBoxDoingPractice.Checked))
                richTextBoxDescription.Text = ParsedResult[index].Value;
            var value = (this.dataGridViewAnswerSheet1[1, row].Value = this.dataGridViewAnswerSheet1[1, row].Value.ToString().ToUpper()).ToString();
            if (PossibleOptions.Contains(value))
            {
                _submittedAnswers[index] = value;
                labelKeyStrokeValidator.ForeColor = Color.LimeGreen;
                var key = int.Parse((this.dataGridViewAnswerSheet1[0, row].Value = index + 1).ToString());
                bool isCorrect = _metaDataTable.Select($"QNo = '{index+1}' AND Ans = '{value}'").Any();
                if (isCorrect)
                    AnswerList[index] = 1;
                else
                    AnswerList[index] = -1;

                if (_isSubmitted || (_isDoingPractice && checkBoxDoingPractice.Checked))
                {
                    richTextBoxDescription.Text = ParsedResult[index].Value;
                    if (isCorrect)
                    {
                        this.dataGridViewAnswerSheet1[0, row].Style.BackColor = Color.LimeGreen;
                    }
                    else
                    {
                        this.dataGridViewAnswerSheet1[0, row].Style.BackColor = Color.LightSalmon;
                    }
                }
            }
            else
            {
                _submittedAnswers[index] = string.Empty;
                this.dataGridViewAnswerSheet1[1, row].Value = string.Empty;
                labelKeyStrokeValidator.ForeColor = Color.LightSalmon;
            }
            if (string.IsNullOrEmpty(value))
                labelKeyStrokeValidator.ForeColor = Color.WhiteSmoke;
        }
        private void UpdateDataGridViewAnswerSheet2(int row, int index)
        {
            var value = (this.dataGridViewAnswerSheet2[1, row].Value = this.dataGridViewAnswerSheet2[1, row].Value.ToString().ToUpper()).ToString();
            if (_isSubmitted || (_isDoingPractice && checkBoxDoingPractice.Checked))
                richTextBoxDescription.Text = ParsedResult[index].Value;
            if (PossibleOptions.Contains(value))
            {
                _submittedAnswers[index] = value;
                labelKeyStrokeValidator.ForeColor = Color.LimeGreen;
                var key = int.Parse((this.dataGridViewAnswerSheet2[0, row].Value = index + 1).ToString());
                bool isCorrect = _metaDataTable.Select($"QNo = '{index+1}' AND Ans = '{value}'").Any();
                if (isCorrect)
                    AnswerList[index] = 1;
                else
                    AnswerList[index] = -1;

                if (_isSubmitted || (_isDoingPractice && checkBoxDoingPractice.Checked))
                {
                    richTextBoxDescription.Text = ParsedResult[index].Value;
                    if (isCorrect)
                    {
                        this.dataGridViewAnswerSheet2[0, row].Style.BackColor = Color.LimeGreen;
                    }
                    else
                    {
                        this.dataGridViewAnswerSheet2[0, row].Style.BackColor = Color.LightSalmon;
                    }
                }
            }
            else
            {
                _submittedAnswers[index] = string.Empty;
                this.dataGridViewAnswerSheet2[1, row].Value = string.Empty;
                labelKeyStrokeValidator.ForeColor = Color.LightSalmon;
            }
            if (string.IsNullOrEmpty(value))
                labelKeyStrokeValidator.ForeColor = Color.WhiteSmoke;
        }
        private void UpdateDataGridViewAnswerSheet3(int row, int index)
        {
            var value = (this.dataGridViewAnswerSheet3[1, row].Value = this.dataGridViewAnswerSheet3[1, row].Value.ToString().ToUpper()).ToString();
            if (_isSubmitted || (_isDoingPractice && checkBoxDoingPractice.Checked))
                richTextBoxDescription.Text = ParsedResult[index].Value;
            if (PossibleOptions.Contains(value))
            {
                _submittedAnswers[index] = value;
                labelKeyStrokeValidator.ForeColor = Color.LimeGreen;
                var key = int.Parse((this.dataGridViewAnswerSheet3[0, row].Value = index + 1).ToString());
                bool isCorrect = _metaDataTable.Select($"QNo = '{index+1}' AND Ans = '{value}'").Any();
                if (isCorrect)
                    AnswerList[index] = 1;
                else
                    AnswerList[index] = -1;

                if (_isSubmitted || (_isDoingPractice && checkBoxDoingPractice.Checked))
                {
                    richTextBoxDescription.Text = ParsedResult[index].Value;
                    if (isCorrect)
                    {
                        this.dataGridViewAnswerSheet3[0, row].Style.BackColor = Color.LimeGreen;
                    }
                    else
                    {
                        this.dataGridViewAnswerSheet3[0, row].Style.BackColor = Color.LightSalmon;
                    }
                }
            }
            else
            {
                _submittedAnswers[index] = string.Empty;
                this.dataGridViewAnswerSheet3[1, row].Value = string.Empty;
                labelKeyStrokeValidator.ForeColor = Color.LightSalmon;
            }
            if (string.IsNullOrEmpty(value))
                labelKeyStrokeValidator.ForeColor = Color.WhiteSmoke;
        }
        private void UpdateDataGridViewAnswerSheet4(int row, int index)
        {
            var value = (this.dataGridViewAnswerSheet4[1, row].Value = this.dataGridViewAnswerSheet4[1, row].Value.ToString().ToUpper()).ToString();
            if (_isSubmitted || (_isDoingPractice && checkBoxDoingPractice.Checked))
                richTextBoxDescription.Text = ParsedResult[index].Value;
            if (PossibleOptions.Contains(value))
            {
                _submittedAnswers[index] = value;
                labelKeyStrokeValidator.ForeColor = Color.LimeGreen;
                var key = int.Parse((this.dataGridViewAnswerSheet4[0, row].Value = index + 1).ToString());
                bool isCorrect = _metaDataTable.Select($"QNo = '{index+1}' AND Ans = '{value}'").Any();
                if (isCorrect)
                    AnswerList[index] = 1;
                else
                    AnswerList[index] = -1;

                if (_isSubmitted || (_isDoingPractice && checkBoxDoingPractice.Checked))
                {
                    richTextBoxDescription.Text = ParsedResult[index].Value;
                    if (isCorrect)
                    {
                        this.dataGridViewAnswerSheet4[0, row].Style.BackColor = Color.LimeGreen;
                    }
                    else
                    {
                        this.dataGridViewAnswerSheet4[0, row].Style.BackColor = Color.LightSalmon;
                    }
                }
            }
            else
            {
                _submittedAnswers[index] = string.Empty;
                this.dataGridViewAnswerSheet4[1, row].Value = string.Empty;
                labelKeyStrokeValidator.ForeColor = Color.LightSalmon;
            }
            if (string.IsNullOrEmpty(value))
                labelKeyStrokeValidator.ForeColor = Color.WhiteSmoke;
        }
        private async Task SendPendingMails()
        {
            try
            {
                var isAnyReportLeftPending = Directory.GetDirectories("SubmissionReport");
                if (isAnyReportLeftPending.Any())
                {
                    foreach (var folder in Directory.GetDirectories("SubmissionReport"))
                    {
                        if (!_exludedFolders.Contains(folder.Split('\\')[1]))
                            try
                            {
                                var date = DateTime.ParseExact(folder.Split('\\')[1], "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                                var files = Directory.GetFiles(folder);

                                //creating the object of MailMessage
                                MailMessage mailMessage = new MailMessage();
                                mailMessage.From = new MailAddress(_senderId); //From Email Id
                                mailMessage.Subject = "(Old) Neelu Pariksha Report held at " + date.ToString("yyyy-MMM-dd hh:mm:ss tt") + " DeviceName - " + Environment.MachineName + " User " + Environment.UserName; //Subject of Email
                                mailMessage.IsBodyHtml = true;

                                foreach (var file in files)
                                {
                                    var fileInfo = new FileInfo(file);

                                    if (string.Equals(fileInfo.Extension, ".html", StringComparison.OrdinalIgnoreCase))
                                        mailMessage.Body = File.ReadAllText(fileInfo.FullName); //body or message of Email
                                    else
                                        mailMessage.Attachments.Add(new Attachment(fileInfo.FullName));
                                }
                                //Adding Multiple recipient email id logic
                                string[] Multi = _recipients; //spiliting input Email id string with comma(,)
                                foreach (string Multiemailid in Multi)
                                {
                                    mailMessage.To.Add(new MailAddress(Multiemailid)); //adding multi reciver's Email Id
                                }
                                SmtpClient smtp = new SmtpClient(); // creating object of smptpclient
                                smtp.Host = "smtp.gmail.com"; //host of emailaddress for example smtp.gmail.com etc
                                                              //network and security related credentials
                                smtp.EnableSsl = true;
                                NetworkCredential NetworkCred = new NetworkCredential();
                                NetworkCred.UserName = mailMessage.From.Address;
                                NetworkCred.Password = _senderPassword;
                                smtp.UseDefaultCredentials = true;
                                smtp.Credentials = NetworkCred;
                                smtp.Port = 587;
                                smtp.Send(mailMessage);
                                smtp.Timeout = 5000;//sending Email
                                Directory.Delete(folder, true);
                            }
                            catch (SmtpException e)
                            {
                            }
                            catch (IOException e)
                            {
                                _exludedFolders.Add(folder.Split('\\')[1]);
                                UpdateAppSettingKey(ExludedFolders, string.Join("|", _exludedFolders));
                            }
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
        private async Task SendReport(Models body)
        {
            try
            {
                //creating the object of MailMessage
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_senderId); //From Email Id
                mailMessage.Subject = "Neelu Pariksha Report held at " + _startTime.ToString("yyyy-MMM-dd hh:mm:ss tt") + " DeviceName - " + Environment.MachineName + " User " + Environment.UserName; //Subject of Email
                mailMessage.Body = Common.ConvertModelsToHtml(body); //body or message of Email
                mailMessage.IsBodyHtml = true;
                //Adding Multiple recipient email id logic
                string[] Multi = _recipients; //spiliting input Email id string with comma(,)
                foreach (string Multiemailid in Multi)
                {
                    mailMessage.To.Add(new MailAddress(Multiemailid)); //adding multi reciver's Email Id
                }
                mailMessage.Attachments.Add(new Attachment(_questionPaperSheetFilePath));
                mailMessage.Attachments.Add(new Attachment(_answerSheetFilePath));
                SmtpClient smtp = new SmtpClient(); // creating object of smptpclient
                smtp.Host = "smtp.gmail.com"; //host of emailaddress for example smtp.gmail.com etc

                //network and security related credentials
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = mailMessage.From.Address;
                NetworkCred.Password = _senderPassword;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage); //sending Email
            }
            catch (Exception e)
            {
                if (Directory.Exists($"SubmissionReport\\{_startTime.ToString("yyyyMMddHHmmss")}"))
                {
                    if (Directory.Exists($"SubmissionReport\\{_startTime.ToString("yyyyMMddHHmmss")}"))
                    {
                        System.IO.File.WriteAllText($"SubmissionReport\\{_startTime.ToString("yyyyMMddHHmmss")}\\SubmitResult.json", Newtonsoft.Json.JsonConvert.SerializeObject(GetExamProfile(), Newtonsoft.Json.Formatting.Indented));
                        File.Copy(_answerSheetFilePath, $"SubmissionReport\\{_startTime.ToString("yyyyMMddHHmmss")}\\A_{body.AnswerPaperDetails.FileName}");
                        File.Copy(_questionPaperSheetFilePath, $"SubmissionReport\\{_startTime.ToString("yyyyMMddHHmmss")}\\Q_{body.QuestionPaperDetails.FileName}");
                        File.WriteAllText($"SubmissionReport\\{_startTime.ToString("yyyyMMddHHmmss")}\\Report.html", Common.ConvertModelsToHtml(body));
                    }
                }
                else
                {
                    Directory.CreateDirectory($"SubmissionReport\\{_startTime.ToString("yyyyMMddHHmmss")}");
                    System.IO.File.WriteAllText($"SubmissionReport\\{_startTime.ToString("yyyyMMddHHmmss")}\\SubmitResult.json", Newtonsoft.Json.JsonConvert.SerializeObject(GetExamProfile(), Newtonsoft.Json.Formatting.Indented));
                    File.Copy(_answerSheetFilePath, $"SubmissionReport\\{_startTime.ToString("yyyyMMddHHmmss")}\\A_{body.AnswerPaperDetails.FileName}");
                    File.Copy(_questionPaperSheetFilePath, $"SubmissionReport\\{_startTime.ToString("yyyyMMddHHmmss")}\\Q_{body.QuestionPaperDetails.FileName}");
                    File.WriteAllText($"SubmissionReport\\{_startTime.ToString("yyyyMMddHHmmss")}\\Report.html", Common.ConvertModelsToHtml(body));
                }
            }
        }


    }
}
