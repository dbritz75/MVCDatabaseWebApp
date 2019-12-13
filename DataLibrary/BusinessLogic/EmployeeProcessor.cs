using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class EmployeeProcessor
    {
        public static int CreateEmployee(int EID, string fname, string lname, string email)
        {
            EmployeeModel data = new EmployeeModel
            {
                employeeID = EID,
                firstName = fname,
                lastName = lname,
                Email = email
            };

            string sql = @"INSERT INTO dbo.Employees (EmployeeID, FirstName, LastName, Email) VALUES(@employeeID, @firstName, @lastName, @email);";
            return SQLDataAccess.SaveData(sql, data);
        }

        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = "SELECT ID, EmployeeID, FirstName, LastName, Email FROM dbo.Employees;";
            return SQLDataAccess.LoadData<EmployeeModel>(sql);
        }
    }
}
