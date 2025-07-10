using System.Text;

namespace OOProjectBasedLeaning
{

    public partial class HomeForm : DragDropForm
    {
        private List<Employee> employeelist = new List<Employee>();
        private Label employeeNamesLabel = new Label();
        Company company;
        public HomeForm(CompanyForm companyForm)
        {

            InitializeComponent();

            company = companyForm.company;

            //�ދ΂�Label���쐬
            Label ClockOutlabel = new Label 
            {
                Location = new Point(480, 20 + Controls.Count * 30),
                Width = 300,
                Height = 200,
                BackColor = Color.LightSalmon,
                ForeColor = Color.White,
                Text = "�ދ�",
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            //TimeTracker��Label���쐬
            Label timetrackerlabel = new Label
            {
                Location = new Point(480, 20),
                Width = 300,
                Height = 25,
                BackColor = Color.Blue,
                Text = "TimeTracker",
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.TopCenter
            };
            //Label�̍쐬
            employeeNamesLabel = new Label
            {

                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Regular),

            };

            //Form�ɃR���g���[����ǉ�
            Controls.Add(ClockOutlabel);
            Controls.Add(timetrackerlabel);
            Controls.Add(employeeNamesLabel);
            timetrackerlabel.BringToFront();

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
                //���삵���p�l����employeePanel�ɒ�`
                EmployeePanel employeePanel = (EmployeePanel)serializableObject;
                //EmployyePanel����emPloyee���擾
                Employee employee = employeePanel.returnEmp();
                //Addemployee�̌Ăяo��
                AddEmployee(employee);
                if (!company.IsAtWork(employee) & employee.ReturnWorkMode() == "�o�Β�")
                {

                    employee.ClockOut();
                    employeePanel.AddForm(this);

                }
                else if(employee.ReturnWorkMode() == "---")
                {
                    MessageBox.Show($"{employee.Name}�͂܂���Ђɓo�^����Ă��܂���B");
                }
                else
                {
                    MessageBox.Show($"{employee.Name}�͊��ɑދΒ��ł��B");
                }
            }

        }
        private void AddEmployee(Employee employee)
        {
            if(!employeelist.Contains(employee))
            {
                //�d���Ȃ�
                employeelist.Add(employee);
                UpdateEmployeeNameLabel();
            }
        }
        private void UpdateEmployeeNameLabel()
        {
            employeeNamesLabel.Text = string.Join("\n",employeelist.Select(e => e.Name));
        }
    }

}
