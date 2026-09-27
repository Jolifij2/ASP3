using BookApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// DI: регистрация сервиса. Scoped — один экземпляр на HTTP-запрос
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
