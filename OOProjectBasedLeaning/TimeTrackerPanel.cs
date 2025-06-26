using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProjectBasedLeaning
{

    public class TimeTrackerPanel : Panel, Observer
    {

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

            Label titleLabel = new Label
            {
                Text = "Time Tracker",
                Font = new Font("Arial", 16, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(titleLabel);

            TouchableLabel touchableLabel = new RecordModeTouchableLabel();
            touchableLabel.AddObserver(this);
            Controls.Add(touchableLabel);
                
            }

        // Methods to handle user interactions like PunchIn, PunchOut, etc.
        public void Update(object sender)
        {
            if (sender is RecordModeTouchableLabel)
            {
                TouchableLabel touchableLabel = sender as TouchableLabel;
                if(touchableLabel.Text == "退　勤")
                {

                    //timeTracker.PunchIn(10001);
                }
                else
                {

                    //timeTracker.PunchOut(10001);
                }
            }
        }

    }

}
