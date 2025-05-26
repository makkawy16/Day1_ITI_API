
using CQRS;
using CQRS.Data.Context;
using CQRS.Data.Models;
using CQRS.Repositories.Intefrafces;
using CQRS.Repositories;
using CQRS.TransientService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Day1_ITI_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
            });

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            #region Register Service

            /// <summary>
            /// Registers all services implementing <see cref="ITransientService"/> from the specified assemblies 
            /// into the dependency injection container with a transient lifetime. Each class is registered 
            /// for all interfaces it implements, as well as itself.
            /// </summary>
            Assembly targetAssembly = Assembly.Load("CQRS");
            Type interfaceType = typeof(ITransientService); // Get ITransientService Type


            //Get Any Thing Impelements ITransientService
            IEnumerable<Type> transientServices = targetAssembly.GetTypes()
                                .Where(t => interfaceType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

            foreach (Type serviceType in transientServices)
            {
                // Get all interfaces
                IEnumerable<Type> interfaces = serviceType.GetInterfaces().Where(i => i != typeof(ITransientService));

                foreach (Type serviceInterface in interfaces)
                {
                    // Register the class type for each interface it implements
                    builder.Services.AddTransient(serviceInterface, serviceType);
                }

                // Register the class itself
                builder.Services.AddTransient(serviceType);
            }
            #endregion
            builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();

            builder.Services.AddMediatR(typeof(CqrsMediator).Assembly);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();



        }



    }
}
