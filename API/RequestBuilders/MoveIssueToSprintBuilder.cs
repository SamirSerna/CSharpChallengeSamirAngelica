
using System.Collections.Generic;
using BusinessSolution.DataEntities;

namespace BusinessSolution.API.RequestBuilders
{
    public class MoveIssueToSprintBuilder
    {
        private List<string> _issues;

        public MoveIssueToSprintRequest Build()
        {
            return new MoveIssueToSprintRequest
            {
                issues = _issues
            };
        }

        public MoveIssueToSprintBuilder WithIssueToMove(List<string> issues)
        {
            _issues = issues;
            return this;
        }

    }
}
