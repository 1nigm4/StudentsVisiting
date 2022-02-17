using StudentsVisiting.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }
    }
}
