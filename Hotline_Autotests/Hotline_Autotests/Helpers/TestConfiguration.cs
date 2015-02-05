using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;

namespace Hotline_Autotests.Helpers
{
    static class TestConfiguration
    {
        public static readonly IWebDriver Driver = SetDriver();
        public static String ProductType
        {
            get { return ConfigurationManager.AppSettings.Get("ProductType"); }
        }
        public static String Brand
        {
            get { return ConfigurationManager.AppSettings.Get("Brand"); }
        }

        /*public static String GetUrl(String filePath)
        {
            String uri = "";
            XmlTextReader myXMLReader = new XmlTextReader(filePath);

            while (myXMLReader.Read())
            {
                if (myXMLReader.NodeType==XmlNodeType.Element)
                {
                    if (myXMLReader.Name=="Url")
                    {
                        uri = myXMLReader.GetAttribute("value");
                    }
                    
                }

            }

            return uri;
        }*/

        public static String GetUrl()
        {
            return ConfigurationManager.AppSettings.Get("URL");
        }

        public static IWebDriver GetDriver()
        {   
            return Driver;
        }

        public static IWebDriver SetDriver()
        {
            IWebDriver driver = null;

            switch (ConfigurationManager.AppSettings.Get("browser"))
            {
                case "firefox": driver = new FirefoxDriver();
                    break;
                case "chrome": driver = new ChromeDriver();
                    break;
                case "ie": driver = new InternetExplorerDriver();
                    break;
            }

            return driver;
        }
    }
}
