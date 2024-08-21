namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IShipRepository Ship { get; }
        ICargoRepository Cargo { get; }
        void Save();
    }
}