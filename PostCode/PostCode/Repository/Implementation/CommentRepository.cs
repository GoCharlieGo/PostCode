using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PostCode.Models;

namespace PostCode.Repository
{
    public class CommentRepository:Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext сontext) : base(сontext)
        {
        }

        public Comment GetById(string Id)
        {
            return _entities.Set<Comment>().Include(x => x.Post).Include(x=> x.User).FirstOrDefault(x => x.Id == Id);
        }
    }
}