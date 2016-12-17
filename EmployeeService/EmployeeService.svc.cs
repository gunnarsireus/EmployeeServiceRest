using EmployeeService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.ServiceModel.Activation;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EmployeeService : IEmployeeService
    {
        public void AddEmployee()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection sc = new SqlConnection(cs))
            {
                using (var cmd = sc.CreateCommand())
                {
                    sc.Open();
                    cmd.CommandText = "INSERT INTO tblEmployee (Id,Name,Gender,DateOfBirth) VALUES(0,'','Female','2016-01-01')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(string Id)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection sc = new SqlConnection(cs))
            {
                using (var cmd = sc.CreateCommand())
                {
                    sc.Open();
                    cmd.CommandText = "DELETE FROM tblEmployee WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Employee GetEmployee(string Id)
        {
            Employee employee = new Employee();
            string cs = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@Id";
                parameterId.Value = Id;
                cmd.Parameters.Add(parameterId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employee.Id = Convert.ToInt32(reader["Id"]);
                    employee.Name = Convert.ToString(reader["Name"]);
                    employee.Gender = Convert.ToString(reader["Gender"]);
                    employee.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                }
            }
            if (employee.Name == null) return null;
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string cs = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployees", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(reader["Id"]);
                    employee.Name = Convert.ToString(reader["Name"]);
                    employee.Gender = Convert.ToString(reader["Gender"]);
                    employee.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    employees.Add(employee);
                }
            }
            return employees;
        }

        public void CreateEmployee(Employee employee)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@Id";
                parameterId.Value = employee.Id;
                cmd.Parameters.Add(parameterId);
                SqlParameter parameterName = new SqlParameter();
                parameterName.ParameterName = "@Name";
                parameterName.Value = employee.Name??"";
                cmd.Parameters.Add(parameterName);
                SqlParameter parameterGender = new SqlParameter();
                parameterGender.ParameterName = "@Gender";
                parameterGender.Value = employee.Gender??"";
                cmd.Parameters.Add(parameterGender);
                SqlParameter parameterDateOfBirth = new SqlParameter();
                parameterDateOfBirth.ParameterName = "@DateOfBirth";
                parameterDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(parameterDateOfBirth);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection sc = new SqlConnection(cs))
            {
                using (var cmd = sc.CreateCommand())
                {
                    sc.Open();
                    cmd.CommandText = "UPDATE tblEmployee SET Name = '" + employee.Name + "', Gender = '" + employee.Gender + "', DateOfBirth = '" + employee.DateOfBirth + "' WHERE Id=" + employee.Id;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
