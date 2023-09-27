namespace PROG7312_POE_PART1.UserControls
{
    partial class Confetti
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
            this.pb_Confetti = new System.Windows.Forms.PictureBox();
            this.bt_Close = new System.Windows.Forms.Button();
            this.lb_YouWin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Confetti)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Confetti
            // 
            this.pb_Confetti.BackColor = System.Drawing.Color.Transparent;
            this.pb_Confetti.Location = new System.Drawing.Point(11, 10);
            this.pb_Confetti.Margin = new System.Windows.Forms.Padding(4);
            this.pb_Confetti.Name = "pb_Confetti";
            this.pb_Confetti.Size = new System.Drawing.Size(1331, 613);
            this.pb_Confetti.TabIndex = 37;
            this.pb_Confetti.TabStop = false;
            // 
            // bt_Close
            // 
            this.bt_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Close.Location = new System.Drawing.Point(518, 375);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(134, 44);
            this.bt_Close.TabIndex = 38;
            this.bt_Close.Text = "Close";
            this.bt_Close.UseVisualStyleBackColor = true;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // lb_YouWin
            // 
            this.lb_YouWin.AutoSize = true;
            this.lb_YouWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_YouWin.Location = new System.Drawing.Point(523, 232);
            this.lb_YouWin.Name = "lb_YouWin";
            this.lb_YouWin.Size = new System.Drawing.Size(129, 32);
            this.lb_YouWin.TabIndex = 39;
            this.lb_YouWin.Text = "You Win!";
            // 
            // Confetti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lb_YouWin);
            this.Controls.Add(this.bt_Close);
            this.Controls.Add(this.pb_Confetti);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1331, 613);
            this.MinimumSize = new System.Drawing.Size(1331, 613);
            this.Name = "Confetti";
            this.Size = new System.Drawing.Size(1331, 613);
            this.VisibleChanged += new System.EventHandler(this.Confetti_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Confetti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Confetti;
        private System.Windows.Forms.Button bt_Close;
        private System.Windows.Forms.Label lb_YouWin;
    }
}
