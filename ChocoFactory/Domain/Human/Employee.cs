using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;

namespace ChocoFactory.Domain

{
    [Serializable]
    public class Employee : IEmployeeModel
    {

        //properties
        [CsvColumn(Name = "ID", FieldIndex = 1)]
        public int EmployeeID { get; set; }

        [CsvColumn(Name = "Salary", FieldIndex = 2)]
        public decimal Salary { get; set; }

        [CsvColumn(Name = "DeparmentId", FieldIndex = 3)]
        public int DeparmentId { get; set; }

        [CsvColumn(Name = "ManagerId", FieldIndex = 4)]
        public int ManagerId { get; set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string EmailAddres { get; private set; }

        public double Phone ;

        //default constructor

        //custom constructor
        //methods
    }
}
