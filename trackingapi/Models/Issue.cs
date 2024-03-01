using System.ComponentModel.DataAnnotations;

namespace trackingapi.Models
{
    public class Issue
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public IssueType IssueType { get; set; }
        private DateTime _created;
        public DateTime Created
        {
            get { return _created; }
            set { _created = value ?? DateTime.Now; }
        }
        public DateTime? Completed { get; set; }
    }

    public enum Priority 
    {
        Low, Medium, High
    }

    public enum IssueType
    {
        Feature, Bug, Documentation
    }
}
