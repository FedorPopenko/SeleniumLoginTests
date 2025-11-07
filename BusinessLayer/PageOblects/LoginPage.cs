using CoreLayer.WebDriver;
using log4net;
using OpenQA.Selenium;

namespace BusinessLayer.PageOblects
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly ILog logger;
        private static string Url { get; } = "https://www.saucedemo.com/";
        public LoginPage(IWebDriver driver, ILog logger)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public LoginPage Open()
        {
            logger.Info("Opening login page.");
            driver.Url = Url;
            driver.WaitUntilPageReady();
            return this;
        }

        public LoginPage Username(string username)
        {
            logger.Info("Entering username.");
            var usernameField = driver.WaitUntilVisible(By.XPath("//input[@id='user-name']"));
            usernameField.Clear();
            usernameField.SendKeys(username);
            return this;
        }

        public LoginPage Password(string password)
        {
            logger.Info("Entering password.");
            var passwordField = driver.WaitUntilVisible(By.XPath("//form//input[@type='password']"));
            passwordField.Clear();
            passwordField.SendKeys(password);
            return this;
        }

        public void LoginButtonClick()
        {
            logger.Info("Clicking login button.");
            var loginButton = driver.WaitUntilClickable(By.XPath("//input[@type='submit']"));
            loginButton.Click();
        }

        public void UsernameClear()
        {
            logger.Info("Clearing Username field.");
            var usernameField = driver.WaitUntilClickable(By.XPath("//input[@id='user-name']"));
            usernameField.Click();
            usernameField.SendKeys(Keys.Control + "a");
            usernameField.SendKeys(Keys.Delete);
        }

        public void PasswordClear()
        {
            logger.Info("Clearing Password field.");
            var passwordField = driver.WaitUntilClickable(By.XPath("//form//input[@type='password']"));
            passwordField.Click();
            passwordField.SendKeys(Keys.Control + "a");
            passwordField.SendKeys(Keys.Delete);
        }
    }
}
