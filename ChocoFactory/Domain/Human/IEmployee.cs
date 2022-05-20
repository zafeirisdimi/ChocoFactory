using ChocoFactory.Interfaces;

namespace ChocoFactory.Domain
{
    public interface IEmployee : IHuman
    {
        int ID { get; }
        int DeparmentId { get; }
        int ManagerId { get; }
        decimal Salary { get; }

        string Email { get; }
    }
}