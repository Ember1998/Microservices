using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlatformService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddDbContext<AppDbContext>(opt=>{
    opt.UseInMemoryDatabase("MemoDb1");
});
var assemblies =AppDomain.CurrentDomain.GetAssemblies();
builder.Services.AddAutoMapper(assemblies);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.PrepPopulate();

app.MapGet("/getAll",(IPlatformRepo _repo, IMapper _mapper)=>{
    var platformItems = _repo.GetAllPlatforms();
    return Results.Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platformItems));
}).WithName("GetPlatforms").WithOpenApi();

app.MapPost("/create",(IPlatformRepo _repo, IMapper _mapper,PlatformCreateDTO item)=>{
    var platformModel = _mapper.Map<Platform>(item);
    _repo.CreatePlatform(platformModel);
    _repo.SaveChanges();

    var PlatformReadDTO=_mapper.Map<PlatformReadDTO>(platformModel);
    return Results.CreatedAtRoute("GetPlatformById", new {Id=PlatformReadDTO.Id},PlatformReadDTO);
}).WithName("CreatePlatform").WithOpenApi();

app.MapGet("/getPlatformId",(IPlatformRepo _repo, IMapper _mapper, int Id)=>{
    var platform = _repo.GetPlatformById(Id);
    return Results.Ok(_mapper.Map<PlatformReadDTO>(platform));
}).WithName("GetPlatformById").WithOpenApi();
app.Run();
