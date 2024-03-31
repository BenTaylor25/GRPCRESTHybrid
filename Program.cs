using GRPCRESTHybrid.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddGrpc();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    app.MapGrpcService<GreeterService>();
    app.UseHttpsRedirection();
    app.MapControllers();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
