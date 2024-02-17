using Almoxarifado_API.Metodos;
using Almoxarifado_API.Models;

var categorias = new List<Categorias>();
var departamentos = new List<Departamentos>
{
    new Departamentos
    {
        idDep = 1,
        Descricao = "RH",
        Funcionarios = new List<Funcionarios>
        {
            new Funcionarios
            {
                FuncNome = "Pedrinho",
                Cargo = new Cargos
                {
                    CargosNome = "marceneiro"
                }
            },
            new Funcionarios
            {
                FuncNome = "Ana Julia",
                Cargo = new Cargos
                {
                    CargosNome = "professora"
                }
            }
        }
    }
};
var motivos = new List<Motivos>();
var estoques = new List<Estoques>
{
    new Estoques
    {
        Produtos = new List<Produtos>
        {
            new Produtos {Estoque = 5},
            new Produtos { Estoque = 6},
            new Produtos { Estoque = 7},
            new Produtos { Estoque = 8},
            new Produtos { Estoque = 9}
        }
    }
};
var funcionarios = new List<Funcionarios>
{


    new Funcionarios
    {
        FuncNome = "João",
       
    },
    new Funcionarios
    {
        FuncNome = "Marcela",
      
    }

};



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(categorias);
builder.Services.AddSingleton(departamentos);
builder.Services.AddSingleton(motivos);
builder.Services.AddSingleton(estoques);
builder.Services.AddSingleton(funcionarios);

builder.Services.AddSingleton<CrudProdutos>();

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
