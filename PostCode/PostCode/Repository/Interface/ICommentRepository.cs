using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostCode.Models;

namespace PostCode.Repository
{
    public interface ICommentRepository:IRepository<Comment>
    {
        Comment GetById(string id);
    }
}
