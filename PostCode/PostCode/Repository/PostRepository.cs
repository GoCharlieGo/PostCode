using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PostCode.Models;

namespace PostCode.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DbContext context)
           : base(context)
       {
           
       }

        public override IEnumerable<Post> GetAll()
        {
            return _entities.Set<Post>().Include(x => x.ApplicationUser).AsEnumerable();
        }

        public Post GetById(Int32 id)
        {
            return _dbset.Include(x => x.ApplicationUser).FirstOrDefault(x => x.Id == id);
        }
    }
}