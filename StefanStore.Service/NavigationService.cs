using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StefanStore.Repository.Abstract.UnitOfWork;

namespace StefanStore.Service
{
    public class NavigationService : INavigationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NavigationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<string> BuildMenu()
        {
            return _unitOfWork.Products.GetAll().Select(x => x.Category).Distinct().OrderBy(x => x);
        }
    }
}
