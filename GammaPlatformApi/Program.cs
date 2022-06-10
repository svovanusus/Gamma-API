using Gamma.Data.EF;
using Gamma.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<GammaDbContext>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthConfig.ISSUER,

            ValidateAudience = true,
            ValidAudience = AuthConfig.AUDIENCE,

            ValidateLifetime = false,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = AuthConfig.GetSymmetricSecurityKey()
        };
    });

Gamma.Logic.Repositories.DiSetup.Setup(builder.Services);
Gamma.Logic.Services.DiSetup.Setup(builder.Services);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
