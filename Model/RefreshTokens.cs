using System;
using System.Collections.Generic;

namespace ACCOUNTINGSHEET.Model
{
    public partial class RefreshTokens
    {
        public string RefreshTokenId { get; set; }
        public string Subject { get; set; }
        public string ClientId { get; set; }
        public DateTime? IssuedUtc { get; set; }
        public DateTime? ExpiresUtc { get; set; }
        public int? UserId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Token Client { get; set; }
        public virtual User User { get; set; }
    }
}
