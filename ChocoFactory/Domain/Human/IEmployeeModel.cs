using ChocoFactory.Interfaces;

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