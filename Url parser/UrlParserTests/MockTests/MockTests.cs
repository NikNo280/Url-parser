using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Url_parser;
using Url_parser.Writer;

namespace UrlParserTests.MockTests
{
    public class MockTests
    {
        [Test]
        public void TestWrite()
        {
            var list = new List<UrlModel>();
            var mock = new Mock<IWriter<UrlModel>>();
            mock.Setup(obj => obj.Write(list.ToArray(), "test.xml"));
            mock.Verify();
        }
    }
}
