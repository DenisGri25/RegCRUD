using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RegCRUD.Utility;

namespace RegCRUD.Models
{
    public class CompaniesDataAccessLayer
    {
         readonly string _connectionString = ConnectionString.CName;

        public IEnumerable<Companies> GetAllCompanies()  
        {  
            var lstCompanies = new List<Companies>();  
            using (var con = new SqlConnection(_connectionString))  
            {  
                var cmd = new SqlCommand("spGetAllCompanies", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
                con.Open();  
                var rdr = cmd.ExecuteReader();  
  
                while (rdr.Read())  
                {  
                    var company = new Companies();  
                    company.Id = Convert.ToInt32(rdr["Id"]);
                    company.CompanyName = rdr["CompanyName"].ToString();
                    company.OLF = rdr["OLF"].ToString();

                    lstCompanies.Add(company);  
                }  
                con.Close();  
            }  
            return lstCompanies;  
        }
        
        public void AddCompanies(Companies companies)  
        {  
            using (var con = new SqlConnection(_connectionString))  
            {  
                var cmd = new SqlCommand("spAddCompany", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
  
                cmd.Parameters.AddWithValue("@CompanyName", companies.CompanyName);  
                cmd.Parameters.AddWithValue("@OLF", companies.OLF);  

                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }  
  
        public void UpdateCompanies(Companies companies)  
        {  
            using (var con = new SqlConnection(_connectionString))  
            {  
                var cmd = new SqlCommand("spUpdateCompany", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
  
                cmd.Parameters.AddWithValue("@Id", companies.Id);  
                cmd.Parameters.AddWithValue("@CompanyName", companies.CompanyName);  
                cmd.Parameters.AddWithValue("@OLF", companies.OLF);  

                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }  
  
        public Companies GetCompaniesData(int? id)  
        {  
            var companies = new Companies();  
  
            using (var con = new SqlConnection(_connectionString))  
            {  
                var sqlQuery = "SELECT * FROM Companies WHERE Id= " + id;  
                var cmd = new SqlCommand(sqlQuery, con);  
                con.Open();  
                var rdr = cmd.ExecuteReader();  
  
                while (rdr.Read())  
                {  
                    companies.Id = Convert.ToInt32(rdr["Id"]);
                    companies.CompanyName = rdr["CompanyName"].ToString();
                    companies.OLF = rdr["OLF"].ToString();
                }  
            }  
            return companies;  
        }  
  
        public void DeleteCompanies(int? id)  
        {  
            using (var con = new SqlConnection(_connectionString))  
            {  
                var cmd = new SqlCommand("spDeleteCompany", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
                cmd.Parameters.AddWithValue("@Id", id);  
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }  
    }
}