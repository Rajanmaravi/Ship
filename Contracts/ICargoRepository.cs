using Entities.Models;

namespace Contracts
{
    public interface ICargoRepository //: IRepositoryBase<Cargo>
    {
        Cargo GetCargoById(int id);
        IEnumerable<Cargo> CargoByShip(int shipId);
        void CreateCargo(Cargo cargo);
        void UpdateCargo(Cargo cargo);
        void DeleteCargo(Cargo cargo);
    }
}