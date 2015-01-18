using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostCode.Models;

namespace PostCode.Repository.Interface
{
    public interface IPostTagRepository:IRepository<PostTag>
    {
        PostTag GetById(string Id);
        IEnumerable<PostTag> GetByTag(string tag);
    }
}
