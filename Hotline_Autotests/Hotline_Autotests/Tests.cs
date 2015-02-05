using System;
using Hotline_Autotests.Helpers;
using Hotline_Autotests.Pages;
using NLog;
using NLog.Fluent;
using NUnit.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Hotline_Autotests
{
    [TestFixture]
    public class Tests
    {
        private String _url;
        private IWebDriver _driver;
        private static readonly NLog.Logger logger = LogManager.GetLogger("MyLogger");
        private String message = "No message";
        private String stackTrace = "No information";

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

            try
            {
                Assert.True(_driver.Url.Contains("hotline"));
            }
            catch (Exception ex)
            {
                Exception NewEx = new Exception("Current Url is not valid.", ex);
                message = NewEx.Message;
                stackTrace = ex.StackTrace;
                throw;
            }


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
            //log results
            if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
            {
                logger.Warn("Test <{0}> was FAILED. Message: {1}.\n StackTrace: {2}", TestContext.CurrentContext.Test.Name, message, stackTrace);
            }
            else if (TestContext.CurrentContext.Result.Status == TestStatus.Passed)
            {
                logger.Warn("Test <{0}> was Passed. Message: {1}", TestContext.CurrentContext.Test.Name, message);
            }

            _driver.Quit();
        }

    }
}
