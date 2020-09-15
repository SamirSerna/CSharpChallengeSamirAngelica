using System;
using System.Configuration;
using System.IO;
using BusinessSolution.API.MessageManager.RequestManager;
using BusinessSolution.API.MessageManager.ResponseManager;
using BusinessSolution.API.RequestBuilders;
using BusinessSolution.DataEntities;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;

namespace JiraAPIAutomationTests.Tests.IssuesTests
{
    [TestFixture]
    [AllureNUnit]
    public class IssuesTests
    {
        private readonly string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        private readonly string Username = ConfigurationManager.AppSettings["Username"];
        private readonly string Password = ConfigurationManager.AppSettings["Password"];
        RestClient restClient;
        IssuesRequestManager issuesRequestManager;
        ResponseManager responseManager;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
        }

        [SetUp]
        public void SetUp()
        {
            restClient = new RestClient(BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(Username, Password),
            };
            issuesRequestManager = new IssuesRequestManager(restClient);
            responseManager = new ResponseManager();
        }

        [Test(Description = "GIVEN the user has valid Jira credentials\n\n" +
                            "AND a bug has been created in the backlog\n\n" +
                            "WHEN the user performs the action to move the bug to the current sprint\n\n" +
                            "THEN the bug is displayed in the current sprint board\n\n" +
                            "AND a NoContent response is generated ")]
        public void MoveNewBugToCurrentSprintTest()
        {
            CreateIssueRequest newBug = new CreateIssueBuilder().
                WithProjectKey("TP").
                WithSummary("Bug moved to the current sprint").
                WithDescription("Bug moved to the current sprint").
                WithIssueType("Bug").
                Build();
            string issueKey = issuesRequestManager.GetIssueKey(newBug);
            responseManager.ValidateNoContentResponse(issuesRequestManager.MoveIssueToSprint(issueKey, "1"));
        }

        [Test(Description = "GIVEN the user has valid Jira credentials\n\n" +
                            "AND a bug has been created in the backlog\n\n" +
                            "WHEN the user performs the action to assign the bug to any user\n\n" +
                            "THEN the bug assignee is updated with the selected user\n\n" +
                            "AND a NoContent response is generated ")]
        public void AssignBugToUserTest()
        {
            CreateIssueRequest newBug = new CreateIssueBuilder().
                WithProjectKey("TP").
                WithSummary("Bug assigned to a user").
                WithDescription("Bug assigned to a user").
                WithIssueType("Bug").
                Build();
            string issueKey = issuesRequestManager.GetIssueKey(newBug);
            responseManager.ValidateNoContentResponse(issuesRequestManager.AssignIssueToUser(issueKey, "samir.serna48"));
        }

        [Test(Description = "GIVEN the user has valid Jira credentials\n\n" +
                            "AND a user story has been created in the backlog\n\n" +
                            "AND an epic has been created in the current project\n\n" +
                            "WHEN the user performs the action to relate the epic with the user story\n\n" +
                            "THEN the related epic field in the story is updated with the selected epic\n\n" +
                            "AND a NoContent response is generated ")]
        public void AssingEpicToAStoryTest()
        {
            CreateEpicRequest newEpic = new CreateEpicBuilder().
                WithProjectKey("TP").
                WithSummary("Epic with a related story").
                WithDescription("Epic with a related story").
                WithIssueType("Epic").
                WithEpicName("New epic").
                Build();
            string epicKey = issuesRequestManager.GetEpicKey(newEpic);
            CreateIssueRequest newStory = new CreateIssueBuilder().
                WithProjectKey("TP").
                WithSummary("Story with a related epic").
                WithDescription("Story with a related epic").
                WithIssueType("Story").
                Build();
            string storyKey = issuesRequestManager.GetIssueKey(newStory);
            responseManager.ValidateNoContentResponse(issuesRequestManager.AssignEpicToIssue(storyKey, epicKey));
        }

        [Test(Description = "GIVEN the user has valid Jira credentials\n\n" +
                            "AND a story has been created in the project\n\n" +
                            "WHEN the user performs the action to add a comment into the story\n\n" +
                            "THEN the comment is added into the story comments section\n\n" +
                            "AND a Created response is generated ")]
        public void AddCommentToStoryTest()
        {
            CreateIssueRequest newStory = new CreateIssueBuilder().
                WithProjectKey("TP").
                WithSummary("Story with comment").
                WithDescription("Story with comment").
                WithIssueType("Story").
                Build();
            string issueKey = issuesRequestManager.GetIssueKey(newStory);
            responseManager.ValidateCreatedResponse(issuesRequestManager.AddCommentToIssue(issueKey, "Test comment"));
        }

        [Test(Description = "GIVEN the user has valid Jira credentials\n\n" +
                            "AND a story has been created in the project\n\n" +
                            "AND a bug has been created in the project\n\n" +
                            "WHEN the user performs the action to link the bug with the user story\n\n" +
                            "THEN the bug issue links section is updated with the linked story\n\n" +
                            "AND a Created response is generated ")]
        public void LinkBugToAStoryTest()
        {
            CreateIssueRequest newStory = new CreateIssueBuilder().
                WithProjectKey("TP").
                WithSummary("Story linked to a bug").
                WithDescription("Story linked to a bug").
                WithIssueType("Story").
                Build();
            string storyKey = issuesRequestManager.GetIssueKey(newStory);
            CreateIssueRequest newBug = new CreateIssueBuilder().
                WithProjectKey("TP").
                WithSummary("Bug linked to a story").
                WithDescription("Bug linked to a story").
                WithIssueType("Bug").
                Build();
            string bugKey = issuesRequestManager.GetIssueKey(newBug);
            responseManager.ValidateCreatedResponse(issuesRequestManager.LinkIssues(storyKey, bugKey));
        }

        [Test(Description = "GIVEN the user has valid Jira credentials\n\n" +
                            "AND a bug has been created in the project\n\n" +
                            "WHEN the user performs the action to set the bug priority\n\n" +
                            "THEN the bug priority field is updated with the new value\n\n" +
                            "AND a NoContent response is generated ")]
        public void UpdatePriorityToABug()
        {
            CreateIssueRequest newBug = new CreateIssueBuilder().
                WithProjectKey("TP").
                WithSummary("Bug with assigned priority").
                WithDescription("Bug with assigned priority").
                WithIssueType("Bug").
                Build();
            string bugKey = issuesRequestManager.GetIssueKey(newBug);
            responseManager.ValidateNoContentResponse(issuesRequestManager.UpdateIssuePriority(bugKey, "High"));
        }

        [Test(Description = "GIVEN the user has valid Jira credentials\n\n" +
                            "WHEN the user performs a search filtering issues by user \n\n" +
                            "THEN the list of issues assigned to the selected user are displayed\n\n" +
                            "AND a OK response is generated ")]
        public void GetIssuesAssignedToAUsuer()
        {
            responseManager.ValidateOKResponse(issuesRequestManager.GetIssuesAssignedToAUser("samir.serna48"));
        }
    }
}
