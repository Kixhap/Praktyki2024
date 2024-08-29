using ClassLibrary.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var itemViewModel = new ItemViewModel();

            var loginWindow = new LoginWindow(itemViewModel);
            loginWindow.Show();
        }
    }

}
