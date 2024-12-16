using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace BahnAppMockup.Logic
{
    internal class Tools
    {
        /*
            string plannedDepartureTime = DateTime.Now.Hour + ":" + Tools.PadInteger(plannedStart);
        string plannedArrivalTime = DateTime.Now.Hour + ":" + Tools.PadInteger(plannedEnd);*/

        public static string[] ConvertPlannedTimes (int plannedDeparture, int plannedArrival)
        {
            string[] output = new string[2];

            if(DateTime.Now.Minute > plannedDeparture)
            {
                output[0] = DateTime.Now.Hour+1 + ":" + PadInteger(plannedDeparture);
                output[1] = DateTime.Now.Hour +1 + ":" + PadInteger(plannedArrival);
                return output;
            }
            else
            {
                output[0] = DateTime.Now.Hour + ":" + PadInteger(plannedDeparture);
            }

            if(plannedArrival < plannedDeparture)
            {

                output[1] = DateTime.Now.Hour+1 + ":" + PadInteger(plannedArrival);
            }
            else
            {
                output[1] = DateTime.Now.Hour + ":" + PadInteger(plannedArrival);
            }

            return output;
        }
        public static string PadInteger(int i)
        {
            string s = i.ToString();
            if(s.Length < 2) s = "0"+s;

            return s;
        }
        public static int GetTimeDifference(DateTime departureTime, DateTime arrivalTime)
        {
            Debug.WriteLine("Time Differnce of: "+departureTime.ToString() + arrivalTime.ToString());
            return arrivalTime.Subtract(departureTime).Minutes;
        }

        public static string ConvertDateTimeToString(DateTime dt)
        {
            return dt.Hour+":"+PadInteger(dt.Minute);
        }
    }
}
