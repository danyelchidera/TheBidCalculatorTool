namespace BidCalculator.Domain.Vehicle;
public record VehicleFeeType(int Id, string Name)
{
    public static VehicleFeeType Basic = new(0, "Basic");

    public static VehicleFeeType Special = new(1, "Special");
    
    public static VehicleFeeType Association = new(2, "Association");
    
    public static VehicleFeeType Storage= new(3, "Storage");
   

    public override string ToString() => Name;
    
    public static VehicleFeeType GetVehicleFeeTypeById(int id)
    {
        return id switch
        {
            0 => Basic,
            1 => Special,
            2 => Association,
            3 => Storage,
            _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
        };
    }

    public static IEnumerable<VehicleFeeType> GetAllVehicleFeeTypes()
    {
        return new List<VehicleFeeType>
        {
            Basic,
            Special,
            Association,
            Storage
        };
    }
}