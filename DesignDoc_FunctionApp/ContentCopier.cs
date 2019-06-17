using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesignDoc_FunctionApp
{
    public class ContentCopier
    {
        private readonly string nameOfTemplate;
        private readonly DirectoryInfo folder;
        private readonly string newFileName;

        private Dictionary<string, Mapping> mappings = new Dictionary<string, Mapping>();


        public ContentCopier(string nameOfTemplate, DirectoryInfo folder, string newFileName)
        {
            this.nameOfTemplate = nameOfTemplate;
            this.folder = folder;
            this.newFileName = newFileName;
        }

        public void AddMapping(string key, string value, bool shouldIndent = false)
        {
            Mapping mapping = new Mapping();
            mapping.Key = key;
            mapping.Value = new List<string>() { value };
            mapping.ShouldIndent = shouldIndent;

            mappings.TryAdd(key, mapping);
        }
        public void AddMapping(string key, List<string> value, bool shouldIndent = false)
        {
            Mapping mapping = new Mapping();
            mapping.Key = key;
            mapping.Value = value;
            mapping.ShouldIndent = shouldIndent;

            mappings.TryAdd(key, mapping);
        }

        public void Start()
        {

            var filePath = Path.Combine(Environment.ExpandEnvironmentVariables("%HOME%"), @"site\wwwroot\Templates");

            string line;
            using (System.IO.StreamReader inputFile = new System.IO.StreamReader(filePath + "\\"+nameOfTemplate))
            {
                using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(Path.Combine(folder.FullName, newFileName), false))
                {
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        bool found = false;
                        foreach (var item in mappings)
                        {
                            string key = "[" + item.Key + "]";
                            if (line.Contains(key))
                            {
                                if (item.Value.Value.Count == 1)
                                {
                                    line = line.Replace(key, item.Value.Value[0]);
                                    outputFile.WriteLine(line);
                                }
                                else
                                {
                                    foreach (var value in item.Value.Value)
                                    {
                                        outputFile.WriteLine(item.Value.ShouldIndent ? "\t- " + value : "- " + value);
                                    }
                                }
                                found = true;
                                break;
                            }

                        }
                        if (!found)
                        {
                            outputFile.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}
