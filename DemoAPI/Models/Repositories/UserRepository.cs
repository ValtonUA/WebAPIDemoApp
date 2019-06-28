using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class UserRepository : IRepository<User>
    {
        UserContext db;

        public UserRepository()
        {
            db = new UserContext();
        }

        public void Delete(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public User Get(int id)
        {
            return db.Users.SingleOrDefault(i => i.UserId == id);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public void Post(User item)
        {
            db.Users.Add(item);
        }

        public void Put(User item)
        {
            var user = db.Users.Find(item.UserId);
            if (user != null)
            {
                user.Username = item.Username;
            }
        }

        public void Save()
        { 
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}