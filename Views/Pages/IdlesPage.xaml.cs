using StudentsVisiting.Views.Windows;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace StudentsVisiting.Views.Pages
{
    public partial class IdlesPage : Page
    {
        CollectionViewSource StudentsCollection;
        public IdlesPage()
        {
            InitializeComponent();
            StudentsCollection = (CollectionViewSource)FindResource("StudentsViewSource");
            StudentsCollection.Source = App.Database.Students.Local.ToList();
            Groups.ItemsSource = App.Database.Groups.Local.ToBindingList();
            Subjects.ItemsSource = App.Database.Subjects.Local.ToBindingList();
        }

        private void StudentsCollection_OnFilter(object sender, FilterEventArgs e)
        {
            e.Accepted = false;
            if (e.Item is not Student student) return;
            if (Groups.SelectedItem is not Group selectedGroup) return;
            if (Subjects.SelectedItem is not Subject selectedSubject) return;

            if (student.Group != selectedGroup) return;
            if (!student.ToString().Contains(Search.Text)) return;
            e.Accepted = true;
        }

        private void Filter_OnChanged(object sender, EventArgs e) =>
            StudentsCollection.View.Refresh();

        private void AddAction_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button) return;
            bool isAddGroup = button.Name == "AddGroup";
            Window window = new AddAction(isAddGroup);
            window.ShowDialog();
            StudentsCollection.Source = App.Database.Students.Local.ToList();
            StudentsCollection.View.Refresh();
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(Students.SelectedItem is Student student)) return;
            if (!(Subjects.SelectedItem is Subject subject)) return;
            Window window = new EditAction(student, subject);
            window.ShowDialog();
            StudentsCollection.View.Refresh();
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(Students.SelectedItem is Student student)) return;
            App.Database.Students.Local.Remove(student);
            StudentsCollection.View.Refresh();
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите сохранить изменения?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                App.Database.SaveChanges();
        }
    }
}