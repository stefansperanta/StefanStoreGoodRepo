using StefanStore.Repository.Abstract;

namespace StefanStore.Repository.Abstract.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        //void Rollback();

        IProductRepository Products { get; }
    }
}
