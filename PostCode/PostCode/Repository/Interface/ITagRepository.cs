using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PostCode.Models;

namespace PostCode.Repository
{
    public interface ITagRepository:IRepository<Tag>
    {
        Tag GetById(string Id);
    }
}