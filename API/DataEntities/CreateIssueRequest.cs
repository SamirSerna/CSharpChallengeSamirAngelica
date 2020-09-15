
namespace BusinessSolution.DataEntities
{
    public class CreateIssueRequest
    {
        public Fields fields { get; set; }
    }

    public class Fields
    {
        public Project project { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public Issuetype issuetype { get; set; }
    }

    public class Project
    {
        public string key { get; set; }
    }

    public class Issuetype
    {
        public string name { get; set; }
    }
}
