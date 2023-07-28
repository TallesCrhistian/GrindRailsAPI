using GrindRailsAPI.API;
using GrindRailsAPI.Utils.MappingProfile;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddDataBaseIndentiy(builder.Configuration);
builder.Services.AddDefaultIdentity();
builder.Services.WorkUnit();
builder.Services.AddRepository();
builder.Services.AddBusiness();
builder.Services.AddIdentity();
builder.Services.AddServices();
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddLogging(logginBuilder =>
{
    logginBuilder.ClearProviders();
    logginBuilder.AddConsole();
    logginBuilder.AddDebug();
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
