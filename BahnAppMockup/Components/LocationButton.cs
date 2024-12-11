using BahnAppMockup.Design;
using BahnAppMockup.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BahnAppMockup.Components
{
    public enum StationTypes
    {
        Station = 0,
        Location = 1,
        Position = 2
    }

    public class CustomButton : UserControl
    {
        private PictureBox leftIcon;
        private Label buttonText;
        private PictureBox rightIcon;

        public CustomButton()
        {
            InitializeComponent("destination");
        }

        public CustomButton(string text)
        {
            InitializeComponent("destination");
            ButtonText = text;
        }

        public CustomButton(bool favoritable, string text, int stationType)
        {
            if (!Enum.IsDefined(typeof(StationTypes), stationType))
            {
                throw new ArgumentException("Station Type invalid!");
            }

            switch (stationType)
            {
                case 0: InitializeComponent("Station"); break;
                case 1: InitializeComponent("destination"); break;
                case 2: InitializeComponent("Position"); break;
            }
            
            ButtonText = text;
            rightIcon.Visible = favoritable;
        }

        public void ChangeIcon(int stationType)
        {
            string s = "";
            switch (stationType)
            {
                case 0: s  = "Station"; break;
                case 1: s = "destination"; break;
                case 2: s = "Position"; break;
            }
            leftIcon.Image = (Image)Properties.Resources.ResourceManager.GetObject(s);
            rightIcon.Image = (Image)Properties.Resources.ResourceManager.GetObject("unfavorite");
        }
        private void InitializeComponent(string leftPicture)
        {
            this.buttonText = new Label();
            this.leftIcon = new PictureBox();
            this.rightIcon = new PictureBox();

            // Configure UserControl
            this.BackColor = DesignProperties.backgroundColor;
            this.Size = new Size(300, 50);

            // Left Icon
            leftIcon.Image = (Image)Properties.Resources.ResourceManager.GetObject(leftPicture);
            leftIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            leftIcon.Size = new Size(15, 15);
            leftIcon.Location = new Point(15, (this.Height - leftIcon.Height) / 2);
            leftIcon.Anchor = AnchorStyles.Left;

            // Button Text
            buttonText.ForeColor = Color.White;
            buttonText.AutoSize = true;
            buttonText.Location = new Point(40, (this.Height - buttonText.Height) / 2);
            buttonText.Anchor = AnchorStyles.Left;

            // Right Icon
            rightIcon.Image = (Image)Properties.Resources.ResourceManager.GetObject("unfavorite");
            rightIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            rightIcon.Size = new Size(15, 15);
            rightIcon.Location = new Point(this.Width - rightIcon.Width - 50, (this.Height - rightIcon.Height) / 2);

            // Add Controls
            this.Controls.Add(leftIcon);
            this.Controls.Add(buttonText);
            this.Controls.Add(rightIcon);

            // Handle Resize
            this.Resize += CustomButton_Resize;

            // Forward Click Events
            leftIcon.Click += ForwardClick;
            buttonText.Click += ForwardClick;
            rightIcon.Click += ForwardClick;
            this.Click += ButtonOnClick;
        }

        private void ButtonOnClick(object sender, EventArgs e)
        {
            PlaceSearch.GetInstance().SelectPlace(ButtonText);
            Main.GetInstance().ClearMiniPanel();

            Main.GetInstance().Invalidate();
        }
        private void CustomButton_Resize(object sender, EventArgs e)
        {
            // Reposition elements on resize
            leftIcon.Location = new Point(10, (this.Height - leftIcon.Height) / 2);
            buttonText.Location = new Point(40, (this.Height - buttonText.Height) / 2);
            rightIcon.Location = new Point(this.Width - rightIcon.Width - 50, (this.Height - rightIcon.Height) / 2);
        }

        private void ForwardClick(object sender, EventArgs e)
        {
            // Raise the UserControl's Click event
            this.OnClick(e);
        }

        // Properties for customizing the button
        public string ButtonText
        {
            get => buttonText.Text;
            set => buttonText.Text = value;
        }

        public string LeftIconResource
        {
            set => leftIcon.Image = (Image)Properties.Resources.ResourceManager.GetObject(value);
        }

        public string RightIconResource
        {
            set => rightIcon.Image = (Image)Properties.Resources.ResourceManager.GetObject(value);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Set the graphics smoothing mode for better quality
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Define the border color and width
            using (Pen borderPen = new Pen(Color.FromArgb(50,255,255,255), 1))
            {
                // Draw the bottom border
                e.Graphics.DrawLine(
                    borderPen,
                    0,                // Start X (left edge)
                    this.Height - 1,  // Start Y (bottom edge)
                    this.Width,       // End X (right edge)
                    this.Height - 1   // End Y (bottom edge)
                );
            }
        }

    }
}
