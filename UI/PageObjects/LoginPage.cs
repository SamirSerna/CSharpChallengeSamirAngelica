
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BusinessSolution.PageObjects
{
    public class LoginPage : BasePage

    {
        private IWebElement Username => driver.FindElement(By.Id("login-form-username"));
        private IWebElement Password => driver.FindElement(By.Id("login-form-password"));
        private IWebElement LoguinButton => driver.FindElement(By.Id("login"));

        public LoginPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public LoginPage fillUsername()
        {
            Username.SendKeys(ConfigUsername);
            return this;
        }

        public LoginPage fillPassword()
        {
            Password.SendKeys(ConfigPassword);
            return this;
        }

        public LoginPage ClickLogin()
        {
            LoguinButton.Click();
            return this;
        }
    }
}
