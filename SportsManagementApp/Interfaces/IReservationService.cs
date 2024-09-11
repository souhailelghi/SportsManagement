using SportsManagementApp.Models;

namespace SportsManagementApp.Interfaces
{
    public interface IReservationService
    {
        Task<bool> CanReserveAsync(int userId, string fieldType, string part);
        Task<Reservation> CreateReservationAsync(Reservation reservation);
    }
}
