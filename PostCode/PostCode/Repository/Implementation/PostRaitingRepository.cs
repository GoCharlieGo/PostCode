using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PostCode.Models;
using PostCode.Repository.Interface;

namespace PostCode.Repository.Implementation
{
    public class PostRaitingRepository:Repository<PostRaiting>, IPostRaitingRepository
    {
        public PostRaitingRepository(DbContext сontext) : base(сontext)
        {
        }

        public PostRaiting GetById(string Id)
        {
            return _entities.Set<PostRaiting>().Include(x => x.Post).FirstOrDefault(x => x.Id == Id);
        }

        public double AverageRaiting(string Id)
        {
            var reaitPost = FindBy(x => x.PostId == Id).Average(x => x.Value);
            return reaitPost;
        }

        public  PostRaiting Add(PostRaiting entity, string userId)
        {
            if (GetById(entity.Id) == null || FindBy(x=>x.UserId==userId || x.PostId == entity.Id).Any())
                return _entities.Set<PostRaiting>().Add(entity);
            else return null;

        }
    }
}