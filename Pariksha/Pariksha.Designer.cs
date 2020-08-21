namespace Pariksha
{
    partial class Pariksha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pariksha));
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.buttonFilePicker = new System.Windows.Forms.Button();
            this.dataGridViewAnswerSheet1 = new System.Windows.Forms.DataGridView();
            this.labelMessage = new System.Windows.Forms.Label();
            this.dataGridViewAnswerSheet2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewAnswerSheet3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewAnswerSheet4 = new System.Windows.Forms.DataGridView();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.checkBoxDoingPractice = new System.Windows.Forms.CheckBox();
            this.buttonCalculateScore = new System.Windows.Forms.Button();
            this.labelMarksObtained = new System.Windows.Forms.Label();
            this.labelOutOff = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStartTest = new System.Windows.Forms.Button();
            this.numericUpDownTotalTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonQuestionPaper = new System.Windows.Forms.Button();
            this.textBoxQuestionPaperFilePath = new System.Windows.Forms.TextBox();
            this.labelCorrectAnswers = new System.Windows.Forms.Label();
            this.labelInCorrectAnswers = new System.Windows.Forms.Label();
            this.labelBlankAnswers = new System.Windows.Forms.Label();
            this.labelKeyStrokeValidator = new System.Windows.Forms.Label();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.linkLabelSuperUser = new System.Windows.Forms.LinkLabel();
            this.pictureBoxResize = new System.Windows.Forms.PictureBox();
            this.pictureBoxCircle = new System.Windows.Forms.PictureBox();
            this.labelTimer = new System.Windows.Forms.Label();
            this.buttonReloadAnswers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnswerSheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnswerSheet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnswerSheet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnswerSheet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCircle)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFilePath.Location = new System.Drawing.Point(85, 11);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(204, 20);
            this.textBoxFilePath.TabIndex = 0;
            this.textBoxFilePath.Text = "Please select a file";
            this.textBoxFilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxFilePath.TextChanged += new System.EventHandler(this.textBoxFilePath_TextChanged);
            // 
            // buttonFilePicker
            // 
            this.buttonFilePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonFilePicker.Location = new System.Drawing.Point(12, 10);
            this.buttonFilePicker.Name = "buttonFilePicker";
            this.buttonFilePicker.Size = new System.Drawing.Size(70, 22);
            this.buttonFilePicker.TabIndex = 2;
            this.buttonFilePicker.Text = "Browse File";
            this.buttonFilePicker.UseVisualStyleBackColor = true;
            this.buttonFilePicker.Click += new System.EventHandler(this.buttonFilePicker_Click);
            // 
            // dataGridViewAnswerSheet1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAnswerSheet1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAnswerSheet1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnswerSheet1.EnableHeadersVisualStyles = false;
            this.dataGridViewAnswerSheet1.Location = new System.Drawing.Point(12, 38);
            this.dataGridViewAnswerSheet1.MultiSelect = false;
            this.dataGridViewAnswerSheet1.Name = "dataGridViewAnswerSheet1";
            this.dataGridViewAnswerSheet1.RowHeadersVisible = false;
            this.dataGridViewAnswerSheet1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewAnswerSheet1.RowTemplate.Height = 15;
            this.dataGridViewAnswerSheet1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAnswerSheet1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewAnswerSheet1.Size = new System.Drawing.Size(100, 395);
            this.dataGridViewAnswerSheet1.TabIndex = 3;
            this.dataGridViewAnswerSheet1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAnswerSheet_CellClick);
            this.dataGridViewAnswerSheet1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAnswerSheet_CellClick);
            this.dataGridViewAnswerSheet1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewAnswerSheet_KeyMoveMement);
            this.dataGridViewAnswerSheet1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewAnswerSheet_KeyMoveMement);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(295, 15);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(12, 13);
            this.labelMessage.TabIndex = 4;
            this.labelMessage.Text = "*";
            // 
            // dataGridViewAnswerSheet2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAnswerSheet2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAnswerSheet2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnswerSheet2.EnableHeadersVisualStyles = false;
            this.dataGridViewAnswerSheet2.Location = new System.Drawing.Point(118, 38);
            this.dataGridViewAnswerSheet2.MultiSelect = false;
            this.dataGridViewAnswerSheet2.Name = "dataGridViewAnswerSheet2";
            this.dataGridViewAnswerSheet2.RowHeadersVisible = false;
            this.dataGridViewAnswerSheet2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewAnswerSheet2.RowTemplate.Height = 15;
            this.dataGridViewAnswerSheet2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAnswerSheet2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewAnswerSheet2.Size = new System.Drawing.Size(100, 395);
            this.dataGridViewAnswerSheet2.TabIndex = 4;
            this.dataGridViewAnswerSheet2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAnswerSheet_CellClick);
            this.dataGridViewAnswerSheet2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAnswerSheet_CellClick);
            this.dataGridViewAnswerSheet2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewAnswerSheet_KeyMoveMement);
            this.dataGridViewAnswerSheet2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewAnswerSheet_KeyMoveMement);
            // 
            // dataGridViewAnswerSheet3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAnswerSheet3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAnswerSheet3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnswerSheet3.EnableHeadersVisualStyles = false;
            this.dataGridViewAnswerSheet3.Location = new System.Drawing.Point(224, 38);
            this.dataGridViewAnswerSheet3.MultiSelect = false;
            this.dataGridViewAnswerSheet3.Name = "dataGridViewAnswerSheet3";
            this.dataGridViewAnswerSheet3.RowHeadersVisible = false;
            this.dataGridViewAnswerSheet3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewAnswerSheet3.RowTemplate.Height = 15;
            this.dataGridViewAnswerSheet3.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAnswerSheet3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewAnswerSheet3.Size = new System.Drawing.Size(100, 395);
            this.dataGridViewAnswerSheet3.TabIndex = 5;
            this.dataGridViewAnswerSheet3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAnswerSheet_CellClick);
            this.dataGridViewAnswerSheet3.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAnswerSheet_CellClick);
            this.dataGridViewAnswerSheet3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewAnswerSheet_KeyMoveMement);
            this.dataGridViewAnswerSheet3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewAnswerSheet_KeyMoveMement);
            // 
            // dataGridViewAnswerSheet4
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAnswerSheet4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewAnswerSheet4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnswerSheet4.EnableHeadersVisualStyles = false;
            this.dataGridViewAnswerSheet4.Location = new System.Drawing.Point(330, 38);
            this.dataGridViewAnswerSheet4.MultiSelect = false;
            this.dataGridViewAnswerSheet4.Name = "dataGridViewAnswerSheet4";
            this.dataGridViewAnswerSheet4.RowHeadersVisible = false;
            this.dataGridViewAnswerSheet4.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewAnswerSheet4.RowTemplate.Height = 15;
            this.dataGridViewAnswerSheet4.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAnswerSheet4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewAnswerSheet4.Size = new System.Drawing.Size(100, 395);
            this.dataGridViewAnswerSheet4.TabIndex = 8;
            this.dataGridViewAnswerSheet4.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAnswerSheet_CellClick);
            this.dataGridViewAnswerSheet4.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAnswerSheet_CellClick);
            this.dataGridViewAnswerSheet4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewAnswerSheet_KeyMoveMement);
            this.dataGridViewAnswerSheet4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewAnswerSheet_KeyMoveMement);
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.richTextBoxDescription.Location = new System.Drawing.Point(12, 511);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ReadOnly = true;
            this.richTextBoxDescription.Size = new System.Drawing.Size(418, 175);
            this.richTextBoxDescription.TabIndex = 8;
            this.richTextBoxDescription.Text = "";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.labelDescription.Location = new System.Drawing.Point(9, 488);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(69, 15);
            this.labelDescription.TabIndex = 9;
            this.labelDescription.Text = "Description";
            // 
            // checkBoxDoingPractice
            // 
            this.checkBoxDoingPractice.AutoSize = true;
            this.checkBoxDoingPractice.Enabled = false;
            this.checkBoxDoingPractice.Location = new System.Drawing.Point(22, 445);
            this.checkBoxDoingPractice.Name = "checkBoxDoingPractice";
            this.checkBoxDoingPractice.Size = new System.Drawing.Size(117, 17);
            this.checkBoxDoingPractice.TabIndex = 10;
            this.checkBoxDoingPractice.Text = "I am doing Practice";
            this.checkBoxDoingPractice.UseVisualStyleBackColor = true;
            // 
            // buttonCalculateScore
            // 
            this.buttonCalculateScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.buttonCalculateScore.Location = new System.Drawing.Point(223, 455);
            this.buttonCalculateScore.Name = "buttonCalculateScore";
            this.buttonCalculateScore.Size = new System.Drawing.Size(66, 23);
            this.buttonCalculateScore.TabIndex = 12;
            this.buttonCalculateScore.Text = "Submit";
            this.buttonCalculateScore.UseVisualStyleBackColor = true;
            this.buttonCalculateScore.Click += new System.EventHandler(this.buttonCalculateScore_Click);
            // 
            // labelMarksObtained
            // 
            this.labelMarksObtained.AutoSize = true;
            this.labelMarksObtained.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.labelMarksObtained.Location = new System.Drawing.Point(356, 452);
            this.labelMarksObtained.Name = "labelMarksObtained";
            this.labelMarksObtained.Size = new System.Drawing.Size(44, 16);
            this.labelMarksObtained.TabIndex = 13;
            this.labelMarksObtained.Text = "00.00";
            this.labelMarksObtained.Visible = false;
            // 
            // labelOutOff
            // 
            this.labelOutOff.AutoSize = true;
            this.labelOutOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.labelOutOff.Location = new System.Drawing.Point(361, 480);
            this.labelOutOff.Name = "labelOutOff";
            this.labelOutOff.Size = new System.Drawing.Size(32, 16);
            this.labelOutOff.TabIndex = 14;
            this.labelOutOff.Text = "200";
            this.labelOutOff.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.label1.Location = new System.Drawing.Point(352, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "-----------";
            this.label1.Visible = false;
            // 
            // buttonStartTest
            // 
            this.buttonStartTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonStartTest.Location = new System.Drawing.Point(386, 9);
            this.buttonStartTest.Name = "buttonStartTest";
            this.buttonStartTest.Size = new System.Drawing.Size(44, 22);
            this.buttonStartTest.TabIndex = 16;
            this.buttonStartTest.Text = "Start";
            this.buttonStartTest.UseVisualStyleBackColor = true;
            this.buttonStartTest.Click += new System.EventHandler(this.buttonStartTest_Click);
            // 
            // numericUpDownTotalTime
            // 
            this.numericUpDownTotalTime.Location = new System.Drawing.Point(333, 10);
            this.numericUpDownTotalTime.Name = "numericUpDownTotalTime";
            this.numericUpDownTotalTime.Size = new System.Drawing.Size(38, 20);
            this.numericUpDownTotalTime.TabIndex = 17;
            this.numericUpDownTotalTime.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(369, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "m";
            // 
            // buttonQuestionPaper
            // 
            this.buttonQuestionPaper.Location = new System.Drawing.Point(1226, 10);
            this.buttonQuestionPaper.Name = "buttonQuestionPaper";
            this.buttonQuestionPaper.Size = new System.Drawing.Size(132, 23);
            this.buttonQuestionPaper.TabIndex = 20;
            this.buttonQuestionPaper.Text = "Open Questions Paper";
            this.buttonQuestionPaper.UseVisualStyleBackColor = true;
            this.buttonQuestionPaper.Click += new System.EventHandler(this.buttonQuestionPaper_Click);
            // 
            // textBoxQuestionPaperFilePath
            // 
            this.textBoxQuestionPaperFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuestionPaperFilePath.Location = new System.Drawing.Point(962, 12);
            this.textBoxQuestionPaperFilePath.Name = "textBoxQuestionPaperFilePath";
            this.textBoxQuestionPaperFilePath.Size = new System.Drawing.Size(247, 20);
            this.textBoxQuestionPaperFilePath.TabIndex = 0;
            this.textBoxQuestionPaperFilePath.Text = "Please select a file";
            this.textBoxQuestionPaperFilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCorrectAnswers
            // 
            this.labelCorrectAnswers.AutoSize = true;
            this.labelCorrectAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.labelCorrectAnswers.Location = new System.Drawing.Point(295, 444);
            this.labelCorrectAnswers.Name = "labelCorrectAnswers";
            this.labelCorrectAnswers.Size = new System.Drawing.Size(0, 16);
            this.labelCorrectAnswers.TabIndex = 4;
            // 
            // labelInCorrectAnswers
            // 
            this.labelInCorrectAnswers.AutoSize = true;
            this.labelInCorrectAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.labelInCorrectAnswers.Location = new System.Drawing.Point(295, 485);
            this.labelInCorrectAnswers.Name = "labelInCorrectAnswers";
            this.labelInCorrectAnswers.Size = new System.Drawing.Size(0, 16);
            this.labelInCorrectAnswers.TabIndex = 4;
            // 
            // labelBlankAnswers
            // 
            this.labelBlankAnswers.AutoSize = true;
            this.labelBlankAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.labelBlankAnswers.Location = new System.Drawing.Point(295, 465);
            this.labelBlankAnswers.Name = "labelBlankAnswers";
            this.labelBlankAnswers.Size = new System.Drawing.Size(0, 16);
            this.labelBlankAnswers.TabIndex = 4;
            // 
            // labelKeyStrokeValidator
            // 
            this.labelKeyStrokeValidator.AutoSize = true;
            this.labelKeyStrokeValidator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.labelKeyStrokeValidator.ForeColor = System.Drawing.SystemColors.Control;
            this.labelKeyStrokeValidator.Location = new System.Drawing.Point(416, 433);
            this.labelKeyStrokeValidator.Name = "labelKeyStrokeValidator";
            this.labelKeyStrokeValidator.Size = new System.Drawing.Size(20, 16);
            this.labelKeyStrokeValidator.TabIndex = 21;
            this.labelKeyStrokeValidator.Text = "⚫";
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(436, 38);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(922, 648);
            this.axAcroPDF1.TabIndex = 19;
            // 
            // linkLabelSuperUser
            // 
            this.linkLabelSuperUser.AutoSize = true;
            this.linkLabelSuperUser.Location = new System.Drawing.Point(145, 446);
            this.linkLabelSuperUser.Name = "linkLabelSuperUser";
            this.linkLabelSuperUser.Size = new System.Drawing.Size(57, 13);
            this.linkLabelSuperUser.TabIndex = 22;
            this.linkLabelSuperUser.TabStop = true;
            this.linkLabelSuperUser.Text = "SuperUser";
            this.linkLabelSuperUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSuperUser_LinkClicked);
            // 
            // pictureBoxResize
            // 
            this.pictureBoxResize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxResize.Image = global::Pariksha.Properties.Resources.Resize;
            this.pictureBoxResize.Location = new System.Drawing.Point(409, 488);
            this.pictureBoxResize.Name = "pictureBoxResize";
            this.pictureBoxResize.Size = new System.Drawing.Size(22, 20);
            this.pictureBoxResize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxResize.TabIndex = 23;
            this.pictureBoxResize.TabStop = false;
            this.pictureBoxResize.Click += new System.EventHandler(this.pictureBoxResize_Click);
            // 
            // pictureBoxCircle
            // 
            this.pictureBoxCircle.Image = global::Pariksha.Properties.Resources.circle;
            this.pictureBoxCircle.Location = new System.Drawing.Point(339, 434);
            this.pictureBoxCircle.Name = "pictureBoxCircle";
            this.pictureBoxCircle.Size = new System.Drawing.Size(77, 74);
            this.pictureBoxCircle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCircle.TabIndex = 11;
            this.pictureBoxCircle.TabStop = false;
            this.pictureBoxCircle.Visible = false;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Consolas", 15.25F, System.Drawing.FontStyle.Bold);
            this.labelTimer.ForeColor = System.Drawing.Color.Red;
            this.labelTimer.Location = new System.Drawing.Point(436, 7);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(0, 24);
            this.labelTimer.TabIndex = 24;
            // 
            // buttonReloadAnswers
            // 
            this.buttonReloadAnswers.Location = new System.Drawing.Point(85, 482);
            this.buttonReloadAnswers.Name = "buttonReloadAnswers";
            this.buttonReloadAnswers.Size = new System.Drawing.Size(100, 23);
            this.buttonReloadAnswers.TabIndex = 25;
            this.buttonReloadAnswers.Text = "Reload Answers";
            this.buttonReloadAnswers.UseVisualStyleBackColor = true;
            this.buttonReloadAnswers.Visible = false;
            this.buttonReloadAnswers.Click += new System.EventHandler(this.buttonReloadAnswers_Click);
            // 
            // Pariksha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1370, 696);
            this.Controls.Add(this.buttonReloadAnswers);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.pictureBoxResize);
            this.Controls.Add(this.linkLabelSuperUser);
            this.Controls.Add(this.labelKeyStrokeValidator);
            this.Controls.Add(this.labelMarksObtained);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonQuestionPaper);
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.numericUpDownTotalTime);
            this.Controls.Add(this.buttonStartTest);
            this.Controls.Add(this.labelOutOff);
            this.Controls.Add(this.buttonCalculateScore);
            this.Controls.Add(this.pictureBoxCircle);
            this.Controls.Add(this.checkBoxDoingPractice);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.dataGridViewAnswerSheet4);
            this.Controls.Add(this.dataGridViewAnswerSheet3);
            this.Controls.Add(this.dataGridViewAnswerSheet2);
            this.Controls.Add(this.labelBlankAnswers);
            this.Controls.Add(this.labelInCorrectAnswers);
            this.Controls.Add(this.labelCorrectAnswers);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.dataGridViewAnswerSheet1);
            this.Controls.Add(this.buttonFilePicker);
            this.Controls.Add(this.textBoxQuestionPaperFilePath);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1364, 726);
            this.Name = "Pariksha";
            this.Text = "Pariksha";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnswerSheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnswerSheet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnswerSheet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnswerSheet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCircle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button buttonFilePicker;
        private System.Windows.Forms.DataGridView dataGridViewAnswerSheet1;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.DataGridView dataGridViewAnswerSheet2;
        private System.Windows.Forms.DataGridView dataGridViewAnswerSheet3;
        private System.Windows.Forms.DataGridView dataGridViewAnswerSheet4;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.CheckBox checkBoxDoingPractice;
        private System.Windows.Forms.PictureBox pictureBoxCircle;
        private System.Windows.Forms.Button buttonCalculateScore;
        private System.Windows.Forms.Label labelMarksObtained;
        private System.Windows.Forms.Label labelOutOff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStartTest;
        private System.Windows.Forms.NumericUpDown numericUpDownTotalTime;
        private System.Windows.Forms.Label label2;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.Button buttonQuestionPaper;
        private System.Windows.Forms.TextBox textBoxQuestionPaperFilePath;
        private System.Windows.Forms.Label labelCorrectAnswers;
        private System.Windows.Forms.Label labelInCorrectAnswers;
        private System.Windows.Forms.Label labelBlankAnswers;
        private System.Windows.Forms.Label labelKeyStrokeValidator;
        private System.Windows.Forms.LinkLabel linkLabelSuperUser;
        private System.Windows.Forms.PictureBox pictureBoxResize;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Button buttonReloadAnswers;
    }
}