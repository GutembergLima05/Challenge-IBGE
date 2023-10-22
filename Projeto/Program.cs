using Projeto.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<RelatorioDbContext>();
var app = builder.Build();
app.MapControllers();
app.Run();
