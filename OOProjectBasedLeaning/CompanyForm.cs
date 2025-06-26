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

            company = new CompanyModel("MyCompany");

            // TODO: タイムレコーダーのパネルを設置する
            TimeTracker tt = new TimeTrackerModel(company);
            Controls.Add(new TimeTrackerPanel(tt)
            {
                Location = new Point(480,20 + Controls.Count * 30),
                Width = 300,
                Height = 200,
                BackColor = Color.Blue,
            });

            employeeNamesLabel = new Label
            {

                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Arial", 15, FontStyle.Regular),

            };
            Controls.Add(employeeNamesLabel);
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
    }



}
