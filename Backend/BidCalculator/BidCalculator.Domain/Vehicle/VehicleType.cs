
namespace BidCalculator.Domain.Vehicle;

public record VehicleType(int Id, string Name)
{
    public static VehicleType Common = new(0, "Common");

    public static VehicleType Luxury = new(1, "Luxury");

    public override string ToString() => Name;
    
    public static VehicleType GetVehicleTypeById(int id)
    {
        return id switch
        {
            0 => Common,
            1 => Luxury,
            _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
        };
    }
    
    public static bool TryGetVehicleTypeByName(string name, out VehicleType vehicleType)
    {
        switch (name.ToLower())
        {
            case "common":
                vehicleType = Common;
                return true;
            case "luxury":
                vehicleType = Luxury;
                return true;
            default:
                vehicleType = default;
                return false;
        }
    }

    public static IEnumerable<VehicleType> GetAllVehicleTypes()
    {
        return new List<VehicleType>
        {
            Common,
            Luxury
        };
    }
}