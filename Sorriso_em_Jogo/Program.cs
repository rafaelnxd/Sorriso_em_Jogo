using Sorriso_em_Jogo.Application.Services;
using Sorriso_em_Jogo.Infrastructure.Repositories;


using Microsoft.EntityFrameworkCore;
using Sorriso_em_Jogo.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurando o ApplicationDbContext com a string de conexão definida no appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar repositórios e serviços ao container
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IRecompensaRepository, RecompensaRepository>();
builder.Services.AddScoped<IHabitoRepository, HabitoRepository>();
builder.Services.AddScoped<IProcedimentoRepository, ProcedimentoRepository>();
builder.Services.AddScoped<IProcedimentosDaUnidadeRepository, ProcedimentosDaUnidadeRepository>();
builder.Services.AddScoped<IRegistroHabitoRepository, RegistroHabitoRepository>();
builder.Services.AddScoped<IUnidadeRepository, UnidadeRepository>();
builder.Services.AddScoped<IUsuarioColetandoRecompensaRepository, UsuarioColetandoRecompensaRepository>();

// Adicionar serviços ao container
builder.Services.AddScoped<FeedbackService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<RecompensaService>();
builder.Services.AddScoped<HabitoService>();
builder.Services.AddScoped<ProcedimentoService>();
builder.Services.AddScoped<ProcedimentosDaUnidadeService>();
builder.Services.AddScoped<RegistroHabitoService>();
builder.Services.AddScoped<UnidadeService>();
builder.Services.AddScoped<UsuarioColetandoRecompensaService>();

// Configurando Swagger e Endpoints
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
