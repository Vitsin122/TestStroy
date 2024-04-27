namespace ServerASP.Models.DTO.Incoming
{
    public class EmployerPostDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }
    }
}
