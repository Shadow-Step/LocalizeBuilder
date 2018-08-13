using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizeBuilder.src
{
    [Serializable]
    internal class StringUnit : INotifyWrapper
    {
        //Fields
        private string _key;
        private string _value;
        //Properties
        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
                PropChanged("Key");
            }
        }
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                PropChanged("Value");
            }
        }
        //Constructor
        public StringUnit() { }
        public StringUnit(string key,string value)
        {
            Key = key;
            Value = value;
        }
    }
}
