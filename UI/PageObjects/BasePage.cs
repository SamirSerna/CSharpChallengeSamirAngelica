
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BusinessSolution.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected readonly string ConfigUsername = ConfigurationManager.AppSettings["Username"];
        protected readonly string ConfigPassword = ConfigurationManager.AppSettings["Password"];
        protected readonly string ConfigNameOfProject = ConfigurationManager.AppSettings["NameOfProject"];
        protected readonly string ConfigNameOfSprint = ConfigurationManager.AppSettings["NameOfSprint"];
        protected readonly string ConfigNameOfTest = ConfigurationManager.AppSettings["NameOfTest"];
        protected readonly string ConfigKey = ConfigurationManager.AppSettings["KeyOfProject"];

        public BasePage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
    }
}
