using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Windows.Forms;
using UIforAPI.ViewModels;
using UIforAPI;

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

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // Set credentials in the ViewModel
            _itemViewModel.SetCredentials(username, password);

            // Open the main form after successful login
            var mainForm = new MainForm(_itemViewModel);
            mainForm.Show();
            this.Hide();  // Hide the login form
        }
    }
}

