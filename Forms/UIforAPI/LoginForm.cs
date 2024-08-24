using System;
using System.Windows.Forms;
using WindowsFormsApp.ViewModels;

namespace UIforAPi
{
    public partial class LoginForm : Form
    {
        private readonly ItemViewModel _viewModel;

        public LoginForm(ItemViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            // Set credentials in the ViewModel
            _viewModel.SetCredentials(username, password);

            // Close the login form and open the main form
            this.Hide();
            MainForm mainForm = new MainForm(_viewModel);
            mainForm.ShowDialog();
            this.Close();
        }
    }
}
