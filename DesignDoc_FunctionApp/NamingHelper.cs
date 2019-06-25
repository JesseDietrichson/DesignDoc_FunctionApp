using System;
using System.Collections.Generic;
using System.Text;

namespace DesignDoc_FunctionApp
{
    public static class NamingHelper
    {
        private static string[] punctuationToRemove = { "?", "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "{", "}", "[", "]", "\\", "|", ";", ":", "'", "\"", "<", ">", "/", ".", "," };
        public static string ReplaceSpacesWithHyphen(string text, bool removePunctuation)
        {
            string newText = text.Replace(" ", "-");
            newText = newText.Replace("---", "-");
            newText = newText.Replace("--", "-");

            if (removePunctuation)
            {
                foreach (var punc in punctuationToRemove)
                {
                    newText = newText.Replace(punc, "");
                }
            }
            return newText.ToLower();
        }
    }
}
