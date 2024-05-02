using MailSender.Extensions;
using MailSender.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => { options.AllowEmptyInputInBodyModelBinding = true; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClients(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddMapper();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

app.UseExceptionHandler(_ => { });
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();