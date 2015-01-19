using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PostCode.Models;
using PostCode.Repository.Interface;

namespace PostCode.Repository.Implementation
{
    public class CommentLikeRepository : Repository<CommentLike>, ICommentLikeRepository
    {
        public CommentLikeRepository(DbContext сontext) : base(сontext)
        {
        }

        public override CommentLike GetById(string Id)
        {
             return _entities.Set<CommentLike>().Include(x => x.Comment).Include(x => x.User).FirstOrDefault(x => x.Id == Id);
        }

        public int LikeCount(string id)
        {
            var comment = FindBy(x => x.Comment.Id == id);
            return comment.Sum(item => item.Value);
        }

        public CommentLike Add(CommentLike entity, string userId)
        {
            if (!FindBy(x=>x.UserId == userId ).Any())
            {
                return _entities.Set<CommentLike>().Add(entity);
            }
            return null;
        }
    }
}