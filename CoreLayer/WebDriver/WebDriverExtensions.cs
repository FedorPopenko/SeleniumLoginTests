using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CoreLayer.WebDriver
{
    public static class WebDriverExtensions
    {
        public static void WaitUntilPageReady(this IWebDriver driver, int timeoutSeconds = 5)
        {
            ArgumentNullException.ThrowIfNull(driver);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(d =>
            {
                var jsExecutor = d as IJavaScriptExecutor;
                var state = jsExecutor?.ExecuteScript("return document.readyState")?.ToString();
                return state == "complete";
            });
        }

        public static IWebElement WaitUntilVisible(this IWebDriver driver, By locator, int timeoutSeconds = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return element.Displayed ? element : null;
            });
        }

        public static IWebElement WaitUntilClickable(this IWebDriver driver, By locator, int timeoutSeconds = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return (element.Displayed && element.Enabled) ? element : null;
            });
        }
    }
}
