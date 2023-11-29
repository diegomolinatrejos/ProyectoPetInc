var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configuracion de CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyCorsPolicy",
        policy =>
        {
            policy.AllowAnyOrigin();// www.mypage.com, www.mypage.net, otros
            policy.AllowAnyHeader();// application /json, aplication/xml, application/text, application/html
            policy.AllowAnyMethod();// get, post, put, delete
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

    app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
