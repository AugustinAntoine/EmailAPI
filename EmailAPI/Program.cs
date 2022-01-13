var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

#region Exemple test d'un service allignant simplement une température et un état
var summaries = new[]
{
    "Glacé", "Aéré", "Frais", "Moyen", "Chaud", "Brulant"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
#endregion

#region Nos services
string[] users = { "augustin.antoine.pro@gmail.com", "generalmadgus@gmail.com" };
//construction du mail
EmailAPI.MailHelper.SendMail("test@test.fr", users, "Hello", "Voici des nouvelles !");
//tâche terminée
Console.WriteLine("Mails envoyés...");
Console.Read();
#endregion

app.Run();

#region Exemple test d'un service allignant simplement une température et un état
internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
#endregion