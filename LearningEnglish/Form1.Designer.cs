
namespace LearningEnglish
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
            this.lbQuestion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.rBtnPanel = new System.Windows.Forms.Panel();
            this.rB4 = new System.Windows.Forms.RadioButton();
            this.rB3 = new System.Windows.Forms.RadioButton();
            this.rB2 = new System.Windows.Forms.RadioButton();
            this.rB1 = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.rBtnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbQuestion
            // 
            this.lbQuestion.AutoSize = true;
            this.lbQuestion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbQuestion.Location = new System.Drawing.Point(23, 19);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(65, 28);
            this.lbQuestion.TabIndex = 1;
            this.lbQuestion.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.lbQuestion);
            this.panel2.Location = new System.Drawing.Point(155, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 202);
            this.panel2.TabIndex = 2;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNext.Location = new System.Drawing.Point(815, 661);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(119, 51);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Tovább";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // rBtnPanel
            // 
            this.rBtnPanel.BackColor = System.Drawing.SystemColors.Control;
            this.rBtnPanel.Controls.Add(this.rB4);
            this.rBtnPanel.Controls.Add(this.rB3);
            this.rBtnPanel.Controls.Add(this.rB2);
            this.rBtnPanel.Controls.Add(this.rB1);
            this.rBtnPanel.Location = new System.Drawing.Point(155, 332);
            this.rBtnPanel.Name = "rBtnPanel";
            this.rBtnPanel.Size = new System.Drawing.Size(779, 274);
            this.rBtnPanel.TabIndex = 0;
            // 
            // rB4
            // 
            this.rB4.AutoSize = true;
            this.rB4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rB4.Location = new System.Drawing.Point(485, 174);
            this.rB4.Name = "rB4";
            this.rB4.Size = new System.Drawing.Size(149, 32);
            this.rB4.TabIndex = 3;
            this.rB4.TabStop = true;
            this.rB4.Text = "radioButton4";
            this.rB4.UseVisualStyleBackColor = true;
            // 
            // rB3
            // 
            this.rB3.AutoSize = true;
            this.rB3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rB3.Location = new System.Drawing.Point(485, 71);
            this.rB3.Name = "rB3";
            this.rB3.Size = new System.Drawing.Size(149, 32);
            this.rB3.TabIndex = 2;
            this.rB3.TabStop = true;
            this.rB3.Text = "radioButton3";
            this.rB3.UseVisualStyleBackColor = true;
            // 
            // rB2
            // 
            this.rB2.AutoSize = true;
            this.rB2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rB2.Location = new System.Drawing.Point(144, 174);
            this.rB2.Name = "rB2";
            this.rB2.Size = new System.Drawing.Size(149, 32);
            this.rB2.TabIndex = 1;
            this.rB2.TabStop = true;
            this.rB2.Text = "radioButton2";
            this.rB2.UseVisualStyleBackColor = true;
            // 
            // rB1
            // 
            this.rB1.AutoSize = true;
            this.rB1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rB1.Location = new System.Drawing.Point(144, 71);
            this.rB1.Name = "rB1";
            this.rB1.Size = new System.Drawing.Size(149, 32);
            this.rB1.TabIndex = 0;
            this.rB1.TabStop = true;
            this.rB1.Text = "radioButton1";
            this.rB1.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOk.Location = new System.Drawing.Point(815, 661);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(119, 51);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Kész";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1096, 776);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rBtnPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.rBtnPanel.ResumeLayout(false);
            this.rBtnPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbQuestion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel rBtnPanel;
        private System.Windows.Forms.RadioButton rB4;
        private System.Windows.Forms.RadioButton rB3;
        private System.Windows.Forms.RadioButton rB2;
        private System.Windows.Forms.RadioButton rB1;
        private System.Windows.Forms.Button btnOk;
    }
}

