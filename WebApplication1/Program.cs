var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// {
//     if (!optionsBuilder.IsConfigured)
//     {
//         optionsBuilder.UseNpgsql(@"Server=localhost; Port=5432; Database=postgres; User Id=postgres; Password = password;");
//     }
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
