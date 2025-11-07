
## Task Description
Launch URL: https://www.saucedemo.com/  

Provide parallel execution, add logging for tests and use Data Provider to parametrize tests.
Make sure that all tasks are supported by these 3 conditions: UC-1; UC-2; UC-3.

### To perform the task use the various of additional options:
1. Test Automation tool: Selenium WebDriver;
2. Browsers: 1) Firefox; 2) Chrome;
3. Locators: XPath;
4. Test Runner: xUnit;
5. [Optional] Patterns: 1) Singleton; 2) Adapter; 3) Strategy;
6. [Optional] Test automation approach: BDD;
7. Assertions: Fluent Assertion;
8. [Optional] Loggers: SeriLog.

### UC-1: est Login form with empty credentials
1. Type any credentials into "Username" and "Password" fields
2. Clear the inputs.
3. Hit the "Login" button.  
4. Check the error messages: "Username is required".

### UC-2: Test Login form with credentials by passing Username
1. Type any credentials in username. 
2. Enter password. 
3. Clear the "Password" input.
4. Hit the "Login" button. 
5. Check the error messages: "Password is required".

### UC-3: Test Login form with credentials by passing Username & Password:
1. Type credentials in username which are under Accepted username are sections. 
2. Enter password as secret sauce. 
3. Click Login.  
4. Validate the title “Swag Labs” in the dashboard.

---

## Technologies and Tools
| Component | Description |
|------------|-------------|
| **Language** | C# |
| **Framework** | xUnit |
| **Automation Tool** | Selenium WebDriver |
| **Assertions** | FluentAssertions |
| **Logging** | Log4Net |
| **Browsers** | Chrome, Firefox |
| **Locators** | XPath |
| **Parallel Execution** | Enabled |
| **Design Patterns** | Page Object, Data Provider |
| **Helpers** | `WebDriverExtensions` for waits and readiness checks |

