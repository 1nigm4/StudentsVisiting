using StudentsVisiting.Views.Windows;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudentsVisiting.Views.Pages
{
    public partial class IdlesPage : Page
    {
        public IdlesPage()
        {
            InitializeComponent();
            Groups.ItemsSource = App.Database.Groups.Local.ToBindingList();
            Subjects.ItemsSource = App.Database.Subjects.Local.ToBindingList();
        }

        private void AddAction_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button) return;
            bool isAddGroup = button.Name == "AddGroup";
            Window window = new AddAction(isAddGroup);
            window.ShowDialog();
            Groups_OnSelectionChanged(null, null);
        }

        private void Subjects_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Groups.SelectedItem == null) return;
            this.Students.Items.Refresh();
            this.Students.SelectedItem = null;
        }

        private void Groups_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Subjects.SelectedItem == null) return;
            this.Students.ItemsSource = App.Database.Students.Local.Where(s => s.Group == Groups.SelectedItem);
            this.Students.Items.Refresh();
            this.Students.SelectedItem = null;
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(Students.SelectedItem is Student student)) return;
            if (!(Subjects.SelectedItem is Subject subject)) return;

            Window window = new EditAction(student, subject);
            window.ShowDialog();
            Groups_OnSelectionChanged(null, null);
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(Students.SelectedItem is Student student)) return;

            App.Database.Students.Local.Remove(student);
            Groups_OnSelectionChanged(null, null);
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите сохранить изменения?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                App.Database.SaveChanges();
        }
    }
}