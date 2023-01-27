using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Application.Commons.Abstractions.Data.Commons;
using RepositoryPattern.Application.Commons.Abstractions.Data.ContextRepositories;
using RepositoryPattern.Application.Commons.Abstractions.Data.EntityRepositories;
using RepositoryPattern.Infrastructure.Persistence;
using RepositoryPattern.Infrastructure.Persistence.ContextRepositories;
using RepositoryPattern.Infrastructure.Persistence.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);
#region [ SERVICES ]
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region [ DATABASE ]
builder.Services.AddTransient(typeof(IMainContextRepository<>), typeof(MainContextRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
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