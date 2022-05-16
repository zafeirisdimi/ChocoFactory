using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Interfaces
{
    interface IHumanModel
    {
        int ID { get; }
        string FirstName { get; }
        string LastName { get; }
        double Phone { get; }
        string Email { get; }

       
    }
}
