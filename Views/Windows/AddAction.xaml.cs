using System.Linq;
using System.Windows;

namespace StudentsVisiting.Views.Windows
{
    public partial class AddAction : Window
    {
        public AddAction(bool isAddGroup)
        {
            InitializeComponent();
            Group.Visibility = isAddGroup ? Visibility.Visible : Visibility.Hidden;
            Groups.ItemsSource = App.Database.Groups.Local.ToList();
            AddButton.Click += isAddGroup ? AddGroup_OnClick : AddStudent_OnClick;
        }

        private void AddStudent_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastName.Text) ||
                string.IsNullOrWhiteSpace(Name.Text) ||
                string.IsNullOrWhiteSpace(Patronymic.Text) ||
                Groups.SelectedItem is not Group group)
            {
                MessageBox.Show("Необходимо заполнить все поля", "Добавление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Student student = new Student()
            {
                LastName = LastName.Text,
                Name = Name.Text,
                Patronymic = Patronymic.Text,
                Group = group
            };

            App.Database.Students.Local.Add(student);
            MessageBox.Show("Студент успешно добавлена", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddGroup_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GroupName.Text))
            {
                MessageBox.Show("Необходимо заполнить все поля", "Добавление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Group group = new Group()
            {
                Name = GroupName.Text
            };

            App.Database.Groups.Local.Add(group);
            MessageBox.Show("Группа успешно добавлена", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e) => this.Close();
    }
}
