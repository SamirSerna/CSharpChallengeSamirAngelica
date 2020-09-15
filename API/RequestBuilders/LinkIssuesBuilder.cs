
using BusinessSolution.DataEntities;

namespace BusinessSolution.API.RequestBuilders
{
    public class LinkIssuesBuilder
    {
        private string _name;
        private string _inwardIssueKey;
        private string _outwardIssueKey;

        public LinkIssuesRequest Build()
        {
            LinkType _type = new LinkType
            {
                name = _name
            };

            InwardIssue _inwardIssue = new InwardIssue
            {
                key = _inwardIssueKey
            };

            OutwardIssue _outwardIssue = new OutwardIssue
            {
                key = _outwardIssueKey
            };

            return new LinkIssuesRequest
            {
                type = _type,
                inwardIssue = _inwardIssue,
                outwardIssue = _outwardIssue,
            };
        }

        public LinkIssuesBuilder WithType(string name)
        {
            _name = name;
            return this;
        }

        public LinkIssuesBuilder WithInwardIssue(string key)
        {
            _inwardIssueKey = key;
            return this;
        }

        public LinkIssuesBuilder WithOutwardIssue(string key)
        {
            _outwardIssueKey = key;
            return this;
        }
    }
}
