
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BusinessSolution.PageObjects
{
    public class DashboardPage : BasePage
    {
        private IWebElement JiraLogo => wait.Until(driver => driver.FindElement(By.Id("jira")));
        private IWebElement ProjectButton => wait.Until(driver => driver.FindElement(By.Id("browse_link")));
        private IWebElement CreateNewProject => wait.Until(driver => driver.FindElement(By.Id("project_template_create_link_lnk")));
        private IWebElement CreateScrumDev => wait.Until(driver => driver.FindElement(By.XPath("//div[@class='template-name']" +
            "[@title='Scrum software development']")));
        private IWebElement NextButton => wait.Until(driver => driver.FindElement(By.XPath("//button[@class='create-project-dialog-create-" +
            "button pt-submit-button aui-button aui-button-primary']")));
        private IWebElement SelectButton => wait.Until(driver => driver.FindElement(By.XPath("//button[@class='template-info-dialog-" +
            "create-button pt-submit-button aui-button aui-button-primary']")));
        private IWebElement NameField => wait.Until(driver => driver.FindElement(By.Id("name")));
        private IWebElement SubmitButton => wait.Until(driver => driver.FindElement(By.XPath("//*[@class='add-project-dialog-create-button pt-submit-button aui-button aui-button-primary'][contains(text(),Submit)]")));
        IWebElement BoardButton => wait.Until(driver => driver.FindElement(By.Id("greenhopper_menu")));
        private IWebElement SpecificBoardButton => wait.Until(driver => driver.FindElement(By.XPath("//a[contains(text(),'" + ConfigKey + "')]")));

        public DashboardPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }


        public bool LogoDisplayed()
        {
            return JiraLogo.Displayed;
        }

        public DashboardPage ClickProjectButton()
        {
            ProjectButton.Click();
            return this;
        }
        public DashboardPage ClickCreateNewProject()
        {
            CreateNewProject.Click();
            return this;
        }

        public DashboardPage ClickTemplate()
        {
            CreateScrumDev.Click();
            return this;
        }
        public DashboardPage ClickNext()
        {
            NextButton.Click();
            return this;
        }
        public DashboardPage ClickSelect()
        {
            SelectButton.Click();
            return this;
        }

        public DashboardPage TypeName()
        {
            NameField.SendKeys(ConfigNameOfProject);
            return this;
        }

        public DashboardPage SubmitProject()
        {
            Thread.Sleep(3000);
            SubmitButton.Click();
            return this;
        }

        public DashboardPage ClickBoardsButton()
        {
            Thread.Sleep(1000);
            BoardButton.Click();
            return this;
        }

        public DashboardPage SelectSpecificBoard()
        {
            SpecificBoardButton.Click();
            return this;
        }


    }
}
