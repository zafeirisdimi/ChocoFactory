using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public abstract class Human
    {
        //properties of object Human
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double PhoneNumber { get; set; }

        public char Sex { get; set; }


        protected Human(string firstName, string lastName, double phoneNumber, char sex)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Sex = sex;
        }


        //methods
    }
}
