﻿namespace PROG7312_POE_PART1.UserControls
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
            this.btn_Acheivements = new System.Windows.Forms.Button();
            this.tb_Help = new System.Windows.Forms.TabControl();
            this.tp_OrderingGame = new System.Windows.Forms.TabPage();
            this.rtb_OrderingGameHelp = new System.Windows.Forms.RichTextBox();
            this.tp_MatchingGame = new System.Windows.Forms.TabPage();
            this.rtb_MatchingGame = new System.Windows.Forms.RichTextBox();
            this.tb_Help.SuspendLayout();
            this.tp_OrderingGame.SuspendLayout();
            this.tp_MatchingGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_OrderGame
            // 
            this.btn_OrderGame.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_OrderGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_OrderGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OrderGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_OrderGame.Location = new System.Drawing.Point(373, 87);
            this.btn_OrderGame.Name = "btn_OrderGame";
            this.btn_OrderGame.Size = new System.Drawing.Size(156, 39);
            this.btn_OrderGame.TabIndex = 0;
            this.btn_OrderGame.Text = "Order game";
            this.btn_OrderGame.UseVisualStyleBackColor = false;
            this.btn_OrderGame.Click += new System.EventHandler(this.btn_OrderGame_Click);
            this.btn_OrderGame.MouseEnter += new System.EventHandler(this.btn_OrderGame_MouseEnter);
            // 
            // btn_Leaderboard
            // 
            this.btn_Leaderboard.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Leaderboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Leaderboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Leaderboard.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Leaderboard.Location = new System.Drawing.Point(373, 355);
            this.btn_Leaderboard.Name = "btn_Leaderboard";
            this.btn_Leaderboard.Size = new System.Drawing.Size(156, 43);
            this.btn_Leaderboard.TabIndex = 1;
            this.btn_Leaderboard.Text = "Leaderboard";
            this.btn_Leaderboard.UseVisualStyleBackColor = false;
            this.btn_Leaderboard.Click += new System.EventHandler(this.btn_Leaderboard_Click);
            this.btn_Leaderboard.MouseEnter += new System.EventHandler(this.btn_OrderGame_MouseEnter);
            // 
            // btn_MatchColumns
            // 
            this.btn_MatchColumns.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_MatchColumns.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_MatchColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MatchColumns.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_MatchColumns.Location = new System.Drawing.Point(373, 163);
            this.btn_MatchColumns.Name = "btn_MatchColumns";
            this.btn_MatchColumns.Size = new System.Drawing.Size(156, 39);
            this.btn_MatchColumns.TabIndex = 2;
            this.btn_MatchColumns.Text = "Matching Game";
            this.btn_MatchColumns.UseVisualStyleBackColor = false;
            this.btn_MatchColumns.Click += new System.EventHandler(this.btn_OrderGame_Click);
            this.btn_MatchColumns.MouseEnter += new System.EventHandler(this.btn_OrderGame_MouseEnter);
            // 
            // btn_FindCallNumbers
            // 
            this.btn_FindCallNumbers.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_FindCallNumbers.Enabled = false;
            this.btn_FindCallNumbers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_FindCallNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FindCallNumbers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_FindCallNumbers.Location = new System.Drawing.Point(373, 265);
            this.btn_FindCallNumbers.Name = "btn_FindCallNumbers";
            this.btn_FindCallNumbers.Size = new System.Drawing.Size(156, 39);
            this.btn_FindCallNumbers.TabIndex = 3;
            this.btn_FindCallNumbers.Text = "Find Numbers";
            this.btn_FindCallNumbers.UseVisualStyleBackColor = false;
            this.btn_FindCallNumbers.Click += new System.EventHandler(this.btn_OrderGame_Click);
            this.btn_FindCallNumbers.MouseEnter += new System.EventHandler(this.btn_OrderGame_MouseEnter);
            // 
            // btn_Acheivements
            // 
            this.btn_Acheivements.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Acheivements.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Acheivements.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Acheivements.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Acheivements.Location = new System.Drawing.Point(373, 459);
            this.btn_Acheivements.Name = "btn_Acheivements";
            this.btn_Acheivements.Size = new System.Drawing.Size(156, 43);
            this.btn_Acheivements.TabIndex = 4;
            this.btn_Acheivements.Text = "Acheivments";
            this.btn_Acheivements.UseVisualStyleBackColor = false;
            this.btn_Acheivements.Click += new System.EventHandler(this.btn_Acheivements_Click);
            this.btn_Acheivements.MouseEnter += new System.EventHandler(this.btn_OrderGame_MouseEnter);
            // 
            // tb_Help
            // 
            this.tb_Help.Controls.Add(this.tp_OrderingGame);
            this.tb_Help.Controls.Add(this.tp_MatchingGame);
            this.tb_Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Help.Location = new System.Drawing.Point(26, 72);
            this.tb_Help.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_Help.Name = "tb_Help";
            this.tb_Help.SelectedIndex = 0;
            this.tb_Help.Size = new System.Drawing.Size(226, 206);
            this.tb_Help.TabIndex = 5;
            // 
            // tp_OrderingGame
            // 
            this.tp_OrderingGame.Controls.Add(this.rtb_OrderingGameHelp);
            this.tp_OrderingGame.Location = new System.Drawing.Point(4, 31);
            this.tp_OrderingGame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tp_OrderingGame.Name = "tp_OrderingGame";
            this.tp_OrderingGame.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tp_OrderingGame.Size = new System.Drawing.Size(218, 171);
            this.tp_OrderingGame.TabIndex = 0;
            this.tp_OrderingGame.Text = "Ordering Game";
            this.tp_OrderingGame.UseVisualStyleBackColor = true;
            // 
            // rtb_OrderingGameHelp
            // 
            this.rtb_OrderingGameHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_OrderingGameHelp.Location = new System.Drawing.Point(2, 0);
            this.rtb_OrderingGameHelp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtb_OrderingGameHelp.Name = "rtb_OrderingGameHelp";
            this.rtb_OrderingGameHelp.ReadOnly = true;
            this.rtb_OrderingGameHelp.Size = new System.Drawing.Size(216, 181);
            this.rtb_OrderingGameHelp.TabIndex = 0;
            this.rtb_OrderingGameHelp.Text = resources.GetString("rtb_OrderingGameHelp.Text");
            // 
            // tp_MatchingGame
            // 
            this.tp_MatchingGame.Controls.Add(this.rtb_MatchingGame);
            this.tp_MatchingGame.Location = new System.Drawing.Point(4, 31);
            this.tp_MatchingGame.Name = "tp_MatchingGame";
            this.tp_MatchingGame.Padding = new System.Windows.Forms.Padding(3);
            this.tp_MatchingGame.Size = new System.Drawing.Size(218, 171);
            this.tp_MatchingGame.TabIndex = 1;
            this.tp_MatchingGame.Text = "Matching Game";
            this.tp_MatchingGame.UseVisualStyleBackColor = true;
            // 
            // rtb_MatchingGame
            // 
            this.rtb_MatchingGame.Location = new System.Drawing.Point(0, 3);
            this.rtb_MatchingGame.Name = "rtb_MatchingGame";
            this.rtb_MatchingGame.Size = new System.Drawing.Size(218, 162);
            this.rtb_MatchingGame.TabIndex = 0;
            this.rtb_MatchingGame.Text = "The matching game requires\nyou to match the catgory\nto the dewey decimal\nclassifi" +
    "cation";
            // 
            // mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.mainMenuBackground3;
            this.Controls.Add(this.tb_Help);
            this.Controls.Add(this.btn_Acheivements);
            this.Controls.Add(this.btn_FindCallNumbers);
            this.Controls.Add(this.btn_MatchColumns);
            this.Controls.Add(this.btn_Leaderboard);
            this.Controls.Add(this.btn_OrderGame);
            this.MaximumSize = new System.Drawing.Size(1001, 513);
            this.MinimumSize = new System.Drawing.Size(1001, 513);
            this.Name = "mainMenu";
            this.Size = new System.Drawing.Size(1001, 513);
            this.tb_Help.ResumeLayout(false);
            this.tp_OrderingGame.ResumeLayout(false);
            this.tp_MatchingGame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_OrderGame;
        private System.Windows.Forms.Button btn_Leaderboard;
        private System.Windows.Forms.Button btn_MatchColumns;
        private System.Windows.Forms.Button btn_FindCallNumbers;
        private System.Windows.Forms.Button btn_Acheivements;
        private System.Windows.Forms.TabControl tb_Help;
        private System.Windows.Forms.TabPage tp_OrderingGame;
        private System.Windows.Forms.RichTextBox rtb_OrderingGameHelp;
        private System.Windows.Forms.TabPage tp_MatchingGame;
        private System.Windows.Forms.RichTextBox rtb_MatchingGame;
    }
}
