using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinExplorer.Models
{
    public enum GenderType
    {
        Male,
        Female
    }

    public class RegisterModel : ModelBase
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool AcceptToTerm { get; set; }
        public GenderType Gender { get; set; }
        //public string State { get; set; }

        public SelectListItemModel State { get; set; }
    }
}
