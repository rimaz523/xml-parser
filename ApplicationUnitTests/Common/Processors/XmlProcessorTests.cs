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
    }
}
