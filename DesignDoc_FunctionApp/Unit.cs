using Html2Markdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DesignDoc_FunctionApp
{
    public class Unit
    {
        public string Title { get; set; }
        public string Notes { get; set; }
        public bool IsKnowledgeCheck { get; set; }
        public bool IsExercise { get; set; }

        public Unit(string html)
        {
            parseHtml(html);
        }

        private void parseHtml(string html)
        {
            //Title
            var paragraphs = HTMLHelper.GetInnerTextOfElement("<html>" + html + "</html>", "strong");
            Title = paragraphs.FirstOrDefault();

            //Notes
            Converter converter = new Converter();
            var markdown = converter.Convert(html);
            Notes = markdown;

            //Knowledge check
            if (Title.ToLower().Contains("knowledge check"))
            {
                IsKnowledgeCheck = true;
            }

            //Exercise
            if (Title.ToLower().Contains("exercise"))
            {
                IsExercise = true;
            }
        }
        public override string ToString()
        {
            return NamingHelper.ReplaceSpacesWithHyphen(Title);
        }
    }
}
