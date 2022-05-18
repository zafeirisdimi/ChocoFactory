using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Interfaces
{
    public interface IChocolateModel : IProductModel
    {
        DateTime ExpirationDate { get;}
    }
}
