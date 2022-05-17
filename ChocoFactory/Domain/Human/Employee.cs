using ChocoFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;

namespace ChocoFactory.Domain

{
    [Serializable]
    public class Employee
    {
        [CsvColumn(Name = "ID",FieldIndex = 1)]
        //properties
        public int ID { get; set; }
        [CsvColumn(Name = "Salary", FieldIndex = 2)]
        public decimal Salary { get; set; }
        [CsvColumn(Name = "DeparmentId", FieldIndex = 3)]
        public int DeparmentId { get; set; }
        [CsvColumn(Name = "ManagerId", FieldIndex = 4)]
        public int ManagerId { get; set; }
        //default constructor

        //custom constructor
        //methods
    }
}
