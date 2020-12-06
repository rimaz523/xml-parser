using Application.Common.Processors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Common.Processors
{
    public class XmlProcessor : IXmlProcessor
    {
        public bool IsTagPresent(string tag, string xmlContent)
        {
            var openingTag = $"<{tag}>";
            var closingTag = $"</{tag}>";
            var startIndex = xmlContent.IndexOf(openingTag);
            var endIndex = xmlContent.IndexOf(closingTag);
            if (startIndex < 0 || endIndex < 0)
            {
                return false;
            }
            return true;
        }

        public string GetTagContent(string tag, string xmlContent)
        {
            var openingTag = $"<{tag}>";
            var closingTag = $"</{tag}>";
            var startIndex = xmlContent.IndexOf(openingTag);
            var endIndex = xmlContent.IndexOf(closingTag);
            if (startIndex < 0 || endIndex < 0)
            {
                return null;
            }
            return xmlContent.Substring(startIndex + openingTag.Length, endIndex - (startIndex + openingTag.Length));
        }

        public bool AreAllOpeningTagsHavingCorrespondingClosingTags(string xmlContent)
        {
            var tagName = FindFirstOpeningTag(xmlContent);
            if (String.IsNullOrEmpty(tagName))
            {
                return true;
            }
            var openingTag = $"<{tagName}>";
            var closingTag = $"</{tagName}>";
            List<string> xmlOpeningTagSplitStrings = xmlContent.Split(openingTag, 2, StringSplitOptions.None).ToList();
            List<string> xmlClosingTagSplitStrings = xmlOpeningTagSplitStrings[1].Split(closingTag, 2, StringSplitOptions.None).ToList();
            if (xmlClosingTagSplitStrings.Count < 2)
            {
                return false; //There is no corresponding closing tag
            }
            
            return true 
                && AreAllOpeningTagsHavingCorrespondingClosingTags(xmlClosingTagSplitStrings[0]) 
                && AreAllOpeningTagsHavingCorrespondingClosingTags(xmlClosingTagSplitStrings[1]);
        }

        public string FindFirstOpeningTag(string xmlContent)
        {
            var startOfOpeningTag = "<";
            var endOfOpeningTag = ">";
            var startIndex = xmlContent.IndexOf(startOfOpeningTag);
            var endIndex = xmlContent.IndexOf(endOfOpeningTag);
            if (startIndex < 0 || endIndex < 0)
            {
                return null;
            }
            return xmlContent.Substring(startIndex + startOfOpeningTag.Length, endIndex - (startIndex + startOfOpeningTag.Length));
        }
    }
}
