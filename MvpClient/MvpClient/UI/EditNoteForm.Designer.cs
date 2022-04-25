namespace MvpClient.UI
{
    partial class EditNoteForm
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
            this.textBoxNoteName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxIsComplete = new System.Windows.Forms.CheckBox();
            this.buttonApplyChanges = new System.Windows.Forms.Button();
            this.buttonRemoveNote = new System.Windows.Forms.Button();
            this.comboBoxOrder = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxNoteName
            // 
            this.textBoxNoteName.Location = new System.Drawing.Point(95, 18);
            this.textBoxNoteName.Name = "textBoxNoteName";
            this.textBoxNoteName.Size = new System.Drawing.Size(241, 20);
            this.textBoxNoteName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Заметка:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "№ по порядку:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Выполнено:";
            // 
            // checkBoxIsComplete
            // 
            this.checkBoxIsComplete.AutoSize = true;
            this.checkBoxIsComplete.Location = new System.Drawing.Point(95, 95);
            this.checkBoxIsComplete.Name = "checkBoxIsComplete";
            this.checkBoxIsComplete.Size = new System.Drawing.Size(15, 14);
            this.checkBoxIsComplete.TabIndex = 7;
            this.checkBoxIsComplete.UseVisualStyleBackColor = true;
            // 
            // buttonApplyChanges
            // 
            this.buttonApplyChanges.Location = new System.Drawing.Point(12, 125);
            this.buttonApplyChanges.Name = "buttonApplyChanges";
            this.buttonApplyChanges.Size = new System.Drawing.Size(158, 23);
            this.buttonApplyChanges.TabIndex = 8;
            this.buttonApplyChanges.Text = "Применить изменения";
            this.buttonApplyChanges.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveNote
            // 
            this.buttonRemoveNote.Location = new System.Drawing.Point(178, 125);
            this.buttonRemoveNote.Name = "buttonRemoveNote";
            this.buttonRemoveNote.Size = new System.Drawing.Size(158, 23);
            this.buttonRemoveNote.TabIndex = 9;
            this.buttonRemoveNote.Text = "Удалить заметку";
            this.buttonRemoveNote.UseVisualStyleBackColor = true;
            // 
            // comboBoxOrder
            // 
            this.comboBoxOrder.FormattingEnabled = true;
            this.comboBoxOrder.Location = new System.Drawing.Point(95, 57);
            this.comboBoxOrder.Name = "comboBoxOrder";
            this.comboBoxOrder.Size = new System.Drawing.Size(75, 21);
            this.comboBoxOrder.TabIndex = 10;
            // 
            // EditNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 160);
            this.Controls.Add(this.comboBoxOrder);
            this.Controls.Add(this.buttonRemoveNote);
            this.Controls.Add(this.buttonApplyChanges);
            this.Controls.Add(this.checkBoxIsComplete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNoteName);
            this.Controls.Add(this.label1);
            this.Name = "EditNoteForm";
            this.Text = "Изменить заметку";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNoteName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxIsComplete;
        private System.Windows.Forms.Button buttonApplyChanges;
        private System.Windows.Forms.Button buttonRemoveNote;
        private System.Windows.Forms.ComboBox comboBoxOrder;
    }
}