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
        public void CreateCsFile(string path,string _namespace, List<LanguageData>data)
        {
            StringBuilder builder = new StringBuilder();
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
            builder.AppendLine("internal class Language");
            builder.AppendLine("{");
            foreach (var str in data.First().Strings)
            {
                builder.AppendLine($"public string {str.Key} {{get;set;}} = \"{str.Value}\";");
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
