using BahnAppMockup.Components;
using BahnAppMockup.Logic;
using BahnAppMockup.Models.JsonModels;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BahnAppMockup.Forms
{
    public partial class SingleConnection : Form
    {
        DateTime predictedArrival = DateTime.Now;
        private static SingleConnection instance;

        public static SingleConnection GetInstance()
        {
            if(instance == null) instance = new SingleConnection();

            return instance;
        }
        public SingleConnection()
        {
            InitializeComponent();
        }
        public SingleConnection(ConnectionPanel cp)
        {
            InitializeComponent();

            foreach(string key in cp.actual.Keys)
            {
                Debug.WriteLine(key);
            }
            DateTime aimedDeparture = cp.schedule["Köln Hbf"];
            DateTime aimedArrival = cp.schedule["Bergisch Gladbach Duckterath (S)"];
            DateTime predictedDeparture = cp.actual["Köln Hbf"];
            predictedArrival = cp.actual["Bergisch Gladbach Duckterath (S)"];
            



            aimedDepartureLabel.Text = Logic.Tools.ConvertDateTimeToString(aimedDeparture);
            aimedArrivalLabel.Text = Logic.Tools.ConvertDateTimeToString(aimedArrival);
            departureLabel.Text = Logic.Tools.ConvertDateTimeToString(predictedDeparture);
            arrivalLabel.Text = Logic.Tools.ConvertDateTimeToString(predictedArrival);
            aiPredictedDepartureLabel.Text = Logic.Tools.ConvertDateTimeToString(predictedDeparture);
            predictTimes(cp.schedule, cp.actual).ConfigureAwait(false);
        }

        private async Task predictTimes(Dictionary<string, DateTime> schedule, Dictionary<string, DateTime> actual)
        {
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
            }
            // Set the Python DLL explicitly
            Runtime.PythonDLL = @"C:\Users\lohma\AppData\Local\Programs\Python\Python311\python311.dll"; // Update with your Python path
            //Runtime.PythonDLL = @"C:\Users\GNHZW\AppData\Local\Programs\Python\Python311\python311.dll";


            string basePath = AppDomain.CurrentDomain.BaseDirectory; // bin\Debug or bin\Release
            string solutionPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
            string aiFolderPath = Path.Combine(solutionPath, "AI");

            DateTime mainStationPlanned = schedule["Köln Hbf"];
            DateTime mainStationActual = actual["Köln Hbf"];
            DateTime buchforstPlanned = schedule["Köln Buchforst S-Bahn"];
            DateTime buchforstActual = actual["Köln Buchforst S-Bahn"];

            int mainStationDelay = Logic.Tools.GetTimeDifference(mainStationPlanned, mainStationActual);
            int buchforstDelay = Logic.Tools.GetTimeDifference(buchforstPlanned, buchforstActual);

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
                        dynamic result = predictor.predict_delays(mainStationDelay, buchforstDelay);

                        // Display the result
                        Console.WriteLine("Predicted Delays:");

                        this.Invoke((Action)(() =>
                        {
                            foreach (var item in result)
                            {
                                Console.WriteLine($"{item}: {result[item]} Minutes");

                                string itemString = item.ToString();
                                if (itemString.Equals("Verspätung Köln Dellbrück"))
                                {
                                    this.aiPredictedArrivalLabel.Text = Logic.Tools.ConvertDateTimeToString(predictedArrival.AddMinutes((double)result[item]));
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

        private void button1_Click(object sender, EventArgs e)
        {
            Main.GetInstance().ChangeDisplayedForm(Booking.GetInstance());
        }
    }
}
