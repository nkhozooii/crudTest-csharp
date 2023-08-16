using Mc2.CrudTest.Presentation.Application.Handlers.CommandHandler;
using Mc2.CrudTest.Presentation.Core.Repositories.Command.Base;
using Mc2.CrudTest.Presentation.Core.Repositories.Query;
using Mc2.CrudTest.Presentation.Core.Repositories.Query.Base;
using Mc2.CrudTest.Presentation.Infrastructure.Repository.Command;
using Mc2.CrudTest.Presentation.Infrastructure.Repository.Command.Base;
using Mc2.CrudTest.Presentation.Infrastructure.Repository.Query;
using Mc2.CrudTest.Presentation.Infrastructure.Repository.Query.Base;
using MediatR;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Mc2.CrudTest.Presentation.Core;

namespace Mc2.CrudTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // var AllowOrigins = "_myAllowOrigins";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy(AllowOrigins,
            //        policy =>
            //        {
            //            policy.AllowAnyOrigin();
            //        });
            //});
//
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            //
            builder.Services.AddControllers();

            string connectionString = builder.Configuration.GetConnectionString("SqlConnection");
            //register DbContext
            builder.Services.AddDbContext<CrudTestDbContext>(options => {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer.API", Version = "v1" });
            });

            // Register dependencies
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateCustomerHandler>());
            builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            builder.Services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
            builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            builder.Services.AddTransient<Core.Repositories.Command.ICustomerCommandRepository, CustomerCommandRepository>();
            //


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer.API v1"));
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


            app.MapRazorPages();
           // app.UseCors(AllowOrigins);
            app.UseAuthorization();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}