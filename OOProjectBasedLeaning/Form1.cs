namespace OOProjectBasedLeaning
{

    public partial class Form1 : DragDropForm
    {

        public Form1()
        {

            InitializeComponent();

            // �]�ƈ��̍쐬
            new EmployeeCreatorForm().Show();

            // ��
            new HomeForm().Show();

            // ���
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
