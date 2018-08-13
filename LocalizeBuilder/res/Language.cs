using System.ComponentModel;

namespace LocalizeBuilder.res
{
    internal enum LanguageEnum
    {
        Russian,
        English
    }
    internal class Language : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void PropChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private string _file = "Файл";
        private string _new = "Новый";
        private string _save = "Сохранить";
        private string _open = "Открыть";
        private string _synchronize = "Синхронизировать";
        private string _export = "Экспортировать";
        private string _name = "Название";
        private string _key = "Ключ";
        private string _value = "Значение";
        private string _namespace = "Namespace";
        private string _classname = "Название класса";
        private string _values = "Значения";
        private string _languages = "Языки";

        public string File
        {
            get { return _file; }
            set { _file = value; PropChanged("File"); }
        }
        public string New
        {
            get { return _new; }
            set { _new = value; PropChanged("New"); }
        }
        public string Save
        {
            get { return _save; }
            set { _save = value; PropChanged("Save"); }
        }
        public string Open
        {
            get { return _open; }
            set { _open = value; PropChanged("Open"); }
        }
        public string Synchronize
        {
            get { return _synchronize; }
            set { _synchronize = value; PropChanged("Synchronize"); }
        }
        public string Export
        {
            get { return _export; }
            set { _export = value; PropChanged("Export"); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; PropChanged("Name"); }
        }
        public string Key
        {
            get { return _key; }
            set { _key = value; PropChanged("Key"); }
        }
        public string Value
        {
            get { return _value; }
            set { _value = value; PropChanged("Value"); }
        }
        public string Namespace
        {
            get { return _namespace; }
            set { _namespace = value; PropChanged("Namespace"); }
        }
        public string ClassName
        {
            get { return _classname; }
            set { _classname = value; PropChanged("ClassName"); }
        }
        public string Values
        {
            get { return _values; }
            set { _values = value; PropChanged("Values"); }
        }
        public string Languages
        {
            get { return _languages; }
            set { _languages = value; PropChanged("Languages"); }
        }
        public void SwitchLanguage(LanguageEnum lang_param)
        {
            switch (lang_param)
            {
                case LanguageEnum.Russian:
                    File = "Файл";
                    New = "Новый";
                    Save = "Сохранить";
                    Open = "Открыть";
                    Synchronize = "Синхронизировать";
                    Export = "Экспортировать";
                    Name = "Название";
                    Key = "Ключ";
                    Value = "Значение";
                    Namespace = "Namespace";
                    ClassName = "Название класса";
                    Values = "Значения";
                    Languages = "Языки";
                    break;
                case LanguageEnum.English:
                    File = "File";
                    New = "New";
                    Save = "Save";
                    Open = "Open";
                    Synchronize = "Synchronize";
                    Export = "Export";
                    Name = "Name";
                    Key = "Key";
                    Value = "Value";
                    Namespace = "Namespace";
                    ClassName = "ClassName";
                    Values = "Values";
                    Languages = "Languages";
                    break;
            }
        }
    }
}

