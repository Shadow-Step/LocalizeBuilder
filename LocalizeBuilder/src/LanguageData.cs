using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizeBuilder.src
{
    [Serializable]
    internal class LanguageData : INotifyWrapper
    {
        //Fields
        private string _longName;

        //Properties
        public string LongName
        {
            get { return _longName; }
            set
            {
                _longName = value;
                PropChanged("LongName");
            }
        }
        public ObservableCollection<StringUnit> Strings { get; set; }
        //Constructors
        public LanguageData()
        {
            Strings = new ObservableCollection<StringUnit>();
        }
        public LanguageData(string longName) : base()
        {
            _longName = longName;
        }
        //Methods
    }
}
