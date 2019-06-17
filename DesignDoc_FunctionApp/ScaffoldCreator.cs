using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace DesignDoc_FunctionApp
{
    public class ScaffoldCreator
    {
        private readonly DesignDoc designDoc;
        private DirectoryInfo rootFolder;
        private DirectoryInfo includesFolder;
        private string zippedPath;

        public ScaffoldCreator(DesignDoc designDoc)
        {
            this.designDoc = designDoc;

            createFolders();
            createIndexYmlFile();
            createYmlFiles();
            createMdFiles();
            zipFolder();
        }

        private void createFolders()
        {
            string rootFolderName = NamingHelper.ReplaceSpacesWithHyphen(designDoc.Title);
            rootFolder = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(),rootFolderName));

            includesFolder = rootFolder.CreateSubdirectory("includes");
            rootFolder.CreateSubdirectory("media");
        }

        private void createIndexYmlFile()
        {
            ContentCopier copier = new ContentCopier("indextemplateyml.yml", rootFolder, "index.yml");
            copier.AddMapping("title", designDoc.Title);
            copier.AddMapping("date", DateTime.Now.ToShortDateString());
            copier.AddMapping("summary", designDoc.Summary);
            copier.AddMapping("learning_objectives", designDoc.LearningObjectives, true);
            copier.AddMapping("prerequisites", designDoc.Prerequisites, true);
            copier.AddMapping("level", designDoc.Level.ToLower());
            copier.AddMapping("roles", designDoc.GetRolesForIndexYml());
            //copier.AddMapping("products", designDoc.Products);
            copier.AddMapping("units", designDoc.GetUnitsForIndexYml());
            copier.Start();
        }

        private void createYmlFiles()
        {
            for (int i = 0; i < designDoc.Units.Count; i++)
            {
                string markdown_file_uid = (i + 1).ToString() + "-" + NamingHelper.ReplaceSpacesWithHyphen(designDoc.Units[i].Title);

                if (designDoc.Units[i].IsKnowledgeCheck)
                {
                    ContentCopier copier = new ContentCopier("knowledgechecktemplateyml.yml", rootFolder, markdown_file_uid + ".yml");
                    copier.AddMapping("title", designDoc.Units[i].Title);
                    copier.AddMapping("titlenospace", designDoc.Units[i].ToString());
                    copier.AddMapping("date", DateTime.Now.ToShortDateString());
                    copier.AddMapping("markdown_file_uid", markdown_file_uid);
                    copier.Start();
                }
                else
                {
                    ContentCopier copier = new ContentCopier("unittemplateyml.yml", rootFolder, markdown_file_uid + ".yml");
                    copier.AddMapping("title", designDoc.Units[i].Title);
                    copier.AddMapping("titlenospace", designDoc.Units[i].ToString());
                    copier.AddMapping("date", DateTime.Now.ToShortDateString());
                    copier.AddMapping("markdown_file_uid", markdown_file_uid);
                    copier.Start();
                }
            }
        }

        private void createMdFiles()
        {
            for (int i = 0; i < designDoc.Units.Count; i++)
            {
                string markdown_file_uid = (i + 1).ToString() + "-" + NamingHelper.ReplaceSpacesWithHyphen(designDoc.Units[i].Title);

                if (designDoc.Units[i].IsKnowledgeCheck)
                {
                    continue;
                }
                else if (designDoc.Units[i].IsExercise)
                {
                    ContentCopier copier = new ContentCopier("exercisetemplatemd.md", includesFolder, markdown_file_uid + ".md");
                    copier.AddMapping("notes", designDoc.Units[i].Notes);
                    copier.Start();
                }
                else if (i == 0)
                {
                    ContentCopier copier = new ContentCopier("introductiontemplatemd.md", includesFolder, markdown_file_uid + ".md");
                    copier.AddMapping("notes", designDoc.Units[i].Notes);
                    copier.AddMapping("learning_objectives", designDoc.LearningObjectives);
                    copier.AddMapping("prerequisites", designDoc.Prerequisites);
                    copier.Start();
                }
                else if (i == designDoc.Units.Count - 1)
                {
                    ContentCopier copier = new ContentCopier("summarytemplatemd.md", includesFolder, markdown_file_uid + ".md");
                    copier.AddMapping("notes", designDoc.Units[i].Notes);
                    copier.Start();
                }
                else
                {
                    ContentCopier copier = new ContentCopier("learningcontenttemplatemd.md", includesFolder, markdown_file_uid + ".md");
                    copier.AddMapping("notes", designDoc.Units[i].Notes);
                    copier.Start();
                }
            }
        }

        private void zipFolder()
        {
            Random r = new Random();
            int rNumber = r.Next(1000, 9999);
            zippedPath = Path.Combine(Path.GetTempPath(), "LearnModule" + rNumber + ".zip");
            ZipFile.CreateFromDirectory(rootFolder.FullName, zippedPath);
        }

        public void SendEmail(string who)
        {

            var settings = new SmtpSettings()
            {
                Host = "smtp.live.com", // or "smtp.gmail.com"
                Port = 587,
                Username = "learndesigndoc@outlook.com",
                Password = "Mslearndoc"
        };

            var smtpMailer = new SmtpMailer();

            smtpMailer.Send(settings, "learndesigndoc@outlook.com", who, "Learn Module scaffolding", "",zippedPath);
            File.Delete(zippedPath);
        }
    }
}
