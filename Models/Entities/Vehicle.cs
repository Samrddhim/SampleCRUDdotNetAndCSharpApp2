namespace SampleCRUDusingDotNetAndCSharp2.Models.Entities
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public required string VehicleName { get; set; }
        public int? EngineCapacity { get; set; }
        public required double Price { get; set; }


    }
}
