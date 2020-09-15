
using BusinessSolution.DataEntities;

namespace BusinessSolution.API.RequestBuilders
{
    public class CreateIssueBuilder
    {
        private string _summary;
        private string _description;
        private string _key;
        private string _name;


        public CreateIssueRequest Build()
        {

            Issuetype issueType = new Issuetype
            {
                name = _name
            };

            Project project = new Project
            {
                key = _key
            };

            return new CreateIssueRequest
            {
                fields = new Fields
                {
                    project = project,
                    summary = _summary,
                    description = _description,
                    issuetype = issueType
                }
            };
        }

        public CreateIssueBuilder WithProjectKey(string key)
        {
            _key = key;
            return this;
        }

        public CreateIssueBuilder WithSummary(string summary)
        {
            _summary = summary;
            return this;
        }

        public CreateIssueBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateIssueBuilder WithIssueType(string issueType)
        {
            _name = issueType;
            return this;
        }
    }
}
