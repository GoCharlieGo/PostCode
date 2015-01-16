using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostCode.Models;

namespace PostCode.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        Post GetById(string Id);
    }
}
