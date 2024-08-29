using ClassLibrary.ViewModels;
using System.Windows;

namespace WpfUI
{
    public partial class LoginWindow : Window
    {
        private readonly ItemViewModel _itemViewModel;

        public LoginWindow()
        {
            InitializeComponent();
        }

        public LoginWindow(ItemViewModel itemViewModel) : this()
        {
            _itemViewModel = itemViewModel ?? throw new ArgumentNullException(nameof(itemViewModel));
            this.DataContext = _itemViewModel;
        }
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            _itemViewModel.SetCredentials(username, password);

            try
            {
                await _itemViewModel.LoadItemsAsync();

                MainWindow mainWindow = new MainWindow(_itemViewModel);
                mainWindow.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
