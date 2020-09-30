using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace ACCOUNTINGSHEET.Helper
{
    public static class Helper
    {
        private static Random random = new Random();
 

        public static ResponseData CreateResponse(string code, string message, object data)
        {
            return new ResponseData()
            {
                Code = code,
                Message = message,
                Data = data
            };
        }

        public static string GenerateRandomPassword()
        {
            //return System.Web.Security.Membership.GeneratePassword(16, 0);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 20)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateVerificationCode()
        {
            return new Random().Next(100000, 10000000).ToString();
        }

        public static string GenerateSearchId(List<string> usersSearchIds)
        {
            const string chars = "0123456789";
            var str = "";
            do
                str = new string(Enumerable.Repeat(chars, 12)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            while (usersSearchIds.Contains(str));
            return str;
        }


       
     


    }
}