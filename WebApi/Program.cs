
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
builder.Services.AddDbContext<DataContexts>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
//builder.Services.AddDbContext<DataContexts>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Education2\\ASP\\WebApi\\Infrastructure\\Data\\db.mdf;Integrated Security=True;Connect Timeout=30"));
builder.Services.AddControllers();
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
