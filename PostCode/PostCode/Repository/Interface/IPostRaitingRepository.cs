using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostCode.Models;

namespace PostCode.Repository.Interface
{
    public interface IPostRaitingRepository:IRepository<PostRaiting>
    {
        PostRaiting GetById(string Id);
        double AverageRaiting(string Id);
    }
}
