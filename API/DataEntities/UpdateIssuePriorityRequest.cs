
namespace BusinessSolution.DataEntities
{
    public class UpdateIssuePriorityRequest
    {
        public PriorityField fields { get; set; }
    }

    public class PriorityField
    {
        public Priority priority { get; set; }
    }

    public class Priority
    {
        public string name { get; set; }
    }
}
