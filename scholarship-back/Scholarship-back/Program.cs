using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Scholarship_back.Data;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Scholarship_back.ScholarshipApplication.Services.ApplicationFormService;
using Scholarship_back.ScholarshipApplication.Services.SubmitionDeadlineService;
using NETCore.MailKit.Core;
using Scholarship_back.ScholarshipEvaluation.Interface;
using Scholarship_back.ScholarshipEvaluation.Service;
using Scholarship_back.ScholarshipManager.Interfaces;
using Scholarship_back.ScholarshipManager.Services;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.Outer.Services;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Services;
using Scholarship_back.ScholarshipApplication.Services.EmailSender;
using IEmailService = Scholarship_back.ScholarshipApplication.Services.EmailSender.IEmailService;
using EmailService = Scholarship_back.ScholarshipApplication.Services.EmailSender.EmailService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddScoped<IStudent, IStudentService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IApplicationFormService, ApplicationFormService>();
builder.Services.AddScoped<IVerification, Verification>();
builder.Services.AddScoped<IScholarship, IScholarshipService>();
builder.Services.AddScoped<FacultyInterface, FacultyService>();
builder.Services.AddScoped<HighSchoolInterface, HighSchoolService>();
builder.Services.AddScoped<IEApplicationForm, AllSubmitionsService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateTokenReplay = true
        };
    });

var app = builder.Build();

app.UseCors(options =>
options.WithOrigins("http://localhost:8080")
.AllowAnyMethod()
.AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiUploadFile v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
