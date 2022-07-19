using System.ComponentModel.DataAnnotations;

namespace Samples.Core.Models
{
    public abstract class Vehicle
    {
        [Required]
        [Display(Name = "Vehicle model")] 
        public string? Model { get; set; }
        
        public abstract int Wheels { get; }
    }

    public class Car : Vehicle
    {
        public override int Wheels 
        {
            get => 4;
        }
    }

    public class Motorbike : Vehicle
    {
        public override int Wheels
        {
            get => 2;
        }
    }
}
