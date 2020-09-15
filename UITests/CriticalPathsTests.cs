
using BusinessSolution.PageObjects;
using CSharpChallengeAngelicaSamir.Hooks;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace CSharpChallengeAngelicaSamir.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class CriticalPathsTests : DriverSetUp
    {

        [Test(Description = "A user logged into Jira is able to create a new project and into it a new Sprint.\n\n " +
                            "In Backlog section user is able to create a new issue and move\n\n" +
                            "it to the sprint created and the start this sprint to see the issue in To Do.")]
        public void JiraAllowsToCreateANewProject()
        {
            var loginPage = new LoginPage(_driver, _wait);
            loginPage
                .fillUsername()
                .fillPassword()
                .ClickLogin();
            var dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage
                .ClickProjectButton()
                .ClickCreateNewProject()
                .ClickTemplate()
                .ClickNext()
                .ClickSelect()
                .TypeName()
                .SubmitProject();
            var board = new BoardPage(_driver, _wait, _actions);
            board
                .ClickCreateSprint()
                //.TypeSprintName()
                //.ClickCreateTheSprintButtton();
                //board    
                .ClickCreateIssueButton()
                .TypeWhatNeedToBeDone()
                .ClickOpenInDialogButton()
                .ClickCreateTheIssueButton()
                .RightClickInIssue()
                .ClickInSendToSprint()
                .ClickStartSprintButton()
                .ClickStartButton();
            Assert.IsTrue(board.VerifySprintHasBeenStarted());
        }

        [Test(Description = "A user logged into Jira is able to move an issue between a \n\n" +
                            "Sprint from To Do column to In Progress column and then to Done column")]
        public void JiraAllowsToMoveAnIssue()
        {
            var loginPage = new LoginPage(_driver, _wait);
            loginPage
                .fillUsername()
                .fillPassword()
                .ClickLogin();

            var dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage
                .ClickBoardsButton()
                .SelectSpecificBoard();

            var board = new BoardPage(_driver, _wait, _actions);
            board
                .MoveIssueFromToDoToInProgress()
                .MoveIssueFromInProgressToToDo();
        }

    }
}
