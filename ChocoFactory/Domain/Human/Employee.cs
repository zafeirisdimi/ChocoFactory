using ChocoFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public class Employee : Human 
    {
       
        //properties
        public int ID { get; set; }
        public decimal Salary { get; set; }
        public int DeparmentId { get; set; }
        public int ManagerId { get; set; }
        //default constructor

        //custom constructor
        //methods
    }
}
