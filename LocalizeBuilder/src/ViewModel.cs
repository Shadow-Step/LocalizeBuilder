﻿using LocalizeBuilder.res;
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
        private string _namespace;
        private string _className;
        //Properties
        public Language Language { get; set; }
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
        public string Namespace
        {
            get { return _namespace; }
            set
            {
                _namespace = value;
                PropChanged("Namespace");
            }
        }
        public string ClassName
        {
            get { return _className; }
            set
            {
                _className = value;
                PropChanged("ClassName");
            }
        }
        //Constructors
        private ViewModel()
        {
            Language = new Language();
            LanguageDatas = new ObservableCollection<LanguageData>();
            CommandAddLanguage = new RelayCommand(AddLanguage);
            CommandSaveToFile = new RelayCommand(SaveToFile);
            CommandLoadFromFile = new RelayCommand(LoadFromFile);
            CommandCreateNewProject = new RelayCommand(CreateNewProject);
            CommandExportProject = new RelayCommand(ExportProject);
            CommandSynchronize = new RelayCommand(Synchronize);
        }
        //Commands
        public RelayCommand CommandAddLanguage { get; set; }
        public RelayCommand CommandSaveToFile { get; set; }
        public RelayCommand CommandLoadFromFile { get; set; }
        public RelayCommand CommandCreateNewProject { get; set; }
        public RelayCommand CommandExportProject { get; set; }
        public RelayCommand CommandSynchronize { get; set; }
        //Methods
        public static ViewModel GetInstance()
        {
            return _viewModel ?? (_viewModel = new ViewModel());
        }

        private void AddLanguage(object param)
        {
            LanguageDatas.Add(new LanguageData(""));
            SelectedLanguage = LanguageDatas.Last();
        }
        private void SaveToFile(object param)
        {
            if (!(param is string path))
                throw new Exception();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                ViewModelArgs args = new ViewModelArgs(LanguageDatas, SelectedLanguage, Namespace, ClassName);
                formatter.Serialize(stream, args);
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
                ViewModelArgs args = (ViewModelArgs)formatter.Deserialize(stream);
                LanguageDatas = args.ItemsCollection;
                SelectedLanguage = args.SelectedItem;
                Namespace = args.Namespace;
                ClassName = args.ClassName;
            }
            ProjectPath = path;
        }
        private void CreateNewProject(object param)
        {
            SelectedLanguage = null;
            LanguageDatas.Clear();
            ProjectPath = null;
        }
        private void ExportProject(object param)
        {
            if (!(param is string path))
                throw new Exception();
            CsCreator creator = new CsCreator();
            creator.CreateCsFile(path, Namespace,ClassName, LanguageDatas.ToList()); // temp
        }
        private void Synchronize(object param)
        {
            if (LanguageDatas.Count < 2)
                return; // ! Return

            var pattern = LanguageDatas.First();
            for (int i = 1; i < LanguageDatas.Count; i++)
            {
                foreach (var item in pattern.Strings)
                {
                    var res = from x in LanguageDatas[i].Strings where x.Key == item.Key select x;
                    if(res.Count() == 0)
                    LanguageDatas[i].Strings.Add(new StringUnit(item.Key, $"!->{item.Value}"));
                }
                foreach (var item in LanguageDatas[i].Strings)
                {
                    var res = from x in pattern.Strings where x.Key == item.Key select x;
                    if (res.Count() == 0)
                        pattern.Strings.Add(new StringUnit(item.Key, $"!->{item.Value}"));
                }
            }
        }
    }
}
