namespace VehicleDiagnosticAPI.Models
{
    public class VehicleStatus
    {
        public int Id { get; set; }

        public int EngineTemperature { get; set; }

        public int OilPressure { get; set; }

        public int CoolantLevel { get; set; }

        public string Status { get; set; } = string.Empty;
        public bool FanActive { get; set; }
        public bool EmergencyMode { get; set; }
    }
}
