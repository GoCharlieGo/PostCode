using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PostCode.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim(ClaimTypes.Gender, this.Gender));
            userIdentity.AddClaim(new Claim("age", this.Age.ToString()));
            // Add custom user claims here
            return userIdentity;
        }
        public int Age { get; set; }
        public string Gender { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 822f931... Revert "Revert "added model and initialize in context""
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostRaiting> PostRaitings { get;set; }
        public DbSet<Comment> Comments { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<PostTag> PostTags { get; set; } 
=======

>>>>>>> 78eb888... Revert "added model and initialize in context"
=======
        public DbSet<CommentLike> CommentLikes { get; set; } 
>>>>>>> 822f931... Revert "Revert "added model and initialize in context""
=======
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<PostTag> PostTags { get; set; } 
>>>>>>> e60a9d7f60a07b76c6378f2b81af55850aafc6aa
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 822f931... Revert "Revert "added model and initialize in context""

    public class Post
    {
        [Key]
        public Int32 Id { get; set; }
        public String Content { get; set; }
        public String UserId { get; set; }
        public String Name { get; set; }
    }

    public class PostRaiting
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 PostId { get; set; }
        public String UserId { get; set; }
        public Int32 Value { get; set; }
    }

    public class Comment
    {
        [Key]
        public Int32 Id { get; set; }
        public String Content { get; set; }
        public String UserId { get; set; }
        public Int32 PostId { get; set; }
    }

    public class CommentLike
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 CommentId { get; set; }
        public String UserId { get; set; }
        public Int32 Value { get; set; }
    }

    public class Tag
    {
        [Key]
        public Int32 Id { get; set; }
        public String Name { get; set; }
    }
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> e60a9d7f60a07b76c6378f2b81af55850aafc6aa

    public class PostTag
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 PostId { get; set; }
        public Int32 TagId { get;set; }
    }
<<<<<<< HEAD
=======
>>>>>>> 78eb888... Revert "added model and initialize in context"
=======
>>>>>>> 822f931... Revert "Revert "added model and initialize in context""
=======
>>>>>>> e60a9d7f60a07b76c6378f2b81af55850aafc6aa
}