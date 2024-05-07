using Microsoft.EntityFrameworkCore;
using ServerASP.Data.DBContext;
using ServerASP.Data.Interfaces;
using ServerASP.Data.Repositories;
using ServerASP.Data.UOF;
using ServerASP.Services;
using ServerASP.Services.Interfaces;

namespace ServerASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<EmployeeDBContext>( opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<IPositionService, PositionService>();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            builder.Services.AddTransient<IPositionRepository, PositionRepository>();
            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddTransient<UnitOfWork>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            //Ну чисто протестить сначала, какой json он выдаёт.
            //Ну да, можно было бы через юнит тесты и Moq, но я уже соскуфился
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
