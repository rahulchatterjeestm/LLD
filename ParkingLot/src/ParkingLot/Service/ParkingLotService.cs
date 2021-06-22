using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Exceptions;
using ParkingLot.Models;
using ParkingLot.Models.Strategy;

namespace ParkingLot.Service
{
    public class ParkingLotService
    {
        private Models.ParkingLot parkingLot;
        private IParkingStrategy parkingStrategy;

        public void CreateParkingLot(Models.ParkingLot parkingLot, IParkingStrategy parkingStrategy)
        {
            if(this.parkingLot != null)
            {
                throw new ParkingLotException("Parking lot already exists");
            }

            this.parkingLot = parkingLot;
            this.parkingStrategy = parkingStrategy;
            for(int i=1; i<=parkingLot.Capacity; i++)
            {
                this.parkingStrategy.AddSlot(i);
            }
        }

        public int Park(Car car)
        {
            ValidateParkingLotExists();
            var nextSlot = this.parkingStrategy.GetNextSlot();
            this.parkingLot.Park(car, nextSlot);
            parkingStrategy.RemoveSlot(nextSlot);
            return nextSlot;
        }

        private void ValidateParkingLotExists()
        {
            if(this.parkingLot == null)
            {
                throw new ParkingLotException("Parking lot doesn't exist");
            }
        }
    }
}
