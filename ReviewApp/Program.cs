using Microsoft.EntityFrameworkCore;
using ReviewApp;
using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Repository;
using AutoMapper;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//sseding data
builder.Services.AddTransient<Seed>();

builder.Services.AddControllers().AddJsonOptions(x => 
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//repository injection
builder.Services.AddScoped<ICharacterRespsoitory, CharacterRespository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICountryRespository, CountryRespository>();
builder.Services.AddScoped<IOwnerRespository, OwnerRespository>();
builder.Services.AddScoped<IReviewRespository, ReviewRespository>();
builder.Services.AddScoped<IReviewerRepository, ReviewerRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//adding db conenction
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConenction")));

var app = builder.Build();
if (args.Length == 1 && args[0].ToLower() == "seeddata")
SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}


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
