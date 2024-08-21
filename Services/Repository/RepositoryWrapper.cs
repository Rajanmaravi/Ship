using Contracts;
using Entities;

namespace Services.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IShipRepository? _ship;
        private ICargoRepository? _cargo;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IShipRepository Ship
        {
            get
            {
                if (_ship == null)
                {
                    _ship = new ShipRepository(_repositoryContext);
                }
                return _ship;
            }
        }

        public ICargoRepository Cargo
        {
            get
            {
                if (_cargo == null)
                {
                    _cargo = new CargoRepository(_repositoryContext);
                }
                return _cargo;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }

    }
}