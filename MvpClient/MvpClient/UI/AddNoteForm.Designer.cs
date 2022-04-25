namespace MvpClient.UI
{
    partial class AddNoteForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNoteName = new System.Windows.Forms.TextBox();
            this.buttonCencel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заметка:";
            // 
            // textBoxNoteName
            // 
            this.textBoxNoteName.Location = new System.Drawing.Point(73, 19);
            this.textBoxNoteName.Name = "textBoxNoteName";
            this.textBoxNoteName.Size = new System.Drawing.Size(264, 20);
            this.textBoxNoteName.TabIndex = 1;
            // 
            // buttonCencel
            // 
            this.buttonCencel.Location = new System.Drawing.Point(12, 61);
            this.buttonCencel.Name = "buttonCencel";
            this.buttonCencel.Size = new System.Drawing.Size(128, 23);
            this.buttonCencel.TabIndex = 2;
            this.buttonCencel.Text = "Отмена";
            this.buttonCencel.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(161, 61);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(176, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Добавить заметку";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // AddNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 96);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonCencel);
            this.Controls.Add(this.textBoxNoteName);
            this.Controls.Add(this.label1);
            this.Name = "AddNoteForm";
            this.Text = "Новая заметка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNoteName;
        private System.Windows.Forms.Button buttonCencel;
        private System.Windows.Forms.Button buttonAdd;
    }
}