using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    public class Command
    {
        public string CommandName { get; }
        public List<string> Params { get; }

        public Command(string inputLine)
        {
            List<string> tokenList = inputLine.Split().Where(i => i.Length>0).ToList();
            if(tokenList.Count() == 0)
            {
                throw new Exception(); //invalid cmd
            }

            this.CommandName = tokenList[0];
            tokenList.RemoveAt(0);
            this.Params = tokenList;
        }
    }
}
