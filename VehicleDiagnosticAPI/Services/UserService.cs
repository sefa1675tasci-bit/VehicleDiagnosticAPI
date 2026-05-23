using Microsoft.EntityFrameworkCore;
using VehicleDiagnosticAPI.Data;
using VehicleDiagnosticAPI.DTOs;
using VehicleDiagnosticAPI.Models;

namespace VehicleDiagnosticAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VehicleStatus> AnalyzeVehicleAsync(CreateVehicleStatusDto dto)
        {
            string status = "Normal";

            bool fanActive = false;

            bool emergencyMode = false;

            // CRITICAL
            if (dto.EngineTemperature > 110 ||
                dto.OilPressure < 20 ||
                dto.CoolantLevel < 20)
            {
                status = "Critical";

                emergencyMode = true;
            }

            // WARNING
            else if (dto.EngineTemperature > 90 ||
                     dto.OilPressure < 40 ||
                     dto.CoolantLevel < 40)
            {
                status = "Warning";
            }

            // FAN
            if (dto.EngineTemperature > 95)
            {
                fanActive = true;
            }

            var vehicleStatus = new VehicleStatus
            {
                EngineTemperature = dto.EngineTemperature,

                OilPressure = dto.OilPressure,

                CoolantLevel = dto.CoolantLevel,

                Status = status,

                FanActive = fanActive,

                EmergencyMode = emergencyMode
            };

            _context.VehicleStatuses.Add(vehicleStatus);

            await _context.SaveChangesAsync();

            return vehicleStatus;
        }

        public List<VehicleStatus> GetHistory()
        {
            return _context.VehicleStatuses
                .OrderByDescending(x => x.Id)
                .ToList();
        }

        public string GetSystemHealth()
        {
            int criticalCount = _context.VehicleStatuses
                .Count(x => x.Status == "Critical");

            int warningCount = _context.VehicleStatuses
                .Count(x => x.Status == "Warning");

            if (criticalCount >= 5)
            {
                return "Vehicle is in dangerous condition!";
            }

            if (warningCount >= 10)
            {
                return "Vehicle requires maintenance.";
            }

            return "Vehicle systems are stable.";
        }
    }
}