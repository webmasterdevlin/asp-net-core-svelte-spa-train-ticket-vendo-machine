using TrainTicketMachine.Application;
using TrainTicketMachine.Data;
using TrainTicketMachine.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddApiVersioningExtension();
builder.Services.AddVersionedApiExplorerExtension();
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(b =>
{
    b.AllowAnyOrigin();
    b.AllowAnyHeader();
    b.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();