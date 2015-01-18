using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PostCode.Models;
using PostCode.Repository;

namespace PostCode.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public CommentsController(ICommentRepository commentRepository, IUserRepository userRepository, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _postRepository = postRepository;
        }
        // GET: Comments
        public async Task<ActionResult> Index(string id)
        {

            return View();
        }

        // GET: Comments/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var comment = _commentRepository.GetById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Content,Data,PostId,UserId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Id = Guid.NewGuid().ToString();
                comment.UserId = User.Identity.GetUserId();
                comment.Data = DateTime.Now;
                _commentRepository.Add(comment);
                _commentRepository.Save();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentRepository.GetById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Content,Data,PostId,UserId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.UserId = User.Identity.GetUserId();
                comment.User = _userRepository.GetById(comment.UserId);
                _commentRepository.Edit(comment);
                _commentRepository.Save();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentRepository.GetById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Comment comment = _commentRepository.GetById(id);
            _commentRepository.Delete(comment);
            _commentRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }
    }
}
