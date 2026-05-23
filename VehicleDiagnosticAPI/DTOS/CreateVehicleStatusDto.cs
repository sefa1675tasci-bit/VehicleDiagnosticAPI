using System.ComponentModel.DataAnnotations;

namespace VehicleDiagnosticAPI.DTOs
{
    public class CreateVehicleStatusDto
    {
        [Range(0, 150)]
        public int EngineTemperature { get; set; }

        [Range(0, 100)]
        public int OilPressure { get; set; }

        [Range(0, 100)]
        public int CoolantLevel { get; set; }
    }
}