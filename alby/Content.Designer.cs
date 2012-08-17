namespace Alby
{
    partial class Content
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            this.contentWindow = new System.Windows.Forms.TabControl();
            this.nowPlaying = new System.Windows.Forms.TabPage();
            this.library = new System.Windows.Forms.TabPage();
            this.libraryList = new System.Windows.Forms.ListView();
            this.nowPlayingList = new System.Windows.Forms.ListView();
            this.songTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.artistName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.albumTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.index = new System.Windows.Forms.Button();
            this.contentWindow.SuspendLayout();
            this.nowPlaying.SuspendLayout();
            this.library.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentWindow
            // 
            this.contentWindow.Controls.Add(this.nowPlaying);
            this.contentWindow.Controls.Add(this.library);
            this.contentWindow.Location = new System.Drawing.Point(13, 45);
            this.contentWindow.Name = "contentWindow";
            this.contentWindow.SelectedIndex = 0;
            this.contentWindow.Size = new System.Drawing.Size(332, 248);
            this.contentWindow.TabIndex = 0;
            // 
            // nowPlaying
            // 
            this.nowPlaying.Controls.Add(this.nowPlayingList);
            this.nowPlaying.Location = new System.Drawing.Point(4, 22);
            this.nowPlaying.Name = "nowPlaying";
            this.nowPlaying.Padding = new System.Windows.Forms.Padding(3);
            this.nowPlaying.Size = new System.Drawing.Size(324, 222);
            this.nowPlaying.TabIndex = 0;
            this.nowPlaying.Text = "Now Playing";
            this.nowPlaying.UseVisualStyleBackColor = true;
            // 
            // library
            // 
            this.library.Controls.Add(this.libraryList);
            this.library.Location = new System.Drawing.Point(4, 22);
            this.library.Name = "library";
            this.library.Padding = new System.Windows.Forms.Padding(3);
            this.library.Size = new System.Drawing.Size(324, 222);
            this.library.TabIndex = 1;
            this.library.Text = "Library";
            this.library.UseVisualStyleBackColor = true;
            // 
            // libraryList
            // 
            this.libraryList.Location = new System.Drawing.Point(0, 0);
            this.libraryList.Name = "libraryList";
            this.libraryList.Size = new System.Drawing.Size(324, 219);
            this.libraryList.TabIndex = 0;
            this.libraryList.UseCompatibleStateImageBehavior = false;
            // 
            // nowPlayingList
            // 
            this.nowPlayingList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.songTitle,
            this.artistName,
            this.albumTitle});
            this.nowPlayingList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.nowPlayingList.Location = new System.Drawing.Point(0, 0);
            this.nowPlayingList.Name = "nowPlayingList";
            this.nowPlayingList.Size = new System.Drawing.Size(324, 222);
            this.nowPlayingList.TabIndex = 0;
            this.nowPlayingList.UseCompatibleStateImageBehavior = false;
            // 
            // songTitle
            // 
            this.songTitle.Text = "Song Title";
            // 
            // artistName
            // 
            this.artistName.Text = "Artist";
            // 
            // albumTitle
            // 
            this.albumTitle.Text = "Album Title";
            // 
            // index
            // 
            this.index.Location = new System.Drawing.Point(17, 13);
            this.index.Name = "index";
            this.index.Size = new System.Drawing.Size(75, 23);
            this.index.TabIndex = 1;
            this.index.Text = "Index";
            this.index.UseVisualStyleBackColor = true;
            this.index.Click += new System.EventHandler(this.index_Click);
            // 
            // Content
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(357, 305);
            this.Controls.Add(this.index);
            this.Controls.Add(this.contentWindow);
            this.Name = "Content";
            this.Text = "Content";
            this.contentWindow.ResumeLayout(false);
            this.nowPlaying.ResumeLayout(false);
            this.library.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl contentWindow;
        private System.Windows.Forms.TabPage library;
        private System.Windows.Forms.ListView libraryList;
        private System.Windows.Forms.ColumnHeader songTitle;
        private System.Windows.Forms.ColumnHeader artistName;
        private System.Windows.Forms.ColumnHeader albumTitle;
        public System.Windows.Forms.ListView nowPlayingList;
        public System.Windows.Forms.TabPage nowPlaying;
        private System.Windows.Forms.Button index;
    }
}