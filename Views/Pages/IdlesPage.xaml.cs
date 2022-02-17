using StudentsVisiting.Views.Windows;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;

namespace StudentsVisiting.Views.Pages
{
    public partial class IdlesPage : Page
    {
        public IdlesPage()
        {
            InitializeComponent();
            Idles.ItemsSource = DataBase.Context.Students.Local.ToBindingList();
        }

        private void AddAction_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button) return;
            bool isAddGroup = button.Name == "AddGroup";
            Window window = new AddAction(isAddGroup);
            window.ShowDialog();
        }
    }
}
