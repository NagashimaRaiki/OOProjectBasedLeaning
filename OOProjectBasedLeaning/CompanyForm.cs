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
                //操作したパネルをemployeePanelに定義
                EmployeePanel employeePanel = (EmployeePanel)serializableObject;
                //EmployyePanelからemPloyeeを取得
                Employee employee = employeePanel.returnEmp();
                //CompanyAddempの呼び出し
                CompanyAddEmp(employee);
                if (!company.IsAtWork(employee))
                {

                    company.ClockIn(employee);
                    employeePanel.AddForm(this);
                    
                }
                else
                {
                    MessageBox.Show($"{employee.Name}は既に出勤中です。");
                }
            }

        }

        private void UpdateDisplay()
        {
            //StringBuilderを作成
            StringBuilder employeeNames = new StringBuilder();
            //companyからすべてのEmployeeを取り出す
            company.Employees().ForEach(employee =>
            {
                //employeeを追加
                employeeNames.Append(employee.Name);
                //改行追加
                employeeNames.Append("\n");

            });
            //ラベルにemployeeNamesを貼り付け
            employeeNamesLabel.Text = employeeNames.ToString();

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
            UpdateDisplay();
        }
    }

}
