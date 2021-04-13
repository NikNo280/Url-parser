using NUnit.Framework;
using System;
using Url_parser;

namespace UrlParserTests.Unit_Tests
{
    public class UrlParserTests
    {
        [TestCaseSource(typeof(TestsCases), nameof(TestsCases.UrlParceTest))]
        public void UrlParceTest(string source, UrlModel urlModel)
        {
            var model = new UrlParcer().Parce(source);
            Assert.AreEqual(urlModel.HostName, model.HostName);
            CollectionAssert.AreEqual(urlModel.GetParameters(), model.GetParameters());
            CollectionAssert.AreEqual(urlModel.GetUri(), model.GetUri());
        }
    }
}
