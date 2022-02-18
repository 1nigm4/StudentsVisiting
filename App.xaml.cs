using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsVisiting
{
    public partial class App : Application
    {
        public static DataBase Database;
        public App()
        {
            Database = new DataBase();
            Database.Students.Load();
            Database.Groups.Load();
            Database.Subjects.Load();
            Database.Idles.Load();
        }
    }
}
