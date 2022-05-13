using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public abstract class Department
    {
        //properties
        public int DepartmentID { get; set; }
        public string Description { get; set; }

        public int ManagerID { get; set; }

       

        //methods

    }
}
