
namespace BusinessSolution.DataEntities
{
    public class CreateEpicRequest
    {
        public EpicFields fields { get; set; }
    }

    public class EpicFields
    {
        public Project project { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public Issuetype issuetype { get; set; }
        public string customfield_10102 { get; set; }
    }
}
