namespace StaffManagementSystem.Web.Models
{
    public class ResultError
    {
        public Dictionary<string, string[]> errors { get; set; }
        public int status { get; set; }
        public string? title { get; set; }
        public string? type { get; set; }
    }
}
