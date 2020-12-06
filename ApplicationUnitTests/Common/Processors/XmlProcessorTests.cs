using Application.Common.Processors;
using Application.Common.Processors.Interfaces;
using NUnit.Framework;

namespace ApplicationUnitTests.Common.Processors
{
    public class XmlProcessorTests
    {
        private IXmlProcessor _xmlProcessor;

        [SetUp]
        public void Setup ()
        {
            _xmlProcessor = new XmlProcessor();
        }

        [Test]
        public void IsTagPresent_WhenTagStartAndEndExistsInXml_ReturnTrue()
        {
            var result = _xmlProcessor.IsTagPresent("test", "this is a <test></test> xml");

            Assert.IsTrue(result);
        }

        [Test]
        public void IsTagPresent_WhenStartTagMissingInXml_ReturnFalse()
        {
            var result = _xmlProcessor.IsTagPresent("test", "this is a </test> xml");

            Assert.IsFalse(result);
        }

        [Test]
        public void IsTagPresent_WhenEndTagMissingInXml_ReturnFalse()
        {
            var result = _xmlProcessor.IsTagPresent("test", "this is a <test> xml");

            Assert.IsFalse(result);
        }

        [Test]
        public void IsTagPresent_WhenTagsMissingInXml_ReturnFalse()
        {
            var result = _xmlProcessor.IsTagPresent("test", "this is a <other>12</other> xml");

            Assert.IsFalse(result);
        }

        [Test]
        public void GetTagContent_WhenTagAndContentExists_ReturnContent()
        {
            var tagContent = "sampleContent";
            var result = _xmlProcessor.GetTagContent("test", $"this is a <test>{tagContent}</test> xml");

            Assert.AreEqual(result, tagContent);
        }

        [Test]
        public void GetTagContent_WhenTagAndContentDoNotExist_ReturnNull()
        {
            var result = _xmlProcessor.GetTagContent("test", $"this is a <other>other content</other> xml");

            Assert.IsNull(result);
        }
    }
}
