using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaglarDurmus.ShoppingApi.Business.Abstract;
using CaglarDurmus.ShoppingApi.Business.Concrete;
using CaglarDurmus.ShoppingApi.DataAccess.Abstract;
using CaglarDurmus.ShoppingApi.DataAccess.Concrete.EntityFramework;
using CaglarDurmus.ShoppingApi.MvcWebUI.Middlewares;
using CaglarDurmus.ShoppingApi.MvcWebUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CaglarDurmus.ShoppingApi.MvcWebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region injection

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion

            services.AddSession();

            //Session Cache de tutar
            services.AddDistributedMemoryCache();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseNodeModules(env.ContentRootPath);
            app.UseSession();
            app.UseMvcWithDefaultRoute();

        }
    }
}
