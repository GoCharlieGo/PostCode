using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PostCode.Models;

namespace PostCode.Repository.Implementation
{
    public class TagRepository:Repository<Tag>,ITagRepository
    {
        public TagRepository(DbContext сontext) : base(сontext)
        {
        }

        public Tag GetById(string Id)
        {
            return FindBy(x => x.Id == Id).FirstOrDefault(); 
        }
    }
}