using System;
using System.Windows.Forms;
using UIforAPI.ViewModels;

namespace UIforAPI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create the ViewModel
            var itemViewModel = new ItemViewModel();

            // Start with the LoginForm
            Application.Run(new LoginForm(itemViewModel));
        }
    }
}