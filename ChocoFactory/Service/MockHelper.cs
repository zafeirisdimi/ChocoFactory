using ChocoFactory.Domain;
using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Service
{
    public static class MockHelper
    {
         public static List<IEmployeeModel> EmployeesMockList()
        {
            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                IgnoreUnknownColumns = true,
                SeparatorChar = ',',
                UseFieldIndexForReadingData = false
            };

            var csvContext = new CsvContext();
            var EmployeesMock = csvContext.Read<Employee>("MockFiles/employeesmock.csv", csvFileDescription);
            Console.WriteLine("|Just created a new mock list of employees|");
            List<IEmployeeModel> EmployeesMockList = new List<IEmployeeModel>();
            foreach (var employee in EmployeesMock)
            {
                //Console.WriteLine($"|ID: {employee.ID }\t|Salary: {employee.Salary}\t|DeparmentID: {employee.DeparmentId}|\t|ManagerID: {employee.ManagerId}");
                if (employee.DeparmentId == 2)
                {
                    EmployeesMockList.Add(employee);
                }
            }
            return EmployeesMockList;
        }

        
    }
}
