
namespace Plugin_Post
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
            this.label1 = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.postTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clearTextBox = new System.Windows.Forms.TextBox();
            this.postTestButton = new System.Windows.Forms.Button();
            this.clearTestButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "送信先アドレス";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(115, 12);
            this.urlTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(455, 22);
            this.urlTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "受け付けパス";
            // 
            // postTextBox
            // 
            this.postTextBox.Location = new System.Drawing.Point(115, 41);
            this.postTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.postTextBox.Name = "postTextBox";
            this.postTextBox.Size = new System.Drawing.Size(100, 22);
            this.postTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "取り消しパス";
            // 
            // clearTextBox
            // 
            this.clearTextBox.Location = new System.Drawing.Point(115, 70);
            this.clearTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.clearTextBox.Name = "clearTextBox";
            this.clearTextBox.Size = new System.Drawing.Size(100, 22);
            this.clearTextBox.TabIndex = 5;
            // 
            // postTestButton
            // 
            this.postTestButton.Location = new System.Drawing.Point(221, 41);
            this.postTestButton.Margin = new System.Windows.Forms.Padding(2);
            this.postTestButton.Name = "postTestButton";
            this.postTestButton.Size = new System.Drawing.Size(80, 24);
            this.postTestButton.TabIndex = 6;
            this.postTestButton.Text = "送信テスト";
            this.postTestButton.UseVisualStyleBackColor = true;
            this.postTestButton.Click += new System.EventHandler(this.PostTestButton_Click);
            // 
            // clearTestButton
            // 
            this.clearTestButton.Location = new System.Drawing.Point(221, 70);
            this.clearTestButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearTestButton.Name = "clearTestButton";
            this.clearTestButton.Size = new System.Drawing.Size(80, 24);
            this.clearTestButton.TabIndex = 7;
            this.clearTestButton.Text = "削除テスト";
            this.clearTestButton.UseVisualStyleBackColor = true;
            this.clearTestButton.Click += new System.EventHandler(this.ClearTestButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(306, 70);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(80, 24);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "削除実行";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(15, 190);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(555, 118);
            this.textBox4.TabIndex = 9;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(406, 315);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 24);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(491, 315);
            this.closeButton.Margin = new System.Windows.Forms.Padding(2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(80, 24);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(582, 352);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.clearTestButton);
            this.Controls.Add(this.postTestButton);
            this.Controls.Add(this.clearTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.postTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bouyomi POST 設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox postTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox clearTextBox;
        private System.Windows.Forms.Button postTestButton;
        private System.Windows.Forms.Button clearTestButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
    }
}