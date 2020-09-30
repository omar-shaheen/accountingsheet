
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Security.Claims;
using ACCOUNTINGSHEET.Model;
namespace ACCOUNTINGSHEET.Helper
{
    public class AuthHelper
    {
              public class UserInfo
        {
            public long Id { get; set; }
            public string UserName { get; set; }
        }
        public static int GetCurrentUserId(ClaimsPrincipal user)
        {
            string userId = user.Claims.LastOrDefault(c => c.Type == "UserId").Value;
            int UserId = 0;
            if (int.TryParse(userId.ToString(), out UserId))
            {
                return UserId;
            }
            else
                throw new UnauthorizedAccessException();
        }

        public static string GetCurrentUserSearchId(ClaimsPrincipal user)
        {
            string searchId = user.Claims.FirstOrDefault(c => c.Type == "SearchId").Value;
            if (!string.IsNullOrEmpty(searchId))
            {
                return searchId;
            }
            else
                throw new Exception();
        }

 /*      public static UserInfo GetCurrentUser(ClaimsPrincipal user, IUserService _userService)
        {
            var userObj = (User)_userService.GetUser(GetCurrentUserId(user)).Data;
            return new UserInfo() { Id = userObj.Id, UserName = userObj.UserName };
        }


        public static User GetCurrentUserById(long id, IUserService _userService)
        {
            return (User)_userService.GetUser(id).Data;
        }
*/        

        public static string GetSignalrUserId(HubConnectionContext connection)
        {
            return connection.User?.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
        }
  
        
    }
}