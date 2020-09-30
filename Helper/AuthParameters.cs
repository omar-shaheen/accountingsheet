namespace ACCOUNTINGSHEET
{
   public class AuthParameters
    {
        public string grant_type { get; set; }
        public string refresh_token { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string customerid { get; set;}
        public string email { get; set; }

    }
}