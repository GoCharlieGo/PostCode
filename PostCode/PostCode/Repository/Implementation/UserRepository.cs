using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PostCode.Models;

namespace PostCode.Repository
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        private readonly ApplicationDbContext _applicationDb;
        MappingForUser map = new MappingForUser();
        public UserRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
            _applicationDb = applicationDb;
        }

        public override IEnumerable<User> GetAll()
        {
            return _applicationDb.Users.ToList().Select(user => new User()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                LockoutEnabled = user.LockoutEnabled
            });
        }

        public override User GetById(string id)
        {
           // return FindBy(x => x.Id == id).FirstOrDefault(); 
            var user =  map.GetForAppUser(_applicationDb.Users.FirstOrDefault(x => x.Id == id));
            return user;
        }

        public override void Delete(User entity)
        {
            var appUser = _applicationDb.Users.FirstOrDefault(x => x.Id == entity.Id);
            _applicationDb.Users.Remove(appUser);
        }

        public override User Add(User entity)
        {
            if (_applicationDb.Users.Any(x => x.Email==entity.Email)) return null;
            var appUser = map.GetForUser(entity);
            appUser.EmailConfirmed = true;
            return map.GetForAppUser(_applicationDb.Users.Add(appUser));
        }

        public override void Edit(User entity)
        {
            var appUser = _applicationDb.Users.FirstOrDefault(x => x.Id == entity.Id);
            _applicationDb.Entry((object)appUser).CurrentValues.SetValues(entity);
        }

        public override void Save()
        {
            _applicationDb.SaveChanges();
        }
    }
}