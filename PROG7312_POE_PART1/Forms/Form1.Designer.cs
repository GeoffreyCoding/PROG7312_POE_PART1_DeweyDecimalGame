namespace PROG7312_POE_PART1
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
            this.mainMenu1 = new PROG7312_POE_PART1.UserControls.mainMenu();
            this.orderingGame1 = new PROG7312_POE_PART1.UserControls.orderingGame();
            this.leaderboard1 = new PROG7312_POE_PART1.UserControls.Leaderboard();
            this.achievementPage1 = new PROG7312_POE_PART1.UserControls.AchievementPage();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.BackColor = System.Drawing.Color.AliceBlue;
            this.mainMenu1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainMenu1.BackgroundImage")));
            this.mainMenu1.Location = new System.Drawing.Point(-2, 0);
            this.mainMenu1.MaximumSize = new System.Drawing.Size(1001, 513);
            this.mainMenu1.MinimumSize = new System.Drawing.Size(1001, 513);
            this.mainMenu1.Name = "mainMenu1";
            this.mainMenu1.Size = new System.Drawing.Size(1001, 513);
            this.mainMenu1.TabIndex = 0;
            // 
            // orderingGame1
            // 
            this.orderingGame1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("orderingGame1.BackgroundImage")));
            this.orderingGame1.Location = new System.Drawing.Point(-2, 0);
            this.orderingGame1.MaximumSize = new System.Drawing.Size(1001, 513);
            this.orderingGame1.MinimumSize = new System.Drawing.Size(1001, 513);
            this.orderingGame1.Name = "orderingGame1";
            this.orderingGame1.Size = new System.Drawing.Size(1001, 513);
            this.orderingGame1.TabIndex = 1;
            this.orderingGame1.Visible = false;
            // 
            // leaderboard1
            // 
            this.leaderboard1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leaderboard1.BackgroundImage")));
            this.leaderboard1.Location = new System.Drawing.Point(-2, 0);
            this.leaderboard1.MaximumSize = new System.Drawing.Size(1001, 513);
            this.leaderboard1.MinimumSize = new System.Drawing.Size(1001, 513);
            this.leaderboard1.Name = "leaderboard1";
            this.leaderboard1.Size = new System.Drawing.Size(1001, 513);
            this.leaderboard1.TabIndex = 2;
            this.leaderboard1.Visible = false;
            // 
            // achievementPage1
            // 
            this.achievementPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("achievementPage1.BackgroundImage")));
            this.achievementPage1.Location = new System.Drawing.Point(-2, 0);
            this.achievementPage1.MaximumSize = new System.Drawing.Size(1001, 513);
            this.achievementPage1.MinimumSize = new System.Drawing.Size(1001, 513);
            this.achievementPage1.Name = "achievementPage1";
            this.achievementPage1.Size = new System.Drawing.Size(1001, 513);
            this.achievementPage1.TabIndex = 3;
            this.achievementPage1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 512);
            this.Controls.Add(this.achievementPage1);
            this.Controls.Add(this.leaderboard1);
            this.Controls.Add(this.orderingGame1);
            this.Controls.Add(this.mainMenu1);
            this.MaximumSize = new System.Drawing.Size(1001, 551);
            this.MinimumSize = new System.Drawing.Size(1001, 551);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.mainMenu mainMenu1;
        private UserControls.orderingGame orderingGame1;
        private UserControls.Leaderboard leaderboard1;
        private UserControls.AchievementPage achievementPage1;
    }
}

