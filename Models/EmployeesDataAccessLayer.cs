using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using RegCRUD.Utility;

namespace RegCRUD.Models
{
    public static class Extensions
    {
        /// <summary>
        ///     A generic extension method that aids in reflecting 
        ///     and retrieving any attribute that is applied to an `Enum`.
        /// </summary>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) 
            where TAttribute : Attribute
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<TAttribute>();
        }
    }
    public class EmployeesDataAccessLayer
    {
        readonly string _connectionString = ConnectionString.CName;

        public IEnumerable<Employees> GetAllEmployee()  
        {  
            var lstEmployee = new List<Employees>();  
            using (var con = new SqlConnection(_connectionString))  
            {  
                var cmd = new SqlCommand("spGetAllEmployees", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
                con.Open();  
                var rdr = cmd.ExecuteReader();  
  
                while (rdr.Read())  
                {  
                    var employee = new Employees();  
                    employee.Id = Convert.ToInt32(rdr["Id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.SecondName = rdr["SecondName"].ToString();
                    employee.MiddleName = rdr["MiddleName"].ToString();
                    employee.Company = rdr["Company"].ToString();
                    employee.Position = (PositionName) Enum.Parse(typeof(PositionName), rdr["Position"].ToString() ?? string.Empty);
                    employee.HiringDate = Convert.ToDateTime(rdr["HiringDate"]);

                    lstEmployee.Add(employee);  
                }  
                con.Close();  
            }  
            return lstEmployee;  
        }
        
        public void AddEmployees(Employees employee)  
        {  
            using (var con = new SqlConnection(_connectionString))  
            {  
                var cmd = new SqlCommand("spAddEmployees", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
  
                cmd.Parameters.AddWithValue("@Name", employee.Name);  
                cmd.Parameters.AddWithValue("@SecondName", employee.SecondName);  
                cmd.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                cmd.Parameters.AddWithValue("@Company", employee.Company);
                cmd.Parameters.AddWithValue("@HiringDate", employee.HiringDate);
                cmd.Parameters.AddWithValue("@Position", employee.Position);
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }  
        
            public void UpdateEmployees(Employees employee)  
        {  
            using (var con = new SqlConnection(_connectionString))  
            {  
                var cmd = new SqlCommand("spUpdateEmployees", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
  
                cmd.Parameters.AddWithValue("@Id", employee.Id);  
                cmd.Parameters.AddWithValue("@Name", employee.Name);  
                cmd.Parameters.AddWithValue("@SecondName", employee.SecondName);  
                cmd.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                cmd.Parameters.AddWithValue("@Company", employee.Company);
                cmd.Parameters.AddWithValue("@HiringDate", employee.HiringDate);
                //var positionDisplayName = employee.Position.GetAttribute<DisplayAttribute>();   
                //cmd.Parameters.AddWithValue("@Position", positionDisplayName.Name); 
                cmd.Parameters.AddWithValue("@Position", employee.Position);
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }  
  
        public Employees GetEmployeesData(int? id)  
        {  
            var employee = new Employees();  
  
            using (var con = new SqlConnection(_connectionString))  
            {  
                var sqlQuery = "SELECT * FROM Employee WHERE Id= " + id;  
                var cmd = new SqlCommand(sqlQuery, con);  
                con.Open();  
                var rdr = cmd.ExecuteReader();  
  
                while (rdr.Read())  
                {  
                    employee.Id = Convert.ToInt32(rdr["Id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.SecondName = rdr["SecondName"].ToString();
                    employee.MiddleName = rdr["MiddleName"].ToString();
                    employee.Company = rdr["Company"].ToString();
                    employee.Position = (PositionName) Enum.Parse(typeof(PositionName), rdr["Position"].ToString() ?? string.Empty);
                    employee.HiringDate = Convert.ToDateTime(rdr["HiringDate"]);
                }  
            }  
            return employee;  
        }  
  
        public void DeleteEmployees(int? id)  
        {  
            using (var con = new SqlConnection(_connectionString))  
            {  
                var cmd = new SqlCommand("spDeleteEmployee", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
                cmd.Parameters.AddWithValue("@Id", id);  
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }  
    }
}