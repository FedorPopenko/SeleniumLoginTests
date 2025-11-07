using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace CoreLayer.WebDriver
{
    public static class WebDriverFactory
    {
        public static IWebDriver Create(BrowserType browserType)
        {
            IWebDriver driver = browserType switch
            {
                BrowserType.Chrome => new ChromeDriver(),
                BrowserType.Firefox => new FirefoxDriver(),
                _ => throw new ArgumentOutOfRangeException(nameof(browserType))
            };

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            return driver;
        }
    }
}
