namespace PROG7312_POE_PART1.UserControls
{
    partial class loseGame
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
            this.lb_YouLose = new System.Windows.Forms.Label();
            this.bt_Close = new System.Windows.Forms.Button();
            this.pb_LoseGame = new System.Windows.Forms.PictureBox();
            this.lb_Score = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_LoseGame)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_YouLose
            // 
            this.lb_YouLose.AutoSize = true;
            this.lb_YouLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_YouLose.Location = new System.Drawing.Point(512, 222);
            this.lb_YouLose.Name = "lb_YouLose";
            this.lb_YouLose.Size = new System.Drawing.Size(158, 32);
            this.lb_YouLose.TabIndex = 42;
            this.lb_YouLose.Text = "You Lose :(";
            // 
            // bt_Close
            // 
            this.bt_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Close.Location = new System.Drawing.Point(507, 365);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(134, 44);
            this.bt_Close.TabIndex = 41;
            this.bt_Close.Text = "Close";
            this.bt_Close.UseVisualStyleBackColor = true;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // pb_LoseGame
            // 
            this.pb_LoseGame.BackColor = System.Drawing.Color.Transparent;
            this.pb_LoseGame.Location = new System.Drawing.Point(0, 0);
            this.pb_LoseGame.Margin = new System.Windows.Forms.Padding(4);
            this.pb_LoseGame.Name = "pb_LoseGame";
            this.pb_LoseGame.Size = new System.Drawing.Size(1306, 613);
            this.pb_LoseGame.TabIndex = 40;
            this.pb_LoseGame.TabStop = false;
            // 
            // lb_Score
            // 
            this.lb_Score.AutoSize = true;
            this.lb_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Score.Location = new System.Drawing.Point(424, 290);
            this.lb_Score.Name = "lb_Score";
            this.lb_Score.Size = new System.Drawing.Size(363, 32);
            this.lb_Score.TabIndex = 43;
            this.lb_Score.Text = "Score || Right : 0 | Wrong : 0";
            // 
            // loseGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lb_Score);
            this.Controls.Add(this.lb_YouLose);
            this.Controls.Add(this.bt_Close);
            this.Controls.Add(this.pb_LoseGame);
            this.MaximumSize = new System.Drawing.Size(1331, 613);
            this.MinimumSize = new System.Drawing.Size(1331, 613);
            this.Name = "loseGame";
            this.Size = new System.Drawing.Size(1331, 613);
            this.VisibleChanged += new System.EventHandler(this.AshFall_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pb_LoseGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_YouLose;
        private System.Windows.Forms.Button bt_Close;
        private System.Windows.Forms.PictureBox pb_LoseGame;
        private System.Windows.Forms.Timer ashTimer;
        private System.Windows.Forms.Label lb_Score;
    }
}
