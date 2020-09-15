
using System.Threading;
using BusinessSolution.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace BusinessSolution.PageObjects
{
    public class BoardPage : BasePage
    {
        private Actions actions;
        private IWebElement CreateSprintButton => wait.Until(driver => driver.FindElement(By.XPath("//button[@class='js-add-sprint aui-button']")));
        private IWebElement SprintName => wait.Until(driver => driver.FindElement(By.Id("ghx-sprint-name")));
        /*private IWebElement CreateTheSprintButton => wait.Until(driver => driver.FindElement(By.XPath("//button[@class='aui-button aui-button-" +
            "primary ghx-add-sprint-button']")));*/
        private IWebElement CreateTheSprintButton => wait.Until(driver => driver.FindElement(By.XPath("//button[@class='js-add-sprint aui-button']")));
        private IWebElement CreateIssueButton => wait.Until(driver => driver.FindElement(By.XPath("(//span[contains(text(), 'Create issue')])[2]")));
        private IWebElement TypeNeedToBeDone => wait.Until(driver => driver.FindElement(By.XPath("(//textarea[@placeholder='What needs to be done?'])[2]")));
        private IWebElement OpenInDialogButton => wait.Until(driver => driver.FindElement(By.XPath("(//button[@original-title='Open in dialog'])[2]")));
        private IWebElement CreateTheIssueButton => wait.Until(driver => driver.FindElement(By.Id("create-issue-submit")));
        private IWebElement Issue => wait.Until(driver => driver.FindElement(By.ClassName("ghx-row")));
        //private IWebElement SendToSprint => wait.Until(driver => driver.FindElement(By.XPath("(//a[contains(text(), '')])[2]")));
        private IWebElement SendToSprint => wait.Until(driver => driver.FindElement(By.XPath("//a[contains(@id, 'ghx-issue-ctx-action-send-to-sprint')]")));
        private IWebElement StartSprintButton => wait.Until(driver => driver.FindElement(By.XPath("//button[@class='js-sprint-start aui-button aui-button-primary']")));
        private IWebElement StartButton => wait.Until(driver => driver.FindElement(By.XPath("(//button[@class='button-panel-button aui-button'][contains(text(), 'Start')])")));
        private IWebElement ToDoColumn => wait.Until(driver => driver.FindElement(By.XPath("(//li[@class = 'ghx-column ui-sortable'])[1]")));
        private IWebElement InProgressColumn => wait.Until(driver => driver.FindElement(By.XPath("(//li[@class = 'ghx-column ui-sortable'])[2]")));
        private IWebElement DoneColumn => wait.Until(driver => driver.FindElement(By.XPath("(//li[@class = 'ghx-column ui-sortable'])[3]")));
        private IWebElement NameOfProject => wait.Until(driver => driver.FindElement(By.Id("ghx-board-name")));
        private IWebElement SprintCreated => wait.Until(driver => driver.FindElement(By.XPath("//div[@class='aui-message closeable aui-message-success aui-will-close']")));
        private IWebElement SprintStarted => wait.Until(driver => driver.FindElement(By.XPath("//span[@class='subnavigator-title']")));
        public BoardPage(IWebDriver driver, WebDriverWait wait, Actions actions) : base(driver, wait)
        {
            actions = new Actions(driver);
            this.actions = actions;
        }

        public bool VerifyNameOfProject()
        {
            return NameOfProject.Displayed;
        }

        public bool VerifySprintHasBeenCreated()
        {

            return SprintCreated.Displayed;
        }

        public bool VerifySprintHasBeenStarted()
        {

            return SprintStarted.Displayed;
        }
        public BoardPage ClickCreateSprint()
        {
            Thread.Sleep(3000);
            CreateSprintButton.Click();
            return this;
        }

        public BoardPage TypeSprintName()
        {
            SprintName.SendKeys(ConfigNameOfSprint);
            return this;
        }

        public BoardPage ClickCreateTheSprintButtton()
        {
            CreateTheSprintButton.Click();
            return this;
        }

        public BoardPage ClickCreateIssueButton()
        {
            CreateIssueButton.Click();
            return this;
        }

        public BoardPage TypeWhatNeedToBeDone()
        {
            TypeNeedToBeDone.SendKeys(ConfigNameOfTest);
            return this;
        }

        public BoardPage ClickOpenInDialogButton()
        {
            OpenInDialogButton.Click();
            return this;
        }

        public BoardPage ClickCreateTheIssueButton()
        {
            CreateTheIssueButton.Click();
            return this;
        }

        public BoardPage RightClickInIssue()
        {
            actions.ContextClick(Issue);
            actions.Perform();
            return this;
        }

        public BoardPage ClickInSendToSprint()
        {
            SendToSprint.Click();
            return this;
        }

        public BoardPage ClickStartSprintButton()
        {
            StartSprintButton.Click();
            return this;
        }

        public BoardPage ClickStartButton()
        {
            StartButton.Click();
            return this;
        }

        public BoardPage MoveIssueFromToDoToInProgress()
        {
            DragAndDrop _drag = new DragAndDrop();
            IWebElement ElementToBeMOved = wait.Until(driver => driver.FindElement(By.XPath("//div[contains(@class,'js-detailview ghx-issue js-issue ghx-has-avatar js-parent-drag')]")));
            IWebElement InProgressColumn = wait.Until(driver => driver.FindElement(By.XPath("(//li[@class = 'ghx-column ui-sortable'])[2]")));
            _drag.MoveAnElement(ElementToBeMOved, InProgressColumn, actions);
            return this;
        }
        public BoardPage MoveIssueFromInProgressToToDo()
        {     
            bool staleElement = true;
            int attemps = 0;
            while (staleElement && attemps <= 20)
            {
                DragAndDrop _drag = new DragAndDrop();
                try
                {
                    IWebElement ElementToBeMOved = wait.Until (driver => driver.FindElement(By.XPath("//*[@role='listitem']")));
                    IWebElement DoneColumn = wait.Until(driver => driver.FindElement(By.XPath("(//li[@class = 'ghx-column ui-sortable'])[3]")));
                    _drag.MoveAnElement(ElementToBeMOved, DoneColumn, actions);                    
                    staleElement = false;
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                    attemps++;
                }
            }
            return this;
        }
    }
}
