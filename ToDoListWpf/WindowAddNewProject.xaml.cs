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
using System.Windows.Shapes;

namespace ToDoListWpf
{
    /// <summary>
    /// Логика взаимодействия для WindowAddNewProject.xaml
    /// </summary>
    public partial class WindowAddNewProject : Window
    {
        public WindowAddNewProject()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string NameInTextBox
        {
            get { return nameBox.Text; }
        }
    }
}
