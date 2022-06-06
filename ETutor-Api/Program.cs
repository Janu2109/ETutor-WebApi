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
builder.Services.AddTransient<IModuleRepositoryAsync, ModuleRepositoryAsync>();
builder.Services.AddTransient<ICourseRepositoryAsync, CourseRepositoryAsync>();
builder.Services.AddTransient<IClassesRepositoryAsync, ClassesRepositoryAsync>();
builder.Services.AddTransient<IStudentEnrollmentRepositoryAsync, StudentEnrollmentRepositoryAsync>();
builder.Services.AddTransient<IStudentsEnrolledRepositoryAsync, StudentsEnrolledRepositoryAsync>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    Environment.SetEnvironmentVariable("CONNECTION_STRING", "Data Source=SICT-SQL.mandela.ac.za ;Initial Catalog=GRP27-ETutor;User Id=GRP27;Password=grp27-soit2022;Integrated Security=false");
}


app.UseRouting();

app.UseHttpsRedirection();


app.UseCors(options => options.AllowAnyOrigin()
                                           .AllowAnyHeader()
                                           .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
