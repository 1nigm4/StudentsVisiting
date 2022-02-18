using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace StudentsVisiting.Views.Windows
{
    public partial class EditAction : Window
    {
        private Student student;
        private Subject subject;
        public EditAction(Student student, Subject subject)
        {
            this.student = student;
            this.subject = subject;
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Subject.Content = $"Предмет: {subject}";
            IdleCount.Text = subject.Idles.First(i => i.Student == student).Count.ToString();
            LastName.Text = student.LastName;
            Name.Text = student.Name;
            Patronymic.Text = student.Patronymic;
            Groups.ItemsSource = App.Database.Groups.Local.ToBindingList();
            Groups.SelectedItem = student.Group;
        }

        private void EditStudent_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdleCount.Text) ||
                string.IsNullOrWhiteSpace(LastName.Text) ||
                string.IsNullOrWhiteSpace(Name.Text) ||
                string.IsNullOrWhiteSpace(Patronymic.Text) ||
                Groups.SelectedItem == null)
            {
                MessageBox.Show("Необходимо заполнить все поля", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            student.LastName = LastName.Text;
            student.Name = Name.Text;
            student.Patronymic = Patronymic.Text;
            student.Group = Groups.SelectedItem as Group;
            student.Idles.First(i => i.Subject == subject).Count = int.Parse(IdleCount.Text);

            MessageBox.Show("Студент успешно обновлён", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e) => this.Close();
    }
}
