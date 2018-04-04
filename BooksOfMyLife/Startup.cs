using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BooksOfMyLife.Startup))]
namespace BooksOfMyLife
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
