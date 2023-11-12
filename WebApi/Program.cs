using System.Text;
using Domain.DTOs.EmailDTOs;
using Domain.Entities.UserEntities;
using Infrastructure.Automapper;
using Infrastructure.Data;
using Infrastructure.Seed;
using Infrastructure.Services.ChatServises;
using Infrastructure.Services.EmailServices;
using Infrastructure.Services.FavoriteServices;
using Infrastructure.Services.FileServices;
using Infrastructure.Services.FollowingRelationShipServices;
using Infrastructure.Services.MessageServises;
using Infrastructure.Services.PostServices;
using Infrastructure.Services.ProfileServices;
using Infrastructure.Services.StoryServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();

// Add services to the container.
//Abdughaffor
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<Seeder>();
builder.Services.AddScoped<IFileService,FileService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IFavoriteService,FavoriteService>();
builder.Services.AddScoped<IProfileService,ProfileService>();
builder.Services.AddScoped<IFollowingRelationShipService,FollowingRelationShipService>();

//Mahmud
builder.Services.AddScoped<IMessageServise, MessageServise>();
builder.Services.AddScoped<IChatServise, ChatServise>();

//Shahrom
builder.Services.AddScoped<IStoryService,StoryService>();


builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddDbContext<DataContext>(c => c.UseNpgsql(connection));


builder.Services.AddIdentity<User, IdentityRole>(config =>
    {
        config.Password.RequiredLength = 4;
        config.Password.RequireDigit = false;
        config.Password.RequireNonAlphanumeric = false;
        config.Password.RequireUppercase = false;
        config.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;            
}).AddJwtBearer(o =>
{
    var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sample web API",
        Version = "v1",
        Description = "Sample API Services.",
        Contact = new OpenApiContact { Name = "Abdughaffor" },
    });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
            
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

try
{
    var serviceProvider = app.Services.CreateScope().ServiceProvider; 
    var dataContext = serviceProvider.GetRequiredService<DataContext>();
    await dataContext.Database.MigrateAsync();
    
    var seeder = serviceProvider.GetRequiredService<Seeder>();
    await seeder.SeedUser();
}
catch (Exception e)
{
    // ignored
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
