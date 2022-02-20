using StudentsVisiting.Views.Windows;
using System.Windows;
using System.Windows.Controls;

namespace StudentsVisiting.Views.Pages
{
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Auth_OnClick(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "admin" && Pass.Password == "admin")
                MainWindow.Navigate(new IdlesPage());
            else
                MessageBox.Show("Неверный логин или пароль!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
