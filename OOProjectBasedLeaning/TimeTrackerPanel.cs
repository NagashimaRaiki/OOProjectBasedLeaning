﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProjectBasedLeaning
{

    public class TimeTrackerPanel : Panel, Observer
    {
        RecordModeTouchableLabel touchableLabel = new RecordModeTouchableLabel();
        private TimeTracker timeTracker = NullTimeTracker.Instance;

        public TimeTrackerPanel()
        {

            InitializeComponent();

        }


        public TimeTrackerPanel(TimeTracker timeTracker)
        {

            this.timeTracker = timeTracker;

            InitializeComponent();

        }

        private void InitializeComponent()
        {

            // Initialize UI components for the Time Tracker panel
            // This could include buttons for PunchIn, PunchOut, and displaying status


            Label titleLabel = new Label
            {
                Text = "Time Tracker",
                Font = new Font("Arial", 16, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(titleLabel);

            touchableLabel.AddObserver(this);
            Controls.Add(touchableLabel);

        }

        // Methods to handle user interactions like PunchIn, PunchOut, etc.
        public void Update(object sender)
        {
            if (touchableLabel.IsClockOutMode())
            {
                MessageBox.Show("a", "a");//テスト用

                //timeTracker.PunchIn(10001);
            }
            else
            {
                MessageBox.Show("b", "b");//テスト用

                //timeTracker.PunchOut(10001);
            }

        }
    }
}