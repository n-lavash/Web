using TaskTracker.BLL;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL;
using TaskTracker.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("TaskTrackerConnectStr");
builder.Services.AddSingleton(connectionString);
builder.Services.AddScoped<ITaskTrackerLogic, TaskTrackerLogic>();
builder.Services.AddSingleton<ITaskTrackerDAO>(provider => new TaskTrackerDAO(connectionString));

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
