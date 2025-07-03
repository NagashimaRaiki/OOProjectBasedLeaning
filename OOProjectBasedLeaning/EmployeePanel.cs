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
            //移動先がCompanyFormだったら
            if (form is CompanyForm)
            {
                //ステータスラベルを[出勤中]に変更
                employeeStatusLabel.Text = "[出勤中]";
                //背景をLightGreenに変更
                this.BackColor = Color.LightGreen;
            }
            //移動先がHomeFormだったら
            else if (form is HomeForm)
            {
                //ステータスラベルを[退勤中]に変更
                employeeStatusLabel.Text = "[退勤中]";
                //背景をLightSalmonに変更
                this.BackColor = Color.LightSalmon;
            }
        }



        protected override void OnPanelMouseDown()
        {
            DoDragDropMove();
        }
    }
}
