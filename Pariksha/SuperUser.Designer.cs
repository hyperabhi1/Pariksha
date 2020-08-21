namespace Pariksha
{
    partial class SuperUser
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
            this.richTextBoxPDFString = new System.Windows.Forms.RichTextBox();
            this.dataGridViewRegexGroup = new System.Windows.Forms.DataGridView();
            this.dataGridViewAbsolutePatter = new System.Windows.Forms.DataGridView();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxRegexPattern = new System.Windows.Forms.TextBox();
            this.textBoxAbsolutePattern = new System.Windows.Forms.TextBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegexGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAbsolutePatter)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxPDFString
            // 
            this.richTextBoxPDFString.Location = new System.Drawing.Point(12, 39);
            this.richTextBoxPDFString.Name = "richTextBoxPDFString";
            this.richTextBoxPDFString.ReadOnly = true;
            this.richTextBoxPDFString.Size = new System.Drawing.Size(275, 399);
            this.richTextBoxPDFString.TabIndex = 0;
            this.richTextBoxPDFString.Text = "";
            // 
            // dataGridViewRegexGroup
            // 
            this.dataGridViewRegexGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegexGroup.Location = new System.Drawing.Point(299, 39);
            this.dataGridViewRegexGroup.Name = "dataGridViewRegexGroup";
            this.dataGridViewRegexGroup.Size = new System.Drawing.Size(170, 399);
            this.dataGridViewRegexGroup.TabIndex = 2;
            // 
            // dataGridViewAbsolutePatter
            // 
            this.dataGridViewAbsolutePatter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAbsolutePatter.Location = new System.Drawing.Point(480, 39);
            this.dataGridViewAbsolutePatter.Name = "dataGridViewAbsolutePatter";
            this.dataGridViewAbsolutePatter.Size = new System.Drawing.Size(308, 399);
            this.dataGridViewAbsolutePatter.TabIndex = 3;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(12, 10);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxRegexPattern
            // 
            this.textBoxRegexPattern.Location = new System.Drawing.Point(299, 13);
            this.textBoxRegexPattern.Name = "textBoxRegexPattern";
            this.textBoxRegexPattern.Size = new System.Drawing.Size(170, 20);
            this.textBoxRegexPattern.TabIndex = 5;
            this.textBoxRegexPattern.Text = "Regex Pattern";
            this.textBoxRegexPattern.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxAbsolutePattern
            // 
            this.textBoxAbsolutePattern.Location = new System.Drawing.Point(480, 13);
            this.textBoxAbsolutePattern.Name = "textBoxAbsolutePattern";
            this.textBoxAbsolutePattern.Size = new System.Drawing.Size(170, 20);
            this.textBoxAbsolutePattern.TabIndex = 6;
            this.textBoxAbsolutePattern.Text = "Absolute Pattern";
            this.textBoxAbsolutePattern.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(228, 13);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(59, 23);
            this.buttonRefresh.TabIndex = 7;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(713, 10);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "SaveRegex";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // SuperUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.textBoxAbsolutePattern);
            this.Controls.Add(this.textBoxRegexPattern);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.dataGridViewAbsolutePatter);
            this.Controls.Add(this.dataGridViewRegexGroup);
            this.Controls.Add(this.richTextBoxPDFString);
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "SuperUser";
            this.Text = "SuperUser";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegexGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAbsolutePatter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxPDFString;
        private System.Windows.Forms.DataGridView dataGridViewRegexGroup;
        private System.Windows.Forms.DataGridView dataGridViewAbsolutePatter;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textBoxRegexPattern;
        private System.Windows.Forms.TextBox textBoxAbsolutePattern;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonSave;
    }
}