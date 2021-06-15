namespace ParkingLot.Models
{
    public class Slot
    {
        private Car parkedCar;
        private int slotNumber;

        public Slot(int slotNum)
        {
            this.slotNumber = slotNum;
        }

        public Car GetParkedCar => parkedCar;

        public bool IsSlotFree => parkedCar == null;

        public void AssingCar(Car car)
        {
            this.parkedCar = car;
        }

        public void UnassignCar()
        {
            this.parkedCar = null;
        }
    }
}
