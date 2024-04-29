using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    public class EmployeeGetDTO
    {
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string PositionName { get; set; }
        public bool IsActive { get; set; }
    }
}
