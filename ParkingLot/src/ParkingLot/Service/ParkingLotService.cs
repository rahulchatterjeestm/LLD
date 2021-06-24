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

        public void MakeSlotFree(int slotNum)
        {
            this.ValidateParkingLotExists();
            this.parkingLot.MakeSlotFree(slotNum);
            this.parkingStrategy.AddSlot(slotNum);
        }

        public List<Slot> GetOccupiedSlots()
        {
            ValidateParkingLotExists();
            var occupidSlotList = new List<Slot>();
            var allSlots = this.parkingLot.Slots;

            for(int i=1; i<=this.parkingLot.Capacity; i++)
            {
                if(allSlots.ContainsKey(i))
                {
                    var slot = allSlots[i];
                    if(!slot.IsSlotFree)
                    {
                        occupidSlotList.Add(slot);
                    }
                }
            }

            return occupidSlotList;
        }

        public List<Slot> GetSlotsForColor(string color)
        {
            var occupiedSlots = this.GetOccupiedSlots();
            return occupiedSlots.Where(slot => slot.GetParkedCar.Color == color).ToList();
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
