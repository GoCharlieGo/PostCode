using PostCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PostCode.Repository;

namespace PostCode.Controllers
{
    public class PostController : Controller
    {
        private PostRepository _postRepository;
        private ApplicationDbContext _bdContext = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(_postRepository.GetAll());
        }     
        // GET: Publication
        public ActionResult Post()
        {
            return View(new Post { });
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                _postRepository.Add(post);
                return RedirectToAction("Index");
            }
            return View(post);

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

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post= _postRepository.GetById(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostId = new SelectList(_postRepository.GetAll(), "Id", "Name", post.UserId);
            return View(post);
        }

        // POST: /Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Conent,Data,UserId")] Post post)
        {
            if (ModelState.IsValid)
            {
                _postRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(_postRepository.GetAll(), "Id", "Name", post.UserId);
            return View(post);
        }


    }
}