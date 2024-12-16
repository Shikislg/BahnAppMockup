using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BahnAppMockup.Models.JsonModels
{
    public class TrainInformation
    {
        public string shortName {  get; set; }
        public string longName { get; set; }

        public string id { get; set; }

        public string destination { get; set; }
        public Station[] stations { get; set; }
    }
    public class Station
    {
        public string arrivalTime { get; set; }
        public string aimedArrivalTime { get; set; }

        public string departureTime { get; set; }
        public string aimedDepartureTime { get; set; }

        public string stationName { get; set; }
    }
}
