
//Criando o Construtor
var builder = WebApplication.CreateBuilder(args);

//Adicionando Serviços (Injeção de Dependência)
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


//var app = builder.Build();
var app = builder.Build();

//Configurando o Pipeline (O fluxo de requisições)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Regras de Segurança e Rotas
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Ligando o Servidor
app.Run();
