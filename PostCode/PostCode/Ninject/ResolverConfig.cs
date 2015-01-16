using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Ninject;
using PostCode.Models;
using PostCode.Repository;

namespace PostCode.Ninject
{
    public static class ResolverConfig
    {

        public static void ConfigureConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            kernel.Bind<DbContext>().To<ApplicationDbContext>().InSingletonScope();
            kernel.Bind<IPostRepository>().To<PostRepository>();
        }
    }
}