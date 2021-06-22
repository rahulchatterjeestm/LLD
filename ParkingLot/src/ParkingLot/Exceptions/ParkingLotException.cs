using System;

namespace ParkingLot.Exceptions
{
    public class ParkingLotException: Exception
    {
        public ParkingLotException()
        {
        }

        public ParkingLotException(string message): base(message)
        {            
        }
    }
}
