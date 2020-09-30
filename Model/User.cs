using System;
using System.Collections.Generic;

namespace ACCOUNTINGSHEET.Model
{
    public partial class User
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshTokens>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool? Active { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Updatedat { get; set; }
        public int? Updatedby { get; set; }
        public string Mobile { get; set; }
        public bool? Mobileactivated { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool? Emailactivated { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RefreshTokens> RefreshTokens { get; set; }
    }
}
