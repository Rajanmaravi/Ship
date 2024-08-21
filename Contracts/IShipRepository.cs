using Entities.Models;

namespace Contracts
{
    public interface IShipRepository //: IRepositoryBase<Ship>
    {
        IEnumerable<Ship> GetAllShips();
        Ship GetShipById(int id);
        Ship GetShipWithDetails(int id);
        void CreateShip(Ship ship);
        void UpdateShip(Ship ship);
        void DeleteShip(Ship ship);
    }
}