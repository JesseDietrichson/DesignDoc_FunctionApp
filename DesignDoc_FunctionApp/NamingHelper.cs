using System;
using System.Collections.Generic;
using System.Text;

namespace DesignDoc_FunctionApp
{
    public static class NamingHelper
    {
        public static string ReplaceSpacesWithHyphen(string text)
        {
            string newText = text.Replace(" ", "-");
            newText = newText.Replace("---", "-");
            newText = newText.Replace("--", "-");
            newText = newText.Replace("?", "");
            return newText.ToLower();
        }
    }
}
