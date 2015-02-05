using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Hotline_Autotests.Pages
{
    partial class MainPage
    {
        [FindsBy(How = How.Id, Using = "searchbox")]
        private IWebElement searchBoxInput;

        [FindsBy(How = How.Id, Using = "doSearch")]
        private IWebElement searchButton;
    }
}
