﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PostCode.Models;
using PostCode.Repository;

namespace PostCode.Controllers
{
    [ValidateInput(false)]
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public PostsController(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }
        // GET: Posts
        public async Task<ActionResult> Index()
        {
            var posts = _postRepository.GetAll().Select(post => new Post()
            {
                Id =post.Id,
                Content = post.Content,
                Code = post.Code,
                Data = post.Data,
                User = post.User,
                Name = post.Name 
            });
            return View(posts);
        }

        // GET: Posts/Details
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var post =_postRepository.GetById(id);
            
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [Authorize]
        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create([Bind(Include = "Id,Content,Code,Data,Name,UserId")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Id = Guid.NewGuid().ToString();
                post.UserId = User.Identity.GetUserId();
                post.Data = DateTime.Now;
                _postRepository.Add(post);
                _postRepository.Save();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Edit
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post =_postRepository.GetById(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Content,Code,Data, Name, UserId")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.UserId = User.Identity.GetUserId();
                post.User = _userRepository.GetById(post.UserId);
                _postRepository.Edit(post);
                _postRepository.Save();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _postRepository.GetById(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Post post = _postRepository.GetById(id);
            _postRepository.Delete(post);
            _postRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _postRepository.Dispose();
            }
        }
    }
}
