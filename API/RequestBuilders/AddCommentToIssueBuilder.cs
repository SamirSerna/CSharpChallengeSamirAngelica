
using BusinessSolution.DataEntities;

namespace BusinessSolution.API.RequestBuilders
{
    public class AddCommentToIssueBuilder
    {
        private string _body;

        public AddCommentToIssueRequest Build()
        {
            return new AddCommentToIssueRequest
            {
                body = _body
            };
        }

        public AddCommentToIssueBuilder WithBody(string comment)
        {
            _body = comment;
            return this;
        }

    }
}
