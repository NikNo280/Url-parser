using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Url_parser;

namespace UrlParserTests.Unit_Tests
{
    internal class TestsCases
    {
        public static IEnumerable<TestCaseData> UrlParceTest
        {
            get
            {
                yield return new TestCaseData(
                   "https://github.com/AnzhelikaKravchuk?tab=repositories",
                    new UrlModel("github.com", new List<string>() { "AnzhelikaKravchuk" },
                    new List<(string, string)> { ("repositories", "tab") })
                    );
                yield return new TestCaseData(
                   "https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU",
                    new UrlModel("github.com", new List<string>() { "AnzhelikaKravchuk", "2017-2018.MMF.BSU" },
                    new List<(string, string)> ())
                    );
                yield return new TestCaseData(
                   "https://habrahabr.ru/company/it-grad/blog/341486/",
                    new UrlModel("habrahabr.ru", new List<string>() { "company", "it-grad", "blog", "341486" },
                    new List<(string, string)>())
                    );
            }
        }
    }
}
