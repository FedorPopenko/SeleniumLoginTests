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
    public class TestBase
    {
        public required ILog Logger { get; set; }
        public IWebDriver Init(BrowserType browserType, string testName)
        {
            string browser = browserType.ToString();
            Logger = LoggingConfig.Configure(browser, testName);
            Logger.Info($"Starting test: {testName}");
            return WebDriverFactory.Create(browserType);
        }
    }
    public class Login_WithEmptyCredentials : TestBase
    {
        [Theory]
        [MemberData(nameof(LoginTestData.Login_WithEmptyCredentials_GetLoginData), MemberType = typeof(LoginTestData))]
        public void GivenEmptyCredentials_WhenUserTriesToLogin_ThenErrorMessageIsDisplayed(BrowserType browserType, string username, string password)
        {
            //Arrange
            using var driver = Init(browserType, GetType().Name);
            var loginPage = new LoginPage(driver, Logger);
            //Act
            loginPage.Open()
                     .Username(username)
                     .Password(password)
                     .UsernameClear();
            loginPage.PasswordClear();
            loginPage.LoginButtonClick();
            //Assert
            var errorMessage = loginPage.IsUsernameRequiredErrorDisplayed();
            errorMessage.Should().BeTrue("Because the username field is required and the error should be visible");
        }
    }
    public class Login_WithUsernameOnly : TestBase
    {
        [Theory]
        [MemberData(nameof(LoginTestData.Login_WithUsernameOnly_GetLoginData), MemberType = typeof(LoginTestData))]
        public void GivenUsernameOnly_WhenLoginAttempted_ThenPasswordErrorDisplayed(BrowserType browserType, string username, string password)
        {
            //Arrange
            using var driver = Init(browserType, GetType().Name);
            var loginPage = new LoginPage(driver, Logger);
            //Act
            loginPage.Open()
                     .Username(username)
                     .Password(password)
                     .PasswordClear();
            loginPage.LoginButtonClick();
            //Assert
            var errorMessage = loginPage.IsPasswordRequiredErrorDisplayed();
            errorMessage.Should().BeTrue("Because the password field is required and the error should be visible");
        }
    }

    public class Login_WithValidCredentials : TestBase
    {
        [Theory]
        [MemberData(nameof(LoginTestData.Login_WithValidCredentials_GetLoginData), MemberType = typeof(LoginTestData))]
        public void GivenValidCredentials_WhenUserLogsIn_ThenUserIsRedirectedToMainPage(BrowserType browserType, string username, string password)
        {
            //Arrange
            using var driver = Init(browserType, GetType().Name);
            var loginPage = new LoginPage(driver, Logger);
            //Act
            loginPage.Open()
                     .Username(username)
                     .Password(password)
                     .LoginButtonClick();
            //Assert
            var mainPage = loginPage.IsMainPageDisplayed();
            mainPage.Should().BeTrue("Because the user should be redirected to the main page after valid login");
        }
    }
}