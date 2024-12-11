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
    public partial class Main : Form
    {
        private static Main INSTANCE = null;


        public static Main GetInstance()
        {
            if (INSTANCE == null) INSTANCE = new Main();

            return INSTANCE;
        }

        public Main()
        {
            InitializeComponent();
            ChangeDisplayedForm(new Booking());
        }

        public void ChangeDisplayedForm(Form form)
        {

            //Set up form to work as child of a panel
            form.TopLevel = false;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            //Add Form as child of the panel
            FormPanel.Controls.Clear();
            FormPanel.Controls.Add(form);
            form.Show();
        }

        public void ChangeDisplayedMiniForm(Form form)
        {
            //Set up form to work as child of a panel
            form.TopLevel = false;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            //Add Form as child of the panel
            MiniPanel.Controls.Clear();
            MiniPanel.Controls.Add(form);
            form.Show();
            MiniPanel.Show();

            //Adjust Main Panel
            FormPanel.Size = new System.Drawing.Size(FormPanel.Width-50, FormPanel.Height);
            FormPanel.Location = new System.Drawing.Point(FormPanel.Location.X + 25, FormPanel.Location.Y + 10);
        }

        public void ClearMiniPanel()
        {
            MiniPanel.Controls.Clear();

            FormPanel.Size = new System.Drawing.Size(FormPanel.Width + 50, FormPanel.Height);
            FormPanel.Location = new System.Drawing.Point(0,0);

            MiniPanel.Hide();
        }

    }
}
