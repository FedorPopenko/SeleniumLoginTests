using CoreLayer.WebDriver;
using log4net;
using OpenQA.Selenium;

namespace BusinessLayer.PageOblects
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly ILog logger;

        private readonly By usernameLocator = By.XPath("//input[@id='user-name']");
        private readonly By passwordLocator = By.XPath("//form//input[@type='password']");
        private readonly By loginBattonLocator = By.XPath("//input[@type='submit']");

        private readonly By errorMessageUsernameLocator = By.XPath("//*[contains(text(),'Username is required')]");
        private readonly By errorMessagePasswordLocator = By.XPath("//*[contains(text(),'Password is required')]");
        private readonly By mainPageLocator = By.XPath("//div[contains(text(),'Swag Labs')]");

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
            var usernameField = driver.WaitUntilVisible(usernameLocator);
            usernameField.Clear();
            usernameField.SendKeys(username);
            return this;
        }

        public LoginPage Password(string password)
        {
            logger.Info("Entering password.");
            var passwordField = driver.WaitUntilVisible(passwordLocator);
            passwordField.Clear();
            passwordField.SendKeys(password);
            return this;
        }

        public void LoginButtonClick()
        {
            logger.Info("Clicking login button.");
            var loginButton = driver.WaitUntilClickable(loginBattonLocator);
            loginButton.Click();
        }

        public void FieldClear(By locator)
        {
            var element = driver.WaitUntilClickable(locator);
            element.Click();
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
        }

        public void UsernameClear()
        {
            logger.Info("Clearing Username field.");
            FieldClear(usernameLocator);
        }

        public void PasswordClear()
        {
            logger.Info("Clearing Password field.");
            FieldClear(passwordLocator);
        }

        public bool IsUsernameRequiredErrorDisplayed()
        {
            logger.Info("Checking username required error.");
            return driver.WaitUntilVisible(errorMessageUsernameLocator).Displayed;
        }

        public bool IsPasswordRequiredErrorDisplayed()
        {
            logger.Info("Checking password required error.");
            return driver.WaitUntilVisible(errorMessagePasswordLocator).Displayed;
        }

        public bool IsMainPageDisplayed()
        {
            logger.Info("Checking if main page is opened.");
            return driver.WaitUntilVisible(mainPageLocator).Displayed;
        }
    }
}
