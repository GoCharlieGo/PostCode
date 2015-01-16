using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PostCode.Models;

namespace PostCode.Repository
{
    public class MappingForUser : IMapper<User, ApplicationUser>
    {

        public ApplicationUser MappingToDefU(User entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new ApplicationUser()
            {
                Id = entity.Id,
                Email = entity.Email,
                LockoutEnabled = entity.LockoutEnabled,
                UserName = entity.UserName
            };
        }

        public User MappingFromDefU(ApplicationUser entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new User()
            {
                Id = entity.Id,
                Email = entity.Email,
                LockoutEnabled = entity.LockoutEnabled,
                UserName = entity.UserName
            };
        }
    }
}