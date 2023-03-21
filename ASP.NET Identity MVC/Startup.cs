using ASP.NET_Identity_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Identity_MVC
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config) 
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //DB connection.
            var connection = _config.GetConnectionString("IdentityDBConnect");
            services.AddDbContextPool<IdentityDbContext>(options => options.UseSqlServer(_config.GetConnectionString("IdentityConnect")));
            services.AddMvc();
        }
    }
}
