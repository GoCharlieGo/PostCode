using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostCode.Models;

namespace PostCode.Repository.Interface
{
    public interface ICommentLikeRepository:IRepository<CommentLike>
    {
        CommentLike GetById(string Id);
    }
}
