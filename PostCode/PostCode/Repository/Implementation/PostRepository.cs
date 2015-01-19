using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Services.Description;
using PostCode.Models;

namespace PostCode.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DbContext context)
            : base(context)
        {

        }

        public IEnumerable<Post> GetAll()
        {
            return _entities.Set<Post>().Include(x => x.User).AsEnumerable();
        }

        public override Post GetById(string Id)
        {
            return _entities.Set<Post>().Include(x => x.User).FirstOrDefault(x => x.Id == Id);
        }

        public override Post Add(Post entity)
        {
            if (entity.Content == null || entity.Name == null || entity.UserId == null)
            {
                return null;
            }
            return  _entities.Set<Post>().Add(entity);
        }
    }
}