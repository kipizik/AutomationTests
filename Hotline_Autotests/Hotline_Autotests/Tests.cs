using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotline_Autotests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace Hotline_Autotests
{
    [TestFixture]
    public class Tests
    {
        private String URL = FileOperations.GetUrl("Configuration.xml");

        [SetUp]
        public void BeforeTest()
        {

        }

        [Test]
        public void OpenMainPage()
        {
            var driver = new FirefoxDriver(); 

            driver.Navigate().GoToUrl(URL);
        }

        [TearDown]
        public void AfterTest()
        {

        }

    }
}
