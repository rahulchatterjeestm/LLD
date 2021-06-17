using ParkingLot.Exceptions;
using System;
using System.Collections.Generic;

namespace ParkingLot.Models.Strategy
{
    class NaturalOrderParkingStrategy : IParkingStrategy
    {
        private SortedSet<int> sortedSet;

        public NaturalOrderParkingStrategy()
        {
            this.sortedSet = new SortedSet<int>();
        }
        public void AddSlot(int slotNum)
        {
            this.sortedSet.Add(slotNum);
        }

        public int GetNextSlot()
        {
            if(this.sortedSet.Count == 0)
            {
                throw new NoFreeSlotAvailableException();
            }
            return this.sortedSet.Min;
        }

        public void RemoveSlot(int slotNum)
        {
            this.sortedSet.Remove(slotNum);
        }
    }
}
