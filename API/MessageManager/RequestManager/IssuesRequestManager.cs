
using System.Collections.Generic;
using System.Configuration;
using BusinessSolution.API.RequestBuilders;
using BusinessSolution.DataEntities;
using Newtonsoft.Json;
using RestSharp;

namespace BusinessSolution.API.MessageManager.RequestManager
{
    public class IssuesRequestManager
    {
        private readonly string CreateIssueEndpoint = ConfigurationManager.AppSettings["CreateIssueEndpoint"];
        private readonly string MoveIssueToSprintEndpoint = ConfigurationManager.AppSettings["MoveIssueToSprintEndpoint"];
        private readonly string LinkIssuesEndpoint = ConfigurationManager.AppSettings["LinkIssuesEndpoint"];
        private readonly string FindUserEndpoint = ConfigurationManager.AppSettings["FindUserEndpoint"];
        RestClient _restClient;

        public IssuesRequestManager(RestClient restClient)
        {
            _restClient = restClient;
        }

        public string GetIssueKey(CreateIssueRequest issueRequestBody)
        {
            RestRequest createIssueRequest = new RestRequest(CreateIssueEndpoint);
            createIssueRequest.AddHeader("Content-Type", "application/json");
            createIssueRequest.AddJsonBody(issueRequestBody);
            string requestContent = _restClient.Post(createIssueRequest).Content;
            return JsonConvert.DeserializeObject<CreateIssueResponse>(requestContent).key;
        }

        public string GetEpicKey(CreateEpicRequest epicRequestBody)
        {
            RestRequest createEpicRequest = new RestRequest(CreateIssueEndpoint);
            createEpicRequest.AddHeader("Content-Type", "application/json");
            createEpicRequest.AddJsonBody(epicRequestBody);
            string requestContent = _restClient.Post(createEpicRequest).Content;
            return JsonConvert.DeserializeObject<CreateIssueResponse>(requestContent).key;
        }

        public IRestResponse MoveIssueToSprint(string issueToMove, string sprintCode)
        {
            List<string> issues = new List<string>();
            issues.Add(issueToMove);
            RestRequest moveIssueToSprintRequest = new RestRequest(MoveIssueToSprintEndpoint);
            MoveIssueToSprintRequest body = new MoveIssueToSprintBuilder()
                .WithIssueToMove(issues)
                .Build();
            moveIssueToSprintRequest.AddHeader("Content-Type", "application/json");
            moveIssueToSprintRequest.AddParameter("sprintId", sprintCode, ParameterType.UrlSegment);
            moveIssueToSprintRequest.AddJsonBody(body);
            return _restClient.Post(moveIssueToSprintRequest);
        }

        public IRestResponse AssignEpicToIssue(string issueToUpdate, string epicKey)
        {
            RestRequest assignEpicToIssueRequest = new RestRequest(CreateIssueEndpoint + issueToUpdate);
            AssignEpicToStoryRequest body = new AssignEpicToStoryBuilder()
                .AssignEpic(epicKey)
                .Build();
            assignEpicToIssueRequest.AddHeader("Content-Type", "application/json");
            assignEpicToIssueRequest.AddJsonBody(body);
            return _restClient.Put(assignEpicToIssueRequest);
        }

        public IRestResponse AssignIssueToUser(string issueToAssign, string username)
        {
            RestRequest assignIssueToUserRequest = new RestRequest(CreateIssueEndpoint + issueToAssign + "/assignee");
            AssignIssueToUserRequest body = new AssignIssueToUserBuilder()
                .WithUsername(username)
                .Build();
            assignIssueToUserRequest.AddHeader("Content-Type", "application/json");
            assignIssueToUserRequest.AddJsonBody(body);
            return _restClient.Put(assignIssueToUserRequest);
        }

        public IRestResponse AddCommentToIssue(string issueKey, string comment)
        {
            RestRequest addCommentToIssueRequest = new RestRequest(CreateIssueEndpoint + issueKey + "/comment");
            AddCommentToIssueRequest body = new AddCommentToIssueBuilder()
                .WithBody(comment)
                .Build();
            addCommentToIssueRequest.AddHeader("Content-Type", "application/json");
            addCommentToIssueRequest.AddJsonBody(body);
            return _restClient.Post(addCommentToIssueRequest);
        }

        public IRestResponse LinkIssues(string inwardIssueKey, string outwardIssueKey)
        {
            RestRequest linkIssuesRequest = new RestRequest(LinkIssuesEndpoint);
            LinkIssuesRequest body = new LinkIssuesBuilder()
                .WithType("Duplicate")
                .WithInwardIssue(inwardIssueKey)
                .WithOutwardIssue(outwardIssueKey)
                .Build();
            linkIssuesRequest.AddHeader("Content-Type", "application/json");
            linkIssuesRequest.AddJsonBody(body);
            return _restClient.Post(linkIssuesRequest);
        }

        public IRestResponse UpdateIssuePriority(string issueKey, string priorityName)
        {
            RestRequest updateIssuePriorityRequest = new RestRequest(CreateIssueEndpoint + issueKey);
            UpdateIssuePriorityRequest body = new UpdateIssuePriorityBuilder()
                .WithPriorityName(priorityName)
                .Build();
            updateIssuePriorityRequest.AddHeader("Content-Type", "application/json");
            updateIssuePriorityRequest.AddJsonBody(body);
            return _restClient.Put(updateIssuePriorityRequest);
        }

        public IRestResponse GetIssuesAssignedToAUser(string username)
        {
            RestRequest getIssuesAssignedToAUserRequest = new RestRequest(FindUserEndpoint);
            getIssuesAssignedToAUserRequest.AddHeader("Content-Type", "application/json");
            getIssuesAssignedToAUserRequest.AddQueryParameter("jql=assignee", username);
            var response = _restClient.Get(getIssuesAssignedToAUserRequest);
            return response;
        }
    }
}
