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
                MessageBox.Show("Проект не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Проект не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var project = (Project)selected;
            project.AddTask(TaskTextBox.Text);
            tasksView.ItemsSource = new ObservableCollection<ProjectTask>(project.Tasks);

        }

        private void DelTask_Click(object sender, RoutedEventArgs e)
        {
            var selectedProjects = listProjects.SelectedItem;
            var selectedTasks = tasksView.SelectedItem;

            if (!(selectedProjects is Project project))
            {
                MessageBox.Show("Проект не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!(selectedTasks is ProjectTask projectTask))
            {
                MessageBox.Show("Задача не выбрана", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
                return;
            }

            var project = (Project)selected;
            tasksView.ItemsSource = new ObservableCollection<ProjectTask>(project.Tasks);
        }

        //private void TaskTextBox_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    TaskTextBox.SelectionStart = 0;
        //    TaskTextBox.SelectionLength = TaskTextBox.Text.Length;
        //    TaskTextBox.Select(0, TaskTextBox.Text.Length);
        //}

        private bool isFocused = false;
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            isFocused = true;
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (isFocused)
            {
                isFocused = false;
                (sender as TextBox).SelectAll();
            }
        }
    }
}
