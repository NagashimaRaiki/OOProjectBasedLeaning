using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProjectBasedLeaning
{
    public abstract class TouchableLabel : Label
    {

        private List<Observer> observers = new List<Observer>();

        public TouchableLabel()
        {

            InitializeComponent();

        }

        private void InitializeComponent()
        {

            Click += touchLabel_Click;

        }

        private void touchLabel_Click(object? sender, EventArgs e)
        {

            OnTouch();

            observers.ForEach(observer =>
            {

                // Notify each observer about the click event
                observer.Update(this);

            });

        }

        protected abstract void OnTouch();

        public void AddObserver(Observer observer)
        {

            observers.Add(observer);

        }

        public void RemoveObserver(Observer observer)
        {

            observers.Remove(observer);

        }

    }

    public class RecordModeTouchableLabel : TouchableLabel
    {

        private RecordMode mode = RecordMode.ClockIn;
        private string clockInText = "出　勤";
        private string clockOutText = "退　勤";

        public RecordModeTouchableLabel()
        {

            InitializeComponent();

        }

        private void InitializeComponent()
        {

            Font = new Font("Arial", 16, FontStyle.Bold);
            Dock = DockStyle.Fill;
            TextAlign = ContentAlignment.MiddleCenter;
            // 起動時は「出勤」状態とする
            ChangeClockInMode();

        }

        public string ClockInText { get { return clockInText; } set { clockInText = value; } }

        public string ClockOutText { get { return clockOutText; } set { clockOutText = value; } }

        public bool IsClockInMode()
        {

            return mode is RecordMode.ClockIn;

        }

        public bool IsClockOutMode()
        {

            return mode is RecordMode.ClockOut;

        }

        protected override void OnTouch()
        {

            if (IsClockInMode())
            {

                ChangeClockOutMode();

            }
            else if (IsClockOutMode())
            {

                ChangeClockInMode();

            }

        }

        public void ChangeClockInMode()
        {

            Text = clockInText;
            ForeColor = Color.White;
            BackColor = Color.SkyBlue;
            mode = RecordMode.ClockIn;

        }

        public void ChangeClockOutMode()
        {

            Text = clockOutText;
            ForeColor = Color.White;
            BackColor = Color.LightSalmon;
            mode = RecordMode.ClockOut;

        }

    }

    public class NullTouchableLabel : TouchableLabel
    {

        private static readonly TouchableLabel instance = new NullTouchableLabel();

        private NullTouchableLabel()
        {

            // Private constructor to prevent instantiation
            Text = "No Action";

        }

        public static TouchableLabel Instance
        {

            get { return instance; }

        }

        protected override void OnTouch()
        {

        }

    }

}