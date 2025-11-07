using BusinessLayer.Config;
using BusinessLayer.PageOblects;
using CoreLayer;
using CoreLayer.WebDriver;
using FluentAssertions;
using log4net;
using OpenQA.Selenium;

[assembly: CollectionBehavior(DisableTestParallelization = false, MaxParallelThreads = 3)]

namespace TestLayer
{
    public class UnitTest1
    {
        [Theory]
        [MemberData(nameof(LoginTestData.UnitTest1_GetLoginData), MemberType = typeof(LoginTestData))]
        public void GivenEmptyCredentials_WhenUserTriesToLogin_ThenErrorMessageIsDisplayed(BrowserType browserType, string username, string password)
        {
            string browser = browserType.ToString();
            string testClass = GetType().Name;
            ILog logger = LoggingConfig.Configure(browser, testClass);
            logger.Info("Starting test: Login_WithEmptyCredentials");

            //Arrange
            using var driver = WebDriverFactory.Create(browserType);
            var loginPage = new LoginPage(driver, logger);
            //Act
            loginPage.Open()
                     .Username(username)
                     .Password(password)
                     .UsernameClear();
            loginPage.PasswordClear();
            loginPage.LoginButtonClick();
            //Assert
            var errorMessage = driver.FindElement(By.XPath("//*[contains(text(),'Username is required')]"));
            errorMessage.Displayed
                        .Should().BeTrue("Because the username field is required and the error should be visible");

            logger.Info("Test passed");
        }
    }
    public class UnitTest2
    {
        [Theory]
        [MemberData(nameof(LoginTestData.UnitTest2_GetLoginData), MemberType = typeof(LoginTestData))]
        public void GivenUsernameOnly_WhenLoginAttempted_ThenPasswordErrorDisplayed(BrowserType browserType, string username, string password)
        {
            string browser = browserType.ToString();
            string testClass = GetType().Name;
            ILog logger = LoggingConfig.Configure(browser, testClass);
            logger.Info("Starting test: Login_WithUsernameOnly");

            //Arrange
            using var driver = WebDriverFactory.Create(browserType);
            var loginPage = new LoginPage(driver, logger);
            //Act
            loginPage.Open()
                     .Username(username)
                     .Password(password)
                     .PasswordClear();
            loginPage.LoginButtonClick();
            //Assert
            var errorMessage = driver.FindElement(By.XPath("//*[contains(text(),'Password is required')]"));
            errorMessage.Displayed
                        .Should().BeTrue("Because the password field is required and the error should be visible");

            logger.Info("Test passed");
        }
    }

    public class UnitTest3
    {
        [Theory]
        [MemberData(nameof(LoginTestData.UnitTest3_GetLoginData), MemberType = typeof(LoginTestData))]
        public void GivenValidCredentials_WhenUserLogsIn_ThenUserIsRedirectedToMainPage(BrowserType browserType, string username, string password)
        {
            string browser = browserType.ToString();
            string testClass = GetType().Name;
            ILog logger = LoggingConfig.Configure(browser, testClass);
            logger.Info("Starting test: Login_WithValidCredentials");

            //Arrange
            using var driver = WebDriverFactory.Create(browserType);
            var loginPage = new LoginPage(driver, logger);
            //Act
            loginPage.Open()
                     .Username(username)
                     .Password(password)
                     .LoginButtonClick();
            //Assert
            var mainPage = driver.FindElement(By.XPath("//div[contains(text(),'Swag Labs')]"));
            mainPage.Displayed
                    .Should().BeTrue("Because the user should be redirected to the main page after valid login");

            logger.Info("Test passed");
        }
    }
}