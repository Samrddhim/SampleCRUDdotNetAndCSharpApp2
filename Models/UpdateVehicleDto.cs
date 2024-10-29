namespace SampleCRUDusingDotNetAndCSharp2.Models
{
    public class UpdateVehicleDto
    {
        public required string VehicleName { get; set; }
        public int? EngineCapacity { get; set; }
        public required double Price { get; set; }
    }
}
