using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BahnAppMockup.Components
{
    public partial class ConnectionPanel : Component
    {
        private Panel MainPanel = new Panel();
        private RoundButton ViewMap = new RoundButton();
        private Label RealTimeLabel = new Label();
        private Label DepartingStationLabel = new Label();
        private Label TravelDurationLabel = new Label();
        private Label PlannedTimeLabel = new Label();
        private Button TrainButton = new Button();

        public ConnectionPanel() : this(new Point(10, 50), new string[] {"21:30","21:43"}, new string[] { "21:25", "21:38" }, "Köln-Mülheim", 13, "S11") {}

        public ConnectionPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public ConnectionPanel(string[] RealTime, string[] PlannedTime, string DepartingStation, int TravelDuration, string TrainName) : this(new Point(0, 0), RealTime, PlannedTime, DepartingStation, TravelDuration, TrainName) {}

        public ConnectionPanel(Point position, string[] RealTime, string[] PlannedTime, string DepartingStation, int TravelDuration, string TrainName)
        {
            InitializeComponent();

            GenerateComponents();

            if (RealTime.Length != 2 || PlannedTime.Length != 2)
            {
                throw new ArgumentException("Unsupported Argument length for Values RealTime or PlannedTime");
            }
            //Adjust all Text
            RealTimeLabel.Text = $"{RealTime[0]}: {RealTime[1]}";
            PlannedTimeLabel.Text = $"{PlannedTime[0]}: {PlannedTime[1]}";

            DepartingStationLabel.Text = "from "+ DepartingStation;
            TravelDurationLabel.Text = "| "+TravelDuration.ToString()+"m";
            TrainButton.Text = TrainName;
            MainPanel.Location = position;
        }

        private void GenerateComponents()
        {
            // 
            // panel1
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.MainPanel.Controls.Add(this.ViewMap);
            this.MainPanel.Controls.Add(this.RealTimeLabel);
            this.MainPanel.Controls.Add(this.DepartingStationLabel);
            this.MainPanel.Controls.Add(this.TrainButton);
            this.MainPanel.Controls.Add(this.TravelDurationLabel);
            this.MainPanel.Controls.Add(this.PlannedTimeLabel);
            this.MainPanel.Location = new System.Drawing.Point(12, 57);
            this.MainPanel.Name = "panel1";
            this.MainPanel.Size = new System.Drawing.Size(362, 125);
            this.MainPanel.TabIndex = 3;
            // 
            // roundButton1
            // 
            this.ViewMap.Location = new System.Drawing.Point(315, 10);
            this.ViewMap.Name = "roundButton1";
            this.ViewMap.Size = new System.Drawing.Size(35, 35);
            this.ViewMap.TabIndex = 5;
            this.ViewMap.UseVisualStyleBackColor = true;
            this.ViewMap.Click += new System.EventHandler(this.MapViewButton_Click);
            // 
            // label5
            // 
            this.RealTimeLabel.AutoSize = true;
            this.RealTimeLabel.Font = Design.DesignProperties.connectionPanelFont;
            this.RealTimeLabel.ForeColor = System.Drawing.Color.Red;
            this.RealTimeLabel.Location = new System.Drawing.Point(5, 28);
            this.RealTimeLabel.Name = "label5";
            this.RealTimeLabel.Size = new System.Drawing.Size(107, 23);
            this.RealTimeLabel.TabIndex = 4;
            this.RealTimeLabel.Text = "20:21-20:33";
            // 
            // label4
            // 
            this.DepartingStationLabel.AutoSize = true;
            this.DepartingStationLabel.Font = Design.DesignProperties.buttonFont;
            this.DepartingStationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.DepartingStationLabel.Location = new System.Drawing.Point(10, 90);
            this.DepartingStationLabel.Name = "label4";
            this.DepartingStationLabel.Size = new System.Drawing.Size(112, 20);
            this.DepartingStationLabel.TabIndex = 3;
            this.DepartingStationLabel.Text = "From Köln Hbf";
            // 
            // button1
            // 
            this.TrainButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TrainButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TrainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TrainButton.Font = Design.DesignProperties.connectionPanelFont;
            this.TrainButton.Location = new System.Drawing.Point(9, 59);
            this.TrainButton.Name = "button1";
            this.TrainButton.Size = new System.Drawing.Size(341, 28);
            this.TrainButton.TabIndex = 2;
            this.TrainButton.Text = "S 11";
            this.TrainButton.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.TravelDurationLabel.AutoSize = true;
            this.TravelDurationLabel.Font = Design.DesignProperties.buttonFont;
            this.TravelDurationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TravelDurationLabel.Location = new System.Drawing.Point(110, 5);
            this.TravelDurationLabel.Name = "label3";
            this.TravelDurationLabel.Size = new System.Drawing.Size(39, 15);
            this.TravelDurationLabel.TabIndex = 1;
            this.TravelDurationLabel.Text = "| 13m";
            // 
            // label1
            // 
            this.PlannedTimeLabel.AutoSize = true;
            this.PlannedTimeLabel.Font = Design.DesignProperties.connectionPanelFont;
            this.PlannedTimeLabel.ForeColor = System.Drawing.Color.White;
            this.PlannedTimeLabel.Location = new System.Drawing.Point(5, 5);
            this.PlannedTimeLabel.Name = "label1";
            this.PlannedTimeLabel.Size = new System.Drawing.Size(107, 23);
            this.PlannedTimeLabel.TabIndex = 0;
            this.PlannedTimeLabel.Text = "20:15-20:28";
        }


        public Panel GetMainPanel()
        {
            return MainPanel;
        }
        private void MapViewButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mobility.portal.geops.io/de/world.geops.transit?layers=paerke,strassennamen,haltekanten,haltestellen,pois,world.geops.traviclive&x=775031.84&y=6612128.91&z=15.06");
        }
    }
}
