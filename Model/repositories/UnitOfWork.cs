
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace ACCOUNTINGSHEET.Model.repositories
{

public class UnitOfWork : IDisposable
    {
        private DB_A66DAB_accountingsheetContext _ctx = new DB_A66DAB_accountingsheetContext();
        

        public Userrepository Userrepository
        {
            get
            {
                return new Userrepository(_ctx);
            }
        }

         //RefreshTokenrepository  
          public RefreshTokenrepository RefreshTokenrepository
          {
            get
            {
                return new RefreshTokenrepository(_ctx);
            }
          }
           public Projectrepository Projectrepository
          {
            get
            {
                return new Projectrepository(_ctx);
            }
          }

           public contractorrepository contractorrepository
          {
            get
            {
                return new contractorrepository(_ctx);
            }
          }

            public MonthlyInputrepository MonthlyInputrepository
          {
            get
            {
                return new MonthlyInputrepository(_ctx);
            }
          }

          public taskcostsrepository taskcostsrepository{
            get
            {
                return new taskcostsrepository(_ctx);
            }
          }
        
        public int Commit()
        {
            return _ctx.SaveChanges();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(_ctx);
        }

        internal void Update<T>(T entity) where T : class
        {
            _ctx.Entry<T>(entity).State = EntityState.Modified;       
        }
    }

}