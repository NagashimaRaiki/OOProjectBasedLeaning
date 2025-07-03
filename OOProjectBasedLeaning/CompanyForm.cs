using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOProjectBasedLeaning
{

    public partial class CompanyForm : DragDropForm
    {

        private Company company = NullCompany.Instance;
        private Label employeeNamesLabel;

        public CompanyForm()
        {

            InitializeComponent();
            //CompanyModelの作成
            company = new CompanyModel("MyCompany");

            //TimeTrackerの作成
            TimeTracker tt = new TimeTrackerModel(company);
            //ControlsにTimeTrackerPanelの追加
            Controls.Add(new TimeTrackerPanel(tt)
            {
                Location = new Point(480,20 + Controls.Count * 30),
                Width = 300,
                Height = 200,
                BackColor = Color.Blue,
            });

            //Labelの作成
            employeeNamesLabel = new Label
            {

                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Regular),

            };
            //ControlsにLabelを追加
            Controls.Add(employeeNamesLabel);

            UpdateDisplay();
        }

        protected override void OnFormDragEnterSerializable(DragEventArgs dragEventArgs)
        {

            dragEventArgs.Effect = DragDropEffects.Move;

        }

        protected override void OnFormDragDropSerializable(object? serializableObject, DragEventArgs dragEventArgs)
        {

            if (serializableObject is DragDropPanel)
            {

                (serializableObject as DragDropPanel).AddDragDropForm(this, PointToClient(new Point(dragEventArgs.X, dragEventArgs.Y)));
                EmployeePanel employeePanel = (EmployeePanel)serializableObject;
                Employee employee = employeePanel.returnEmp();
                CompanyAddEmp(employee);
            }

        }

        private void UpdateDisplay()
        {

            StringBuilder employeeNames = new StringBuilder();
            company.Employees().ForEach(employee =>
            {

                employeeNames.Append(employee.Name);
                employeeNames.Append("\n");

            });

            employeeNamesLabel.Text = employeeNames.ToString();

        }
        private void CompanyAddEmp(Employee employee)
        {
            Employee findEmp = company.FindEmployeeById(employee.Id);
            if (findEmp != employee)
            {
                company.AddEmployee(employee);
            }
            UpdateDisplay();
        }
    }

}
