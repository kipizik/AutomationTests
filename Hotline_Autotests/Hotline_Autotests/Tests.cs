using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotline_Autotests.Helpers;
using Hotline_Autotests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Hotline_Autotests
{
    [TestFixture]
    public class Tests
    {
        private String _url;
        private IWebDriver _driver;

        [SetUp]
        public void BeforeTest()
        {
            _driver = TestConfiguration.Driver;
            if (_driver!=null)
            {
                _url = TestConfiguration.GetUrl(); 
            }
            else
            {
                throw new WebDriverException("Undefined driver type. Null");
            }
        }

        [Test]
        public void UserIsOnMainPage()
        {
            //_driver.Navigate().GoToUrl(_url);
            MainPage main = new MainPage();
            main.Open(_url).Refresh();

            Assert.True(_driver.Url.Contains("hotline"));
        }

        [Test]
        public void SeekingProductIsFound()
        {
            //_driver.Navigate().GoToUrl(_url);
            var mainPage = new MainPage();
            mainPage.Open(_url);
            SearchResultsPage searchResultsPage = mainPage.SearchProduct(TestConfiguration.Brand);

            Assert.True(_driver.PageSource.Contains(TestConfiguration.Brand));
        }

        [TearDown]
        public void AfterTest()
        {
            _driver.Quit();
        }

    }
}
