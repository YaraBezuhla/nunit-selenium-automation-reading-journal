using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace nunit_selenium_automation_reading_journal.Drivers
{
    public class ChromeDriverFactory : IDriverFactory
    {
            public IWebDriver CreateDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }
            
        
    }
}
