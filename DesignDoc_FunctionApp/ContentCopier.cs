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

        private Dictionary<string, List<string>> mappings = new Dictionary<string, List<string>>();


        public ContentCopier(string nameOfTemplate, DirectoryInfo folder, string newFileName)
        {
            this.nameOfTemplate = nameOfTemplate;
            this.folder = folder;
            this.newFileName = newFileName;
        }

        public void AddMapping(string key, string value)
        {
            mappings.TryAdd(key, new List<string>() { value });
        }
        public void AddMapping(string key, List<string> value)
        {
            mappings.TryAdd(key, value);
        }

        public void Start()
        {

            var filePath = Path.Combine(Environment.ExpandEnvironmentVariables("%HOME%"), @"site\wwwroot\Templates");

            string line;
            using (System.IO.StreamReader inputFile = new System.IO.StreamReader(filePath + nameOfTemplate))
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
                                if (item.Value.Count == 1)
                                {
                                    line = line.Replace(key, item.Value[0]);
                                    outputFile.WriteLine(line);
                                }
                                else
                                {
                                    foreach (var value in item.Value)
                                    {
                                        outputFile.WriteLine("- " + value);
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
