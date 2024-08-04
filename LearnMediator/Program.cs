using FluentValidation;
using LearnMediator;
using LearnMediator.Abstractions.Shared.Behaviors;
using LearnMediator.Repositories.UserRepository;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(configuration => configuration
                .RegisterServicesFromAssemblies(typeof(ILearnMediator).Assembly));

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipeLineBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(ILearnMediator).Assembly,includeInternalTypes: true);

builder.Services.AddSingleton<FakeStoreData>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
