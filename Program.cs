using Microsoft.EntityFrameworkCore;
using TrainSchedule.Models;
using Microsoft.AspNetCore.Authorization; 
using TrainSchedule.Data; 

var builder = WebApplication.CreateBuilder(args);

// DbContext configuration (with seeding)
builder.Services.AddDbContext<TrainScheduleDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TrainScheduleDb"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }),
    ServiceLifetime.Scoped // Make sure it's scoped
); 


builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();

var app = builder.Build();  // 'app' is declared here

// Database Migration and Seeding
using (var scope = app.Services.CreateScope()) // Use the existing 'app'
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<TrainScheduleDbContext>();
        context.Database.Migrate(); // Apply migrations

        // Check if data already exists, then seed 
        if (!context.Trains.Any())
        {
            context.Trains.AddRange(
                new Train { Id = 1, DepartureCity = "Харків", ArrivalCity = "Одеса", TrainNumber = "DE1", AvailableSeats = 20 },
                new Train { Id = 2, DepartureCity = "Київ", ArrivalCity = "Одеса", TrainNumber = "WE5", AvailableSeats = 48 },
                new Train { Id = 3, DepartureCity = "Харків", ArrivalCity = "Рубіжне", TrainNumber = "R45", AvailableSeats = 35 },
                // ... (the rest of your train data)
                new Train { Id = 4, DepartureCity = "Київ", ArrivalCity = "Рубіжне", TrainNumber = "D4", AvailableSeats = 5 },
                new Train { Id = 5, DepartureCity = "Київ", ArrivalCity = "Суми", TrainNumber = "WE5", AvailableSeats = 48 },
                new Train { Id = 6, DepartureCity = "Лисичанськ", ArrivalCity = "Київ", TrainNumber = "WE5", AvailableSeats = 48 },
                // Add more train data with different cities as needed
                new Train { Id = 7, DepartureCity = "Львів", ArrivalCity = "Київ", TrainNumber = "IC123", AvailableSeats = 30 }
            );
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();