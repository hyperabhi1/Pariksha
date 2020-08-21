using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pariksha
{
    public partial class SuperUser : Form
    {
        private const string PatternKey = "PatternKey";
        private const string PatternValue = "PatternValue";
        private const string NextPatternNumber = "NextPatternNumber";
        private const string MachineNames = "MachineNames";

        private static int _nextPatternNumber = 0;
        private static string _machineNames = "";
        private static List<KeyValuePair<int, KeyValuePair<string, string>>> _patterns = new List<KeyValuePair<int, KeyValuePair<string, string>>>();
        public SuperUser()
        {
            InitializeComponent();
            _machineNames = ConfigurationManager.AppSettings[MachineNames];
            _nextPatternNumber = int.Parse(ConfigurationManager.AppSettings[NextPatternNumber]);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog fileDialog = new OpenFileDialog
                {
                    InitialDirectory = "C:\\",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "pdf",
                    Filter = "pdf files (*.pdf)|*.pdf",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    var parsedTxt = Common.ConvertPdf2Txt(fileDialog.FileName);
                    if (parsedTxt.Item1)
                        richTextBoxPDFString.Text = parsedTxt.Item2;
                    else
                        MessageBox.Show("Error converting pdf to readable string");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
        private Tuple<DataTable, DataTable> ParsePdfByRegex(KeyValuePair<string, string> pattern, string input, RegexOptions regexOptions = RegexOptions.IgnoreCase)
        {
            bool isValid = false;
            DataTable dataTableRegexPattern = new DataTable();
            dataTableRegexPattern.Columns.Add("#", typeof(string));
            dataTableRegexPattern.Columns.Add("Value", typeof(string));

            DataTable dataTableAbsolutePattern = new DataTable();
            dataTableAbsolutePattern.Columns.Add("#", typeof(string));
            dataTableAbsolutePattern.Columns.Add("Value", typeof(string));
            try
            {

                var answerDescription = input.Split(new string[] { pattern.Value }, StringSplitOptions.None);
                var matchedCollection = Regex.Matches(input, pattern.Key, RegexOptions.IgnoreCase);
                for (int i = 0; i < matchedCollection.Count; i++)
                {
                    string key = matchedCollection[i].Groups[1].Value;
                    string value = answerDescription[i + 1];
                    dataTableRegexPattern.Rows.Add((i + 1), key);
                    dataTableAbsolutePattern.Rows.Add((i + 1), value);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + Environment.NewLine + e.StackTrace);
            }

            return Tuple.Create(dataTableRegexPattern,dataTableAbsolutePattern);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
           var tables = ParsePdfByRegex(new KeyValuePair<string, string>(textBoxRegexPattern.Text, textBoxAbsolutePattern.Text), richTextBoxPDFString.Text, RegexOptions.None);
            dataGridViewRegexGroup.DataSource = tables.Item1;
            dataGridViewAbsolutePatter.DataSource = tables.Item2;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var tables = ParsePdfByRegex(new KeyValuePair<string, string>(textBoxRegexPattern.Text, textBoxAbsolutePattern.Text), richTextBoxPDFString.Text, RegexOptions.None);
            if(tables.Item1.Rows.Count == 100 && tables.Item2.Rows.Count == 100)
            {
                if (!_patterns.Select(x => x.Value).Select(x => x.Key + x.Value).Contains(textBoxRegexPattern.Text + textBoxAbsolutePattern.Text))
                {
                    UpdatePatternToAppSetting(textBoxRegexPattern.Text, textBoxAbsolutePattern.Text);
                    MessageBox.Show("Pattern Saved Successfully");
                }
                else
                    MessageBox.Show("This pattern already exists");
            }
            else
            {
                MessageBox.Show("The Regex doesn't parse the pdf properly");
            }
        }
        private void UpdatePatternToAppSetting(string patternRegex, string patternAbsolute)
        {
            AddAppSettingKey($"{PatternKey}_{_nextPatternNumber:D3}", patternRegex);
            AddAppSettingKey($"{PatternValue}_{_nextPatternNumber:D3}", patternAbsolute);
            _nextPatternNumber++;
            UpdateAppSettingKey(NextPatternNumber, _nextPatternNumber.ToString());
            LoadPatterns();
        }
        private void UpdateAppSettingKey(string key, string value)
        {
            Configuration configuration =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");

            _machineNames = ConfigurationManager.AppSettings[MachineNames];
            _nextPatternNumber = int.Parse(ConfigurationManager.AppSettings[NextPatternNumber]);
        }
        private void AddAppSettingKey(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Add(key, value);
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");

            _machineNames = ConfigurationManager.AppSettings[MachineNames];
            _nextPatternNumber = int.Parse(ConfigurationManager.AppSettings[NextPatternNumber]);
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
    }
}
