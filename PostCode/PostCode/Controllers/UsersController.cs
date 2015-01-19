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

namespace PostCode.App_Start
{
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: Users
        public ActionResult Index()
        {
            return View(_userRepository.GetAll().ToList());
        }

        // GET: Users/Details/5
        public  ActionResult Details(string id)
        {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = _userRepository.GetById(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);  
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(string id)
        {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var user = _userRepository.GetById(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User user)
        {

                if (ModelState.IsValid)
                {
                    _userRepository.Edit(user);
                    _userRepository.Save();
                    return RedirectToAction("Index");
                }
                return View(user);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = _userRepository.GetById(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);  
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
                var user = _userRepository.GetById(id);
                _userRepository.Delete(user);
                _userRepository.Save();
                return RedirectToAction("Index");
            
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userRepository.Dispose();
            }
        }
    }
}
