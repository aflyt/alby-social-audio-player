namespace Alby
{
    partial class mainWindow
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
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.volumeMute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.positionTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.BackColor = System.Drawing.Color.Green;
            this.openFile.FlatAppearance.BorderSize = 0;
            this.openFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFile.ForeColor = System.Drawing.Color.White;
            this.openFile.Location = new System.Drawing.Point(3, 4);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(89, 80);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Open";
            this.openFile.UseVisualStyleBackColor = false;
            this.openFile.Click += new System.EventHandler(this.Open_Click);
            // 
            // Play
            // 
            this.Play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Play.FlatAppearance.BorderSize = 0;
            this.Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play.ForeColor = System.Drawing.Color.White;
            this.Play.Location = new System.Drawing.Point(98, 4);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(88, 36);
            this.Play.TabIndex = 1;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = false;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Stop.FlatAppearance.BorderSize = 0;
            this.Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Stop.Location = new System.Drawing.Point(192, 4);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(88, 36);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = false;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // positionTrackbar
            // 
            this.positionTrackbar.Enabled = false;
            this.positionTrackbar.LargeChange = 1;
            this.positionTrackbar.Location = new System.Drawing.Point(93, 44);
            this.positionTrackbar.Maximum = 100;
            this.positionTrackbar.Name = "positionTrackbar";
            this.positionTrackbar.Size = new System.Drawing.Size(118, 45);
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
            this.timerTrackbar.Tick += new System.EventHandler(this.SongTime_Tick);
            // 
            // timeDisplay
            // 
            this.timeDisplay.AutoSize = true;
            this.timeDisplay.Location = new System.Drawing.Point(217, 44);
            this.timeDisplay.Name = "timeDisplay";
            this.timeDisplay.Size = new System.Drawing.Size(49, 13);
            this.timeDisplay.TabIndex = 5;
            this.timeDisplay.Text = "00:00:00";
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.BackColor = System.Drawing.Color.White;
            this.volumeTrackBar.LargeChange = 1;
            this.volumeTrackBar.Location = new System.Drawing.Point(213, 64);
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(66, 45);
            this.volumeTrackBar.TabIndex = 6;
            this.volumeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackBar.Value = 50;
            this.volumeTrackBar.Scroll += new System.EventHandler(this.VolumeTrackBar_Scroll);
            // 
            // volumeMute
            // 
            this.volumeMute.BackColor = System.Drawing.Color.Gray;
            this.volumeMute.FlatAppearance.BorderSize = 0;
            this.volumeMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.volumeMute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeMute.ForeColor = System.Drawing.Color.White;
            this.volumeMute.Location = new System.Drawing.Point(191, 64);
            this.volumeMute.Margin = new System.Windows.Forms.Padding(0);
            this.volumeMute.Name = "volumeMute";
            this.volumeMute.Size = new System.Drawing.Size(22, 20);
            this.volumeMute.TabIndex = 7;
            this.volumeMute.Text = "X";
            this.volumeMute.UseVisualStyleBackColor = false;
            this.volumeMute.Click += new System.EventHandler(this.VolumeMute_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(284, 87);
            this.Controls.Add(this.volumeMute);
            this.Controls.Add(this.volumeTrackBar);
            this.Controls.Add(this.timeDisplay);
            this.Controls.Add(this.positionTrackbar);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.openFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "mainWindow";
            this.Text = "alby - Love Music";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.positionTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timerTrackbar;
        private System.Windows.Forms.Label timeDisplay;
        public System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.Button volumeMute;
        private System.Windows.Forms.TrackBar positionTrackbar;
    }
}

