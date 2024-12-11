using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace BahnAppMockup.Logic
{
    internal class TrainScheduler
    {
        static int[] departureTimes = new int[] { 6, 26, 46 };
        static int[][] baseSchedule = new int[][] { new int[]{ 6, 9, 12, 15, 18, 21, 24 }, new int[] { 26, 29, 32, 35, 38, 41, 44 }, new int[] { 46, 49, 52, 55, 58, 1, 4 } };


        //Ill keep it simple here for now, this will have to be redone in the future to add more features

        public static int[] GetTrainSchedule(DateTime requestTime)
        {
            int index = FindClosestIndex(requestTime);

            int[] schedule = baseSchedule[index];

            return schedule;
        }

        private static int FindClosestIndex(DateTime time)
        {

            if (time.Minute < departureTimes[0] || time.Minute > departureTimes[2]) return 0;
            else if (time.Minute < departureTimes[1]) return 1;
            else return 2;
        }
    }
}
