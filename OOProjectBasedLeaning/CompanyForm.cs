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

        public CompanyForm()
        {

            InitializeComponent();

            company = new CompanyModel("MyCompany");

            // TODO: タイムレコーダーのパネルを設置する
            TimeTracker tt = new TimeTrackerModel(company);
            Controls.Add(new TimeTrackerPanel(tt)
            {
                Location = new Point(0,20 + Controls.Count * 30),
                Width = 800,
                BackColor = Color.Blue,
            });
            this.Controls.Add(new Label { Text = "タイムレコーダー", Location = new System.Drawing.Point(0, 0)});
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

    }



}
