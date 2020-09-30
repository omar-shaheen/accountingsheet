using System;
using System.Collections.Generic;

namespace ACCOUNTINGSHEET.Model
{
    public partial class Token
    {
        public Token()
        {
            RefreshTokens = new HashSet<RefreshTokens>();
        }

        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }
        public bool? ApplicationType { get; set; }
        public bool? Active { get; set; }
        public int? RefreshTokenLifeTime { get; set; }
        public string AllowedOrigin { get; set; }

        public virtual ICollection<RefreshTokens> RefreshTokens { get; set; }
    }
}
