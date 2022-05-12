using ChocoFactory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Services
{
    class FakeDatabase
    {
        //create data list for every Object that we need to test our application

        List<Customer> CustomersFake = new List<Customer>();
        List<Employee> EmployeesFake = new List<Employee>();
        List<Seller> SellersFake = new List<Seller>();

        
        List<Schocolate> ChocolatesFake = new List<Schocolate>();
        List<Shop> ShopsFake = new List<Shop>();
        
        
       
    }
}
