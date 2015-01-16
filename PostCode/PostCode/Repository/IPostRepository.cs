using PostCode.Models;

namespace PostCode.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        Post GetById(string Id);
    }
}
