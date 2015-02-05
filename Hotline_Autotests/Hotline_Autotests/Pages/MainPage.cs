using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotline_Autotests.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Hotline_Autotests.Pages
{
    partial class MainPage:IWebPage
    {
        private readonly IWebDriver _currentDriver = TestConfiguration.Driver;
        
        public MainPage()
        {
            PageFactory.InitElements(_currentDriver, this);
        }

        public IWebPage Open(string url)
        {
            _currentDriver.Navigate().GoToUrl(url);

            return new MainPage();
        }

        public IWebPage Refresh()
        {
            _currentDriver.Navigate().Refresh();

            return new MainPage();
        }

        public void Close()
        {
            _currentDriver.Close();
        }

        public SearchResultsPage SearchProduct(String name)
        {
            searchBoxInput.Clear();
            searchBoxInput.SendKeys(name);
            searchButton.Click();

            return new SearchResultsPage();
        }
    }
}
