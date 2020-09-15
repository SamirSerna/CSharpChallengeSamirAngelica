
using BusinessSolution.DataEntities;

namespace BusinessSolution.API.RequestBuilders
{
    public class AssignEpicToStoryBuilder
    {
        private string _customfield_10100;

        public AssignEpicToStoryRequest Build()
        {
            return new AssignEpicToStoryRequest
            {
                fields = new UpdateFields
                {
                    customfield_10100 = _customfield_10100
                }
            };
        }

        public AssignEpicToStoryBuilder AssignEpic(string epicKey)
        {
            _customfield_10100 = epicKey;
            return this;
        }
    }
}
