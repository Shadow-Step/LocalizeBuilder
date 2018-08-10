using Microsoft.Win32;
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

namespace LocalizeBuilder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = src.ViewModel.GetInstance();
        }

        private void SaveToFile(object sender, RoutedEventArgs e)
        {
            if (src.ViewModel.GetInstance().ProjectPath == null)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.RestoreDirectory = true;
                saveFile.Filter = "Project file (*.lcb)|*lcb";
                saveFile.DefaultExt = ".lcb";
                if ((bool)saveFile.ShowDialog())
                {
                    src.ViewModel.GetInstance().CommandSaveToFile.Execute(saveFile.FileName);
                }
            }
            else
            {
                src.ViewModel.GetInstance().CommandSaveToFile.Execute(src.ViewModel.GetInstance().ProjectPath);
            }
        }
        private void LoadFromFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "Project file (*.lcb)|*lcb";
            if ((bool)fileDialog.ShowDialog())
            {
                src.ViewModel.GetInstance().CommandLoadFromFile.Execute(fileDialog.FileName);
            }
        }
        private void CreateNewProject(object sender, RoutedEventArgs e)
        {
            src.ViewModel.GetInstance().CommandCreateNewProject.Execute(null);
        }
        private void ExportProject(object sender, RoutedEventArgs e)
        {
            SaveFileDialog export = new SaveFileDialog();
            export.Filter = "Project file (*.cs)|*cs";
            export.DefaultExt = ".cs";
            if ((bool)export.ShowDialog())
            {
                src.ViewModel.GetInstance().CommandExportProject.Execute(export.FileName);
            }
        }
    }
}
