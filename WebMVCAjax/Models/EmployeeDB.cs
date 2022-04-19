using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebMVCAjax.Models
{
    public class EmployeeDB
    {
        // DB 연결
        // @"Data Source=DESKTOP-DD3FU43\SQLEXPRESS;uid=sa;pwd=1004;database=kosaDB"
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        // CRUD 함수
        public List<Employee> ListAll()
        {
            //SqlConnection, SqlCommend, DataReader
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("selectEmployee", conn);
                comm.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    employees.Add(new Employee
                    {
                        EmployeeID = Convert.ToInt32(dr["employeeID"]),
                        Name = dr["Name"].ToString(),
                        Age = Convert.ToInt32(dr["age"]),
                        State = dr["State"].ToString(),
                        Country = dr["Country"].ToString()
                    });
                }
            }
            return employees;
        }

        public int Add(Employee emp)
        {
            int returnValue = 0;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("insertUPdateEmployee",conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@id",emp.EmployeeID);     // 프로시저가 insert update 다가져서 줘야댐..
                comm.Parameters.AddWithValue("@Name", emp.Name);
                comm.Parameters.AddWithValue("@Age", emp.Age);
                comm.Parameters.AddWithValue("@State", emp.State);
                comm.Parameters.AddWithValue("@Country", emp.Country);
                comm.Parameters.AddWithValue("@Action", "insert");

                returnValue = comm.ExecuteNonQuery();
            }
                return returnValue;
        }
        public int update(Employee emp)
        {

            return 0;
        }
        public int Delete(int id)
        {

            return 0;
        }
    }
}