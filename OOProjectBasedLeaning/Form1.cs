namespace OOProjectBasedLeaning
{

    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();

            // �]�ƈ��̍쐬
            new EmployeeCreatorForm().Show();

            // ���
            CompanyForm companyForm = new CompanyForm();
            companyForm.Show();

            // ��
            new HomeForm(companyForm).Show();

        }

    }

}
