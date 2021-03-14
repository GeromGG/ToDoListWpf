using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoListWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Loaded += MainWindow_Loaded;
        }


        //private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var selected = listProjects.SelectedItem;
        //    var project = (Project)selected;
        //    if (project != null)
        //    {
        //        foreach (var task in project.Tasks)
        //        {
        //            tasksView.Items.Add(task);
        //        }
        //    }
        //}

        Projects projects = new();

        private void AddProjects_Click(object sender, RoutedEventArgs e)
        {
            WindowAddNewProject windowAddNewProject = new();
            if (windowAddNewProject.ShowDialog() == true)
            {
                var nameInTextBox = windowAddNewProject.NameInTextBox;
                var i = projects.AddProject(nameInTextBox);
                listProjects.Items.Add(projects.ListProjects[i]);
            }
        }

        private void DelProjects_Click(object sender, RoutedEventArgs e)
        {
            var selected = listProjects.SelectedItem;

            if (selected is null)
            {
                return;
            }

            listProjects.Items.Remove(selected);
            projects.DeleteProject((Project)selected);
        }
    }
}
