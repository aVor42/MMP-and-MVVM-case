namespace SuperApi.Models
{
    public class Authorization
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; } 
        public bool IsActive { get; set; }

    }
}
