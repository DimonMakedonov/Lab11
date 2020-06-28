using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>    
    public partial class App : Application
    {

        public static Model.EFContext _db = new Model.EFContext("Database1");
        public Model.EFContext db
        {
            get { return _db; }
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            foreach (var student in db.Students)
            {
                Debug.WriteLine($"{student.Name}, {student.Group.Track}-{student.Group.Course}{student.Group.Number}");
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Debug.WriteLine($"ExitCode ={e.ApplicationExitCode}");
            db.SaveChanges();
            base.OnExit(e);
        }
    }
}
