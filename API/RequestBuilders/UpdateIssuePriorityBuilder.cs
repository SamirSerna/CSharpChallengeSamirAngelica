
using BusinessSolution.DataEntities;

namespace BusinessSolution.API.RequestBuilders
{
    public class UpdateIssuePriorityBuilder
    {
        private string _name;

        public UpdateIssuePriorityRequest Build()
        {
            Priority _priority = new Priority
            {
                name = _name
            };

            return new UpdateIssuePriorityRequest
            {
                fields = new PriorityField
                {
                    priority = _priority
                }
            };
        }

        public UpdateIssuePriorityBuilder WithPriorityName(string priorityName)
        {
            _name = priorityName;
            return this;
        }
    }
}
