using BahnAppMockup.Components;
using BahnAppMockup.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Python.Runtime;
using System.IO;

namespace BahnAppMockup
{
    public partial class Connections : Form
    {
        ConnectionPanel cp;
        public Connections()
        {
            InitializeControlPanel("Köln Hbf", "Bergisch Gladbach Duckterath (S)").ConfigureAwait(false);
            InitializeComponent();
            AdjustPanelSizes();


        }

        private async Task InitializeControlPanel(string departureStation, string arrivalStation)
        {
            Debug.WriteLine("test");
            Dictionary<string, DateTime> schedule = await TrainScheduler.GetTrainSchedule(DateTime.Now).ConfigureAwait(false);
            Dictionary<string, DateTime> actual = await TrainScheduler.GetDelays(DateTime.Now).ConfigureAwait(false);



            DateTime plannedDepartureTime = schedule[departureStation];
            DateTime plannedArrivalTime = schedule[arrivalStation];
            DateTime departureTime = actual[departureStation];
            DateTime arrivalTime = actual[arrivalStation];

            string plannedDepartureString = Tools.ConvertDateTimeToString(plannedDepartureTime);
            string plannedArrivalString = Tools.ConvertDateTimeToString(plannedArrivalTime);

            string actualDepartureString = Tools.ConvertDateTimeToString(departureTime);
            string actualArrivalString = Tools.ConvertDateTimeToString(arrivalTime);

            this.Invoke((Action)(() =>
            {
                cp = new ConnectionPanel(new Point(0, 0), new string[] { actualDepartureString, actualArrivalString },
                    new string[] { plannedDepartureString, plannedArrivalString },
                    "Köln Hbf", Tools.GetTimeDifference(departureTime, arrivalTime), "S11", schedule, actual);

                this.flowLayoutPanel1.Controls.Add(cp.GetMainPanel());
            }));

        }


        private void roundButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mobility.portal.geops.io/de/world.geops.transit?layers=paerke,strassennamen,haltekanten,haltestellen,pois,world.geops.traviclive&x=775031.84&y=6612128.91&z=15.06");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main.GetInstance().ChangeDisplayedForm(Booking.GetInstance());
        }
        private void AdjustPanelSizes()
        {
            if (flowLayoutPanel1 == null) return;
            int containerWidth = flowLayoutPanel1.ClientSize.Width; // Get the visible width of the FlowLayoutPanel
            int padding = 10; // Optional padding to leave space on the sides

            foreach (Panel panel in flowLayoutPanel1.Controls)
            {
                panel.Width = containerWidth - padding;
            }
            foreach (Control child in flowLayoutPanel1.Controls)
            {
                child.Margin = new Padding(0,15,0,0); // Set a uniform margin
            }

        }


        public static void PredictDelays()
        {
            // Set the Python DLL explicitly
            //Runtime.PythonDLL = @"C:\Users\lohma\AppData\Local\Programs\Python\Python311\python311.dll"; // Update with your Python path
            Runtime.PythonDLL = @"C:\Users\GNHZW\AppData\Local\Programs\Python\Python311\python311.dll";


            string basePath = AppDomain.CurrentDomain.BaseDirectory; // bin\Debug or bin\Release
            string solutionPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
            string aiFolderPath = Path.Combine(solutionPath, "AI");
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
                        dynamic result = predictor.predict_delays(5, 8);

                        // Display the result
                        Console.WriteLine("Predicted Delays:");
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item}: {result[item]} Minutes");
                        }
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
