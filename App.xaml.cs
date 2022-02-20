using System.Data.Entity;
using System.Windows;

namespace StudentsVisiting
{
    public partial class App : Application
    {
        public static Database Database;
        public App()
        {
            Database = new Database();
            Database.Students.Load();
            Database.Groups.Load();
            Database.Subjects.Load();
            Database.Idles.Load();
        }
    }
}
