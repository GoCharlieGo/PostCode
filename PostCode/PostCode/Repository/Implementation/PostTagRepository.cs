using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PostCode.Models;
using PostCode.Repository.Interface;

namespace PostCode.Repository.Implementation
{
    public class PostTagRepository:Repository<PostTag>, IPostTagRepository
    {
        public PostTagRepository(DbContext сontext) : base(сontext)
        {
        }

        public PostTag GetById(string Id)
        {
            if (Id == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                return _entities.Set<PostTag>().Include(x => x.Post).Include(x=>x.Tag).FirstOrDefault(x => x.Id == Id);
            }
        }
        public IEnumerable<PostTag> GetByTag(string tag)
        {
            return FindBy(x=> tag == x.Tag.Name);
        }
    }
}