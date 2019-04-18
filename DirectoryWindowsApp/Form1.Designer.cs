namespace DirectoryWindowsApp
{
    partial class Form1
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
            this.button_selectDirectory = new System.Windows.Forms.Button();
            this.listBox_directoryList = new System.Windows.Forms.ListBox();
            this.listBox_listFiles = new System.Windows.Forms.ListBox();
            this.listBox_listSortedFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox_listCalcFiles = new System.Windows.Forms.ListBox();
            this.listBox_listAnswers = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_searchWords = new System.Windows.Forms.TextBox();
            this.button_searchWords = new System.Windows.Forms.Button();
            this.listBox_listSearchFiles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button_selectDirectory
            // 
            this.button_selectDirectory.Location = new System.Drawing.Point(210, 12);
            this.button_selectDirectory.Name = "button_selectDirectory";
            this.button_selectDirectory.Size = new System.Drawing.Size(289, 50);
            this.button_selectDirectory.TabIndex = 0;
            this.button_selectDirectory.Text = "SELECT DIRECTORY";
            this.button_selectDirectory.UseVisualStyleBackColor = true;
            this.button_selectDirectory.Click += new System.EventHandler(this.button_selectDirectory_Click);
            // 
            // listBox_directoryList
            // 
            this.listBox_directoryList.FormattingEnabled = true;
            this.listBox_directoryList.ItemHeight = 16;
            this.listBox_directoryList.Location = new System.Drawing.Point(728, 118);
            this.listBox_directoryList.Name = "listBox_directoryList";
            this.listBox_directoryList.Size = new System.Drawing.Size(296, 244);
            this.listBox_directoryList.TabIndex = 1;
            // 
            // listBox_listFiles
            // 
            this.listBox_listFiles.FormattingEnabled = true;
            this.listBox_listFiles.ItemHeight = 16;
            this.listBox_listFiles.Location = new System.Drawing.Point(40, 118);
            this.listBox_listFiles.Name = "listBox_listFiles";
            this.listBox_listFiles.Size = new System.Drawing.Size(279, 244);
            this.listBox_listFiles.TabIndex = 2;
            // 
            // listBox_listSortedFiles
            // 
            this.listBox_listSortedFiles.FormattingEnabled = true;
            this.listBox_listSortedFiles.ItemHeight = 16;
            this.listBox_listSortedFiles.Location = new System.Drawing.Point(399, 118);
            this.listBox_listSortedFiles.Name = "listBox_listSortedFiles";
            this.listBox_listSortedFiles.Size = new System.Drawing.Size(275, 244);
            this.listBox_listSortedFiles.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(725, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "List of directories having sorted files";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "List of sorted files in chosen directory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "List of text files in selected directory";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(324, 60);
            this.button1.TabIndex = 7;
            this.button1.Text = "SELECT DIRECTORY TO SOLVE CALC FILES";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox_listCalcFiles
            // 
            this.listBox_listCalcFiles.FormattingEnabled = true;
            this.listBox_listCalcFiles.ItemHeight = 16;
            this.listBox_listCalcFiles.Location = new System.Drawing.Point(40, 502);
            this.listBox_listCalcFiles.Name = "listBox_listCalcFiles";
            this.listBox_listCalcFiles.Size = new System.Drawing.Size(287, 212);
            this.listBox_listCalcFiles.TabIndex = 8;
            // 
            // listBox_listAnswers
            // 
            this.listBox_listAnswers.FormattingEnabled = true;
            this.listBox_listAnswers.ItemHeight = 16;
            this.listBox_listAnswers.Location = new System.Drawing.Point(399, 502);
            this.listBox_listAnswers.Name = "listBox_listAnswers";
            this.listBox_listAnswers.Size = new System.Drawing.Size(275, 212);
            this.listBox_listAnswers.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 479);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "List of calc files in the selected directory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 478);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "List of answers in answ file";
            // 
            // textBox_searchWords
            // 
            this.textBox_searchWords.Location = new System.Drawing.Point(1150, 58);
            this.textBox_searchWords.Name = "textBox_searchWords";
            this.textBox_searchWords.Size = new System.Drawing.Size(207, 22);
            this.textBox_searchWords.TabIndex = 12;
            this.textBox_searchWords.Text = "SEARCH";
            // 
            // button_searchWords
            // 
            this.button_searchWords.Location = new System.Drawing.Point(1363, 57);
            this.button_searchWords.Name = "button_searchWords";
            this.button_searchWords.Size = new System.Drawing.Size(75, 23);
            this.button_searchWords.TabIndex = 13;
            this.button_searchWords.Text = "Search";
            this.button_searchWords.UseVisualStyleBackColor = true;
            this.button_searchWords.Click += new System.EventHandler(this.button_searchWords_Click);
            // 
            // listBox_listSearchFiles
            // 
            this.listBox_listSearchFiles.FormattingEnabled = true;
            this.listBox_listSearchFiles.ItemHeight = 16;
            this.listBox_listSearchFiles.Location = new System.Drawing.Point(1150, 98);
            this.listBox_listSearchFiles.Name = "listBox_listSearchFiles";
            this.listBox_listSearchFiles.Size = new System.Drawing.Size(288, 260);
            this.listBox_listSearchFiles.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1522, 797);
            this.Controls.Add(this.listBox_listSearchFiles);
            this.Controls.Add(this.button_searchWords);
            this.Controls.Add(this.textBox_searchWords);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox_listAnswers);
            this.Controls.Add(this.listBox_listCalcFiles);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_listSortedFiles);
            this.Controls.Add(this.listBox_listFiles);
            this.Controls.Add(this.listBox_directoryList);
            this.Controls.Add(this.button_selectDirectory);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_selectDirectory;
        private System.Windows.Forms.ListBox listBox_directoryList;
        private System.Windows.Forms.ListBox listBox_listFiles;
        private System.Windows.Forms.ListBox listBox_listSortedFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox_listCalcFiles;
        private System.Windows.Forms.ListBox listBox_listAnswers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_searchWords;
        private System.Windows.Forms.Button button_searchWords;
        private System.Windows.Forms.ListBox listBox_listSearchFiles;
    }
}

