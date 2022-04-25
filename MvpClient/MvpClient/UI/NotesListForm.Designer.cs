namespace MvpClient.UI
{
    partial class NotesListForm
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
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.listBoxNotes = new System.Windows.Forms.ListBox();
            this.buttonNewNote = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(453, 12);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 0;
            // 
            // listBoxNotes
            // 
            this.listBoxNotes.FormattingEnabled = true;
            this.listBoxNotes.Location = new System.Drawing.Point(12, 12);
            this.listBoxNotes.Name = "listBoxNotes";
            this.listBoxNotes.Size = new System.Drawing.Size(429, 381);
            this.listBoxNotes.TabIndex = 1;
            // 
            // buttonNewNote
            // 
            this.buttonNewNote.Location = new System.Drawing.Point(12, 411);
            this.buttonNewNote.Name = "buttonNewNote";
            this.buttonNewNote.Size = new System.Drawing.Size(143, 27);
            this.buttonNewNote.TabIndex = 2;
            this.buttonNewNote.Text = "Новая заметка";
            this.buttonNewNote.UseVisualStyleBackColor = true;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(453, 411);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(164, 27);
            this.buttonLogout.TabIndex = 3;
            this.buttonLogout.Text = "Выход";
            this.buttonLogout.UseVisualStyleBackColor = true;
            // 
            // NotesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 450);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonNewNote);
            this.Controls.Add(this.listBoxNotes);
            this.Controls.Add(this.calendar);
            this.Name = "NotesListForm";
            this.Text = "Список дел";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.ListBox listBoxNotes;
        private System.Windows.Forms.Button buttonNewNote;
        private System.Windows.Forms.Button buttonLogout;
    }
}