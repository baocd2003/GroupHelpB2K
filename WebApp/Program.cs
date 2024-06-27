using DataAccessObjects;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Implementation;
using Services.Interface;
using WebApp.AppStarts;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            
            builder.Services.AddSession(option => option.IdleTimeout = TimeSpan.FromMinutes(30));

            builder.Services.AddScoped(typeof(IGenericDAO<>), typeof(GenericDAO<>));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            builder.Services.AddScoped<ICommentRepo, CommentRepo>();
            builder.Services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
            builder.Services.AddScoped<IOrderRepo, OrderRepo>();
            builder.Services.AddScoped<IPublisherRepo, PublisherRepo>();
            builder.Services.AddScoped<IBookManagementRepo, BookManagementRepo>();

            builder.Services.AddScoped<IBookManagementService, BookManagementService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IPublisherService, PublisherService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
            builder.Services.AddScoped<ICommentService, CommentService>();

            builder.Services.AddAutoMapper(typeof(MapperConfig).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.UseSession();

            app.Run();
        }
    }
}