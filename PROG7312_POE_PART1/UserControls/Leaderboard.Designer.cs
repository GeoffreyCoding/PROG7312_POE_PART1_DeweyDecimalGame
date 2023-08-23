namespace PROG7312_POE_PART1.UserControls
{
    partial class Leaderboard
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
            this.btn_BackToMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_BackToMenu
            // 
            this.btn_BackToMenu.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.mainMenuBtnBackgrounds;
            this.btn_BackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_BackToMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BackToMenu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_BackToMenu.Location = new System.Drawing.Point(796, 464);
            this.btn_BackToMenu.Name = "btn_BackToMenu";
            this.btn_BackToMenu.Size = new System.Drawing.Size(156, 35);
            this.btn_BackToMenu.TabIndex = 24;
            this.btn_BackToMenu.Text = "Back to Menu";
            this.btn_BackToMenu.UseVisualStyleBackColor = true;
            this.btn_BackToMenu.Click += new System.EventHandler(this.btn_BackToMenu_Click);
            this.btn_BackToMenu.MouseEnter += new System.EventHandler(this.btn_BackToMenu_MouseEnter);
            // 
            // Leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.orderGameBackground;
            this.Controls.Add(this.btn_BackToMenu);
            this.MaximumSize = new System.Drawing.Size(1001, 513);
            this.MinimumSize = new System.Drawing.Size(1001, 513);
            this.Name = "Leaderboard";
            this.Size = new System.Drawing.Size(1001, 513);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_BackToMenu;
    }
}
