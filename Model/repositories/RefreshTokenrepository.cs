using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCOUNTINGSHEET.Model;
using ACCOUNTINGSHEET.Helper;
namespace ACCOUNTINGSHEET.Model.repositories
{
    public class RefreshTokenrepository : RepositoryBase<RefreshTokens>
    {

        public RefreshTokenrepository(DB_A66DAB_accountingsheetContext _ctx): base(
            _ctx) { 
               this.db=_ctx;
            }
              
      
         public bool AddToken(RefreshTokens token)

         {
              if (token == null)
                return false;   
            //save Data
         try
         {
             RefreshTokens _RefreshToken = new RefreshTokens();
             _RefreshToken.ClientId = token.ClientId;
             _RefreshToken.IssuedUtc = token.IssuedUtc;
             _RefreshToken.RefreshTokenId=token.RefreshTokenId;
             _RefreshToken.ExpiresUtc=token.ExpiresUtc;
             _RefreshToken.UserId=token.UserId;
             _RefreshToken.Subject=token.Subject;
              this.insert(_RefreshToken);
           return true;
            }
            catch (Exception ex)
            {
                // just for use ex to remove warnings
                if(ex == null)
                    return false;
                else
                    return false;
            }
           
         }
        public bool ExpireToken(RefreshTokens token)
        {
            if (token == null)
                return false;
            
            db.RefreshTokens.Update(token);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // just for use ex to remove warnings
                if (ex == null)
                    return false;
                else
                    return false;
            }
        }

        public RefreshTokens GetToken(string refresh_token, string client_id)
        {
            var token = db.RefreshTokens.FirstOrDefault(x => x.RefreshTokenId == refresh_token && x.ClientId == client_id);
            if (token == null)
                return null;
            else
                return token;
        }

        public bool AnyClient(string client_id, string client_secret)
        {
            if (db.Token.Any(x => x.ClientId == client_id
                                    && x.Secret == client_secret))
            {
                return true;
            }
            else return false;
        }

        public void insert(RefreshTokens _Refershtoken)
        {       
            // Console.WriteLine(_Owner.Namear); 
             db.RefreshTokens.Add(_Refershtoken);           
        }
        public RefreshTokens GenerateRefreshTokenModel(string clientId, string clientSecret, string userName, string refreshToken, int userId)
        {
            var client = db.Token.FirstOrDefault(x => x.ClientId == clientId && x.Secret == clientSecret);
            double lifeTime = client.RefreshTokenLifeTime == null ? 30 : (double)client.RefreshTokenLifeTime;
            return new RefreshTokens
            {
                ClientId = clientId,
                Subject = userName,
                RefreshTokenId = refreshToken,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddDays(lifeTime),
                UserId = userId,
                IsDeleted = false
            };
        }

        public bool UpdateLastAccess(int userId)
        {
            var user = db.User.Find(userId);

            user.Updatedat = DateTime.Now;

            db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return true;
        }
           public User GetUserByEmailAndPassword(string email, string password)
        {
            var user = db.User.FirstOrDefault(x => x.Email == email);
            if (user != null && user.Password ==Helper.ComputeHash.ComputeMD5Hash(password))
            {
                return user;
            }
            else
                return null;
        }

    }
}