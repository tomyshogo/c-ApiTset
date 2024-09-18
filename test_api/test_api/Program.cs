var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// CORSポリシーを追加（例: Reactアプリからのリクエストを許可）
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // Reactアプリが動作しているURL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Swagger/OpenAPIの設定
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

// CORSを有効にする
app.UseCors("AllowReactApp");

app.MapControllers();

app.Run();
