namespace HiLow2SNConvert
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.textBox4 = new System.Windows.Forms.TextBox();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.radioButton3 = new System.Windows.Forms.RadioButton();
      this.textBox5 = new System.Windows.Forms.TextBox();
      this.textBox6 = new System.Windows.Forms.TextBox();
      this.radioButton4 = new System.Windows.Forms.RadioButton();
      this.textBox7 = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(88, 45);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(87, 20);
      this.textBox1.TabIndex = 1;
      this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(182, 45);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(87, 20);
      this.textBox2.TabIndex = 2;
      this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // textBox3
      // 
      this.textBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.textBox3.Location = new System.Drawing.Point(88, 12);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(87, 20);
      this.textBox3.TabIndex = 0;
      this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(181, 11);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(88, 22);
      this.button1.TabIndex = 7;
      this.button1.Text = "Рассчитать";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // textBox4
      // 
      this.textBox4.Location = new System.Drawing.Point(88, 112);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new System.Drawing.Size(87, 20);
      this.textBox4.TabIndex = 5;
      this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // radioButton1
      // 
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new System.Drawing.Point(12, 45);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(70, 17);
      this.radioButton1.TabIndex = 9;
      this.radioButton1.Text = "HI - LOW";
      this.radioButton1.UseVisualStyleBackColor = true;
      this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
      // 
      // radioButton2
      // 
      this.radioButton2.AutoSize = true;
      this.radioButton2.Checked = true;
      this.radioButton2.Location = new System.Drawing.Point(12, 14);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(63, 17);
      this.radioButton2.TabIndex = 8;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "SERIAL";
      this.radioButton2.UseVisualStyleBackColor = true;
      this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
      // 
      // radioButton3
      // 
      this.radioButton3.AutoSize = true;
      this.radioButton3.Location = new System.Drawing.Point(12, 79);
      this.radioButton3.Name = "radioButton3";
      this.radioButton3.Size = new System.Drawing.Size(47, 17);
      this.radioButton3.TabIndex = 10;
      this.radioButton3.Text = "HEX";
      this.radioButton3.UseVisualStyleBackColor = true;
      this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
      // 
      // textBox5
      // 
      this.textBox5.Location = new System.Drawing.Point(88, 79);
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new System.Drawing.Size(87, 20);
      this.textBox5.TabIndex = 3;
      this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // textBox6
      // 
      this.textBox6.Location = new System.Drawing.Point(182, 79);
      this.textBox6.Name = "textBox6";
      this.textBox6.Size = new System.Drawing.Size(87, 20);
      this.textBox6.TabIndex = 4;
      this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // radioButton4
      // 
      this.radioButton4.AutoSize = true;
      this.radioButton4.Location = new System.Drawing.Point(12, 113);
      this.radioButton4.Name = "radioButton4";
      this.radioButton4.Size = new System.Drawing.Size(54, 17);
      this.radioButton4.TabIndex = 11;
      this.radioButton4.Text = "HDLC";
      this.radioButton4.UseVisualStyleBackColor = true;
      this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
      // 
      // textBox7
      // 
      this.textBox7.Location = new System.Drawing.Point(182, 112);
      this.textBox7.Name = "textBox7";
      this.textBox7.Size = new System.Drawing.Size(86, 20);
      this.textBox7.TabIndex = 6;
      this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // Form1
      // 
      this.AcceptButton = this.button1;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(281, 148);
      this.Controls.Add(this.textBox7);
      this.Controls.Add(this.radioButton4);
      this.Controls.Add(this.textBox6);
      this.Controls.Add(this.textBox5);
      this.Controls.Add(this.radioButton3);
      this.Controls.Add(this.radioButton2);
      this.Controls.Add(this.radioButton1);
      this.Controls.Add(this.textBox4);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.textBox3);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.textBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "UniCalc";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;

    }
}

