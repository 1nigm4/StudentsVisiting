using StudentsVisiting.Views.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StudentsVisiting.Views.Converters
{
    class IdlesConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(values[0] is Student student)) return null;
            if (student.Group == null) return null;
            if (!(values[2] is IdlesPage page)) return null;
            if (!(page.Subjects.SelectedItem is Subject subject)) return null;

            BindingList<Idle> idles = App.Database.Idles.Local.ToBindingList();
            Idle idle = student.Idles.FirstOrDefault(i => i.Subject == subject);
            if (idle == null)
            {
                idle = new Idle()
                {
                    Subject = subject,
                    Student = student
                };
                idles.Add(idle);
            }

            return idle.Count.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
