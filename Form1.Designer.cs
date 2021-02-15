namespace BackPropagation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_drawLines = new System.Windows.Forms.Button();
            this.btn_drawPoints = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.antrenareBtn = new System.Windows.Forms.Button();
            this.btn_Test = new System.Windows.Forms.Button();
            this.onlineRadio = new System.Windows.Forms.RadioButton();
            this.offlineRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 738);
            this.panel1.TabIndex = 0;
            // 
            // btn_drawLines
            // 
            this.btn_drawLines.Location = new System.Drawing.Point(876, 15);
            this.btn_drawLines.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_drawLines.Name = "btn_drawLines";
            this.btn_drawLines.Size = new System.Drawing.Size(108, 33);
            this.btn_drawLines.TabIndex = 1;
            this.btn_drawLines.Text = "Draw Lines";
            this.btn_drawLines.UseVisualStyleBackColor = true;
            this.btn_drawLines.Click += new System.EventHandler(this.btn_drawLines_Click);
            // 
            // btn_drawPoints
            // 
            this.btn_drawPoints.Location = new System.Drawing.Point(876, 66);
            this.btn_drawPoints.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_drawPoints.Name = "btn_drawPoints";
            this.btn_drawPoints.Size = new System.Drawing.Size(108, 33);
            this.btn_drawPoints.TabIndex = 2;
            this.btn_drawPoints.Text = "Draw Points";
            this.btn_drawPoints.UseVisualStyleBackColor = true;
            this.btn_drawPoints.Click += new System.EventHandler(this.btn_drawPoints_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.Location = new System.Drawing.Point(872, 506);
            this.errorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(51, 17);
            this.errorLabel.TabIndex = 3;
            this.errorLabel.Text = "Eroare";
            // 
            // antrenareBtn
            // 
            this.antrenareBtn.Location = new System.Drawing.Point(876, 121);
            this.antrenareBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.antrenareBtn.Name = "antrenareBtn";
            this.antrenareBtn.Size = new System.Drawing.Size(108, 33);
            this.antrenareBtn.TabIndex = 4;
            this.antrenareBtn.Text = "Antrenare";
            this.antrenareBtn.UseVisualStyleBackColor = true;
            this.antrenareBtn.Click += new System.EventHandler(this.antrenareBtn_Click);
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(876, 180);
            this.btn_Test.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(108, 33);
            this.btn_Test.TabIndex = 5;
            this.btn_Test.Text = "Testare";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // onlineRadio
            // 
            this.onlineRadio.AutoSize = true;
            this.onlineRadio.Location = new System.Drawing.Point(876, 244);
            this.onlineRadio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.onlineRadio.Name = "onlineRadio";
            this.onlineRadio.Size = new System.Drawing.Size(70, 21);
            this.onlineRadio.TabIndex = 6;
            this.onlineRadio.TabStop = true;
            this.onlineRadio.Text = "Online";
            this.onlineRadio.UseVisualStyleBackColor = true;
            // 
            // offlineRadio
            // 
            this.offlineRadio.AutoSize = true;
            this.offlineRadio.Location = new System.Drawing.Point(876, 272);
            this.offlineRadio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.offlineRadio.Name = "offlineRadio";
            this.offlineRadio.Size = new System.Drawing.Size(70, 21);
            this.offlineRadio.TabIndex = 7;
            this.offlineRadio.TabStop = true;
            this.offlineRadio.Text = "Offline";
            this.offlineRadio.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 752);
            this.Controls.Add(this.offlineRadio);
            this.Controls.Add(this.onlineRadio);
            this.Controls.Add(this.btn_Test);
            this.Controls.Add(this.antrenareBtn);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.btn_drawPoints);
            this.Controls.Add(this.btn_drawLines);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_drawLines;
        private System.Windows.Forms.Button btn_drawPoints;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button antrenareBtn;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.RadioButton onlineRadio;
        private System.Windows.Forms.RadioButton offlineRadio;
    }
}

