using ECommerce.WebUI.Middlewares;
using ECommerceDemo.Business.Abstract;
using ECommerceDemo.Business.Concrete;
using ECommerceDemo.DataAccess.Abstract;
using ECommerceDemo.DataAccess.Concrete.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ECommerce.WebUI
{
	public class Startup
	{
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddRazorPages();

			services.AddScoped<IProductDal, EfCoreProductDal>(); //ba�ka bir altyap�yla cal�smak istenirse de�i�tirilcek k�s�m.
			services.AddScoped<IProductService, ProductManager>();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}
			else {
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();

			//app.CustomStaticFiles();

			app.UseRouting(); //middleware gelen iste�in rotas� 

			app.UseEndpoints(endpoints => {
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}
