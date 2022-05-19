using ChocoFactory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public interface IHumanModel
    {
        string FirstName { get; }
        string LastName { get; }

    }
}
