using Microsoft.AspNetCore.Authentication;
using PeopleSoftGLExport.Business;
using PeopleSoftGLExport.Data;
using PeopleSoftGLExport.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPeopleSoftGLExportData, PeopleSoftGLExportData>();
builder.Services.AddScoped<IPeopleSoftGLExportBusiness, PeopleSoftGLExportBusiness>();

builder.Services.AddOptions<Credentials>().Bind(builder.Configuration.GetSection(nameof(Credentials)));
builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
                ("BasicAuthentication", null);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
