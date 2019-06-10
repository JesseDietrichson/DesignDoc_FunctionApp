using CsQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DesignDoc_FunctionApp
{
    class HTMLHelper
    {
        /// <summary>
        /// Gets the value of an html element by the class attribute
        /// </summary>
        /// <param name="html">The html string to scan</param>
        /// <param name="selector">The css selector to determine what html elements to scan</param>
        /// <param name="classValue">The possible values of the class</param>
        /// <returns>The value of the html element</returns>
        public static List<string> GetInnerTextOfElementByClass(string html, string selector, params string[] classValue)
        {
            try
            {
                CQ csQuery = new CQ(html);
                CQ allItems = csQuery.Find(selector);
                List<string> returnValues = new List<string>();
                foreach (var item in allItems)
                {
                    foreach (var value in classValue)
                    {
                        if (item.GetAttribute("class") == value)
                        {
                            returnValues.Add(item.InnerText);
                            break;
                        }
                    }
                }
                return returnValues;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<string> GetInnerTextOfElementById(string html, string selector, params string[] idValue)
        {
            try
            {
                CQ csQuery = new CQ(html);
                CQ allItems = csQuery.Find(selector);
                List<string> returnValues = new List<string>();
                foreach (var item in allItems)
                {
                    foreach (var value in idValue)
                    {
                        if (item.Id == value)
                        {
                            returnValues.Add(item.InnerText);
                            break;
                        }
                    }
                }
                return returnValues;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<string> GetInnerTextOfAllElements(string html, string selector)
        {
            try
            {
                CQ csQuery = new CQ(html);
                CQ allItems = csQuery.Find(selector);
                List<string> returnValues = new List<string>();
                foreach (var item in allItems)
                {
                    returnValues.Add(item.InnerText);
                }
                return returnValues;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Gets the outer html(including selector) of an html element by the class attribute and selector
        /// </summary>
        /// <param name="html">The html string to scan</param>
        /// <param name="selector">The css selector to determine what html elements to scan</param>
        /// <param name="classValue">The possible values of the class</param>
        /// <returns>The value of the html element</returns>
        public static List<string> GetOuterHTMLOfElementByClass(string html, string selector, params string[] classValue)
        {
            try
            {
                CQ csQuery = new CQ(html);
                CQ allItems = csQuery.Find(selector);
                List<string> returnValues = new List<string>();
                foreach (var item in allItems)
                {
                    foreach (var value in classValue)
                    {
                        if (item.GetAttribute("class") == value)
                        {
                            returnValues.Add(item.OuterHTML);
                            break;
                        }
                    }
                }
                return returnValues;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Gets the outer html(including selector) of an html element by the class attribute and selector

        /// </summary>

        /// <param name="html">The html string to scan</param>

        /// <param name="selector">The css selector to determine what html elements to scan</param>

        /// <param name="classValue">The possible values of the class</param>

        /// <returns>The value of the html element</returns>

        public static List<string> GetOuterHTMLOfElementByApproximateClass(string html, string selector, params string[] classValue)

        {

            try

            {

                CQ csQuery = new CQ(html);

                CQ allItems = csQuery.Find(selector);

                List<string> returnValues = new List<string>();

                foreach (var item in allItems)

                {

                    foreach (var value in classValue)

                    {

                        if (item.GetAttribute("class").Contains(value))

                        {

                            returnValues.Add(item.OuterHTML);

                            break;

                        }

                    }



                }

                return returnValues;

            }

            catch (Exception)

            {

                return null;

            }

        }

        public static List<string> GetInnerHTMLOfElementById(string html, string selector, params string[] idValue)
        {
            try
            {
                CQ csQuery = new CQ(html);
                CQ allItems = csQuery.Find(selector);
                List<string> returnValues = new List<string>();
                foreach (var item in allItems)
                {
                    foreach (var value in idValue)
                    {
                        if (item.Id == value)
                        {
                            returnValues.Add(item.InnerHTML);
                            break;
                        }
                    }
                }
                return returnValues;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<string> GetInnerHTMLOfElementWithOneParent(string html, string selector)
        {
            try
            {
                CQ csQuery = new CQ(html);
                CQ allItems = csQuery.Find(selector);
                List<string> returnValues = new List<string>();
                foreach (var item in allItems)
                {
                    if (item.ParentNode.ParentNode.ParentNode == null)
                    {
                        returnValues.Add(item.InnerHTML);
                    }
                }
                return returnValues;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<string> GetInnerTextOfElementWithOneParent(string html, string selector)
        {
            try
            {
                CQ csQuery = new CQ(html);
                CQ allItems = csQuery.Find(selector);
                List<string> returnValues = new List<string>();
                foreach (var item in allItems)
                {
                    if (item.ParentNode.ParentNode.ParentNode == null)
                    {
                        returnValues.Add(item.InnerText);
                    }
                }
                return returnValues;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<string> GetInnerTextOfElement(string html, string selector)
        {
            try
            {
                CQ csQuery = new CQ(html);
                CQ allItems = csQuery.Find(selector);
                List<string> returnValues = new List<string>();
                foreach (var item in allItems)
                {
                    returnValues.Add(item.InnerText);
                }
                return returnValues;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>

        /// Gets the outer html(excluding selector) of an html element by the class attribute and selector

        /// </summary>

        /// <param name="html">The html string to scan</param>

        /// <param name="selector">The css selector to determine what html elements to scan</param>

        /// <param name="classValue">The possible values of the class</param>

        /// <returns>The value of the html element</returns>

        public static List<string> GetInnerHTMLOfElementByClass(string html, string selector, params string[] classValue)

        {

            try

            {

                CQ csQuery = new CQ(html);

                CQ allItems = csQuery.Find(selector);

                List<string> returnValues = new List<string>();

                foreach (var item in allItems)

                {

                    foreach (var value in classValue)

                    {

                        if (item.GetAttribute("class") == value)

                        {

                            returnValues.Add(item.InnerHTML);

                            break;

                        }

                    }



                }

                return returnValues;

            }

            catch (Exception)

            {

                return null;

            }

        }



        /// <summary>

        /// Gets the value of an html element by the name attribute

        /// </summary>

        /// <param name="html">The html string to scan</param>

        /// <param name="selector">The css selector to determine what html elements to scan</param>

        /// <returns>The value of the html element</returns>

        public static List<string> GetVariableAttributeOfElementBySelector(string html, string selector, string variableAttribute)

        {

            try

            {

                CQ csQuery = new CQ(html);

                CQ allItems = csQuery.Find(selector);

                List<string> results = new List<string>();

                foreach (var item in allItems)

                {

                    foreach (var attribute in item.Attributes)

                    {

                        if (attribute.Key == variableAttribute)

                        {

                            results.Add(attribute.Value);

                        }

                    }

                }

                return results;

            }

            catch (Exception)

            {

                return null;

            }

        }

        /// <summary>

        /// Generates a form string of Name=value from all elements in the parameter array

        /// </summary>

        /// <param name="values">A tuple array of string,string containing name,value</param>

        /// <returns>A form string of Name=value</returns>

        public static string GenerateFormString(params Tuple<string, string>[] values)

        {

            try

            {

                StringBuilder builder = new StringBuilder();

                if (values.Length == 0)

                    return "";

                else if (values.Length == 1)

                    builder.Append(values[0].Item1 + "=" + HttpUtility.UrlEncode(values[0].Item2));

                else

                {

                    builder.Append(values[0].Item1 + "=" + HttpUtility.UrlEncode(values[0].Item2));

                    for (int i = 1; i < values.Length; i++)

                    {

                        builder.Append("&" + values[i].Item1 + "=" + HttpUtility.UrlEncode(values[i].Item2));

                    }

                }

                return builder.ToString();

            }

            catch (Exception)

            {

                return null;

            }

        }

        /// <summary>

        /// Generates a form string of Name=value from all elements based off the selector

        /// </summary>

        /// <param name="html">The html page to generate the form string from</param>

        /// <param name="selector">The css selector to determine what html elements should be selected</param>

        /// <param name="presetValues">A tuple array consisting of nameAttributeValue,valueAttributeValue. The values in the tuple will replace the values of the html elements before recording them in form string format</param>

        /// <returns></returns>

        public static string GenerateNameValueFormStringFromHTML(string html, string selector, params Tuple<string, string>[] presetValues)

        {

            try

            {

                StringBuilder builder = new StringBuilder();



                CQ loginFormCSQuery = new CQ(html);

                CQ allItems = loginFormCSQuery.Find(selector);

                foreach (var item in allItems)

                {

                    //Get the value of the name attribute from all inputs in the html

                    string nameAttributeValue = item.GetAttribute("name");

                    //Get the value of the value attribute from all inputs in the html

                    string valueAttributeValue = item.Value;



                    foreach (var preset in presetValues)

                    {

                        if (preset.Item1 == nameAttributeValue)

                        {

                            valueAttributeValue = preset.Item2;

                            break;

                        }

                    }

                    if (builder.Length == 0)

                        builder.Append($"{nameAttributeValue}={valueAttributeValue}");

                    else

                        builder.Append($"&{nameAttributeValue}={valueAttributeValue}");

                }

                return builder.ToString();

            }

            catch (Exception)

            {

                return null;

            }

        }

        /// <summary>
        /// Extracts a substring from html
        /// </summary>
        /// <param name="html">The html the pull the substring from</param>
        /// <param name="referencePoint">A point in the html that comes directly before the firstBound and secondBound</param>
        /// <param name="firstBound">The start of the substring not including itself</param>
        /// <param name="secondBound">The end of the substring not including itself</param>
        /// <returns>The substring</returns>
        public static string ExtractValueFromHTML(string html, string referencePoint, string firstBound, string secondBound, bool includeBounds = false)
        {
            try
            {
                int referencePointIndex = html.IndexOf(referencePoint);
                string secondHalfOfFile = html.Substring(referencePointIndex);
                int firstBoundIndex = secondHalfOfFile.IndexOf(firstBound) + firstBound.Length;
                string thirdHalfOfFile = secondHalfOfFile.Substring(firstBoundIndex);
                if (secondBound == "")
                    return thirdHalfOfFile;
                int secoundBoundIndex = thirdHalfOfFile.IndexOf(secondBound);
                if (secoundBoundIndex == -1)
                {
                    secoundBoundIndex = thirdHalfOfFile.Length - 1;
                }
                string finalSubString = thirdHalfOfFile.Substring(0, secoundBoundIndex);
                if (includeBounds)
                {
                    finalSubString = firstBound + finalSubString + secondBound;
                }
                finalSubString = finalSubString.Replace("\n", "");
                return finalSubString;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
