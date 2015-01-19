using PostCode.Models;

namespace PostCode.Repository
{
    public class MappingForUser : IMapper<User, ApplicationUser>
    {

        public User GetForAppUser(ApplicationUser entity)
        {
            if (entity == null)
                return null;//throw new ArgumentNullException("dalEntity");
            return new User()
            {
                Id = entity.Id,
               Email = entity.Email,
               LockoutEnabled = entity.LockoutEnabled,
               UserName = entity.UserName
            };
        }

        public ApplicationUser GetForUser(User entity)
        {
            if (entity == null)
                return null;//throw new ArgumentNullException("bllEntity");
            return new ApplicationUser ()
            {
                Id = entity.Id,
                Email = entity.Email,
                LockoutEnabled = entity.LockoutEnabled,
                UserName = entity.UserName
            };
        }
    }
}