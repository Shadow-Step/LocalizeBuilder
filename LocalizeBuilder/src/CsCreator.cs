using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizeBuilder.src
{
    internal enum Languages
    {

    }
    internal class CsCreator
    {
        //Methods
        public void CreateCsFile(string path,string _namespace,string _classname, List<LanguageData>data)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("using System.ComponentModel;");
            builder.AppendLine();
            builder.AppendLine($"namespace {_namespace}");
            builder.AppendLine("{");
            builder.AppendLine("internal enum LanguageEnum");
            builder.AppendLine("{");
            for (int i = 0; i < data.Count; i++)
            {
                if(i != data.Count - 1)
                    builder.AppendLine($"{data[i].LongName},");
                else
                    builder.AppendLine(data[i].LongName);
            }
            builder.AppendLine("}");
            builder.AppendLine($"internal class {_classname} : INotifyPropertyChanged");
            builder.AppendLine("{");
            builder.AppendLine("public event PropertyChangedEventHandler PropertyChanged;");
            builder.AppendLine("public void PropChanged(string property)");
            builder.AppendLine("{");
            builder.AppendLine("PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));");
            builder.AppendLine("}");
            builder.AppendLine();
            foreach (var str in data.First().Strings)
            {
                builder.AppendLine($"private string _{str.Key.ToLower()} = \"{str.Value}\";");
            }
            builder.AppendLine();
            foreach (var str in data.First().Strings)
            {
                builder.AppendLine($"public string {str.Key}");
                builder.AppendLine("{");
                builder.AppendLine($"get{{return _{str.Key.ToLower()};}}");
                builder.AppendLine($"set{{_{str.Key.ToLower()} = value; PropChanged(\"{str.Key}\");}}");
                builder.AppendLine("}");
            }
            builder.AppendLine("public void SwitchLanguage(LanguageEnum lang_param)");
            builder.AppendLine("{");
            builder.AppendLine("switch (lang_param)");
            builder.AppendLine("{");
            foreach (var lang in data)
            {
                builder.AppendLine($"case LanguageEnum.{lang.LongName}:");
                foreach (var str in lang.Strings)
                {
                    builder.AppendLine($"{str.Key} = \"{str.Value}\";");
                }
                builder.AppendLine("break;");
            }
            builder.AppendLine("}");
            builder.AppendLine("}");
            builder.AppendLine("}");
            builder.AppendLine("}");

            using (StreamWriter stream = new StreamWriter(path))
            {
                stream.WriteLine(builder.ToString());
            }
        }
    }
}
