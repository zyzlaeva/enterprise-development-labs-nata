using AutoMapper;
using Mediateca.Application;
using Mediateca.Application.Contracts;
using Mediateca.Application.Contracts.Musician;
using Mediateca.Application.Contracts.Album;
using Mediateca.Application.Contracts.Track;
using Mediateca.Application.Services;
using Mediateca.Domain.Model;
using Mediateca.Domain.Services;
using Mediateca.Infractructure.EfCore.Services;
using Mediateca.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));
IMapper? mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient<IRepository<Album, int>, AlbumEfCoreRepository>();
builder.Services.AddTransient<IRepository<Musician, int>, MusicianEfCoreRepository>();
builder.Services.AddTransient<ITrackRepository, TrackEfCoreRepository>();

builder.Services.AddScoped<ICrudService<AlbumDto, AlbumCreateUpdateDto, int>, AlbumCrudService>();
builder.Services.AddScoped<ICrudService<MusicianDto, MusicianCreateUpdateDto, int>, MusicianCrudService>();
builder.Services.AddScoped<ICrudService<TrackDto, TrackCreateUpdateDto, int>, TrackCrudService>();
builder.Services.AddScoped<IAnalyticsService, TrackCrudService>();

builder.Services.AddDbContextFactory<MediatecaDbContext>(options =>
    options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
