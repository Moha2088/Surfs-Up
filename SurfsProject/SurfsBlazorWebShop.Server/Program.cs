using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Components.WebAssembly.Server;
using SurfsWebShopLibrary.Product;
using SurfsWebShopLibrary.Product.Models;
using SurfsWebShopLibrary.ShoppingCart;
using SurfsWebShopLibrary.ShoppingCart.Models;

using SurfsWebShopLibrary.Storage;
using SurfsBlazorWebShop.Server.Hubs;

namespace SurfsBlazorWebShop.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Dependency injection
            builder.Services.AddSingleton<IStorageService, StorageService>();
            builder.Services.AddSingleton<IShoppingCartService, ShoppingCartService>();
            builder.Services.AddTransient<IProductService, ProductService>();

            builder.Services.AddSignalR();
            builder.Services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            var app = builder.Build();

            app.UseResponseCompression();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();

                // No cache
                app.Use(async (httpContext, next) =>
                {
                    httpContext.Response.Headers[HeaderNames.CacheControl] = "no-cache";
                    await next();
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.MapHub<LiveChatHub>("/live-chat");
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}