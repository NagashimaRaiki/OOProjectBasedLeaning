using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProjectBasedLeaning
{

    public class TimeTrackerPanel : Panel
    {

        private TimeTracker timeTracker = NullTimeTracker.Instance;
        
        public TimeTrackerPanel(TimeTracker timeTracker)
        {

            this.timeTracker = timeTracker;

            InitializeComponent();

        }

        private void InitializeComponent()
        {

            RecordModeTouchableLabel touchableLabel = new RecordModeTouchableLabel(timeTracker);
            Controls.Add(touchableLabel);

        }

    }

}
