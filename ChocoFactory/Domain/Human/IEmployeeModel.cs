using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public interface IEmployeeModel : IHumanModel
    {
        int EmployeeID { get; }
        int DeparmentId { get; }
        int ManagerId { get; }
        decimal Salary { get; }

        string EmailAddres { get; }
    }
}