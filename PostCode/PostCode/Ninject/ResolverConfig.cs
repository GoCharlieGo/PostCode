using System.Data.Entity;
using Ninject;
using PostCode.Models;
using PostCode.Repository;

namespace PostCode.Ninject
{
    public static class ResolverConfig
    {
        private static void Configure(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<ApplicationDbContext>().InSingletonScope();
            kernel.Bind<IPostRepository>().To<PostRepository>();
        }
    }
}