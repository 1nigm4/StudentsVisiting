using System.Windows;
using System.Windows.Controls;

namespace StudentsVisiting.Views.Windows
{
    public partial class MainWindow : Window
    {
        static Frame Navigation;
        public MainWindow()
        {
            InitializeComponent();
            Navigation = Nav;
        }

        public static void Navigate(Page page) => Navigation.Navigate(page);
    }
}
