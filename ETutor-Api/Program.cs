using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddScoped<IDatabase, Database>(i => new Database(Environment.GetEnvironmentVariable("CONNECTION_STRING")));
builder.Services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    Environment.SetEnvironmentVariable("CONNECTION_STRING", "Data Source=(localdb)\\mssqllocaldb ;Initial Catalog=GRP27-ETutor;User Id=janu;Password=janu;Integrated Security=false");
}


app.UseRouting();

app.UseHttpsRedirection();


app.UseCors(options => options.AllowAnyOrigin()
                                           .AllowAnyHeader()
                                           .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
