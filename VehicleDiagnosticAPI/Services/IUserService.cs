using VehicleDiagnosticAPI.DTOs;
using VehicleDiagnosticAPI.Models;

namespace VehicleDiagnosticAPI.Services
{
    public interface IUserService
    {
        Task<VehicleStatus> AnalyzeVehicleAsync(CreateVehicleStatusDto dto);

        List<VehicleStatus> GetHistory();

        string GetSystemHealth();
    }
}