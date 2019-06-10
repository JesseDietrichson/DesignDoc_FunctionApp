using Markdig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DesignDoc_FunctionApp
{
    public class DesignDocParser
    {
        private string designDocHTML;
        public DesignDoc DesignDocument { get; private set; }
        public DesignDocParser(string markdown)
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            var document = Markdown.ToHtml(Markdown.Normalize(markdown), pipeline);

            designDocHTML = "<html>" + document + "</html>";
            DesignDocument = new DesignDoc();

            parseTitle();
            parseRoles();
            parseLevel();
            parseProducts();
            parsePrerequisites();
            parseSummary();
            parseLearningObjectives();
            parseUnits();
        }

        private void parseTitle()
        {
            string titleHtml = HTMLHelper.ExtractValueFromHTML(designDocHTML, "<h2 id=\"title\">", "Title</h2>", "<h2 id=\"roles\">Role(s)</h2>");
            var title = getTextFromHtml(titleHtml).FirstOrDefault();
            DesignDocument.Title = title;
        }

        private void parseRoles()
        {
            string roleHtml = HTMLHelper.ExtractValueFromHTML(designDocHTML, "<h2 id=\"roles\">", "Role(s)</h2>", "<h2 id=\"level\">Level</h2>");
            var roles = getTextFromHtml(roleHtml);
            DesignDocument.Roles = roles;
        }

        private void parseLevel()
        {
            string levelHtml = HTMLHelper.ExtractValueFromHTML(designDocHTML, "<h2 id=\"level\">", "Level</h2>", "<h2 id=\"products\">Product(s)</h2>");
            var level = getTextFromHtml(levelHtml).FirstOrDefault();
            DesignDocument.Level = level;
        }

        private void parseProducts()
        {
            string productsHtml = HTMLHelper.ExtractValueFromHTML(designDocHTML, "<h2 id=\"products\">", "Product(s)</h2>", "<h2 id=\"prerequisites\">Prerequisites</h2>");
            var products = getTextFromHtml(productsHtml);
            DesignDocument.Products = products;
        }

        private void parsePrerequisites()
        {
            string prerequisiteHtml = HTMLHelper.ExtractValueFromHTML(designDocHTML, "<h2 id=\"prerequisites\">", "Prerequisites</h2>", "<h2 id=\"summary\">Summary</h2>");
            var prerequisites = getTextFromHtml(prerequisiteHtml);
            DesignDocument.Prerequisites = prerequisites;
        }

        private void parseSummary()
        {
            string summaryHtml = HTMLHelper.ExtractValueFromHTML(designDocHTML, "<h2 id=\"summary\">", "Summary</h2>", "<h2 id=\"learning-objectives\">Learning objectives</h2>");
            var summary = getTextFromHtml(summaryHtml).FirstOrDefault();
            DesignDocument.Summary = summary;
        }

        private void parseLearningObjectives()
        {
            string learningObjectiveHtml = HTMLHelper.ExtractValueFromHTML(designDocHTML, "<h2 id=\"learning-objectives\">", "Learning objectives</h2>", "<h2 id=\"chunk-your-content-into-subtasks\">Chunk your content into subtasks</h2>");
            var learningObjectives = getTextFromHtml(learningObjectiveHtml);
            DesignDocument.LearningObjectives = learningObjectives;
        }

        private void parseUnits()
        {
            string unitsHtml = HTMLHelper.ExtractValueFromHTML(designDocHTML, "<h2 id=\"outline-the-units\">", "Outline the units</h2>", "<h2");
            var units = HTMLHelper.GetInnerHTMLOfElementWithOneParent(unitsHtml, "li");
            foreach (var unit in units)
            {
                Unit newUnit = new Unit(unit);
                DesignDocument.Units.Add(newUnit);
            }
        }

        private List<string> getTextFromHtml(string html)
        {
            List<string> text = null;
            if (html.Contains("<p>"))
            {
                text = new List<string>();
                text.Add(HTMLHelper.ExtractValueFromHTML(html, "<p", ">", "</p>"));
            }
            else if (html.Contains("<li>"))
            {
                text = HTMLHelper.GetInnerTextOfAllElements(html, "li"); ;
            }
            return text;

        }
    }
}
