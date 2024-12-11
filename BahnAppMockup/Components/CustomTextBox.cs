using BahnAppMockup.Design;
using BahnAppMockup.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BahnAppMockup.Components
{
    public partial class CustomTextBox : Panel
    {
        private TextBox innerTextBox = new TextBox();
        private PictureBox leftImage = new PictureBox();

        public CustomTextBox()
        {
            InitializeComponent();
            InitializeCustomTextBox();
        }

        public CustomTextBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InitializeCustomTextBox();
        }

        private void InitializeCustomTextBox()
        {
            // Set Panel properties
            BackColor = DesignProperties.darkButtonColor;
            BorderStyle = BorderStyle.None;
            Font = DesignProperties.textBoxFont;
            ForeColor = Color.White;
            Padding = new Padding(30, 5, 5, 15); // Leave space for the image on the left

            // Add the inner TextBox
            Controls.Add(innerTextBox);

            // Set TextBox properties
            innerTextBox.BackColor = DesignProperties.darkButtonColor;
            innerTextBox.BorderStyle = BorderStyle.None;
            innerTextBox.Font = DesignProperties.textBoxFont;
            innerTextBox.ForeColor = Color.White;

            // Add PictureBox for the image
            leftImage.Image = (Image)Properties.Resources.ResourceManager.GetObject("circlewithdot");
            leftImage.BackColor = Color.Transparent; // Ensure no extra background overlaps
            leftImage.SizeMode = PictureBoxSizeMode.StretchImage; // Scale the image
            leftImage.Size = new Size(15, 15); // Adjust the size to fit your layout
            leftImage.Location = new Point(5, (Height - leftImage.Height) / 2); // Center vertically
            leftImage.Anchor = AnchorStyles.Left | AnchorStyles.Top; // Keep the image in the top-left
            Controls.Add(leftImage);

            // Ensure the image is drawn on top
            leftImage.BringToFront();
            ResizeInnerTextBox();
        }

        private void ResizeInnerTextBox()
        {
            // Calculate the size and position of the innerTextBox based on padding
            innerTextBox.Location = new Point(Padding.Left, Padding.Top);
            innerTextBox.Size = new Size(
                Width - Padding.Left - Padding.Right,
                Height - Padding.Top - Padding.Bottom
            );
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Adjust the PictureBox position when resized
            leftImage.Location = new Point(5, (Height - leftImage.Height) / 2); // Center vertically
            ResizeInnerTextBox();
        }

        // Override OnPaint to draw the white bottom border
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Set the graphics properties for smooth lines
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Save the original clip region
            var originalClip = e.Graphics.Clip;

            // Exclude the PictureBox area from the clip region
            var excludeRect = new Rectangle(leftImage.Left, leftImage.Bottom - 1, leftImage.Width, 2);
            var region = new Region(originalClip.GetBounds(e.Graphics));
            region.Exclude(excludeRect);
            e.Graphics.Clip = region;

            using (Pen whitePen = new Pen(Color.White, 2)) // 2px thick white line
            {
                // Draw the bottom border across the entire width
                e.Graphics.DrawLine(
                    whitePen,
                    0,                // Start X (left edge of the panel)
                    Height - 1,       // Start Y (bottom of the panel)
                    Width,            // End X (right edge of the panel)
                    Height - 1        // End Y (bottom of the panel)
                );
            }

            // Restore the original clip region
            e.Graphics.Clip = originalClip;
        }


    }
}
