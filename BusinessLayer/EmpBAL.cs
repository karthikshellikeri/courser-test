using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace BusinessLayer
{
    public class EmpBAL
    {
        List<Employee> employeeDetails = new List<Employee>();
        string connectionString = ConfigurationManager.ConnectionStrings["api"].ConnectionString;

        public List<Employee> FetchEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("selectallemployees", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee
                            {

                                // Assign values directly to properties
                                ProjectID = Convert.ToInt32(reader["ProjectID"]),
                                JobCode = Convert.ToInt32(reader["JobCode"]),
                                FacilityID = reader["FacilityID"].ToString(),
                                EmpName = reader["EmpName"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                DOJ = Convert.ToDateTime(reader["DOJ"]),
                                EmpID = Convert.ToInt32(reader["EmpID"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),

                            };
                            employeeDetails.Add(employee);
                        }
                    }
                }
            }
            return employeeDetails;
        }

        public bool InsertEmployee(Employee employeeModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertEmployee", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Assuming the parameters match the columns in your Employees table
                    cmd.Parameters.AddWithValue("@EmpID", employeeModel.EmpID);
                    cmd.Parameters.AddWithValue("@EmpName", employeeModel.EmpName);
                    cmd.Parameters.AddWithValue("@ProjectID", employeeModel.ProjectID);
                    cmd.Parameters.AddWithValue("@JobCode", employeeModel.JobCode);
                    cmd.Parameters.AddWithValue("@FacilityID", employeeModel.FacilityID);
                    cmd.Parameters.AddWithValue("@IsActive", employeeModel.IsActive);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@DOB", employeeModel.DOB);
                    cmd.Parameters.AddWithValue("@DOJ", employeeModel.DOJ);

                    connection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    // If one or more rows were affected, consider the insertion successful
                    return rowsAffected > 0;
                }
            }
        }

    }
}
