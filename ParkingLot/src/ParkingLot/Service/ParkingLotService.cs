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
                throw new ParkingSlotException("Parking lot already exists");
            }

            this.parkingLot = parkingLot;
            this.parkingStrategy = parkingStrategy;
            for(int i=1; i<=parkingLot.Capacity; i++)
            {
                this.parkingStrategy.AddSlot(i);
            }
        }

    }
}
