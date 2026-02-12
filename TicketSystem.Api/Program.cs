using System.Globalization;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Presistence.DbContext;

namespace TicketSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // add Database Context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.MigrationsAssembly("TicketSystem.Presistence")
                )
            );

            #region Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            #endregion

            #region Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
    