using Microsoft.AspNetCore.Authentication.JwtBearer;
using MoviesApi.Filters;
using MoviesApi.Services;

namespace MoviesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers(options =>
            {
                //add global filters
                options.Filters.Add(typeof(MyExceptionFilter));
            }).AddXmlDataContractSerializerFormatters();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddSingleton<IRepository, InMemoryRepository>();
            builder.Services.AddResponseCaching();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

            //action filter
            builder.Services.AddTransient<MyActionFilter>(); builder.Services.AddTransient<Microsoft.Extensions.Hosting.IHostedService, WriteToFileHostedService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseResponseCaching();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}