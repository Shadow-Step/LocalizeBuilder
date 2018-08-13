using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizeBuilder.src
{
    [Serializable]
    internal class ViewModelArgs
    {
        public ObservableCollection<LanguageData> ItemsCollection { get; set; }
        public LanguageData SelectedItem { get; set; }
        public string Namespace { get; set; }
        public string ClassName { get; set; }
        
        //Contructor
        public ViewModelArgs(ObservableCollection<LanguageData> ItemsCollection, LanguageData SelectedItem,string Namespace,string ClassName)
        {
            this.ItemsCollection = ItemsCollection;
            this.SelectedItem = SelectedItem;
            this.Namespace = Namespace;
            this.ClassName = ClassName;
        }
    }
}
