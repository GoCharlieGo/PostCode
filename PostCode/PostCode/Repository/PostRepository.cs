using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        Post IPostRepository.GetById(string Id)
        {
            return _entities.Set<Post>().Include(x => x.User).Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}