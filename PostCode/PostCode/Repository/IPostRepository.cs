using System;
using PostCode.Models;

namespace PostCode.Repository
{
    public interface IPostRepository:IRepository<Post>
    {
        Post GetById(Int32 id);
    }
}
