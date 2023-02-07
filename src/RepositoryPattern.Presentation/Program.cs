using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Application.Commons.Abstractions.Data.Commons;
using RepositoryPattern.Application.Commons.Abstractions.Data.ContextRepositories;
using RepositoryPattern.Application.Commons.Abstractions.Data.EntityRepositories;
using RepositoryPattern.Infrastructure.Persistence;
using RepositoryPattern.Infrastructure.Persistence.ContextRepositories;
using RepositoryPattern.Infrastructure.Persistence.UnitOfWork;
using RepositoryPattern.Presentation.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
#region [ SERVICES ]
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Program));
var assembly = AppDomain.CurrentDomain.Load("RepositoryPattern.Application");
builder.Services.AddMediatR(assembly);

#region [ DATABASE ]
builder.Services.AddDatabase();
builder.Services.AddDbContext<MainContext>(option =>
{
    option.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(MainContext).Assembly.FullName));
});
#endregion

#endregion

var app = builder.Build();
#region [ CONFIGURES ]
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion