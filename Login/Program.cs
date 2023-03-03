using FluentValidation;
using FluentValidation.AspNetCore;
using Login.Data;
using Login.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation(o =>
{
    o.DisableDataAnnotationsValidation = true;
});
builder.Services.AddCorsPolicy();
builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data source = lite.db");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
