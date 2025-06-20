namespace OOProjectBasedLeaning
{

    public partial class Form1 : DragDropForm
    {

        public Form1()
        {

            InitializeComponent();

            // 従業員の作成
            new EmployeeCreatorForm().Show();

            // 家
            new HomeForm().Show();

            // 会社
            new CompanyForm().Show();

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
