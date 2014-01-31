using System;
using StefanStore.Repository.Abstract;
using StefanStore.Repository.Abstract.UnitOfWork;
using StefanStore.Repository.Concrete.Repository;

namespace StefanStore.Repository.Concrete.UnitOfWork
{
    internal class StefanStoreUow : IUnitOfWork, IDisposable
    {
        private StefanStoreDbContext DbContext { get; set; }
        private IProductRepository _products;

        public StefanStoreUow()
        {
            CreateDbContext();
        }

        private void CreateDbContext()
        {
            DbContext = new StefanStoreDbContext();

            DbContext.Configuration.ProxyCreationEnabled = false;
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        #region IUnitOfWork
        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductRepository(DbContext);
                }
                return _products;
            }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }
        #endregion
    }
}
