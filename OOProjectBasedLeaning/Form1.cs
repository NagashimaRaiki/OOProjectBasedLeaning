namespace OOProjectBasedLeaning
{

    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();

            // è]ã∆àıÇÃçÏê¨
            new EmployeeCreatorForm().Show();

            // âÔé–
            CompanyForm companyForm = new CompanyForm();
            companyForm.Show();

            // â∆
            new HomeForm(companyForm).Show();

        }

    }

}
