using PatientInformationsAPI.Model;
using PatientInformationsAPI.Repository.Allergy;
using PatientInformationsAPI.Repository.DiseaseDetails;
using PatientInformationsAPI.Repository.NCD;
using PatientInformationsAPI.Repository.PatientDetails;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PatientInformationContext>();

builder.Services.AddScoped<IPatientDetailsRepository, PatientDetailsRepository>();
builder.Services.AddScoped<IDiseaseDetailsRepository, DiseaseDetailsRepository>();
builder.Services.AddScoped<IAllergyRepository, AllergyRepository>();
builder.Services.AddScoped<INCDRepository, NCDRepository>();

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(name: "PatientDetailsFrontEnd",
            policy => policy.WithOrigins("https://localhost:7290/")
            .AllowAnyHeader()
            .AllowAnyMethod()
            );
    }

    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PatientDetailsFrontEnd");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
