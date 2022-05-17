using ChocoFactory.Domain;
using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Service
{
    public static class CsvHelper
    {
        public static void ReadCsvFileEmployee()
        {
            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                IgnoreUnknownColumns = true,
                SeparatorChar = ',',
                UseFieldIndexForReadingData = false
            };

            var csvContext = new CsvContext();
            var EmployeesDummy = csvContext.Read<Employee>("employeesfake.csv", csvFileDescription);
            Console.WriteLine("|Just created a new fake list of employees|");
            foreach (var employee in EmployeesDummy)
            {
                Console.WriteLine($"|ID: {employee.ID }\t|Salary: {employee.Salary}\t|DeparmentID: {employee.DeparmentId}|\t|ManagerID: {employee.ManagerId}");
            }

        }

        public static void ReadCsvFileSupplier()
        {
            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                IgnoreUnknownColumns = true,
                SeparatorChar = ',',
                UseFieldIndexForReadingData = false
            };

            var csvContext = new CsvContext();
            var EmployeesDummy = csvContext.Read<Employee>("employeesfake.csv", csvFileDescription);
            Console.WriteLine("Just created a new fake list of employees");

        }
    }
}
