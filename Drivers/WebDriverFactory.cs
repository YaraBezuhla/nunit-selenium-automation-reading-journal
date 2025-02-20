namespace nunit_selenium_automation_reading_journal.Drivers
{
    public static class WebDriverFactory
    {
        public static IDriverFactory GetDriverFactory(string browse)
        {
            switch (browse.ToLower())
            {
                case "chrome":
                    return new ChromeDriverFactory();
                case "firefox":
                    return new FirefoxDriverFactrory();
                    default:
                    return new ChromeDriverFactory();
            }
                     
        }
    }
}
