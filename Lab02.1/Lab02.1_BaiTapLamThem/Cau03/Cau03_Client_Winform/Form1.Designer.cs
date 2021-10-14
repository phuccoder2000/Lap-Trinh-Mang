namespace Cau03_Client_Winform
{
    partial class Calculator
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOperatorAdd = new System.Windows.Forms.Button();
            this.btnOperatorMinus = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btnOperatorMultiply = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btnOperatorDivision = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnOperatorResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(5, 9);
            this.txtResult.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(318, 54);
            this.txtResult.TabIndex = 0;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(5, 75);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(237, 53);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOperatorAdd
            // 
            this.btnOperatorAdd.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOperatorAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperatorAdd.Location = new System.Drawing.Point(248, 75);
            this.btnOperatorAdd.Name = "btnOperatorAdd";
            this.btnOperatorAdd.Size = new System.Drawing.Size(75, 53);
            this.btnOperatorAdd.TabIndex = 4;
            this.btnOperatorAdd.Text = "+";
            this.btnOperatorAdd.UseVisualStyleBackColor = true;
            this.btnOperatorAdd.Click += new System.EventHandler(this.btnOperatorAdd_Click);
            // 
            // btnOperatorMinus
            // 
            this.btnOperatorMinus.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOperatorMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperatorMinus.Location = new System.Drawing.Point(248, 134);
            this.btnOperatorMinus.Name = "btnOperatorMinus";
            this.btnOperatorMinus.Size = new System.Drawing.Size(75, 53);
            this.btnOperatorMinus.TabIndex = 8;
            this.btnOperatorMinus.Text = "-";
            this.btnOperatorMinus.UseVisualStyleBackColor = true;
            this.btnOperatorMinus.Click += new System.EventHandler(this.btnOperatorMinus_Click);
            // 
            // btn9
            // 
            this.btn9.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.Location = new System.Drawing.Point(167, 134);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(75, 53);
            this.btn9.TabIndex = 7;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btn8
            // 
            this.btn8.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.Location = new System.Drawing.Point(86, 134);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(75, 53);
            this.btn8.TabIndex = 6;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btn7
            // 
            this.btn7.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.Location = new System.Drawing.Point(5, 134);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(75, 53);
            this.btn7.TabIndex = 5;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // btnOperatorMultiply
            // 
            this.btnOperatorMultiply.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOperatorMultiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperatorMultiply.Location = new System.Drawing.Point(248, 193);
            this.btnOperatorMultiply.Name = "btnOperatorMultiply";
            this.btnOperatorMultiply.Size = new System.Drawing.Size(75, 53);
            this.btnOperatorMultiply.TabIndex = 12;
            this.btnOperatorMultiply.Text = "x";
            this.btnOperatorMultiply.UseVisualStyleBackColor = true;
            this.btnOperatorMultiply.Click += new System.EventHandler(this.btnOperatorMultiply_Click);
            // 
            // btn6
            // 
            this.btn6.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.Location = new System.Drawing.Point(167, 193);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(75, 53);
            this.btn6.TabIndex = 11;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn5
            // 
            this.btn5.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Location = new System.Drawing.Point(86, 193);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(75, 53);
            this.btn5.TabIndex = 10;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn4
            // 
            this.btn4.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Location = new System.Drawing.Point(5, 193);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(75, 53);
            this.btn4.TabIndex = 9;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btnOperatorDivision
            // 
            this.btnOperatorDivision.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOperatorDivision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperatorDivision.Location = new System.Drawing.Point(248, 252);
            this.btnOperatorDivision.Name = "btnOperatorDivision";
            this.btnOperatorDivision.Size = new System.Drawing.Size(75, 53);
            this.btnOperatorDivision.TabIndex = 16;
            this.btnOperatorDivision.Text = "/";
            this.btnOperatorDivision.UseVisualStyleBackColor = true;
            this.btnOperatorDivision.Click += new System.EventHandler(this.btnOperatorDivision_Click);
            // 
            // btn3
            // 
            this.btn3.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.Location = new System.Drawing.Point(167, 252);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(75, 53);
            this.btn3.TabIndex = 15;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn2
            // 
            this.btn2.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.Location = new System.Drawing.Point(86, 252);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 53);
            this.btn2.TabIndex = 14;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            this.btn1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Location = new System.Drawing.Point(5, 252);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 53);
            this.btn1.TabIndex = 13;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn0
            // 
            this.btn0.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn0.Location = new System.Drawing.Point(5, 311);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(75, 53);
            this.btn0.TabIndex = 17;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // btnOperatorResult
            // 
            this.btnOperatorResult.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOperatorResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperatorResult.Location = new System.Drawing.Point(86, 311);
            this.btnOperatorResult.Name = "btnOperatorResult";
            this.btnOperatorResult.Size = new System.Drawing.Size(237, 53);
            this.btnOperatorResult.TabIndex = 18;
            this.btnOperatorResult.Text = "=";
            this.btnOperatorResult.UseVisualStyleBackColor = true;
            this.btnOperatorResult.Click += new System.EventHandler(this.btnOperatorResult_Click);
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 374);
            this.Controls.Add(this.btnOperatorResult);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnOperatorDivision);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnOperatorMultiply);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btnOperatorMinus);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btnOperatorAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtResult);
            this.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "Calculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOperatorAdd;
        private System.Windows.Forms.Button btnOperatorMinus;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btnOperatorMultiply;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btnOperatorDivision;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnOperatorResult;
    }
}

