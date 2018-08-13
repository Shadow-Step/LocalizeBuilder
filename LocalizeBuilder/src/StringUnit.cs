using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocalizeBuilder.src
{
    [Serializable]
    internal class StringUnit : INotifyWrapper, IDataErrorInfo
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

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "Value":
                        if (Value == null || Value[0] == '!')
                            error = "Rename";
                        break;
                    default:
                        break;
                }
                return error;
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
