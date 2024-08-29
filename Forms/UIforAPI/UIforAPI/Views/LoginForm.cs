using ClassLibrary.ViewModels;

namespace UIforAPI
{
    public partial class LoginForm : Form
    {
        private readonly ItemViewModel _itemViewModel;

        public LoginForm(ItemViewModel itemViewModel)
        {
            InitializeComponent();
            _itemViewModel = itemViewModel;
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            _itemViewModel.SetCredentials(username, password);

            bool isValid = await _itemViewModel.ValidateCredentialsAsync();

            if (isValid)
            {
                var mainForm = new MainForm(_itemViewModel);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

