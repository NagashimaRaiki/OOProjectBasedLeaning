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

            //退勤のLabelを作成
            Label ClockOutlabel = new Label 
            {
                Location = new Point(480, 20 + Controls.Count * 30),
                Width = 300,
                Height = 200,
                BackColor = Color.LightSalmon,
                ForeColor = Color.White,
                Text = "退勤",
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            //TimeTrackerのLabelを作成
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
            //Labelの作成
            employeeNamesLabel = new Label
            {

                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Regular),

            };

            //Formにコントロールを追加
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
                //操作したパネルをemployeePanelに定義
                EmployeePanel employeePanel = (EmployeePanel)serializableObject;
                //EmployyePanelからemPloyeeを取得
                Employee employee = employeePanel.returnEmp();
                //Addemployeeの呼び出し
                AddEmployee(employee);
                if (!company.IsAtWork(employee) & employee.ReturnWorkMode() == "出勤中")
                {

                    employee.ClockOut();
                    employeePanel.AddForm(this);

                }
                else if(employee.ReturnWorkMode() == "---")
                {
                    MessageBox.Show($"{employee.Name}はまだ会社に登録されていません。");
                }
                else
                {
                    MessageBox.Show($"{employee.Name}は既に退勤中です。");
                }
            }

        }
        private void AddEmployee(Employee employee)
        {
            if(!employeelist.Contains(employee))
            {
                //重複なし
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
