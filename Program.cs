var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURACIÓN DE SERVICIOS ---
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); // Configuración simplificada para evitar errores de namespace

var app = builder.Build();

// --- 2. CONFIGURACIÓN DEL PIPELINE ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Por defecto buscará /swagger/index.html
}

app.UseHttpsRedirection();

// --- 3. BASE DE DATOS TEMPORAL Y RUTAS ---
var clientes = new List<Cliente>
{
    new Cliente("1712345678001", "Consumidor Final", "ventas@pcsbur.com")
};

app.MapGet("/api/clientes", () => Results.Ok(clientes))
   .WithName("GetClientes");

app.MapPost("/api/clientes", (Cliente nuevoCliente) => {
    clientes.Add(nuevoCliente);
    return Results.Created($"/api/clientes/{nuevoCliente.Ruc}", nuevoCliente);
})
.WithName("CreateCliente");

app.Run();

// El modelo de datos (Record) debe ir al final, fuera de las llaves si las hubiera
public record Cliente(string Ruc, string Nombre, string Email);