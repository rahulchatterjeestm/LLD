namespace ParkingLot.Models.Strategy
{
    public interface IParkingStrategy
    {
        void AddSlot(int slotNum);
        void RemoveSlot(int slotNum);
        int GetNextSlot();
    }
}
