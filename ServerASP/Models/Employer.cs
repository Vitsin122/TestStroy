namespace ServerASP.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Lastname { get; set; }
        public DateTime? Birthday { get; set; }
        public short PositionId { get; set; }
        public Position? Position { get; set; }
        public int Salary { get; set; }
        public bool isActive { get; set; }
    }
}
