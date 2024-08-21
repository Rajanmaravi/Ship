using Contracts;
using Entities;
using Entities.Models;

namespace Services.Repository
{
    public class CargoRepository : RepositoryBase<Cargo>, ICargoRepository
    {
        public CargoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCargo(Cargo cargo)
        {
            Create(cargo);
        }

        public void DeleteCargo(Cargo cargo)
        {
            Delete(cargo);
        }

        public void UpdateCargo(Cargo cargo)
        {
            Update(cargo);
        }

        public Cargo GetCargoById(int id)
        {
            return FindByCondition(cargo => cargo.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Cargo> CargoByShip(int shipId)
        {
            return FindByCondition(c => c.ShipId.Equals(shipId)).ToList();
        }
    }
}