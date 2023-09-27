namespace PROG7312_POE_PART1.UserControls
{
    partial class loadingScreen
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
            this.components = new System.ComponentModel.Container();
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
            this.lb_Loading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // timerLoading
            // 
            this.timerLoading.Tick += new System.EventHandler(this.timerLoading_Tick);
            // 
            // pictureBoxLoading
            // 
            this.pictureBoxLoading.Location = new System.Drawing.Point(236, 91);
            this.pictureBoxLoading.Name = "pictureBoxLoading";
            this.pictureBoxLoading.Size = new System.Drawing.Size(513, 331);
            this.pictureBoxLoading.TabIndex = 0;
            this.pictureBoxLoading.TabStop = false;
            this.pictureBoxLoading.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxLoading_Paint);
            // 
            // lb_Loading
            // 
            this.lb_Loading.AutoSize = true;
            this.lb_Loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Loading.Location = new System.Drawing.Point(455, 240);
            this.lb_Loading.Name = "lb_Loading";
            this.lb_Loading.Size = new System.Drawing.Size(89, 25);
            this.lb_Loading.TabIndex = 2;
            this.lb_Loading.Text = "Loading";
            // 
            // loadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_Loading);
            this.Controls.Add(this.pictureBoxLoading);
            this.MaximumSize = new System.Drawing.Size(1001, 513);
            this.MinimumSize = new System.Drawing.Size(1001, 513);
            this.Name = "loadingScreen";
            this.Size = new System.Drawing.Size(1001, 513);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerLoading;
        private System.Windows.Forms.PictureBox pictureBoxLoading;
        private System.Windows.Forms.Label lb_Loading;
    }
}
