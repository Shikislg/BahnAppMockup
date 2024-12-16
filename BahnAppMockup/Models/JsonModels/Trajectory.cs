using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BahnAppMockup.Models.JsonModels
{
    public class Trajectory
    {
        public Feature[] features { get; set; }
    }
    public class Feature
    {
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public string train_id { get; set; }
        public Line line { get; set; }
    }
    public class Line
    {
        public string name { get; set; }
        public int id { get; set; }
    }
}
