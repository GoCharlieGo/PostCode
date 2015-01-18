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
        MappingForUser map = new MappingForUser();
        public UserRepository(DbContext сontext) : base(сontext)
        {
        }
        public User GetById(string id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault(); 
        }
    }
}