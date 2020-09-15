
using BusinessSolution.DataEntities;

namespace BusinessSolution.API.RequestBuilders
{
    public class CreateEpicBuilder
    {
        private string _summary;
        private string _description;
        private string _key;
        private string _name;
        private string _customfield_10102;


        public CreateEpicRequest Build()
        {

            Issuetype issueType = new Issuetype
            {
                name = _name
            };

            Project project = new Project
            {
                key = _key
            };

            return new CreateEpicRequest
            {
                fields = new EpicFields
                {
                    project = project,
                    summary = _summary,
                    description = _description,
                    issuetype = issueType,
                    customfield_10102 = _customfield_10102
                }
            };
        }

        public CreateEpicBuilder WithProjectKey(string key)
        {
            _key = key;
            return this;
        }

        public CreateEpicBuilder WithSummary(string summary)
        {
            _summary = summary;
            return this;
        }

        public CreateEpicBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateEpicBuilder WithIssueType(string issueType)
        {
            _name = issueType;
            return this;
        }

        public CreateEpicBuilder WithEpicName(string epicName)
        {
            _customfield_10102 = epicName;
            return this;
        }
    }
}
