using System.Text;

namespace OOProjectBasedLeaning
{

    public partial class HomeForm : DragDropForm
    {
        private List<Employee> employeelist = new List<Employee>();
        private Label employeeNamesLabel = new Label();
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
                Employee employee = employeePanel.returnEmp();
                ////CompanyAddempの呼び出し
                CompanyAddEmp(employee);
                employeePanel.AddForm(this);
            }

        }
        private void CompanyAddEmp(Employee employee)
        {
           //名前がすでにあるか重複チェック
           if(employeelist.Any(e => e.Name == employee.Name))
           {
                return;
           }
           //重複なし
           employeelist.Add(employee);
           UpdateEmployeeNamesLabel();
        }

        private void UpdateEmployeeNamesLabel()
        {
            employeeNamesLabel.Text = string.Join("\n",employeelist.Select(e => e.Name));
        }

    }

}
