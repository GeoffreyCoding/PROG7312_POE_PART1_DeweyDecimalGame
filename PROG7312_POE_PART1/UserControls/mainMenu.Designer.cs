namespace PROG7312_POE_PART1.UserControls
{
    partial class mainMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainMenu));
            this.btn_OrderGame = new System.Windows.Forms.Button();
            this.btn_Leaderboard = new System.Windows.Forms.Button();
            this.btn_MatchColumns = new System.Windows.Forms.Button();
            this.btn_FindCallNumbers = new System.Windows.Forms.Button();
            this.wmp_MusicPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.wmp_MusicPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OrderGame
            // 
            this.btn_OrderGame.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.mainMenuBtnBackgrounds;
            this.btn_OrderGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_OrderGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OrderGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_OrderGame.Location = new System.Drawing.Point(373, 87);
            this.btn_OrderGame.Name = "btn_OrderGame";
            this.btn_OrderGame.Size = new System.Drawing.Size(156, 39);
            this.btn_OrderGame.TabIndex = 0;
            this.btn_OrderGame.Text = "Order game";
            this.btn_OrderGame.UseVisualStyleBackColor = true;
            // 
            // btn_Leaderboard
            // 
            this.btn_Leaderboard.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.mainMenuBtnBackgrounds;
            this.btn_Leaderboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Leaderboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Leaderboard.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Leaderboard.Location = new System.Drawing.Point(373, 355);
            this.btn_Leaderboard.Name = "btn_Leaderboard";
            this.btn_Leaderboard.Size = new System.Drawing.Size(156, 43);
            this.btn_Leaderboard.TabIndex = 1;
            this.btn_Leaderboard.Text = "Leaderboard";
            this.btn_Leaderboard.UseVisualStyleBackColor = true;
            // 
            // btn_MatchColumns
            // 
            this.btn_MatchColumns.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.mainMenuBtnBackgrounds;
            this.btn_MatchColumns.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_MatchColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MatchColumns.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_MatchColumns.Location = new System.Drawing.Point(373, 163);
            this.btn_MatchColumns.Name = "btn_MatchColumns";
            this.btn_MatchColumns.Size = new System.Drawing.Size(156, 39);
            this.btn_MatchColumns.TabIndex = 2;
            this.btn_MatchColumns.Text = "Matching Game";
            this.btn_MatchColumns.UseVisualStyleBackColor = true;
            // 
            // btn_FindCallNumbers
            // 
            this.btn_FindCallNumbers.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.mainMenuBtnBackgrounds;
            this.btn_FindCallNumbers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_FindCallNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FindCallNumbers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_FindCallNumbers.Location = new System.Drawing.Point(373, 265);
            this.btn_FindCallNumbers.Name = "btn_FindCallNumbers";
            this.btn_FindCallNumbers.Size = new System.Drawing.Size(156, 39);
            this.btn_FindCallNumbers.TabIndex = 3;
            this.btn_FindCallNumbers.Text = "Find Numbers";
            this.btn_FindCallNumbers.UseVisualStyleBackColor = true;
            // 
            // wmp_MusicPlayer
            // 
            this.wmp_MusicPlayer.Enabled = true;
            this.wmp_MusicPlayer.Location = new System.Drawing.Point(783, 464);
            this.wmp_MusicPlayer.Name = "wmp_MusicPlayer";
            this.wmp_MusicPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmp_MusicPlayer.OcxState")));
            this.wmp_MusicPlayer.Size = new System.Drawing.Size(215, 46);
            this.wmp_MusicPlayer.TabIndex = 4;
            // 
            // mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.mainMenuBackground3;
            this.Controls.Add(this.wmp_MusicPlayer);
            this.Controls.Add(this.btn_FindCallNumbers);
            this.Controls.Add(this.btn_MatchColumns);
            this.Controls.Add(this.btn_Leaderboard);
            this.Controls.Add(this.btn_OrderGame);
            this.MaximumSize = new System.Drawing.Size(1001, 513);
            this.MinimumSize = new System.Drawing.Size(1001, 513);
            this.Name = "mainMenu";
            this.Size = new System.Drawing.Size(1001, 513);
            ((System.ComponentModel.ISupportInitialize)(this.wmp_MusicPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_OrderGame;
        private System.Windows.Forms.Button btn_Leaderboard;
        private System.Windows.Forms.Button btn_MatchColumns;
        private System.Windows.Forms.Button btn_FindCallNumbers;
        private AxWMPLib.AxWindowsMediaPlayer wmp_MusicPlayer;
    }
}
