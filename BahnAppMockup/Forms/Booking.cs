using BahnAppMockup.Forms;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BahnAppMockup
{
    public partial class Booking : Form
    {
        protected static Booking INSTANCE = new Booking();
        public int CornerRadius { get; set; } = 20;
        public static Booking GetInstance()
        {
            if( INSTANCE == null ) new Booking();
            return INSTANCE;
        }

        public Booking()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            SetStyle(ControlStyles.ResizeRedraw, true);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Main.GetInstance().ChangeDisplayedForm(new Connections());
        }

        private void StationButton_Click(object sender, EventArgs e)
        {
            PlaceSearch form = new PlaceSearch((Button)sender)
            {
                //Set up form to work as child of a panel
                TopLevel = false,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            Main.GetInstance().ChangeDisplayedMiniForm(form);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string help = DepartureButton.Text;
            DepartureButton.Text = DestinationButton.Text;
            DestinationButton.Text = help;
        }

        public void SetDestinationButtonText(string text)
        {
            DestinationButton.Text = text;
        }
        public void SetDepartureButtonText(string text)
        {
            Debug.WriteLine(DepartureButton.Text);
            DepartureButton.Text = text;
            Debug.WriteLine(DepartureButton.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string delayOne = button3.Text;
            string delayTwo = button4.Text;
            string basePath = AppDomain.CurrentDomain.BaseDirectory; // bin\Debug or bin\Release
            string solutionPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
            string aiFolderPath = Path.Combine(solutionPath, "AI");
            // Set the Python DLL explicitly
            Runtime.PythonDLL = @"C:\Users\lohma\AppData\Local\Programs\Python\Python311\python311.dll"; // Update with your Python path
            //Runtime.PythonDLL = @"C:\Users\GNHZW\AppData\Local\Programs\Python\Python311\python311.dll";
            try
            {
                // Initialize Python
                PythonEngine.Initialize();

                using (Py.GIL()) // Acquire the Global Interpreter Lock
                {
                    PythonEngine.Initialize();

                    using (Py.GIL())
                    {
                        // Add the dynamically found 'AI' folder to Python's sys.path
                        dynamic sys = Py.Import("sys");
                        sys.path.append(aiFolderPath);

                        // Import the Python file
                        dynamic predictor = Py.Import("DelayPredictor");

                        // Call the Python function
                        dynamic result = predictor.predict_delays(delayOne, delayTwo);

                        // Display the result
                        Console.WriteLine("Predicted Delays:");

                        this.Invoke((Action)(() =>
                        {
                            string s = "";
                            foreach (var item in result)
                            {
                                Console.WriteLine($"{item}: {result[item]} Minutes");
                                s += $"{item}: {(int)result[item]} Minutes\n";

                                string itemString = item.ToString();
                                if (itemString.Equals("Verspätung Duckterath"))
                                {
                                    this.delayLabel.Text = ""+ s;
                                }
                            }
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                PythonEngine.Shutdown();
            }
        }
    }
}
