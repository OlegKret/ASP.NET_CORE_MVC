using System.ComponentModel.DataAnnotations;

namespace TrainSchedule.Models
{
    public class Train
    {
        public int Id { get; set; }

        [Display(Name = "Departure City")]
        public string DepartureCity { get; set; } 

        [Display(Name = "Arrival City")]
        public string ArrivalCity { get; set; }

        [Display(Name = "Train Number")]
        public string TrainNumber { get; set; } 

        [Display(Name = "Available Seats")]
        public int AvailableSeats { get; set; } 
    }
}