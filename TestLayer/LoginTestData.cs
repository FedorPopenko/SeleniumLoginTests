using CoreLayer;

namespace TestLayer
{
    public static class LoginTestData
    {
        public static IEnumerable<object[]> UnitTest1_GetLoginData => new List<object[]>
        {
            new object[] { BrowserType.Chrome, "JohnDoe", "1234" },
            new object[] { BrowserType.Firefox, "JohnDoe", "1234" },
        };

        public static IEnumerable<object[]> UnitTest2_GetLoginData => new List<object[]>
        {
            new object[] { BrowserType.Chrome, "standard_user", "1234" },
            new object[] { BrowserType.Firefox, "standard_user", "1234" },
        };

        public static IEnumerable<object[]> UnitTest3_GetLoginData => new List<object[]>
        {
            new object[] { BrowserType.Chrome, "standard_user", "secret_sauce" },
            new object[] { BrowserType.Firefox, "standard_user", "secret_sauce" },
        };

    }
}
