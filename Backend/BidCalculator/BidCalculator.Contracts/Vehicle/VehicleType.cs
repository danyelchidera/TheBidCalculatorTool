using System.Text.Json.Serialization;

namespace BidCalculator.Contracts.Vehicle;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VehicleType
{
    Common,
    Luxury
}