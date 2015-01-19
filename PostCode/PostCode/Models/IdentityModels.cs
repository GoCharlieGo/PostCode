using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PostCode.Repository;

namespace PostCode.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostRaiting> PostRaitings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        public override IDbSet<ApplicationUser> Users
        {
            get { return base.Users; }
            set { base.Users = value; }
        }

        //public DbSet<User> Users { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
    }
    public class User : IEntity
    {
        [Key]
        public String Id { get; set; }
        public String Email { get; set; }
        public String UserName { get; set; }
        public Boolean LockoutEnabled { get; set; }


        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<CommentLike> CommentLikes { get; set; }
        public IEnumerable<PostRaiting> PostRaitings { get; set; }
    }
    public  class Post : IEntity
    {
        [Key]
        public String Id { get; set; }
        public String Content { get; set; }
        public String Code { get; set; }
        public DateTime Data { get; set; }
        public String Name { get; set; }


        [Display(Name = "User")]
        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public IEnumerable<PostRaiting> PostRaitings { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
    public class PostRaiting : IEntity
    {
        [Key]
        public String Id { get; set; }
        public Int32 Value { get; set; }

        [Display(Name = "Post")]
        public String PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [Display(Name = "User")]
        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
    public class Comment : IEntity
    {
        [Key]
        public String Id { get; set; }
        public String Content { get; set; }
        public DateTime Data { get; set; }


        [Display(Name = "Post")]
        public String PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }


        [Display(Name = "User")]
        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual IEnumerable<CommentLike> CommentLikes { get; set; }
    }

    public class CommentLike :IEntity
    {
        [Key]
        public String Id { get; set; }
        public Int32 Value { get; set; }

        [Display(Name = "Comment")]
        public String CommentId { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }

        [Display(Name = "User")]
        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }

    public class Tag : IEntity
    {
        [Key]
        public String Id { get; set; }
        public String Name { get; set; }

        public virtual IEnumerable<PostTag> PostTags { get; set; }
    }
    public class PostTag : IEntity
    {
        [Key]
        public String Id { get; set; }

        [Display(Name = "Post")]
        public String PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [Display(Name = "Tag")]
        public String TagId { get; set; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}