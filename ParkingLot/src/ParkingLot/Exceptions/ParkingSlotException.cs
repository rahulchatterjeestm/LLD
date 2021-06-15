using System;

namespace ParkingLot.Exceptions
{
    public class ParkingSlotException: Exception
    {
        public ParkingSlotException()
        {
        }

        public ParkingSlotException(string message): base(message)
        {            
        }
    }
}
