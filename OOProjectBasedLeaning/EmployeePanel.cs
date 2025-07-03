using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProjectBasedLeaning
{

    public class EmployeePanel : DragDropPanel
    {
        private Label employeeStatusLabel = new Label()
        {
            Text = "[ーーー]",
            AutoSize = true,
            Location = new Point(115, 38)
        };

        private Employee employee;

        public EmployeePanel(Employee employee)
        {

            this.employee = employee;

            InitializeComponent();

        }

        public Employee returnEmp()
        {
            return employee;
        }

        private void InitializeComponent()
        {

            Label employeeNameLabel = new Label
            {
                Text = employee.Name,
                AutoSize = true,
                Location = new Point(20, 10)
            };

            TextBox guestNameTextBox = new TextBox
            {
                Text = employee.Name,
                Location = new Point(140, 6),
                Width = 160
            };

            Controls.Add(employeeNameLabel);
            Controls.Add(employeeStatusLabel);
            Controls.Add(guestNameTextBox);

        }

        protected override void _AddForm(Form form)
        {
            if (form is CompanyForm)
            {
                employeeStatusLabel.Text = "[出勤中]";
            }
            else if (form is HomeForm)
            {
                employeeStatusLabel.Text = "[退勤中]";
            }
        }



        protected override void OnPanelMouseDown()
        {
            DoDragDropMove();
        }
    }
}
