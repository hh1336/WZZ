using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BLL;
using DAL;

namespace WZZ
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            #region 连接字符串
            //连接字符串
            //var sqlConnection = Configuration.GetConnectionString("SqlServer");
            //services.AddDbContext<MyDbcontext>(option => option.UseSqlServer(sqlConnection));

            //var sqlConnection = @"Data Source=120.78.198.92;Initial Catalog=WZZ;Persist Security Info=True;User ID=sa;Password=Woshimayu1998;";
            //services.AddDbContext<MyDbContext>(option => option.UseSqlServer(sqlConnection));
            services.AddDbContext<MyDbContext>(d => d.UseMySQL(Configuration.GetConnectionString("MysqlConnection")));


            #endregion
            BLLDIRegister sdr = new BLLDIRegister();
            sdr.DIRegister_DAL(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseStaticFiles(new StaticFileOptions() {
                ServeUnknownFileTypes = true
            });
        }
    }
}
