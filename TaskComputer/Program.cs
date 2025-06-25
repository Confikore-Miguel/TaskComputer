using TaskComputer;
using TaskComputer.Application;
using TaskComputer.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
                .AddApplication();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ApplyMigration();
}

app.UseExceptionHandler("/error"); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExeptionHandlingMiddleware>();

app.MapControllers();

app.Run();
