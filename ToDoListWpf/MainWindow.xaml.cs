using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //var selected = listProjects.SelectedItem;
            //var project = (Project)selected;
            //if (project != null)
            //{
            //    foreach (var task in project.Tasks)
            //    {
            //        tasksView.Items.Add(task);
            //    }
            //}
        }

        Projects projects = new();

        private void AddProjects_Click(object sender, RoutedEventArgs e)
        {
            WindowAddNewProject windowAddNewProject = new();
            if (windowAddNewProject.ShowDialog() == true)
            {
                var nameInTextBox = windowAddNewProject.NameInTextBox;
                projects.AddProject(nameInTextBox);
                listProjects.ItemsSource = new ObservableCollection<Project>(projects.ListProjects);
            }
        }

        private void DelProjects_Click(object sender, RoutedEventArgs e)
        {
            var selected = listProjects.SelectedItem;

            if (!(selected is Project project))
            {
                //добавить сообщение
                return;
            }

            var collection = (ObservableCollection<Project>)listProjects.ItemsSource;
            collection.Remove(project);
            projects.DeleteProject(project);
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var selected = listProjects.SelectedItem;

            if (selected is null)
            {
                //добавить сообщение
                return;
            }

            var project = (Project)selected;
            project.AddTask(tasksView.Items.Count, TaskTextBox.Text);
            tasksView.ItemsSource = new ObservableCollection<ProjectTask>(project.Tasks);

        }

        private void DelTask_Click(object sender, RoutedEventArgs e)
        {
            var selectedProjects = listProjects.SelectedItem;
            var selectedTasks = tasksView.SelectedItem;

            if (!(selectedProjects is Project project))
            {
                return;
            }

            if (!(selectedTasks is ProjectTask projectTask))
            {
                //добавить сообщение
                return;
            }

            var collection = (ObservableCollection<ProjectTask>)tasksView.ItemsSource;
            collection.Remove(projectTask);
            project.DeleteTask(projectTask);
        }

        private void listProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = listProjects.SelectedItem;

            if (selected is null)
            {
                tasksView.ItemsSource = new ObservableCollection<ProjectTask>();
                //добавить сообщение
                return;
            }

            var project = (Project)selected;
            tasksView.ItemsSource = new ObservableCollection<ProjectTask>(project.Tasks);
        }
    }
}
