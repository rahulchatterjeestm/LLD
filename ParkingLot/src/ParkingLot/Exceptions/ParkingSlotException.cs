using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
