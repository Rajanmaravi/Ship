using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Repository
{
    public class ShipRepository : RepositoryBase<Ship>, IShipRepository
    {
        public ShipRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateShip(Ship ship)
        {
            Create(ship);
        }

        public void UpdateShip(Ship ship)
        {
            Update(ship);
        }

        public void DeleteShip(Ship ship)
        {
            Delete(ship);
        }

        public IEnumerable<Ship> GetAllShips()
        {
            return FindAll().OrderBy(sh => sh.Company).ToList();
        }

        public Ship GetShipById(int id)
        {
            return FindByCondition(ship => ship.Id.Equals(id)).FirstOrDefault();
        }

        public Ship GetShipWithDetails(int id)
        {
            return FindByCondition(ship => ship.Id.Equals(id)).Include(ca => ca.Cargos).FirstOrDefault();
        }
    }
}
