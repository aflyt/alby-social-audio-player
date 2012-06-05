namespace Alby
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
            this.components = new System.ComponentModel.Container();
            this.openFile = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.positionTrackbar = new System.Windows.Forms.TrackBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerTrackbar = new System.Windows.Forms.Timer(this.components);
            this.timeDisplay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.positionTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(1, 0);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(89, 72);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Open";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.onClickOpen);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(96, 0);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(75, 37);
            this.Play.TabIndex = 1;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(189, 1);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(88, 36);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // positionTrackbar
            // 
            this.positionTrackbar.LargeChange = 1;
            this.positionTrackbar.Location = new System.Drawing.Point(96, 55);
            this.positionTrackbar.Maximum = 100;
            this.positionTrackbar.Name = "positionTrackbar";
            this.positionTrackbar.Size = new System.Drawing.Size(180, 45);
            this.positionTrackbar.TabIndex = 3;
            this.positionTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.positionTrackbar.Scroll += new System.EventHandler(this.Scroll_PositionTrackbar);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timerTrackbar
            // 
            this.timerTrackbar.Tick += new System.EventHandler(this.songTime_Tick);
            // 
            // timeDisplay
            // 
            this.timeDisplay.AutoSize = true;
            this.timeDisplay.Location = new System.Drawing.Point(229, 40);
            this.timeDisplay.Name = "timeDisplay";
            this.timeDisplay.Size = new System.Drawing.Size(43, 13);
            this.timeDisplay.TabIndex = 5;
            this.timeDisplay.Text = "0:00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 75);
            this.Controls.Add(this.timeDisplay);
            this.Controls.Add(this.positionTrackbar);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.openFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "alby - Love Music";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.positionTrackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.TrackBar positionTrackbar;
        private System.Windows.Forms.Timer timerTrackbar;
        private System.Windows.Forms.Label timeDisplay;
    }
}

