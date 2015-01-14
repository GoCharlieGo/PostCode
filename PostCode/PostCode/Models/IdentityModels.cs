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
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<CommentLike> CommentLikes { get; set; }
        public IEnumerable<PostRaiting> PostRaitings { get; set; }
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
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
    public sealed class Post 
    {
        [Key]
        public Int32 Id { get; set; }
        public String Content { get; set; }

        public DateTime Data { get; set; }
        public String Name { get; set; }
        [Display(Name = "ApplicationUser")]
        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<PostRaiting> PostRaitings { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
    public class PostRaiting
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 Value { get; set; }

        [Display(Name = "Post")]
        public Int32 PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [Display(Name = "ApplicationUser")]
        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    public class Comment 
    {
        [Key]
        public Int32 Id { get; set; }
        public String Content { get; set; }
        public DateTime Data { get; set; }


        [Display(Name = "Post")]
        public Int32 PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }


        [Display(Name = "ApplicationUser")]
        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual IEnumerable<CommentLike> CommentLikes { get; set; }
    }

    public class CommentLike 
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 Value { get; set; }

        [Display(Name = "Comment")]
        public Int32 CommentId { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }

        [Display(Name = "ApplicationUser")]
        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public class Tag 
    {
        [Key]
        public Int32 Id { get; set; }
        public String Name { get; set; }

        public virtual IEnumerable<PostTag> PostTags { get; set; }
    }
    public class PostTag
    {
        [Key]
        public Int32 Id { get; set; }

        [Display(Name = "Post")]
        public Int32 PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [Display(Name = "Tag")]
        public Int32 TagId { get; set; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}