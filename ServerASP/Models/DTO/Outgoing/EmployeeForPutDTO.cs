namespace ServerASP.Models.DTO.Outgoing
{
    public class EmployeeForPutDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }
    }
}
