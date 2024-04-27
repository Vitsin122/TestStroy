using System.ComponentModel.DataAnnotations.Schema;

namespace ServerASP.Models
{
    public class Position
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }
        public string PositionName { get; set; } = null!;
        public List<Employer>? Employers { get; set; } = new();
    }
}
