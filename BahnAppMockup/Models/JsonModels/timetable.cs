using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BahnAppMockup.Models.JsonModels
{
    public class timetable
    {
        public Journey journeys{ get; set; }

    }
    public class Journey
    {
        public string destination { get; set; }
        public int KoelnHbf { get; set; }
        public int KoelnMesseDeutz { get; set; }
        public int KoelnBuchforst { get; set; }
        public int KoelnMuelheim { get; set; }
        public int KoelnHolweide { get; set; }
        public int KoelnDellbrueck { get; set; }
        public int Duckterath { get; set; }

    }
}
