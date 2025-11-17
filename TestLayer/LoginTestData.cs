using CoreLayer;

namespace TestLayer
{
    public static class LoginTestData
    {
        public static IEnumerable<object[]> Login_WithEmptyCredentials_GetLoginData => new List<object[]>
        {
            new object[] { BrowserType.Chrome, "JohnDoe", "1234" },
            new object[] { BrowserType.Firefox, "JohnDoe", "1234" },
        };

        public static IEnumerable<object[]> Login_WithUsernameOnly_GetLoginData => new List<object[]>
        {
            new object[] { BrowserType.Chrome, "standard_user", "1234" },
            new object[] { BrowserType.Firefox, "standard_user", "1234" },
        };

        public static IEnumerable<object[]> Login_WithValidCredentials_GetLoginData => new List<object[]>
        {
            new object[] { BrowserType.Chrome, "standard_user", "secret_sauce" },
            new object[] { BrowserType.Firefox, "standard_user", "secret_sauce" },
        };

    }
}
