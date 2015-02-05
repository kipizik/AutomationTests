using System;
using TechTalk.SpecFlow;

namespace Hotline_Autotests
{
    [Binding]
    public class SpecFlowFeature1Steps
    {   
        [Given]
        public void Given_I_have_entered_valid_URL(String url)
        {
            
        }
       
        [Then]
        public void Then_the_main_page_is_opened()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
