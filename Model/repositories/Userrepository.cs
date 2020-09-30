using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCOUNTINGSHEET.Model;
using ACCOUNTINGSHEET.Model.viewmodel;
namespace ACCOUNTINGSHEET.Model.repositories
{
    public class Userrepository :  RepositoryBase<User>
    {
       public Userrepository(DB_A66DAB_accountingsheetContext _ctx): base(_ctx) {
            this.db=_ctx;
        }        public List<User> FetchAll()
        {
            return db.User.OrderByDescending(d => d.Id).ToList<User>();
        }
       

       //FetchByEmailorusername
      
        public User FetchByEmail(string email)
        {
            return db.User.Where(o => o.Email == email).FirstOrDefault();
        }

        //FetchByMobile
         public User FetchByMobile(string mobile)
        {
            return db.User.Where(o => o.Mobile == mobile).FirstOrDefault();
        }

        public User FetchById(int Id)
        {
            return db.User.SingleOrDefault(o => o.Id == Id);
        }

    //    public bool Login (User user)
    //     {
    //         bool SuccessLog = false;
    //          if(db.User.Where(o => o.UserName == user.UserName && o.Password==user.Password).SingleOrDefault()!=null)
    //         { SuccessLog=true;}
    //         return SuccessLog;
    //     }
         public bool insert(User user)
        {
            try
            {
                db.User.Add(user);
                return true;
            }
            catch (System.Exception)
            {
            return false;
            } 
        }

        // /CheckUserRelations
       

    }
}
