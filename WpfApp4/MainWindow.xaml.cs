using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.Entity;
using System.Windows.Documents;
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var db = (Application.Current as App).db;
            db.Students.Load();
            db.Groups.Load();


            var studentViewSource = ((CollectionViewSource)(this.FindResource("studentViewSource")));
            studentViewSource.Source = db.Students.Local;

            var groupViewSource = ((CollectionViewSource)(this.FindResource("groupViewSource")));
            groupViewSource.Source = db.Groups.Local;

        }

        private void StudentsFilter(object sender, FilterEventArgs e)
        {
            var student = e.Item as Model.Student;
            var group = groupSelectList.SelectedItem as Model.Group;
            if (group != null)
                e.Accepted = student.GroupId == group.Id;
            else
                e.Accepted = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = (Application.Current as App).db;
            var studentViewSource = ((CollectionViewSource)(this.FindResource("studentViewSource")));
            studentViewSource.Source = db.Students.Local;
            var dialog = new NewStudent();
            if (dialog.ShowDialog() == true)
            {
                db.Students.Add(dialog.FindResource("NewStudent") as Model.Student);
            }
            studentViewSource.Filter -= StudentsFilter;
            studentViewSource.Filter += StudentsFilter;
        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {
            var db = (Application.Current as App).db;
            var groupViewSource = ((CollectionViewSource)(this.FindResource("groupViewSource")));
            groupViewSource.Source = db.Groups.Local;
            var dialog = new NewGroup();
            if (dialog.ShowDialog() == true)
            {
                var newGroup = new Model.Group();
                var rand = new Random();
                newGroup = dialog.FindResource("NewGroup") as Model.Group;
                newGroup.Id = rand.Next(1000000);
                db.Groups.Add(newGroup);
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var db = (Application.Current as App).db;
            if (db.ChangeTracker.HasChanges())
            {
                var dialog = MessageBox.Show($"Save changes?", "Exit", MessageBoxButton.OKCancel);
                if (dialog == MessageBoxResult.OK)
                db.SaveChanges();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var db = (Application.Current as App).db;
            
            db.Students.Remove(listBox.SelectedItem as Model.Student);
            
        }

        private void RemoveGroupButton_Click(object sender, RoutedEventArgs e)
        {
            var db = (Application.Current as App).db;
            db.Groups.Remove(groupSelectList.SelectedItem as Model.Group);

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var studentViewSource = ((CollectionViewSource)(this.FindResource("studentViewSource")));
            studentViewSource.Filter -= StudentsFilter;
            studentViewSource.Filter += StudentsFilter;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var studentViewSource = ((CollectionViewSource)(this.FindResource("studentViewSource")));
            var studentsCollection = studentViewSource.Source as ObservableCollection<Model.Student>;

            var currentGroup = groupSelectList.SelectedItem as Model.Group;

            var data = from student in studentsCollection
                       where student.Group == currentGroup
                       select student;

            var export = new XLSExportProvider(data);

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel|*.xlsx";
            saveDialog.AddExtension = true;
            if (saveDialog.ShowDialog() == true)
            {
                var fileName = saveDialog.FileName;
                if (fileName.IndexOf("xls") == -1)
                    fileName += ".xlsx";
                export.ExportTo(saveDialog.FileName);
            }
        }
    }
}
