namespace WinFormsApp7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox_begin = new ComboBox();
            btn_start = new Button();
            lbCounter = new Label();
            btnRules = new Button();
            SuspendLayout();
            // 
            // comboBox_begin
            // 
            comboBox_begin.FormattingEnabled = true;
            comboBox_begin.Items.AddRange(new object[] { "Починає гравець", "Починає комп'ютер" });
            comboBox_begin.Location = new Point(446, 64);
            comboBox_begin.Name = "comboBox_begin";
            comboBox_begin.Size = new Size(180, 33);
            comboBox_begin.TabIndex = 0;
            // 
            // btn_start
            // 
            btn_start.Location = new Point(446, 12);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(180, 45);
            btn_start.TabIndex = 1;
            btn_start.Text = "Почати гру";
            btn_start.UseVisualStyleBackColor = true;
            btn_start.Click += btn_start_Click;
            // 
            // lbCounter
            // 
            lbCounter.AutoSize = true;
            lbCounter.Font = new Font("Segoe UI Black", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            lbCounter.ForeColor = Color.White;
            lbCounter.Location = new Point(353, 32);
            lbCounter.Name = "lbCounter";
            lbCounter.Size = new Size(0, 65);
            lbCounter.TabIndex = 2;
            // 
            // btnRules
            // 
            btnRules.Location = new Point(446, 386);
            btnRules.Name = "btnRules";
            btnRules.Size = new Size(180, 52);
            btnRules.TabIndex = 3;
            btnRules.Text = "Правила гри";
            btnRules.UseVisualStyleBackColor = true;
            btnRules.Click += btnRules_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            ClientSize = new Size(638, 450);
            Controls.Add(btnRules);
            Controls.Add(lbCounter);
            Controls.Add(btn_start);
            Controls.Add(comboBox_begin);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_begin;
        private Button btn_start;
        private Label lbCounter;
        private Button btnRules;
    }
}
