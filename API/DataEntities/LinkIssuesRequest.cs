
namespace BusinessSolution.DataEntities
{
    public class LinkIssuesRequest
    {
        public LinkType type { get; set; }
        public InwardIssue inwardIssue { get; set; }
        public OutwardIssue outwardIssue { get; set; }
    }

    public class LinkType
    {
        public string name { get; set; }
    }

    public class InwardIssue
    {
        public string key { get; set; }
    }

    public class OutwardIssue
    {
        public string key { get; set; }
    }
}
