using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinExplorer.Models
{
    public class EmployeeModel : ModelBase
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
