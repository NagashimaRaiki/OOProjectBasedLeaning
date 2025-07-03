using System.Text;

namespace OOProjectBasedLeaning
{

    public partial class HomeForm : DragDropForm
    {
        private Company company = NullCompany.Instance;
        private Label employeeNamesLabel;
        public HomeForm()
        {

            InitializeComponent();

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
                //Employee employee = employeePanel.returnEmp();
                ////CompanyAddempの呼び出し
                //CompanyAddEmp(employee);
                employeePanel.AddForm(this);
            }

        }
        private void CompanyAddEmp(Employee employee)
        {
            //Employeeがcompanyに加入していないかの確認
            Employee findEmp = company.FindEmployeeById(employee.Id);
            //employeeがcompanyに加入していない時
            if (findEmp != employee)
            {
                //companyにemployeeを加入
                company.AddEmployee(employee);

            }
            //UpdateDisplayを呼び出し
            //UpdateDisplay();
        }

    }

}
