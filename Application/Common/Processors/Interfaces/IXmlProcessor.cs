namespace Application.Common.Processors.Interfaces
{
    public interface IXmlProcessor
    {
        public bool IsTagPresent(string tag, string xmlContent);
        public string GetTagValue(string tag, string xmlContent);
        public string FindFirstOpeningTag(string xmlContent);
        public bool AreAllOpeningTagsHavingCorrespondingClosingTags(string xmlContent);
    }
}
