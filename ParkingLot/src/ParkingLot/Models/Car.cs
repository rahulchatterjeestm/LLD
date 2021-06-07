namespace ParkingLot.Models
{
    public class Car
    {
        public string RegisterationNumber { get; }
        public string Color { get; }

        public Car(string registerationNumber, string color)
        {
            this.RegisterationNumber = registerationNumber;
            this.Color = color;
        }

    }
}
