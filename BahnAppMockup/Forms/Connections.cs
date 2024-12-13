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

namespace BahnAppMockup
{
    public partial class Connections : Form
    {
        public Connections()
        {
            int[] schedule = TrainScheduler.GetTrainSchedule(DateTime.Now);

            int plannedStart = schedule[0];
            int plannedEnd = schedule[schedule.Length - 1];


            int realStart = plannedStart+5;
            int realEnd = plannedEnd+5;

            string[] plannedTimes = Tools.ConvertPlannedTimes(plannedStart, plannedEnd);
            string[] realTimes = Tools.ConvertPlannedTimes(realStart, realEnd);

            ConnectionPanel cp = new ConnectionPanel(new Point(10, 50), new string[] { realTimes[0], realTimes[1] }, new string[] { plannedTimes[0], plannedTimes[1] }
            , "Köln Hbf",Tools.GetTimeDifference(plannedStart,plannedEnd), "S11");

            this.Controls.Add(cp.GetMainPanel());
            InitializeComponent();

        }


        private void roundButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mobility.portal.geops.io/de/world.geops.transit?layers=paerke,strassennamen,haltekanten,haltestellen,pois,world.geops.traviclive&x=775031.84&y=6612128.91&z=15.06");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main.GetInstance().ChangeDisplayedForm(Booking.GetInstance());
        }
    }
}
