using BahnAppMockup.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BahnAppMockup.Forms
{
    public partial class PlaceSearch : Form
    {
        private static PlaceSearch INSTANCE = null;
        bool isDestination = false;

        public static PlaceSearch GetInstance()
        {
            if(INSTANCE == null) INSTANCE = new PlaceSearch();
            return INSTANCE;
        }

        public int CornerRadius { get; set; } = 20;
        public PlaceSearch()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            SetStyle(ControlStyles.ResizeRedraw, true);


            //Manual for now until I find a way to fix it
            GladbachButton.ChangeIcon((int)StationTypes.Station);
            CologneButton.ChangeIcon((int)StationTypes.Station);

        }
        public PlaceSearch(Button source)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            SetStyle(ControlStyles.ResizeRedraw, true);
            label2.Text = source.Name.Equals("DepartureButton") ? "Select point of Departure" : "Select point of Destination";
            if(source.Name.Equals("DestinationButton")) isDestination = true;

            //Manual for now until I find a way to fix it
            GladbachButton.ChangeIcon((int)StationTypes.Station);
            CologneButton.ChangeIcon((int)StationTypes.Station);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main.GetInstance().ClearMiniPanel();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Create a rounded rectangle region for the form
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, CornerRadius, CornerRadius), 180, 90);
                path.AddArc(new Rectangle(Width - CornerRadius, 0, CornerRadius, CornerRadius), 270, 90);
                path.AddArc(new Rectangle(Width - CornerRadius, Height - CornerRadius, CornerRadius, CornerRadius), 0, 90);
                path.AddArc(new Rectangle(0, Height - CornerRadius, CornerRadius, CornerRadius), 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Optional: Draw a border around the form
            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawPath(pen, CreateRoundRectPath(this.ClientRectangle, CornerRadius));
            }
        }

        private GraphicsPath CreateRoundRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(rect.Left, rect.Top, radius, radius), 180, 90);
            path.AddArc(new Rectangle(rect.Right - radius, rect.Top, radius, radius), 270, 90);
            path.AddArc(new Rectangle(rect.Right - radius, rect.Bottom - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(rect.Left, rect.Bottom - radius, radius, radius), 90, 90);
            path.CloseFigure();
            return path;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Debug.WriteLine("test");
            button3.ForeColor = Color.Gray;
        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.White;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {

        }
        
        public void SelectPlace(string text)
        {
            Debug.WriteLine(isDestination);
            if (isDestination) Booking.GetInstance().SetDestinationButtonText(text);
            else Booking.GetInstance().SetDepartureButtonText(text);
        }

    }
}
