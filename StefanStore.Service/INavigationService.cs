using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefanStore.Service
{
    public interface INavigationService
    {
        IEnumerable<string> BuildMenu();
    }
}
