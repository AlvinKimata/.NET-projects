namespace ASP.NET_Identity_MVC
{
    public class Startup
    {
        public Startup(IConfiguration config) 
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //DB connection.
            var connection = _config.GetConnectionString("IdentityConnect");
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("IdentityConnect"));
            services.AddMvc();
        }
    }
}
