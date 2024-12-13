using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BahnAppMockup.Design
{
    public class DesignProperties
    {
        public static Color backgroundColor = Color.FromArgb(41, 45, 56);
        public static Color darkBackgroundColor = Color.FromArgb(20, 24, 33);
        public static Color darkButtonColor = Color.FromArgb(20,24,33);
        public static Color lightButtonColor = Color.FromArgb(98, 105, 115);
        public static Color redAccent = Color.FromArgb(252, 142, 143);

        public static Font buttonFont = new System.Drawing.Font("DB Neo Office Cond", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        public static Font connectionPanelFont = new System.Drawing.Font("DB Neo Office Cond", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        public static Font textBoxFont = new System.Drawing.Font("DB Neo Office Cond", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);

    }
}
