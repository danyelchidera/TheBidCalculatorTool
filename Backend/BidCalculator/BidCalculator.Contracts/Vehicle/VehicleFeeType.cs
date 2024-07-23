using System.Text.Json.Serialization;

namespace BidCalculator.Contracts.Vehicle;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VehicleFeeType
{
    Basic,
    Special,
    Association,
    Storage
    
}