using PostCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace PostCode.Controllers
{
    public class PostController : Controller
    {

        private ApplicationDbContext _bdContext = new ApplicationDbContext();
        // GET: Publication
        public ActionResult Post()
        {
            return View(new Post { });
        }

        [HttpPost]
        [AllowAnonymous]
        public ViewResult Post(Post model)
        {
            model.UserId = User.Identity.GetUserId();
            model.Data = DateTime.Now;
            _bdContext.Posts.Add(model);
            _bdContext.SaveChanges();
            return View(model);
        }
    }
}