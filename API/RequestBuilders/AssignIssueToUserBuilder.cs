
using BusinessSolution.DataEntities;

namespace BusinessSolution.API.RequestBuilders
{
    public class AssignIssueToUserBuilder
    {
        private string _name;

        public AssignIssueToUserRequest Build()
        {
            return new AssignIssueToUserRequest
            {
                name = _name
            };
        }

        public AssignIssueToUserBuilder WithUsername(string username)
        {
            _name = username;
            return this;
        }
    }
}
