
namespace DataPlus.Bar.Contracts.Repositories
{
    public interface IWrapperRepository
    {
        ICubeRepository Cube { get; }
        void Save();
    }
}
