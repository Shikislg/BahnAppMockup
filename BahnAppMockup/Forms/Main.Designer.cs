namespace BahnAppMockup
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MiniPanel = new RoundedPanel();
            this.FormPanel = new RoundedPanel();
            this.SuspendLayout();
            // 
            // MiniPanel
            // 
            this.MiniPanel.BackColor = System.Drawing.Color.Transparent;
            this.MiniPanel.BorderColor = System.Drawing.Color.Black;
            this.MiniPanel.BorderWidth = 2F;
            this.MiniPanel.CornerRadius = 20;
            this.MiniPanel.Location = new System.Drawing.Point(0, 20);
            this.MiniPanel.Name = "MiniPanel";
            this.MiniPanel.Size = new System.Drawing.Size(389, 814);
            this.MiniPanel.TabIndex = 1;
            this.MiniPanel.Visible = false;
            // 
            // FormPanel
            // 
            this.FormPanel.BorderColor = System.Drawing.Color.Black;
            this.FormPanel.BorderWidth = 2F;
            this.FormPanel.CornerRadius = 20;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(387, 837);
            this.FormPanel.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(386, 835);
            this.Controls.Add(this.MiniPanel);
            this.Controls.Add(this.FormPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "BahnApp Mockup";
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPanel FormPanel;
        private RoundedPanel MiniPanel;
    }
}