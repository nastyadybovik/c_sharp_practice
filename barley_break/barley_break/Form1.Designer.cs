namespace barley_break
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
        private void InitializeComponent(int n)
        {
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
           
            this.Name = "Form1";
            this.Text = "Barley-break";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

            this.buttonArray = new System.Windows.Forms.Button[n*n];
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    this.buttonArray[i*n+j] = new System.Windows.Forms.Button();
                    this.Controls.Add(this.buttonArray[i * n + j]);
                    this.SuspendLayout();
                    this.buttonArray[i * n + j].Location = new System.Drawing.Point(50*j, 50*i);
                    this.buttonArray[i * n + j].Name = "button" + (i * n + j);
                    this.buttonArray[i * n + j].Size = new System.Drawing.Size(50, 50);
                    this.buttonArray[i * n + j].TabIndex = 0;
                    this.buttonArray[i * n + j].Text = "" + (i * n + j + 1);
                    this.buttonArray[i * n + j].UseVisualStyleBackColor = true;
                    this.buttonArray[i * n + j].Click += new System.EventHandler(this.button_Click);  
                }
            }
            this.buttonArray[n * n - 1].Visible = false;

            // 
            // labelWin
            // 
            this.labelWin = new System.Windows.Forms.Label();
            this.labelWin.AutoSize = true;
            this.labelWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelWin.Location = new System.Drawing.Point(10, 160);
            this.labelWin.Name = "labelWin";
            this.labelWin.Size = new System.Drawing.Size(148, 17);
            this.labelWin.TabIndex = 1;
            this.labelWin.Text = "";
            this.Controls.Add(this.labelWin);

            // 
            // buttonStart
            // 
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStart.Location = new System.Drawing.Point(10, 190);
            this.buttonStart.Name = "button1";
            this.buttonStart.Size = new System.Drawing.Size(123, 34);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            this.Controls.Add(this.buttonStart);

            //
            // soundPlayer
            //
            this.soundPlayer = new System.Media.SoundPlayer();
    
        }

        #endregion

        private System.Windows.Forms.Button[] buttonArray;
        private System.Windows.Forms.Label labelWin;
        private System.Windows.Forms.Button buttonStart;
        private System.Media.SoundPlayer soundPlayer;
    }
}

