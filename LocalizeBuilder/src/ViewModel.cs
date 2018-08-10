using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LocalizeBuilder.src
{
    //Singleton
    internal class ViewModel : INotifyWrapper
    {
        //Fields
        private static ViewModel _viewModel;
        private LanguageData _selectedLanguage;
        private ObservableCollection<LanguageData> _languageDatas;
        private string _projectPath;
        //Properties
        public ObservableCollection<LanguageData> LanguageDatas
        {
            get { return _languageDatas; }
            set
            {
                _languageDatas = value;
                PropChanged("LanguageDatas");
            }
        }
        public LanguageData SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                _selectedLanguage = value;
                PropChanged("SelectedLanguage");
            }
        }
        public string ProjectPath
        {
            get { return _projectPath; }
            set
            {
                _projectPath = value;
                PropChanged("ProjectPath");
            }
        }
        //Constructors
        private ViewModel()
        {
            LanguageDatas = new ObservableCollection<LanguageData>();
            CommandAddLanguage = new RelayCommand(AddLanguage);
            CommandSaveToFile = new RelayCommand(SaveToFile);
            CommandLoadFromFile = new RelayCommand(LoadFromFile);
            CommandCreateNewProject = new RelayCommand(CreateNewProject);
        }
        //Commands
        public RelayCommand CommandAddLanguage { get; set; }
        public RelayCommand CommandSaveToFile { get; set; }
        public RelayCommand CommandLoadFromFile { get; set; }
        public RelayCommand CommandCreateNewProject { get; set; }
        //Methods
        public static ViewModel GetInstance()
        {
            return _viewModel ?? (_viewModel = new ViewModel());
        }

        private void AddLanguage(object param)
        {
            LanguageDatas.Add(new LanguageData("asd","11"));
            SelectedLanguage = LanguageDatas.Last();
        }
        private void SaveToFile(object param)
        {
            if (!(param is string path))
                throw new Exception();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, LanguageDatas);
            }
            ProjectPath = path;
        }
        private void LoadFromFile(object param)
        {
            if (!(param is string path))
                throw new Exception();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path,FileMode.Open))
            {
                LanguageDatas = (ObservableCollection<LanguageData>)formatter.Deserialize(stream);
                SelectedLanguage = LanguageDatas.First();
            }
            ProjectPath = path;
        }
        private void CreateNewProject(object param)
        {
            SelectedLanguage = null;
            LanguageDatas.Clear();
            ProjectPath = null;
        }
    }
}
