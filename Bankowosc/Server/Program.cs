using Bankowosc.Server.Models;
using Bankowosc.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Bankowosc.Server.Entities.encryptEntities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<BankService>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//builder.Services.AddScoped<EncryptCreditCard>();
EncryptCreditCard.SetKey(builder.Configuration.GetSection("CreditCard:k1").Value,builder.Configuration.GetSection("CreditCard:k2").Value,builder.Configuration.GetSection("CreditCard:k3").Value,builder.Configuration.GetSection("CreditCard:k4").Value);
EncryptUser.setKey(builder.Configuration.GetSection("User:k1").Value,builder.Configuration.GetSection("User:k2").Value,builder.Configuration.GetSection("User:k3").Value,builder.Configuration.GetSection("User:k4").Value);
EncryptTransaction.setKey(builder.Configuration.GetSection("Transaction:k1").Value,builder.Configuration.GetSection("Transaction:k2").Value,builder.Configuration.GetSection("Transaction:k3").Value,builder.Configuration.GetSection("Transaction:k4").Value,builder.Configuration.GetSection("Transaction:k5").Value);

string token = builder.Configuration.GetSection("Token").Value;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
       
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token)),
            ValidateIssuerSigningKey = true,
        };
    });

var app = builder.Build();
// /*
using (var serviceScope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
    var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
    if (pendingMigrations.Any())
    {
        Console.WriteLine($"Applying {pendingMigrations.Count()} pending migrations.");
        await dbContext.Database.MigrateAsync();
    }
    else
    {
        Console.WriteLine("No pending migrations.");
    }
} 
// */

app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

//app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
