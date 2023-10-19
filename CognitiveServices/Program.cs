using CognitiveServices.Services;

var builder = WebApplication.CreateBuilder(args);

var policyName = "_myAllowSpecificOrigins";

//// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                         builder =>
                         {
                             builder
                               .AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                         });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddScoped<IComputerVisionClientService, ComputerVisionClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(policyName);

app.UseAuthorization();

app.MapControllers();

app.Run();