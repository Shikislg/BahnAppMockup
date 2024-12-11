using BahnAppMockup.Components;
using BahnAppMockup.Design;
using System.Drawing;
using System.Windows.Forms;

namespace BahnAppMockup.Forms
{
    partial class PlaceSearch
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
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.GladbachButton = new BahnAppMockup.Components.CustomButton();
            this.CologneButton = new BahnAppMockup.Components.CustomButton();
            this.NearbyStopsButton = new BahnAppMockup.Components.CustomButton();
            this.CurrPosButton = new BahnAppMockup.Components.CustomButton();
            this.textBox1 = new BahnAppMockup.Components.CustomTextBox(this.components);
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("DB Neo Office Cond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(3, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 28);
            this.button3.TabIndex = 7;
            this.button3.Text = "Cancel";
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            this.button3.MouseHover += new System.EventHandler(this.button3_MouseHover);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("DB Neo Office Head", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-1, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(387, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select point of Departure";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.panel1.Location = new System.Drawing.Point(-5, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 20);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(-20, 184);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 37);
            this.panel2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(410, 33);
            this.label1.TabIndex = 13;
            this.label1.Text = "History";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GladbachButton
            // 
            this.GladbachButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.GladbachButton.ButtonText = "Köln-Mülheim";
            this.GladbachButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GladbachButton.Font = new System.Drawing.Font("DB Neo Office Cond", 11.25F);
            this.GladbachButton.ForeColor = System.Drawing.Color.White;
            this.GladbachButton.Location = new System.Drawing.Point(0, 267);
            this.GladbachButton.Name = "GladbachButton";
            this.GladbachButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.GladbachButton.Size = new System.Drawing.Size(403, 40);
            this.GladbachButton.TabIndex = 16;
            // 
            // CologneButton
            // 
            this.CologneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.CologneButton.ButtonText = "Bergisch Gladbach";
            this.CologneButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CologneButton.Font = new System.Drawing.Font("DB Neo Office Cond", 11.25F);
            this.CologneButton.ForeColor = System.Drawing.Color.White;
            this.CologneButton.Location = new System.Drawing.Point(0, 227);
            this.CologneButton.Name = "CologneButton";
            this.CologneButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.CologneButton.Size = new System.Drawing.Size(403, 40);
            this.CologneButton.TabIndex = 15;
            // 
            // NearbyStopsButton
            // 
            this.NearbyStopsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.NearbyStopsButton.ButtonText = "Nearby Stations";
            this.NearbyStopsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NearbyStopsButton.Font = new System.Drawing.Font("DB Neo Office Cond", 11.25F);
            this.NearbyStopsButton.ForeColor = System.Drawing.Color.White;
            this.NearbyStopsButton.Location = new System.Drawing.Point(0, 145);
            this.NearbyStopsButton.Name = "NearbyStopsButton";
            this.NearbyStopsButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.NearbyStopsButton.Size = new System.Drawing.Size(403, 40);
            this.NearbyStopsButton.TabIndex = 12;
            // 
            // CurrPosButton
            // 
            this.CurrPosButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.CurrPosButton.ButtonText = "Current Position";
            this.CurrPosButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CurrPosButton.Font = new System.Drawing.Font("DB Neo Office Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrPosButton.ForeColor = System.Drawing.Color.White;
            this.CurrPosButton.Location = new System.Drawing.Point(0, 105);
            this.CurrPosButton.Name = "CurrPosButton";
            this.CurrPosButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.CurrPosButton.Size = new System.Drawing.Size(403, 40);
            this.CurrPosButton.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.textBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox1.Font = new System.Drawing.Font("DB Neo Office Cond", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(5, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Padding = new System.Windows.Forms.Padding(30, 5, 5, 15);
            this.textBox1.Size = new System.Drawing.Size(372, 38);
            this.textBox1.TabIndex = 17;
            // 
            // PlaceSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(389, 814);
            this.Controls.Add(this.GladbachButton);
            this.Controls.Add(this.CologneButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.NearbyStopsButton);
            this.Controls.Add(this.CurrPosButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlaceSearch";
            this.Text = "PlaceSearch";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Components.CustomTextBox textBox1;
        private CustomButton CurrPosButton;
        private CustomButton NearbyStopsButton;
        private CustomButton GladbachButton;
        private CustomButton CologneButton;
    }
}