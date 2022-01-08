using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Filters;

namespace tssrazor
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
			services
				.AddSession(opt => 
				{
					opt.Cookie.Name = "wtb";
					opt.IdleTimeout = new TimeSpan(0, 0, 30);
				})
				.AddRazorPages()
				.AddMvcOptions(opt => 
				{
					//opt.Filters.Add(typeof(NeedLogonAttribute));
					opt.Filters.Add<HasLogonAttribute>();
				})
				.AddRazorPagesOptions(opt =>
				{
					opt.Conventions.AddPageRoute("/Articles/Article", "/Article/{id:int}");
					opt.Conventions.AddPageRoute("/Articles/Index", "/Article/Page/{pageIndex:int}");
					opt.Conventions.AddPageRoute("/Members/Register", "/Register/{id:int?}");
					opt.Conventions.AddPageRoute("/Members/Logon", "/Logon/{refererURL?}");
					opt.Conventions.AddPageRoute("/Members/Logoff", "/Logoff/{id:int?}");
					opt.Conventions.AddPageRoute("/Backstage/MessageMine", "/Message/Mine/Status/{msgStatus:int}/Page/{pageIndex:int}");
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();

			app.UseRouting();

			app.UseSession();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});
		}
	}
}
