namespace OOProjectBasedLeaning
{

    public partial class Form1 : DragDropForm
    {

        public Form1()
        {

            InitializeComponent();

            // è]ã∆àıÇÃçÏê¨
            new EmployeeCreatorForm().Show();

            // â∆
            new HomeForm().Show();

            // âÔé–
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
