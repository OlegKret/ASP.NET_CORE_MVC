using Microsoft.EntityFrameworkCore;
using TrainSchedule.Models;

namespace TrainSchedule.Data 
{
    public class TrainDbInitializer : IEntityTypeConfiguration<Train>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Train> builder)
        {
            builder.HasData(
                new Train { Id = 1, DepartureCity = "Харків", ArrivalCity = "Одеса", TrainNumber = "DE1", AvailableSeats = 20 },
                new Train { Id = 2, DepartureCity = "Київ", ArrivalCity = "Одеса", TrainNumber = "WE5", AvailableSeats = 48 },
                new Train { Id = 3, DepartureCity = "Харків", ArrivalCity = "Рубіжне", TrainNumber = "R45", AvailableSeats = 35 },
                new Train { Id = 4, DepartureCity = "Київ", ArrivalCity = "Рубіжне", TrainNumber = "D4", AvailableSeats = 5 },
                new Train { Id = 5, DepartureCity = "Київ", ArrivalCity = "Суми", TrainNumber = "WE5", AvailableSeats = 48 },
                new Train { Id = 6, DepartureCity = "Лисичанськ", ArrivalCity = "Київ", TrainNumber = "WE5", AvailableSeats = 48 },
                // Add more train data with different cities as needed
                new Train { Id = 7, DepartureCity = "Львів", ArrivalCity = "Київ", TrainNumber = "IC123", AvailableSeats = 30 }
            );
        }
    }
}