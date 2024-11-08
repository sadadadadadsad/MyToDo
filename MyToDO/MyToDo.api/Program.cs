
using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyToDo.api.Context;
using MyToDo.api.Context.Repository;
using MyToDo.api.Extensions;
using MyToDo.api.Service;

namespace MyToDo.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<MyToDoContext>(options => {
                var connectionString = builder.Configuration.GetConnectionString("ToDoConnection");
                options.UseSqlite(connectionString);
            }).AddUnitOfWork<MyToDoContext>()
            .AddCustomRepository<ToDo,ToDoRepository>()
            .AddCustomRepository<Memo,MemoRepository>()
            .AddCustomRepository<User,UserRepository>()
            ;
            builder.Services.AddTransient<IToDoService, ToDoService>(); //注入服务
            builder.Services.AddTransient<IMemoService, MemoService>();
            builder.Services.AddTransient<ILoginService, LoginService>();

            //添加AutoMapper
            var automapperConfog = new MapperConfiguration(configure =>
            {
                configure.AddProfile(new AutoMapperProfile());
            });
            builder.Services.AddSingleton(automapperConfog.CreateMapper());    //注入mapper映射

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
